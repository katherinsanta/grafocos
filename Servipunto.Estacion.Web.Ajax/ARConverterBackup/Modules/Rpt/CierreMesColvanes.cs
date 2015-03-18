using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for CierreMesColvanes.
    /// </summary>
    public partial class CierreMesColvanes : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _mes;
        #endregion

        #region Costructor de la clase
        public CierreMesColvanes(DateTime fechaInicio, DateTime fechaFin)
        {            
            _fechaInicio = fechaInicio; // DateTime.Parse(System.DateTime.Now.Year.ToString().PadLeft(4, '0') + "-" + this._mes.ToString().PadLeft(2, '0') + "-" + "01");
            _fechaFin = _fechaInicio;
            _fechaFin = fechaFin;
            //_fechaFin = _fechaFin.AddDays(-1);
            InitializeComponent();
            InitializeDatabase();
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
            this.lblFecha.Text = "Fecha: " + DateTime.Now.ToLongDateString();
            this.lblHora.Text = "Hora: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "Entre las fechas de emisión: " +
                this._fechaInicio.ToString("dd/MM/yyyy") + " " +  "00:00:01" + " Hasta " +
                this._fechaFin.ToString("dd/MM/yyyy") + " " + "23:59:59";

            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append(" Exec CierreMesCliente");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "'");
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
               }
        #endregion

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            //this.srptGrafica.Report = new SubGraficaVentasPorHora();
        }
        #endregion
             
        private void ghTotal_Format(object sender, System.EventArgs eArgs)
        {

        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {

        }

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.CierreMesColvanes.rpx");
       
           
            // Attach Report Events
        }

        private string HoraInicial()
        {
            SqlDataReader dr = null;
            string result = "";
            string sql = "select dbo.hinteger(Hora_Ini) from jornadazeta where  dbo.finteger(fecha) ='" + _fechaInicio.ToString("dd/MM/yyyy")+"'";
            dr = SqlHelper.ExecuteReader(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);
            if (dr.Read())
            {
                result = dr.IsDBNull(0) ? "" : dr.GetString(0);

            }
            return result;
        }

        private string HoraFinal()
        {
            
            SqlDataReader dr = null;
            string result = "";
            string sql = "select dbo.hinteger(Hora_fin) from jornadazeta where  dbo.finteger(fecha) ='" + _fechaFin.ToString("dd/MM/yyyy") + "'";

            dr = SqlHelper.ExecuteReader(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);
                if (dr.Read())
                {
                    result = dr.IsDBNull(0) ? "" : dr.GetString(0);

                }
                return result;

        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {

        }

    }
}
