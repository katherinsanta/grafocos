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
	public class FiltroCierreTurno : System.Web.UI.Page
	{
		#region Declaración de Controles
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblReporte;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.TextBox txtTurno;
		protected System.Web.UI.WebControls.DropDownList cboIsla;
		protected System.Web.UI.WebControls.RadioButtonList rbnCreditoDirecto;
		protected System.Web.UI.WebControls.RadioButtonList rbnFormasPago;
		protected System.Web.UI.WebControls.RadioButtonList rbnArticulos;
		protected System.Web.UI.WebControls.RadioButtonList rbnLectuas;
		protected System.Web.UI.WebControls.RadioButtonList rbnTurnoIsla;		
		protected System.Web.UI.WebControls.RadioButtonList rbnInformacionTurno;
		protected System.Web.UI.WebControls.RadioButtonList rbFormato;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblInfoTurno;
        protected System.Web.UI.WebControls.Label lblResumenIsla;
        protected System.Web.UI.WebControls.Label lblDiffLecturas;
        protected System.Web.UI.WebControls.Label lblArticulos;
        protected System.Web.UI.WebControls.Label lblFormasPago;
        protected System.Web.UI.WebControls.Label lblCreditoDirecto;
        protected System.Web.UI.WebControls.Label lblFecha;

		#endregion
	
		#region Form Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (this.IsPostBack)
			{
				if (Request.Form["__EVENTTARGET"].Length == 0)
					this.EjecutarReporte();
			}
			else
			{
				this.InicializarForma();
				this.VerificarPermisos();
                this.Traducir();
			}
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			try
			{
				int.Parse(this.txtTurno.Text);
			}
			catch(Exception)
			{
				this.SetError("Debe ingresar un turno valido o seleccionar la casilla todos los turnos!");
				return false;
			}
			return true;
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Periodo de Tiempo";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Cierre Turno");
			
			if (!permiso)
			{
				this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
                this.pnlForm.Visible = false;
                //this.MyForm.Visible = false;
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
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,334, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					DataDynamics.ActiveReports.ActiveReport report = null;
                    if (lblReporte.Text == "Sales Report Closing Time")
                        report = new Servipunto.Estacion.Web.Modules.Rpt.CierreTurno(this.FechaInicio.SelectedDate,
                        this.txtTurno.Text,
                        int.Parse(this.cboIsla.SelectedValue),
                        rbnInformacionTurno.SelectedValue == "1" ? true : false,
                        false,
                        rbnTurnoIsla.SelectedValue == "1" ? true : false,
                        rbnLectuas.SelectedValue == "1" ? true : false,
                        rbnArticulos.SelectedValue == "1" ? true : false,
                        rbnFormasPago.SelectedValue == "1" ? true : false,
                        rbnCreditoDirecto.SelectedValue == "1" ? true : false, 1
                        );
                    else
                        report = new Servipunto.Estacion.Web.Modules.Rpt.CierreTurno(this.FechaInicio.SelectedDate,
                        this.txtTurno.Text,
                        int.Parse(this.cboIsla.SelectedValue),
                        rbnInformacionTurno.SelectedValue == "1" ? true : false,
                        false,
                        rbnTurnoIsla.SelectedValue == "1" ? true : false,
                        rbnLectuas.SelectedValue == "1" ? true : false,
                        rbnArticulos.SelectedValue == "1" ? true : false,
                        rbnFormasPago.SelectedValue == "1" ? true : false,
                        rbnCreditoDirecto.SelectedValue == "1" ? true : false, 0
                        );
					Session["LastReport"] = report;
					Session["Formato"] = rbFormato.SelectedValue;
					Response.Redirect("../Visor/PDF.aspx",false);
				}
				catch (Exception ex)
				{
					this.SetError(ex.Message);
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el reporte de ventas por cierre de turno. ");
					}
					catch(Exception exx)
					{
						lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						this.SetError(lblError.Text);

					}
					#endregion

				}
			}
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Reporte de Ventas por Cierre de Turno</b>";
			this.FechaInicio.SelectedDate = System.DateTime.Now;
			this.txtTurno.Text = "1";
			this.CargarIslas();
		}
		#endregion

		#region CargarIslas
		private void CargarIslas()
		{
			for (int i = 1; i <= 15; i++)
			{
				this.cboIsla.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
		}
		#endregion

		#region SetError
		private void SetError(string message)
		{
			this.lblError.Visible = true;
			this.lblError.Text = message;
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

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2197, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            rbnTurnoIsla.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            rbnTurnoIsla.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma);
            rbnArticulos.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            rbnArticulos.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma);
            rbnCreditoDirecto.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            rbnCreditoDirecto.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma);
            rbnFormasPago.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            rbnFormasPago.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma);
            rbnInformacionTurno.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            rbnInformacionTurno.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma);
            rbnLectuas.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            rbnLectuas.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblInfoTurno.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(233, Global.Idioma);
            lblResumenIsla.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(235, Global.Idioma);
            lblFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            lblCreditoDirecto.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2234, Global.Idioma);
            lblDiffLecturas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(236, Global.Idioma);
            lblArticulos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1022, Global.Idioma);
            lblFormasPago.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(980, Global.Idioma);
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }
	}
}
