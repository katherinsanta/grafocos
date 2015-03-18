using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class ImportarTablasGNV : System.Web.UI.Page
    {
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
                this.EjecutarSP();
            }
            else
            {                
                this.VerificarPermisos();
                this.InicializarForma();
            }
        }
        #endregion

        #region Validar
        private bool Validar()
        {
            if (System.IO.Directory.GetFiles(Server.MapPath("../.")).Length != 4)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2126, Global.Idioma),false);
                return false;

            }

            return true;
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Facturacion";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Exportar Ventas Archivo Plano");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma),true);
                this.pnlForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion

        #region EjecutarSP
        private void EjecutarSP()
        {
            if (this.Validar())
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 187, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblConfirmacion.Visible = false;
                Servipunto.Estacion.Libreria.CargarPlanosGNV.PlanosGNV planos;
                try
                {
                    if (Request.Form["txtSeparador"] == "")
                        planos = new Servipunto.Estacion.Libreria.CargarPlanosGNV.PlanosGNV(Server.MapPath("../.") + "\\", ";");
                    else
                        planos = new Servipunto.Estacion.Libreria.CargarPlanosGNV.PlanosGNV(Server.MapPath("../.") + "\\", Request.Form["txtSeparador"]);

                    this.lblConfirmacion.ForeColor = Color.Navy;
                    this.lblConfirmacion.Visible = true;
                    this.lblConfirmacion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2127, Global.Idioma);
                }
                catch (Exception ex)
                {
                    SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2128, Global.Idioma) + ex.Message,false);

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
        }
        #endregion

        #region InicializarForma
        private void InicializarForma()
        {
            this.lblReporte.Text = "<b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2129, Global.Idioma)+"</b>";
            this.Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(874, Global.Idioma)  ;
            this.Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2130, Global.Idioma);
            this.Label3.Text =  Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1941, Global.Idioma);
            this.Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
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
    }
}
