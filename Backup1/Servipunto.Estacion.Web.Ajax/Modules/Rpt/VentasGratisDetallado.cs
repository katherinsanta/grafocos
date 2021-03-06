using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasGratisDetallado.
    /// </summary>
    public partial class VentasGratisDetallado : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        #endregion

        #region Costructor de la clase
        public VentasGratisDetallado(DateTime fechaInicio, DateTime fechaFin)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            InitializeComponent();
            InitializeDatabase();
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
            #region fechas
            this.lblFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma) + ": " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma) + ": " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(836, Global.Idioma) + ": " +
                this._fechaInicio.ToString("dd/MM/yyyy") + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) +
                this._fechaFin.ToString("dd/MM/yyyy");
            #endregion

            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            lbl.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2271, Global.Idioma);            
            lblTituloFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            lblTituloHora.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma);
            lblTituloIsla.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            lblTituloManguera.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            lblTituloIslera.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2272, Global.Idioma);
            lblTituloNombre.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma);
            lblTituloIdentificacion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Global.Idioma);
            lblTituloPlaca.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            lblTituloFactura.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1873, Global.Idioma);
            lblTituloUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            lblTituloNeto.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);            
            lblTotalVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2248, Global.Idioma);
            #region Pie de pagina

            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append(" Exec SP_RptVentasGratis");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(" 0");

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
            this.srptFormasPago.Report = new SubFormasPago();
            this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryGranTotal();
            //InitializeGraph();
        }
        #endregion

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            //this.srptGrafica.Report = new SubGraficaVentasPorHora();
            this.srptGrafica.Report = new SubGraficaVentasPorMes();
            this.srptGrafica.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).SQL = QueryPrincipal();
            ((SubGraficaVentasPorMes)this.srptGrafica.Report).RefrescarGrafica();
        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd") + ", ");
            sql.Append("@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));

            return sql.ToString();
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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasGratisDetallado.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[1]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[2]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[4]));
            this.lbl = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblTituloIsla = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblTituloFactura = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblTituloIslera = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblTituloUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblTituloFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblTituloHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.lblTituloManguera = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.lblTituloNeto = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
            this.lblTituloPorcentaje = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
            this.lblTituloNombre = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
            this.lblTituloIdentificacion = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[18]));
            this.lblTituloPlaca = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtFactura = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtIslera = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtIsla = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtFecha = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.txtHora = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.txtManguera = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.txtValNeto = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.txtDescuento = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.txtNombreCliente = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
            this.txtIdentificaci�n = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
            this.txtPlaca = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[1]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.srptGrafica = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[3]));
            this.txtgranTotalNeto = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[4]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[5]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.ghTotal.Format += new System.EventHandler(this.ghTotal_Format);
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
        }

    }
}
