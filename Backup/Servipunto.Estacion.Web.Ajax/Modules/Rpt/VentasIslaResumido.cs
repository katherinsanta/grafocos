using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasIslaResumido.
    /// </summary>
    public partial class VentasIslaResumido : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _numeroIsla;
        bool _todasLasIslas;
        #endregion

        #region Constructor de la Clase
        public VentasIslaResumido(DateTime fechaInicio, DateTime fechaFin, int numeroIsla)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _numeroIsla = numeroIsla;
            _todasLasIslas = numeroIsla == 0 ? true : false;
            InitializeComponent();
            InitializeDatabase();
        }
        #endregion

        #region InitializeDatabase
        private void InitializeDatabase()
        {
            //Servipunto.Estacion.Libreria.Aplicacion.Refresh();

            this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("exec");
            sql.Append(" SP_RptIslaSurCaraMang");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(" 0, 'I', " + this._numeroIsla);
            return sql.ToString();
        }
        #endregion

        #region Formato del Encabezado
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            this.lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Hora: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "Entre las fechas de emisión: " +
                this._fechaInicio.ToString("dd/MM/yyyy") + " Hasta " +
                this._fechaFin.ToString("dd/MM/yyyy");

            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
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

        #region Formato del Pie del Grupo Isla
        private void gfIsla_Format(object sender, EventArgs eArgs)
        {

        }
        #endregion

        #region QueryFormasPago
        private string QueryFormasPago()
        {
            /*			System.Text.StringBuilder sql = new System.Text.StringBuilder();

                        sql.Append("exec RptResumenFPago ");
                        sql.Append(this._fechaInicio.ToString("yyyyMMdd") + ", ");
                        sql.Append(this._fechaFin.ToString("yyyyMMdd") + ", 'I'");
                        if(!this._todasLasIslas)
                            sql.Append("," + this._numeroIsla);
			
                        return sql.ToString();
            */
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (this._numeroIsla != 0)
                sql.Append(",@Cod_Isl = '" + this._numeroIsla.ToString() + "'");

            return sql.ToString();


        }
        #endregion

        #region Formato del Pie del Grupo Total
        private void gfTotal_Format(object sender, System.EventArgs eArgs)
        {
            this.srptFormasPago.Report = new SubFormasPago();
            this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryFormasPago();
            InitializeGraph();
        }
        #endregion

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            this.srptGrafica.Report = new SubGraficaUnidades();
            //Servipunto.Estacion.Libreria.Aplicacion.Refresh();
            this.srptGrafica.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).SQL = QueryPrincipal();
            ((SubGraficaUnidades)this.srptGrafica.Report).RefrescarGrafica();
        }
        #endregion

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion



    }
}
