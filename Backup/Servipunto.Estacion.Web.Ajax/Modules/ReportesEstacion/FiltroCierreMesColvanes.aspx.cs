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
    public partial class FiltroCierreMesColvanes : System.Web.UI.Page
    {
        #region Declaración de Controles       


        #endregion

        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (Request.Form["__EVENTTARGET"].Length == 0)
                {
                  
                    //this.lblEstado.Text = "ejecutando 0";
                    this.EjecutarReporte();
                }
            }
            else
            {
              
                this.VerificarPermisos();
                this.InicializarForma();
            }
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Periodo de Tiempo Real";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Mes Especifico");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
                //this.MyForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion

        #region EjecutarReporte
        private void EjecutarReporte()
        {
            try
            {
              
               // this.lblEstado.Text = "eje 1";
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 336, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                DataDynamics.ActiveReports.ActiveReport report = null;
                //Por defecto el reporte es resumido
                string strYear = DateTime.Now.Year.ToString();
                //string strFechaInicial = Calendar1.SelectedDate.ToString("yyyyMMdd");
                //string strFechaFinal = Calendar2.SelectedDate.ToString("yyyyMMdd");             
                report = new Servipunto.Estacion.Web.Modules.Rpt.CierreMesColvanes(Calendar1.SelectedDate, Calendar2.SelectedDate);
                //Actualiza la variable de sesión
               // this.lblEstado.Text = "eje 2";
                Session.Add("LastReport", report);
                //Envía el reporte al pdf
                Response.Redirect("../Visor/PDF.aspx", false);
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message);

                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el reporte de ventas por mes laboral. ");
                }
                catch (Exception exx)
                {
                    lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                    this.SetError(lblError.Text);

                }
                #endregion

            }
        }
        #endregion

        #region InicializarForma
        private void InicializarForma()
        {
            Response.Write("llego 00000");
            Calendar1.SelectedDate = DateTime.Now;
            Calendar2.SelectedDate = DateTime.Now;
            this.lblReporte.Text = "<b>Reporte Cierre Mes</b>";
        }
        #endregion

        #region SetError
        private void SetError(string message)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


        private void Alert(string mensaje)
        {
           
          //  ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:Alert('" + mensaje + "');</script>");


        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }
    }
}
