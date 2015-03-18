using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDDiarioTanques.
    /// </summary>
    public partial class SubRptResumenDDiarioTanques : DataDynamics.ActiveReports.ActiveReport
    {

         #region Definicion de variables
        DateTime _fechaInicial;
        DateTime _fechaFinal;       
        #endregion

        
        #region Constructor de la Clase
        public SubRptResumenDDiarioTanques(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
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
            sql.Append(" SubRptTanqueVariacionMensajeDetallado");
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1251, Global.Idioma).ToUpper() + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1212, Global.Idioma).ToUpper();
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(996, Global.Idioma)+" ID";
            Label4.Text = "Initial "+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2024, Global.Idioma);
            label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2108, Global.Idioma);
            label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2107, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23647, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(845, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1212, Global.Idioma);
            Label7.Text = Label7.Text.Substring(0, 1).ToUpper() + Label7.Text.Substring(1).ToLower();
            Label9.Text = "Final " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2024, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(849, Global.Idioma);
        }
        #endregion
    }
}
