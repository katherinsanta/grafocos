using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Servipunto.Estacion.AccesoDatos.EntityClasses;
using Servipunto.Estacion.AccesoDatos.CollectionClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Servipunto.Estacion.AccesoDatos.HelperClasses;


namespace Servipunto.Estacion.Web.Modules.Consultas
{
    public partial class FacturasCanastilla : System.Web.UI.Page
    {
        #region Page_PreLoad Event
        /// <summary>
        /// Adaptacion de traduccion al formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PreLoad(object sender, System.EventArgs e)
        {
            Traducir();
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarPermisos())
            {

                this.FiltrosDeBusqueda1.Buscar += new EventHandler(FiltrosDeBusqueda1_Buscar);
                if (!this.Page.IsPostBack)
                {
                    CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    //this.lblTitle.Text = "<b>Consulta de Facturas Venta Canastilla</b>";
                    string htmlAcciones = "";
                    this.AgregarAccion(ref htmlAcciones, "default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
                    this.Acciones.InnerHtml = htmlAcciones + "<br><br>";
                    CargarCombos();
                    FechaInicio.SelectedDate = DateTime.Today;
                    FechaFin.SelectedDate = DateTime.Today;
                    txtFechaInicio.Text = DateTime.Today.ToShortDateString();
                    txtFechaFinal.Text = DateTime.Today.ToShortDateString();
                    FiltrosDeBusqueda1.RegistrosPorPagina = 10;
                    string conexion = Servipunto.Libreria.Cryptography.Decrypt(System.Configuration.ConfigurationManager.AppSettings["Administ"]);
                    Servipunto.Estacion.AccesoDatos.HelperClasses.DbUtils.ActualConnectionString = conexion;
                    //grdFacturas.DataSource = Libreria.Ventas.VentasCanastilla(FechaInicio.SelectedDate, FechaFin.SelectedDate, ddlCliente.SelectedValue, ddlEstado.SelectedValue, chkTurno.Checked ? "0": txtTurno.Text).Tables[0];
                    //grdFacturas.DataSource = Libreria.Ventas.VentasCanastilla();
                    //grdFacturas.DataBind();
                }
                this.grdFacturas.PageSize = FiltrosDeBusqueda1.RegistrosPorPagina;

            }

        }

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Consultas";
            const string opcion = "Facturas Canastilla";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Facturas Canastilla");

            if (!permiso)
            {
                lblError.Visible = true;
                lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
                pnlForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion


        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(966, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1640, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1071, Global.Idioma);

            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(281, Global.Idioma);
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion
        
        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
        }


        #region Evento GdvFacturas_RowCommand
        protected void grdFacturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string caso = Convert.ToString(e.CommandName);
            
            string IdFactura = Convert.ToString(e.CommandArgument);
            DataDynamics.ActiveReports.ActiveReport report = null;
            switch (caso)
            {
                case "Ver":
                    Response.Redirect("~/Modules/Consultas/FacturaCanastilla.aspx?IdFactura=" + IdFactura );
                    break;

                case "Asignar":
                    Response.Redirect("~/Modules/Consultas/AsignarClienteVentaCreditoCanastilla.aspx?IdFactura=" + IdFactura);
                    break;

                case "Imprimir":
                    report = new Rpt.FacturaCanastilla("", IdFactura);
                    Session["Formato"] = "pdf";
                    Session.Add("LastReport", report);
                    Response.Redirect("../Visor/PDF.aspx", false);
                    //Response.Redirect("~/Modules/Comerciales/Redireccion.aspx?Opcion=FAC&IdNota=" + Convert.ToString(IdFactura));
                    //ActualizarCampoImpresionFactura(Convert.ToInt32(IdFactura));
                    break;
                case "Anular":

                    try
                    {
                        DataTable objDatos = Libreria.Ventas.ObtenerVentaCanastilla("", Convert.ToInt32(IdFactura)).Tables[0];
                        if (objDatos.Rows[0]["Estado"].ToString() == "Activa")
                        {
                            Libreria.Ventas.ActualizarVentaCanastilla("1", objDatos.Rows[0]["Cod_Cli"].ToString(), objDatos.Rows[0]["Placa"].ToString(), Convert.ToInt32(IdFactura));
                            ActualizarFiltrosBusqueda();
                        }
                       
                        
                    }
                    catch
                    {

                    }
                    
                    break;
            }
        }
        #endregion



        protected void grdFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int a = 1;
            }

        }

        #region gdvVales_DataBinding
        protected void grdFacturas_DataBinding(object sender, EventArgs e)
        {
            
                grdFacturas.Columns[0].HeaderText= Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1513, Global.Idioma);
                grdFacturas.Columns[1].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2021, Global.Idioma);
                grdFacturas.Columns[2].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(966, Global.Idioma);
                grdFacturas.Columns[3].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(294, Global.Idioma);
                grdFacturas.Columns[4].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma);
                grdFacturas.Columns[5].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(851, Global.Idioma);
                grdFacturas.Columns[6].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2069, Global.Idioma);
                grdFacturas.Columns[8].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
                grdFacturas.Columns[9].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
                grdFacturas.Columns[10].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Global.Idioma);
                grdFacturas.Columns[11].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1312, Global.Idioma);
                grdFacturas.Columns[12].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(761, Global.Idioma);
                grdFacturas.Columns[13].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(554, Global.Idioma);
            
            //this.EstablecerCultura();
        }
        #endregion

        protected void grdFacturas_RowCommand(object sender, GridViewEditEventArgs e)
        {
            int fila = e.NewEditIndex;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarCombos()
        {
            //Libreria.Comercial.Clientes objclientes = new Servipunto.Estacion.Libreria.Comercial.Clientes(2);
            //ddlCliente.DataSource = objclientes;
            //ddlCliente.DataValueField = "CodigoCliente";
            //ddlCliente.DataTextField = "NombreCliente";
            //ddlCliente.DataBind();
            //ddlCliente.Items.Insert(0, new ListItem("<Todos>", "0"));

            RadioButtonTraduccion();
        }
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlEstado
            this.ddlEstado.Items.Clear();
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "1"));
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "0"));
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "2"));
            this.ddlEstado.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlComodin2
            this.ddlComodin2.Items.Clear();
            this.ddlComodin2.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2070, Global.Idioma), "1"));
            this.ddlComodin2.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2071, Global.Idioma), "2"));
            this.ddlComodin2.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2072, Global.Idioma), "3"));
            this.ddlComodin2.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2073, Global.Idioma), "0"));
            this.ddlComodin2.SelectedValue = "3";
            #endregion
            #region poblar RadioButton  ddlComodin
            this.ddlComodin.Items.Clear();
            this.ddlComodin.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2070, Global.Idioma), "1"));
            this.ddlComodin.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2071, Global.Idioma), "2"));
            this.ddlComodin.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2072, Global.Idioma), "3"));
            this.ddlComodin.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2073, Global.Idioma), "0"));
            this.ddlComodin.SelectedValue = "3";
            #endregion
            
        }
        #endregion
        protected void chkTurno_CheckedChanged(object sender, EventArgs e)
        {
            //txtTurno.Enabled = !chkTurno.Checked;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            /*if (!chkTurno.Checked)
            {
                if (txtTurno.Text != "")
                {
                    //grdFacturas.DataSource = Libreria.Ventas.VentasCanastilla(FechaInicio.SelectedDate, FechaFin.SelectedDate, ddlCliente.SelectedValue, ddlEstado.SelectedValue, chkTurno.Checked ? "0" : txtTurno.Text).Tables[0];
                    //grdFacturas.DataBind();
                }
                else
                {
                    lblError.Text = "Error en consulta, Turno no especificado";
                    lblError.Visible = true;
                }
            }
            else
            {
                //grdFacturas.DataSource = Libreria.Ventas.VentasCanastilla(FechaInicio.SelectedDate, FechaFin.SelectedDate, ddlCliente.SelectedValue, ddlEstado.SelectedValue, chkTurno.Checked ? "0" : txtTurno.Text).Tables[0];
                //grdFacturas.DataBind();
            }*/
            
            
        }

        protected void FechaInicio_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaInicio.Text = this.FechaInicio.SelectedDate.ToString("dd/MM/yyyy");
            this.FechaInicio.Visible = !this.FechaInicio.Visible;
        }

        protected void FechaFin_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaFinal.Text = this.FechaFin.SelectedDate.ToString("dd/MM/yyyy");
            this.FechaFin.Visible = !this.FechaFin.Visible;

        }

        protected void ibMostrarCalendarioFinal_Click(object sender, ImageClickEventArgs e)
        {
           

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {


        }

        protected void ibMostrarCalendarioInicial_Click(object sender, ImageClickEventArgs e)
        {
            this.FechaInicio.Visible = !this.FechaInicio.Visible;
            if (this.FechaFin.Visible)
                this.FechaFin.Visible = !this.FechaFin.Visible;

        }

        protected void ibMostrarCalendarioFinal_Click1(object sender, ImageClickEventArgs e)
        {
            this.FechaFin.Visible = !this.FechaFin.Visible;
            if (this.FechaInicio.Visible)
                this.FechaInicio.Visible = !this.FechaInicio.Visible;
        }

        #region Metodo FiltrosDeBusqueda1_Buscar
        void FiltrosDeBusqueda1_Buscar(object sender, EventArgs e)
        {
            this.ActualizarFiltrosBusqueda();
        }
        #endregion

        #region ActualizarListadoPrincipal
        /// <summary>
        /// Actualiza la grilla principal con los nuevos parametros asignados
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha: 12/06/2009
        /// Autor: Elvis Astaiza Gutierrez.
        private void ActualizarFiltrosBusqueda()
        {

            IPredicateExpression objFiltro = new PredicateExpression();
            try
            {

                objFiltro.AddWithAnd(GrillaConsultaVentaCanastillaFields.Fecha >= Convert.ToDateTime(this.txtFechaInicio.Text) & GrillaConsultaVentaCanastillaFields.Fecha <= Convert.ToDateTime(this.txtFechaFinal.Text));
                
                if (txtTurno.Text.Trim() != "")
                    objFiltro.AddWithAnd(GrillaConsultaVentaCanastillaFields.NumTurn == Convert.ToInt32(txtTurno.Text));
                
                if (ddlEstado.SelectedValue != "2")
                {
                    if ( ddlEstado.SelectedValue == "0")
                        objFiltro.AddWithAnd(GrillaConsultaVentaCanastillaFields.Estado == "Activa");
                    else
                        objFiltro.AddWithAnd(GrillaConsultaVentaCanastillaFields.Estado != "Activa");
                }

                if (txtNombreCliente.Text != "")
                    objFiltro.AddWithAnd(GrillaConsultaVentaCanastillaFields.Nombre % this.AsignarComodines(this.txtNombreCliente.Text, ddlComodin.SelectedValue));

                if (txtIdentificacion.Text != "")
                    objFiltro.AddWithAnd(GrillaConsultaVentaCanastillaFields.CodCli % this.AsignarComodines(this.txtIdentificacion.Text, ddlComodin2.SelectedValue));

                
                /*switch (ddlCriterio.SelectedValue)
                {
                    case "-1":
                        objFiltro = null;
                        break;
                    case "0":
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.NombreRazonSocial % this.AsignarComodines(this.txtIdentificacion.Text, ddlComodin.SelectedValue));
                        break;

                    case "1":
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.Fecha >= Convert.ToDateTime(this.txtFechaInicial.Text) & ConsultaFacturasFiltroFields.Fecha <= Convert.ToDateTime(this.txtFechaFinal.Text));
                        break;

                    case "2":
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.CodigoCentroVenta % this.AsignarComodines(this.ddlEstacion.SelectedValue.ToString(), ddlComodin.SelectedValue));
                        break;
                    case "3":
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.NombreRazonSocial % this.AsignarComodines(this.txtIdentificacion.Text, ddlComodin.SelectedValue));
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.Fecha >= Convert.ToDateTime(this.txtFechaInicial.Text) & ConsultaFacturasFiltroFields.Fecha <= Convert.ToDateTime(this.txtFechaFinal.Text));
                        break;
                    case "4":
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.NombreRazonSocial % this.AsignarComodines(this.txtIdentificacion.Text, ddlComodin.SelectedValue));
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.Fecha >= Convert.ToDateTime(this.txtFechaInicial.Text) & ConsultaFacturasFiltroFields.Fecha <= Convert.ToDateTime(this.txtFechaFinal.Text));
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.CodigoCentroVenta % this.AsignarComodines(this.ddlEstacion.SelectedValue.ToString(), ddlComodin.SelectedValue));
                        break;
                    case "5":
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.CodigoCentroVenta % this.AsignarComodines(this.ddlEstacion.SelectedValue.ToString(), ddlComodin.SelectedValue));
                        objFiltro.AddWithAnd(ConsultaFacturasFiltroFields.Fecha >= Convert.ToDateTime(this.txtFechaInicial.Text) & ConsultaFacturasFiltroFields.Fecha <= Convert.ToDateTime(this.txtFechaFinal.Text));
                        break;
                    case "6":
                        break;
                    case "7":
                        objFiltro.Add(null);
                        break;
                    default:
                        throw new Exception("Consulta no configurada '" + ddlCriterio.SelectedValue + "'");

                }*/
            }
            catch (Exception ex)
            {
                //this.SetError("Problemas al consultar: " + ex.Message, false);
            }
            finally
            {
                FiltrosDeBusqueda1.Filtro = objFiltro;
            }

        }
        #endregion

        #region DatoABuscar
        /// <summary>
        /// Retorna el dato a buscar con los comodines de coincidencia
        /// </summary>
        /// <param name="datoABuscar">Dato a colocar los comodines</param>
        /// <param name="modoDeBusqueda">Ubicacion de comodines</param>
        /// <returns>Dato formateado</returns>
        /// Referencia Documental: (Falta)
        /// Fecha:  09/06/2009
        /// Autor:  Elvis Astaiza Gutierrez
        private string AsignarComodines(string datoABuscar, string modoDeBusqueda)
        {
            if (datoABuscar.Length == 0)
                return datoABuscar;
            if (modoDeBusqueda == "1")
                datoABuscar += "%";
            else if (modoDeBusqueda == "2")
                datoABuscar = "%" + datoABuscar;
            else if (modoDeBusqueda == "3")
                datoABuscar = "%" + datoABuscar + "%";
            return datoABuscar;
        }
        #endregion

       
    }
}
