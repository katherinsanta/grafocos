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
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class RegistroOtroIngreso : System.Web.UI.Page
    {
        protected WebApplication.FormMode _mode;
        protected Libreria.RegistroOtroIngreso _objRegistroIngreso = null;
        protected string _id = null;
        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (Request.QueryString["Id"] == null && lblHide.Text == "")
                    this._mode = WebApplication.FormMode.New;
                else
                    this._mode = WebApplication.FormMode.Edit;

                if (!this.IsPostBack)
                {
                    if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                    {
                        this._id = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                        lblHide.Text = this._id;
                    }
                    this.InicializarForma();
                }
                else
                    if (Request.Form["AcceptButton"] != null)
                        this.Guardar();
            }
            catch (Exception ex)
            {
                lblError.Text += "Error cargando el formulario";

                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, "Error cargando el formulario de Registro de Otros Ingresos");
                }
                catch (Exception exx)
                {
                    lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = "Registro Otros Ingresos";
            bool permiso;

            if (this._mode == WebApplication.FormMode.New)
                permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
            else
                permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.", true);
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
                this.lblBack.NavigateUrl = "RegistroOtrosIngresos.aspx";
                if (this._mode == WebApplication.FormMode.New)
                {
                    #region Modo de Inserción
                    this.lblFormTitle.Text = "<b>Creación de un Registro de otro Ingreso</b>";
                    this.AcceptButton.Value = "Crear";
                    CargarConceptosOtrosIngresos();
                    #endregion
                }
                else
                {
                    #region Modo de Edición
                    this.SetError("<b>Acceso Denegado.</b><br><br>Pagina no disponible.", true);
                    #endregion
                }
            }
        }
        #endregion
        #region Cargar Conceptos Otros Ingresos
        protected void CargarConceptosOtrosIngresos()
        {
            Servipunto.Estacion.Libreria.Configuracion.ConceptoOtrosIngresos objCOI = new Servipunto.Estacion.Libreria.Configuracion.ConceptoOtrosIngresos();
            ddlConcenptosOtrosIngresos.DataSource = objCOI;
            this.ddlConcenptosOtrosIngresos.DataTextField = "NombreOtroIngreso";
            this.ddlConcenptosOtrosIngresos.DataValueField = "IdConceptoOtroIngreso";
            this.ddlConcenptosOtrosIngresos.DataBind();
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
                        Servipunto.Estacion.Libreria.Turnos.JornadaZeta objJZ = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(1);
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 31, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objRegistroIngreso = new Libreria.RegistroOtroIngreso();
                        this._objRegistroIngreso.Fecha = objJZ.Fecha;
                        this._objRegistroIngreso.Hora = DateTime.Now;
                        this._objRegistroIngreso.FechaReal = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        this._objRegistroIngreso.IdConcepto = Convert.ToInt32(ddlConcenptosOtrosIngresos.SelectedValue);
                        this._objRegistroIngreso.Valor = Convert.ToDecimal(txtValor.Text);
                        Libreria.RegistrosOtrosIngresos.Adicionar(this._objRegistroIngreso);
                        //Modificado:   07-03-2011
                        //Autor:        Miguel Cantor L.
                        //Descripción:  Crea registro de otros ingresos en el compilado del mismo.
                        //Presentes:    Luisa Maca
                        #region Consolidado Otros Ingresos
                        SqlConnection conect = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
                        if (conect.State == ConnectionState.Closed)
                            conect.Open();
                        Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                        sql.Append("InsertarConsolidadoOtroIngreso");
                        sql.ParametersNumber = 3;
                        sql.AddParameter("@Fecha", SqlDbType.DateTime, this._objRegistroIngreso.Fecha);
                        sql.AddParameter("@IdConceptoOtrosIngresos", SqlDbType.Int, this._objRegistroIngreso.IdConcepto);
                        sql.AddParameter("@ValorOtroIngreso", SqlDbType.Decimal, this._objRegistroIngreso.Valor);
                        SqlHelper.ExecuteNonQuery(conect, CommandType.StoredProcedure, sql.Text, sql.Parameters);
                        conect.Dispose();
                        conect.Close();
                        #endregion
                        #endregion
                    }
                    else
                    {
                        #region Modificar                        
                        #endregion
                    }
                    Response.Redirect("RegistroOtrosIngresos.aspx");
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
                            ex.Message + " !ERROR APP! " + ex.StackTrace, "Error guardando los datos de el Registro del Otros ingresos");
                    }
                    catch (Exception exx)
                    {
                        lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                    }
                    #endregion

                    return;
                }
                finally
                {
                    this._objRegistroIngreso= null;
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
            Servipunto.Estacion.Libreria.Turnos.JornadaZeta objJZ = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(1);
            if (objJZ != null)
            {
               
            }
            else
            {
                this.SetError("No existen jornadas Zeta Abiertas!" , true);
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

        protected void AcceptButton_ServerClick(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
