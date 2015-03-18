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
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;


namespace Servipunto.ZencilloCartera.Web.PaginaMaestra
{
    public partial class MasterInicio : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                logo();
                logoComapnia();
                CargarIdioma();
            }

        }
        protected void ImgServipunto_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("www.servipunto.com");
        }

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
            //    if (objDSuscrip.Count > 0)
            //    {
            //        if (Convert.ToString(objDSuscrip[0].Version) == "L" || Convert.ToString(objDSuscrip[0].Version) == "Lite")
            //        {
            //            pnlLogoLite.Visible = true;
            //            pnlLogoFull.Visible = false;
            //        }
            //        else
            //        {
            //            pnlLogoLite.Visible = false;
            //            pnlLogoFull.Visible = true;
            //        }
            //    }
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
            //        if (Convert.ToString(objDGeneral[0].RutaLogoCompania) != null || Convert.ToString(objDGeneral[0].RutaLogoCompania) != "")
            //        {
            //            try
            //            {

            //                validarCadena = objClaseDato.LogoCompania();
            //                validarCaracter = validarCadena.IndexOf('.');
            //                if (validarCaracter != -1)
            //                {
            //                    this.imgLogoCompania.ImageUrl = validarCadena;
            //                }
            //                else
            //                {
            //                    lblLogoCompania.Text = "Logo de Compañia no Disponible!";
            //                    lblLogoCompania.Visible = true;
            //                    lblLogoCompania.ForeColor = System.Drawing.Color.Red;
            //                    this.imgLogoCompania.ImageUrl = "~/Estilos/Estilo1/Imagenes/Logo.png";
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                ///Mensaje1.ShowMessage("El logo de la compañia no se puede cargar, verificar en datos generales la ruta del logo y su extencion. Ejemplo : C:/Logo.bmp ", "Atencion!!");
            //                this.imgLogoCompania.ImageUrl = "~/Estilos/Estilo1/Imagenes/Logo.png";
            //            }
            //        }
            //        else
            //        {
            //            this.imgLogoCompania.ImageUrl = "~/Estilos/Estilo1/Imagenes/Logo.png";
            //        }
            //    }
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

            LblMensajePagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1699, 1);
            lblVersion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1700, 1);
            lblAVisoLegal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1701, 1);
            hipServipunto.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1703, 1);
            lblDerechos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1702, 1);
        }
    }
}
