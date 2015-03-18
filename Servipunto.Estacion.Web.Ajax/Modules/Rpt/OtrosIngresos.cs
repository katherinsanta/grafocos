using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for OtrosIngresos.
    /// </summary>
    public partial class OtrosIngresos : DataDynamics.ActiveReports.ActiveReport
    {

        #region Declaracion de Variables
        private string      _FechaDe;
        private string      _TipoReporte;
        private DateTime    _FechaInicial;
        private DateTime    _FechaFinal;
        #endregion
        #region Constructor
        public OtrosIngresos(string Fechade, string TipoReporte, DateTime FechaInicial, DateTime FechaFinal)
        {
            _FechaDe = Fechade;
            _TipoReporte = TipoReporte;
            _FechaInicial = FechaInicial;
            _FechaFinal = FechaFinal;

            
            InitializeComponent();
            QueryPrincipal();
            Traducir();
        }
        #endregion
        #region Cabecera
        private void pageHeader_Format(object sender, EventArgs e)
        {

            if (_FechaDe == "1") {
                LblTitulo.Text = LblTitulo.Text  + " Per Shift";

                if (_TipoReporte == "1")
                {
                    LblTitulo.Text = LblTitulo.Text + " Summarized";
                }
                else {
                    LblTitulo.Text = LblTitulo.Text + " Detailed";
                }
            }
            else {
                LblTitulo.Text = LblTitulo.Text  + " per Real Date";
            }
            LblTitulo.Text += " Report";
            this.lblFecha.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "Between the dates: " +
                this._FechaInicial.ToString("dd/MM/yyyy") + " To " +
                this._FechaFinal.ToString("dd/MM/yyyy");

            if (_TipoReporte == "1")
            {
                Label4.Visible = false;
                TextBox1.Visible = false;
            }
            else
            {
                Label4.Visible = true;
                TextBox1.Visible = true ;
            }

            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();


        }
        #endregion
        #region Pie de pagina
        private void pageFooter_Format(object sender, EventArgs e)
        {

        }
        #endregion
        #region InicializaReporte
        public void InitializeReport()
        {            
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.pageFooter.Controls[3]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.pageFooter.Controls[5]));
      }
        #endregion
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
        #region consultaPrincipal
        private void QueryPrincipal()
        {

            this.DataSource = Servipunto.Estacion.Libreria.Ventas.RecuperarVentasOtrosIngresos(_FechaDe, _TipoReporte, _FechaInicial, _FechaFinal);
                        
        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {
            if (TextBox1.Text != null)
            {
                if (TextBox1.Text != "hora")
                    TextBox1.Text = Convert.ToDateTime(TextBox1.Text).ToShortTimeString();
            }
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            LblTitulo.Text = "Other Incomes";
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(247, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23599, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(989, Global.Idioma);
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
