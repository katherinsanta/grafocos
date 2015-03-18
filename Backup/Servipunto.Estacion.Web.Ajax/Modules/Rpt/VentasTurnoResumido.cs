using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasTurnoResumido.
    /// </summary>
    public partial class VentasTurnoResumido : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _turno;
        bool _todos;
        #endregion

        #region Costructor de la clase
        public VentasTurnoResumido(DateTime fechaInicio, DateTime fechaFin, string turno, bool todos)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _turno = turno;
            _todos = todos;
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2310, Global.Idioma);
            lblTurno.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);            
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);            
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
            sql.Append("Select");
//			sql.Append(" Dbo.Finteger(V.Fecha) Fecha,");
            sql.Append(" V.Num_Tur Turno,");
            sql.Append(" Count (V.Consecutivo ) Cantidad_de_Ventas,");
            sql.Append(" IsNull(Sum(V.Cantidad), 0) Unidades,");
            //Modificacion 14/08/2006 -> Juan Fernando Obando Trejos
            sql.Append(" IsNull(Sum(V.ValorNeto), 0) ValorNeto,");
            //sql.Append(" IsNull(Sum(V.Cantidad * V.Precio_Uni), 0) ValorNeto,");
            sql.Append(" IsNull(Sum(V.Descuento), 0) Descuento,");
            //Modificacion 14/08/2006 -> Juan Fernando Obando Trejos
            sql.Append(" IsNull(Sum(V.SubTotal), 0) SubTotal,");
            //sql.Append(" IsNull(Sum((V.Cantidad * V.Precio_Uni)-V.Descuento), 0) SubTotal,");
            sql.Append(" IsNull(Sum(V.Vr_Iva), 0) Iva,");
            sql.Append(" IsNull(Sum(V.Total_Cuota), 0) Recaudo,");
            //Modificacion 14/08/2006 -> Juan Fernando Obando Trejos
            sql.Append(" IsNull(Sum(V.Total), 0) Total");
            //sql.Append(" IsNull(Sum((V.Cantidad * V.Precio_Uni)-V.Descuento + V.Total_Cuota), 0) Total");
            sql.Append(" From Ventas V");
            sql.Append(" Where V.Cod_Art <> 0 And (Dbo.Finteger(V.Fecha) Between '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(" And '" + this._fechaFin.ToString("yyyyMMdd") + "')");
            if(!this._todos)
                sql.Append(" And V.Num_Tur = " + this._turno);
            sql.Append(" Group by V.Num_Tur");
            sql.Append(" Order by V.Num_Tur");	
			
            return sql.ToString();
            */

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec rptVentasPorTurno ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            sql.Append(",@Opcion = " + "1");
            if (!this._todos)
                sql.Append(",@turno = " + this._turno);
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
            InitializeGraph();
        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {/*
			System.Text.StringBuilder sql = new System.Text.StringBuilder();

			sql.Append("exec RptResumenFPago ");
			sql.Append(this._fechaInicio.ToString("yyyyMMdd") + ", ");
			sql.Append(this._fechaFin.ToString("yyyyMMdd") + ", null,null");
			if(!this._todos)
				sql.Append("," + this._turno);

			return sql.ToString();
			*/
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (!this._todos)
                sql.Append(",@Num_tur = '" + this._turno + "'");
            return sql.ToString();

        }
        #endregion

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            this.srptGrafica.Report = new SubGraficaTurno();
            this.srptGrafica.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).SQL = QueryPrincipal();
            ((SubGraficaTurno)this.srptGrafica.Report).RefrescarGrafica();
        }
        #endregion

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasTurnoResumido.rpx");
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
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblTurno = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtTurno = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[5]));
            this.srptGrafica = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[6]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[7]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[8]));
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
