using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasPorTipoAutoConsolidadoDias.
    /// </summary>
    public partial class VentasPorTipoAutoConsolidadoDias : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        string _tipoAutomotor;
        #endregion

        #region Costructor de la clase
        public VentasPorTipoAutoConsolidadoDias(DateTime fechaInicio, string tipoAutomotor)
        {
            _fechaInicio = fechaInicio;
            _tipoAutomotor = tipoAutomotor;
            InitializeComponent();
            InitializeDatabase();
            InitializeGraph();
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
                this._fechaInicio.ToString("dd/MM/yyyy");
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2289, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(342, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2048, Global.Idioma);
            lblMes1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2049, Global.Idioma);
            lblMes2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2050, Global.Idioma);
            lblMes3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2051, Global.Idioma);
            lblMes4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2052, Global.Idioma);
            lblMes5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2053, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2064, Global.Idioma);
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
            sql.Append("exec RptVentasTipoAuto ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', 0 ");
            if (_tipoAutomotor != "-1")
                sql.Append(",'" + _tipoAutomotor + "',0");
            else
                sql.Append(",null,0");
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

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            this.srptGrafica.Report = new SubRptConsolidadoTipoAutomotorDia();
            //Servipunto.Estacion.Libreria.Aplicacion.Refresh();
            this.srptGrafica.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).SQL = QueryPrincipal();
            ((SubRptConsolidadoTipoAutomotorDia)this.srptGrafica.Report).RefrescarGrafica();
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasPorTipoAutoConsolidadoDias.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[2]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblMes1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblMes2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblMes3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblMes4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblMes5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[11]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[12]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.txtMes1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtMes2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtMes3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtMes4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtMes5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.srptGrafica = ((DataDynamics.ActiveReports.SubReport)(this.GroupFooter1.Controls[0]));
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
        }

    }
}
