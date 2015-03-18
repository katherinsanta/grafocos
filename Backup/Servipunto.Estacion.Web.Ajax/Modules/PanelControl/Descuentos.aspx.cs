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
    public partial class Descuentos1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Repeater Results;

        protected void Page_Load(object sender, EventArgs e)
        {

            InicializarForma();
        }
        #region inicializarFormulario
        private void InicializarForma()
        {
            if (this.VerificarPermisos())
            {
                try
                {   //this.lblFormTitle.Text = "<b>Creación, Configuración y Generación de Archivos Planos</b>";
                    //this.lblBack.NavigateUrl = "Default.aspx";
                    Visualizar();
                }
                catch (Exception ex)
                {
                    //this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
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

        #region Verificar Permisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = " Descuentos";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Cosultar");

            if (!permiso)
            {
                lblError.Visible = true;
                lblError.Text= Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
                //this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                this.pnlForm.Visible = false;
                //this.MyForm.Visible=false;
                return false;
            }
            return true;
        }
        #endregion

        #region visualizar
        private void Visualizar() 
        {
            Libreria.Configuracion.ConfiguracionDescuentos objDescuentos = new Libreria.Configuracion.ConfiguracionDescuentos();
            gvwDescuentos.DataSource = objDescuentos;
            gvwDescuentos.DataBind();
            objDescuentos = null;
        }
        #endregion

        #region Método Eliminar
        private void Eliminar()
        {
            if (Request.Form["Check"] != null)
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 21, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                int i;
                string[] aSelectedItems = Request.Form["Check"].Split(",".ToCharArray());

                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i <= aSelectedItems.Length - 1; i++)
                {
                
                    try
                    {
                        if (aSelectedItems[i].ToUpper() == "SYSTEM")
                        {
                            throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1771, Global.Idioma));
                        }
                        Libreria.Configuracion.ConfiguracionDescuentos.Eliminar(Convert.ToInt16(aSelectedItems[i]));
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        protected void gvwDescuentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                //GridViewRow row = gvwDescuentos.Rows[index];


                Response.Redirect("Descuento.aspx?Id=" + gvwDescuentos.DataKeys[index].Value.ToString()   );

            }
                

                
        }

    }
}
