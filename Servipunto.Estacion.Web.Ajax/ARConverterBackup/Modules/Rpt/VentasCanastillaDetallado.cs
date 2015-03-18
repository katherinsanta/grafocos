using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasCanastillaDetallado.
    /// </summary>
    public partial class VentasCanastillaDetallado : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _codigo;
        string _codigoEmpleado;
        string _nombreEmpleado;
        #endregion

        #region Constructor de la Clase
        /// <summary>
        /// Reporte de ventas detallado por canastilla
        /// </summary>		
        /// Modificación: Se creo un nuevo parametro de consulta "CodigoEmpleado" y "nombreEmpleado"
        /// Referencia Documental:  Automatizacion > Solicitud_Cambio _Administrativo_002_GR_SC
        /// Fecha:  26/08/2008
        /// Autor:  Elvis Astaiza Gutierrez
        public VentasCanastillaDetallado(DateTime fechaInicio, DateTime fechaFin, string codigo, string codigoEmpleado, string nombreEmpleado, int Idioma)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _codigo = codigo;
            _codigoEmpleado = codigoEmpleado;
            _nombreEmpleado = nombreEmpleado;
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
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
                this._fechaInicio.ToString("dd/MM/yyyy")+ " " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) + " " +
                this._fechaFin.ToString("dd/MM/yyyy");
            #endregion
            this.lblEmpleado.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(542, Global.Idioma) + " (" + (_codigoEmpleado == "0" ? "All" : _nombreEmpleado) + ")";

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
            lblTitulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2255, Global.Idioma);
            lblConsecutivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            lblFechaGroup.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            lblFactura.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(483, Global.Idioma);
            lblTotalFactura.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2248, Global.Idioma);

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
        /// <summary>
        /// Crea la sentencia sql
        /// </summary>
        /// <returns>La cadena de consulta principal</returns>
        /// Modificación: Se creo un nuevo parametro de consulta "CodigoEmpleado"
        /// Referencia Documental:  Automatizacion > Solicitud_Cambio _Administrativo_002_GR_SC
        /// Fecha:  26/08/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec");
            sql.Append(" RptVentsArticulo");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(" 1, 0, " + _codigo + ",0,0");
            if (_codigoEmpleado != "0")
                sql.Append(", @CodigoEmpleado = '" + _codigoEmpleado + "'");

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
            this.srptFormasPago.Report = new SubFormasPagoCanastilla();
            this.srptFormasPago.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptFormasPago.Report.DataSource).SQL = QueryGranTotal();
        }
        #endregion

        #region QueryGranTotal
        /// <summary>
        /// Crea la sentencia sql
        /// </summary>
        /// <returns>La cadena de consulta de totales por forma de pago</returns>
        /// Modificación: Se creo un nuevo parametro de consulta "CodigoEmpleado"
        /// Referencia Documental:  Automatizacion > Solicitud_Cambio _Administrativo_002_GR_SC
        /// Fecha:  26/08/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private string QueryGranTotal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("Select");
            sql.Append(" F.Cod_For_Pag Codigo,");
            sql.Append(" F.Descripcion Forma_De_Pago,");
            sql.Append(" IsNull(Count(distinct VCI.Consecutivo), 0) Cantidad_de_Pagos,");
            sql.Append(" IsNull(Sum(VCI.Cantidad), 0) cantidad,");
            sql.Append(" IsNull(Sum(VCI.Total), 0) Total");
            sql.Append(" From Form_Pag F Left Join ( VentaCanastillaItems VCI Inner Join  VentaCanastilla VC");
            sql.Append(" On ( VCI.Consecutivo = VC.Consecutivo ))");
            sql.Append(" On (F.Cod_For_Pag = VC.Cod_For_Pag)");
            sql.Append(" And (Dbo.Finteger(Fecha) Between '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(" And '" + this._fechaFin.ToString("yyyyMMdd") + "')");
            if (_codigoEmpleado != "0")
                sql.Append(" And VC.Cod_emp = '" + _codigoEmpleado + "'");
            if (_codigo != "0")
                sql.Append(" And VCI.Cod_art = '" + _codigo + "'");

            sql.Append(" Group By F.Cod_For_Pag, F.Descripcion");
            return sql.ToString();
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasCanastillaDetallado.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.ghFactura = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFactura"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfFactura = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFactura"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.lblTitulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblConsecutivo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[8]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[9]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblEmpleado = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.lblFechaGroup = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.txtFecha = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.lblFactura = ((DataDynamics.ActiveReports.Label)(this.ghFactura.Controls[0]));
            this.txtFactura = ((DataDynamics.ActiveReports.TextBox)(this.ghFactura.Controls[1]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtCantidad = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtConsecutivo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.lblTotalFactura = ((DataDynamics.ActiveReports.Label)(this.gfFactura.Controls[0]));
            this.txtTotalFactura = ((DataDynamics.ActiveReports.TextBox)(this.gfFactura.Controls[1]));
            //this.txtTotalfactura = ((DataDynamics.ActiveReports.TextBox)(this.gfFactura.Controls[2]));
            //this.txtTotalUnidades = ((DataDynamics.ActiveReports.TextBox)(this.gfFactura.Controls[3]));
            //this.txtTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfFactura.Controls[4]));
            //this.lblEtiquetaTotalFecha = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[0]));
            //this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[1]));
            //this.txtTotalFecha = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            //this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            //this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            //this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            //this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            //this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            //this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[3]));
            //this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[4]));
            //this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            //this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            //this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            //this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            //this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            //this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            //this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
        }

    }
}
