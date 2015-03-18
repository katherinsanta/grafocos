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
using Servipunto.Estacion.Web;

namespace Servipunto.Estacion.Reportes
{
	public class FiltroAuditoriaError : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.Panel pnlcodArticulo;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.RadioButtonList rbFormato;
		protected System.Web.UI.WebControls.DropDownList cboTipoError;
		protected System.Web.UI.WebControls.DropDownList cboMinutoInicial;
		protected System.Web.UI.WebControls.DropDownList cboHoraInicial;
		protected System.Web.UI.WebControls.DropDownList cboMinutoFinal;
		protected System.Web.UI.WebControls.DropDownList cboHoraFinal;
		protected System.Web.UI.WebControls.TextBox txtDetallePersonal;
		protected System.Web.UI.WebControls.TextBox txtDetalleDebug;
		protected System.Web.UI.WebControls.TextBox txtPosibleSuceso;
		protected System.Web.UI.WebControls.DropDownList cboOrdenar;
		protected System.Web.UI.WebControls.Label lblArticulo;
		protected System.Web.UI.WebControls.DropDownList cboAplicacion;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.Label Label12;
        protected System.Web.UI.WebControls.Label Label13;
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

		#region EjecutarReporte
		private void EjecutarReporte()
		{
			if (this.Validar())
			{
				try
				{
					string fechaInicial;
					string fechaFinal;
                    fechaInicial = Convert.ToDateTime(txtFechaInicial.Text).ToShortDateString() + " " + cboHoraInicial.SelectedValue + ":" + cboMinutoInicial.SelectedValue.PadLeft(2, '0');
                    fechaFinal = Convert.ToDateTime(txtFechaFin.Text).ToShortDateString() + " " + cboHoraFinal.SelectedValue + ":" + cboMinutoFinal.SelectedValue.PadLeft(2, '0') + ":59.999";

					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,490, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					DataDynamics.ActiveReports.ActiveReport report = null;
					report = new Servipunto.Estacion.Web.Modules.Rpt.AuditoriaError(DateTime.Parse(fechaInicial), 
																					DateTime.Parse(fechaFinal),
																					int.Parse(cboAplicacion.SelectedValue), 
																					int.Parse(cboTipoError.SelectedValue),
																					cboOrdenar.SelectedValue,
																					txtDetalleDebug.Text.Trim(),
																					txtDetallePersonal.Text.Trim(),
																					txtPosibleSuceso.Text.Trim()
																					);
					Session["LastReport"] = report;
					Session["Formato"] = rbFormato.SelectedValue;
					Response.Redirect("../Visor/PDF.aspx",false);
				}
				catch (Exception ex)
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
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Auditoria";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Auditoria de errores");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}
			
			return true;
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(437, Global.Idioma) + "</b>";
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(813, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(439, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(262, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(452, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(458, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(829, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(448, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(832, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(831, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            #region poblar RadioButton  TipoReporte            
            this.cboAplicacion.Items.Clear();
            this.cboAplicacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(703, Global.Idioma), "1"));
            this.cboAplicacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(805, Global.Idioma), "2"));
            this.cboAplicacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(807, Global.Idioma), "7"));
            this.cboAplicacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(469, Global.Idioma), "8"));
            this.cboAplicacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));
            this.cboAplicacion.SelectedValue = "1";
            this.cboTipoError.Items.Clear();
            this.cboTipoError.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "1"));
            this.cboTipoError.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(819, Global.Idioma), "2"));
            this.cboTipoError.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(820, Global.Idioma), "3"));
            this.cboTipoError.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(821, Global.Idioma), "4"));
            this.cboTipoError.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(822, Global.Idioma), "5"));
            this.cboTipoError.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(823, Global.Idioma), "0"));
            this.cboTipoError.SelectedValue = "0";
            this.cboOrdenar.Items.Clear();
            this.cboOrdenar.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma), "s.fecha"));
            this.cboOrdenar.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(439, Global.Idioma), "p.aplicativo"));
            this.cboOrdenar.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(813, Global.Idioma), "tp.tipoError"));
            this.cboOrdenar.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(814, Global.Idioma), "e.detallePersonal"));
            this.cboOrdenar.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(815, Global.Idioma), "e.detalleDebug"));
            this.cboOrdenar.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(816, Global.Idioma), "a.Descripcion"));
            this.cboOrdenar.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(817, Global.Idioma), "s.idresponsable"));            
            this.cboOrdenar.SelectedValue = "s.fecha";            
            #endregion
            ViewState["Control"] = "1";
            #endregion            
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
			for(int i=0; i<=23; i++)
			{
				cboHoraInicial.Items.Add(i.ToString().PadLeft(2,'0'));
				cboHoraFinal.Items.Add(i.ToString().PadLeft(2,'0'));
			}

			for(int i=0; i<=55; i+=5)
			{
				cboMinutoInicial.Items.Add(i.ToString().PadLeft(2,'0'));
				cboMinutoFinal.Items.Add(i.ToString().PadLeft(2,'0'));
			}
			cboMinutoFinal.Items.Add("59");
			cboHoraFinal.SelectedIndex = cboHoraFinal.Items.Count -1;
			cboMinutoFinal.SelectedIndex = cboMinutoFinal.Items.Count -1;

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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
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
