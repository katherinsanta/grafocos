using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDiarioDConsignaciones.
    /// </summary>
    public partial class SubRptResumenDiarioDConsignaciones : DataDynamics.ActiveReports.ActiveReport3
    {

       #region Definicion de variables
        DateTime _fechaInicial;
        DateTime _fechaFinal;        
        #endregion

        
        #region Constructor de la Clase
        public SubRptResumenDiarioDConsignaciones(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
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
            sql.Append(" SubRptResumenDiarioConsignaciones");
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

        private void GHIslero_Format(object sender, EventArgs e)
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
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23683, Global.Idioma).ToUpper();
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(264, Global.Idioma).ToUpper();
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23322, Global.Idioma).ToUpper();
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(96, Global.Idioma).ToUpper();
            label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23682, Global.Idioma).ToUpper();
            label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23683, Global.Idioma).ToUpper()+"S";
            label4.Text = "TOTAL "+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma).ToUpper();
            label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2194, Global.Idioma).ToUpper();
            label12.Text = "TOTAL "+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23683, Global.Idioma).ToUpper();
        }
        #endregion
    }
}
