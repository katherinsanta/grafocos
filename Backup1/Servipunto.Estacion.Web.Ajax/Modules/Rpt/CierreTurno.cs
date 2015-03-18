using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for CierreTurno.
    /// </summary>
    public partial class CierreTurno : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        string _turno;
        int _isla;
        bool _informacionTurno;
        bool _consecutivo;
        bool _turnoIsla;
        bool _lectuas;
        bool _articulos;
        bool _formasPago;
        bool _creditoDirecto;
        int _Language = 0;

        #endregion

        #region Costructor de la clase
        public CierreTurno(DateTime fechaInicio,
            string turno,
            int isla,
            bool informacionTurno,
            bool consecutivo,
            bool turnoIsla,
            bool lectuas,
            bool articulos,
            bool formasPago,
            bool creditoDirecto,
            int Idioma
            )
        {
            _fechaInicio = fechaInicio;
            _turno = turno;
            _isla = isla;
            _informacionTurno = informacionTurno;
            _consecutivo = consecutivo;
            _turnoIsla = turnoIsla;
            _lectuas = lectuas;
            _articulos = articulos;
            _formasPago = formasPago;
            _creditoDirecto = creditoDirecto;
            _Language = Idioma;
            this.PageSettings.PaperName = "";
            InitializeComponent();
            if (Idioma == 1)
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

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion

        #region Reporte de ventas por turno e isla
        private void ghTurnoIsla_Format(object sender, System.EventArgs eArgs)
        {
            if (!_turnoIsla)
                return;
            SubRptIslaResumido rpt = new SubRptIslaResumido(this._fechaInicio, this._isla, this._turno, false);
            this.SubReportTurnoIsla.Report = rpt;
        }
        #endregion

        #region Reporte de diferencia de lecturas
        private void ghDiferenciaLecturas_Format(object sender, System.EventArgs eArgs)
        {
            if (!_lectuas)
                return;
            SubRptDiferenciaLecturas rpt;
            if (_Language == 1)
                rpt = new SubRptDiferenciaLecturas(this._fechaInicio, this._isla, this._turno, false, 1);
            else
                rpt = new SubRptDiferenciaLecturas(this._fechaInicio, this._isla, this._turno, false, 0);
            SubReportDiferenciaLecturas.Report = rpt;
        }
        #endregion

        #region Reporte de ventas por articulo
        private void ghArticulo_Format(object sender, System.EventArgs eArgs)
        {
            if (!_articulos)
                return;

            SubRptArticulo rpt = new SubRptArticulo(this._fechaInicio, this._isla, this._turno, false);
            SubReportArticulo.Report = rpt;
        }
        #endregion

        #region Reporte por formas de pago
        private void ghFormasPago_Format(object sender, System.EventArgs eArgs)
        {
            if (!_formasPago)
                return;

            //SubRptFormasPago rpt = new SubRptFormasPago(this._fechaInicio, this._isla, this._turno);
            //SubRptFormasPago rpt = new SubFormasPago(this._fechaInicio, this._isla, this._turno);
            //SubReportFormaspago.Report = rpt;			
            this.srptFormasPago.Report = new SubFormasPago();
            this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryGranTotal();
        }
        #endregion

        #region Reporte credito directo
        private void ghCreditoDirecto_Format(object sender, System.EventArgs eArgs)
        {
            if (!_creditoDirecto)
                return;

            SubRptCreditoDirecto rpt = new SubRptCreditoDirecto(this._fechaInicio, this._isla, this._turno, false);
            SubReportCreditoDirecto.Report = rpt;
        }
        #endregion

        #region Formato del Encabezado de Pagina
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            this.lblFecha.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "On the issue date: " + this._fechaInicio.ToString("dd/MM/yyyy");

            if (_informacionTurno)
            {
                if (_Language == 1)
                    this.SubRptTurnoInformacion.Report = new SubRptTurnoInformacion(_fechaInicio, _turno, _isla, 1);
                else
                    this.SubRptTurnoInformacion.Report = new SubRptTurnoInformacion(_fechaInicio, _turno, _isla, 0);
            }
            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@Num_tur = '" + this._turno + "'");
            sql.Append(",@Cod_Isl = '" + this._isla.ToString() + "'");
            return sql.ToString();

        }
        #endregion

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader = null;
        private DataDynamics.ActiveReports.Label lblHora = null;
        private DataDynamics.ActiveReports.Label lblFecha = null;
        private DataDynamics.ActiveReports.SubReport srptEncabezado = null;
        private DataDynamics.ActiveReports.Label Label15 = null;
        private DataDynamics.ActiveReports.Label lblTituloFechas = null;
        private DataDynamics.ActiveReports.SubReport SubRptTurnoInformacion = null;
        private DataDynamics.ActiveReports.GroupHeader ghTurnoIsla = null;
        private DataDynamics.ActiveReports.SubReport SubReportTurnoIsla = null;
        private DataDynamics.ActiveReports.Line Line1 = null;
        private DataDynamics.ActiveReports.Line Line3 = null;
        private DataDynamics.ActiveReports.GroupHeader ghDiferenciaLecturas = null;
        private DataDynamics.ActiveReports.SubReport SubReportDiferenciaLecturas = null;
        private DataDynamics.ActiveReports.Line Line5 = null;
        private DataDynamics.ActiveReports.Line Line7 = null;
        private DataDynamics.ActiveReports.GroupHeader ghArticulo = null;
        private DataDynamics.ActiveReports.SubReport SubReportArticulo = null;
        private DataDynamics.ActiveReports.Line Line9 = null;
        private DataDynamics.ActiveReports.Line Line11 = null;
        private DataDynamics.ActiveReports.GroupHeader ghFormasPago = null;
        private DataDynamics.ActiveReports.Line Line4 = null;
        private DataDynamics.ActiveReports.Line Line6 = null;
        private DataDynamics.ActiveReports.SubReport srptFormasPago = null;
        private DataDynamics.ActiveReports.GroupHeader ghCreditoDirecto = null;
        private DataDynamics.ActiveReports.SubReport SubReportCreditoDirecto = null;
        private DataDynamics.ActiveReports.Line Line8 = null;
        private DataDynamics.ActiveReports.Line Line10 = null;
        private DataDynamics.ActiveReports.Detail Detail = null;
        private DataDynamics.ActiveReports.GroupFooter gfCreditoDirecto = null;
        private DataDynamics.ActiveReports.GroupFooter gfFormasPago = null;
        private DataDynamics.ActiveReports.GroupFooter gfArticulo = null;
        private DataDynamics.ActiveReports.GroupFooter gfDiferenciaLecturas = null;
        private DataDynamics.ActiveReports.GroupFooter gfTurnoIsla = null;
        private DataDynamics.ActiveReports.PageFooter PageFooter = null;
        private DataDynamics.ActiveReports.Label lblModulo = null;
        private DataDynamics.ActiveReports.Label Label = null;
        private DataDynamics.ActiveReports.Label lblPagina = null;
        private DataDynamics.ActiveReports.Label lblDe = null;
        private DataDynamics.ActiveReports.Label lblAno = null;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina = null;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas = null;
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.CierreTurno.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));            
            this.ghTurnoIsla = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTurnoIsla"]));
            this.ghDiferenciaLecturas = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghDiferenciaLecturas"]));
            this.ghArticulo = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghArticulo"]));
            this.ghFormasPago = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFormasPago"]));
            this.ghCreditoDirecto = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghCreditoDirecto"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfCreditoDirecto = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfCreditoDirecto"]));
            this.gfFormasPago = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFormasPago"]));
            this.gfArticulo = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfArticulo"]));
            this.gfDiferenciaLecturas = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfDiferenciaLecturas"]));
            this.gfTurnoIsla = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTurnoIsla"]));
            
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[2]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.SubRptTurnoInformacion = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[5]));
            
            this.SubReportTurnoIsla = ((DataDynamics.ActiveReports.SubReport)(this.ghTurnoIsla.Controls[0]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ghTurnoIsla.Controls[1]));
            this.Line3 = ((DataDynamics.ActiveReports.Line)(this.ghTurnoIsla.Controls[2]));
            this.SubReportDiferenciaLecturas = ((DataDynamics.ActiveReports.SubReport)(this.ghDiferenciaLecturas.Controls[0]));
            this.Line5 = ((DataDynamics.ActiveReports.Line)(this.ghDiferenciaLecturas.Controls[1]));
            this.Line7 = ((DataDynamics.ActiveReports.Line)(this.ghDiferenciaLecturas.Controls[2]));
            this.SubReportArticulo = ((DataDynamics.ActiveReports.SubReport)(this.ghArticulo.Controls[0]));
            this.Line9 = ((DataDynamics.ActiveReports.Line)(this.ghArticulo.Controls[1]));
            this.Line11 = ((DataDynamics.ActiveReports.Line)(this.ghArticulo.Controls[2]));
            this.Line4 = ((DataDynamics.ActiveReports.Line)(this.ghFormasPago.Controls[0]));
            this.Line6 = ((DataDynamics.ActiveReports.Line)(this.ghFormasPago.Controls[1]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.ghFormasPago.Controls[2]));
            this.SubReportCreditoDirecto = ((DataDynamics.ActiveReports.SubReport)(this.ghCreditoDirecto.Controls[0]));
            this.Line8 = ((DataDynamics.ActiveReports.Line)(this.ghCreditoDirecto.Controls[1]));
            this.Line10 = ((DataDynamics.ActiveReports.Line)(this.ghCreditoDirecto.Controls[2]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events            
            this.ghDiferenciaLecturas.Format += new System.EventHandler(this.ghDiferenciaLecturas_Format);
            this.ghArticulo.Format += new System.EventHandler(this.ghArticulo_Format);
            this.ghFormasPago.Format += new System.EventHandler(this.ghFormasPago_Format);
            this.ghCreditoDirecto.Format += new System.EventHandler(this.ghCreditoDirecto_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.ghTurnoIsla.Format += new System.EventHandler(this.ghTurnoIsla_Format);
        }

        #endregion

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2197, Global.Idioma);
            #region Pie de pagina
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
    }
}
