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

namespace Servipunto.Estacion.Web.Ajax.Modules.Procesos
{
    public partial class RegistroCompraCanastilla : System.Web.UI.Page
    {
        protected WebApplication.FormMode _mode;
        protected Libreria.RegistroCompraCanastilla _objRegistroIngreso = null;
        protected string _id = null;
        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (Request.QueryString["Id"] == null )
                    this._mode = WebApplication.FormMode.New;
                else
                    this._mode = WebApplication.FormMode.Edit;

                if (!this.IsPostBack)
                {
                    if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                    {
                        this._id = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                      
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
            this.dtgInventarioCanastilla.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dtgInventarioCanastilla_EditCommand);
            //this.imgFechaInicio.Click += new System.Web.UI.ImageClickEventHandler(this.imgFechaInicio_Click1);
            this.img.Click += new System.Web.UI.ImageClickEventHandler(this.img_Click);
            this.cldFechaInicio.SelectionChanged += new System.EventHandler(this.cldFechaInicio_SelectionChanged);
            this.dtgInventarioCanastilla.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dtgInventarioCanastilla_EditCommand);
            //this.dtgTanques.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dtgTanques_DeleteCommand);
            //this.lnkbActualiza1.Click += new System.EventHandler(this.lnkbActualiza1_Click);
            //this.lnkbActualiza2.Click += new System.EventHandler(this.lnkbActualiza2_Click);
            //this.lnkIActualizarInventarioCanastilla.Click += new EventHandler(this.lnkIActualizarInventarioCanastilla_Click);

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
                this.lblBack.NavigateUrl = "default.aspx";
                CargarZeta();
                CargarGrillaInventario();
               
                    #region Modo de Inserción
                    this.lblFormTitle.Text = "<b>Actualizar Registro Inventario de Canastilla</b>";
                    this.Button1.Text = "Actualizar";                    
                    #endregion
                
            }
        }
        #endregion

        #region Cargar Grilla
        /// <summary>
        /// Lista los tanques configurados en el sitema con sus respectivos registros de entradas y salidas para la fecha
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void CargarGrillaInventario()
        {
            try
            {
                DataTable ds = Libreria.InventarioItemsCanastilla.ObtenerDataTableInventarioItemCanastilla(Convert.ToDateTime(txtFechaJornada.Text));
                this.dtgInventarioCanastilla.DataSource = ds;
                this.dtgInventarioCanastilla.DataKeyField = "cod_art";
                this.dtgInventarioCanastilla.DataBind();
              //  txtVariacionesRegistradas.Text = ds.Tables[1].Rows[0]["TotalConVariacionReal"].ToString();
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
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

        private void CargarZeta()
        {
            Libreria.Turnos.JornadaZeta objJornadaZeta = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(2);
            cldFechaInicio.Visible = false;

            if (objJornadaZeta != null)
            {
                txtFechaJornada.Text = objJornadaZeta.Fecha.ToString("dd/MM/yyyy");
            }

            else if (objJornadaZeta == null)
            {
                this.txtFechaJornada.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        #region Guardar
        private void Guardar()
        {
            if (this.Validar())
            {
                try
                {
                    Libreria.InventarioItemCanastilla reg = new  Servipunto.Estacion.Libreria.InventarioItemCanastilla();
                    reg.Fecha = Convert.ToDateTime(this.txtFechaJornada.Text);
                    reg.Cod_Art = Convert.ToInt16(lblCod_Art.Text);
                    reg.CompraFactura = Convert.ToDecimal(txtCompraFactura.Text);                    
                    reg.SaldoFisico = Convert.ToDecimal(txtSaldoFisico.Text);
                    reg.Salidas = Convert.ToDecimal(txtVentas.Text);
                    reg.SaldoSistema = reg.CompraFactura - reg.Salidas;                   
                    reg.Sobrante = reg.SaldoFisico > reg.SaldoSistema ? reg.SaldoFisico - reg.SaldoSistema : 0;
                    reg.Faltante = reg.SaldoSistema > reg.SaldoFisico ? reg.SaldoSistema - reg.SaldoFisico : 0;
                    reg.Modificar();
                    txtSobrante.Text = reg.Sobrante.ToString();
                    txtFaltante.Text = reg.Faltante.ToString();
                    txtSaldoSistema.Text = reg.SaldoSistema.ToString();

                   
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
                    this._objRegistroIngreso = null;
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
                this.SetError("No existen jornadas Zeta Abiertas!", true);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        #region gdvVales_DataBinding
        protected void grdFacturas_DataBinding(object sender, EventArgs e)
        {
            //dtgTanques.Columns[0].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(81, 1);
            //dtgTanques.Columns[1].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, 1);
            //dtgTanques.Columns[2].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1445, 1);
            //dtgTanques.Columns[3].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2106, 1);
            //dtgTanques.Columns[4].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2107, 1);
            //dtgTanques.Columns[5].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2108, 1);
            //dtgTanques.Columns[6].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1448, 1);
            //dtgTanques.Columns[7].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1449, 1);
            ////dtgTanques.Columns[9].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, 1);
            //dtgTanques.Columns[10].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, 1);
            //dtgTanques.Columns[11].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2109, 1);
        }
        #endregion


        #region dtgTanques_EditCommand
        private void dtgInventarioCanastilla_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            try
            {
                
                if (e.CommandName == "Edit")
                {
                    lblCod_Art.Text = e.Item.Cells[0].Text;
                    txtArticulo.Text = e.Item.Cells[1].Text;
                    txtCompraFactura.Text = e.Item.Cells[2].Text;
                    txtVentas.Text = e.Item.Cells[3].Text;
                    txtSaldoSistema.Text = e.Item.Cells[4].Text;
                    txtSaldoFisico.Text = e.Item.Cells[5].Text;
                    txtSobrante.Text = e.Item.Cells[6].Text;
                    txtFaltante.Text = e.Item.Cells[7].Text;                    

                }
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2116, Global.Idioma) + ex.Message, false);
            }
        }
        #endregion

        #region imgFechaInicio_Click
        //private void imgFechaInicio_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    cldFechaInicio.Visible = !cldFechaInicio.Visible;
        //}
        #endregion

        #region cldFechaInicio_SelectionChanged
        private void cldFechaInicio_SelectionChanged(object sender, System.EventArgs e)
        {
            txtFechaJornada.Text = cldFechaInicio.SelectedDate.ToString("dd/MM/yyyy");//.ToString("dddd, MMMM dd yyyy", new System.Globalization.CultureInfo("es-CO", false));            
            cldFechaInicio.Visible = false;
            CargarGrillaInventario();
        }
        #endregion

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Guardar();
        }

        //protected void imgFechaInicio_Click1(object sender, ImageClickEventArgs e)
        //{
        //    cldFechaInicio.Visible = !cldFechaInicio.Visible;

        //}

        protected void img_Click(object sender, ImageClickEventArgs e)
        {
            cldFechaInicio.Visible = !cldFechaInicio.Visible;
            cldFechaInicio.Visible = true;
        }

        
        
    }
}
