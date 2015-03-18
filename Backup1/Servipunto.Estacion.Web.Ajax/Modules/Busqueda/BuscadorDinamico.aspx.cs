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
using Servipunto.Estacion.Libreria;
using Servipunto.Estacion.AccesoDatos.EntityClasses;
using Servipunto.Estacion.AccesoDatos.CollectionClasses;


namespace Servipunto.Cartera.Web.Modules.Busqueda
{
    public partial class BuscadorDinamico : System.Web.UI.Page
    {
        #region Seccion de Declaraciones
        /// <summary>
        /// En esta seccion se declaran todas las variables y objetos globales que sehan necesarios.
        /// </summary>
        protected BusquedaDinamica _objBusquedaDinamica = new BusquedaDinamica();
        Utilidades _objUtilidades = new Utilidades();

        private string SortField
        {
            get
            {
                object o = ViewState["SortField"];
                return (o == null) ? String.Empty : (string)o;
            }
            set
            {
                ViewState["SortField"] = value;
            }
        }

        private DataTable Tabla
        {
            get
            {
                object o = ViewState["Tabla"];
                return (DataTable)o;
            }
            set
            {
                ViewState["Tabla"] = value;
            }
        }

        #endregion

        #region Page_Load
        /// <summary>
        /// Evento de carga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblError.Text = "";
            if (!this.IsPostBack)
            {
                if (!this.VerificarPermisos())
                    return;
                txtBusquedaDesignada.Text = Request.QueryString["TipoDeBusqueda"] == null ? "SinDefinir" : Request.QueryString["TipoDeBusqueda"];
                this.InicializarForma();
                SortField = null;
                //grdResultadoBusqueda.DataSource = Tabla;
            }
        }
        #endregion

        #region InicializarForma
        /// <summary>
        /// Establece el estado inicial del formulario
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha: 08/06/2009
        /// Autor: Elvis Astaiza
        private void InicializarForma()
        {
            try
            {
                this.ConstruirEntorno();
            }
            catch (Exception ex)
            {
                this.SetError("Problemas al iniciar el formulario: " + ex.Message, false);
            }
        }
        #endregion

        #region ConstruirEntorno
        /// <summary>
        /// Configura el formulario deacuerdo al tipo de busqueda
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha: 08/06/2009
        /// Autor: Elvis Astaiza
        private void ConstruirEntorno()
        {
            BusquedaDesignada busquedaDesignada;
            try
            {
                busquedaDesignada = this._objBusquedaDinamica.RecuperarBusquedaDesignada(txtBusquedaDesignada.Text);
                lblTitulo.Text = "Buscar " + _objUtilidades.SepararPalabras(busquedaDesignada.ToString(), true) + "...";
                this.Limpiar();

                switch (busquedaDesignada)
                {

                    case BusquedaDesignada.Cliente:

                        ddlCriterioBusqueda.Items.Add("Cod_Cli");
                        ddlCriterioBusqueda.Items.Add("Nombre");
                        #region ConfigurarGridDinamico
                        /*
                        BoundColumn columnaDatos;
                        ButtonColumn columnaSeleccion;            
                         
                        columnaDatos = new BoundColumn();
                        columnaDatos.HeaderText = "Identificacion";
                        columnaDatos.DataField = "Identificacion";                        
                        grdResultadoBusqueda.Columns.Add(columnaDatos);

                        columnaDatos = new BoundColumn();
                        columnaDatos.HeaderText = "Nombre";
                        columnaDatos.DataField = "NombreGrupoEmpresarial";
                        grdResultadoBusqueda.Columns.Add(columnaDatos);
                        grdResultadoBusqueda.DataKeyField = "Identificacion";
                        
                        columnaSeleccion = new ButtonColumn();
                        columnaSeleccion.HeaderText = "Seleccionar";
                        columnaSeleccion.CommandName = "Seleccionar";
                        columnaSeleccion.Text = "Seleccionar";
                        grdResultadoBusqueda.Columns.Add(columnaSeleccion);
                     */
                        #endregion
                        break;

                    case BusquedaDesignada.Automotor:
                        ddlCriterioBusqueda.Items.Add("Placa");
                        break;


                    case BusquedaDesignada.Empleado:
                        ddlCriterioBusqueda.Items.Add("Cod_Emp");
                        ddlCriterioBusqueda.Items.Add("Nombre");
                        break;


                    default:
                        throw new Exception("Entorno no configurado para: " + busquedaDesignada.ToString());
                }
            }
            catch (Exception ex)
            {
                this.SetError("Problemas al iniciar el formulario: " + ex.Message, false);
            }
        }
        #endregion

        #region Buscar
        /// <summary>
        /// Configura el formulario deacuerdo al tipo de busqueda
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha: 08/06/2009
        /// Autor: Elvis Astaiza
        private void Buscar()
        {
            #region Declaracion de variables
            ArrayList parametros = new ArrayList();
            #endregion

            #region Asignacion de parametros
            parametros.Add(txtBusquedaDesignada.Text);
            parametros.Add(ddlCriterioBusqueda.SelectedValue);
            parametros.Add(txtDatoABuscar.Text.Trim());
            parametros.Add(ddlComodin.SelectedValue);
            #endregion

            #region Obtener los datos
            try
            {
                grdResultadoBusqueda.DataSource = _objBusquedaDinamica.RecuperarDatos(parametros);//.DefaultView.Sort = SortField;                        
                grdResultadoBusqueda.DataBind();
                lblTotalPaginas.Text = "Pag. " + Convert.ToString(grdResultadoBusqueda.CurrentPageIndex + 1) + "/" + grdResultadoBusqueda.PageCount.ToString();
            }
            catch (Exception ex)
            {
                this.SetError("Problemas al realizar la busqueda: " + ex.Message, false);
            }
            #endregion
        }
        #endregion

        #region Metodo validar
        /// <summary>
        /// Valida la informacion del formulario.
        /// </summary>
        /// <returns>True: la informacion es correcta, False: La informacion tiene problemas</returns>
        /// Referencia Documental: (Falta)
        /// Fecha: 08/06/2009
        /// Autor: Elvis Astaiza
        private bool validar()
        {
            /*
            if (txtNumeroInicial.Text.Trim().Length == 0)
                throw new Exception("Debe ingresar un numero inicial! gracias");
            if (txtCantidad.Text.Trim().Length == 0)
                throw new Exception("Debe ingresar una cantidad! gracias");
            if(int.Parse(txtCantidad.Text.Trim()) <= 0)
                throw new Exception("El numero de cantidad debe ser mayor a cero! gracias");*/
            return true;
        }
        #endregion

        #region Limpiar
        /// <summary>
        /// Asigna los datos por defecto para la interfaz del formulario
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha: 08/06/2009
        /// Autor: Elvis Astaiza
        private void Limpiar()
        {
            txtDatoABuscar.Text = "";
            ddlCriterioBusqueda.Items.Clear();
            //lblTitulo.Text = "Buscar " + txtBusquedaDesignada.Text + "...";
        }
        #endregion

        #region Cifrado, permisos y SetError

        #region Método DecryptText
        /// <summary>
        /// Desencripta el query string 
        /// </summary>
        /// <param name="strText">texto a desencriptar</param>
        /// <returns>texto desencriptado</returns>
        /// Referencia Documental: 
        /// Fecha: 
        /// Autor: Carlos Anibal Gomez Ocampo.
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
        /// Referencia Documental: 
        /// Fecha: 
        /// Autor: Carlos Anibal Gomez Ocampo.
        public string EncryptText(string strText)
        {
            return Servipunto.Libreria.Cryptography.EncryptQueryString(strText, "!#$a54?3");
        }
        #endregion

        #region SetError and ClearError
        /// <summary>
        /// Visualiza en un Label el mensaje de error enviado al parametro.
        /// </summary>
        /// <param name="message">Mensaje que se muestra en el Label</param>
        /// <param name="hideForm">Propiedad que segun su valor (true, false) muestra o no los controles del formulario.</param>
        /// Fecha: 
        /// Autor: Carlos Anibal Gomez Ocampo.
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.MyForm.Visible = false;
        }

        /// <summary>
        /// Borra la informacion que exista en la propiedad Text del lblError(Label) y su propiedad Visible le asigna el valor de false
        /// para que no sea visto por el usuario.
        /// </summary>
        ///Fecha:  
        ///Autor: Carlos AnibalGomez Ocampo.
        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
        }
        #endregion

        #region VerificarPermisos
        /// <summary>
        /// Verifica si el el usuario con que hicimos logon tiene permisos para para entrar a la opcion TipoIdentificacion.
        /// </summary>
        /// <returns>True si el usuario tiene permiso y False si el usuario no tiene permisos suficientes.</returns>
        /// Referencia Documental: (Falta)
        /// Fecha: 05/06/2009
        /// Autor: Elvis Astaiza Gutierrez.
        private bool VerificarPermisos()
        {
            Usuarios objUsuarios = new Usuarios();
            /*
            if (!objUsuarios.ObtenerPermisosUsuario(((UsuarioEntity)Session["Usuario"]).IdRol, "Formulario Flotante", "Consultas", "Consultar"))
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.", false);
                btnBuscar.Enabled = false;
                return false;
            }*/
            //if (Session["Usuario"] == null)
            //{
            //    this.SetError("<b>Acceso Denegado.</b><br><br>Debe haber iniciado sesión para ingresar a esta pagina.", false);
            //    btnBuscar.Enabled = false;
            //    return false;
            //}
            return true;
        }
        #endregion

        #endregion

        #region CerrarYRetornar
        /// <summary>
        /// Retorna informacion y cierra el formulario flotante
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha: 08/06/2009
        /// Autor: Elvis Astaiza
        private void CerrarYRetornar(string valorARetornar)
        {
            System.Text.StringBuilder Script = new System.Text.StringBuilder();
            Script.Append("\n" + "<script language=Javascript>");
            Script.Append("\n" + "function Close()");
            Script.Append("\n" + "{");
            Script.Append("\n" + "window.returnValue = '" + valorARetornar + "';");
            Script.Append("\n" + "window.close();");
            Script.Append("\n" + "}");
            Script.Append("\n" + "</script>");
            Script.Append("\n" + "<script>Close()</script>");
            Response.Write(Script.ToString());
            this.Dispose();
        }
        #endregion

        #region Eventos de los controles
        protected void grdResultadoBusqueda_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            if (this.IsPostBack)
            {
                this.grdResultadoBusqueda.CurrentPageIndex = 0;
                this.grdResultadoBusqueda.CurrentPageIndex = e.NewPageIndex;
                this.Buscar();
            }
        }

        protected void grdResultadoBusqueda_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            BusquedaDesignada busquedaDesignada;
            try
            {
                if (e.CommandName == "Seleccionar")
                {
                    busquedaDesignada = this._objBusquedaDinamica.RecuperarBusquedaDesignada(txtBusquedaDesignada.Text);
                    switch (busquedaDesignada)
                    {

                        case BusquedaDesignada.Cliente:
                            this.CerrarYRetornar(e.Item.Cells[1].Text.TrimEnd() + "©" + e.Item.Cells[2].Text);
                            break;

                        case BusquedaDesignada.Empleado:
                            this.CerrarYRetornar(e.Item.Cells[1].Text + "©" + e.Item.Cells[2].Text);
                            break;


                        default:
                            throw new Exception("Busqueda no configurada: " + busquedaDesignada.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetError("Problemas al retornar el dato seleccionado: " + ex.Message, false);
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdResultadoBusqueda.CurrentPageIndex = 0;
            this.Buscar();
        }

        protected void lnkSiguiente_Click(object sender, EventArgs e)
        {
            this.CambiarPagina(1);
        }

        protected void lnkAnterior_Click(object sender, EventArgs e)
        {
            this.CambiarPagina(-1);
        }

        private void CambiarPagina(int valor)
        {
            int indicePagina;
            if (grdResultadoBusqueda.PageCount <= 1)
                return;
            indicePagina = grdResultadoBusqueda.CurrentPageIndex + valor;
            if (indicePagina >= grdResultadoBusqueda.PageCount)
                indicePagina = 0;
            else if (indicePagina < 0)
                indicePagina = grdResultadoBusqueda.PageCount - 1;
            this.grdResultadoBusqueda.CurrentPageIndex = indicePagina;
            this.Buscar();
        }

        protected void grdResultadoBusqueda_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            //SortField = e.SortExpression;
            //this.Buscar();
            //grdResultadoBusqueda.table .SortExpression = e.SortExpression;            
        }
        #endregion
    }
}
