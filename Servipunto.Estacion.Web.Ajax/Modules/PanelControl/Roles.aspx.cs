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
using Servipunto.Estacion.Web;

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	public class Roles : System.Web.UI.Page
    {
        #region declaracion de objetos
        protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Panel pnlForm;
        //protected System.Web.UI.WebControls.Label Label4;
        //protected System.Web.UI.WebControls.Label Label5;
        //protected System.Web.UI.WebControls.Label Label6;
        //protected System.Web.UI.WebControls.Label Label7;
        //protected System.Web.UI.WebControls.Label Label8;
        //protected System.Web.UI.WebControls.Label Label9;
        //protected System.Web.UI.WebControls.Label Label10;
        //protected System.Web.UI.WebControls.Label Label11;
        //protected System.Web.UI.WebControls.Label Label12;
        //protected System.Web.UI.WebControls.Label Label13;
        //protected System.Web.UI.WebControls.Label Label14;
        //protected System.Web.UI.WebControls.Label Label15;
        //protected System.Web.UI.WebControls.Label Label16;
        //protected System.Web.UI.WebControls.Label Label17;
        //protected System.Web.UI.WebControls.Label Label18;
        //protected System.Web.UI.WebControls.Label Label19;
        //protected System.Web.UI.WebControls.Label Label20;
        //protected System.Web.UI.WebControls.Label Label21;
        //protected System.Web.UI.WebControls.Label Label22;
        #endregion
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
		#region * Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.Page.IsPostBack) 
			{
				if (this.VerificarPermisos())
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,8, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					this.Visualizar();
				}
			}
			else
			{
				this.Eliminar();
			}
            //Traducir();
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
            //this.Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1695, Global.Idioma);
            //Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1695, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion        
		#region Método VerificarPermisos
        /// <summary>
        /// ajusta los permisos para la traduccion
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <returns></returns>
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Roles";
			string HTMLAcciones = "";

			bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
			bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
			bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!consultar)
			{
                this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
				this.lblError.Visible = true;
				this.Results.Visible = false;
				this.Acciones.Visible = false;
				return false;
			}
			
			if (nuevo)
			{
                this.AgregarAccion(ref HTMLAcciones, "Rol.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(1039, Global.Idioma));				
			}
			if (eliminar)
			{
                this.AgregarAccion(ref HTMLAcciones, "javascript:document.forms[0].submit();", Libreria.Configuracion.PalabrasIdioma.Traduccion(1042, Global.Idioma));				
			}
			if (modificar)
				this.HiddenUpdate.Value = "Allow";
			else
				this.HiddenUpdate.Value = "Deny";
            this.AgregarAccion(ref HTMLAcciones, "Default.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
            this.Acciones.InnerHtml = HTMLAcciones + "<br><br>";
			return true;
        }
        #region Ajustar Permisos
        /// <summary>
        /// ajusta los permisos para la traduccion
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <param name="currentHtml"></param>
        /// <param name="hRef"></param>
        /// <param name="title"></param>
        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
        }
        #endregion
        #endregion

        #region Método Visualizar
        private void Visualizar()
		{
			try
			{
				Libreria.Roles objRoles = new Servipunto.Estacion.Libreria.Roles();
				Results.DataSource = objRoles;
				Results.DataBind();
				objRoles = null;
			}
			catch(Exception ex)
			{
                
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

		#region Método Eliminar
		private void Eliminar()
		{
			if (Request.Form["chkID"] != null)
			{
				int i;
				string [] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());

				this.lblError.Visible = true;
				this.lblError.Text = "";
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,13, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				for (i = 0; i <= aSelectedItems.Length-1; i++) 
				{
					try
					{
						Libreria.Roles.Remover(Convert.ToByte(aSelectedItems[i]));
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

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
            Traducir();
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
                

       
        
	}
}
