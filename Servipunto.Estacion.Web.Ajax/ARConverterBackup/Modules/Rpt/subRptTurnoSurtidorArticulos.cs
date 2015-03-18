using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for subRptTurnoSurtidorArticulos.
    /// </summary>
    public partial class subRptTurnoSurtidorArticulos : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _turno;
        int _surtidor;
        int _articulo;
       
        #endregion

        #region Constructor de la Clase
        public subRptTurnoSurtidorArticulos(DateTime fechaInicio, DateTime fechaFinal, int turno, int surtidor, int articulo)
        {
            _fechaInicio =  fechaInicio;
            _fechaFin = fechaFinal;
            _surtidor = surtidor;
            _articulo = articulo;
            _turno = turno;                       
            InitializeComponent();
            InitializeDatabase();
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2237, Global.Idioma);
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            

        }
        #endregion
        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec");
            sql.Append(" CONSULTAVENTASTOTALES_TURNOSURTIDORARTICULO");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(_turno == 0 ? "null," : _turno.ToString() + ",");
            sql.Append(_surtidor == 0 ? "null," : _surtidor.ToString() + ",");
            sql.Append(_articulo == 0 ? "null" : _articulo.ToString());
            
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
