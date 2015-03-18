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
/*using Servipunto.Zencillo.AccesoDatos.Libreria.CollectionClasses;
using Servipunto.Zencillo.Logica.Libreria.Colecciones;*/

namespace Servipunto.Zencillo.Colombia.PaginaMaestra
{
    public partial class AsistenteDeConfiguracion : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logo();
                logoComapnia();
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
               
            //}

            #endregion

        }
        #endregion
    }
}
