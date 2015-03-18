using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDDiarioFormasPago.
    /// </summary>
    public partial class SubRptResumenDDiarioFormasPago : DataDynamics.ActiveReports.ActiveReport3
    {

       DateTime _fechaInicial;
        DateTime _fechaFinal;      
        
        #region Constructor de la Clase
        public SubRptResumenDDiarioFormasPago(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
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
            sql.Append(" RptRDDFormaPago");
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

        private void groupFooter1_Format(object sender, EventArgs e)
        {

        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirSubReporte()
        {
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1023, Global.Idioma).ToUpper();
            textBox2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(144, Global.Idioma).ToUpper();
            textBox5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(814, Global.Idioma).ToUpper();
            label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23615, Global.Idioma).ToUpper();
            label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(264, Global.Idioma).ToUpper();
            label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma).ToUpper();
            label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma).ToUpper();
            label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma).ToUpper();
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23676, Global.Idioma).ToUpper();
        }
        #endregion
    }
}
