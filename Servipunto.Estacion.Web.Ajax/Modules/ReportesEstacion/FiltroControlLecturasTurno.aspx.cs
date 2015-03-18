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

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
	/// <summary>
	/// Descripción breve de FiltroControlLecturasTurno.
	/// </summary>
	public class FiltroControlLecturasTurno : System.Web.UI.Page
	{		
		#region Declaración de Controles
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.CheckBox cbTodos;
		protected System.Web.UI.WebControls.DropDownList ddlCara;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.RadioButtonList rbFormato;
		protected System.Web.UI.WebControls.DropDownList cboIsla;
		protected System.Web.UI.WebControls.DropDownList cboTurno;
		protected System.Web.UI.WebControls.DropDownList cboManguera;
		protected System.Web.UI.WebControls.TextBox txtSeparador;
		protected System.Web.UI.WebControls.RadioButtonList rbnFormasPago;
		protected System.Web.UI.WebControls.RadioButtonList rbnGrafica;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlArticulo;
		protected System.Web.UI.WebControls.RadioButtonList rbnConsolidadoManguera;
		protected System.Web.UI.WebControls.DropDownList ddlUnidadMedida;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;

        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;        
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.Label Label12;
        protected System.Web.UI.WebControls.Label Label13;
        protected System.Web.UI.WebControls.Label Label14;
        protected System.Web.UI.WebControls.Label Label15;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender1;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender2;
        protected System.Web.UI.WebControls.TextBox txtFechaInicial;
        protected System.Web.UI.WebControls.TextBox txtFechaFin;
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
                CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (Request.Form["__EVENTTARGET"].Length == 0)
                    this.EjecutarReporte();
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
            if (Convert.ToDateTime(this.txtFechaInicial.Text) > Convert.ToDateTime(this.txtFechaFin.Text))
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1962, Global.Idioma), false);
                return false;
            }

            return true;
        }
        #endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Generales";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Cara");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}
			
			return true;
		}
		#endregion

		#region EjecutarReporte
		private void EjecutarReporte()
		{
			if (this.Validar())
			{
				try
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,338, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					if(rbFormato.SelectedValue == "pdf" ||  rbFormato.SelectedValue == "xls")
					{						
						DataDynamics.ActiveReports.ActiveReport report = null;
                        report = new Servipunto.Estacion.Web.Modules.Rpt.ControlLecturasTurno(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), 
									int.Parse(cboIsla.SelectedValue), 
									int.Parse(cboTurno.SelectedValue),
									int.Parse(cboManguera.SelectedValue),
									rbnFormasPago.SelectedValue=="1"?true:false,
									rbnGrafica.SelectedValue=="1"?true:false,
									Int16.Parse(ddlArticulo.SelectedValue),
									ddlArticulo.SelectedItem.ToString(),
									rbnConsolidadoManguera.SelectedValue=="1"?true:false,
									ddlUnidadMedida.SelectedValue.Trim()
							);					
						Session.Add("LastReport", report);
						Session["Formato"] = rbFormato.SelectedValue;
						Response.Redirect("../Visor/PDF.aspx",false);
					}
					else
						this.GenararPlano();

				}
				catch (Exception ex)
				{
					this.SetError(ex.Message,false);
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
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(19, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2323, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(53, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(54, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2324, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(48, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(875, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);            
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            #region poblar RadioButton  TipoReporte            
            this.rbnConsolidadoManguera.Items.Clear();
            this.rbnConsolidadoManguera.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.rbnConsolidadoManguera.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.rbnConsolidadoManguera.SelectedValue = "0";
            this.rbnFormasPago.Items.Clear();
            this.rbnFormasPago.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.rbnFormasPago.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.rbnFormasPago.SelectedValue = "0";
            this.rbnGrafica.Items.Clear();
            this.rbnGrafica.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.rbnGrafica.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.rbnGrafica.SelectedValue = "0";
            #endregion
            ViewState["Control"] = "1";
            #endregion            
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
			CargarCombos();
			CargarArticulos();
		}
		#endregion

		#region Generar Plano
		private void GenararPlano()
		{
			#region Declaraciones
			string separador = txtSeparador.Text;
			//string _fecha = FechaInicio.SelectedDate.ToString();
			string fecha = Convert.ToDateTime(txtFechaInicial.Text).ToString("yyyy/MM/dd");
			int turno = int.Parse(cboTurno.SelectedValue);
			int num_isl = int.Parse(cboIsla.SelectedValue); 
			int cod_mag = int.Parse(cboManguera.SelectedValue); 
			string año = Convert.ToDateTime(txtFechaInicial.Text).Year.ToString();
			string Resultado;
			string [] archivo;
			#endregion
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,338, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				if(año == "1")
				{
                    SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2161, Global.Idioma),false);
					return;
				}

                Resultado = Servipunto.Estacion.Libreria.Turnos.TurnosLaborales.PlanoLecturasControlTurno(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), 
								num_isl,
								turno, 
								cod_mag,
								separador,
								Int16.Parse(ddlArticulo.SelectedValue),
								rbnConsolidadoManguera.SelectedValue=="1"?true:false								
							);			
				archivo = Resultado.Split(",".ToCharArray());

				if(archivo[0].ToString() != "OK")
				{
					this.SetError(Resultado,false);
					return;
				}
				Response.Clear();
				Response.ContentType = "text/plain";
				Response.AppendHeader( "Content-Disposition", "attachment; filename =" + archivo[1].Substring(archivo[1].LastIndexOf("\\")+1)); 
				Response.WriteFile(archivo[1]);
				Response.End();
						

			}
			catch(Exception ex)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma)+" :" + ex.Message,false);
			}

		}
		#endregion

		#region Cargar Caras
		private void CargarCombos()
		{
			for (int i = 1; i <= 20; i++)
			{
				this.cboIsla.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
            this.cboIsla.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));

			for (int i = 1; i <= 10; i++)
			{
				this.cboTurno.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
            this.cboTurno.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));

			for (int i = 1; i <= 80; i++)
			{
				this.cboManguera.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
            this.cboManguera.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));

		}
		#endregion

		#region CargarArticulos
		private void CargarArticulos()
		{
			bool encontrado;

			//carga los articulos
			Servipunto.Estacion.Libreria.Configuracion.Articulos objArticulos = new Servipunto.Estacion.Libreria.Configuracion.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);			
			this.ddlArticulo.DataSource = objArticulos;
			this.ddlArticulo.DataTextField = "Descripcion";
			this.ddlArticulo.DataValueField = "IdArticulo";
			this.ddlArticulo.DataBind();

			//carga las unidades metricas diferentes
			ddlUnidadMedida.Items.Clear();			
			foreach(Servipunto.Estacion.Libreria.Configuracion.Articulo objAticulo in objArticulos)
			{
				encontrado = false;
				for(int i=0; i<ddlUnidadMedida.Items.Count; i++)
					if(ddlUnidadMedida.Items[i].ToString().ToUpper() == objAticulo.UnidadMedida.ToUpper())
					{
						encontrado = true;
						break;
					}
				if(!encontrado)
					this.ddlUnidadMedida.Items.Add(new ListItem(objAticulo.UnidadMedida,objAticulo.UnidadMedida));

			}
            this.ddlArticulo.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));
            this.ddlUnidadMedida.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0")); 
			
			objArticulos = null;
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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }
	}
}
