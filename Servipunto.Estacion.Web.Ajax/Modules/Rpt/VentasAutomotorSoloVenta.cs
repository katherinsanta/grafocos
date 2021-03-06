using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasAutomotorSoloVenta.
    /// </summary>
    public partial class VentasAutomotorSoloVenta : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _codigoCliente;
        string _placa;
        int _ordenar;
        #endregion

        #region Constructor de la Clase
        public VentasAutomotorSoloVenta(DateTime fechaInicio, DateTime fechaFin, string codigoCliente, string placa, int ordenar)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _codigoCliente = codigoCliente;
            _placa = placa;
            _ordenar = ordenar;
            InitializeComponent();
            InitializeDatabase();
            Traducir();
        }
        #endregion

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader = null;
        private DataDynamics.ActiveReports.Label lblHora = null;
        private DataDynamics.ActiveReports.Label lblFecha = null;
        private DataDynamics.ActiveReports.SubReport srptEncabezado = null;
        private DataDynamics.ActiveReports.Label Label15 = null;
        private DataDynamics.ActiveReports.Label lblTituloFechas = null;
        private DataDynamics.ActiveReports.Label lblAutomotor = null;
        private DataDynamics.ActiveReports.GroupHeader ghTotal = null;
        private DataDynamics.ActiveReports.Line Line = null;
        private DataDynamics.ActiveReports.Label Label = null;
        private DataDynamics.ActiveReports.Label Label5 = null;
        private DataDynamics.ActiveReports.Label lblUnidades = null;
        private DataDynamics.ActiveReports.Label Label1 = null;
        private DataDynamics.ActiveReports.Label lblSubTotal = null;
        private DataDynamics.ActiveReports.Label lblIva = null;
        private DataDynamics.ActiveReports.Label lblRecaudo = null;
        private DataDynamics.ActiveReports.Label lblTotal = null;
        private DataDynamics.ActiveReports.Label Label3 = null;
        private DataDynamics.ActiveReports.Label Label4 = null;
        private DataDynamics.ActiveReports.Label Label6 = null;
        private DataDynamics.ActiveReports.Label Label7 = null;
        private DataDynamics.ActiveReports.Label Label9 = null;
        private DataDynamics.ActiveReports.Label Label10 = null;
        private DataDynamics.ActiveReports.Line Line1 = null;
        private DataDynamics.ActiveReports.Detail Detail = null;
        private DataDynamics.ActiveReports.TextBox txtTotal = null;
        private DataDynamics.ActiveReports.TextBox TextBox = null;
        private DataDynamics.ActiveReports.TextBox txtUnidades = null;
        private DataDynamics.ActiveReports.TextBox TextBox1 = null;
        private DataDynamics.ActiveReports.TextBox TextBox2 = null;
        private DataDynamics.ActiveReports.TextBox TextBox3 = null;
        private DataDynamics.ActiveReports.TextBox TextBox4 = null;
        private DataDynamics.ActiveReports.TextBox TextBox5 = null;
        private DataDynamics.ActiveReports.TextBox txtFecha = null;
        private DataDynamics.ActiveReports.TextBox TextBox6 = null;
        private DataDynamics.ActiveReports.TextBox txtConsecutivo = null;
        private DataDynamics.ActiveReports.TextBox TextBox7 = null;
        private DataDynamics.ActiveReports.TextBox TextBox8 = null;
        private DataDynamics.ActiveReports.TextBox TextBox9 = null;
        private DataDynamics.ActiveReports.GroupFooter gfTotal = null;
        private DataDynamics.ActiveReports.TextBox TextBox10 = null;
        private DataDynamics.ActiveReports.TextBox TextBox11 = null;
        private DataDynamics.ActiveReports.Label lblTotalVenta = null;
        private DataDynamics.ActiveReports.SubReport srptFormasPago = null;
        private DataDynamics.ActiveReports.SubReport srptArticulosBasico = null;
        private DataDynamics.ActiveReports.PageFooter PageFooter = null;
        private DataDynamics.ActiveReports.Label lblModulo = null;
        private DataDynamics.ActiveReports.Label Label2 = null;
        private DataDynamics.ActiveReports.Label lblPagina = null;
        private DataDynamics.ActiveReports.Label lblDe = null;
        private DataDynamics.ActiveReports.Label lblAno = null;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina = null;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas = null;
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasAutomotorSoloVenta.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[2]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblAutomotor = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.ghTotal.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[1]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[2]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[3]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[4]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[5]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[6]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[7]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[8]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[9]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[10]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[11]));
            this.Label7 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[12]));
            this.Label9 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[13]));
            this.Label10 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[14]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ghTotal.Controls[15]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.txtFecha = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.txtConsecutivo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
            this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
            this.TextBox10 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.TextBox11 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[2]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[3]));
            this.srptArticulosBasico = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
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
            this.lblAutomotor.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(362, Global.Idioma)+": " + (_placa.Trim().Length == 0 ? "All" : _placa);

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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2254, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(452, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(158, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(75, Global.Idioma);
            lblSubTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);            
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            lblTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma);
            #region Pie de pagina

            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
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
        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptVentasAutomotorSoloVenta ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            sql.Append(",@Ordenar = " + this._ordenar);
            if (_codigoCliente.Trim() != "0" && _codigoCliente.Trim() != "")
                sql.Append(",@CodigoCliente= '" + _codigoCliente.Trim() + "'");
            if (_placa.Trim() != "0" && _placa.Trim() != "")
                sql.Append(",@Placa= '" + _placa.Trim() + "'");
            return sql.ToString();

        }
        #endregion

        #region Formato del Grupo Total
        private void gfTotal_Format()
        {
            this.srptFormasPago.Report = new SubFormasPago();
            this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryGranTotal();

            this.srptArticulosBasico.Report = new SubArticulosBasico();
            this.srptArticulosBasico.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptArticulosBasico.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptArticulosBasico.Report.DataSource).SQL = " exec RptArticulosBasico ";


        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (_placa.Trim() != "0" && _placa.Trim() != "")
                sql.Append(",@placa = '" + _placa.Trim() + "'");
            if (_codigoCliente.Trim() != "0" && _codigoCliente.Trim() != "")
                sql.Append(",@cod_cli = '" + _codigoCliente.Trim() + "'");
            return sql.ToString();
        }
        #endregion

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion

        #region InitializeDatabase
        private void InitializeDatabase()
        {
            this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
            gfTotal_Format();
        }
        #endregion	

    }
}
