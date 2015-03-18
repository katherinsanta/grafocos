using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ControlLecturasTurno.
    /// </summary>
    public partial class ControlLecturasTurno : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _codigoManguera;
        int _codigoIsla;
        int _numeroTurno;
        bool _granTotal = false;
        bool _grafica = false;
        Int16 _idArticulo;
        string _nombreArticulo;
        bool _consolidado = false;
        string _unidadMedida = "0";

        #endregion

        #region Constructor de la Clase
        public ControlLecturasTurno(DateTime fechaInicio, DateTime fechaFin, int codigoIsla, int numeroTurno, int codigoManguera, bool granTotal, bool grafica, Int16 idArticulo, string nombreArticulo, bool consolidado, string unidadMedida)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _codigoManguera = codigoManguera;
            _codigoIsla = codigoIsla;
            _numeroTurno = numeroTurno;
            _granTotal = granTotal;
            _grafica = grafica;
            _idArticulo = idArticulo;
            _nombreArticulo = nombreArticulo;
            _consolidado = consolidado;
            _unidadMedida = unidadMedida;
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
                this._fechaFin.ToString("dd/MM/yyyy") +" - " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma) + ": " + _nombreArticulo + " - " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma) + ": " + (_unidadMedida == "0" ? "All" : _unidadMedida);
            #endregion
            
            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2198, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma);
            lblSubTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(46, Global.Idioma);
            lblTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(841, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(842, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(236, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(844, Global.Idioma);
            #region Pie de pagina
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
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
            sql.Append(" exec rptControlLecturasTurnos ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");

            if (_codigoManguera != 0)
                sql.Append(",@cod_man = '" + _codigoManguera.ToString() + "'");
            if (_codigoIsla != 0)
                sql.Append(",@cod_isl = '" + _codigoIsla.ToString() + "'");
            if (_numeroTurno != 0)
                sql.Append(",@num_tur = '" + _numeroTurno.ToString() + "'");
            if (_idArticulo != 0)
                sql.Append(",@IdArticulo = '" + _idArticulo.ToString() + "'");
            if (_consolidado)
                sql.Append(",@Consolidado = '1'");
            if (_unidadMedida != "0")
                sql.Append(",@UnidadMedida = '" + _unidadMedida + "'");

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

        #region PageFooter_Format
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
            /*this.srptFormasPago.Report = new SubFormasPago();
            this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryGranTotal();
            */
            //InitializeGraph();

        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));

            if (_codigoManguera != 0)
                sql.Append(",@cod_man = '" + _codigoManguera.ToString() + "'");
            if (_codigoIsla != 0)
                sql.Append(",@cod_isl = '" + _codigoIsla.ToString() + "'");
            if (_numeroTurno != 0)
                sql.Append(",@num_tur = '" + _numeroTurno.ToString() + "'");
            if (_idArticulo != 0)
                sql.Append(",@Cod_art = '" + _idArticulo.ToString() + "'");
            if (_unidadMedida != "0")
            {
                sql.Append(",@Opcion = '1'");
                sql.Append(",@UnidadMedida = '" + _unidadMedida + "'");
            }

            return sql.ToString();

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

        private void gfTotal_Format(object sender, System.EventArgs eArgs)
        {
            srptFormasPago.Visible = _granTotal;
            srptGrafica.Visible = _grafica;
            if (_granTotal)
            {
                this.srptFormasPago.Report = new SubFormasPago();
                this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
                ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
                ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryGranTotal();
            }
            if (_grafica)
                InitializeGraph();
        }
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.ControlLecturasTurno.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[6]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[11]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[16]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[2]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[3]));
            this.srptGrafica = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[0]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[1]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[5]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);

        }


    }
}
