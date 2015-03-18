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
    /// Summary description for Tanque.
    /// </summary>
    public partial class Tanque : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de variables de la clase
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _idTanque;
        Int16 _idArticulo;
        #endregion

        #region constructor y destructor
        public Tanque(DateTime fechaInicio, DateTime fechaFin, int idTanque, Int16 idArticulo)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _idTanque = idTanque;
            _idArticulo = idArticulo;
            InitializeComponent();
            QueryPrincipal();
            Traducir();
        }
        #endregion

        #region Cabecera y pie de pagina
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            this.lblFecha.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "Between the dates of issue: " +
                this._fechaInicio.ToString("dd/MM/yyyy") + " To " +
                this._fechaFin.ToString("dd/MM/yyyy");

            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();

        }

        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
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

        #region QueryPrincipal
        private void QueryPrincipal()
        {
            DataSet ds = Servipunto.Estacion.Libreria.Configuracion.Tanques.TanqueVariaciones.RptVariacionMensual(_fechaInicio, _fechaFin, _idTanque, _idArticulo, false);
            this.DataSource = ds.Tables[0];
        }
        #endregion

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.Tanque.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghProducto = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghProducto"]));
            this.ghTanque = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTanque"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTanque = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTanque"]));
            this.gfProducto = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfProducto"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            //this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
           // this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            //this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[18]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[19]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[20]));
            this.TextBox14 = ((DataDynamics.ActiveReports.TextBox)(this.ghProducto.Controls[0]));
            this.idTanque = ((DataDynamics.ActiveReports.TextBox)(this.ghTanque.Controls[0]));
            this.Label16 = ((DataDynamics.ActiveReports.Label)(this.ghTanque.Controls[1]));
            this.TextBox13 = ((DataDynamics.ActiveReports.TextBox)(this.ghTanque.Controls[2]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            //this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.TextBox10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
            this.TextBox11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
            this.TextBox12 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
            this.TextBox20 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
            this.txtTotalGrupo = ((DataDynamics.ActiveReports.TextBox)(this.gfTanque.Controls[0]));
            this.TextBox15 = ((DataDynamics.ActiveReports.TextBox)(this.gfTanque.Controls[1]));
            this.Label17 = ((DataDynamics.ActiveReports.Label)(this.gfTanque.Controls[2]));
            this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.gfTanque.Controls[3]));
            //this.TextBox17 = ((DataDynamics.ActiveReports.TextBox)(this.gfProducto.Controls[0]));
            //this.TextBox18 = ((DataDynamics.ActiveReports.TextBox)(this.gfProducto.Controls[1]));
            this.Label18 = ((DataDynamics.ActiveReports.Label)(this.gfProducto.Controls[2]));
            this.TextBox19 = ((DataDynamics.ActiveReports.TextBox)(this.gfProducto.Controls[3]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[3]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
        }

        private void gfProducto_Format(object sender, EventArgs e)
        {

        }

        private void gfTanque_Format(object sender, EventArgs e)
        {

        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2238, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(811, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2046, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23645, Global.Idioma);
            label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23646, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23647, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(844, Global.Idioma);
            label22.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23648, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23649, Global.Idioma);
            label25.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23650, Global.Idioma);
            label26.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23651, Global.Idioma);
            label24.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23652, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1005, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23653, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23654, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23655, Global.Idioma);
            //PIE DE PAGINA
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
        }
        #endregion
    }
}
