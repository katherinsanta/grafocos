using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptRDTotalIngresos.
    /// </summary>
    public partial class SubRptRDTotalIngresos : DataDynamics.ActiveReports.ActiveReport
    {

       #region Definicion de variables
        DateTime _fechaInicial;
        DateTime _fechaFinal;          
        #endregion

        
        #region Constructor de la Clase
        public SubRptRDTotalIngresos(DateTime fechaInicial, DateTime fechaFinal)
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

            sql.Append("Select isnull(sum(VALOROTROINGRESO),0) TotalOtrosIngresos from ConsolidadoOtrosIngresos where dbo.finteger(fecha) between ");
            sql.Append(" '" + this._fechaInicial.ToString("yyyyMMdd") + "' and ");
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

        private void groupFooter1_Format(object sender, EventArgs e)
        {

        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }
    }
}
