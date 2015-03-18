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
	public class Capturador : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.DropDownList cboPuerto;

		protected WebApplication.FormMode _mode;
		protected Libreria.Configuracion.Capturador _objCapturador = null;
		protected System.Web.UI.WebControls.RadioButtonList rblCapturador;
		protected System.Web.UI.WebControls.TextBox txtDireccionIp;
		protected System.Web.UI.WebControls.TextBox txtDireccionIp3ro;
		protected System.Web.UI.WebControls.TextBox txtPuertoSocket;
		protected System.Web.UI.WebControls.TextBox txtPuertoSocket3ro;
		protected System.Web.UI.WebControls.CheckBox chkVirtual;
        protected System.Web.UI.WebControls.Button btnCrear;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
		protected string _id = null;

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
			if (Request.QueryString["IdCapturador"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdCapturador"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
				this.InicializarForma();
                Traducir();
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
			this.rblCapturador.SelectedIndexChanged += new System.EventHandler(this.rblCapturador_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Capturadores";
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

		#region ObtenerObjetoCapturador
		private bool ObtenerObjetoCapturador()
		{
			try
			{
                this._id = lblHide.Text;  //DecryptText(Convert.ToString(Request.QueryString["IdCapturador"].Replace(" ", "+")));
				this._objCapturador = Libreria.Configuracion.Capturadores.ObtenerItem(Convert.ToInt16(this._id),"0");
				if (this._objCapturador == null)
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

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				try
				{
					this.lblBack.NavigateUrl = "Capturadores.aspx";
					this.CargarPuertos();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(17,Global.Idioma) + "</b>";
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoCapturador())
						{
							//Visualización de Datos						
							this.txtId.Text = this._objCapturador.IdCapturador.ToString();
							this.cboPuerto.SelectedValue = this._objCapturador.IdPuerto;
							this.rblCapturador.SelectedValue = this._objCapturador.CapturadorSerial == true?"1":"0";
							this.txtDireccionIp.Text = this._objCapturador.DireccionIP.Trim();
							this.txtPuertoSocket.Text = this._objCapturador.PuertoSocketEscucha.ToString();
							this.txtDireccionIp3ro.Text = this._objCapturador.DireccionIP3ro;
							this.txtPuertoSocket3ro.Text = this._objCapturador.PuertoSocket3ro.ToString();
							this.chkVirtual.Checked = this._objCapturador.IdRegistro == 0?true:false;
							this.txtId.Enabled = false;
                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(463, Global.Idioma) + ": <b>" + this._objCapturador.IdCapturador.ToString() + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
						}
						#endregion
					}
					this.ActivarControles();
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

		private void ActivarControles()
		{
			if(rblCapturador.SelectedValue == "1")
			{
				cboPuerto.Enabled = true;
				txtDireccionIp.Enabled = false;
				txtPuertoSocket.Enabled = false;
				txtDireccionIp3ro.Enabled = false;
				txtPuertoSocket3ro.Enabled = false;
				chkVirtual.Enabled = true;
			}
			else
			{
				cboPuerto.Enabled = false;
				txtDireccionIp.Enabled = true;
				txtPuertoSocket.Enabled = true;
				txtDireccionIp3ro.Enabled = true;
				txtPuertoSocket3ro.Enabled = true;
				chkVirtual.Enabled = false;
			}

		}

		private void rblCapturador_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.ActivarControles();
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,63, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();

						this._objCapturador = new Libreria.Configuracion.Capturador();
						this._objCapturador.IdCapturador = Convert.ToInt16(this.txtId.Text);
						this._objCapturador.IdPuerto = this.cboPuerto.SelectedValue;
						this._objCapturador.CapturadorSerial = this.rblCapturador.SelectedValue == "0"?false:true;
						this._objCapturador.DireccionIP = this.txtDireccionIp.Text.Trim();
						this._objCapturador.PuertoSocketEscucha = int.Parse(this.txtPuertoSocket.Text);
						this._objCapturador.DireccionIP3ro = this.txtDireccionIp3ro.Text;
						this._objCapturador.PuertoSocket3ro = int.Parse(this.txtPuertoSocket3ro.Text);
						this._objCapturador.IdRegistro = chkVirtual.Checked?0:-1;
						if(!_objCapturador.CapturadorSerial)
							this._objCapturador.IdRegistro = -1;
						Libreria.Configuracion.Capturadores.Adicionar(this._objCapturador);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoCapturador())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,64, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objCapturador.IdCapturador = Convert.ToInt16(this.txtId.Text);
							this._objCapturador.IdPuerto = this.cboPuerto.SelectedValue;
							this._objCapturador.CapturadorSerial = this.rblCapturador.SelectedValue == "0"?false:true;
							this._objCapturador.DireccionIP = this.txtDireccionIp.Text.Trim();
							this._objCapturador.PuertoSocketEscucha = int.Parse(this.txtPuertoSocket.Text);
							this._objCapturador.DireccionIP3ro = this.txtDireccionIp3ro.Text;
							this._objCapturador.PuertoSocket3ro = int.Parse(this.txtPuertoSocket3ro.Text);
							this._objCapturador.IdRegistro = chkVirtual.Checked?0:-1;
							if(!_objCapturador.CapturadorSerial)
								this._objCapturador.IdRegistro = -1;
							this._objCapturador.Modificar();
						}
						#endregion
					}
					Response.Redirect("Capturadores.aspx");
				}
				catch (Exception ex)
				{
					this.lblError.Visible = true;
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
					this._objCapturador = null;
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
			string [] cadena;
			this.ClearError();
			try
			{
				//valida si el puerto es entero 
				try
				{
					int puerto = int.Parse(txtPuertoSocket.Text);
				}
				catch(Exception)
				{
					txtPuertoSocket.Text = "0";
				}

				try
				{
					int puerto = int.Parse(txtPuertoSocket3ro.Text);
				}
				catch(Exception)
				{
					txtPuertoSocket3ro.Text = "0";
				}

				if (this.txtId.Text.Trim().Length != 0)
				{
					if (!Libreria.Aplicacion.IsNumeric(this.txtId.Text.Trim()))
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1809, Global.Idioma), false);
						return false;
					}
				}
				else
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1810, Global.Idioma), false);
					return false;
				}
				
				if(rblCapturador.SelectedValue != "1")
				{
					
					//valida si el puerto es entero 
					try
					{
						int puerto = int.Parse(txtPuertoSocket.Text);
					}
					catch(Exception)
					{
                        throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1821, Global.Idioma));
					}

					try
					{
						int puerto = int.Parse(txtPuertoSocket3ro.Text);
					}
					catch(Exception)
					{
                        throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1822, Global.Idioma));
					}

					//valida las ip
					cadena = txtDireccionIp.Text.Split(".".ToCharArray());
					if(cadena.Length != 4)
                        throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1823, Global.Idioma));
					for(int i=0; i<=3; i++)
					{
						if(int.Parse(cadena[i])< 0 || int.Parse(cadena[i]) > 255)
                            throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1823, Global.Idioma));
					}

					cadena = txtDireccionIp3ro.Text.Split(".".ToCharArray());
					if(cadena.Length != 4)
                        throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1824, Global.Idioma));
					for(int i=0; i<=3; i++)
					{
						if(int.Parse(cadena[i])< 0 || int.Parse(cadena[i]) > 255)
                            throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1824, Global.Idioma));
					}
					//valida el rango del puerto
					if(int.Parse(txtPuertoSocket.Text)<1 || int.Parse(txtPuertoSocket.Text) > 65535)
					{
                        throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1821, Global.Idioma));
					}
					if(int.Parse(txtPuertoSocket3ro.Text)<1 || int.Parse(txtPuertoSocket3ro.Text) > 65535)
					{
                        throw new Exception(Libreria.Configuracion.PalabrasIdioma.Traduccion(1822, Global.Idioma));
					}

				}
	
			}
			catch(Exception ex)
			{
				this.SetError("Error! " + ex.Message, false);
				return false;
			}
			return true;

		}
		#endregion

		#region CargarPuertos
		private void CargarPuertos()
		{
			Libreria.Configuracion.Puertos objPuertos = new Libreria.Configuracion.Puertos();

			this.cboPuerto.DataSource = objPuertos;
			this.cboPuerto.DataTextField = "IdPuerto";
			this.cboPuerto.DataValueField = "IdPuerto";
			this.cboPuerto.DataBind();

			if (this.cboPuerto.Items.Count == 0)
			{
                this.cboPuerto.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1820, Global.Idioma));
				this.AcceptButton.Disabled = true;
			}
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

        #region Traducir
        private void Traducir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1109,Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1110, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1111, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1112, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1113, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1114, Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1115, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
        }
        #endregion
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion



    }
}
