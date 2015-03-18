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
    public class PrecioDiferencial : System.Web.UI.Page
    {
        #region Sección de Declaraciones
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblFormTitle;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.LinkButton lbGuardar;
        protected System.Web.UI.WebControls.DropDownList ddlArticulo;
        protected System.Web.UI.WebControls.TextBox txtPrecio;
        protected Libreria.Comercial.PrecioDiferencial _objPrecio = null;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label1;
        protected static bool editar;
        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (lblHide.Text == "")
                if (Request.QueryString["IdLista"] != null)
                    lblHide.Text = Request.QueryString["IdLista"].ToString();

            if (!this.IsPostBack)
                if (ViewState["Control"].ToString() != "1")
                {
                    this.InicializarForma();
                }
        }
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
            this.lbGuardar.Click += new System.EventHandler(this.lbGuardar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Inicialización del Formulario
        private void InicializarForma()
        {
            ViewState["Control"] = "1";
            CargarArticulos();
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma);
            if (Request.QueryString["Cod"] != null && Request.QueryString["Cod"] != "")
                this.lblBack.NavigateUrl =
                    "ListaPrecioDiferencial.aspx?IdLista=" + Request.QueryString["IdLista"];
            else
            {
                if (Request.QueryString["IdPrecio"] != null && Request.QueryString["IdPrecio"] != "")
                {
                    this.lblBack.NavigateUrl =
                        "PreciosDiferenciales.aspx?IdLista=" + Request.QueryString["IdPrecio"];
                }
                else
                {
                    this.lblBack.NavigateUrl =
                        "PreciosDiferenciales.aspx?IdLista=" + Request.QueryString["IdLista"];
                }
            }

            if (Request.QueryString["IdPrecio"] != null && Request.QueryString["IdPrecio"] != "")
                editar = true;
            else
                editar = false;

            if (!editar)
            {
                #region Modo de Inserción
                this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2062, Global.Idioma) + "</b>";
                this.lbGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1118, Global.Idioma);
                #endregion
            }
            else
            {
                #region Modo de Edición
                if (ObtenerObjetoPrecio())
                {
                    this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2063, Global.Idioma) + "</b>";
                    this.ddlArticulo.Enabled = false;
                    this.ddlArticulo.SelectedValue = Request.QueryString["CodigoArticulo"];
                    this.txtPrecio.Text = _objPrecio.PrecioDiferencialArticulo.ToString();
                    this.lbGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                }
                #endregion
            }

        }
        #endregion

        #region ObtenerObjetoPrecio
        private bool ObtenerObjetoPrecio()
        {
            try
            {
                if (Request.QueryString["IdPrecio"] != null)
                    _objPrecio = Libreria.Comercial.PreciosDiferenciales.ObtenerItem(int.Parse(Request.QueryString["IdPrecio"]), int.Parse(Request.QueryString["CodigoArticulo"]));
                else
                    _objPrecio = null;

                if (this._objPrecio == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objPrecio + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objPrecio + "]", true);
                return false;
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
                    if (!editar)
                    {
                        #region Insertar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 315, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objPrecio =
                            new Libreria.Comercial.PrecioDiferencial();
                        this._objPrecio.IdPrecioDiferencial = int.Parse(lblHide.Text);
                        this._objPrecio.CodigoArticulo = int.Parse(ddlArticulo.SelectedValue);
                        this._objPrecio.PrecioDiferencialArticulo = Decimal.Parse(txtPrecio.Text);
                        Libreria.Comercial.PreciosDiferenciales.Adicionar(this._objPrecio);
                        Response.Redirect("PreciosDiferenciales.aspx?IdLista=" + lblHide.Text);
                        #endregion
                    }
                    else
                    {
                        #region Editar
                        if (this.ObtenerObjetoPrecio())
                        {
                            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 316, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                            this._objPrecio.IdPrecioDiferencial = int.Parse(Request.QueryString["IdPrecio"]);
                            this._objPrecio.CodigoArticulo = int.Parse(ddlArticulo.SelectedValue);
                            this._objPrecio.PrecioDiferencialArticulo = Decimal.Parse(txtPrecio.Text);
                            this._objPrecio.Modificar();
                            Response.Redirect("PreciosDiferenciales.aspx?IdLista=" + Request.QueryString["IdPrecio"]);
                        }
                        #endregion
                    }


                }
                catch (Exception ex)
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = ex.Message;
                    return;
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

            if (ddlArticulo.SelectedIndex == 0)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1937, Global.Idioma), false);
                return false;
            }

            if (txtPrecio.Text == "")
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1793, Global.Idioma), false);
                return false;
            }
            else
            {
                try
                {
                    if (Decimal.Parse(txtPrecio.Text) <= 0)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1793, Global.Idioma), false);
                        return false;
                    }
                }
                catch
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1792, Global.Idioma), false);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Cargar Articulos
        private void CargarArticulos()
        {
            try
            {
                ddlArticulo.DataSource = new Libreria.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
                ddlArticulo.DataTextField = "Descripcion";
                ddlArticulo.DataValueField = "IdArticulo";
                ddlArticulo.DataBind();
                ddlArticulo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "0"));
            }
            catch
            {
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma), false);
            }

        }
        #endregion

        #region Boton Guardar
        private void lbGuardar_Click(object sender, System.EventArgs e)
        {
            Guardar();
        }
        #endregion
    }
}
