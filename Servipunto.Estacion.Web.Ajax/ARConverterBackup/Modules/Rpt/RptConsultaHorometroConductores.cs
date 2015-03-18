using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for RptConsultaHorometroConductores.
    /// </summary>
    public partial class RptConsultaHorometroConductores : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _idConductor;
        #endregion

        #region Costructor de la clase
        public RptConsultaHorometroConductores(DateTime fechaInicio, DateTime fechaFin, int idioma)
        {            
            _fechaInicio = fechaInicio; // DateTime.Parse(System.DateTime.Now.Year.ToString().PadLeft(4, '0') + "-" + this._mes.ToString().PadLeft(2, '0') + "-" + "01");            
            _fechaFin = fechaFin;
          
            InitializeComponent();
            InitializeDatabase();
            if (idioma == 1)
                Traducir();
        }
        #endregion

        #region QueryEncabezado
        private string QueryEncabezado()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("Select");
            sql.Append(" Razon_Social,");
            sql.Append(" Nit,");
            sql.Append(" Nit_Dive");
            sql.Append(" From Dat_Gene");
            return sql.ToString();
        }
        #endregion

        #region Formato del Encabezado de Pagina
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            this.lblFecha.Text = "Date: " + DateTime.Now.ToShortDateString();
            this.lblHora.Text = "Hour: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "Between the dates of issue: " +
                this._fechaInicio.ToString("dd/MM/yyyy") + " To " +
                this._fechaFin.ToString("dd/MM/yyyy");

            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append(" Exec ConsultaHorometro");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "'");
          
                    
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

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion

        #region Formato del Grupo Total
        private void gfTotal_Format(object sender, System.EventArgs eArgs)
        {
               }
        #endregion

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            //this.srptGrafica.Report = new SubGraficaVentasPorHora();
        }
        #endregion
             
        private void ghTotal_Format(object sender, System.EventArgs eArgs)
        {

        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {

        }

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.CierreMesColvanes.rpx");       
           
            // Attach Report Events

        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            
        }

        private void reportFooter1_AfterPrint(object sender, EventArgs e)
        {
           // decimal v = Convert.ToDecimal(textBox5.Text);
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 17/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblTitulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23730, Global.Idioma);
            lblTurno.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23725, Global.Idioma) + " " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1476, Global.Idioma);
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(827, Global.Idioma);
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(828, Global.Idioma);
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23601, Global.Idioma);
            label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma) + "s";
            label6.Text = label6.Text.Substring(0, 1).ToUpper() + label6.Text.Substring(1).ToLower();
            label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1167, Global.Idioma).Split(' ')[0];
            label13.Text = "Total " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2212, Global.Idioma);
            label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23732, Global.Idioma);
            #region Pie De Página
            lblCopyRight.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion
        }
        #endregion
    }
}
