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

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
	/// <summary>
	/// Descripción breve de Restricciones.
	/// </summary>
	public class Restricciones : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
		protected System.Web.UI.WebControls.Label Display;
		protected string _placa = null;
		protected short _dia;
		protected DateTime _hora_Inicio;


		#endregion
	
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
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,310, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
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
				this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta no tiene privilegios suficientes para ingresar a esta página.", true);
				return false;
			}

			//Configuración de Acciones
			string htmlAcciones = "";
			if (nuevo)
				this.AgregarAccion(ref htmlAcciones, "Restriccion.aspx?Placa=" 
					+ Request.QueryString["Placa"] 
					+ "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"] + "&IdCliente=" + Request.QueryString["IdCliente"], "Crear un nuevo Horario");
			if (eliminar)
				this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", "Eliminar los Horarios Seleccionados");

			//this.AgregarAccion(ref htmlAcciones, "Automotores.aspx", "Volver");
			this.AgregarAccion(ref htmlAcciones, "Automotores.aspx?IdCliente=" + Request.QueryString["IdCliente"] + "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"], "Volver");
			
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
			currentHtml += currentHtml.Length==0?"":"&nbsp;|&nbsp;";
			currentHtml += "<a  href='" + hRef + "'>" + title + "</a>";
		}
		#endregion
		
		#region Visualizar
		private void Visualizar()
		{
			try
			{
				this._placa = DecryptText(Convert.ToString(Request.QueryString["Placa"].Replace(" ","+")));
				Display.Text= "<b>Placa del Vehiculo: " + _placa + "</b>";

				Libreria.Comercial.Restricciones objRestricciones = new Libreria.Comercial.Restricciones(this._placa,null,null);
				Results.DataSource = objRestricciones;
				Results.DataBind();
				objRestricciones = null;
			}				
			catch(Exception ex)
			{
				this.SetError(lblError.Text += " Error interno cargando el formulario de horario de consumo. " + ex.Message,false);

				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno cargando el formulario de listado de horarios de consumo.");
				}
				catch(Exception exx)
				{    
					lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					this.SetError(lblError.Text,false);
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
				string [] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
				string [] Cadena;
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,313, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0; i <= aSelectedItems.Length-1; i++) 
				{
					try
					{
						Cadena = aSelectedItems[i].Split("&".ToCharArray());
						_placa = Cadena[0].ToString().Trim();
						_dia = short.Parse(Cadena[1].ToString());
						_hora_Inicio = DateTime.Parse(Cadena[2].ToString());
						Libreria.Comercial.Restricciones.Eliminar(_placa,_dia,_hora_Inicio);
					}
					catch (Exception ex)
					{
						this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
						#region registro del log de errores
						try
						{
							Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
								2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
								ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno eliminando datos de horario de consumo. ");
						}
						catch(Exception exx)
						{    
							lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
							this.SetError(lblError.Text,false);
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
				this.MyForm.Visible = false;
		}

		private void ClearError()
		{
			this.lblError.Text = "";
			this.lblError.Visible = false;
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
