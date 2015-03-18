using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasLecturas.
    /// </summary>
    public partial class VentasLecturas : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _manguera;
        bool _todas;
        #endregion

        #region Costructor de la clase
        public VentasLecturas(DateTime fechaInicio, DateTime fechaFin, int manguera, bool todas)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _manguera = manguera;
            _todas = todas;
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2281, Global.Idioma);
            lblManguera.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            lblLecturaInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(841, Global.Idioma);
            lbllecturaFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(842, Global.Idioma);
            lblLecturaSurtidor.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(843, Global.Idioma);
            lblLecturasPorVentas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(853, Global.Idioma);            
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

            sql.Append(" Exec");
            sql.Append(" SP_RptDifLects ");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            if (!this._todas)
                sql.Append(this._manguera);
            else
                sql.Append("0");

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
            InitializeGraph();
        }
        #endregion

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            this.srptGrafica.Report = new SubGraficaLecturas();
            this.srptGrafica.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).SQL = QueryPrincipal();
            ((SubGraficaLecturas)this.srptGrafica.Report).RefrescarGrafica();

        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (!this._todas)
                sql.Append(",@Cod_man = '" + this._manguera.ToString() + "'");
            return sql.ToString();

        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasLecturas.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblManguera = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[2]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[3]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[5]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblLecturasPorVentas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lbllecturaFinal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblLecturaInicial = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblLecturaSurtidor = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.txtManguera = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtLecturaInicial = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtLecturaFinal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtDiferenciaPorVentas = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtLecturaSurtidor = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[0]));
            this.srptGrafica = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[1]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[4]));
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
