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
	/// Descripción breve de SelfService.
	/// </summary>
	public class SelfService : System.Web.UI.Page
	{
		#region Declaración de controles
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.LinkButton lbGuardar;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.TextBox txtValor1;
		protected System.Web.UI.WebControls.TextBox txtValor2;
		protected System.Web.UI.WebControls.TextBox txtValor3;
		protected System.Web.UI.WebControls.TextBox txtValor4;
		protected System.Web.UI.WebControls.TextBox txtValor5;
		protected System.Web.UI.WebControls.TextBox txtValor6;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected System.Web.UI.WebControls.LinkButton lkbEliminar;
		protected Libreria.Configuracion.Selfservice _objSelfservice = null;
		protected System.Web.UI.WebControls.TextBox txtPuertoLecturaFidelizacion;
		private bool permitir = false;
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
			Libreria.Configuracion.Selfservices objSelfService = new Servipunto.Estacion.Libreria.Configuracion.Selfservices();
			try
			{
				if (objSelfService != null)
				{
					if(objSelfService.Count > 0)
					{ 
						this._mode = WebApplication.FormMode.Edit;
						this.Session["IdSelfservice"] = objSelfService[0].IdSelfservice;
					}
					else
						this._mode = WebApplication.FormMode.New;

                    if (!this.IsPostBack)
                    {
                        this.InicializarForma();
                        Traduccir();
                    }
                    else
                        if (Request.Form["AcceptButton"] != null)
                            this.Guardar();	
					
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

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Selfservice";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");
			
			if (permitir == true)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}			
			return true;
		}

		#endregion

		#region ObtenerObjetoSelfservice
		private bool ObtenerObjetoSelfservice()
		{
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,158, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this._objSelfservice = Libreria.Configuracion.Selfservices.ObtenerItem(Convert.ToInt32(Session["IdSelfservice"].ToString()));
				if (this._objSelfservice == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objSelfservice + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objSelfservice + "]", true);
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
                    this.lblBack.NavigateUrl = "SelfServices.aspx";
					this.lblFormTitle.Text = "<b>SelfService</b>";
					try
					{

						Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene = new Servipunto.Estacion.Libreria.Configuracion.Dat_Gene();
						objDat_Gene = Servipunto.Estacion.Libreria.Configuracion.Datos_Gene.ObtenerItem();
						txtPuertoLecturaFidelizacion.Enabled = objDat_Gene.EDSFideliza;
					}
					catch(Exception)
					{
                        throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1786, Global.Idioma));
						
					}

					//txtPuertoLecturaFidelizacion
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.AcceptButton.Value =  Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma) ;
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoSelfservice())
						{
							//Visualización de Datos	
							this.txtCodigo.Text = this._objSelfservice.IdSelfservice.ToString();
							this.txtValor1.Text = this._objSelfservice.ValorBoton1.ToString();
							this.txtValor2.Text = this._objSelfservice.ValorBoton2.ToString();
							this.txtValor3.Text = this._objSelfservice.ValorBoton3.ToString();
							this.txtValor4.Text = this._objSelfservice.ValorBoton4.ToString();
							this.txtValor5.Text = this._objSelfservice.ValorBoton5.ToString();
							this.txtValor6.Text = this._objSelfservice.ValorBoton6.ToString();
							this.txtPuertoLecturaFidelizacion.Text = this._objSelfservice.PuertoLectorFidelizacion.Trim();
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma) ;
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,159, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objSelfservice = new Libreria.Configuracion.Selfservice();

						if (this.txtCodigo.Text.Trim().Length != 0) 
						{
							_objSelfservice.IdSelfservice = Convert.ToInt32(txtCodigo.Text.Trim());
						}

						this._objSelfservice.ValorBoton1 = Convert.ToDecimal(this.txtValor1.Text.Trim());
						this._objSelfservice.ValorBoton2 = Convert.ToDecimal(this.txtValor2.Text.Trim());
						this._objSelfservice.ValorBoton3 = Convert.ToDecimal(this.txtValor3.Text.Trim());
						this._objSelfservice.ValorBoton4 = Convert.ToDecimal(this.txtValor4.Text.Trim());
						this._objSelfservice.ValorBoton5 = Convert.ToDecimal(this.txtValor5.Text.Trim());
						this._objSelfservice.ValorBoton6 = Convert.ToDecimal(this.txtValor6.Text.Trim());
						this._objSelfservice.PuertoLectorFidelizacion = this.txtPuertoLecturaFidelizacion.Text.Trim();

						this._objSelfservice.CaraBoton1 = (short)1;
						this._objSelfservice.CaraBoton2 = (short)2;
						this._objSelfservice.CaraBoton3 = (short)3;
						this._objSelfservice.CaraBoton4 = (short)4;
						this._objSelfservice.CaraBoton5 = (short)5;
						this._objSelfservice.CaraBoton6 = (short)6;
						this._objSelfservice.CaraBoton7 = (short)7;
						this._objSelfservice.CaraBoton8 = (short)8;
						this._objSelfservice.CaraBoton9 = (short)9;
						this._objSelfservice.CaraBoton10 = (short)10;
						this._objSelfservice.CaraBoton11 = (short)11;
						this._objSelfservice.CaraBoton12 = (short)12;
						
                        					
						
						Libreria.Configuracion.Selfservices.Adicionar(this._objSelfservice);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoSelfservice())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,160, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objSelfservice.ValorBoton1 = Convert.ToDecimal(this.txtValor1.Text.Trim());
							this._objSelfservice.ValorBoton2 = Convert.ToDecimal(this.txtValor2.Text.Trim());
							this._objSelfservice.ValorBoton3 = Convert.ToDecimal(this.txtValor3.Text.Trim());
							this._objSelfservice.ValorBoton4 = Convert.ToDecimal(this.txtValor4.Text.Trim());
							this._objSelfservice.ValorBoton5 = Convert.ToDecimal(this.txtValor5.Text.Trim());
							this._objSelfservice.ValorBoton6 = Convert.ToDecimal(this.txtValor6.Text.Trim());
							this._objSelfservice.PuertoLectorFidelizacion = this.txtPuertoLecturaFidelizacion.Text.Trim();

							this._objSelfservice.Modificar();
						}
						#endregion
					}
					Response.Redirect("SelfServices.aspx");
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
					this._objSelfservice = null;
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
			if (this.txtValor1.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 1 " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
				return false;
			}
			if (this.txtValor2.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 2 " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
				return false;
			}
			if (this.txtValor3.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 3 " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
				return false;
			}
			if (this.txtValor4.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 4 " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
				return false;
			}
			if (this.txtValor5.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 5 " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
				return false;
			}
			if (this.txtValor6.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 6 " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
				return false;
			}
			return true;
		}
		#endregion

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.lkbEliminar.Click += new System.EventHandler(this.lkbEliminar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Evento Eliminar
		private void lkbEliminar_Click(object sender, System.EventArgs e)
		{
			try
			{
				permitir = true;
				if (this.VerificarPermisos())
				{
					Libreria.Configuracion.Selfservices.Eliminar(Convert.ToInt32(this.Session["IdSelfservice"].ToString()));
					Response.Redirect("Default.aspx");
				}

			}
			catch (Exception ex)
			{
				this.lblError.Text = this.lblError.Text + ex.Message + " <br>";

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

        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 1";
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 2";
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 3";
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 4";
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 5";
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma) + " 6";
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1530, Global.Idioma) ;
            lkbEliminar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(775, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            
        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
    }
}
