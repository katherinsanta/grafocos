using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
    public partial class Conductor : System.Web.UI.Page
    {
        #region Sección de Declaraciones
       
        protected Libreria.Configuracion.Conductor _objConductor = null;
        protected static bool editar;
        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if  (Request.QueryString["IdConductor"] != null && lblHide.Text == "")
                lblHide.Text = Request.QueryString["IdConductor"].ToString();

            if (!this.IsPostBack)
                this.InicializarForma();
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
            this.lblBack.NavigateUrl = "Conductores.aspx";


            if (lblHide.Text != "")
                editar = true;
            else
                editar = false;

            if (!editar)
            {
                #region Modo de Inserción
                this.lblFormTitle.Text = "<b>Asignar Nuevo Conductor</b>";
                this.lbGuardar.Text = "Crear";
                #endregion
            }
            else
            {
                #region Modo de Edición
                if (ObtenerObjetoConductor())
                {
                    txtCodigo.Enabled = false;
                    txtNombre.Text = _objConductor.Nombre;
                    txtCodigo.Text = _objConductor.Codigo;
                    txtIdentificacion.Text = _objConductor.Identificacion;
                    ddlAutorizado.SelectedValue = _objConductor.Autorizacion == "S" ? "Si" : "No";

                    this.lblFormTitle.Text = "<b>Modificar Conductor:" + txtCodigo.Text + "</b>";                 
                 
                    this.lbGuardar.Text = "Modificar";
                }
                #endregion
            }

        }
        #endregion

        #region ObtenerObjetoPrecio
        private bool ObtenerObjetoConductor()
        {
            try
            {
                if (lblHide.Text != "")
                    _objConductor = Libreria.Configuracion.Conductores.ObtenerItem(lblHide.Text);
                else
                    _objConductor = null;

                if (this._objConductor == null)
                {
                    this.SetError("Elemento No Encontrado [" + lblHide.Text + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError("Ingreso Invalido a la página! [" + lblHide.Text + "]", true);
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
                        this._objConductor =  new Libreria.Configuracion.Conductor();
                        this._objConductor.Codigo = txtCodigo.Text;
                        this._objConductor.Nombre =  txtNombre.Text;
                        this._objConductor.Identificacion = txtIdentificacion.Text;
                        this._objConductor.Autorizacion = ddlAutorizado.SelectedValue;
                        Libreria.Configuracion.Conductores.Adicionar(this._objConductor);
                        Response.Redirect("Conductores.aspx");
                        #endregion
                    }
                    else
                    {
                        #region Editar
                        if (this.ObtenerObjetoConductor())
                        {
                            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 316, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                            this._objConductor.Codigo = txtCodigo.Text;
                            this._objConductor.Nombre = txtNombre.Text;
                            this._objConductor.Identificacion = txtIdentificacion.Text;
                            this._objConductor.Autorizacion = ddlAutorizado.SelectedValue;
                            this._objConductor.Modificar();
                            Response.Redirect("Conductores.aspx?Codigo=" + Request.QueryString["Codigo"]);
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


            if (txtCodigo.Text == "")
            {
                this.SetError("Debe ingresar un codigo!", false);
                return false;
            }

            if (txtNombre.Text == "")
            {
                this.SetError("Debe ingresar un nombre!", false);
                return false;
            }

            if (txtIdentificacion.Text == "")
            {
                this.SetError("Debe ingresar una identificación!", false);
                return false;
            }
            

            return true;
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
