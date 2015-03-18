using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for InformacionCuposAutomotores.
    /// </summary>
    public partial class InformacionCuposAutomotores : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        string _orden;
        string _codigo;
        #endregion

        #region Constructor de la Clase
        public InformacionCuposAutomotores(string codigo, string orden)
        {
            _codigo = codigo;
            _orden = orden;
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2224, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(154, Global.Idioma);
            lblSubTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1679, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1680, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            lblTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2225, Global.Idioma);

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
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            if (_orden != "-1")
                sql.Append("exec RptCuposAuto '" + _codigo + "', " + _orden);
            else
                sql.Append("exec RptCuposAuto '" + _codigo + "'");
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

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.InformacionCuposAutomotores.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[2]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[6]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[7]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[0]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.GroupFooter1.Controls[1]));
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
    }
}
