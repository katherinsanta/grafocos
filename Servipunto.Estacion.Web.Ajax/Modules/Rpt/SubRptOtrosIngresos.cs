using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptOtrosIngresos.
    /// </summary>
    public partial class SubRptOtrosIngresos : DataDynamics.ActiveReports.ActiveReport
    {

       DateTime _fechaInicial;
        DateTime _fechaFinal;


        public SubRptOtrosIngresos(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                Traducir();
        }

        private void detail_Format(object sender, EventArgs e)
        {

        }

        #region InitializeDatabase
        private void InitializeDatabase()
        {
            this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
        }
        #endregion	

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();       
            sql.Append("SELECT ISNULL(SUM(ValorOtroIngreso),0) 'Total' FROM dbo.ConsolidadoOtrosIngresos WHERE DBO.FINTEGER(FECHA) between '" + this._fechaInicial.ToString("yyyyMMdd") + "' and '" + this._fechaFinal.ToString("yyyyMMdd") + "'");            
            return sql.ToString();
        }
        #endregion

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23702, Global.Idioma).ToUpper();
        }
        #endregion
    }
}
