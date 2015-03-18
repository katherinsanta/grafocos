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
    public class Upd_SUIC : System.Web.UI.Page
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
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
            Visualizar("NoPlaca");
            Update();
		}

        private void Update()
        {
            int result=0;
            try
            {
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                sql.Append("UpdateClientesSUIC");
                sql.ParametersNumber = 2;
                sql.AddParameter("@Placa", SqlDbType.Char, Request.QueryString["pl"]);
                sql.AddParameter("@Cod_Cli", SqlDbType.Char, Request.QueryString["cli"]);
                result = SqlHelper.ExecuteNonQuery(Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            }
            catch (Exception ex)
            {
                result=-1;
            }
            finally
            {
                Response.Redirect("ClienteSUIC.aspx?result=" + result);
            }
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
            #endregion

            #region Execute Sql
            try
            {
                Results.DataBind();
            }
            catch (Exception ex)
            {
            }
            #endregion
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
	}
}
