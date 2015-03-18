using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasHoraArticulo.
    /// </summary>
    public partial class VentasHoraArticulo : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _hora;
        int _codigoArticulo;

        #endregion

        #region Costructor de la clase
        public VentasHoraArticulo(DateTime fechaInicio, DateTime fechaFin, int hora, int codigoArticulo)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _hora = hora;
            _codigoArticulo = codigoArticulo;
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
            lbl.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2273, Global.Idioma);
            lbltituloHora.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma);            
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            lblCantidadVentas.Text ="No. "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(483, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);            
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

            sql.Append(" Exec ReporteHoraArticulo");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(" 1,");
            sql.Append(this._hora.ToString() + ",");
            sql.Append(this._codigoArticulo).ToString();

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
        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (this._hora != 24)
            {
                sql.Append(",@Num_Hora = '" + this._hora.ToString() + "'");
            }
            if (this._codigoArticulo != 0)
            {
                sql.Append(",@Cod_Art = '" + this._codigoArticulo.ToString() + "'");
            }
            return sql.ToString();

        }
        #endregion

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasHoraArticulo.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.lbl = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lbltituloHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblCantidadVentas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblArticulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.txtHora = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.txtcntidadVentas = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.txtArticulo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[0]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[4]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[5]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[7]));
            this.srptGrafica = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[8]));
            this.txtTotalCantVentas = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[9]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[3]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
        }

    }
}
