using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for NewActiveReport1.
    /// </summary>
    public partial class LogPlanillaDia : DataDynamics.ActiveReports.ActiveReport
    {

         DateTime _fechaInicio;
     

        public LogPlanillaDia(DateTime Fechainicio)

        {
            _fechaInicio = Fechainicio;
       
           
            InitializeComponent();
            QueryPrincipal();
            Traducir();
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {

        }

        private void detail_Format(object sender, EventArgs e)
        {

        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            this.lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Hora: " + DateTime.Now.ToString("hh:mm tt");
          
                this.lblTituloFechas.Text = "Entre las fechas: " +
                    this._fechaInicio.ToString("dd/MM/yyyy") + " y " +
                   this._fechaInicio.ToString("dd/MM/yyyy");
           
            this.srptEncabezado.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }


        #region ConsultaEncabezado
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



        private void QueryPrincipal()
        {
            //SubRptResumenDiarioCalibraciones
            this.DataSource = CargarDatosLogPlanilla();
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            //Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23656, Global.Idioma);
            //label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(144, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            //Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(247, Global.Idioma);
            //Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(940, Global.Idioma);
            //Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
        
            //#region Pie de pagina
            //Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            //Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            //lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            //lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            //#endregion

        }
        #endregion

        private DataTable CargarDatosLogPlanilla()
        {


            return Libreria.LogPlanillaTurno.CargarLogPlanilla(_fechaInicio);



        }
    }
}
