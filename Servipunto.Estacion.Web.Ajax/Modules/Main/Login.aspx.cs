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
using System.Web.Security;
using System.Diagnostics;
using Servipunto.Estacion.Web.Ajax.ControlesdelUsuario;

namespace Servipunto.Estacion.Web.Modules.Main
{
	public class Login : System.Web.UI.Page
	{
		#region Local Variables and Controls Declarations
		protected System.Web.UI.HtmlControls.HtmlForm LoginForm;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblContrasena;
		protected System.Web.UI.WebControls.TextBox txtUserID;
		protected System.Web.UI.WebControls.TextBox txtPassword;
        protected System.Web.UI.WebControls.Label lblUser;
        protected System.Web.UI.WebControls.Label lblBienvenida;
        protected System.Web.UI.WebControls.Label lblInactividad;

		protected System.Web.UI.HtmlControls.HtmlGenericControl InscriptionSection;
		#endregion
	
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
            //navigationPanel();
           
			if (this.IsPostBack)
				this.LogOn();
			else
			{
				this.InitializeForm();
                #region Solo En desarrollo
                txtUserID.Text = "Servipunto";
                //txtPassword.Text = "1688";
                #endregion
			}
		}
		#endregion

        #region Page Pre Load Event
        private void Page_PreLoad(object sender, System.EventArgs e)
        {
            this.lblContrasena.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1419, Global.Idioma);
            this.AcceptButton.Value = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(781, Global.Idioma);
            this.lblBienvenida.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1697, Global.Idioma);
            this.lblUser.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1698, Global.Idioma);
            

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
            this.PreLoad += new System.EventHandler(this.Page_PreLoad);
            this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region InicializeForm
		private void InitializeForm()
		{
            try
            {
                if (Request.QueryString["LogOff"] != null)
                    this.LogOff();
                if (Request.QueryString["SesionClose"] != null)
                {
                    if (Request.QueryString["SesionClose"].ToString() == "1")
                    {
                        Label lblUsuario = (Label)Master.FindControl("lblUsuario");
                        lblUsuario.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2368, Global.Idioma) + " !!";
                        lblInactividad.Visible = true;
                        lblInactividad.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2368, Global.Idioma) + " !!";
                        Session.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");                
            }
			
		}
		#endregion

		#region MakeValidations
		private bool MakeValidations()
		{
			this.lblError.Text = "";
			if (this.txtUserID.Text.Length == 0)
			{
                this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2092, Global.Idioma);
				return false;
			}
			return true;
		}
		#endregion

		#region LogOn
		private void LogOn()
        {
            
            bool seguridad = true;
			Servipunto.Libreria.Registry registro;
			DateTime fecha;

			if (this.MakeValidations())
			{
				Libreria.Usuarios objUsuarios = new Libreria.Usuarios();
				Libreria.Usuario objUsuario;
				try
				{					
					Libreria.Aplicacion.Log.Path = @"C:\Temp";			
					SecurityKey.SecurityKey objSecurityKey = new SecurityKey.SecurityKey();
					
					//obtengo la ruta física del directorio virtual.
					//string ruta = Server.MapPath(HttpContext.Current.Request.FilePath);
					//obtengo la fecha de creación del directorio virtual.
					//DateTime fechacreaciondirectoriovirtual = System.IO.Directory.GetCreationTime(ruta);

                    //Si la fecha actual del sistema es superior a la fecha de creación del directorio virtual
					//más 15 días entonces pide la llave de seguridad.

					//if(DateTime.Now > fechacreaciondirectoriovirtual.AddDays(14))     
					//	seguridad = objSecurityKey.IniciarConexion();
					
					//Comentariar la siguiente linea para eliminar el hardkey validation 

					
//					
					#region llave de seguridad
                    //try
                    //{
						
                    //    seguridad = objSecurityKey.IniciarConexion();
                    //    try
                    //    {
                    //        string cadena = objSecurityKey.fechaVencimiento;
                    //        DateTime fechaVencimiento = Convert.ToDateTime(cadena);
                    //        if (fechaVencimiento.Year > Global.Idioma)
                    //        {
                    //            //if (fechaVencimiento <= DateTime.Today)
                    //            //    seguridad = false;
                    //            //else
                    //                seguridad = true;
                    //        }
                    //        else
                    //            seguridad = true;
                    //    }
                    //    catch
                    //    {

                    //    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    this.lblError.Visible = true;
                    //    this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2093, Global.Idioma) +ex.Message;
                    //    return;
                    //}		
					#endregion
								
					#region demo
					try
					{
						if(!seguridad)
						{
							registro = new Servipunto.Libreria.Registry(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\WinSer\Security\Security");							
							fecha = DateTime.Parse(Servipunto.Libreria.Cryptography.DecryptQueryString(registro.Read("Date"),"ServipuntoEstacion"));
							if(fecha.AddDays(15) < DateTime.Now)//if(fecha.AddDays(Double.Parse(registro.Read("Runs"))) < DateTime.Now)
								throw new Exception("La versión demo ya se encuentra caducada.");
							else
								seguridad = true;
						}
					}
					catch(Exception ex)
					{
						this.lblError.Visible = true;
						this.lblError.Text = "La Aplicación no tiene la llave de seguridad asociada.  Comuníquese con Zencillo de Software Ltda, teléfono 6146666 Bogotá - Colombia - e-mail:  webmaster@servipunto.com. " + ex.Message;
						return;
					}
					#endregion
					
					if (seguridad == true)
					{
						// depurar error
						//StackTrace st = new StackTrace(true);

						try
						{
							objUsuario = Libreria.Aplicacion.Autenticacion(this.txtUserID.Text.Trim(), this.txtPassword.Text);

							if (objUsuario == null)
								throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2094, Global.Idioma));
							else
							{
								Session.Clear();
								Session.Add("Usuario", objUsuario);
								Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,6, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
								FormsAuthentication.RedirectFromLoginPage(objUsuario.IdUsuario, false);
							}
						}
						catch(Exception ex)
						{


							/*string errores = "";
							//  errores
							for(int i =0; i< st.FrameCount; i++ )
							{
								// Note that high up the call stack, there is only
								// one stack frame.
								StackFrame sf = st.GetFrame(i);								
								errores += "High up the call stack, Method: " + sf.GetMethod() + "\r\n" ;
								errores += "High up the call stack, Line Number: " + sf.GetFileLineNumber();
							}

							throw new Exception(ex.StackTrace + "-->" + errores);*/

							this.lblError.Visible = true;
                            this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2095, Global.Idioma) +ex.Message;

							
						}
					}
					else
					{
						this.lblError.Visible = true;
                        this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2096, Global.Idioma);
					}
				}
				catch (Exception ex)
				{
					this.lblError.Visible = true;
					this.lblError.Text = ex.Message;

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
					return;
				}
				finally 
				{
					objUsuarios = null;
					objUsuario = null;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
		}
		#endregion
        //protected void navigationPanel()
        //{
        //    NavigationPanel panel = new NavigationPanel();
        //    panel.Grupo = "Reportes";
        //    panel.GenerarPanel();
        //}



		#region LogOff
		private void LogOff()
		{
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,7, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
			}
			catch{}

			FormsAuthentication.SignOut();
			Session.Add("Usuario", null);
			//Response.Redirect(Request.UrlReferrer.ToString());
			this.lblError.Text = "<br><font color=blue><b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2097, Global.Idioma)+"</b></font>";
		}
		#endregion

	}
}