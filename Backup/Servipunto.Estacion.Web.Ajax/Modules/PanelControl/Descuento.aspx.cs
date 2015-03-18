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

namespace Servipunto.Estacion.Web.Ajax.Modules.PanelControl
{
    public partial class Descuentos : System.Web.UI.Page
    {
        #region Sección de Declaraciones
        protected WebApplication.FormMode _mode;
        protected Libreria.Configuracion.ConfiguracionDescuento _objConfiguracionDescuento = null;
        protected string _id = null;

        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {

            //cargarRadioButon();
            try
            {

                if (!this.IsPostBack)
                {
                    
                //    LabelPorc.Visible = false;
                //    LabelValor.Visible = false;
                //    txtPorcentajeDescuento.Visible = false;
                //    TexValor.Visible = false;
                    //this.InicializarForma();

                    if (Request.QueryString["id"] == "null")
                    {
                        InicializarFrmNuevo();
                    }
                    else
                    {
                        InicializarForma();
                    }
                }
              


            }
            catch (Exception ex)
            {
                lblError.Text += "Error cargando el formulario";

                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, "Error cargando el formulario de compañia");
                }
                catch (Exception exx)
                {
                    lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                }
                #endregion

            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
                      
        }

        private void Modificar() 
        {
            #region Modificar
            ObtenerObjetoConfiguracionZeta();
            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 32, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
            if (!ChkTodasHoras.Checked)
            {
                this._objConfiguracionDescuento.HoraInicio = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraInicio.SelectedValue), Convert.ToInt32(ddlMinutoInicio.SelectedValue), 0);
                this._objConfiguracionDescuento.HoraFinal = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraFinal.SelectedValue), Convert.ToInt32(ddlMinutoFinal.SelectedValue), 0);
            }
            else
            {
                this._objConfiguracionDescuento.HoraInicio = new DateTime(1900, 1, 1, 0, 0, 0);
                this._objConfiguracionDescuento.HoraFinal = new DateTime(1900, 1, 1, 0, 0, 0);
            }
            this._objConfiguracionDescuento.IdDescuento = Convert.ToInt16(Request.QueryString["id"].ToString());
            this._objConfiguracionDescuento.TipoDescuento = Convert.ToInt16(ddlTipoDescuento.SelectedValue);
            this._objConfiguracionDescuento.TodasHoras = ChkTodasHoras.Checked;
            if (!chkTodosLosDias.Checked)
                this._objConfiguracionDescuento.DiasSemana = ObtenerDiasSemna();
            else
                this._objConfiguracionDescuento.DiasSemana = "0;";

            this._objConfiguracionDescuento.FechaFinal = calFechaFinal.SelectedDate;
            this._objConfiguracionDescuento.FechaInicio = calFechaInicio.SelectedDate;
            this._objConfiguracionDescuento.ItemsAfectados = ObtenerItemsAfectados();
                if (RadioButton2.Checked)
                {
                    this._objConfiguracionDescuento.PorcDescuento = Convert.ToDecimal(TexValor.Text);
                    this._objConfiguracionDescuento.Valor = 0;
                }
                else if (RadioButton1.Checked)
                {
                    int aux = (int)(Convert.ToDecimal(TexValor.Text));

                    this._objConfiguracionDescuento.Valor = aux;
                    this._objConfiguracionDescuento.PorcDescuento = Convert.ToDecimal("0,0");
                }
            this._objConfiguracionDescuento.Aplica = ObtenerAplica();
            this._objConfiguracionDescuento.FechaCreacion = DateTime.Now;
            this._objConfiguracionDescuento.FechaModificacion = DateTime.Now;
            this._objConfiguracionDescuento.IdUsuario = Convert.ToString(((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString());
            if (RbActivo.Checked)
            {
                this._objConfiguracionDescuento.Estado = true;
            }
            else if (!RbActivo.Checked)
            {
                this._objConfiguracionDescuento.Estado = false;
            }
            if (RbReSi.Checked)
            {
                this._objConfiguracionDescuento.Redondear = true;
            }
            else if (!RbReSi.Checked)
            {
                this._objConfiguracionDescuento.Redondear = false;
            }
            this._objConfiguracionDescuento.Modificar();
            Response.Redirect("Descuentos.aspx");
            #endregion

        }

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
            const string opcion = "Companias";
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

        #region ObtenerObjetoConfiguracionZeta
        private bool ObtenerObjetoConfiguracionZeta()
        {
            try
            {
                Libreria.Configuracion.ConfiguracionDescuentos objConfiguraciones = new Servipunto.Estacion.Libreria.Configuracion.ConfiguracionDescuentos();
                if (objConfiguraciones.Count > 0)
                {
                    _objConfiguracionDescuento = objConfiguraciones[0];
                    return true;
                }
                else
                    return false;
            }
            catch (FormatException)
            {
                this.SetError("Ingreso Invalido a la página! [" + this._id + "]", true);
                return false;
            }
        }
        #endregion

        #region inicializarNuevo
        protected void InicializarFrmNuevo()
        {
            this.lblBack.NavigateUrl = "Descuentos.aspx";
            this.lblFormTitle.Text = "<b>Nuevo Descuento</b>";
            this._mode = WebApplication.FormMode.New;
            LLenarHorasMinutos();
            calFechaFinal.SelectedDate = DateTime.Now;
            calFechaInicio.SelectedDate = DateTime.Now;
            LabelFechaCreac.Text = DateTime.Now.ToString();
            ConsultarAplica();
            LabelFechaModifi.Text = DateTime.Now.ToString();
            this.ddlHoraInicio.SelectedValue = _objConfiguracionDescuento.HoraInicio.Hour.ToString().PadLeft(2, '0');
            this.ddlHoraFinal.SelectedValue = _objConfiguracionDescuento.HoraFinal.Hour.ToString().PadLeft(2, '0');
            this.ddlMinutoInicio.SelectedValue = _objConfiguracionDescuento.HoraInicio.Minute.ToString().PadLeft(2, '0');
            this.ddlMinutoFinal.SelectedValue = _objConfiguracionDescuento.HoraFinal.Minute.ToString().PadLeft(2, '0');
            this._mode = WebApplication.FormMode.Edit;
            ChkAplica.SelectedItem.Selected = false;

        }

        #endregion

        #region Inicialización del Descuento existente
        private void InicializarForma()
        {
            if (this.VerificarPermisos())
            {
                this.lblBack.NavigateUrl = "Descuentos.aspx";
                this.lblFormTitle.Text = "<b>Configuración Descuento</b>";
                this._mode = WebApplication.FormMode.New;
                LLenarHorasMinutos();
                if (ObtenerObjetoConfiguracionDescuento())
                {
                    chkListaItems.Enabled = false;
                    chkChequeoLista.Enabled = false;
                    ddlTipoDescuento.SelectedValue = _objConfiguracionDescuento.TipoDescuento.ToString();                    
                    LlenarListaItems();
                    if (_objConfiguracionDescuento.Valor==0)
                    {
                        RadioButton2.Checked = true;
                        RadioButton1.Checked = false;
                        TexValor.Text = _objConfiguracionDescuento.PorcDescuento.ToString();
                    }
                    else if (_objConfiguracionDescuento.Valor != 0)
                    {
                        RadioButton1.Checked = true;
                        RadioButton2.Checked = false;
                        TexValor.Text = _objConfiguracionDescuento.Valor.ToString();
                    }
                    LabelFechaCreac.Text = _objConfiguracionDescuento.FechaCreacion.ToShortDateString();
                    LabelFechaModifi.Text = DateTime.Now.ToString();
                    ConsultarItemsAfectados();
                    ConsultarDiasAfectados();
                    calFechaInicio.SelectedDate = _objConfiguracionDescuento.FechaInicio;
                    calFechaFinal.SelectedDate = _objConfiguracionDescuento.FechaFinal;
                    ChkTodasHoras.Checked = _objConfiguracionDescuento.TodasHoras;
                    ConsultarAplica();
                    bool estado = _objConfiguracionDescuento.Estado;
                    bool redondear = _objConfiguracionDescuento.Redondear;
                    if (estado)
                    {
                        RbActivo.Checked = true;
                        RbInactivo.Checked = false;
                    }
                    else if (!estado)
                    {
                        RbInactivo.Checked = true;
                        RbActivo.Checked = false;
                    }
                    if (redondear)
                    {
                        RbReSi.Checked = true;
                        RbReNo.Checked = false;
                    }
                    else if (!redondear)
                    {
                        RbReSi.Checked = false;
                        RbReNo.Checked = true;
                    }

                    if (ChkTodasHoras.Checked)
                    {
                        ddlHoraInicio.Enabled = false;
                        ddlMinutoInicio.Enabled = false;
                        ddlHoraFinal.Enabled = false;
                        ddlMinutoFinal.Enabled = false;
                    }
                    else
                    {
                        ddlHoraInicio.Enabled = true;
                        ddlMinutoInicio.Enabled = true;
                        ddlHoraFinal.Enabled = true;
                        ddlMinutoFinal.Enabled = true;
                    }
                    this.ddlHoraInicio.SelectedValue = _objConfiguracionDescuento.HoraInicio.Hour.ToString().PadLeft(2,'0');
                    this.ddlHoraFinal.SelectedValue = _objConfiguracionDescuento.HoraFinal.Hour.ToString().PadLeft(2, '0');
                    this.ddlMinutoInicio.SelectedValue = _objConfiguracionDescuento.HoraInicio.Minute.ToString().PadLeft(2, '0');
                    this.ddlMinutoFinal.SelectedValue = _objConfiguracionDescuento.HoraFinal.Minute.ToString().PadLeft(2, '0');                    
                    this._mode = WebApplication.FormMode.Edit;

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
                        #region Insertar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 31, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objConfiguracionDescuento = new Servipunto.Estacion.Libreria.Configuracion.ConfiguracionDescuento();
                        if (!ChkTodasHoras.Checked)
                        {
                            this._objConfiguracionDescuento.HoraInicio = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraInicio.SelectedValue), Convert.ToInt32(ddlMinutoInicio.SelectedValue), 0);
                            this._objConfiguracionDescuento.HoraFinal = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraFinal.SelectedValue), Convert.ToInt32(ddlMinutoFinal.SelectedValue), 0);
                        }
                        else
                        {
                            this._objConfiguracionDescuento.HoraInicio = new DateTime(1900, 1, 1, 0, 0, 0);
                            this._objConfiguracionDescuento.HoraFinal = new DateTime(1900, 1, 1, 0, 0, 0);
                        }
                        if (RadioButton2.Checked)
                        {
                            this._objConfiguracionDescuento.PorcDescuento = Convert.ToDecimal(TexValor.Text);
                            this._objConfiguracionDescuento.Valor = 0;
                        }
                        else if (RadioButton1.Checked)
                        {
                            this._objConfiguracionDescuento.Valor = Convert.ToInt32(TexValor.Text.ToString());
                            this._objConfiguracionDescuento.PorcDescuento = Convert.ToDecimal("0,0");
                        }                 
                        
                        this._objConfiguracionDescuento.TipoDescuento = Convert.ToInt16(ddlTipoDescuento.SelectedValue);
                        this._objConfiguracionDescuento.TodasHoras = ChkTodasHoras.Checked;
                        if (!chkTodosLosDias.Checked)
                            this._objConfiguracionDescuento.DiasSemana = ObtenerDiasSemna();
                        else
                            this._objConfiguracionDescuento.DiasSemana = "0;";

                        this._objConfiguracionDescuento.FechaFinal = calFechaFinal.SelectedDate;
                        this._objConfiguracionDescuento.FechaInicio = calFechaInicio.SelectedDate;
                        this._objConfiguracionDescuento.ItemsAfectados = ObtenerItemsAfectados();
                        
                        this._objConfiguracionDescuento.Aplica = ObtenerAplica();
                        this._objConfiguracionDescuento.FechaCreacion = DateTime.Now;
                        this._objConfiguracionDescuento.FechaModificacion = DateTime.Now;
                        this._objConfiguracionDescuento.IdUsuario =Convert.ToString(((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString());
                        if (RbActivo.Checked)
                        {
                            this._objConfiguracionDescuento.Estado = true;
                        }
                        else if (!RbActivo.Checked)
                        {
                            this._objConfiguracionDescuento.Estado = false;
                        }
                        if (RbReSi.Checked)
                        {
                            this._objConfiguracionDescuento.Redondear = true;
                        }
                        else if (!RbReSi.Checked)
                        {
                            this._objConfiguracionDescuento.Redondear = false;
                        }
                        
                        

                        Libreria.Configuracion.ConfiguracionDescuentos.Adicionar(this._objConfiguracionDescuento);
                        #endregion
                        
                        Response.Redirect("Descuentos.aspx");
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
                            ex.Message + " !ERROR APP! " + ex.StackTrace, "Error guardando los datos de las compañias");
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
                    this._objConfiguracionDescuento = null;

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

        protected void chkChequeoLista_CheckedChanged(object sender, EventArgs e)
        {

            foreach (ListItem obj in chkListaItems.Items)
                obj.Selected = true;

        }

        private void ConsultarItemsAfectados()
        {

            string[] sels = _objConfiguracionDescuento.ItemsAfectados.Split(';');
            if (sels.Length > 0)
            {

                foreach (ListItem item in chkListaItems.Items)
                {
                    for (int i = 0; i < sels.Length; i++)
                    {
                        if (sels[i] == item.Value)
                            item.Selected = true;

                    }

                }
            }

        }

        private void ConsultarAplica() 
        {
            string[] aplica = _objConfiguracionDescuento.Aplica.Split(';');
            if (aplica.Length>0)
            {
                if (aplica[0]!="0")
                {
                    foreach (ListItem item in ChkAplica.Items)
                    {
                        item.Selected = false;
                        for (int i = 0; i < aplica.Length; i++)
                        {
                            if (aplica[i] == item.Value)
                                item.Selected = true;
                        }
                    }
                }
                else
                {
                    foreach (ListItem item in ChkAplica.Items)
                    {
                        for (int i = 0; i < aplica.Length; i++)
                        {
                            item.Selected = false;
                        }
                    }
                }
            }
        }

        private void ConsultarDiasAfectados()
        {
            string[] sels = _objConfiguracionDescuento.DiasSemana.Split(';');
            if (sels.Length > 0)
            {
                if (sels[0] != "0")
                {
                    chkTodosLosDias.Checked = false;
                    chkListaDiasSemana.Enabled = true;
                    foreach (ListItem item in chkListaDiasSemana.Items)
                    {
                        item.Selected = false;
                        for (int i = 0; i < sels.Length; i++)
                        {
                            if (sels[i] == item.Value)
                                item.Selected = true;

                        }

                    }
                }
                else
                {
                    chkTodosLosDias.Checked = true;
                    chkListaDiasSemana.Enabled = false;
                    foreach (ListItem item in chkListaDiasSemana.Items)
                    {
                        for (int i = 0; i < sels.Length; i++)
                            item.Selected = true;
                    }
                }
            }

        }

        private bool ObtenerObjetoConfiguracionDescuento()
        {
            try
            {

                Libreria.Configuracion.ConfiguracionDescuentos objConfiguraciones = new Servipunto.Estacion.Libreria.Configuracion.ConfiguracionDescuentos(int.Parse(Request.QueryString["id"].ToString()));
                if (objConfiguraciones.Count > 0)
                {
                    _objConfiguracionDescuento = objConfiguraciones[0];
                    return true;
                }
                else
                    return false;
            }
            catch (FormatException)
            {
                this.SetError("Ingreso Invalido a la página! [" + this._id + "]", true);
                return false;
            }
        }

        private string ObtenerAplica() 
        {
            string aplica = "";
            foreach (ListItem obj in ChkAplica.Items)
            {
                if (obj.Selected)
                    aplica += obj.Value.ToString() + ";";
            }
            return aplica;
        }

        private string ObtenerDiasSemna()
        {
            string items = "";
            foreach (ListItem obj in chkListaDiasSemana.Items)
            {
                if (obj.Selected)
                    items += obj.Value.ToString() + ";";

            }
            return items;
        }

        private string ObtenerItemsAfectados()
        {
            string items = "";
            foreach (ListItem obj in chkListaItems.Items)
            {
                if (obj.Selected)
                    items += obj.Value.ToString() + ";";

            }
            return items;
        }

        private void LlenarListaMangueras()
        {
            Libreria.Configuracion.Mangueras objs = new Servipunto.Estacion.Libreria.Configuracion.Mangueras();
            chkListaItems.DataSource = objs;
            chkListaItems.DataTextField = "IdManguera";
            chkListaItems.DataValueField = "IdManguera";
            chkListaItems.DataBind();
        }

        private void LlenarListaArticulos()
        {
            Libreria.Configuracion.Articulos objs = new Servipunto.Estacion.Libreria.Configuracion.Articulos(Libreria.TipoArticulo.Combustible);
            chkListaItems.DataSource = objs;
            chkListaItems.DataTextField = "Descripcion";
            chkListaItems.DataValueField = "IdArticulo";
            chkListaItems.DataBind();
        }

        private void LlenarListaSurtidor()
        {
            Libreria.Configuracion.Islas objs = new Servipunto.Estacion.Libreria.Configuracion.Islas();
            foreach (Libreria.Configuracion.Isla obj in objs)
            {
                Libreria.Configuracion.Surtidores objSurtidores = new Servipunto.Estacion.Libreria.Configuracion.Surtidores(obj.IdIsla, true, false);
                foreach (Libreria.Configuracion.Surtidor objSurtidor in objSurtidores)
                {
                    chkListaItems.Items.Add(new ListItem(objSurtidor.IdIsla.ToString(), objSurtidor.IdIsla.ToString()));
                }
            }

            //Libreria.Configuracion.Surtidores objs = new Servipunto.Estacion.Libreria.Configuracion.Surtidores();
            //chkListaItems.DataSource = objs;
            //chkListaItems.DataTextField = "IdSurtidor";
            //chkListaItems.DataValueField = "IdSurtidor";
            //chkListaItems.DataBind();
        }

        private void LlenarListaIsla()
        {
            Libreria.Configuracion.Islas objs = new Servipunto.Estacion.Libreria.Configuracion.Islas();
            chkListaItems.DataSource = objs;
            chkListaItems.DataTextField = "IdIsla";
            chkListaItems.DataValueField = "IdIsla";
            chkListaItems.DataBind();
        }

        protected void ddlTipoDescuento_TextChanged(object sender, EventArgs e)
        {
            LlenarListaItems();
        }

        private void LlenarListaItems()
        {
            int opcion = Convert.ToInt32(ddlTipoDescuento.SelectedValue);
            switch (opcion)
            {
                case 0:
                    lblTipoDescuento.Text = "Seleción General";
                    chkListaItems.Enabled = false;
                    chkChequeoLista.Enabled = false;
                    chkListaItems.DataSource = null;
                    chkListaItems.DataBind();
                    break;
                case 1:
                    lblTipoDescuento.Text = "Seleción Articulo";
                    chkListaItems.Enabled = true;
                    chkChequeoLista.Checked = false;
                    chkChequeoLista.Enabled = true;
                    LlenarListaArticulos();
                    break;
                case 2:
                    lblTipoDescuento.Text = "Seleción Manguera";
                    chkListaItems.Enabled = true;
                    chkChequeoLista.Checked = false;
                    chkChequeoLista.Enabled = true;
                    LlenarListaMangueras();
                    break;
                case 3:
                    lblTipoDescuento.Text = "Seleción Surtidor";
                    chkListaItems.Enabled = true;
                    chkChequeoLista.Checked = false;
                    chkChequeoLista.Enabled = true;
                    LlenarListaSurtidor();
                    break;

                case 4:
                    lblTipoDescuento.Text = "Seleción Isla";
                    chkListaItems.Enabled = true;
                    chkChequeoLista.Checked = false;
                    chkChequeoLista.Enabled = true;
                    LlenarListaIsla();
                    break;



            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == "null")
            {
                Guardar();
            }
            else
            {
                Modificar();
            } 
        }

        protected void chkTodosLosDias_CheckedChanged(object sender, EventArgs e)
        {

            if (chkTodosLosDias.Checked)
            {
                foreach (ListItem obj in chkListaDiasSemana.Items)
                    obj.Selected = true;

                chkListaDiasSemana.Enabled = false;
            }
            else
            {
                chkListaDiasSemana.Enabled = true;
            }
        }

        private void LLenarHorasMinutos()
        {
            ddlHoraInicio.Items.Clear();
            ddlHoraFinal.Items.Clear();
            ddlMinutoInicio.Items.Clear();
            ddlMinutoFinal.Items.Clear();

            for (int i = 0; i < 24; i++)
            {
                ddlHoraInicio.Items.Add(new ListItem(i.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0')));
                ddlHoraFinal.Items.Add(new ListItem(i.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0')));
            }

            for (int j = 0; j < 60; j += 5)
            {
                ddlMinutoInicio.Items.Add(new ListItem(j.ToString().PadLeft(2, '0'), j.ToString().PadLeft(2, '0')));
                ddlMinutoFinal.Items.Add(new ListItem(j.ToString().PadLeft(2, '0'), j.ToString().PadLeft(2, '0')));
            }
        }

        protected void ChkTodasHoras_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkTodasHoras.Checked)
            {
                ddlHoraInicio.Enabled = true;
                ddlHoraFinal.Enabled = true;
                ddlMinutoInicio.Enabled = true;
                ddlMinutoFinal.Enabled = true;
            }
            else
            {
                ddlHoraInicio.Enabled = false;
                ddlHoraFinal.Enabled = false;
                ddlMinutoInicio.Enabled = false;
                ddlMinutoFinal.Enabled = false;
            }

        }

        public void cargarRadioButon()
        {
            if (RadioButton1.Checked)
            {
                LabelValor.Visible = true;
                //TexValor.Visible = true;
                LabelPorc.Visible = false;
                //txtPorcentajeDescuento.Visible = false;
            }
            else if (RadioButton2.Checked)
            {
                LabelPorc.Visible = true;
                LabelValor.Visible = false;
                //txtPorcentajeDescuento.Visible = true;
                //LabelValor.Visible = false ;
                //TexValor.Visible = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == "null")
            {
                Guardar();
            }
            else
            {
                Modificar();
            } 

        }

    }
}
