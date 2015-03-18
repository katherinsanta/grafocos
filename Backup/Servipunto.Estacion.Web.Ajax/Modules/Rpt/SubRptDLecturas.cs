using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptDLecturas.
    /// </summary>
    public partial class SubRptDLecturas : DataDynamics.ActiveReports.ActiveReport
    {

       
         #region Definicion de variables
        DateTime _fechaInicial;
        DateTime _fechaFinal;       
        #endregion

        
        #region Constructor de la Clase
        public SubRptDLecturas(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
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
            sql.Append(" SubRDRptLecturasDetallado");
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

        private void reportHeader1_Format(object sender, EventArgs e)
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
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23327, Global.Idioma);
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            label1.Text = label1.Text.Substring(0, 1).ToUpper() + label1.Text.Substring(1).ToLower();
            label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(940, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(841, Global.Idioma);
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(842, Global.Idioma);
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(236, Global.Idioma);
            textBox5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(977, Global.Idioma);
        }
        #endregion
    }
}
