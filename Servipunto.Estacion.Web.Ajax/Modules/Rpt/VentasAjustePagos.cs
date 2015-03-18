using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasAjustePagos.
    /// </summary>
    public partial class VentasAjustePagos : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        #endregion

        #region Constructor clase
        public VentasAjustePagos(DateTime fechaInicio, DateTime fechaFin)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            InitializeComponent();
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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2241, Global.Idioma);
            lblTituloFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(625, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2242, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2242, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2243, Global.Idioma);
            Label1.Text ="Pag "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1003, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1003, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2243, Global.Idioma);
            Label4.Text = "Pag " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1004, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(988, Global.Idioma);
            #region Pie de pagina

            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
        #endregion

        #region Pie de pagina
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasAjustePagos.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblTituloFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[9]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[13]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[14]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.Label8 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[8]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[0]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[2]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[5]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
        }
    }
}
