using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasPorEmpleadoTurnoIslaMangueraResumido.
    /// </summary>
    public partial class VentasPorEmpleadoTurnoIslaMangueraResumido : DataDynamics.ActiveReports.ActiveReport3
    {
        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _empleado;
        int _turno;
        int _isla;
        int _manguera;
        bool _todosEmpleados;
        bool _todosTurnos;
        bool _todasMangueras;
        #endregion

        #region Costructor de la clase
        public VentasPorEmpleadoTurnoIslaMangueraResumido(DateTime fechaInicio, DateTime fechaFin, int empleado, bool todosEmpleados, int turno, bool todosTurnos, int isla, int manguera, bool todasMangueras)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _empleado = empleado;
            _turno = turno;
            _isla = isla;
            _manguera = manguera;
            _todosEmpleados = todosEmpleados;
            _todosTurnos = todosTurnos;
            _todasMangueras = todasMangueras;
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
            lbl.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2288, Global.Idioma);
            Label1.Text ="No. "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(483, Global.Idioma);            
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);            
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(542, Global.Idioma);            
            Label9.Text = "Total " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(542, Global.Idioma);            
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

            sql.Append("Exec ");
            sql.Append("SP_RptEmployee ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
            sql.Append("'" + this._fechaFin.ToString("yyyyMMdd") + "', 0, ");

            if (this._todosEmpleados)
                sql.Append("'Todos', ");
            else
                sql.Append(this._empleado + ", ");

            if (this._todosTurnos)
                sql.Append("0, ");
            else
                sql.Append(this._turno + ", ");

            sql.Append(this._isla + ", ");

            if (this._todasMangueras)
                sql.Append("0");
            else
                sql.Append(this._manguera);

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

        #region Formato del Pie del Grupo Total
        private void gfTotal_Format(object sender, System.EventArgs eArgs)
        {
            InitializeGraph();
        }
        #endregion

        #region Iniciar Grafica
        private void InitializeGraph()
        {
            this.srptGrafica.Report = new SubGraficaVentasEmpleado();
            //Servipunto.Estacion.Libreria.Aplicacion.Refresh();
            this.srptGrafica.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptGrafica.Report.DataSource).SQL = QueryPrincipal();
            ((SubGraficaVentasEmpleado)this.srptGrafica.Report).RefrescarGrafica();
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaMangueraResumido.rp" +
    "x");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghEmpleado = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghEmpleado"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfEmpleado = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfEmpleado"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[1]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[2]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[4]));
            this.lbl = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.ghEmpleado.Controls[0]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.ghEmpleado.Controls[1]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox42 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox13 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[0]));
            this.TextBox14 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[1]));
            this.TextBox15 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[2]));
            this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[3]));
            this.Label9 = ((DataDynamics.ActiveReports.Label)(this.gfEmpleado.Controls[4]));
            this.TextBox17 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[5]));
            this.TextBox18 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[6]));
            this.TextBox40 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[7]));
            this.TextBox46 = ((DataDynamics.ActiveReports.TextBox)(this.gfEmpleado.Controls[8]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[4]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[5]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.TextBox48 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[7]));
            this.srptGrafica = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[8]));
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
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
        }



    }
}
