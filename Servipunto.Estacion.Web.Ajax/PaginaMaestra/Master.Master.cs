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
using Servipunto.Estacion.AccesoDatos.HelperClasses;
using Servipunto.Estacion.AccesoDatos.EntityClasses;
using Servipunto.Estacion.AccesoDatos.CollectionClasses;
//using Servipunto.ReconversionTarija.Logica.Clases;

namespace Servipunto.AdministrativoEstacion.Web.PaginaMaestra
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Visualizando Datos de Session
                #region verificar session
                if (Session["Usuario"] == null)
                {
                    lblUsuario.Text = "?????";
                    lblRol.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2368, 1) + " !!";
                    
                    if (Session["Usuario"] == null)
                    {
                        Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                    }

                }
                #endregion
                if (Session["Usuario"] != null)
                {
                    lblUsuario.Text = ((Servipunto.Estacion.Libreria.Usuario)Session["Usuario"]).Nombre.ToString();
                    lblRol.Text = ((Servipunto.Estacion.Libreria.Usuario)Session["Usuario"]).Rol.ToString();
                    lblFecha.Text = DateTime.Now.ToShortDateString();
                }
                #endregion
                logo();                
                CargarIdioma();
                ConectarBaseDatos();
                CargarMenu();
                logoComapnia();

                //ClpPanelControl.Collapsed = false;
            }
        }
        private void ConectarBaseDatos()
        {
            string conexion = "";
            conexion =Servipunto.Libreria.Cryptography.Decrypt(System.Configuration.ConfigurationManager.AppSettings["administ"]);
            DbUtils.ActualConnectionString = conexion;
        }
        private void CargarMenu()
        {
            //DataSet dsOpciones = new DataSet();
            //dsOpciones.ReadXml(HttpContext.Current.Server.MapPath(@"../../PaginaMaestra/Xml/Opciones.xml"));
            //grdPanelControl.DataSource = dsOpciones;
            //grdPanelControl.DataBind();

            //grdProcesosMenu.DataSource = AccesoDatos.StoredProcedureCallerClasses.RetrievalProcedures.RecuperarPermisosParaMenu(Convert.ToInt32(Session["IdRol"].ToString()), 2);
            //grdProcesosMenu.DataBind();

            //grdConsultasMenu.DataSource = AccesoDatos.StoredProcedureCallerClasses.RetrievalProcedures.RecuperarPermisosParaMenu(Convert.ToInt32(Session["IdRol"].ToString()), 3);
            //grdConsultasMenu.DataBind();

            //grdReportesMenu.DataSource = AccesoDatos.StoredProcedureCallerClasses.RetrievalProcedures.RecuperarPermisosParaMenu(Convert.ToInt32(Session["IdRol"].ToString()), 4);
            //grdReportesMenu.DataBind();

            //DetalleSuscripcionEntity objSuscripcion = Servipunto.Zencillo.Logica.Libreria.Colecciones.DetalleSubscripciones.RecuperarSubscripcionActiva();
            //if (objSuscripcion != null)
            //{
            //    pnlFiltro.Visible = (objSuscripcion.Version == "F");
            //    PnlFiltroClientes.Visible = (objSuscripcion.Version == "F");
            //    PanelFacturacionFull.Visible = (objSuscripcion.Version == "F");

            //}
        }

        protected void grdPanelControl_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "Cabeza";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            {
                e.Row.CssClass = "FilaNormal";
            }
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                e.Row.CssClass = "FilaNormal";
            }
            e.Row.Cells[0].CssClass = "CeldaIcono";
            e.Row.Cells[1].CssClass = "CeldaOpcion";
        }

        protected void LnkBtnContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Main/CambiarContrasena.aspx");
        }
        
        protected void LnkCerrar_Click(object sender, EventArgs e)
        {
            Session["IdUsuario"] = null;
            Session["Usuario"] = null;
            Session.Clear();
            Response.Redirect("~/Modules/Main/Login.aspx");
        }

        protected void ImgServipunto_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("www.servipunto.com");
        }

        protected void ImgHome_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

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

        #region mostrar logo dependiendo de la version
        /// <summary>
        /// permite validar version y mostrar el logo correspondiente.
        /// rodrigo cerquera
        /// 21012010
        /// </summary>
        protected void logo()
        {
            #region declarar variable
            //DetalleSuscripcionCollection objDSuscrip = new DetalleSuscripcionCollection();
            //objDSuscrip.GetMulti(null);
            #endregion

            #region Validacion
            //if (objDSuscrip != null)
            //{
                //if (objDSuscrip.Count > 0)
                //{
                //    if (Convert.ToString(objDSuscrip[0].Version) == "L" || Convert.ToString(objDSuscrip[0].Version) == "Lite")
                //    {
                //        pnlLogoLite.Visible = true;
                //        pnlLogoFull.Visible = false;                       
                //    }
                //    else
                //    {
                //        pnlLogoLite.Visible = false;
                //        pnlLogoFull.Visible = true;
                //    }
                //}
            //}

            #endregion

        }
        #endregion

        #region mostrar logo dependiendo de la compania
        /// <summary>
        /// permite validar que logo debe colocar el de la compania configuarado o el predeterminado.
        /// rodrigo cerquera
        /// 21012010
        /// </summary>
        protected void logoComapnia()
        {
            #region declarar variable
            //DatoGeneralCollection objDGeneral = new DatoGeneralCollection();
            //Servipunto.Zencillo.Logica.Libreria.Colecciones.DatosGenerales objClaseDato = new DatosGenerales();
            //objDGeneral.GetMulti(null);
            //string validarCadena = null;
            //int validarCaracter = -1;
            #endregion

            #region Validacion
            //if (objDGeneral != null)
            //{
            //    if (objDGeneral.Count > 0)
            //    {
                    //if (Convert.ToString(objDGeneral[0].RutaLogoCompania) != null || Convert.ToString(objDGeneral[0].RutaLogoCompania) != "")
                    //{
                    //    try
                    //    {

                    //        validarCadena = objClaseDato.LogoCompania();
                    //        validarCaracter = validarCadena.IndexOf('.');
                    //        if (validarCaracter != -1)
                    //        {
                    //            this.imgLogoCompania.ImageUrl = validarCadena;
                    //        }
                    //        else
                    //        {
                    //            lblLogoCompania.Text = "Logo de Compañia no Disponible!";
                    //            lblLogoCompania.Visible = true;
                    //            lblLogoCompania.ForeColor = System.Drawing.Color.Red;
                    //            this.imgLogoCompania.ImageUrl = "~/Estilos/Estilo1/Imagenes/Logo.png";
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        //Mensaje1.ShowMessage("El logo de la compañia no se puede cargar, verificar en datos generales la ruta del logo y su extencion. Ejemplo : C:/Logo.bmp ", "Atencion!!");
                    //        this.imgLogoCompania.ImageUrl = "~/Estilos/Estilo1/Imagenes/Logo.png";
                    //    }
                    //}
                    //else
                    //{
                    //    this.imgLogoCompania.ImageUrl = "~/Estilos/Estilo1/Imagenes/Logo.png";
                    //}
               // }
            //}

            #endregion

        }
        #endregion

        private void CargarIdioma()
        {
            lblPestPanelControl.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(5, 1);
            lblPestComercial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(6, 1);
            lblPestProcesos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(3, 1);
            lblPestReportes.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2, 1);
            lblPestVariaciones.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(4, 1);
            lblPestConsultas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1694, 1);
            HyperLink1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(576, 1);
            HyperLink2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(750, 1);
            HyperLink4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1022, 1);
            HyperLink5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, 1);
            HyperLink6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(528, 1);
            HyperLink54.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(548, 1);
            HyperLink3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(583, 1);
            HyperLink25.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(563, 1);
            HyperLink33.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(534, 1);
            HyperLink34.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(512, 1);
            HyperLink47.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(578, 1);
            HyperLink52.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(542, 1);
            HyperLink59.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(538, 1);
            HyperLink57.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1403, 1);
            HyperLink58.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1029, 1);
            HyperLink55.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1030, 1);
            HyperLink60.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(631, 1);
            HyperLink61.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1519, 1);
            HyperLink63.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1034, 1);
            HyperLink64.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1035, 1);
            HyperLink65.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1036, 1);
            HyperLink66.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(27, 1);
            HyperLink8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(579, 1);
            HyperLink32.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(256, 1);
            HyperLink36.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(8, 1);
            HyperLink37.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(170, 1);
            HyperLink38.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, 1);
            HyperLink41.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(980, 1);
            HyperLink51.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(256, 1);
            HyperLink42.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(867, 1);
            HyperLink44.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(868, 1);
            HyperLink46.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(870, 1);
            HyperLink15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(993, 1);
            HyperLink16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1006, 1);
            HyperLink7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1026, 1);
            HyperLink21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1696, 1);
            HyperLink9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(307, 1);
            HyperLink10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(239, 1);
            HyperLink11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(384, 1);
            HyperLink12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(435, 1);
            HyperLink45.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(869, 1);
            lblMvPanelControl.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(5, 1);
            lblMvComercial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(6, 1);
            lblMvProcesos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1051, 1);
            lblMvReportes.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(7, 1);
            lblMvVariaciones.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(992, 1);
            lblMvConsultas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1694, 1);
            LnkCerrar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(769, 1);
            LblMensajePagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1699, 1);
            
            lblVersion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1700, 1);
            lblAVisoLegal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1701, 1);
            hipServipunto.Text =Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1703, 1);
            lblDerechos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1702, 1);

        }

        

    }
}
