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
using Servipunto.Estacion.Libreria;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
    public class Permisos : System.Web.UI.Page
    {
        #region Definicion de variables
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected System.Web.UI.WebControls.Label lblFormTitle;
        protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
        protected System.Web.UI.WebControls.DropDownList cboModulos;
        protected System.Web.UI.WebControls.DropDownList cboOpciones;
        protected System.Web.UI.HtmlControls.HtmlInputHidden SubmitSource;
        protected System.Web.UI.WebControls.Label lblHide;
        protected WebApplication.FormMode _mode;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.CheckBoxList chkAcciones;
        protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.LinkButton lbAsignarTodosLosPermisos;
        protected System.Web.UI.WebControls.LinkButton lbQuitarTodosLosPermisos;
        protected Libreria.Rol _objRol = null;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Button btnGuardar;
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
            if (Request.QueryString["Id"] == null)
                this._mode = WebApplication.FormMode.New;
            else
                this._mode = WebApplication.FormMode.Edit;

            if (!this.IsPostBack)
            {
                if (ViewState["Control"].ToString() != "1")
                {
                    if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                    {
                        this._id = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                        this.lblHide.Text = this._id;
                    }
                    this.InicializarForma();
                }
            }
            else
            {
                if (Request.Form["AcceptButton"] != null)
                    this.Guardar();
                /*else
                {
                    if (this.SubmitSource.Value == "AddAll")
                        this.AsignarTodo();
                    else if (this.SubmitSource.Value == "RemoveAll")
                        this.RemoverTodo();
                }*/
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
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(789, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(792, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1768, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1769, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1057, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1058, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1059, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion

        #region * Método de Inicialización del Formulario
        private void InicializarForma()
        {
            try
            {

                if (this.VerificarPermisos())
                {
                    ViewState["Control"] = "1";
                    if (Request.UrlReferrer != null)
                        this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
                    else
                        this.lblBack.NavigateUrl = "Roles.aspx";

                    this.InicializarModoEdicion();
                }
            }
            catch (Exception ex)
            {
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

        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {
            bool permiso;

            if (this._mode == WebApplication.FormMode.New)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma), true);
                return false;
            }

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar("Panel de Control", "Roles", "Permisos");
            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                return false;
            }
            return true;
        }
        #endregion

        #region Método Inicializar Modo de Edición
        private void InicializarModoEdicion()
        {
            if (this.ObtenerElemento())
            {
                this.lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1014, Global.Idioma) + ": <b>" + this._objRol.Nombre + "</b>";
                this.AcceptButton.Value = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                this.btnGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                this.CargarModulos();

                if (Request.QueryString["New"] != null)
                {
                    this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1764, Global.Idioma);
                    this.lblError.Visible = true;
                }
            }
        }
        #endregion

        #region Método para Obtener una Referencia al Objeto
        private bool ObtenerElemento()
        {
            try
            {
                this._id = this.lblHide.Text; //DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ","+") ));
                this._objRol = Libreria.Roles.Obtener(Convert.ToByte(this._id));
                if (this._objRol == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + " [" + this._id + "]", true);
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

        #region Método Guardar
        private void Guardar()
        {
            try
            {
                this.lblError.Text = "";
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 15, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.RegistrarPermisos();
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message, false);

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
                this._objRol = null;
            }
        }
        #endregion

        #region Método RegistrarPermisos
        private void RegistrarPermisos()
        {
            if (this.ObtenerElemento())
            {
                this._objRol.Permisos.Remover(this.cboModulos.SelectedValue, this.cboOpciones.SelectedValue);
                foreach (ListItem objItem in this.chkAcciones.Items)
                {
                    if (objItem.Selected)
                        this._objRol.Permisos.Adicionar(this.cboModulos.SelectedValue, this.cboOpciones.SelectedValue, objItem.Value);
                }
            }
        }
        #endregion

        #region Método AsignarTodo
        private void AsignarTodo()
        {
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 16, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblError.Text = "";
                if (this.ObtenerElemento())
                {
                    this._objRol.Permisos.AsignarTodo();
                    if (this.cboModulos.SelectedIndex != -1)
                        this.CargarOpciones(this.cboModulos.SelectedValue);

                    this.lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1765, Global.Idioma);
                    this.lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message, false);
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
                this._objRol = null;
            }
        }
        #endregion

        #region Método RemoverTodo
        private void RemoverTodo()
        {
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 17, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblError.Text = "";
                if (this.ObtenerElemento())
                {
                    this._objRol.Permisos.RemoverTodo();
                    if (this.cboModulos.SelectedIndex != -1)
                        this.CargarOpciones(this.cboModulos.SelectedValue);
                    this.lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1766, Global.Idioma);
                    this.lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message, false);
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
                this._objRol = null;
            }
        }
        #endregion

        #region Método CargarModulos
        private void CargarModulos()
        {
            this.lblError.Text = "";

            Libreria.Modulos objModulos = new Servipunto.Estacion.Libreria.Modulos();

            this.cboModulos.DataSource = objModulos;
            this.cboModulos.DataTextField = "IdModulo";
            this.cboModulos.DataValueField = "IdModulo";
            this.cboModulos.DataBind();
            #region Traduccion
            for (int i = 0; i < cboModulos.Items.Count; i++)
            {
                #region Prepare Sql Command
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                DataSet Consulta = new DataSet();             

                    #region Idioma español
                    if (Global.Idioma == 0)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, cboModulos.Items[i].Value);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, null);
                        sql.AddParameter("@idioma", SqlDbType.Int, Convert.ToInt32(Global.Idioma.ToString()));

                    }
                    #endregion

                    #region Idioma Ingles
                    else if (Global.Idioma == 1)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, null);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, cboModulos.Items[i].Value);
                        sql.AddParameter("@idioma", SqlDbType.Int, Convert.ToInt32(Global.Idioma.ToString()));
                    }
                    #endregion

                    #region Idioma Panama
                    else if (Global.Idioma == 2)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, null);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, cboModulos.Items[i].Value);
                        sql.AddParameter("@idioma", SqlDbType.Int, Convert.ToInt32(Global.Idioma.ToString()));
                    }
                    #endregion

                #endregion

                #region Execute Sql
                try
                {
                    Consulta = (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message + " !ERROR BD! ");
                }
                finally
                {
                    sql = null;
                }
                #endregion

                if (Consulta != null)
                {
                    cboModulos.Items[i].Text = Consulta.Tables[0].Rows[0][0].ToString();
                    Consulta = null;
                }
            }
            #endregion
            if (this.cboModulos.SelectedIndex != -1)
                this.CargarOpciones(this.cboModulos.SelectedValue);

            objModulos = null;
        }
        #endregion

        #region Método CargarOpciones
        private void CargarOpciones(string idModulo)
        {
            this.lblError.Text = "";

            Libreria.Modulo objModulo = Libreria.Modulos.Obtener(idModulo);
            if (objModulo != null)
            {
                this.cboOpciones.DataSource = objModulo.Opciones;
                this.cboOpciones.DataTextField = "IdOpcion";
                this.cboOpciones.DataValueField = "IdOpcion";
                this.cboOpciones.DataBind();
                #region Traduccion
                for (int i = 0; i < cboOpciones.Items.Count; i++)
                {
                    Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                    DataSet Consulta = new DataSet();

                    #region Prepare Sql Command
                    #region Idioma español
                    if (Global.Idioma == 0)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, cboOpciones.Items[i].Value);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, null);
                        sql.AddParameter("@idioma", SqlDbType.Int,Global.Idioma);
                    }
                        #endregion

                    #region Idioma Ingles
                    else if (Global.Idioma == 1)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, null);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, cboOpciones.Items[i].Value);
                        sql.AddParameter("@idioma", SqlDbType.Int,Global.Idioma);
                    }
                    #endregion

                    #region Idioma Panama
                    else if (Global.Idioma == 2)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, null);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, cboOpciones.Items[i].Value);
                        sql.AddParameter("@idioma", SqlDbType.Int,Global.Idioma);
                    }
                    #endregion

                    #endregion

                    #region Execute Sql
                    try
                    {
                        Consulta = (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
                    }
                    catch (SqlException e)
                    {
                        throw new Exception(e.Message + " !ERROR BD! ");
                    }
                    finally
                    {
                        sql = null;
                    }
                    #endregion

                    if (Consulta != null)
                    {
                        cboOpciones.Items[i].Text = Consulta.Tables[0].Rows[0][0].ToString();
                        Consulta = null;
                    }
                }
                #endregion
                this.cboOpciones.Enabled = true;
                if (this.cboOpciones.SelectedIndex != -1)
                    this.CargarAcciones(idModulo, this.cboOpciones.SelectedValue);
            }
            else
            {
                this.cboOpciones.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1767, Global.Idioma));
                this.cboOpciones.Enabled = false;
            }
            objModulo = null;
        }
        #endregion

        #region Método CargarAcciones
        private void CargarAcciones(string idModulo, string idOpcion)
        {
            this.lblError.Text = "";

            Libreria.Opcion objOpcion = Libreria.Opciones.Obtener(idModulo, idOpcion);
            this._id = this.lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
            this._objRol = Libreria.Roles.Obtener(Convert.ToByte(this._id));

            //objOpcion.Acciones.IdRol = Convert.ToByte(this._id);
            objOpcion.Acciones.IdRol = this._objRol.IdRol;
            if (objOpcion != null)
            {
                this.chkAcciones.Items.Clear();
                foreach (Libreria.Accion objAccion in objOpcion.Acciones)
                {
                    string Traduccion = "";
                    #region Traduccion
                    #region Prepare Sql Command
                    Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                    DataSet Consulta = new DataSet();
                    //sql.Append("RecuperarIdiomaTraduccion");
                    //sql.ParametersNumber = 2;
                    //sql.AddParameter("@Palabra", SqlDbType.VarChar, objAccion.Descripcion);
                    //sql.AddParameter("@Traduccion", SqlDbType.VarChar, null);

                    #region Idioma español
                    if (Global.Idioma == 0)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, objAccion.Descripcion);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, null);
                        sql.AddParameter("@idioma", SqlDbType.Int, Convert.ToInt32(Global.Idioma.ToString()));

                    }
                    #endregion

                    #region Idioma Ingles
                    else if (Global.Idioma == 1)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, null);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, objAccion.Descripcion);
                        sql.AddParameter("@idioma", SqlDbType.Int, Convert.ToInt32(Global.Idioma.ToString()));
                    }
                    #endregion

                    #region Idioma Panama
                    else if (Global.Idioma == 2)
                    {
                        sql.Append("RecuperarIdiomaTraduccion");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Palabra", SqlDbType.VarChar, null);
                        sql.AddParameter("@Traduccion", SqlDbType.VarChar, objAccion.Descripcion);
                        sql.AddParameter("@idioma", SqlDbType.Int, Convert.ToInt32(Global.Idioma.ToString()));
                    }
                    #endregion


                    #endregion
                    #region Execute Sql
                    try
                    {
                        Consulta = (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
                    }
                    catch (SqlException e)
                    {
                        throw new Exception(e.Message + " !ERROR BD! ");
                    }
                    finally
                    {
                        sql = null;
                    }
                    #endregion

                    if (Consulta != null)
                    {
                        Traduccion = Consulta.Tables[0].Rows[0][0].ToString();
                        Consulta = null;
                    }

                    #endregion

                    System.Web.UI.WebControls.ListItem objItem = new ListItem(Traduccion, objAccion.IdAccion);
                    objItem.Selected = objAccion.Existe;
                    this.chkAcciones.Items.Add(objItem);
                }
            }
            objOpcion = null;
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
            this.cboModulos.SelectedIndexChanged += new System.EventHandler(this.cboModulos_SelectedIndexChanged);
            this.cboOpciones.SelectedIndexChanged += new System.EventHandler(this.cboOpciones_SelectedIndexChanged);
            this.lbAsignarTodosLosPermisos.Click += new System.EventHandler(this.lbAsignarTodosLosPermisos_Click);
            this.lbQuitarTodosLosPermisos.Click += new System.EventHandler(this.lbQuitarTodosLosPermisos_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Evento Click del Combo de Modulos
        private void cboModulos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.CargarOpciones(this.cboModulos.SelectedValue);
        }
        #endregion

        #region Evento Click dem Combo de Opciones
        private void cboOpciones_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.CargarAcciones(this.cboModulos.SelectedValue, this.cboOpciones.SelectedValue);
        }
        #endregion    

        #region Asignar Todos los permisos
        private void lbAsignarTodosLosPermisos_Click(object sender, System.EventArgs e)
        {
            this.AsignarTodo();
        }
        #endregion

        #region Quitar Todos los Permisos
        private void lbQuitarTodosLosPermisos_Click(object sender, System.EventArgs e)
        {
            this.RemoverTodo();
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

        #region Guardar o Actualizar
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }
        #endregion
    }
}
