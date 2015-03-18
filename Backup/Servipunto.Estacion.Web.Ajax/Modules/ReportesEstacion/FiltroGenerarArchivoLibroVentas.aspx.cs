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
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;
using System.Data.SqlClient;
using Servipunto.Estacion.Web;

namespace Servipunto.Estacion.Reportes
{
	public class FiltroGenerarArchivoLibroVentas : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Label lblTipoReporte;
		protected System.Web.UI.WebControls.DropDownList ddlAno;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.LinkButton lbCrearArchivo;
		protected System.Web.UI.WebControls.Label lblConfirmacion;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Label2;        
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel pnlForm;
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
            ViewState["Control"] = "0";
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
        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (Request.Form["__EVENTTARGET"].Length == 0)
                    this.EjecutarSP();
            }
            else
            {
                if (ViewState["Control"].ToString() != "1")
                {
                    this.VerificarPermisos();
                    this.InicializarForma();
                }
            }
        }
        #endregion

		#region Validar
		private bool Validar()
		{
			return true;
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Facturacion";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Generar Archivo Libro Ventas");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), false);
				return false;
			}
			
			return true;
		}
		#endregion

		#region EjecutarSP
		private void EjecutarSP()
		{
			
			this.lblConfirmacion.Visible = false;
			this.lblError.Visible = false;
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,357, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

                //string Directorio = Server.MapPath("../."); 
                string Directorio = "D:/"; 
				string [] arreglo = System.IO.Directory.GetFiles(Directorio);

				string sqlcomando = "exec SP_Call_PlainGenerator '" + 
				this.ddlAno.SelectedValue + "-" +  this.ddlMes.SelectedValue + "-01'" 
				+ ",'" + this.ddlAno.SelectedValue + "-" +  this.ddlMes.SelectedValue + "-01'"
				+ ",'" + Request.Form["txtSeparador"] + "','" + Directorio + "'" + ", 5,0,0";

				SqlCommand Comando = new SqlCommand(sqlcomando,Conexion);
				Comando.CommandType = CommandType.Text;
				Comando.ExecuteNonQuery();
				arreglo = System.IO.Directory.GetFiles(Directorio);
				Conexion.Close();
				
				arreglo = System.IO.Directory.GetFiles(Directorio);

				if(arreglo.Length > 0)
				{
					Response.Clear();
					Response.ContentType = "text/plain";
					Response.AppendHeader( "Content-Disposition", "attachment; filename =" + arreglo[0].Substring(arreglo[0].LastIndexOf("\\") + 1)); 
					Response.WriteFile(arreglo[0]);
					Response.End();
					
				}
				else
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma),false);
				}

			}
			catch(Exception ex)
			{
                this.SetError(ex.Message, false);
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

		#region InicializarForma
		private void InicializarForma()
		{
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(388, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(415, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(243, Global.Idioma);
            lblConfirmacion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2148, Global.Idioma);   
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #region poblar RadioButton  ddlMes
            this.ddlMes.Items.Clear();
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2291, Global.Idioma), "1"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2292, Global.Idioma), "2"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2293, Global.Idioma), "3"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2294, Global.Idioma), "4"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2295, Global.Idioma), "5"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2296, Global.Idioma), "6"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2297, Global.Idioma), "7"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2298, Global.Idioma), "8"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2299, Global.Idioma), "9"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2300, Global.Idioma), "10"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2301, Global.Idioma), "11"));
            this.ddlMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2302, Global.Idioma), "12"));
            this.ddlMes.SelectedValue = "1";
            #endregion
            ViewState["Control"] = "1";
            #endregion            

			int añoInicial = 2006;
			int añoActual = DateTime.Now.Year;

			for (int i = añoInicial ; i <= añoActual ; i++)
				ddlAno.Items.Add(new ListItem(i.ToString(),i.ToString()));
		}
		#endregion

        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            //if (hideForm)
                this.pnlForm.Visible = false;

        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
        }
        #endregion
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarSP();
        }

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
