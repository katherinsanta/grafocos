using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDiarioDTVentasCombustible.
    /// </summary>
    public partial class SubRptResumenDiarioDTVentasCombustible : DataDynamics.ActiveReports.ActiveReport
    {
        DateTime _fechaInicial;
        DateTime _fechaFinal;      
        
        #region Constructor de la Clase
        public SubRptResumenDiarioDTVentasCombustible(DateTime fechaInicial, DateTime fechaFinal)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            InitializeComponent();
            InitializeDatabase();
        }
        #endregion
        

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec");
            sql.Append(" RptRDDVentasCombustible");
            sql.Append(" '" + this._fechaInicial.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFinal.ToString("yyyyMMdd") + "'");                            
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

        private void detail_Format(object sender, EventArgs e)
        {

        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void detail_Format_1(object sender, EventArgs e)
        {

        }
        
    }
}
