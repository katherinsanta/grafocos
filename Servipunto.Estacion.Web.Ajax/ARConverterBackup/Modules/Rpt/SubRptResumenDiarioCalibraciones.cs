using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDiarioCalibraciones.
    /// </summary>
    public partial class SubRptResumenDiarioCalibraciones : DataDynamics.ActiveReports.ActiveReport3
    {

        
        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _isla;
        string _turno;
        bool _todos;
        #endregion

        #region Constructor de la Clase
        public SubRptResumenDiarioCalibraciones(DateTime fechaInicio, DateTime fechaFinal, int Idioma)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFinal;
           
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                Traducir();
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23648, Global.Idioma).ToUpper();
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(247, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(940, Global.Idioma);
            label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(531, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1630, Global.Idioma);
            label10.Text = label10.Text.Substring(0, 1).ToUpper() + label10.Text.Substring(1).ToLower();
            label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(989, Global.Idioma);
        }
        #endregion
        #region QueryPrincipal
        private string QueryPrincipal()
        {
            //pendientex
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("SP_RptFormasPago ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
            sql.Append("'" + this._fechaFin.ToString("yyyyMMdd") + "', 1,6, ");
            sql.Append("'Todos',0, ");
            sql.Append(this._isla + ", " + this._turno);
            return sql.ToString();
            */

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("SubRptResumenDiarioCalibraciones ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd")+"'");
           
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
    }
}
