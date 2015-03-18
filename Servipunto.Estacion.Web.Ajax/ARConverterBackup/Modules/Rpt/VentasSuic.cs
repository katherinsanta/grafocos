using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Servipunto.Estacion.Web.Modules.Rpt;

namespace Servipunto.Estacion.Web.Ajax.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasSuic.
    /// </summary>
    public partial class VentasSuic : DataDynamics.ActiveReports.ActiveReport3
    {
        DateTime _fechaInico;
        DateTime _fechFinal;
        DateTime _fechMantI;
        DateTime _fechMantF;
        int _cant;

        #region constructor
        public VentasSuic(DateTime fechaInico,DateTime fechFinal,DateTime fechaMantI,DateTime fechaMantF, int cant)
        {
            _fechaInico = fechaInico;
            _fechFinal = fechFinal;
            _fechMantI = fechaMantI;
            _fechMantF = fechaMantF;
            _cant = cant;
            InitializeComponent();
            InitializeDataBase();
        }
        #endregion

        #region inicializa DataBase
        private void InitializeDataBase() 
        {
            this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
        }

        #endregion

        #region Query
        private string QueryPrincipal() 
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("execute  ");
            sql.Append("sp_VehiculoSuic");
            sql.Append("'"+this._fechaInico.ToString("dd-MM-yyyy")+"',");
            sql.Append("'" + this._fechFinal.ToString("dd-MM-yyyy") + "',");
            sql.Append("'" + this._fechMantI.ToString("dd-MM-yyyy") + "',");
            sql.Append("'" + this._fechMantF.ToString("dd-MM-yyyy") + "',");
            sql.Append(Convert.ToInt32(this._cant.ToString()));
            return sql.ToString();
        }
        #endregion 

        #region query encabezado
        private string QueryEncabezado() 
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("select  ");
            sql.Append("Razon_Social,");
            sql.Append("Nit,");
            sql.Append("Nit_Dive  ");
            sql.Append("from Dat_Gene");
            return sql.ToString();
        }
        #endregion

        #region pageHeader Format
        private void pageHeader_Format(object sender, EventArgs e)
        {
            this.lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = DateTime.Now.ToString("hh:mm tt");
            this.lblTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23594, Global.Idioma) + ": " +
                this._fechaInico.ToString("dd/MM/yyyy") + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) +
                this._fechFinal.ToString("dd/MM/yyyy");
            this.lblTituloFechas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23595, Global.Idioma) + ": " +
                this._fechMantI.ToString("dd/MM/yyyy") + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) +
                this._fechMantF.ToString("dd/MM/yyyy");


            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #endregion

        #region footer format
        private void pageFooter_Format(object sender, EventArgs e)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion
    }
}
