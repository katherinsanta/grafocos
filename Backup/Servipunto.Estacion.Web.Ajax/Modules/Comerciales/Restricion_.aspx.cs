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
    public partial class Restricion_ : System.Web.UI.Page
    {
        protected WebApplication.FormMode _mode;
        protected short _dia;
        protected string _placa = null;
        protected DateTime _horaInicio;
        protected Libreria.Comercial.Restriccion _objRestriccion = null;

        protected void Page_Load(object sender, EventArgs e)
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
            if (Request.QueryString["Dia"] == null )
                this._mode = WebApplication.FormMode.New;
            else
                this._mode = WebApplication.FormMode.Edit;

            if (!this.IsPostBack)
            {
                if (this._dia == 0 & this._mode == WebApplication.FormMode.Edit)
                {
                    //lblHide.Text = this._dia.ToString();
                    this._placa = DecryptText(Convert.ToString(Request.QueryString["placa"].Replace(" ", "+")));
                    this._dia = short.Parse((Request.QueryString["dia"].ToString().Trim()));
                    this._horaInicio = DateTime.Parse(Request.QueryString["horainicio"].ToString().Trim());
                }
                this.InicializarForma();
            }
            //else
            //if (Request.Form["AcceptButton"] != null)

        }

        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.MyForm.Visible = false;
        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Comerciales";
            const string opcion = "Identificadores";
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

        #region ObtenerObjetoRestriccion
        private bool ObtenerObjetoRestriccion()
        {
            try
            {
                this._objRestriccion = Libreria.Comercial.Restricciones.ObtenerItem(_placa, _dia, _horaInicio);
                if (this._objRestriccion == null)
                {
                    this.SetError("Elemento No Encontrado [" + this._placa + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError("Ingreso Invalido a la página! [" + this._placa + "]", true);
                return false;
            }
        }
        #endregion

        #region Inicialización del Formulario
        private void InicializarForma()
        {
            try
            {
                this.lblBack.NavigateUrl = "Restricciones_.aspx?Placa=" + Request.QueryString["Placa"] + "&IdCliente=" + Request.QueryString["IdCliente"] + "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"];

                if (this.VerificarPermisos())
                {

                    if (this._mode == WebApplication.FormMode.New)
                    {
                        #region Modo de Inserción
                        this.lblFormTitle.Text = "<b>Configuración de un nuevo Horario</b>";
                        //this.EstadoActivo.Disabled = this.EstadoInactivo.Disabled = true;
                        //this.txtIdRestriccion.Enabled = true;
                        this.lblPlaca.Text = DecryptText(Convert.ToString(Request.QueryString["placa"].Replace(" ", "+")));

                        //this.AcceptButton.Value = "Crear";
                        this.lblGuardar.Text = "Crear";
                        #endregion
                    }
                    else
                    {
                        #region Modo de Edición
                        if (this.ObtenerObjetoRestriccion())
                        {
                            string[] cadena;
                            this.lblFormTitle.Text = "<b>Actualización de una Restricción</b>";
                            this.lblPlaca.Text = _objRestriccion.Placa;
                            this.cboDia.SelectedValue = _objRestriccion.Dia.ToString();
                            cadena = _objRestriccion.HoraInicioDisplay.Split(":".ToCharArray());
                            this.cboHoraInicio.SelectedValue = cadena[0].ToString();
                            this.cboMinutoInicio.Text = cadena[1].ToString();
                            cadena = _objRestriccion.HoraFinDisplay.Split(":".ToCharArray());
                            this.cboHoraFin.SelectedValue = cadena[0].ToString();
                            this.cboMinutoFin.Text = cadena[1].ToString();
                            this.txtLlaveCompuesta.Text = "";
                            this.txtLlaveCompuesta.Text = this.lblPlaca.Text + ";" + this.cboDia.SelectedValue + ";" + cboHoraInicio.SelectedValue + ":" + cboMinutoInicio.Text;//this.txtHoraInicio.Tex;

                            //Visualización de Datos
                            /*this.lblCodigoEmpleado.Text = this._objRestriccion.CodigoEmpleado.ToString();
                            this.txtIdRestriccion.Text =this._objRestriccion.NumeroRestriccion.ToString();

                            if(_objRestriccion.RestriccionActivo == "Activo")
                            {
                                EstadoActivo.Checked = true;
                                EstadoInactivo.Checked = false;
                            }
                            else
                            {
                                EstadoActivo.Checked = false;
                                EstadoInactivo.Checked = true;
                            }
						
                            this.txtCodigoROM.Text = this._objRestriccion.IdRom;
                            this.ddlTipoRestriccion.SelectedValue = this._objRestriccion.TipoRestriccion;
                            this.txtPlaca.Text = this._objRestriccion.Placa;
                            this.lblFormTitle.Text = "Restriccion: <b>" + this._objRestriccion.NumeroRestriccion.ToString() + "</b>";
                            */
                            this.lblGuardar.Text = "Guardar";
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                SetError(ex.Message, false);
                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno cargando el formulario de horario de consumo. ");
                }
                catch (Exception exx)
                {
                    lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                    this.SetError(lblError.Text, false);
                }
                #endregion
                return;
            }
        }
        #endregion

        #region Guardar
        private void lblGuardar_Click(object sender, System.EventArgs e)
        {
            this.Guardar();
        }

        private void Guardar()
        {
            string[] cadena;
            if (this.Validar())
            {
                try
                {
                    this._objRestriccion = new Libreria.Comercial.Restriccion();
                    this._objRestriccion.Placa = lblPlaca.Text.Trim();
                    this._objRestriccion.Dia = short.Parse(cboDia.SelectedValue);
                    this._objRestriccion.HoraInicio = DateTime.Parse("1900-01-01 " + cboHoraInicio.SelectedValue + ":" + cboMinutoInicio.Text);
                    this._objRestriccion.HoraFin = DateTime.Parse("1900-01-01 " + cboHoraFin.SelectedValue + ":" + cboMinutoFin.Text);

                    if (this._mode == WebApplication.FormMode.New)
                    {
                        #region Insertar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 311, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        Libreria.Comercial.Restricciones.Adicionar(this._objRestriccion);
                        #endregion
                    }
                    else
                    {
                        #region Modificar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 312, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this.txtLlaveCompuesta.Text = this.txtLlaveCompuesta.Text;
                        cadena = this.txtLlaveCompuesta.Text.Split(";".ToCharArray());
                        this._dia = short.Parse(cadena[1]);
                        this._horaInicio = DateTime.Parse(cadena[2]);
                        this._objRestriccion.Modificar(_dia, _horaInicio);
                        #endregion
                    }
                    Response.Redirect("Restricciones.aspx?Placa=" + Request.QueryString["Placa"] + "&IdCliente=" + Request.QueryString["IdCliente"] + "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"]);
                    //+ "&IdCliente=" + Request.QueryString["IdCliente"] 
                    //+ "&IdNombreCliente=" + Request.QueryString["IdNombreCliente"]);
                }
                catch (Exception ex)
                {
                    SetError(ex.Message, false);
                    #region registro del log de errores
                    try
                    {
                        Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                            2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                            ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno guardando los datos de horario de consumo. ");
                    }
                    catch (Exception exx)
                    {
                        lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                        this.SetError(lblError.Text, false);

                    }
                    #endregion
                    return;
                }
                finally
                {
                    this._objRestriccion = null;
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
            cboMinutoInicio.Text = cboMinutoInicio.Text.PadLeft(2, '0');
            cboMinutoFin.Text = cboMinutoFin.Text.PadLeft(2, '0');
            if (int.Parse(cboMinutoInicio.Text) < 0 || int.Parse(cboMinutoInicio.Text) > 59)
            {
                SetError("Los minutos de inicio deben de estar entre 0 y 59!", false);
                return false;
            }
            if (int.Parse(cboMinutoFin.Text) < 0 || int.Parse(cboMinutoFin.Text) > 59)
            {
                SetError("Los minutos de fin deben de estar entre 0 y 59!", false);
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

        protected void lblGuardar_Click1(object sender, EventArgs e)
        {
            Guardar();
        }

        

    }
}
