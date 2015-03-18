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
#region Sección de Declaraciones

	public class Restriccion : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.HtmlControls.HtmlTableRow filaPlaca;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtIdRestriccion;
		protected System.Web.UI.WebControls.TextBox txtCodigoROM;
		protected System.Web.UI.WebControls.DropDownList ddlTipoRestriccion;
		protected System.Web.UI.WebControls.TextBox txtPlaca;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton EstadoActivo;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton EstadoInactivo;
		protected System.Web.UI.WebControls.Label lblCodigoEmpleado;
		protected System.Web.UI.HtmlControls.HtmlTableRow filaEmpleado;
		protected Libreria.Comercial.Restriccion _objRestriccion = null;
		protected System.Web.UI.WebControls.Label lblPlaca;
        protected System.Web.UI.WebControls.Label lblHide;
		protected string _placa = null;
		protected short _dia;
		protected System.Web.UI.WebControls.DropDownList cboDia;
		protected DateTime _horaInicio;
		protected System.Web.UI.WebControls.LinkButton lblGuardar;
		protected System.Web.UI.WebControls.DropDownList cboHoraInicio;
		protected System.Web.UI.WebControls.DropDownList cboHoraFin;
		protected System.Web.UI.WebControls.TextBox cboMinutoInicio;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.TextBox cboMinutoFin;
		protected System.Web.UI.WebControls.TextBox txtLlaveCompuesta;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
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
            Traducir();
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
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.QueryString["Dia"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
				if (this._dia == 0 & this._mode == WebApplication.FormMode.Edit )
				{
                    //lblHide.Text = this._dia.ToString();
					this._placa = DecryptText(Convert.ToString(Request.QueryString["placa"].Replace(" ","+") ));
					this._dia = short.Parse((Request.QueryString["dia"].ToString().Trim()));
					this._horaInicio = DateTime.Parse(Request.QueryString["horainicio"].ToString().Trim());
				}
				this.InicializarForma();
			}
			//else
				//if (Request.Form["AcceptButton"] != null)
				


			
		}
		#endregion
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  cboDia
            this.cboDia.Items.Clear();
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2047, Global.Idioma), "7"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2064, Global.Idioma), "0"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2048, Global.Idioma), "1"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2049, Global.Idioma), "2"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2050, Global.Idioma), "3"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2051, Global.Idioma), "4"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2052, Global.Idioma), "5"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2053, Global.Idioma), "6"));
            this.cboDia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2054, Global.Idioma), "8"));
            this.cboDia.SelectedValue = "0";
            #endregion
            
        }
        #endregion
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2046, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(452, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(458, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2027, Global.Idioma);
            

            
            lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1662, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
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
			this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Comerciales";
			const string opcion = "Identificadores";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}			
			return true;
		}
		#endregion

		#region ObtenerObjetoRestriccion
		private bool ObtenerObjetoRestriccion()
		{
			try
			{
				this._objRestriccion = Libreria.Comercial.Restricciones.ObtenerItem(_placa,_dia,_horaInicio);
				if (this._objRestriccion == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objRestriccion + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objRestriccion + "]", true);
                return false;
			}
		}
		#endregion

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			try
			{
				this.lblBack.NavigateUrl = "Restricciones_.aspx?Placa=" + Request.QueryString["Placa"]+ "&IdCliente=" + Request.QueryString["IdCliente"] + "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"];

				if (this.VerificarPermisos())
				{
                    RadioButtonTraduccion();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.lblFormTitle.Text = "<b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2055, Global.Idioma)+"</b>";
						//this.EstadoActivo.Disabled = this.EstadoInactivo.Disabled = true;
						//this.txtIdRestriccion.Enabled = true;
						this.lblPlaca.Text = DecryptText(Convert.ToString(Request.QueryString["placa"].Replace(" ","+") ));

						//this.AcceptButton.Value = "Crear";
                        this.lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1118, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoRestriccion())
						{
							string [] cadena;
							this.lblFormTitle.Text = "<b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2056, Global.Idioma)+"</b>";
							this.lblPlaca.Text = _objRestriccion.Placa;
							this.cboDia.SelectedValue = _objRestriccion.Dia.ToString();
							cadena = _objRestriccion.HoraInicioDisplay.Split(":".ToCharArray());														
							this.cboHoraInicio.SelectedValue = cadena[0].ToString();
							this.cboMinutoInicio.Text = cadena[1].ToString();							
							cadena = _objRestriccion.HoraFinDisplay.Split(":".ToCharArray());							
							this.cboHoraFin.SelectedValue = cadena[0].ToString();
							this.cboMinutoFin.Text = cadena[1].ToString();				
							this.txtLlaveCompuesta.Text = "";
							this.txtLlaveCompuesta.Text = this.lblPlaca.Text + ";" + this.cboDia.SelectedValue + ";" + cboHoraInicio.SelectedValue + ":" + cboMinutoInicio.Text;//this.txtHoraInicio.Tex;

							//Visualización de Datos
							/*this.lblCodigoEmpleado.Text = this._objRestriccion.CodigoEmpleado.ToString();
							this.txtIdRestriccion.Text =this._objRestriccion.NumeroRestriccion.ToString();

							if(_objRestriccion.RestriccionActivo == "Activo")
							{
								EstadoActivo.Checked = true;
								EstadoInactivo.Checked = false;
							}
							else
							{
								EstadoActivo.Checked = false;
								EstadoInactivo.Checked = true;
							}
						
							this.txtCodigoROM.Text = this._objRestriccion.IdRom;
							this.ddlTipoRestriccion.SelectedValue = this._objRestriccion.TipoRestriccion;
							this.txtPlaca.Text = this._objRestriccion.Placa;
							this.lblFormTitle.Text = "Restriccion: <b>" + this._objRestriccion.NumeroRestriccion.ToString() + "</b>";
							*/
                            this.lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
						}
						#endregion
					}
				}
			}
			catch(Exception ex)
			{
				SetError(ex.Message, false);
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
				return;
			}
		}
		#endregion

		#region Guardar
		private void lblGuardar_Click(object sender, System.EventArgs e)
		{
			this.Guardar();
		}

		private void Guardar()
		{			
			string [] cadena;
			if (this.Validar())
			{
				try
				{
					this._objRestriccion = new Libreria.Comercial.Restriccion();
					this._objRestriccion.Placa = lblPlaca.Text.Trim();
					this._objRestriccion.Dia = short.Parse(cboDia.SelectedValue);
					this._objRestriccion.HoraInicio = DateTime.Parse("1900-01-01 " + cboHoraInicio.SelectedValue + ":" + cboMinutoInicio.Text);
					this._objRestriccion.HoraFin = DateTime.Parse("1900-01-01 " + cboHoraFin.SelectedValue + ":" + cboMinutoFin.Text);

					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,311, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						Libreria.Comercial.Restricciones.Adicionar(this._objRestriccion);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,312, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this.txtLlaveCompuesta.Text = this.txtLlaveCompuesta.Text;
						cadena = this.txtLlaveCompuesta.Text.Split(";".ToCharArray());
						this._dia = short.Parse(cadena[1]);
						this._horaInicio = DateTime.Parse(cadena[2]);
						this._objRestriccion.Modificar(_dia,_horaInicio);
						#endregion
					}
					Response.Redirect("Restricciones_.aspx?Placa=" + Request.QueryString["Placa"]+ "&IdCliente=" + Request.QueryString["IdCliente"] + "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"]);
						//+ "&IdCliente=" + Request.QueryString["IdCliente"] 
						//+ "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"]);
				}
				catch (Exception ex)
				{
					SetError(ex.Message, false);
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
					return;
				}
				finally 
				{
					this._objRestriccion = null;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			cboMinutoInicio.Text = cboMinutoInicio.Text.PadLeft(2,'0');
			cboMinutoFin.Text = cboMinutoFin.Text.PadLeft(2,'0');
			if(int.Parse(cboMinutoInicio.Text) < 0 || int.Parse(cboMinutoInicio.Text) > 59)
			{
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2057, Global.Idioma), false);
				return false;
			}
			if(int.Parse(cboMinutoFin.Text) < 0 || int.Parse(cboMinutoFin.Text) > 59)
			{
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2058, Global.Idioma), false);
				return false;
			}

			
			return true;
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
