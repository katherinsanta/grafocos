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
	/// <summary>
	/// Descripción breve de Clientes.
	/// </summary>
	public class Clientes : System.Web.UI.Page
	{
		#region Declaraciones
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
		protected System.Web.UI.WebControls.Label lblTituloGenerales;
		protected System.Web.UI.WebControls.LinkButton btnBuscar;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.WebControls.TextBox txtBuscar2;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.RadioButtonList rbtOrden;
		protected System.Web.UI.WebControls.DropDownList ddlCriterioBusqueda;
		protected System.Web.UI.WebControls.DropDownList ddlRegistrosPorPagina;
		protected System.Web.UI.WebControls.DropDownList ddlNumeroPagina;
        protected System.Web.UI.WebControls.DropDownList ddlTipoAutorizacion;
		protected System.Web.UI.WebControls.LinkButton lblanterior;
		protected System.Web.UI.WebControls.LinkButton lblSiguiente;
		protected System.Web.UI.WebControls.Label lblTotalPaginas;
		protected System.Web.UI.WebControls.CheckBox cbxContenga;
		protected System.Web.UI.WebControls.Repeater Results;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        
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
			lblError.Visible = false;
            
			if (!this.Page.IsPostBack) 
			{
				if (this.VerificarPermisos())
                {
                    if (ViewState["Control"].ToString() != "1")
                    {
                       // CargarTipoAutorizacionExterna();
                        this.Visualizar();
                    }
				}
			}
            else
            {
                this.Eliminar();
            }
			
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
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1007, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1659, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1660, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1654, Global.Idioma);

            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(281, Global.Idioma);
            btnBuscar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(974, Global.Idioma);

            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1653, Global.Idioma);
            cbxContenga.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1658, Global.Idioma);
            
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, 1);
        }
        #endregion    

        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  rbtOrden
            this.rbtOrden.Items.Clear();
            this.rbtOrden.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma), "1"));
            this.rbtOrden.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Global.Idioma), "2"));
            this.rbtOrden.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.rbtOrden.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlCriterioBusqueda
            this.ddlCriterioBusqueda.Items.Clear();
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma), "1"));
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(265, Global.Idioma), "2"));
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma), "3"));
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1124, Global.Idioma), "4"));
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Global.Idioma), "5"));
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(683, Global.Idioma), "6"));
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma), "7"));
            this.ddlCriterioBusqueda.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1499, Global.Idioma), "8"));            
            this.ddlCriterioBusqueda.SelectedValue = "2";
            #endregion
           
        }
        #endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Comerciales";
			const string opcion = "Clientes";
			bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
			bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
			bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			//Revisión de permiso de consulta
			if (!consultar)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}

			//Configuración de Acciones
			string htmlAcciones = "";
			if (nuevo)
                this.AgregarAccion(ref htmlAcciones, "Cliente.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1661, Global.Idioma));
			if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1684, Global.Idioma));

			if(Request.QueryString["IdCliente"] != null || Request.QueryString["IdCliente"] != "")
                this.AgregarAccion(ref htmlAcciones, "default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
			
			this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

			//Configuración del permiso de modificación
			if (modificar)
				this.HiddenUpdate.Value = "Allow";
			else
				this.HiddenUpdate.Value = "Deny";

			return true;
		}

		private void AgregarAccion(ref string currentHtml, string hRef, string title)
		{
			currentHtml += currentHtml.Length==0?"":"&nbsp;|&nbsp;";
			currentHtml += "<a  href='" + hRef + "'>" + title + "</a>";
		}
		#endregion

		#region Visualizar
		private void Visualizar()
		{
			try
			{
                RadioButtonTraduccion();
				//Refresca la ultima pantalla de busqueda
				if(Session["BuscarCliente"] != null)
				{
					string [] parametrosBusqueda;
					string [] DatoBusqueda;
					int totalPaginas;
					parametrosBusqueda = Session["BuscarCliente"].ToString().Split("|".ToCharArray()); 
					ddlCriterioBusqueda.SelectedValue = parametrosBusqueda[0].ToString();
					txtBuscar.Text = parametrosBusqueda[1].ToString();
					
					DatoBusqueda = parametrosBusqueda[1].ToString().Split("%".ToCharArray());
					if(DatoBusqueda.Length>1)
					{
						txtBuscar2.Text = DatoBusqueda[1].ToString();
						cbxContenga.Checked = true;
					}
					else
						DatoBusqueda[0].ToString();

					totalPaginas = int.Parse(parametrosBusqueda[6].ToString());
					for(int i=0; i<totalPaginas; i++) 
					{
						if(i==0)
							ddlNumeroPagina.Items.Clear();
						ddlNumeroPagina.Items.Add(Convert.ToString(i+1));
					}
					ddlNumeroPagina.SelectedValue = Convert.ToString(int.Parse(parametrosBusqueda[2].ToString())+1);					
					ddlRegistrosPorPagina.SelectedValue = parametrosBusqueda[3].ToString();
					rbtOrden.SelectedValue = parametrosBusqueda[5].ToString();
					this.Buscar();
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

		#region Eliminar
		private void Eliminar()
		{
			if (Request.Form["chkID"] != null)
			{
				int i;
				string [] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,285, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0; i <= aSelectedItems.Length-1; i++) 
				{
					try
					{
						Libreria.Comercial.Clientes.Eliminar(aSelectedItems[i]);
                        break;
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
				this.Visualizar();
				this.Buscar();
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
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			this.ddlNumeroPagina.SelectedIndexChanged += new System.EventHandler(this.ddlNumeroPagina_SelectedIndexChanged);
			this.lblanterior.Click += new System.EventHandler(this.lblanterior_Click);
			this.lblSiguiente.Click += new System.EventHandler(this.lblSiguiente_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Evento del DropDownList
		private void ddlFiltro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.VerificarPermisos())
				this.Visualizar();
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

                            
        #region Buscar
		private void Buscar()
		{
		
			int RegistrosPorPagina = int.Parse(ddlRegistrosPorPagina.SelectedValue);;
			//Realiza la consulta
			DataSet ds;
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,282, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				ds = Libreria.Comercial.Clientes.ObtenerItems(int.Parse(ddlCriterioBusqueda.SelectedValue),txtBuscar.Text,(int.Parse(ddlNumeroPagina.SelectedValue))-1,RegistrosPorPagina,2,int.Parse(rbtOrden.SelectedValue));				
				if(ds.Tables[0].Rows.Count == 0)
                    SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1989, Global.Idioma), false);
				Results.DataSource = ds.Tables[0];
				Results.DataBind();
				Session["BuscarCliente"]= ddlCriterioBusqueda.SelectedValue + "|" + txtBuscar.Text + "|" + Convert.ToString((int.Parse(ddlNumeroPagina.SelectedValue))-1) + "|" + RegistrosPorPagina + "|" + "2" + "|" + rbtOrden.SelectedValue + "|" + ddlNumeroPagina.Items.Count.ToString();
                if (ddlCriterioBusqueda.SelectedValue == "7")
                    Session["BuscarPlaca"] = txtBuscar.Text;
                else
                    Session["BuscarPlaca"] = null;


			}
			catch(Exception)
			{
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1990, Global.Idioma), false);
			}
			lblTotalPaginas.Text = ddlNumeroPagina.SelectedValue + "/" + ddlNumeroPagina.Items.Count.ToString();

        }

        #region
        private void CargarTipoAutorizacionExterna()
        {
            try
            {
                Libreria.TiposAutorizacionExterna objTipoAutorizanExterna = new Libreria.TiposAutorizacionExterna();
                
                this.ddlTipoAutorizacion.DataTextField = "TipoAutorizacion";
                this.ddlTipoAutorizacion.DataValueField = "IdTipoAutorizacion";
                this.ddlTipoAutorizacion.DataSource = objTipoAutorizanExterna;
                this.ddlTipoAutorizacion.DataBind();

            }
            catch (Exception ex)
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
            }
        }
        #endregion


        private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			int TotalRegistros;
			int RegistrosPorPagina;
			int totalPaginas;
			try
			{
				if(cbxContenga.Checked)
					txtBuscar.Text = "%" + txtBuscar2.Text.Trim();
				else
					txtBuscar.Text = txtBuscar2.Text.Trim();
				//crea el paginado
				RegistrosPorPagina = int.Parse(ddlRegistrosPorPagina.SelectedValue);
				DataSet ds = Libreria.Comercial.Clientes.ObtenerItems(int.Parse(ddlCriterioBusqueda.SelectedValue),txtBuscar.Text,0,5,1,0);
				TotalRegistros = int.Parse(ds.Tables[0].Rows[0][0].ToString());
				totalPaginas = TotalRegistros/RegistrosPorPagina;
				if(TotalRegistros%RegistrosPorPagina > 0)
					totalPaginas = totalPaginas + 1;
				ddlNumeroPagina.Items.Clear();
				ddlNumeroPagina.Items.Add("1");
				for(int i=0; i<totalPaginas; i++) 
				{	if(i==0)
						ddlNumeroPagina.Items.Clear();
					ddlNumeroPagina.Items.Add(Convert.ToString(i+1));
				}
				this.Buscar();
			}
			catch(Exception)
			{
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1991, Global.Idioma), false);
			}


		}

		private void ddlNumeroPagina_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.Buscar();
		}

		private void lblSiguiente_Click(object sender, System.EventArgs e)
		{
			int indicePagina;
			if(ddlNumeroPagina.Items.Count == 1)
				return;
			indicePagina = ddlNumeroPagina.SelectedIndex + 1;
			if(indicePagina >= ddlNumeroPagina.Items.Count)
				ddlNumeroPagina.SelectedIndex = 0;
			else
				ddlNumeroPagina.SelectedIndex = indicePagina;
			this.Buscar();

		}
		private void lblanterior_Click(object sender, System.EventArgs e)
		{
			int indicePagina;
			if(ddlNumeroPagina.Items.Count == 1)
				return;
			indicePagina = ddlNumeroPagina.SelectedIndex - 1;
			if(indicePagina < 0)
				ddlNumeroPagina.SelectedIndex = ddlNumeroPagina.Items.Count-1;
			else
				ddlNumeroPagina.SelectedIndex = indicePagina;
			this.Buscar();		
		}


		#endregion

	}
}
