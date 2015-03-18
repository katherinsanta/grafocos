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

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class ProcesosEstandar : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Introducir aquí el código de usuario para inicializar la página
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 197, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2135, Global.Idioma);
                Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(879, Global.Idioma);
                Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(879, Global.Idioma);
                Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(884, Global.Idioma);
                Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2140, Global.Idioma) + " " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(884, Global.Idioma);
                Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(880, Global.Idioma);
                Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2140, Global.Idioma) + " " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(880, Global.Idioma); ;
                Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(885, Global.Idioma);
                Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2141, Global.Idioma);
                Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(881, Global.Idioma);
                Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2142, Global.Idioma);
                Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(886, Global.Idioma);
                Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2143, Global.Idioma);
                Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(882, Global.Idioma);
                Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2144, Global.Idioma);
                Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(887, Global.Idioma);
                Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2145, Global.Idioma);
                Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(883, Global.Idioma);
                Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2146, Global.Idioma);
                Label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(881, Global.Idioma);
                Label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2147, Global.Idioma);
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
            catch (Exception) { }

        }
    }
}
