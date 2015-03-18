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

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
    public partial class Restricciones_ : System.Web.UI.Page
    {
        protected string _placa = null;
        protected short _dia;        
        protected DateTime _hora_Inicio;

        #region Page Load Event
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
            if (!this.Page.IsPostBack)
            {
                if (this.VerificarPermisos())
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 310, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    this.Visualizar();
                }

            }
            else
            {
                this.Eliminar();
            }
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Comerciales";
            const string opcion = "Automotores";
            bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
            bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
            bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
            bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

            //Revisión de permiso de consulta
            if (!consultar)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                return false;
            }

            //Configuración de Acciones
            string htmlAcciones = "";
            if (nuevo)
                this.AgregarAccion(ref htmlAcciones, "Restriccion.aspx?Placa="
                    + Request.QueryString["Placa"]
                    + "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"] + "&IdCliente=" + Request.QueryString["IdCliente"], Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
            if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(775, Global.Idioma));

            //this.AgregarAccion(ref htmlAcciones, "Automotores.aspx", "Volver");
            this.AgregarAccion(ref htmlAcciones, "Automotores.aspx?IdCliente=" + Request.QueryString["IdCliente"] + "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"], Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));

            this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

            //Configuración del permiso de modificación
            if (modificar)
                this.HiddenUpdate.Value = "Allow";
            else
                this.HiddenUpdate.Value = "Deny";

            return true;
        }

        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
        }
        #endregion

        #region Visualizar
        private void Visualizar()
        {
            try
            {
                this._placa = DecryptText(Convert.ToString(Request.QueryString["Placa"].Replace(" ", "+")));
                Display.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2027, Global.Idioma)+": " + _placa + "</b>";

                Libreria.Comercial.Restricciones objRestricciones = new Libreria.Comercial.Restricciones(this._placa, null, null);
                Results.DataSource = objRestricciones;
                Results.DataBind();
                objRestricciones = null;
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

        #region Eliminar
        private void Eliminar()
        {
            if (Request.Form["chkID"] != null)
            {
                int i;
                string[] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
                string[] Cadena;
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 313, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i <= aSelectedItems.Length - 1; i++)
                {
                    try
                    {
                        Cadena = aSelectedItems[i].Split("&".ToCharArray());
                        _placa = Cadena[0].ToString().Trim();
                        _dia = short.Parse(Cadena[1].ToString());
                        _hora_Inicio = DateTime.Parse(Cadena[2].ToString());
                        Libreria.Comercial.Restricciones.Eliminar(_placa, _dia, _hora_Inicio);
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

        #region Método DecryptText
        /// <summary>
        /// Desencripta el query string 
        /// </summary>
        /// <param name="strText">texto a desencriptar</param>
        /// <returns>texto desencriptado</returns>
        private string DecryptText(string strText)
        {
            return Servipunto.Libreria.Cryptography.DecryptQueryString(strText, "!#$a54?3");
        }
        #endregion

        #region Método EncryptText
        /// <summary>
        /// encripta el dato del querystring
        /// </summary>
        /// <param name="strText">texto a encriptar</param>
        /// <returns>texto encriptado</returns>
        public string EncryptText(string strText)
        {
            return Servipunto.Libreria.Cryptography.EncryptQueryString(strText, "!#$a54?3");
        }
        #endregion
        protected void Results_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Servipunto.Estacion.Libreria.Comercial.Restriccion dbr = (Servipunto.Estacion.Libreria.Comercial.Restriccion)e.Item.DataItem;
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Lunes - Viernes")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2047, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Lunes")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2048, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Martes")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2049, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Miercoles")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2050, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Jueves")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2051, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Viernes")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2052, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Sabado")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2053, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Todos los días")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2054, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreDia")) == "Domingo")
                    ((Label)e.Item.FindControl("Label5")).Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2064, Global.Idioma);
                
            }


        }
    }
}
