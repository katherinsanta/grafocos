using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ReporteFacturasCanastilla.
    /// </summary>
    public partial class ReporteFacturasCanastilla : DataDynamics.ActiveReports.ActiveReport3
    {
        DateTime _fechaInicio;
        DateTime _fechaFin;

        public ReporteFacturasCanastilla(DateTime fechaInicial, DateTime fechaFinal)
        {

            _fechaInicio = fechaInicial;
            _fechaFin = fechaFinal;
            this.InitializeDatabase();
            InitializeComponent();
            Traducir();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            Libreria.Configuracion.Datos_Gene objdatosGene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
            #region fechas
            this.lblFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(836, Global.Idioma) + ": " +
                this._fechaInicio.ToString("dd/MM/yyyy") + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) +
                this._fechaFin.ToString("dd/MM/yyyy");
            #endregion            
            this.lblCompania.Text = objdatosGene[0].RazonSocial;

        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            lblNombreReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2227, Global.Idioma);
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2021, Global.Idioma);
            label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(154, Global.Idioma);
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2069, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(154, Global.Idioma);
            lblTotalVentas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2228, Global.Idioma);
            label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2229, Global.Idioma);

            #region Pie de pagina

            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
        private void InitializeDatabase()
        {
            this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryActivas();

            /*this.subReporteAnuladas.Report = new VentasCanastillaAnuladas();
            this.subReporteAnuladas.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.subReporteAnuladas.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.subReporteAnuladas.Report.DataSource).SQL = QueryAnuladas();*/
        }


        #region QueryPrincipal
        private string QueryActivas()
        {

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("ConsultaVentaCanastilla");
            sql.Append(" @FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            sql.Append(",@CodigoCliente = '0'");
            sql.Append(",@Estado = '0'");
            sql.Append(",@Turno = '0'");            
            return sql.ToString();
        }
        #endregion

        #region QueryPrincipal
        private string QueryAnuladas()
        {

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("ConsultaVentaCanastilla");
            sql.Append(" @FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            sql.Append(",@CodigoCliente = '0'");
            sql.Append(",@Estado = '1'");
            sql.Append(",@Turno = '0'");
            return sql.ToString();
        }
        #endregion

        private void groupFooter1_Format(object sender, EventArgs e)
        {

        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {
            this.subReporteAnuladas.Report = new VentasCanastillaAnuladas();
           this.subReporteAnuladas.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
           ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.subReporteAnuladas.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
           ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.subReporteAnuladas.Report.DataSource).SQL = QueryAnuladas();
        }

    }
}
