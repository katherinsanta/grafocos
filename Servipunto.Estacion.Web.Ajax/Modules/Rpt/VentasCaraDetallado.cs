using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasCaraDetallado.
    /// </summary>
    public partial class VentasCaraDetallado : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _numeroCara;
        #endregion

        #region Constructor de la Clase
        public VentasCaraDetallado(DateTime fechaInicio, DateTime fechaFin, int numeroCara)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _numeroCara = numeroCara;
            InitializeComponent();
            InitializeDatabase();
            Traducir();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("exec");
            sql.Append(" SP_RptIslaSurCaraMang");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(" 1, 'C', " + this._numeroCara);
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

        #region Formato del Grupo Gran Total
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
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec RptResumenFPago ");
            sql.Append(this._fechaInicio.ToString("yyyyMMdd") + ", ");
            sql.Append(this._fechaFin.ToString("yyyyMMdd") + ", C,");
            if(_numeroCara != 0)
                sql.Append(_numeroCara + ",");
            else
                sql.Append("null, ");
            sql.Append("null");

            return sql.ToString();
            */
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (_numeroCara != 0)
                sql.Append(",@Cod_car = '" + _numeroCara.ToString() + "'");
            return sql.ToString();
        }
        #endregion

        #region Encabezado de la pagina
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2257, Global.Idioma);
            lblCliente.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);
            lblturno.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            lblFechaVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1725, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1725, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2230, Global.Idioma);
            

            #region Pie de pagina

            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
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

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasCaraDetallado.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.ghCara = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghCara"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfCara = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfCara"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblCliente = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.lblturno = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.lblArticulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[6]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[7]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[10]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.lblFechaVenta = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.txtFechaVenta = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.txtCodigoIsla = ((DataDynamics.ActiveReports.TextBox)(this.ghCara.Controls[0]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.ghCara.Controls[1]));
            this.txtCliente = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtTurno = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtArticulo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtHora = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.txtTotalIsla = ((DataDynamics.ActiveReports.TextBox)(this.gfCara.Controls[0]));
            this.txtTotalUnidadesIsla = ((DataDynamics.ActiveReports.TextBox)(this.gfCara.Controls[1]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfCara.Controls[2]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.gfCara.Controls[3]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfCara.Controls[4]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.gfCara.Controls[5]));
            this.TextBox14 = ((DataDynamics.ActiveReports.TextBox)(this.gfCara.Controls[6]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[0]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[1]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[5]));
            this.TextBox15 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[6]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[0]));
            this.TextBox10 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.TextBox11 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.TextBox12 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.TextBox13 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[4]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[5]));
            this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
        }

    }
}
