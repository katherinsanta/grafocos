using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptLecturas.
    /// </summary>
    public partial class SubRptLecturas : DataDynamics.ActiveReports.ActiveReport
    {

         #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _manguera;
        string _turno;
        int _isla;
        #endregion

        #region Costructor de la clase
        public SubRptLecturas(DateTime fechaInicio, DateTime fechaFinal, int Idioma)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFinal;
      
            _manguera = 0;
         
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                TraducirSubReporte();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" Exec");
            sql.Append(" SP_RptDifLects ");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(this._manguera + ",");
            sql.Append(this._isla + ",");
            sql.Append(this._turno);
            return sql.ToString();
            */

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec SubRptResumenDiarioLecturas ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");            
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
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptDiferenciaLecturas.rpx");
         }

        private void GroupHeader1_Format(object sender, EventArgs e)
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
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23704, Global.Idioma).ToUpper();
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            label1.Text = label1.Text.Substring(0,1).ToUpper()+label1.Text.Substring(1).ToLower();
            label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23601, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(841, Global.Idioma);
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(842, Global.Idioma);
            label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23648, Global.Idioma);
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23700, Global.Idioma);
            label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23701, Global.Idioma);
            textBox3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(977, Global.Idioma);
        }
        #endregion
    }
}
