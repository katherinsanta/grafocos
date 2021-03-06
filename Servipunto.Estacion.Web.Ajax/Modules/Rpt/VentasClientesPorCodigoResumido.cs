using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasClientesPorCodigoResumido.
    /// </summary>
    public partial class VentasClientesPorCodigoResumido : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _codigoCliente;
        bool _todas;
        int _nit;
        #endregion

        #region Constructor de la Clase
        public VentasClientesPorCodigoResumido(DateTime fechaInicio, DateTime fechaFin, string codigo, bool todas, int nit)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _codigoCliente = codigo;
            _todas = todas;
            _nit = nit;
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2263, Global.Idioma);            
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            lblFechaVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            lblCliente.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(256, Global.Idioma);                        
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
            sql.Append(" exec RptVentasPorNitCodigo ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (!_todas)
            {
                if (this._nit == 1)
                    sql.Append(",@Nit = '" + _codigoCliente + "'");
                else
                    sql.Append(",@Cod_cli = '" + _codigoCliente + "'");
            }
            sql.Append(",@Opcion = '1'");
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
            if (!_todas)
            {
                if (this._nit == 1)
                    sql.Append(",@Nit = '" + _codigoCliente + "'");
                else
                    sql.Append(",@Cod_cli = '" + _codigoCliente + "'");

            }
            return sql.ToString();


        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasClientesPorCodigoResumido.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.ghCliente = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghCliente"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfCliente = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfCliente"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[2]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[8]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[9]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblFechaVenta = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.txtFechaVenta = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.lblCliente = ((DataDynamics.ActiveReports.Label)(this.ghCliente.Controls[0]));
            this.txtNombreCliente = ((DataDynamics.ActiveReports.TextBox)(this.ghCliente.Controls[1]));
            this.txtCodigoCliente = ((DataDynamics.ActiveReports.TextBox)(this.ghCliente.Controls[2]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.txtTotalClienteUndiades = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[0]));
            this.txtTotalClienteSubtotal = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[1]));
            this.txtTotalClienteIva = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[2]));
            this.txtTotalClienteTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[3]));
            this.txtTotalClienteRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[4]));
            this.lblVentasClientes = ((DataDynamics.ActiveReports.Label)(this.gfCliente.Controls[5]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.gfCliente.Controls[6]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[1]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[5]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[6]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[7]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[5]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[7]));
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
