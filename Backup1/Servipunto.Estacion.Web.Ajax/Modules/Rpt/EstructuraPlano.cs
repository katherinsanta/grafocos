using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for EstructuraPlano.
    /// </summary>
    public partial class EstructuraPlano : DataDynamics.ActiveReports.ActiveReport
    {

        #region Declaracion de variables
        string _tipoArchivo = "";
        string _tituloArchivo = "";
        #endregion
        #region Constructor de la Clase
        public EstructuraPlano(string tipoArchivo, string tituloArchivo)
        {
            _tipoArchivo = tipoArchivo;
            _tituloArchivo = tituloArchivo;
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
            this.lblTitulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma)+": (" + _tituloArchivo + ")";
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
            lablelx.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2199, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2200, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2201, Global.Idioma);
            lblSubTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2202, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2203, Global.Idioma);
            lblTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2204, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2205, Global.Idioma);            
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
        private void QueryPrincipal()
        {
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec AutomotoQuery");
            return sql.ToString();
            */
            DataSet ds;
            ds = Libreria.UtilidadesGenerales.RecuperarEstructuraPlano(0, "ReporteEstructura", "", _tipoArchivo);

            if (ds.Tables[0].Rows.Count > 0)
                this.DataSource = ds.Tables[0];
        }
        #endregion

        #region InitializeDatabase
        private void InitializeDatabase()
        {
            /*this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
            */
            QueryPrincipal();
        }
        #endregion

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader = null;
        private DataDynamics.ActiveReports.Label lblHora = null;
        private DataDynamics.ActiveReports.Label lblFecha = null;
        private DataDynamics.ActiveReports.SubReport srptEncabezado = null;
        private DataDynamics.ActiveReports.Label lablelx = null;
        private DataDynamics.ActiveReports.Label lblUnidades = null;
        private DataDynamics.ActiveReports.Label lblIva = null;
        private DataDynamics.ActiveReports.Label lblTotal = null;
        private DataDynamics.ActiveReports.Label lblSubTotal = null;
        private DataDynamics.ActiveReports.Label Label1 = null;
        private DataDynamics.ActiveReports.Label Label = null;
        private DataDynamics.ActiveReports.Line Line = null;
        private DataDynamics.ActiveReports.Line Line1 = null;
        private DataDynamics.ActiveReports.Label lblTitulo = null;
        private DataDynamics.ActiveReports.Detail Detail = null;
        private DataDynamics.ActiveReports.TextBox txtSubTotal = null;
        private DataDynamics.ActiveReports.TextBox txtRecaudo = null;
        private DataDynamics.ActiveReports.TextBox txtUnidades = null;
        private DataDynamics.ActiveReports.TextBox TextBox6 = null;
        private DataDynamics.ActiveReports.TextBox TextBox = null;
        private DataDynamics.ActiveReports.TextBox TextBox1 = null;
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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.EstructuraPlano.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[2]));
            this.lablelx = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[10]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[11]));
            this.lblTitulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
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

    }
}
