using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;


namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for NewActiveReport1.
    /// </summary>
    public partial class sRptCanastillaTurno : DataDynamics.ActiveReports.ActiveReport
    {

        DateTime _fechaInicial;
        DateTime _fechaFinal;
        short _numTurno;
        short _codIsla;
        
        #region Constructor de la Clase
        public sRptCanastillaTurno(DateTime fechaInicial, DateTime fechaFinal, short turno, short isla,int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            _numTurno = turno;
            _codIsla = isla;
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
            sql.Append(" VentasCanastillaTurno");
            sql.Append(" '" + this._fechaInicial.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFinal.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._numTurno + "',");
            sql.Append(" '" + this._codIsla + "'");                            
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
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23689, Global.Idioma).ToUpper();
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(144, Global.Idioma).ToUpper();
            label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma).ToUpper();
            label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma).ToUpper();
            //label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma).ToUpper();
            //label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1244, Global.Idioma).ToUpper();
            label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23697, Global.Idioma).ToUpper();
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23690, Global.Idioma).ToUpper();
        }
        #endregion
    
    }
}
