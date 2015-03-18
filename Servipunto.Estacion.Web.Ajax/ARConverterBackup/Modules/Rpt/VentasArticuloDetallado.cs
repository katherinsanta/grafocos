using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasArticuloDetallado.
    /// </summary>
    public partial class VentasArticuloDetallado : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _codigoArticulo;
        #endregion

        #region Constructor de la Clase
        public VentasArticuloDetallado(DateTime fechaInicio, DateTime fechaFin, string codigoArticulo, int Idioma)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _codigoArticulo = codigoArticulo;
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                Traducir();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec");
            sql.Append(" RptVentsArticulo");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(" 1, 1, " + _codigoArticulo + ",0,0");
            return sql.ToString();
        }
        #endregion

        #region InitializeDatabase
        private void InitializeDatabase()
        {
            this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
        }
        #endregion

        #region QueryEncabezado
        private string QueryEncabezado()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("Select");
            sql.Append(" Razon_Social,");
            sql.Append(" Nit,");
            sql.Append(" Nit_Dive");
            sql.Append(" From Dat_Gene");
            return sql.ToString();
        }
        #endregion

        #region Formato del Encabezado de Pagina
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {            
            #region fechas
            this.lblFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma) + ": " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma) + ": " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(836, Global.Idioma) + ": " +
                this._fechaInicio.ToString("dd/MM/yyyy")+ " " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) + " " +
                this._fechaFin.ToString("dd/MM/yyyy");
            #endregion
            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            lblTitulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2245, Global.Idioma);
            lblConsecutivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);
            lblCliente.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(154, Global.Idioma);
            lblPlaca.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            lblHoraVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            lblFechaGroup.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2246, Global.Idioma);
            lblEtiquetaTotalFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2247, Global.Idioma);
            lblTotalVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2248, Global.Idioma);
            lblTituloFormasPago.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2233, Global.Idioma);
            lblCodigo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            lblFormaPago.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Global.Idioma);
            lblNumeroVentas.Text ="No. "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(723, Global.Idioma);
            #region Pie de pagina

            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
        #endregion

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion

        #region Formato del Grupo Total
        private void gfTotal_Format(object sender, System.EventArgs eArgs)
        {
            this.srptFormasPago.Report = new SubFormasPago();
            this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryGranTotal();
        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec RptResumenFPago ");
            sql.Append(this._fechaInicio.ToString("yyyyMMdd") + ", ");
            sql.Append(this._fechaFin.ToString("yyyyMMdd") + ", A,");
            if(_codigoArticulo != "0")
                sql.Append(_codigoArticulo + ",");
            else
                sql.Append("null, ");
            sql.Append("null");

            return sql.ToString();
            */
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (_codigoArticulo != "0")
                sql.Append(",@Cod_art = '" + _codigoArticulo + "'");
            return sql.ToString();

        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasArticuloDetallado.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.ghArticulo = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghArticulo"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfArticulo = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfArticulo"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.lblTitulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblConsecutivo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblCliente = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblPlaca = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[10]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.lblHoraVenta = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[16]));
            this.lblFechaGroup = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.txtFecha = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ghArticulo.Controls[0]));
            this.txtArticulo = ((DataDynamics.ActiveReports.TextBox)(this.ghArticulo.Controls[1]));
            this.txtConsecutivo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtCliente = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtPlaca = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtHora = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtCantidad = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.txtHoraVenta = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.gfArticulo.Controls[0]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[1]));
            this.txtTotalArticuloCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[2]));
            this.txtTotalArticuloUnidades = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[3]));
            this.txtTotalArticuloIva = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[4]));
            this.txtTotalArticulo = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[5]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[6]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[7]));
            this.lblEtiquetaTotalFecha = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[0]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[1]));
            this.txtTotalFecha = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            this.txtTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            this.txtTotalUnidades = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            this.txtTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[5]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[6]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[7]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.lblCodigo = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[5]));
            this.lblFormaPago = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[6]));
            this.lblNumeroVentas = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[7]));
            this.lblTotalFormasPago = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[8]));
            this.lblTituloFormasPago = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[9]));
            this.Line3 = ((DataDynamics.ActiveReports.Line)(this.gfTotal.Controls[10]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[11]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[12]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[13]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
        }
    }
}
