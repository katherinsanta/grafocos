using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasAutomotorResumido.
    /// </summary>
    public partial class VentasAutomotorResumido : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _placa;
        bool _todas;
        #endregion

        #region Costructor de la clase
        public VentasAutomotorResumido(DateTime fechaInicio, DateTime fechaFin, string placa, bool todas)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _placa = placa;
            _todas = todas;
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2253, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2230, Global.Idioma);
            lblFechaVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            lblTotalVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2248, Global.Idioma);
            #region Pie de pagina

            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
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
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append(" Select");
            sql.Append(" Dbo.Finteger(V.Fecha) Fecha,");
            sql.Append(" V.Placa,");			
            sql.Append(" IsNull(C.Cod_Cli, '-') CodCli,");
            sql.Append(" IsNull(SubString(C.Nombre, 1, 11), '-') Cliente,");
            sql.Append(" IsNull(Count(V.Consecutivo), 0) Num_Ventas,");
            sql.Append(" IsNull(Sum(V.Cantidad), 0) Unidades,");
            sql.Append(" IsNull(Sum(V.ValorNeto), 0) ValorNeto,");
            //sql.Append(" IsNull(Sum(V.Cantidad * V.Precio_Uni), 0) ValorNeto,");
            sql.Append(" IsNull(Sum(V.Descuento), 0) Descuento,");
            sql.Append(" IsNull(Sum(V.SubTotal), 0) SubTotal,");
            //sql.Append(" IsNull(Sum((V.Cantidad * V.Precio_Uni)-V.Descuento), 0) SubTotal,");
            sql.Append(" IsNull(Sum(V.Vr_Iva), 0) Iva,");
            sql.Append(" IsNull(Sum(V.Total_Cuota), 0) Recaudo,");
            sql.Append(" IsNull(Sum(V.Total), 0) Total");
            //sql.Append(" IsNull(Sum((V.Cantidad * V.Precio_Uni)-V.Descuento + Total_Cuota), 0) Total");
            sql.Append(" From Ventas V Left Join Clientes C");
            sql.Append(" On V.Cod_Cli = C.Cod_Cli ");
            sql.Append(" Where V.Cod_Art <> 0 And (Dbo.Finteger(V.Fecha) Between '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(" And '" + this._fechaFin.ToString("yyyyMMdd") + "')");
            if(!this._todas)
                sql.Append(" And  V.Placa = '" + this._placa + "'");
            sql.Append(" Group by C.Cod_Cli, V.Fecha, V.Placa, C.Nombre");
            sql.Append(" Order by V.Fecha ASC, V.Placa, C.Nombre");
			
            return sql.ToString();
            */

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec rptVentasPorAutomotor ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            sql.Append(",@opcion = '1'");
            if (!this._todas)
                sql.Append(",@placa = '" + _placa.Trim() + "'");
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
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec RptResumenFPago ");
            sql.Append(this._fechaInicio.ToString("yyyyMMdd") + ", ");
            sql.Append(this._fechaFin.ToString("yyyyMMdd") + ", null, null, null,");
            if(!_todas)
                sql.Append("'" + _placa + "'");
            else
                sql.Append("null ");

            return sql.ToString();
            */
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (!_todas)
                sql.Append(",@placa = '" + _placa + "'");
            return sql.ToString();

        }
        #endregion

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasAutomotorResumido.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[1]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[2]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[4]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.lblFechaVenta = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.txtFechaVenta = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtCliente = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[0]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[1]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[5]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[6]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[7]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[5]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[7]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
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
