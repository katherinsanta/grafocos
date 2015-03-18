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
    /// Summary description for Calibracion.
    /// </summary>
    public partial class Calibracion : DataDynamics.ActiveReports.ActiveReport
    {

        DateTime _fechaInicio;
        DateTime _fechaFinal;
        string _Tiporeporte98;
        string _Turno;
        string _Articulo;

        public Calibracion(string Tiporeporte98, string Turno,string Articulo, DateTime Fechainicio, DateTime Fechafinal)

        {
            _fechaInicio = Fechainicio;
            _fechaFinal = Fechafinal;
            _Tiporeporte98 = Tiporeporte98;
            _Turno = Turno;
            _Articulo = Articulo;
           
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
            this.lblFecha.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            if (_Tiporeporte98 == "1")
            {
                this.lblTituloFechas.Text = "Between shift dates: " +
                    this._fechaInicio.ToString("dd/MM/yyyy") + " To " +
                   this._fechaFinal.ToString("dd/MM/yyyy");
            }
            else
            {
                this.lblTituloFechas.Text = "Between real dates: " +
                     this._fechaInicio.ToString("dd/MM/yyyy") + " Tp " +
                    this._fechaFinal.ToString("dd/MM/yyyy");
            }
            this.srptEncabezado.Report = new SubEncabezado();
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
          this.DataSource = Servipunto.Estacion.Libreria.Ventas.RecuperarVentas98Turno(_Tiporeporte98, _Turno , _Articulo, _fechaInicio,_fechaFinal  );                                                                                                  
           
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23656, Global.Idioma);
            label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(144, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(247, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(940, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1725, Global.Idioma);
            label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(567, Global.Idioma);
            label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(989, Global.Idioma);
            #region Pie de pagina
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
    }
}
