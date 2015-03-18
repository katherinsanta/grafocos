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

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	public class DetallePrecio : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
		protected string _id = null;

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
			this.Visualizar();
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			string htmlAcciones = "";
			this.AgregarAccion(ref htmlAcciones, "PreciosProgramados.aspx", "Volver");
			this.Acciones.InnerHtml = htmlAcciones + "<br><br>";
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
				VerificarPermisos();
				this._id = DecryptText(Convert.ToString(Request.QueryString["Fecha"].Replace(" ","+") ));
				string fecha = this._id.Split(" ".ToCharArray())[0];
				string [] split = fecha.Split("/".ToCharArray());
				Results.DataSource = 
				new Servipunto.Estacion.Libreria.Configuracion.PreciosProgramados.DetallePreciosProgramados(new DateTime(int.Parse(split[2]),int.Parse(split[1]),int.Parse(split[0])), int.Parse(Request.QueryString["IdArticulo"]));
				Results.DataBind();
			}
			catch(Exception ex)
			{
				SetError(ex.Message, false);
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
