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
 
namespace Servipunto.Estacion.Web.Ajax.Modules.PanelControl
{
    public partial class ConfiguracionSorteos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            // Put user code to initialize the page here
            if (!this.IsPostBack)
            {
                if (this.VerificarPermisos())
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 146, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    this.Visualizar();
                }
            }
            else
            {
                this.Eliminar();
            }
        }

        #region Eliminar
        private void Eliminar()
        {
            if (Request.Form["chkID"] != null)
            {
                int i;
                string[] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 65, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i <= aSelectedItems.Length - 1; i++)
                {
                    try
                    {
                        Libreria.Configuracion.ConfiguracionSorteos.Eliminar(Convert.ToInt16(aSelectedItems[i]));
                    }
                    catch (Exception ex)
                    {
                        this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
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
                this.Visualizar();
            }
        }
        #endregion


        #region Método Visualizar
        private void Visualizar()
        {
            try
            {
                Libreria.Configuracion.ConfiguracionSorteos objAlarmas = new Servipunto.Estacion.Libreria.Configuracion.ConfiguracionSorteos();
                Results.DataSource = objAlarmas;
                Results.DataBind();
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
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

        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = "Conf. Venta Gratis";

            string htmlAcciones = "";
            bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
            bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
            bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
            bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

            if (!consultar)
            {
                //this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
                this.lblError.Visible = true;
                this.Results.Visible = false;
                this.Acciones.Visible = false;
                return false;
            }

            if (nuevo)
            {
                this.AgregarAccion(ref htmlAcciones, "ConfiguracionSorteo.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1490, Global.Idioma));
            }
            if (eliminar)
            {
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1288, Global.Idioma));				
            }


            if (modificar)
                this.HiddenUpdate.Value = "Allow";
            else
                this.HiddenUpdate.Value = "Deny";

            this.AgregarAccion(ref htmlAcciones, "Default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));

            this.Acciones.InnerHtml = htmlAcciones;
            return true;
        }
        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a  href='" + hRef + "'>" + title + "</a>";
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

        protected void Results_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Servipunto.Estacion.Libreria.Configuracion.ConfiguracionSorteo dbr = (Servipunto.Estacion.Libreria.Configuracion.ConfiguracionSorteo)e.Item.DataItem;
                if (Convert.ToString(DataBinder.Eval(dbr, "Estado")) == "True")
                    ((Label)e.Item.FindControl("Label6")).Text = "Activo";
                else
                    ((Label)e.Item.FindControl("Label6")).Text = "Inactivo";
                
                if (Convert.ToString(DataBinder.Eval(dbr, "MultiplesBoletas")) == "True")
                    ((Label)e.Item.FindControl("Label12")).Text = "Si";
                else
                    ((Label)e.Item.FindControl("Label12")).Text = "No";

            }


        }
    }
}
