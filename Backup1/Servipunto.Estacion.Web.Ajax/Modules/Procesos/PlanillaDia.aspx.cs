using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Servipunto.Estacion.Web.Ajax.Modules.Procesos
{
    public partial class PlanillaDia : System.Web.UI.Page
    {
        decimal _TotalCantidad;
        decimal _TotalSubtotal;
        decimal _Total;
        decimal _TotalDescuento;

        decimal _TotalDiferenciaLects;
        decimal _TotalCalibracionLects;
        decimal _TotalCantidadLects;
        decimal _TotalValorLects;



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                txtFecha.Text = Request.QueryString["FechaInicial"];
                CargueDatos();
            }

        }

        private void CargueDatos()
        {
            txtFecha.Text = DateTime.Parse(txtFecha.Text).ToString("yyyy-MM-dd");
            DataTable datosVentas;
            DataTable datosLecturas;
            DataTable datosCanastilla;
            DataTable datosBolsas;
            DataTable datosResumenArticulo;
            DataTable datosResumenFormasPago;
            DataTable datosDescuadre;
            DataTable datosDetalleTanques;
            _TotalCantidad = 0;
            _TotalSubtotal = 0;
            _TotalDescuento = 0;
            _Total = 0;

            datosVentas = GetDataVentas().Tables[0];
            grdDetalleVentas.DataSource = datosVentas;
            grdDetalleVentas.DataBind();

            datosLecturas = GetDataLecturas().Tables[0];
            GridLecturas.DataSource = datosLecturas;
            GridLecturas.DataBind();


            datosCanastilla = GetDataCanastilla().Tables[0];
            grdCanastilla.DataSource = datosCanastilla;
            grdCanastilla.DataBind();

            datosBolsas = GetDataBolsa().Tables[0];
            //grdBolsasTurno.DataSource = datosBolsas;
            //grdBolsasTurno.DataBind();

            datosResumenArticulo = GetDataResumenArticulos().Tables[0];
            grdArticulos.DataSource = datosResumenArticulo;
            grdArticulos.DataBind();

            datosResumenFormasPago = GetDataResumenFormasPago().Tables[0];
            grdFormasPago.DataSource = datosResumenFormasPago;
            grdFormasPago.DataBind();


            datosDescuadre = GetDataDescuadre().Tables[0];
            grdDescuadre.DataSource = datosDescuadre;
            grdDescuadre.DataBind();

            datosDetalleTanques = GetDataDetalleTanques().Tables[0];
            GrdDetalleTanques.DataSource = datosDetalleTanques;
            GrdDetalleTanques.DataBind();

        }
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
                    _TotalValorLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "VentasVentas"));

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



            DataTable table = this.GetDataVentas().Tables[0];
            table.DefaultView.Sort = sortExpression + direction;
            grdDetalleVentas.DataSource = table;
            grdDetalleVentas.DataBind();

        }

        private DataSet GetDataVentas()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
         
            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDVentasCombustibleDiario", parameters);
            
            return reader;


        }

        private DataSet GetDataLecturas()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);

            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);
         

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptResumenDiarioLecturas", parameters);
            
            return reader;
        }

        private DataSet GetDataCanastilla()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);

            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);
         
            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDVentasCanastilla", parameters);            
            return reader;
        }

        private DataSet GetDataBolsa()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicio", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);

            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptResumenDiarioConsignaciones", parameters);
                       
            return reader;
        }


        private DataSet GetDataResumenArticulos()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);

            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);
            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SP_ResumenArticuloTurno", parameters);
                                  
            return reader;
        }


        private DataSet GetDataDescuadre()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaIniciO", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);

            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);
         
            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptResumenDiarioConsignaciones", parameters);

            return reader;
        }


        private DataSet GetDataDetalleTanques()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);

            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptTanqueVariacionMensaje", parameters);



            return reader;
        }
        private DataSet GetDataResumenFormasPago()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);

            parameters[0].Value = DateTime.Parse(txtFecha.Text);
            parameters[1].Value = DateTime.Parse(txtFecha.Text);
         

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDFormasPago", parameters);
            
            return reader;
        }

        private void ConversionXML(DataSet reader, string fuente)
        {
            Servipunto.Estacion.Libreria.Configuracion.Datos_Gene ObjDa = new Libreria.Configuracion.Datos_Gene();

            if (reader.Tables.Count > 0)
            {
                reader.Tables[0].TableName = fuente;
                if (!System.IO.Directory.Exists(ObjDa[0].RutaExportarPredeterminada))
                    System.IO.Directory.CreateDirectory(ObjDa[0].RutaExportarPredeterminada);

                reader.WriteXml(ObjDa[0].RutaExportarPredeterminada + "\\" + fuente + txtFecha.Text.Replace("/", "-") + ".xml");
            }
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
        


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //this.ModalPopupExtender1.Show();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //this.ModalPopupExtender1.Show();

        }

        
        


        protected void btnGenerarXML_Click(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Parse(txtFecha.Text).ToString("dd-MM-yyyy");
            DataSet datosVentas;
            DataSet datosLecturas;
            DataSet datosCanastilla;
            DataSet datosBolsas;
            DataSet datosResumenArticulo;
            DataSet datosResumenFormasPago;
            DataSet datosDescuadre;
            DataSet datosDetalleTanques;

            _TotalCantidad = 0;
            _TotalSubtotal = 0;
            _TotalDescuento = 0;
            _Total = 0;

            datosVentas = GetDataVentas();        
            datosLecturas = GetDataLecturas();
            datosCanastilla = GetDataCanastilla();        
            datosBolsas = GetDataBolsa();        
            datosResumenArticulo = GetDataResumenArticulos();
            datosResumenFormasPago = GetDataResumenFormasPago();
            datosDescuadre = GetDataDescuadre();
            datosDetalleTanques = GetDataDetalleTanques();

            ConversionXML(datosVentas, "Ventas");
            ConversionXML(datosLecturas, "Lecturas");
            ConversionXML(datosCanastilla, "Canastilla");
            ConversionXML(datosBolsas, "Bolsas");
            ConversionXML(datosResumenArticulo, "Articulos");
            ConversionXML(datosResumenFormasPago, "FormasPago");
            ConversionXML(datosDetalleTanques, "Tanques");

            string javaScript =
            "<script type=text/JavaScript>" +
            "Alert('" + "Archivos XML generados OK"+ "');" + "</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Archivos XML", "alert('Archivos Generados con exito');", true);
            //ClientScript.RegisterStartupScript(GetType(), "message", javaScript);
            
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FiltroPlanillaDia.aspx");
        }

        protected void btnReporteLog_Click(object sender, EventArgs e)
        {

            //DataDynamics.ActiveReports.ActiveReport report = null;


            //report = new Rpt.LogPlanillaDia(DateTime.Parse(txtFecha.Text));
            //Session["LastReport"] = report;
            //Session["Formato"] = "pdf";
            //Response.Redirect("../Visor/PDF.aspx", false);
           
            
        }

        
    }
}