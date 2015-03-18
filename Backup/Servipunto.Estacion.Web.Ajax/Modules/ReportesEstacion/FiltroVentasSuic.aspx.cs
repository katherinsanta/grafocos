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

namespace Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion
{
    public partial class FiltroVentasSuic : System.Web.UI.Page
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
            ViewState["Control"] = "0";
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
            if (this.IsPostBack)
            {
                this.EjecutarReporte();
            }
            else if (ViewState["Control"].ToString() !="1")
            {
                ViewState["Control"] = "1";
                VerificarPermisos();
            }
        }

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "suic";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Vehiculo suic");

            if (!permiso)
            {
                lblError.Visible= true;
                lblError.Text =Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
                this.pnlForm.Visible = false;

                //this.MyForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion

        #region EjecutarRecporte
        private void EjecutarReporte() 
        {
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 345, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                DataDynamics.ActiveReports.ActiveReport report = null;

                DateTime ini = Convert.ToDateTime(txtFechaInicial.Text);
                report = new Servipunto.Estacion.Web.Ajax.Modules.Rpt.VentasSuic(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text),Convert.ToDateTime(TxtFechMantIni.Text),Convert.ToDateTime(TxtFechMantFin.Text), Convert.ToInt32(txtCantidad.Text));

                Session.Add("LastReport", report);
                Session["Formato"] = ddlOrden.SelectedValue;
                Response.Redirect("../Visor/PDF.aspx", false);

            }
            catch (Exception ex)
            {
                this.SetError(ex.Message, false);
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

        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.EjecutarReporte();
        }



    }
}
