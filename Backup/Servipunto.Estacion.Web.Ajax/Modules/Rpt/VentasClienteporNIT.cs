using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasClienteporNIT.
    /// </summary>
    public partial class VentasClienteporNIT : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _codigoCliente;
        string _placa;
        #endregion

        #region Constructor de la Clase
        public VentasClienteporNIT(DateTime fechaInicio, DateTime fechaFin, string codigoCliente, string placa)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _codigoCliente = codigoCliente;
            _placa = placa;
            InitializeComponent();
            InitializeDatabase();
            Traducir();
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
                this._fechaInicio.ToString("dd/MM/yyyy") + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) +
                this._fechaFin.ToString("dd/MM/yyyy");
            #endregion
            this.lblAutomotor.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(362, Global.Idioma)+": " + (_placa == "0" ? "<All>" : _placa);

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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2259, Global.Idioma);
            lblConsecutivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);
            lblTituloFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            lblFechaVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            lblCliente.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(256, Global.Idioma);
            lblPlaca.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2260, Global.Idioma);
            lblVentasClientes.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(640, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2230, Global.Idioma);
            lblTotalVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2248, Global.Idioma);
            #region Pie de pagina

            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec rptVentasClienteExterno ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            if (_codigoCliente.Trim() != "0" && _codigoCliente.Trim() != "")
                sql.Append(",@cod_cli = '" + _codigoCliente.Trim() + "'");
            if (_placa.Trim() != "0" && _placa.Trim() != "")
                sql.Append(",@Placa = '" + _placa.Trim() + "'");

            sql.Append(",@opcion = '2'");
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
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (_codigoCliente.Trim() != "0" && _codigoCliente.Trim() != "")
                sql.Append(",@cod_cli = '" + _codigoCliente + "'");
            if (_placa.Trim() != "0" && _placa.Trim() != "")
                sql.Append(",@Placa = '" + _placa.Trim() + "'");
            return sql.ToString();
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasClienteporNIT.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.ghCliente = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghCliente"]));
            this.ghPlaca = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghPlaca"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfplaca = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfplaca"]));
            this.gfCliente = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfCliente"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblConsecutivo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.lblTituloFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblArticulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[7]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[8]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[10]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
            this.lblAutomotor = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
            this.lblFechaVenta = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.txtFechaVenta = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.lblCliente = ((DataDynamics.ActiveReports.Label)(this.ghCliente.Controls[0]));
            this.txtNombreCliente = ((DataDynamics.ActiveReports.TextBox)(this.ghCliente.Controls[1]));
            this.txtCodigoCliente = ((DataDynamics.ActiveReports.TextBox)(this.ghCliente.Controls[2]));
            this.lblPlaca = ((DataDynamics.ActiveReports.Label)(this.ghPlaca.Controls[0]));
            this.txtPlaca = ((DataDynamics.ActiveReports.TextBox)(this.ghPlaca.Controls[1]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtConsecutivo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtFecha = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.txtArticulo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.txtTotalPlacaUnidades = ((DataDynamics.ActiveReports.TextBox)(this.gfplaca.Controls[0]));
            this.txtTotalVentaSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfplaca.Controls[1]));
            this.txttotaPlacaIVa = ((DataDynamics.ActiveReports.TextBox)(this.gfplaca.Controls[2]));
            this.TotalPlacaTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfplaca.Controls[3]));
            this.txtTotalPlacaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfplaca.Controls[4]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.gfplaca.Controls[5]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.gfplaca.Controls[6]));
            this.lblVentasClientes = ((DataDynamics.ActiveReports.Label)(this.gfCliente.Controls[0]));
            this.txtTotalClienteUndiades = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[1]));
            this.txtTotalClienteSubtotal = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[2]));
            this.txtTotalClienteIva = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[3]));
            this.txtTotalClienteTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[4]));
            this.txtTotalClienteRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[5]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[6]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[1]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[5]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[6]));
            this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[7]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[5]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.TextBox10 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[7]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
        }


    }
}
