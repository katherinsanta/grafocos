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

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	/// <summary>
	/// Formulario encargado de administrar la configuración de estructuras dinamicas para la generación de archivos planos
	/// Autor:			Ing. Elvis Astaiza Gutierrez
	/// Fecha Creacion:	11/07/2008 09:00 AM		
	/// </summary>
	public class EstructuraPlano : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.ListBox lstIncluidos;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnQuitar;
		protected System.Web.UI.WebControls.ListBox lstNoIncluidos;
		protected System.Web.UI.WebControls.DropDownList ddlTamaño;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtSeparadorColumnas;
		protected System.Web.UI.WebControls.TextBox txtSeparadorDecimales;
		protected System.Web.UI.WebControls.Button btnBajar;
		protected System.Web.UI.WebControls.Button btnSubir;
		protected System.Web.UI.WebControls.RadioButtonList rbAnchoFijo;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtNombreArchivo;
		protected System.Web.UI.WebControls.RadioButtonList rbDireccionRelleno;
		protected System.Web.UI.WebControls.TextBox txtCaracterRelleno;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnAplicarRelleno;
		protected System.Web.UI.WebControls.DropDownList ddlArchivo;
		protected System.Web.UI.WebControls.Button btnRestablecerPorDefecto;
		protected System.Web.UI.WebControls.LinkButton lblGuardar;
		protected System.Web.UI.WebControls.Button btnReporte;
		protected System.Web.UI.WebControls.Button btnAplicarValor;
		protected System.Web.UI.WebControls.TextBox txtValor;
		protected System.Web.UI.WebControls.Label lblValor;
		protected System.Web.UI.WebControls.Panel pnlValor;
		protected System.Web.UI.WebControls.Button btnAplicarParametro;
		protected System.Web.UI.WebControls.TextBox txtParametro;
		protected System.Web.UI.WebControls.DropDownList ddlParametro;
		protected System.Web.UI.WebControls.Label lblParametro;
		protected System.Web.UI.WebControls.Panel pnlParametros;
		protected System.Web.UI.WebControls.TextBox txtIdAnchoFijo;
		protected System.Web.UI.WebControls.TextBox txtIdSeparadorColumnas;
		protected System.Web.UI.WebControls.TextBox txtIdSeparadorDecimales;
		protected System.Web.UI.WebControls.TextBox txtIdFecha;
		protected System.Web.UI.WebControls.TextBox txtIdNombreArchivo;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.Label Label12;
        protected System.Web.UI.WebControls.Label Label13;
        protected System.Web.UI.WebControls.Label Label14;
        protected System.Web.UI.WebControls.Panel pnlForm;
        char _separadorVisual = '|';




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
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				//this.SmartNavigation = true;
				//Page.MaintainScrollPositionOnPostBack = true;				
				lblError.Text = "";					
				if (!this.IsPostBack)
				{
                    if (ViewState["Control"].ToString() != "1")
                    {
                        this.InicializarForma();
                        Traduccir();
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 566, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
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
			this.ddlArchivo.SelectedIndexChanged += new System.EventHandler(this.ddlArchivo_SelectedIndexChanged);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
			this.lstIncluidos.SelectedIndexChanged += new System.EventHandler(this.lstIncluidos_SelectedIndexChanged);
			this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
			this.btnBajar.Click += new System.EventHandler(this.btnBajar_Click);
			this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
			this.ddlParametro.SelectedIndexChanged += new System.EventHandler(this.ddlParametro_SelectedIndexChanged);
			this.txtParametro.TextChanged += new System.EventHandler(this.txtParametro_TextChanged);
			this.ddlTamaño.SelectedIndexChanged += new System.EventHandler(this.ddlTamaño_SelectedIndexChanged);
			this.rbDireccionRelleno.SelectedIndexChanged += new System.EventHandler(this.rbDireccionRelleno_SelectedIndexChanged);
			this.txtCaracterRelleno.TextChanged += new System.EventHandler(this.txtCaracterRelleno_TextChanged);
			this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
			this.btnRestablecerPorDefecto.Click += new System.EventHandler(this.btnRestablecerPorDefecto_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Interfaz Contable";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion,"Configuracion Interfaz Contable");

			if(!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}
			return true;
		}
		#endregion
		
		#region Inicialización del Formulario
		private void InicializarForma()
		{						
			if (this.VerificarPermisos())
			{
                RadioButtonTraduccion();
				lblError.Visible = true;
				this.lblBack.NavigateUrl = "Default.aspx";
				this.CargarConfiguracion();
			}
		}
		#endregion

		#region Cargar registros

		#region CargarConfiguracion
		private void CargarConfiguracion()
		{
			#region declarar variables
			DataSet ds;
			#endregion

			#region cargar registro columnas
			lstIncluidos.Items.Clear();
			lstNoIncluidos.Items.Clear();
			ds = Libreria.UtilidadesGenerales.RecuperarEstructuraPlano(0,"","Columna",ddlArchivo.SelectedValue);
			if(ds.Tables[0].Rows.Count > 0)
			{				
				for(int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					if(ds.Tables[0].Rows[i][2].ToString()=="0") //carga las no incluidas
						lstNoIncluidos.Items.Add(new ListItem(
							ds.Tables[0].Rows[i][5].ToString() //tamaño
							+ _separadorVisual
							+ (ds.Tables[0].Rows[i][11].ToString() == "1"?"<":">") //direccion relleno
							+ _separadorVisual
							+ Convert.ToChar((Int16)(ds.Tables[0].Rows[i][10])) //caracter de relleno
							+ _separadorVisual
							+ ds.Tables[0].Rows[i][1].ToString() //descripcion							
							+ _separadorVisual
							+ ds.Tables[0].Rows[i][12].ToString() //descripcion							

							,ds.Tables[0].Rows[i][0].ToString())
							);
					else //carga las incluidas
						lstIncluidos.Items.Add(new ListItem(
							ds.Tables[0].Rows[i][5].ToString() //tamaño
							+ _separadorVisual
							+ (ds.Tables[0].Rows[i][11].ToString() == "1"?"<":">") //direccion relleno
							+ _separadorVisual
							+ Convert.ToChar((Int16)ds.Tables[0].Rows[i][10]) //caracter de relleno
							+ _separadorVisual
							+ ds.Tables[0].Rows[i][1].ToString() //descripcion
							+ _separadorVisual
							+ ds.Tables[0].Rows[i][12].ToString() //descripcion							

							,ds.Tables[0].Rows[i][0].ToString()));

				}
				if(lstIncluidos.Items.Count >= 0)
				{
					lstIncluidos.SelectedIndex = 0;
					CargarRegistro();
				}

				if(lstNoIncluidos.Items.Count >= 0)
					lstNoIncluidos.SelectedIndex = -1;
			}
			#endregion

			#region carga el resto de configuraciones
			if(ds.Tables.Count > 5)
			{
				//carga ancho			
				if(ds.Tables[1].Rows.Count >= 0)
				{
					txtIdAnchoFijo.Text = ds.Tables[1].Rows[0][0].ToString();
					rbAnchoFijo.SelectedValue = ds.Tables[1].Rows[0][1].ToString();											
				}
			
				//carga separador			
				if(ds.Tables[2].Rows.Count >= 0)				
				{
					txtIdSeparadorColumnas.Text = ds.Tables[2].Rows[0][0].ToString();
					txtSeparadorColumnas.Text = ds.Tables[2].Rows[0][1].ToString();			
				}
			
				//carga separador decimales
				if(ds.Tables[3].Rows.Count >= 0)
				{
					txtIdSeparadorDecimales.Text = ds.Tables[3].Rows[0][0].ToString();
					txtSeparadorDecimales.Text = ds.Tables[3].Rows[0][1].ToString();			
				}

				//carga fecha
				if(ds.Tables[4].Rows.Count >= 0)
				{
					txtIdFecha.Text = ds.Tables[4].Rows[0][0].ToString();
					txtFecha.Text = ds.Tables[4].Rows[0][1].ToString();			
				}

				//carga nombre archivo
				if(ds.Tables[5].Rows.Count >= 0)
				{
					txtIdNombreArchivo.Text = ds.Tables[5].Rows[0][0].ToString();
					txtNombreArchivo.Text = ds.Tables[5].Rows[0][1].ToString();			
				}
			}
			ds = null;
			#endregion
			
		}
		#endregion 

		#region CargarParametrosAdicionales
		/// Modificacion: Se adicionaron controles para el manejo de campos con valores por defecto
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  27/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez		
		private void CargarParametrosAdicionales()
		{
			string [] arreglo;
			string [] parametros;
			string [] valores;				
			arreglo = lstIncluidos.Items[lstIncluidos.SelectedIndex].Text.Split(_separadorVisual);	
			//carga el valor por defecto o los valores adicionales si los contiene
			if(arreglo[4].Length > 0) 
			{					
				if((arreglo[4].IndexOf(';') > 0 && arreglo[4].IndexOf('=') > 0) || (arreglo[4].IndexOf(';') < 0 && arreglo[4].IndexOf('=') > 0)) //contiene parametros
				{
					lblParametro.Text = arreglo[3] + ":";
					ddlParametro.Items.Clear();
					pnlParametros.Visible = true;
					parametros = arreglo[4].Split(';');
					for(int i=0; i<parametros.Length; i++)
					{
						valores = null;
						valores = parametros[i].Split('=');
						ddlParametro.Items.Add(new ListItem(valores[0],valores[1]));
					}
					txtParametro.Text = ddlParametro.SelectedValue.ToString();
				}
				else //contiene un valor normal
				{
					lblValor.Text = arreglo[3] + ":";
					pnlValor.Visible = true;
					txtValor.Text = arreglo[4];
				}
			}
				
		}
		#endregion

		#region CargarRegistro
		private void CargarRegistro()
		{

			#region declarar variables
			DataSet ds;
			#endregion

			#region cargar registro columnas
			try
			{
				string [] arreglo;
				if(!(lstIncluidos.SelectedIndex >= 0))
					return;
				ds = Libreria.UtilidadesGenerales.RecuperarEstructuraPlano(int.Parse(lstIncluidos.Items[lstIncluidos.SelectedIndex].Value),"","Columna",ddlArchivo.SelectedValue);
				if(ds.Tables[0].Rows.Count == 0)
					return;
				ddlTamaño.Items.Clear();
				pnlParametros.Visible = false;
				pnlValor.Visible = false;
				for(int i=(Int16)(ds.Tables[0].Rows[0][3]); i<=(Int16)(ds.Tables[0].Rows[0][4]); i++)
				{
					ddlTamaño.Items.Add(i.ToString());
				}
				arreglo = lstIncluidos.Items[lstIncluidos.SelectedIndex].Text.Split(_separadorVisual);	
				ddlTamaño.SelectedValue = arreglo[0].Trim();
				rbDireccionRelleno.SelectedValue = arreglo[1].Trim();
				txtCaracterRelleno.Text = arreglo[2];
				this.CargarParametrosAdicionales();
				
			}
			catch(Exception ex)
			{

                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma), true);
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

			#endregion

		}
		#endregion

		#region RefrescarFila
		/// Modificacion: Se adicionaron controles para el manejo de campos con valores por defecto
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  27/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez		
		private void RefrescarFila()
		{
			string fila="";
			if(!(lstIncluidos.SelectedIndex >= 0))
				return;
			string [] arreglo;
			try
			{
				int seleccionado = lstIncluidos.SelectedIndex;
				arreglo = lstIncluidos.Items[seleccionado].Text.Split(_separadorVisual);			
				fila = ddlTamaño.SelectedValue
					+ _separadorVisual
					+ rbDireccionRelleno.SelectedValue
					+ _separadorVisual
					+ (txtCaracterRelleno.Text.Length == 0?" ":txtCaracterRelleno.Text)
					+ _separadorVisual
					+ arreglo[3]
					+ _separadorVisual
					;
				//+ arreglo[4]
				
				if(pnlValor.Visible)
				{
					if(txtValor.Text.Length == 0)
						throw new Exception("Digite un valor valido para el parametro: " + lblValor.Text);
					fila += txtValor.Text;
				}
				else if(pnlParametros.Visible)
				{
					if(txtParametro.Text.Length == 0)
						throw new Exception("Digite un valor valido para el parametro: " + ddlParametro.SelectedItem);
					fila += arreglo[4].Replace(ddlParametro.SelectedItem.ToString() + "=" + ddlParametro.SelectedValue,ddlParametro.SelectedItem.ToString() + "=" + txtParametro.Text);
				}
				lstIncluidos.Items[seleccionado].Text = fila;
				//para refrescar el cambio de la lista de parametros
				this.CargarParametrosAdicionales();
			}
			catch(Exception ex)
			{
				this.SetError(ex.Message,false);
			}

		}
		#endregion

		#endregion
		
		#region Validar
		private bool Validar()
		{
/*			this.ClearError();
			if (this.txtDescripcion.Text.Trim().Length == 0)
			{
				this.SetError("La descripción no puede ser una cadena vacía!", false);
				return false;
			}
*/
			return true;
		}
		#endregion

		#region ActualizarRegistros o Restablecer

		#region ActualizarRegistros
		private void ActualizarRegistros()
		{
			#region Declaracion de variables		
			string [] arreglo;
			char [] relleno;
			#endregion

			try
			{
				#region guarda las listas de columnas
				//actualiza los no incluidos
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,567, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				for(Int16 i=0; i<lstNoIncluidos.Items.Count; i++) 
				{
					arreglo = lstNoIncluidos.Items[i].Text.Split(_separadorVisual);
					relleno = arreglo[2].ToCharArray();
					Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(int.Parse(lstNoIncluidos.Items[i].Value)
																				,0
																				,Int16.Parse(arreglo[0].ToString().Trim())
																				,(Int16)(relleno[0])
																				,(arreglo[1].ToString().Trim()=="<"?(Int16)1:(Int16)2)																				
																				,arreglo[4]
																				);
				}
				//actualiza los incluidos
				for(Int16 i=0; i<lstIncluidos.Items.Count; i++) 
				{
					arreglo = lstIncluidos.Items[i].Text.Split(_separadorVisual);
					relleno = arreglo[2].ToCharArray();
					Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(int.Parse(lstIncluidos.Items[i].Value)
																				,(Int16)(i + 1)
																				,Int16.Parse(arreglo[0].ToString().Trim())
																				,(Int16)(relleno[0])
																				,(arreglo[1].ToString().Trim()=="<"?(Int16)1:(Int16)2)																										
																				,arreglo[4]
																				);
 				}
				#endregion

				#region guarda los otros regiostros
				//ancho fijo
				Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(int.Parse(txtIdAnchoFijo.Text.Trim()),rbAnchoFijo.SelectedValue);
				//separador
				Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(int.Parse(txtIdSeparadorColumnas.Text.Trim()),txtSeparadorColumnas.Text.Trim());
				//decimales
				Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(int.Parse(txtIdSeparadorDecimales.Text.Trim()),txtSeparadorDecimales.Text.Trim());
				//fecha
				Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(int.Parse(txtIdFecha.Text.Trim()),txtFecha.Text.Trim());
				//nombre
				Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(int.Parse(txtIdNombreArchivo.Text.Trim()),txtNombreArchivo.Text.Trim());
				#endregion

				Response.Redirect("Default.aspx");

			}catch (Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma), true);
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

		#region Restablecer por defecto
		private void RestablecerPorDefecto()
		{
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,568, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				Libreria.UtilidadesGenerales.ActualizarEstructuraPlano(-1,ddlArchivo.SelectedValue);
				lstNoIncluidos.Items.Clear();
				lstIncluidos.Items.Clear();
				this.CargarConfiguracion();
			}
			catch (Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma), true);
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

		#region Eventos de los controles del formulario

		private void lblGuardar_Click(object sender, System.EventArgs e)
		{
			ActualizarRegistros();
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			Libreria.UtilidadesGenerales.ListBoxDesplazarHorizontal(lstNoIncluidos,lstIncluidos);
		}

		private void btnQuitar_Click(object sender, System.EventArgs e)
		{
			Libreria.UtilidadesGenerales.ListBoxDesplazarHorizontal(lstIncluidos,lstNoIncluidos);
		}

		private void btnSubir_Click(object sender, System.EventArgs e)
		{
			Libreria.UtilidadesGenerales.ListBoxDesplazarVertical(lstIncluidos,-1);
		}

		private void btnBajar_Click(object sender, System.EventArgs e)
		{
			Libreria.UtilidadesGenerales.ListBoxDesplazarVertical(lstIncluidos,1);
		}

		private void lstIncluidos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarRegistro();					
		}

		private void rbDireccionRelleno_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RefrescarFila();
		}

		private void txtCaracterRelleno_TextChanged(object sender, System.EventArgs e)
		{
			RefrescarFila();
		}

		private void ddlTamaño_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RefrescarFila();
		}

		private void btnRestablecerPorDefecto_Click(object sender, System.EventArgs e)
		{
			RestablecerPorDefecto();
		}


		private void btnReporte_Click(object sender, System.EventArgs e)
		{
			try
			{

				//Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,346, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				DataDynamics.ActiveReports.ActiveReport report = null;
				report = new Servipunto.Estacion.Web.Modules.Rpt.EstructuraPlano(ddlArchivo.SelectedValue,ddlArchivo.SelectedItem.Text);
				Session["Formato"] = "pdf";
				Session.Add("LastReport", report);					
				Response.Redirect("../Visor/PDF.aspx",false);
			}
			catch (Exception ex)
			{
				this.SetError(ex.Message,false);
				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el reporte de Estructura de planos. ");
				}
				catch(Exception exx)
				{
					lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					this.SetError(lblError.Text,false);

				}
				#endregion
			}


		}


		#endregion

		private void ddlArchivo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.CargarConfiguracion();
		}

		private void ddlParametro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtParametro.Text = ddlParametro.SelectedValue.ToString();
		}

		private void txtParametro_TextChanged(object sender, System.EventArgs e)
		{
			RefrescarFila();
		}

		private void txtValor_TextChanged(object sender, System.EventArgs e)
		{
			RefrescarFila();
		}

        private void Traduccir()
        {
            lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1590, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1592, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1591, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1597, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1593, Global.Idioma) + "|" +
                          Libreria.Configuracion.PalabrasIdioma.Traduccion(1594, Global.Idioma) + "|" +
                          Libreria.Configuracion.PalabrasIdioma.Traduccion(1595, Global.Idioma) + "|" +
                          Libreria.Configuracion.PalabrasIdioma.Traduccion(1596, Global.Idioma);

            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1593, Global.Idioma) + "|" +
                          Libreria.Configuracion.PalabrasIdioma.Traduccion(1594, Global.Idioma) + "|" +
                          Libreria.Configuracion.PalabrasIdioma.Traduccion(1595, Global.Idioma) + "|" +
                          Libreria.Configuracion.PalabrasIdioma.Traduccion(1596, Global.Idioma);

            lblValor.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma);
            lblParametro.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1529, Global.Idioma);
            btnAplicarValor.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1609, Global.Idioma);
            btnAplicarParametro.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1609, Global.Idioma);
            btnAplicarRelleno.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1609, Global.Idioma);
            btnSubir.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1598, Global.Idioma);
            btnBajar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1599, Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1600, Global.Idioma);
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1608, Global.Idioma);
            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1601, Global.Idioma);
            rbAnchoFijo.Items[0].Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            rbAnchoFijo.Items[1].Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1731, Global.Idioma);

            rbDireccionRelleno.Items[0].Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1735, Global.Idioma);
            rbDireccionRelleno.Items[1].Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1736, Global.Idioma);

            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1601, Global.Idioma);
            Label10.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1608, Global.Idioma);
            Label11.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1604, Global.Idioma);
            Label12.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1610, Global.Idioma);
            Label13.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1605, Global.Idioma);
            Label14.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1611, Global.Idioma);
            btnReporte.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1606, Global.Idioma);
            btnRestablecerPorDefecto.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1612, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
            lblGuardar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            Label1.Text = "(*) :" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1732, Global.Idioma) + " 'DD' = " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma) + ",'MM' = " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma) + ",'YYYY','YY' = " + Libreria.Configuracion.PalabrasIdioma.Traduccion(415, Global.Idioma) + ", 'HH' =" + Libreria.Configuracion.PalabrasIdioma.Traduccion(203, Global.Idioma) + ", 'mm' = " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1733, Global.Idioma) + ", 'SS' = " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1734, Global.Idioma);
        }
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlArchivo
            this.ddlArchivo.Items.Clear();
            this.ddlArchivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2375, Global.Idioma), "FacturaEstandar"));
            this.ddlArchivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2376, Global.Idioma), "Inventarios"));
            this.ddlArchivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2377, Global.Idioma), "Lecturas"));
            //this.ddlArchivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2378, Global.Idioma), "SysconVentas"));
            this.ddlArchivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2379, Global.Idioma), "Insepec"));
            this.ddlArchivo.SelectedValue = "FacturaEstandar";
            this.ddlArchivo.Items.Insert(0, new ListItem("AS400","AS400Ventas"));
            this.ddlArchivo.Items.Insert(0, new ListItem("Ventas Syscon", "SyscomVentas"));
            this.ddlArchivo.Items.Insert(0, new ListItem("Lecturas Syscon", "SyscomLecturas"));
            #endregion            
        }
        #endregion
        protected void rbDireccionRelleno_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

	}
}
