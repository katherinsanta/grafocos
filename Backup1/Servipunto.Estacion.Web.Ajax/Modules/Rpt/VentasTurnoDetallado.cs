using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasTurnoDetallado.
    /// </summary>
    public partial class VentasTurnoDetallado : DataDynamics.ActiveReports.ActiveReport
    {
        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _turno;
        bool _todos;
        #endregion

        #region Costructor de la clase
        public VentasTurnoDetallado(DateTime fechaInicio, DateTime fechaFin, string turno, bool todos)
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2309, Global.Idioma);
            lblPlaca.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            lblIsla.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            lblGrupofecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            lblTurno.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label1.Text = "Total "+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);            
            lblEtiqueitaFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2247, Global.Idioma);            
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

            sql.Append("Select");
            sql.Append(" Dbo.Finteger(V.Fecha) Fecha,");
            sql.Append(" V.Num_Tur Turno,");
            sql.Append(" Dbo.Hinteger(Hora) Hora,");
            sql.Append(" LTrim(RTrim(V.Prefijo)) + Cast(V.Consecutivo As Varchar) Consecutivo,");
            sql.Append(" SubString(A.Descripcion, 1, 11) Articulo,");
            sql.Append(" IsNull(V.Placa, '-') as Placa,");
            sql.Append(" IsNull(convert(varchar,V.Cod_Isl), '-') Isla,");
            sql.Append(" IsNull(V.Cantidad, 0) Unidades,");
            sql.Append(" IsNull(V.ValorNeto, 0) ValorNeto,");
            //sql.Append(" IsNull(V.Cantidad * V.Precio_Uni, 0) ValorNeto,");
            sql.Append(" IsNull(V.Descuento, 0) Descuento,");
            sql.Append(" IsNull(V.SubTotal, 0) SubTotal,");
            //sql.Append(" IsNull((V.Cantidad * V.Precio_Uni) - V.Descuento, 0) SubTotal,");
            sql.Append(" IsNull(V.Vr_Iva, 0) Iva,");
            sql.Append(" IsNull(V.Total_Cuota, 0) Recaudo,");
            sql.Append(" IsNull(V.Total, 0) Total");
            //sql.Append(" IsNull((V.Cantidad * V.Precio_Uni) - V.Descuento + V.Total_Cuota, 0) Total");
            sql.Append(" From Ventas V Left Join Articulo A");
            sql.Append(" On V.Cod_Art = A.Cod_Art");
            sql.Append(" Where V.Cod_Art <> 0 And (Dbo.Finteger(Fecha) Between '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(" And '" + this._fechaFin.ToString("yyyyMMdd") + "')");
            if(!this._todos)
                sql.Append(" And V.Num_Tur = " + this._turno);
            sql.Append(" Order by V.Fecha, V.Num_Tur");			
			
            return sql.ToString();
            */
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec rptVentasPorTurno ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            sql.Append(",@Opcion = " + "3");
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
        }
        #endregion

        #region QueryGranTotal
        private string QueryGranTotal()
        {
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();

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
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasTurnoDetallado.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.ghTurno = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTurno"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTurno = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTurno"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblIsla = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.lblArticulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[3]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[4]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[6]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.lblPlaca = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
            this.lblGrupofecha = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.txtGrupoFecha = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.txtTurno = ((DataDynamics.ActiveReports.TextBox)(this.ghTurno.Controls[0]));
            this.lblTurno = ((DataDynamics.ActiveReports.Label)(this.ghTurno.Controls[1]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtPlaca = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtCuota = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtIsla = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.txtArticulo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.txtTotalPlacaUnidades = ((DataDynamics.ActiveReports.TextBox)(this.gfTurno.Controls[0]));
            this.txtTotalVentaSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTurno.Controls[1]));
            this.txttotaPlacaIVa = ((DataDynamics.ActiveReports.TextBox)(this.gfTurno.Controls[2]));
            this.TotalPlacaTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTurno.Controls[3]));
            this.txtTotalPlacaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTurno.Controls[4]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.gfTurno.Controls[5]));
            this.txtTurnoPie = ((DataDynamics.ActiveReports.TextBox)(this.gfTurno.Controls[6]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.gfTurno.Controls[7]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[1]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            this.lblEtiqueitaFecha = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[5]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[6]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[5]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[7]));
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
