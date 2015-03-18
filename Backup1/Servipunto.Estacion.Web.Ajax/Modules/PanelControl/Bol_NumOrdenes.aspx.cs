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
	/// <summary>
	/// Summary description for Bol_NumOrdenes.
	/// </summary>
	public class Bol_NumOrdenes : System.Web.UI.Page
	{
		#region Declaraciones de la pagina
		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;        
        protected System.Web.UI.WebControls.Panel pnlAlertaResolucion;
        protected System.Web.UI.WebControls.Panel PnlDiferenciaAviso;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        protected System.Web.UI.WebControls.Label lblDiferencia;
		#endregion
		
		#region Page_Load
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
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,154, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    ActivarPanelAviso();
					this.Visualizar();
				}
			}
			
		}
		#endregion

		#region Método Visualizar
		private void Visualizar()
		{
			try
			{
				Libreria.Configuracion.Bol_NumOrdenes objBolNumOrdenes = new Servipunto.Estacion.Libreria.Configuracion.Bol_NumOrdenes();
				Results.DataSource = objBolNumOrdenes;
				Results.DataBind();
				objBolNumOrdenes = null;
			}
			catch(Exception ex)
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
			const string opcion = "Dosificacion de Facturas";

			bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
			bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!consultar)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}

			//Configuración de Acciones
			string htmlAcciones = "";
			if (nuevo)
				this.AgregarAccion(ref htmlAcciones, "Bol_NumOrden.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(1441,Global.Idioma));

            this.AgregarAccion(ref htmlAcciones, "Default.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma));
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
			currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
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

		#region Método MostrarMensaje
		public string MostrarMensaje(object dataBinder)
		{
			switch (Convert.ToInt16(dataBinder))
			{
				case 0:
                    return Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma);
				case 1:
                    return Libreria.Configuracion.PalabrasIdioma.Traduccion(2371, Global.Idioma);
				default:
                    return Libreria.Configuracion.PalabrasIdioma.Traduccion(2372, Global.Idioma);
			}
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

        #region Panel Aviso
        private void ActivarPanelAviso()
        {
            int diferencia = 0;
            int aviso = Libreria.Configuracion.Bol_NumOrdenes.VerificarAlarma(ref diferencia);

            if (diferencia > 0)
            {
                switch (aviso)
                {
                    case 0:
                        pnlAlertaResolucion.Visible = false;
                        PnlDiferenciaAviso.Visible = false;
                        break;

                    case 1:
                        pnlAlertaResolucion.Visible = true;
                        PnlDiferenciaAviso.Visible = true;
                        lblDiferencia.Text =  diferencia.ToString() + " "+Libreria.Configuracion.PalabrasIdioma.Traduccion(1947, Global.Idioma);  
                        break;

                    case 2:
                        pnlAlertaResolucion.Visible = true;
                        PnlDiferenciaAviso.Visible = true;
                        lblDiferencia.Text = diferencia.ToString() + " " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1948, Global.Idioma); 
                        break;
                }
            }

        }
        #endregion
        protected void Results_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Servipunto.Estacion.Libreria.Configuracion.Bol_NumOrden dbr = (Servipunto.Estacion.Libreria.Configuracion.Bol_NumOrden)e.Item.DataItem;
                if (Convert.ToString(DataBinder.Eval(dbr, "Regimen")) == "Comun")
                    ((Label)e.Item.FindControl("Label9")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(2373, Global.Idioma);
                else if (Convert.ToString(DataBinder.Eval(dbr, "Regimen")) == "Simplificado")
                    ((Label)e.Item.FindControl("Label9")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(2374, Global.Idioma);
                else
                    ((Label)e.Item.FindControl("Label9")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma);
                //if (Convert.ToString(DataBinder.Eval(dbr, "NumCuenta")) == "(sin definir)")
                //    ((Label)e.Item.FindControl("Label11")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma);
            }


        }
    }
}
