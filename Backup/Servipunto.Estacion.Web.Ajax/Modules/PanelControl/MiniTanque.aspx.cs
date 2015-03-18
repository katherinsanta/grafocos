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
	public class MiniTanque : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.TextBox txtId;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtCapacidad;
		protected System.Web.UI.WebControls.DropDownList ddlArticulo;
		protected Libreria.Configuracion.Tanques.Tanque _objTanque = null;

        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
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
			if (Request.QueryString["IdTanque"] == null)
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

            if (!this.IsPostBack)
            {
                this.InicializarForma();
                Traduccir();
            }
            else
                if (Request.Form["AcceptButton"] != null)
                    this.Guardar();			
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

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Tanques";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
				this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.", true);
				return false;
			}			
			return true;
		}
		#endregion

		#region ObtenerObjetoTanque
		private bool ObtenerObjetoTanque()
		{
			try
			{

				this._objTanque = Libreria.Configuracion.Tanques.Tanques.ObtenerItem(int.Parse(Request.QueryString["IdTanque"]));
				if (this._objTanque == null)
				{
					this.SetError("Elemento No Encontrado [" + Request.QueryString["IdIsla"] + "]", true);
					return false;
				}
				else
					return true;
			}
			catch (FormatException)
			{
				this.SetError("Ingreso Invalido a la página! [" + Request.QueryString["IdIsla"] + "]", true);
				return false;
			}
		}
		#endregion

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				this.CargarArticulos();
				if (this._mode == WebApplication.FormMode.New)
				{
					#region Modo de Inserción
						this.lblFormTitle.Text = "<b>Creación de un Nuevo Tanque</b>";
						this.AcceptButton.Value = "Crear";
					#endregion
				}
				else
				{
					#region Modo de Edición
					if (this.ObtenerObjetoTanque())
					{
						//Visualización de Datos						
						this.txtId.Text = this._objTanque.CodigoTanque.ToString();
						this.txtCapacidad.Text = this._objTanque.CapacidadTanque.ToString();
						this.txtId.Enabled = false;
						this.lblFormTitle.Text = "Editar Tanque: <b>" + this._objTanque.CodigoTanque.ToString() + "</b>";
						this.AcceptButton.Value = "Guardar";
					}
					else
						this.SetError("Navegación invalida, la isla no ha sido encontrada!", true);
					#endregion
				}				
			}
		}
		#endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
							this._objTanque = new Servipunto.Estacion.Libreria.Configuracion.Tanques.Tanque();
							this._objTanque.CapacidadTanque = Decimal.Parse(this.txtCapacidad.Text);	
							this._objTanque.CodigoArticulo = int.Parse(this.ddlArticulo.SelectedValue);
							Libreria.Configuracion.Tanques.Tanques.Adicionar(this._objTanque);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoTanque())
						{
							this._objTanque.CodigoTanque = int.Parse(this.txtId.Text);
							this._objTanque.CapacidadTanque = Decimal.Parse(this.txtCapacidad.Text);
							this._objTanque.CodigoArticulo = int.Parse(this.ddlArticulo.SelectedValue);
							this._objTanque.Modificar();
						}
						#endregion
					}
					Session["refresh"] = 1;
				}
				catch (Exception ex)
				{
					this.lblError.Visible = true;
					this.lblError.Text = ex.Message;
					return;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
		}
		#endregion

		#region CargarArticulos
		private void CargarArticulos()
		{
			Libreria.Configuracion.Articulos objArticulos = new Libreria.Configuracion.Articulos(Libreria.TipoArticulo.Combustible);

			this.ddlArticulo.DataSource = objArticulos;
			this.ddlArticulo.DataTextField = "Descripcion";
			this.ddlArticulo.DataValueField = "IdArticulo";
			this.ddlArticulo.DataBind();

			if (this.ddlArticulo.Items.Count == 0)
			{
				this.ddlArticulo.Items.Add("(no hay artículos configurados)");
				this.AcceptButton.Disabled = true;
			}
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			this.ClearError();
			if (this.txtCapacidad.Text.Trim().Length != 0)
			{
				try
				{
					Decimal.Parse(txtCapacidad.Text);
				}
				catch
				{
					this.SetError("La capacidad del tanque debe ser numérico!", false);
					return false;
				}
			}
			else
			{
				this.SetError("El número del tanque no puede ser una cadena vacia!", false);
				return false;
			}
			try
			{
				int.Parse(ddlArticulo.SelectedValue);
			}
			catch
			{
				this.SetError("El articulo seleccionado no es valido.", false);
				return false;
			}
			
			
			return true;
		}
		#endregion

        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1384, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
        }

	}
}
