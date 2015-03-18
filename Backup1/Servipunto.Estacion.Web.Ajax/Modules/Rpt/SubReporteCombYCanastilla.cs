using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubReporteCombYCanastilla.
    /// </summary>
    public partial class SubReporteCombYCanastilla : DataDynamics.ActiveReports.ActiveReport
    {

        DateTime _fechaInicial;
        DateTime _fechaFinal;


        public SubReporteCombYCanastilla(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                TraducirSubReporte();
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
            /*
             Select
(SELECT SUM(D.TOTAL) 'Total' FROM dbo.VENTACANASTILLA D WHERE DBO.FINTEGER(D.FECHA) = '20101103')
+ (SELECT SUM(dbo.TURN_LEC.VR_DIFERENCIA)'ValorCombustible' FROM dbo.TURN_LEC WHERE DBO.FINTEGER(FECHA) = '20101103') CombYCanastilla
             */

            //Modificado:   08-03-2011
            //Autor:        Miguel Cantor L.
            //Descripcion: Se cambia la siguiente consulta para traer TODOS los datos en los rangos de tyiempo definidos por el usuario.
            //Presentes:    Luisa Maca
            sql.Append("Select (");            
	        sql.Append ("SELECT ISNULL(SUM(D.TOTAL),0) 'Total' FROM dbo.VENTACANASTILLA D WHERE DBO.FINTEGER(D.FECHA) between '" + this._fechaInicial.ToString("yyyyMMdd") + "' and '" + this._fechaFinal.ToString("yyyyMMdd") + "' and tipofactura <> 1)");
            sql.Append(" + ( SELECT ISNULL(SUM(dbo.TURN_LEC.VR_DIFERENCIA),0) -  ISNULL(dbo.SumarCalibracionesvalor('" + this._fechaInicial.ToString("yyyyMMdd") + "','" + this._fechaFinal.ToString("yyyyMMdd") + "', null, null),0)") ;
	        sql.Append(" 'ValorCombustible' FROM dbo.TURN_LEC WHERE DBO.FINTEGER(FECHA) between '" + this._fechaInicial.ToString("yyyyMMdd") + "' AND '" + this._fechaFinal.ToString("yyyyMMdd") + "') ");
            sql.Append(" + ( SELECT ISNULL(SUM(dbo.ConsolidadoOtrosIngresos.VALOROTROINGRESO),0) FROM ConsolidadoOtrosIngresos WHERE DBO.FINTEGER(FECHA) between '" + this._fechaInicial.ToString("yyyyMMdd") + "' and '" + this._fechaFinal.ToString("yyyyMMdd") + "') ValorCombustibleCanastilla");
            return sql.ToString();
        }
        #endregion

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirSubReporte()
        {
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23698, Global.Idioma).ToUpper();
        }
        #endregion
    }
}
