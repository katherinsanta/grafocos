using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for FacturaCombustible.
    /// </summary>
    public partial class FacturaCombustible : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _Prefijo;
        private int _Consecutivo;

        DataTable _objFilaDatos = null;

        public FacturaCombustible(string Prefijo,int Consecutivo, int Idioma)
        {
            _Consecutivo = Consecutivo;
            _Prefijo = Prefijo;
            
            InitializeComponent();
            ConsultaPrincipal();
            if (Idioma == 1)
                Traducir();
            
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        public void ConsultaPrincipal() {
            this.DataSource = Servipunto.Estacion.Libreria.Ventas.RecuperarDetalleVentasPorCombustible(_Consecutivo);
        }



        public void InitializeReport()
        {
            this.txtTotalPaginas = ((DataDynamics.ActiveReports.TextBox)(this.pageFooter.Controls[3]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.pageFooter.Controls[5]));
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            txtValorLetras.Text = Convert.ToString("VALUE IN LETTERS :" + ConvertirNumerosaLetras(txtTotalFactura.Text.Substring(1)) + " Pesos M/Cte").ToUpper();
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {
            try
            {
                Libreria.Configuracion.Dat_Gene objDat_gene = Libreria.Configuracion.Datos_Gene.ObtenerItem();
                lblRazonSocial.Text = objDat_gene.RazonSocial;
                txtNitCentroVenta.Text = objDat_gene.Nit + " " + objDat_gene.NitDive;
                txtDireccionCentroVenta.Text = objDat_gene.Direccion;
                txtTelefonoCentroVenta.Text = objDat_gene.Telefono;
                txtPaisCentroVenta.Text = objDat_gene.Ciudad;
                txtNoFactura.Text = Convert.ToString ( _Consecutivo);

                if (this.ObtenerObjetoVentaCanastilla(_Prefijo, _Consecutivo))
                {
                    txtNoFactura.Text = _objFilaDatos.Rows[0]["Prefijo"] + " " + _objFilaDatos.Rows[0]["Consecutivo"].ToString();
                    txtNumeroResolucion.Text = _objFilaDatos.Rows[0]["IdNumOrden"].ToString();

                    Libreria.Configuracion.Bol_NumOrden objResolucion = Libreria.Configuracion.Bol_NumOrdenes.Obtener(Convert.ToInt32(txtNumeroResolucion.Text));
                  txtNumeroResolucion.Text = objResolucion.NumOrder.ToString();
                    txtFechaResolucion.Text = objResolucion.FechaInicial.ToShortDateString();
                  //  txtFechaEmision.Text = _objFilaDatos.Rows[0]["Fecha"].ToString();
                   // txtFechaVencimiento.Text = objResolucion.FechaFinal.ToShortDateString();

                    lblNombreCliente.Text = _objFilaDatos.Rows[0]["Nombre"].ToString();
                    txtPlaca.Text = _objFilaDatos.Rows[0]["Placa"].ToString();
                    txtIdentificacion.Text = _objFilaDatos.Rows[0]["Cod_Cli"].ToString();
                    Libreria.Comercial.Cliente objCliente = Libreria.Comercial.Clientes.ObtenerItem(txtIdentificacion.Text, 1);
                    if (objCliente != null)
                    {
                        txtDireccionCliente.Text = objCliente.DireccionCliente;
                        txtTelefonoCliente.Text = objCliente.TelefonoCliente;
                        Libreria.Configuracion.Ciudad objCiudad = Libreria.Configuracion.Ciudades.Obtener(objCliente.IdCiudad);
                        txtCiudadCliente.Text = objCiudad.Nombre;
                    }
                
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando factura: " + ex.Message);
            }
        }




        #region convertir en letra
        private string ConvertirNumerosaLetras(string num)
        {

            string res, dec = "";

            Int64 entero;

            int decimales;

            double nro;

            try
            {

                nro = Convert.ToDouble(num);

            }

            catch
            {

                return "";

            }

            entero = Convert.ToInt64(Math.Truncate(nro));

            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

            if (decimales > 0)
            {

                dec = " CON " + decimales.ToString() + "/100";

            }

            res = toText(Convert.ToDouble(entero)) + dec;

            return res;

        }


        private string toText(double value)
        {

            string Num2Text = "";

            value = Math.Truncate(value);

            if (value == 0) Num2Text = "CERO";

            else if (value == 1) Num2Text = "UNO";

            else if (value == 2) Num2Text = "DOS";

            else if (value == 3) Num2Text = "TRES";

            else if (value == 4) Num2Text = "CUATRO";

            else if (value == 5) Num2Text = "CINCO";

            else if (value == 6) Num2Text = "SEIS";

            else if (value == 7) Num2Text = "SIETE";

            else if (value == 8) Num2Text = "OCHO";

            else if (value == 9) Num2Text = "NUEVE";

            else if (value == 10) Num2Text = "DIEZ";

            else if (value == 11) Num2Text = "ONCE";

            else if (value == 12) Num2Text = "DOCE";

            else if (value == 13) Num2Text = "TRECE";

            else if (value == 14) Num2Text = "CATORCE";

            else if (value == 15) Num2Text = "QUINCE";

            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);

            else if (value == 20) Num2Text = "VEINTE";

            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);

            else if (value == 30) Num2Text = "TREINTA";

            else if (value == 40) Num2Text = "CUARENTA";

            else if (value == 50) Num2Text = "CINCUENTA";

            else if (value == 60) Num2Text = "SESENTA";

            else if (value == 70) Num2Text = "SETENTA";

            else if (value == 80) Num2Text = "OCHENTA";

            else if (value == 90) Num2Text = "NOVENTA";

            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);

            else if (value == 100) Num2Text = "CIEN";

            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);

            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";

            else if (value == 500) Num2Text = "QUINIENTOS";

            else if (value == 700) Num2Text = "SETECIENTOS";

            else if (value == 900) Num2Text = "NOVECIENTOS";

            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);

            else if (value == 1000) Num2Text = "MIL";

            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);

            else if (value < 1000000)
            {

                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";

                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);

            }

            else if (value == 1000000) Num2Text = "UN MILLON";

            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);

            else if (value < 1000000000000)
            {

                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";

                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);

            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";

            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {

                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";

                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            }

            return Num2Text;

        }
        #endregion




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

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 16/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblEtiquetaCulturalFactura.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23716, Global.Idioma);
            //DATOS DE ESTACION
            lblRazonSocial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23716, Global.Idioma);
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(855, Global.Idioma);
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(856, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(683, Global.Idioma) + "/" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(725, Global.Idioma);
            //DATOS DE FACTURA
            label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(865, Global.Idioma);
            label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23717, Global.Idioma);
            label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2081, Global.Idioma);
            label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2080, Global.Idioma);
            label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2082, Global.Idioma);
            lblCliente.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(154, Global.Idioma);
            //ENCABEZADOS DE LOS DATOS
            label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2215, Global.Idioma);
            label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2080, Global.Idioma);
            label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            label22.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2080, Global.Idioma);
            label44.Text = "% " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2216, Global.Idioma);
            label23.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2217, Global.Idioma);
            //DATOS PANEL ABAJO
            label31.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1244, Global.Idioma);
            label35.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2218, Global.Idioma) + ":";
            label36.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma) + ":";
            label37.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2220, Global.Idioma);
            label38.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(864, Global.Idioma) + ":";
            label39.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma) + ":";
            label40.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2220, Global.Idioma);
            textBox4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2219, Global.Idioma);
            #region Pie de pagina
            label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            #endregion

        }
        #endregion
    }
}
