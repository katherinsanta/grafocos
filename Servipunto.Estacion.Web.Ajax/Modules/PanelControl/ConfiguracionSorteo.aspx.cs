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
    public partial class ConfiguracionSorteo : System.Web.UI.Page
    {
        protected WebApplication.FormMode _mode;
        protected Servipunto.Estacion.Libreria.Configuracion.ConfiguracionSorteo _objAlarma = null;
        protected Servipunto.Estacion.Libreria.TiposDeAutomotor _objTipoAutomotor = null;
        protected Servipunto.Estacion.Libreria.FormasPago _objFormasPago = null;
        protected Servipunto.Estacion.Libreria.Articulos _objArticulos = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.VerificarPermisos())
            {
                try
                {
                    if (Request.QueryString["IdSorteo"] == null && lblHide.Text == "")
                        this._mode = WebApplication.FormMode.New;
                    else
                    {
                        this._mode = WebApplication.FormMode.Edit;
                        if (lblHide.Text == "")
                            lblHide.Text = Request.QueryString["IdSorteo"];
                    }


                    if (!this.IsPostBack)
                    {
                        //if (ViewState["ControlMaster"].ToString() != "1")
                        //{
                            CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                         

                            _objArticulos = new Servipunto.Estacion.Libreria.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
                            lstArticulos.DataSource = _objArticulos;
                            lstArticulos.DataTextField = "Descripcion";
                            lstArticulos.DataValueField = "IdArticulo";
                            lstArticulos.DataBind();

                            this.InicializarForma();
                          
                        //}
                    }
                }
                catch (Exception ex)
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

        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = "Conf. Venta Gratis";
            bool permiso;

            //Se comenta dado que no se ha realizado la insercion en Permisos
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

        #region Método de Inicialización de Forma
        private void InicializarForma()
        {
            if (this.VerificarPermisos())
            {
               
                if (Request.UrlReferrer != null)
                    this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
                else
                    this.lblBack.NavigateUrl = "ConfiguracionSorteos.aspx";
                //ViewState["ControlMaster"] = "1";
                if (this._mode == WebApplication.FormMode.New)
                    this.InicializarModoInsercion();
                else
                    this.InicializarModoEdicion();
            }
        }
        #endregion


        #region Método Inicializar Modo de Edición
        private void InicializarModoEdicion()
        {
            if (this.ObtenerElemento())
            {
                txtConsecutivoActual.Enabled = true;
                this.txtValorMinimo.Text = this._objAlarma.ValorMinimo.ToString();                
                this.txtConsecutivoInicial.Text = this._objAlarma.ConsecutivoInicial.ToString();
                this.txtConsecutivoActual.Text = this._objAlarma.ConsecutivoActual.ToString();

                this.rblEstado.SelectedValue = this._objAlarma.Estado == false ? "0" : "1";
                this.rbtMultiplesBoletas.SelectedValue = this._objAlarma.MultiplesBoletas == false ? "0" : "1";
                string strCodForPag;
                strCodForPag = this._objAlarma.Articulos;
                string[] ParametrosSeleccionados = strCodForPag.Split(';');
                for (int i = 0; i < ParametrosSeleccionados.Length; i++)
                {
                    if (ParametrosSeleccionados[i] != "")
                        this.lstArticulos.Items.FindByValue(ParametrosSeleccionados[i]).Selected = true;
                }
                this.txtFechaInicial.Text = this._objAlarma.FechaInicio.ToShortDateString();
                this.txtFechaFinal.Text = this._objAlarma.FechaFinal.ToShortDateString();
                
               
                this.lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(999, Global.Idioma) + " No: " + this._objAlarma.IdSorteo.ToString();
            }
        }
        #endregion

        #region Método Obtener Elemento
        private bool ObtenerElemento()
        {
            try
            {
                this._objAlarma = Libreria.Configuracion.ConfiguracionSorteos.Obtener(Convert.ToByte(lblHide.Text));
                if (this._objAlarma == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objAlarma + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objAlarma + "]", true);
                return false;
            }
        }
        #endregion

         #region Método Inicializar Modo de Edición
        private void InicializarModoInsercion()
        {
            txtConsecutivoActual.Text = "1";
            txtConsecutivoInicial.Text = "1";
        }
        #endregion

        protected void lblGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (this._mode == WebApplication.FormMode.New)
                    {
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 147, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this.Insertar();
                        Response.Redirect("ConfiguracionSorteos.aspx");
                    }
                    else
                    {
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 148, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this.Modificar();
                        Response.Redirect("ConfiguracionSorteos.aspx");
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
                }
                finally
                {
                    this._objAlarma = null;
                }
            }
        }

        private bool ValidarDatos()
        {

          
            if (this.txtValorMinimo.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtValorMinimo.Text.Trim()))
                {
                    this.SetError("Valor Minimo  no valido", false);
                    return false;
                }                
            }
            else
            {
                this.SetError("Valor Minimo no establecido", false);
                return false;
            }     


            if (lstArticulos.SelectedIndex < 0)
            {
                this.SetError("Debe seleccionar al menos un articulo de la lista de articulos", false);
                return false;
            }

            if (this.txtConsecutivoInicial.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtConsecutivoInicial.Text.Trim()))
                {
                    this.SetError("Consecutivo Inicial no valido", false);
                    return false;
                }
            }
            else
            {
                this.SetError("Consecutivo Inicial no establecido", false);
                return false;
            }

            if (this.txtConsecutivoActual.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtConsecutivoActual.Text.Trim()))
                {
                    this.SetError("Consecutivo Actual no valido", false);
                    return false;
                }
            }
            else
            {
                this.SetError("Consecutivo Actual no establecido", false);
                return false;
            }

            if (this.txtFechaInicial.Text.Trim().Length == 0 || this.txtFechaFinal.Text.Trim().Length == 0)
            {
            
                    this.SetError("Rango de fechas vacias o no validas", false);
                    return false;
                
            }

            if (DateTime.Compare(DateTime.Parse(this.txtFechaInicial.Text), DateTime.Parse(this.txtFechaFinal.Text)) > 0)
            {

                this.SetError("Fecha Inicial no puede ser superior a la fecha final", false);
                return false;

            }

            return true;
        }


        #region Método Modificar
        private void Modificar()
        {
            if (this.ObtenerElemento())
            {
                this._objAlarma.ValorMinimo = Convert.ToDecimal(this.txtValorMinimo.Text);
                this._objAlarma.FechaInicio = Convert.ToDateTime(this.txtFechaInicial.Text);
                this._objAlarma.FechaFinal = Convert.ToDateTime(this.txtFechaFinal.Text);
                this._objAlarma.ConsecutivoInicial = Convert.ToInt32(this.txtConsecutivoInicial.Text);
                this._objAlarma.ConsecutivoActual = Convert.ToInt32(this.txtConsecutivoActual.Text);
                this._objAlarma.Estado = this.rblEstado.SelectedItem.Value == "0" ? false : true;
                this._objAlarma.MultiplesBoletas = this.rbtMultiplesBoletas.SelectedItem.Value == "0" ? false : true;
                string strCodForPag;
                strCodForPag = "";
                for (int i = 0; i < lstArticulos.Items.Count; i++)
                {
                    if (lstArticulos.Items[i].Selected)
                        strCodForPag += lstArticulos.Items[i].Value + ";";
                }

                this._objAlarma.Articulos = strCodForPag;              
                this._objAlarma.Modificar();
            }
        }
        #endregion

        #region Método Insertar
        private void Insertar()
        {
            this._objAlarma = new Servipunto.Estacion.Libreria.Configuracion.ConfiguracionSorteo();
            this._objAlarma.ValorMinimo = Convert.ToDecimal(this.txtValorMinimo.Text);
            this._objAlarma.FechaInicio = Convert.ToDateTime(this.txtFechaInicial.Text);
            this._objAlarma.FechaFinal = Convert.ToDateTime(this.txtFechaFinal.Text);
            this._objAlarma.ConsecutivoInicial = Convert.ToInt32(this.txtConsecutivoInicial.Text);
            this._objAlarma.ConsecutivoActual = Convert.ToInt32(this.txtConsecutivoActual.Text);
            this._objAlarma.Estado = this.rblEstado.SelectedItem.Value == "0" ? false : true;
            this._objAlarma.MultiplesBoletas = this.rbtMultiplesBoletas.SelectedItem.Value == "0" ? false : true;
            string strCodForPag;
            strCodForPag = "";
            for (int i = 0; i < lstArticulos.Items.Count; i++)
            {
                if (lstArticulos.Items[i].Selected)
                    strCodForPag += lstArticulos.Items[i].Value + ";";
            }

            this._objAlarma.Articulos = strCodForPag;
            this._objAlarma.Modificar();
            Libreria.Configuracion.ConfiguracionSorteos.Adicionar(this._objAlarma);
        }
        #endregion
    }
}
