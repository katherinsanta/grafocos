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
	public class Surtidor : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHideIsla;        
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.DropDownList cboMarca;
		protected System.Web.UI.WebControls.TextBox txtProtocolo;
		protected System.Web.UI.WebControls.TextBox txtDensidad;
		protected System.Web.UI.WebControls.TextBox txtFactorDivision;

		protected WebApplication.FormMode _mode;

		protected Libreria.Configuracion.Surtidor _objSurtidor = null;
		protected System.Web.UI.WebControls.TextBox txtAutorizacion;
		protected System.Web.UI.WebControls.TextBox txtTotalizadores;
		protected System.Web.UI.WebControls.TextBox txtTiempoEstado;
		protected System.Web.UI.WebControls.TextBox txtTiempoDespacho;
		protected Libreria.Configuracion.Isla _objIsla = null;
		protected string _id = null;
		protected string _idIsla = null;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;


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
			if (Request.QueryString["IdSurtidor"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else 
				this._mode = WebApplication.FormMode.Edit;
			
			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdSurtidor"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                    lblHideIsla.Text = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ", "+")));
                }
				this.InicializarForma();
                Traduccir();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Surtidores";
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

		#region ObtenerObjetoSurtidor
		private bool ObtenerObjetoSurtidor()
		{
			try
			{
                this._id = lblHide.Text;  //DecryptText(Convert.ToString(Request.QueryString["IdSurtidor"].Replace(" ", "+")));
				this._objSurtidor = Libreria.Configuracion.Surtidores.ObtenerItem(Convert.ToInt16(this._id));
				if (this._objSurtidor == null)
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

		#region ObtenerObjetoIsla
		private bool ObtenerObjetoIsla()
		{
			try
			{
                if (lblHideIsla.Text == "")
                {
                    this._idIsla = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ", "+")));
                    lblHideIsla.Text = this._idIsla;
                }
                else
                    this._idIsla = lblHideIsla.Text;

                
				this._objIsla = Libreria.Configuracion.Islas.ObtenerItem(Convert.ToInt16(this._idIsla));
				if (this._objIsla == null)
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
			try
			{
				if (this.VerificarPermisos())
				{
					this.CargarMarcas();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						if (this.ObtenerObjetoIsla())
						{
                            //this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1728) + " " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1361) + "</b>";
							this.AcceptButton.Value = "Crear";
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
							this.lblBack.NavigateUrl = "Surtidores.aspx?IdIsla=" + Request.QueryString["IdIsla"];
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) , false);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoSurtidor())
						{
							//Visualización de Datos						
							this.txtId.Text = this._objSurtidor.IdSurtidor.ToString();
							this.cboMarca.SelectedValue = this._objSurtidor.Marca;
							this.txtProtocolo.Text = this._objSurtidor.Protocolo;
							this.txtDensidad.Text = this._objSurtidor.Densidad.ToString();
							this.txtFactorDivision.Text = this._objSurtidor.FactorDivision.ToString();
							this.txtTiempoEstado.Text = this._objSurtidor.TiempoEstado.ToString();
							this.txtAutorizacion.Text = this._objSurtidor.TiempoAutorizacion.ToString();
							this.txtTotalizadores.Text = this._objSurtidor.TiempoTotalizadores.ToString();
							this.txtTiempoDespacho.Text = this._objSurtidor.TiempoDespacho.ToString();

							this.txtId.Enabled = false;

                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma) +": <b>" + this._objSurtidor.IdIsla.ToString() + "</b>, " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1361, Global.Idioma) +": <b>" + this._objSurtidor.IdSurtidor.ToString() + "</b>";
							this.AcceptButton.Value = "Guardar";
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
							this.lblBack.NavigateUrl = "Surtidores.aspx?IdIsla=" + Request.QueryString["IdIsla"];
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) , false);
						#endregion
					}				
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
						if (this.ObtenerObjetoIsla())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,87, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objSurtidor = new Libreria.Configuracion.Surtidor();
							this._objSurtidor.IdSurtidor = Convert.ToInt16(this.txtId.Text);
							this._objSurtidor.IdIsla = this._objIsla.IdIsla;
							this._objSurtidor.Marca = this.cboMarca.SelectedValue;
							this._objSurtidor.Protocolo = this.txtProtocolo.Text.Trim();
							this._objSurtidor.Densidad = Convert.ToDecimal(this.txtDensidad.Text);
							this._objSurtidor.FactorDivision = Convert.ToInt16(this.txtFactorDivision.Text);
							this._objSurtidor.TiempoEstado = int.Parse(this.txtTiempoEstado.Text);
							this._objSurtidor.TiempoDespacho = int.Parse(this.txtTiempoDespacho.Text);
							this._objSurtidor.TiempoAutorizacion = int.Parse(this.txtAutorizacion.Text);
							this._objSurtidor.TiempoTotalizadores = int.Parse(this.txtTotalizadores.Text);
							Libreria.Configuracion.Surtidores.Adicionar(this._objSurtidor);
                            Response.Redirect("Surtidores.aspx?IdIsla=" + EncryptText(lblHideIsla.Text));
						}
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoSurtidor())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,88, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objSurtidor.Marca = this.cboMarca.SelectedValue;
							this._objSurtidor.Protocolo = this.txtProtocolo.Text.Trim();
							this._objSurtidor.Densidad = Convert.ToDecimal(this.txtDensidad.Text);
							this._objSurtidor.FactorDivision = Convert.ToInt16(this.txtFactorDivision.Text);
							this._objSurtidor.TiempoEstado = int.Parse(this.txtTiempoEstado.Text);
							this._objSurtidor.TiempoDespacho = int.Parse(this.txtTiempoDespacho.Text);
							this._objSurtidor.TiempoAutorizacion = int.Parse(this.txtAutorizacion.Text);
							this._objSurtidor.TiempoTotalizadores = int.Parse(this.txtTotalizadores.Text);
							this._objSurtidor.Modificar();

							Response.Redirect("Surtidores.aspx?IdIsla=" + EncryptText(lblHideIsla.Text));
						}
						#endregion
					}					
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
					this._objSurtidor = null;
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
			//Número del Surtidor
			if (this.txtId.Text.Trim().Length != 0)
			{
				try
				{
					 int.Parse(this.txtId.Text.Trim());
				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1839, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1840, Global.Idioma), false);
				return false;
			}

			if (this.txtProtocolo.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1841, Global.Idioma), false);
				return false;
			}
			//Densidad
			if (this.txtDensidad.Text.Trim().Length != 0)
			{
				try
				{
					Decimal.Parse(txtDensidad.Text.Trim().Replace(",","."));
				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1842, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1843, Global.Idioma), false);
				return false;
			}
			if (this.txtTiempoEstado.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(this.txtTiempoEstado.Text.Trim());
				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1844, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1845, Global.Idioma), false);
				return false;
			}
			if (this.txtTiempoDespacho.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(this.txtTiempoDespacho.Text.Trim());
				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1846, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1847, Global.Idioma), false);
				return false;
			}
			//Factor de División
			if (this.txtFactorDivision.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(txtFactorDivision.Text.Trim());
				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1848, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1849, Global.Idioma), false);
				return false;
			}

			if (this.txtAutorizacion.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(this.txtAutorizacion.Text.Trim());
				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1850, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1851, Global.Idioma), false);
				return false;
			}

			if (this.txtTotalizadores.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(this.txtTotalizadores.Text.Trim());
				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1852, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1853, Global.Idioma), false);
				return false;
			}
			return true;
		}
		#endregion

		#region CargarMarcas
		/// <summary>
		///  Carga las marcas de surtidores disponibles
		/// </summary>
		/// Referencia Documental:  ProyectoInterfaseWayne > Proyecto Interfase Wayne_GA_CUS_CPR  
		/// Fecha:  09/09/2008
		/// Autor:  Elvis Astaiza Gutierrez
		private void CargarMarcas()
		{
			this.cboMarca.Items.Add(new ListItem("Agira", "Agira"));
			this.cboMarca.Items.Add(new ListItem("Aspro", "Aspro"));
			this.cboMarca.Items.Add(new ListItem("Galileo", "Galileo"));
			this.cboMarca.Items.Add(new ListItem("Gilbarco", "Gilbarco"));
			this.cboMarca.Items.Add(new ListItem("GilbarcoU", "GilbarcoU"));
			this.cboMarca.Items.Add(new ListItem("Tokheim", "Tokheim"));
			this.cboMarca.Items.Add(new ListItem("Wayne", "Wayne"));
			this.cboMarca.Items.Add(new ListItem("Efiqual", "Efiqual"));
			this.cboMarca.Items.Add(new ListItem("Coritec", "Coritec"));
			this.cboMarca.Items.Add(new ListItem("Hart", "Hart"));
			this.cboMarca.Items.Add(new ListItem("WayneIGEM", "WayneIGEM"));
            this.cboMarca.Items.Add(new ListItem("Wayne5D", "Wayne5D"));
            this.cboMarca.Items.Add(new ListItem("Bennett", "Bennett"));
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

        private void Traduccir()
        {
            Label1.Text = "# " + Libreria.Configuracion.PalabrasIdioma.Traduccion(75,Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1362, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1746, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1747, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1748, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1749, Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1750, Global.Idioma);
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1751, Global.Idioma);
            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1752, Global.Idioma);
            Label10.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1753, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1753, Global.Idioma);

        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion

    }
}
