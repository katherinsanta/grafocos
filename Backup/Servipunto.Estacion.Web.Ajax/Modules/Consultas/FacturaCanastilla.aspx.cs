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

namespace Servipunto.Estacion.Web.Modules.Consultas
{
    public partial class FacturaCanastilla : System.Web.UI.Page
    {
        DataTable _objFilaDatos = null;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["IdFactura"] != null)
                {
                    this.InicializarForma();

                }
            }
        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2021, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(966, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2080, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2081, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2082, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(154, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(851, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1244, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(977, Global.Idioma);
                        
        }
        #endregion
        #region Inicialización del Formulario
        private void InicializarForma()
        {
            //if (this.VerificarPermisos())
            //{

            this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2079, Global.Idioma) + "</b>";
            this.lblBack.NavigateUrl = "FacturasCanastilla.aspx";
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            int consecutivo = Convert.ToInt32(Request.QueryString["IdFactura"].ToString());
            string prefijo = "";
            if (this.ObtenerObjetoVentaCanastilla(prefijo, consecutivo))
            {
                lblNumero.Text = _objFilaDatos.Rows[0]["Prefijo"] + " " + _objFilaDatos.Rows[0]["Consecutivo"].ToString();
                lblEstado.Text = _objFilaDatos.Rows[0]["Estado"].ToString();
                lblNombreCliente.Text = _objFilaDatos.Rows[0]["Nombre"].ToString();
                lblPlaca.Text = _objFilaDatos.Rows[0]["Placa"].ToString();
                lblCod_Cli.Text = _objFilaDatos.Rows[0]["Cod_Cli"].ToString();
                lblFormaPago.Text = _objFilaDatos.Rows[0]["FormaPago"].ToString();
                lblSubTotal.Text = decimal.Parse(_objFilaDatos.Rows[0]["SubTotal"].ToString()).ToString("c");
                lblIva.Text = decimal.Parse(_objFilaDatos.Rows[0]["TotalIva"].ToString()).ToString("c");
                lblTotal.Text = decimal.Parse(_objFilaDatos.Rows[0]["Total"].ToString()).ToString("c");

                  Convert.ToInt32(_objFilaDatos.Rows[0]["IdNumOrden"]);
                  Libreria.Configuracion.Bol_NumOrden  objOrden = Libreria.Configuracion.Bol_NumOrdenes.Obtener(Convert.ToInt32(_objFilaDatos.Rows[0]["IdNumOrden"]));
                  if (objOrden != null)
                  {
                      lblFechaEmision.Text = _objFilaDatos.Rows[0]["Fecha"].ToString();
                      lblFechaResolucion.Text = objOrden.FechaInicial.ToShortDateString();
                      lblFechaVencimiento.Text = objOrden.FechaFinal.ToShortDateString();
                  }
                
                grdDetalle.DataSource = Libreria.Ventas.VentaCanastillaItems("", consecutivo);
                grdDetalle.DataBind();
            }
        }

        #endregion

        /// <summary>
        /// Obtener venta canastilla
        /// </summary>
        /// <param name="consecutivo"></param>
        /// <returns></returns>
        private bool ObtenerObjetoVentaCanastilla(string prefijo, int consecutivo)
        {
            try
            {
                DataSet objDatos = Libreria.Ventas.ObtenerVentaCanastilla(prefijo, consecutivo);

                if (objDatos != null)
                {
                    if (objDatos.Tables.Count > 0)
                    {
                        _objFilaDatos = objDatos.Tables[0];
                        return true;
                    }

                }
            }

            catch
            {

            }
            return false;           
            
        }

        #region gdvVales_DataBinding
        protected void grdFacturas_DataBinding(object sender, EventArgs e)
        {

            grdDetalle.Columns[0].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(263, Global.Idioma);
            grdDetalle.Columns[1].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1243, Global.Idioma);
            grdDetalle.Columns[2].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            grdDetalle.Columns[3].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(851, Global.Idioma);
            grdDetalle.Columns[4].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1244, Global.Idioma);
            grdDetalle.Columns[5].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2069, Global.Idioma);
            grdDetalle.Columns[6].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1638, Global.Idioma);
            

            //this.EstablecerCultura();
        }
        #endregion
    }
}
