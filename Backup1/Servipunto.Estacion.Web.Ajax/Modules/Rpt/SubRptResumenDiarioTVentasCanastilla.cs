using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDiarioTVentasCanastilla.
    /// </summary>
    public partial class SubRptResumenDiarioTVentasCanastilla : DataDynamics.ActiveReports.ActiveReport
    {
         #region Definicion de variables
        DateTime _fechaInicial;
        DateTime _fechaFinal;        
        #endregion

        
        #region Constructor de la Clase
        public SubRptResumenDiarioTVentasCanastilla(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                TraducirSubReporte();
        }
        #endregion
        

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec");
            sql.Append(" RptRDVentasCanastilla");
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

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirSubReporte()
        {
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23689, Global.Idioma).ToUpper();
            label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma).ToUpper();
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23691, Global.Idioma).ToUpper();
            label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23692, Global.Idioma).ToUpper();
            label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23693, Global.Idioma).ToUpper();
            label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23694, Global.Idioma).ToUpper();
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23695, Global.Idioma).ToUpper();
            label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23696, Global.Idioma).ToUpper();
            label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23697, Global.Idioma).ToUpper();
            label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2228, Global.Idioma).ToUpper();
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23690, Global.Idioma).ToUpper();
        }
        #endregion
    }
}
