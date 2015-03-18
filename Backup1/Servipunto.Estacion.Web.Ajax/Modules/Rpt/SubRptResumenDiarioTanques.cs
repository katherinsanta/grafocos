using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDiarioTanques.
    /// </summary>
    public partial class SubRptResumenDiarioTanques : DataDynamics.ActiveReports.ActiveReport
    {

        DateTime _fechaInicial;
        DateTime _fechaFinal;

        public SubRptResumenDiarioTanques(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                TraducirSubReporte();
        }

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec");
            sql.Append(" [RptTanqueVariacionMensaje]");
            sql.Append(" '" + this._fechaInicial.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFinal.ToString("yyyyMMdd") + "'");
            return sql.ToString();
            return "";
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
       

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {

        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirSubReporte()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23699, Global.Idioma).ToUpper();
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23601, Global.Idioma);
            label25.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23650, Global.Idioma);
            label26.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23651, Global.Idioma);
        }
        #endregion
    }
}
