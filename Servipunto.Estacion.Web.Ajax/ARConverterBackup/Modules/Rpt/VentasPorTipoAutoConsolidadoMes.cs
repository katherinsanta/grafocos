using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasPorTipoAutoConsolidadoMes.
    /// </summary>
    public partial class VentasPorTipoAutoConsolidadoMes : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        string _tipoAutomotor;
        #endregion

        #region Costructor de la clase
        public VentasPorTipoAutoConsolidadoMes(DateTime fechaInicio, string tipoAutomotor)
        {
            _fechaInicio = fechaInicio;
            _tipoAutomotor = tipoAutomotor;
            InitializeComponent();
            CreatingSource();
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
                this._fechaInicio.ToString("dd/MM/yyyy");
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2290, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(342, Global.Idioma);            
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
            sql.Append("exec RptVentasTipoAuto ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', 0 ");
            if (_tipoAutomotor != "-1")
                sql.Append(",'" + _tipoAutomotor + "',1");
            else
                sql.Append(",null,1");
            return sql.ToString();
        }
        #endregion

        #region Metodo CreatingSource
        private void CreatingSource()
        {
            switch (_fechaInicio.Month)
            {
                case 1:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2290, Global.Idioma); //"Enero";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2302, Global.Idioma); //"Diciembre";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2301, Global.Idioma); //"Noviembre";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2300, Global.Idioma); //"Octubre";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2299, Global.Idioma); //"Septiembre";
                    break;

                case 2:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2291, Global.Idioma); //"Febrero";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2290, Global.Idioma); //"Enero";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2302, Global.Idioma); //"Diciembre";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2301, Global.Idioma); //"Noviembre";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2300, Global.Idioma); //"Octubre";
                    break;

                case 3:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2292, Global.Idioma); //"Marzo";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2291, Global.Idioma); //"Febrero";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2290, Global.Idioma); //"Enero";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2302, Global.Idioma); //"Diciembre";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2301, Global.Idioma); //"Noviembre";
                    break;

                case 4:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2293, Global.Idioma); //"Abril";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2292, Global.Idioma); //"Marzo";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2291, Global.Idioma); //"Febrero";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2290, Global.Idioma); //"Enero";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2302, Global.Idioma); //"Diciembre";
                    break;

                case 5:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2294, Global.Idioma); //"Mayo";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2293, Global.Idioma); //"Abril";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2292, Global.Idioma); //"Marzo";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2291, Global.Idioma); //"Febrero";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2290, Global.Idioma); //"Enero";
                    break;

                case 6:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2295, Global.Idioma); //"Junio";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2294, Global.Idioma); //"Mayo";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2293, Global.Idioma); //"Abril";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2292, Global.Idioma); //"Marzo";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2291, Global.Idioma); //"Febrero";
                    break;

                case 7:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2297, Global.Idioma); //"Julio";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2296, Global.Idioma); //"Junio";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2295, Global.Idioma); //"Mayo";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2294, Global.Idioma); //"Abril";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2293, Global.Idioma); //"Marzo";
                    break;

                case 8:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2298, Global.Idioma); //"Agosto";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2297, Global.Idioma); //"Julio";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2296, Global.Idioma); //"Junio";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2295, Global.Idioma); //"Mayo";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2294, Global.Idioma); //"Abril";
                    break;

                case 9:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2299, Global.Idioma); //"Septiembre";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2298, Global.Idioma); //"Agosto";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2297, Global.Idioma); //"Julio";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2296, Global.Idioma); //"Junio";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2295, Global.Idioma); //"Mayo";
                    break;

                case 10:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2300, Global.Idioma); //"Octubre";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2299, Global.Idioma); //"Septiembre";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2298, Global.Idioma); //"Agosto";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2297, Global.Idioma); //"Julio";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2296, Global.Idioma); //"Junio";
                    break;

                case 11:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2301, Global.Idioma); //"Noviembre";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2300, Global.Idioma); //"Octubre";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2299, Global.Idioma); //"Septiembre";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2298, Global.Idioma); //"Agosto";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2297, Global.Idioma); //"Julio";
                    break;

                case 12:
                    lblMes1.Text = txtMes1.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2302, Global.Idioma); //"Diciembre";
                    lblMes2.Text = txtMes2.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2301, Global.Idioma); //"Noviembre";
                    lblMes3.Text = txtMes3.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2300, Global.Idioma); //"Octubre";
                    lblMes4.Text = txtMes4.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2299, Global.Idioma); //"Septiembre";
                    lblMes5.Text = txtMes5.DataField = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2298, Global.Idioma); //"Agosto";
                    break;
            }
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

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasPorTipoAutoConsolidadoMes.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[2]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblMes1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblMes2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblMes3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblMes4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblMes5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[11]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[12]));
            this.txtMes1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtMes2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtMes3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtMes4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtMes5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
        }

    }
}
