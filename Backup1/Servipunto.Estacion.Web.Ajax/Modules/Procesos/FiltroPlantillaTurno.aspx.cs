using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class FiltroPlantillaTurno : System.Web.UI.Page
    {
        //acumuladores ventas

        decimal _TotalCantidad;
        decimal _TotalSubtotal;
        decimal _Total;
        decimal _TotalDescuento;

        decimal _TotalDiferenciaLects;
        decimal _TotalCalibracionLects;
        decimal _TotalCantidadLects;
        decimal _TotalValorLects;



        
        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
            if (this.IsPostBack)
            {
                //txtFechaInicial.Text = DateTime.Today.ToString("dd-MM-yyyy");
                CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (Request.Form["__EVENTTARGET"].Length == 0)
                {
                    this.lblError.Visible = false;
                }
            }
            else
            {
                this.VerificarPermisos();
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 207, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.InicializarForma();
            }
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Interfaz Contable";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Generacion Archivo Plano de Facturas");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);

                return false;
            }

            return true;
        }
        #endregion
        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.pnlForm.Visible = false;

        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
        }
        #endregion
        #region EjecutarSP
        private void EjecutarSP()
        {
            string resultado;
            string[] archivo;
            this.lblError.Visible = false;
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 208, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
                resultado = objInterfazContables.PlanoFacturasEstandar(
                    "c:\\TemporalPlanos",
                    Convert.ToDateTime(txtFechaInicial.Text),
                    int.Parse(txtIsla.Text.Trim()),
                    int.Parse(txtTurno.Text.Trim())
                    );


                archivo = resultado.Split(",".ToCharArray());
                if (archivo[0].ToString() != "OK")
                {
                    this.SetError(resultado, false);
                    return;
                }

                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", "attachment; filename =" + archivo[1].Substring(archivo[1].LastIndexOf("\\") + 1));
                Response.WriteFile(archivo[1]);
                Response.End();
            }
            catch (Exception ex)
            {
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma) + ex.Message, false);
                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1757, Global.Idioma) + ex.StackTrace, Libreria.Configuracion.PalabrasIdioma.Traduccion(1758, Global.Idioma));
                }
                catch (Exception exx)
                {
                    lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) + ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) + exx.Message;
                }
                #endregion

            }
        }
        #endregion

        #region InicializarForma
        private void InicializarForma()
        {
            #region traduccion
            txtFechaInicial.Text = DateTime.Today.ToString("dd-MM-yyyy");
            txtTurno.Text = "1";
            txtIsla.Text = "1";
            this.lblReporte.Text = "<b> Generar Planilla Turno </b>";
            //MostrarDatos();

            #endregion
            
        }
        #endregion

        #region Método GuardarPlanoTotales
        private void GuardarPlanoTotales()
        {
            //se hace el mismo procedimiento para la generación del plano
            string resultado;
            string[] archivo;

            this.lblError.Visible = false;
            try
            {
                Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 208, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                resultado = objInterfazContables.PlanoTotalesEstandar("TotalesCuenta-" + Convert.ToDateTime(txtFechaInicial.Text).ToString("dd-MM-yyyy") + ".txt",
                    "c:\\TemporalPlanos",
                    Convert.ToDateTime(txtFechaInicial.Text),
                    int.Parse(txtIsla.Text.Trim()),
                    int.Parse(txtTurno.Text.Trim()),
                    "|"
                    );


                archivo = resultado.Split(",".ToCharArray());
                if (archivo[0].ToString() != "OK")
                {
                    this.SetError(resultado, false);
                    return;
                }

                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", "attachment; filename =" + archivo[1].Substring(archivo[1].LastIndexOf("\\") + 1));
                Response.WriteFile(archivo[1]);
                Response.End();
            }
            catch (Exception ex)
            {
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma) + ex.Message, false);
            }

        }
        #endregion

        #region LimpiarDirectorio
        /// <summary>
        /// Borra los archivos de planos existentes en el directorio de la aplicación
        /// </summary>
        private void LimpiarDirectorio()
        {
            try
            {
                string[] arreglo = System.IO.Directory.GetFiles(Server.MapPath("../."));
                foreach (string c in arreglo)
                    System.IO.File.Delete(c);
            }
            catch (Exception)
            {

            }

        }

        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.lblGuardarFacturas.Click += new System.EventHandler(this.lblGuardarFacturas_Click);
            //this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.lnkGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }

     
        #endregion



     


        protected void grdDetalleVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _TotalCantidad += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                    _TotalSubtotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SubTotal"));
                    _TotalDescuento += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Descuento"));
                    _Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {

                    e.Row.Cells[8].Text = "TOTAL:";
                    
                    e.Row.Cells[9].Text = _TotalCantidad.ToString("n3");
                    e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[10].Text = _TotalSubtotal.ToString("c3");
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[11].Text = _TotalDescuento.ToString("c3");
                    e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[12].Text = _Total.ToString("c3");
                    e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Font.Bold = true;

                }
            }



            catch (Exception err)
            {

                string error = err.Message.ToString() + " - " + err.Source.ToString();

            }


        }

        protected void GridLecturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _TotalDiferenciaLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "diferencia"));
                    _TotalCalibracionLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Calibracion"));
                    _TotalCantidadLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "VentasGls"));
                    _TotalValorLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Valor"));

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {                                                   

                    e.Row.Cells[3].Text = "TOTAL:";

                    e.Row.Cells[4].Text = _TotalDiferenciaLects.ToString("n3");
                    
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[5].Text = _TotalCalibracionLects.ToString("N3");
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[6].Text = _TotalCantidadLects.ToString("N3");
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[7].Text = _TotalValorLects.ToString("c3");
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Font.Bold = true;

                }
            }



            catch (Exception err)
            {

                string error = err.Message.ToString() + " - " + err.Source.ToString();

            }


        }

        protected void SortingGrilla(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            string direction = string.Empty;

            if (e.SortDirection == SortDirection.Ascending)
            {

                e.SortDirection = SortDirection.Ascending;
                direction = " ASC";
            }
            else
            {
                e.SortDirection = SortDirection.Descending;
                direction = " DESC";
            }



            DataTable table = this.GetDataVentas();
            table.DefaultView.Sort = sortExpression + direction;
            grdDetalleVentas.DataSource = table;
            grdDetalleVentas.DataBind();

        }

        private DataTable GetDataVentas()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Num_Tur", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Cod_Isl", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[2].Value = int.Parse(txtTurno.Text);
            parameters[3].Value = int.Parse(txtIsla.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDDVentasCombustible", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataLecturas()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Num_Tur", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Cod_Isl", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[2].Value = int.Parse(txtTurno.Text);
            parameters[3].Value = int.Parse(txtIsla.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptResumenDiarioLecturas", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataCanastilla()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Num_Tur", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Cod_Isl", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[2].Value = int.Parse(txtTurno.Text);
            parameters[3].Value = int.Parse(txtIsla.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDVentasCanastilla", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataBolsa()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Num_Tur", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Cod_Isl", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[2].Value = int.Parse(txtTurno.Text);
            parameters[3].Value = int.Parse(txtIsla.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SP_ConsultaBolsasTurno", parameters);

            return reader.Tables[0];
        }


        private DataTable GetDataResumenArticulos()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Num_Tur", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Cod_Isl", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[2].Value = int.Parse(txtTurno.Text);
            parameters[3].Value = int.Parse(txtIsla.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SP_ResumenArticuloTurno", parameters);

            return reader.Tables[0];
        }


        private DataTable GetDataDescuadre()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicio", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Num_Tur", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Cod_Isl", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[2].Value = int.Parse(txtTurno.Text);
            parameters[3].Value = int.Parse(txtIsla.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptResumenDiarioConsignaciones", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataResumenFormasPago()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Num_Tur", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Cod_Isl", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(txtFechaInicial.Text);
            parameters[2].Value = int.Parse(txtTurno.Text);
            parameters[3].Value = int.Parse(txtIsla.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDFormasPago", parameters);

            return reader.Tables[0];
        }



        /// <summary>
        /// Gets or sets the grid view sort direction.
        /// </summary>
        /// <value>
        /// The grid view sort direction.
        /// </value>
        public SortDirection SortDirection
        {
            get
            {
                if (ViewState["SortDirection"] == null)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }
                else if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
                {
                    ViewState["SortDirection"] = SortDirection.Descending;
                }
                else if ((SortDirection)ViewState["SortDirection"] == SortDirection.Descending)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }

                return (SortDirection)ViewState["SortDirection"];
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }

        

        private void MostrarDatos()
        {
           // txtFechaInicial.Text = DateTime.Today.ToString("dd-MM-yyyy");
            DataTable datos;
            _TotalCantidad = 0;
            _TotalSubtotal = 0;
            _TotalDescuento = 0;
            _Total = 0;
            datos = GetDataVentas();
            grdDetalleVentas.DataSource = datos;
            grdDetalleVentas.DataBind();

        }

        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //this.ModalPopupExtender1.Show();
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender1.Show();

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {

            Response.Redirect("PlanillaTurno.aspx?FechaInicial="+ txtFechaInicial.Text + "&Isla=" + txtIsla.Text + "&Turno="+ txtTurno.Text);
            txtFechaInicial.Text = DateTime.Parse(txtFechaInicial.Text).ToString("dd-MM-yyyy");            
            DataTable datosVentas;
            DataTable datosLecturas;
            DataTable datosCanastilla;
            DataTable datosBolsas;
            DataTable datosResumenArticulo;
            DataTable datosResumenFormasPago;
            DataTable datosDescuadre;
            
            _TotalCantidad = 0;
            _TotalSubtotal = 0;
            _TotalDescuento = 0;
            _Total = 0;

            datosVentas = GetDataVentas();
            grdDetalleVentas.DataSource = datosVentas;
            grdDetalleVentas.DataBind();

            datosLecturas = GetDataLecturas();
            GridLecturas.DataSource = datosLecturas;
            GridLecturas.DataBind();


            datosCanastilla = GetDataCanastilla();
            grdCanastilla.DataSource = datosCanastilla;
            grdCanastilla.DataBind();

            datosBolsas = GetDataBolsa();
            grdBolsasTurno.DataSource = datosBolsas;
            grdBolsasTurno.DataBind();

            datosResumenArticulo = GetDataResumenArticulos();
            grdArticulos.DataSource = datosResumenArticulo;
            grdArticulos.DataBind();



            datosResumenFormasPago = GetDataResumenFormasPago();
            grdFormasPago.DataSource = datosResumenFormasPago;
            grdFormasPago.DataBind();


            datosDescuadre = GetDataDescuadre();
            grdDescuadre.DataSource = datosDescuadre;
            grdDescuadre.DataBind();
            this.ModalPopupExtender1.Show();


        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            lblID.Text = grdDetalleVentas.DataKeys[gvrow.RowIndex].Value.ToString();
            txtfname.Text = gvrow.Cells[2].Text;
            txtlname.Text = gvrow.Cells[3].Text;
            txtCity.Text = gvrow.Cells[4].Text;
            txtDesg.Text = gvrow.Cells[5].Text;
            this.ModalPopupExtender1.Show();
            this.ModalPopupExtender2.Show();
        }

        protected void imgbtnLecturas_Click(object sender, ImageClickEventArgs e)
        {
                    
        }


    }
}