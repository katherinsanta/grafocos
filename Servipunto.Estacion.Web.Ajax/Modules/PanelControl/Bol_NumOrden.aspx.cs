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
	/// Summary description for Bol_NumOrden.
	/// </summary>
	public class Bol_NumOrden : System.Web.UI.Page
	{
		#region Declaración de Controles
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.TextBox txtPrefijo;
		protected System.Web.UI.WebControls.TextBox txtIniConsec;
		protected System.Web.UI.WebControls.TextBox txtFinConsec;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.Label lblIdNumOrden;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected Servipunto.Estacion.Libreria.Configuracion.Bol_NumOrden _objBolNumOrden = null;		
		protected System.Web.UI.WebControls.DropDownList ddlTributarioRegimen;
		protected System.Web.UI.WebControls.Label lblEstado;		
		protected System.Web.UI.WebControls.TextBox txtNumOder;
		protected System.Web.UI.WebControls.TextBox txtActividadEconomica;
        protected System.Web.UI.WebControls.TextBox txtFechaInicio;
        protected System.Web.UI.WebControls.TextBox txtFechaFinal;
        protected System.Web.UI.WebControls.Calendar Calendar1;
        protected System.Web.UI.WebControls.Calendar Calendar2;
        protected System.Web.UI.WebControls.ImageButton ibMostrarCalendarioInicial;
        protected System.Web.UI.WebControls.ImageButton ibMostrarCalendarioFinal;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender1;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender2;
		protected string _id = null;
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
		#region Page Load
		private void Page_Load(object sender, System.EventArgs e)
		{
            
            if (Request.QueryString["IdNumOrden"] == null && lblHide.Text == "")
                this._mode = WebApplication.FormMode.New;
            else            
                this._mode = WebApplication.FormMode.Edit;
            


			if (!this.IsPostBack)
			{
                if (ViewState["Control"].ToString() != "1")
                {
                    if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                    {
                        this._id = DecryptText(Convert.ToString(Request.QueryString["IdNumOrden"].Replace(" ", "+")));
                        lblHide.Text = this._id;
                    }
                    this.InicializarForma();
                    Traduccion();
                    CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                }
			}
			else
				if (Request.Form["AcceptButton"] != null)
				this.Guardar();

		}
		#endregion

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Dosificacion de Facturas";
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

		#region Metodo de Inicializacion del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				try
				{
                    ViewState["Control"] = "1";   
                    RadioButtonTraduccion();
					this.lblBack.NavigateUrl = "Bol_NumOrdenes.aspx";
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.lblFormTitle.Text = "<b>"  + Libreria.Configuracion.PalabrasIdioma.Traduccion(1720,Global.Idioma) + "</b>";
                        this.lblIdNumOrden.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1721, Global.Idioma) + "</b>";
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma) ;
                        txtFechaInicio.Text = DateTime.Today.ToShortDateString();
                        txtFechaFinal.Text = DateTime.Today.ToShortDateString();
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if(this.ObtenerElemento())
						{
							this.lblIdNumOrden.Text ="<b>"+this._objBolNumOrden.IdNumOrden.ToString()+"</b>";
							this.txtNumOder.Text = this._objBolNumOrden.NumOrder;
							this.txtPrefijo.Text = this._objBolNumOrden.Prefijo;
							this.txtIniConsec.Text = this._objBolNumOrden.IniConsec.ToString();
							this.txtFinConsec.Text = this._objBolNumOrden.FinConsec.ToString();
							this.txtActividadEconomica.Text = this._objBolNumOrden.ActEconomica;
							this.ddlTributarioRegimen.SelectedValue = this._objBolNumOrden.Regimen;
                            this.txtFechaInicio.Text = this._objBolNumOrden.FechaInicial.ToShortDateString();
                            this.txtFechaFinal.Text = this._objBolNumOrden.FechaFinal.ToShortDateString();
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
						

							if(this._objBolNumOrden.Estado == (byte)0) 
								this.lblEstado.Text = "Activo";
							else
								if(this._objBolNumOrden.Estado == (byte)1) 
								this.lblEstado.Text = "Utilizado";
							else
								if(this._objBolNumOrden.Estado == (byte)2) 
								this.lblEstado.Text = "En Espera";

							this.lblFormTitle.Text = "Resolución No: " + this._objBolNumOrden.NumOrder.ToString();
							this.AcceptButton.Value = "Guardar";
						
						}
						#endregion
					}
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
		}
		#endregion

		#region Obtener Elementos
		private bool ObtenerElemento()
		{
			try
			{
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["IdNumOrden"].Replace(" ", "+")));
				this._objBolNumOrden = Libreria.Configuracion.Bol_NumOrdenes.Obtener(Convert.ToInt32(this._id));
				if(this._objBolNumOrden == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
                return false;
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
			this.Load += new System.EventHandler(this.Page_Load);
            //this.ibMostrarCalendarioInicial.Click += new System.Web.UI.ImageClickEventHandler(this.ibMostrarCalendarioInicial_Click);
            //this.ibMostrarCalendarioFinal.Click += new System.Web.UI.ImageClickEventHandler(this.ibMostrarCalendarioFinal_Click);

		}
		#endregion

		#region Método Guardar
		private void Guardar()
		{
			if(this.Validar())
			{
				try
				{
					if(this._mode == WebApplication.FormMode.New)
						{
																
							#region Insertar
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,155, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objBolNumOrden = new Libreria.Configuracion.Bol_NumOrden();

							this._objBolNumOrden.NumOrder = txtNumOder.Text;
							this._objBolNumOrden.Prefijo = txtPrefijo.Text;
							this._objBolNumOrden.IniConsec = Convert.ToInt32(txtIniConsec.Text);
							this._objBolNumOrden.FinConsec = Convert.ToInt32(txtFinConsec.Text);
							this._objBolNumOrden.ActEconomica= txtActividadEconomica.Text;							
							this._objBolNumOrden.Regimen = this.ddlTributarioRegimen.SelectedValue;
                            this._objBolNumOrden.FechaInicial = Convert.ToDateTime(this.txtFechaInicio.Text);
                            this._objBolNumOrden.FechaFinal = Convert.ToDateTime(this.txtFechaFinal.Text);                          

							
							//Es falso = 0, dado que las Dosificaciones con estado 0 quieren decir que estan activas, y si es nuevo, se envia por defecto este estado
							Libreria.Configuracion.Bol_NumOrdenes objEstado = new Servipunto.Estacion.Libreria.Configuracion.Bol_NumOrdenes(byte.Parse("0"));
					
							if (objEstado.Count == 1)
								this._objBolNumOrden.Estado = byte.Parse("2");
							else
								this._objBolNumOrden.Estado = byte.Parse("0");
						
							Libreria.Configuracion.Bol_NumOrdenes.Adicionar(this._objBolNumOrden);
                            Response.Redirect("Bol_NumOrdenes.aspx");
							#endregion
						
						}
						else
						{
							#region Modo de Edición
							if(this.ObtenerElemento())
							{
								Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,156, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
								Libreria.Configuracion.Bol_NumOrden objEstado = Servipunto.Estacion.Libreria.Configuracion.Bol_NumOrdenes.Obtener(int.Parse(this._id));
								//Solo se permite modificar si el estado es igual a 2 que significa "En Espera".
								if (objEstado.Estado == (byte)2)
								{
									this._objBolNumOrden.IdNumOrden = int.Parse(this._id);
									this._objBolNumOrden.NumOrder = this.txtNumOder.Text;
									this._objBolNumOrden.Prefijo = txtPrefijo.Text;
									this._objBolNumOrden.IniConsec = Convert.ToInt32(txtIniConsec.Text);
									this._objBolNumOrden.FinConsec = Convert.ToInt32(txtFinConsec.Text);
									this._objBolNumOrden.ActEconomica = this.txtActividadEconomica.Text;
									this._objBolNumOrden.Regimen = this.ddlTributarioRegimen.SelectedValue;
                                    this._objBolNumOrden.FechaInicial = Convert.ToDateTime(this.txtFechaInicio.Text);
                                    this._objBolNumOrden.FechaFinal = Convert.ToDateTime(this.txtFechaFinal.Text);

									//Es falso = 0, dado que las Dosificaciones con estado 0 quieren decir que estan activas, y si es nuevo, se envia por defecto este estado
									this._objBolNumOrden.Estado = byte.Parse("2");
							
									this._objBolNumOrden.Modificar();
                                    Response.Redirect("Bol_NumOrdenes.aspx");
								}
								else
                                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1949, Global.Idioma), true);
							}
							#endregion
						}
						
					}
				
				catch (Exception ex)
				{
					this.lblError.Visible = true;
                    //if (ex.Message.IndexOf("PK_Bol_NumOrdenes", 1, 100) != 0)
                    //    this.SetError("Error: La dosificación especificada ya existe!", false);
                    //else
						this.lblError.Text = ex.Message;
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
					this._objBolNumOrden = null;
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
			this.ClearError();
			if (this.txtNumOder.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1963, Global.Idioma), false);
				return false;
			}
//			if (this.txtPrefijo.Text.Trim().Length == 0)
//			{
//				this.SetError("El prefijo de la orden no puede ser una cadena vacía!", false);
//				return false;
//			}

			if (this.txtIniConsec.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1964, Global.Idioma), false);
				return false;
			}

			if (this.txtFinConsec.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1964, Global.Idioma), false);
				return false;
			}

			if (int.Parse(this.txtIniConsec.Text.Trim()) > int.Parse(this.txtFinConsec.Text.Trim()))
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1964, Global.Idioma), false);
				return false;
			}

            if (Convert.ToDateTime(txtFechaInicio.Text) > Convert.ToDateTime(txtFechaFinal.Text))
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1965, Global.Idioma), false);
                return false;
            }

            
			if (this.txtNumOder.Text.Trim().Length != 0 ) 
			{
//				try
//				{
//					if( int.Parse(this.txtNumOder.Text.Trim()) < Global.Idioma)
//					{
//						this.SetError("El número de la orden debe ser mayor a cero!", false);
//						return false;
//					}
//
//				}
//				catch
//				{
//					this.SetError("El número de la orden debe ser numérico!", false);
//					return false;
//				}
			}

			if (this.txtIniConsec.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtIniConsec.Text.Trim()) < 1)
					{
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1966, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1967, Global.Idioma), false);
					return false;
				}
			}

			if (this.txtFinConsec.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtFinConsec.Text.Trim()) < 1)
					{
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1968, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1969, Global.Idioma), false);
					return false;
				}
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


        #region Eventos de calendario
        #region Mostrar Calendario Inicial
        private void ibMostrarCalendarioInicial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.Calendar1.Visible = !this.Calendar1.Visible;
            if (this.Calendar2.Visible)
                this.Calendar2.Visible = !this.Calendar2.Visible;

        }
        #endregion

        #region Mostrar Calendario Final
        private void ibMostrarCalendarioFinal_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.Calendar2.Visible = !this.Calendar2.Visible;
            if (this.Calendar1.Visible)
                this.Calendar1.Visible = !this.Calendar1.Visible;
            
        }
        #endregion

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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaInicio.Text = this.Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            this.Calendar1.Visible = !this.Calendar1.Visible;

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaFinal.Text = this.Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            this.Calendar2.Visible = !this.Calendar2.Visible;
        }

        private void Traduccion()
        {
            Label2.Text = "Id " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1717, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1519, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1520, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1521, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1522, Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1718, Global.Idioma);
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1719, Global.Idioma);
            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1523, Global.Idioma);
            Label10.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1524, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
            lblEstado.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma);
            AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlTributarioRegimen
            this.ddlTributarioRegimen.Items.Clear();
            this.ddlTributarioRegimen.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlTributarioRegimen.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2373, Global.Idioma), "Comun"));
            this.ddlTributarioRegimen.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2374, Global.Idioma), "Simplificado"));
            this.ddlTributarioRegimen.SelectedValue = "(Sin Definir)";
            #endregion            
        }
        #endregion

	}
}
