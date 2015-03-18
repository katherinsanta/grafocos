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
	public class PreciosDiferenciales : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DropDownList ddlFiltro;
		protected System.Web.UI.WebControls.DropDownList ddlPrueba;
		protected System.Web.UI.WebControls.LinkButton lbAgregarLista;
		protected System.Web.UI.WebControls.LinkButton lbEliminar;
		protected System.Web.UI.WebControls.HyperLink hlVolver;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        protected System.Web.UI.WebControls.Panel pnlForm;
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
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,314, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
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
			const string opcion = "PreciosDiferenciales";
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

			if(!eliminar) lbEliminar.Visible = false;
			if(!nuevo) lbAgregarLista.Visible = false;
            lbEliminar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(775, Global.Idioma);
            lbAgregarLista.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma);
            hlVolver.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
			//Configuración de Acciones
			/*string htmlAcciones = "";
			if (nuevo)
				this.AgregarAccion(ref htmlAcciones, "PrecioDiferencial.aspx?IdList=" + ddlFiltro.SelectedValue, "Crear una Nuevo Precio");
			if (eliminar)
				this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", "Eliminar los Precios Seleccionados");

			this.AgregarAccion(ref htmlAcciones, "ListaPreciosDiferenciales.aspx", "Volver");
			this.Acciones.InnerHtml = htmlAcciones + "<br><br>";
*/
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
			currentHtml += "<a style='color: blue' href='" + hRef + "'>" + title + "</a>";
		}
		#endregion

		#region Visualizar
		private void Visualizar()
		{
			CargarFiltro();
		}
		#endregion

		#region CargarListaPrecios
		private void CargarListaPrecios()
		{
			try
			{
				if(ddlFiltro.SelectedValue != "-1")
				{
					Results.DataSource = new Servipunto.Estacion.Libreria.Comercial.PreciosDiferenciales(int.Parse(ddlFiltro.SelectedValue));
				}
				Results.DataBind();
			}
			catch(Exception ex)
			{
				SetError(ex.Message, false);
			}
		}
		#endregion

		#region CargarFiltro
		private void CargarFiltro()
		{
			try
			{
				ddlFiltro.DataSource = new Servipunto.Estacion.Libreria.Comercial.PreciosDiferenciales();
				ddlFiltro.DataTextField = ddlFiltro.DataValueField ="IdPrecioDiferencial";
				ddlFiltro.DataBind();
				ddlFiltro.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma),"-1"));
				try
				{
					ddlFiltro.SelectedValue = Request.QueryString["IdLista"];
				}
				catch
				{
					ddlFiltro.SelectedValue = "-1";
				}
				CargarListaPrecios();
			}
			catch(Exception ex)
			{
				SetError(ex.Message /*+ "<br><br>" + ex.StackTrace*/, false);
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
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,317, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0 ; i < aSelectedItems.Length ; i++) 
				{
					try
					{
						if(int.Parse(aSelectedItems[i].Split("|".ToCharArray())[0]) != 0)
						{
							Libreria.Comercial.PreciosDiferenciales.Eliminar(
								int.Parse(aSelectedItems[i].Split("|".ToCharArray())[0]),
								int.Parse(aSelectedItems[i].Split("|".ToCharArray())[1]));
							Response.Redirect("PreciosDiferenciales.aspx?IdLista=" + ddlFiltro.SelectedValue);
						}
						else
						{
                            SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2060, Global.Idioma), false);
						}						
					}
					catch (Exception ex)
					{
						this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
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
			this.ddlFiltro.SelectedIndexChanged += new EventHandler(this.ddlFiltroSelectedIndexChanged);
			this.lbAgregarLista.Click += new System.EventHandler(this.lbAgregarLista_Click);
			this.lbEliminar.Click += new System.EventHandler(this.lbEliminar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Seleccionar Lista Diferente en el Filtro
		private void ddlFiltroSelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarListaPrecios();
		}
		#endregion

		#region Boton Eliminar
		private void lbEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar();
		}

		#endregion

		#region Agregar Lista
		private void lbAgregarLista_Click(object sender, System.EventArgs e)
		{
			if(ddlFiltro.SelectedValue != "-1" && ddlFiltro.SelectedValue != "0")
				Response.Redirect("PrecioDiferencial.aspx?IdLista=" + ddlFiltro.SelectedValue);
			else
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2061, Global.Idioma), false);
		}
		#endregion
        protected void Results_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Servipunto.Estacion.Libreria.Comercial.PrecioDiferencial dbr = (Servipunto.Estacion.Libreria.Comercial.PrecioDiferencial)e.Item.DataItem;
                if (Convert.ToString(DataBinder.Eval(dbr, "NombreArticulo")) == "(Sin Definir)")
                    ((Label)e.Item.FindControl("Label4")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma);
            }


        }
	}
}
