using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDiarioDescuadres.
    /// </summary>
    public partial class SubRptResumenDiarioDescuadres : DataDynamics.ActiveReports.ActiveReport3
    {
        #region Definicion de variables
        DateTime _fechaInicial;
        DateTime _fechaFinal;       
        #endregion

        
        #region Constructor de la Clase
        public SubRptResumenDiarioDescuadres(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
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

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void groupFooter1_Format(object sender, EventArgs e)
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
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23679, Global.Idioma).ToUpper();
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23681, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1783, Global.Idioma);
            label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1782, Global.Idioma);
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23682, Global.Idioma);
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23683, Global.Idioma);
            label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23684, Global.Idioma);
            label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23680, Global.Idioma).ToUpper();
        }
        #endregion
    }
}
