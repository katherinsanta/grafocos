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
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
    public class ClienteSUIC : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblTitle;
        protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.WebControls.DropDownList ddlPrueba;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.TextBox txtPlaca;
		#endregion
	
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
            lblError.Visible = false;
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
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 314, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    this.Visualizar("NoPlaca");
                    if (Request.QueryString["result"] != null && Request.QueryString["result"] == "-1")
                    {
                        lblError.Visible = true;
                        lblError.Text = "Operación No Exitosa!!! Codigo de error: " + Request.QueryString["result"];
                    }
                    else if (Request.QueryString["result"] != null)
                    {
                        lblError.Text = "Operación Exitosa!!!";
                        lblError.Visible = true;
                    }
                }
            }
            else
            {
                Results.DataSource = null;
                Results.DataBind();
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

			//Configuración de Acciones
            string htmlAcciones = "";
            //if (nuevo)
            //    this.AgregarAccion(ref htmlAcciones, "ListaPrecioDiferencial.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, 1));
            //if (eliminar)
            //    this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(775, 1));

            this.AgregarAccion(ref htmlAcciones, "Default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000,Global.Idioma));
            this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

            ////Configuración del permiso de modificación
            //if (modificar)
            //    this.HiddenUpdate.Value = "Allow";
            //else
            //    this.HiddenUpdate.Value = "Deny";

			return true;
		}

		private void AgregarAccion(ref string currentHtml, string hRef, string title)
		{
			currentHtml += currentHtml.Length==0?"":"&nbsp;|&nbsp;";
			currentHtml += "<a  href='" + hRef + "'>" + title + "</a>";
		}
		#endregion

		#region Visualizar
		private void Visualizar(string placa)
		{
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("TraerClientesSUIC");
            if (!placa.Equals(""))
            {
                sql.ParametersNumber = 1;
                sql.AddParameter("@Placa", SqlDbType.Char, placa);
                Results.DataSource = SqlHelper.ExecuteDataset(Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            }
            else
                Results.DataSource = SqlHelper.ExecuteDataset(Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
            if (((DataSet)Results.DataSource).Tables[0].Rows.Count == 0 && !placa.Equals("NoPlaca"))
            {
                lblError.Visible = true;
                lblError.Text = "El Automotor Con La Placa '" + placa + "' No Se Encuentra Registrado En La Base SUIC.";
            }
            #endregion

            #region Execute Sql
			try
			{
				Results.DataBind();
			}
			catch(Exception ex)
			{
				SetError(ex.Message /*+ "<br><br>" + ex.StackTrace*/, false);
            }
            #endregion
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

        protected void btnBuscarPlaca_Click(object sender, EventArgs e)
        {
            this.Visualizar(txtPlaca.Text);
        }
	}
}
