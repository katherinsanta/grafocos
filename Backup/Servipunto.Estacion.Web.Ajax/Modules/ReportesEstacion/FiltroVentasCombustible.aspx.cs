using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
    public partial class FiltroVentasCombustible : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarPermisos())
            {

                if (!IsPostBack)
                {
                    FechaInicio.SelectedDate = DateTime.Today;
                    FechaFin.SelectedDate = DateTime.Today;
                    txtFechaInicio.Text = DateTime.Today.ToShortDateString();
                    txtFechaFinal.Text = DateTime.Today.ToShortDateString();
                    cargargrilla();

                }
                else
                {
                    this.GrVentasCombustible.PageSize = 10;

                    Traducir();
                }
            }
        }

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Auditoria";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Auditoria Ventas Combustible");

            if (!permiso)
            {
                lblError.Visible= true;
                lblError.Text=Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
                this.pnlForm.Visible = false;

                //this.MyForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion

        #region cargar grilla
        public void cargargrilla() {
            GrVentasCombustible.DataSource = Servipunto.Estacion.Libreria.Ventas.RecuperarVentasPorCombustible(Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFinal.Text));
            GrVentasCombustible.DataBind();


        }
        #endregion

        protected void ibMostrarCalendarioInicial_Click(object sender, ImageClickEventArgs e)
        {
            this.FechaInicio.Visible = !this.FechaInicio.Visible;
            if (this.FechaFin.Visible)
                this.FechaFin.Visible = !this.FechaFin.Visible;

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

        protected void ibMostrarCalendarioFinal_Click1(object sender, ImageClickEventArgs e)
        {
            this.FechaFin.Visible = !this.FechaFin.Visible;
            if (this.FechaInicio.Visible)
                this.FechaInicio.Visible = !this.FechaInicio.Visible;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cargargrilla();
        }

        protected void GrVentasCombustible_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string aux;
                aux = e.Row.Cells[2].Text;
                string aux2;
                aux2 = e.Row.Cells[3].Text;
                

                e.Row.Cells[2].Text =  (Convert.ToDateTime (aux).ToShortDateString ()) ;

                e.Row.Cells[3].Text = (Convert.ToDateTime(aux2).ToShortTimeString ());
            }
        }

        protected void GrVentasCombustible_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GrVentasCombustible_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(  Convert.ToString(e.CommandName) == "Reporte"){
                string argumento;
                string prefijo;
                string Consecutivo;
                Consecutivo  =  Convert.ToString(e.CommandArgument);


                DataDynamics.ActiveReports.ActiveReport report = null;
                if (lblTituloGenerales.Text == "Find by")
                    report = new Rpt.FacturaCombustible("", Convert.ToInt32(Consecutivo), 1);
                else
                    report = new Rpt.FacturaCombustible("", Convert.ToInt32(Consecutivo), 0);
                Session["Formato"] = "pdf";
                Session.Add("LastReport", report);
                //Response.Write("<script type='text/javascript'>window.open('../Visor/PDF.aspx');</script>");
               Response.Redirect("../Visor/PDF.aspx", true );
            }           
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 16/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1007, Global.Idioma);
            lblInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(249, Global.Idioma);
            lblFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(253, Global.Idioma);
            Button1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(770, Global.Idioma);
            GrVentasCombustible.Columns[0].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1513, Global.Idioma).ToUpper();
            GrVentasCombustible.Columns[1].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(144, Global.Idioma).ToUpper();
            GrVentasCombustible.Columns[2].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(441, Global.Idioma).ToUpper();
            GrVentasCombustible.Columns[3].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma).ToUpper();
            GrVentasCombustible.Columns[5].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2069, Global.Idioma).ToUpper();
            GrVentasCombustible.Columns[7].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(934, Global.Idioma).ToUpper();
            LinkButton1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
        }
        #endregion
    }
}
