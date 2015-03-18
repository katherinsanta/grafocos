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
    /// Summary description for Balance.
    /// </summary>
    public partial class Balance : DataDynamics.ActiveReports.ActiveReport3
    {
        #region Definicion de variables de la clase
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _idTanque;
        Int16 _idArticulo;
        #endregion

        #region constructor y destructor
        /// <summary>
        /// Constructor y destructor de la clase
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio a consultar</param>
        /// <param name="fechaFin">Fecha final a consultar</param>
        /// <param name="idTanque">Tanque a consultar</param>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        public Balance(DateTime fechaInicio, DateTime fechaFin, int idTanque, Int16 idArticulo)
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
        /// <summary>
        /// Crea la cabecera del reporte
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(88, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(192, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2192, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2193, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(844, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2194, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(998, Global.Idioma);
            //Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(448, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2003, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2195, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2196, Global.Idioma);
            
            #region Pie de pagina

            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
        /// <summary>
        /// Crea el pie de pagina del reporte
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader = null;
        private DataDynamics.ActiveReports.Label Label = null;
        private DataDynamics.ActiveReports.Label Label3 = null;
        private DataDynamics.ActiveReports.Label Label4 = null;
        private DataDynamics.ActiveReports.Label Label7 = null;
        private DataDynamics.ActiveReports.Label Label9 = null;
        private DataDynamics.ActiveReports.Label Label11 = null;
        private DataDynamics.ActiveReports.Label Label15 = null;
        private DataDynamics.ActiveReports.Label lblFecha = null;
        private DataDynamics.ActiveReports.Label lblHora = null;
        private DataDynamics.ActiveReports.Label lblTituloFechas = null;
        private DataDynamics.ActiveReports.Line Line = null;
        private DataDynamics.ActiveReports.Line Line1 = null;
        private DataDynamics.ActiveReports.SubReport srptEncabezado = null;
        private DataDynamics.ActiveReports.Label Label5 = null;
        private DataDynamics.ActiveReports.GroupHeader ghArticulo = null;
        private DataDynamics.ActiveReports.TextBox TextBox14 = null;
        private DataDynamics.ActiveReports.GroupHeader ghTanque = null;
        private DataDynamics.ActiveReports.TextBox idTanque = null;
        private DataDynamics.ActiveReports.Label Label16 = null;
        private DataDynamics.ActiveReports.TextBox TextBox13 = null;
        private DataDynamics.ActiveReports.Detail Detail = null;
        private DataDynamics.ActiveReports.TextBox TextBox = null;
        private DataDynamics.ActiveReports.TextBox TextBox1 = null;
        private DataDynamics.ActiveReports.TextBox TextBox4 = null;
        private DataDynamics.ActiveReports.TextBox TextBox6 = null;
        private DataDynamics.ActiveReports.TextBox TextBox8 = null;
        private DataDynamics.ActiveReports.TextBox TextBox11 = null;
        private DataDynamics.ActiveReports.TextBox TextBox2 = null;
        private DataDynamics.ActiveReports.GroupFooter gfTanque = null;
        private DataDynamics.ActiveReports.TextBox TextBox15 = null;
        private DataDynamics.ActiveReports.Label Label17 = null;
        private DataDynamics.ActiveReports.TextBox TextBox16 = null;
        private DataDynamics.ActiveReports.GroupFooter gfArticulo = null;
        private DataDynamics.ActiveReports.TextBox TextBox3 = null;
        private DataDynamics.ActiveReports.Label Label18 = null;
        private DataDynamics.ActiveReports.TextBox TextBox19 = null;
        private DataDynamics.ActiveReports.PageFooter PageFooter = null;
        private DataDynamics.ActiveReports.Label Label1 = null;
        private DataDynamics.ActiveReports.Label Label2 = null;
        private DataDynamics.ActiveReports.Label lblAno = null;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas = null;
        private DataDynamics.ActiveReports.Label lblDe = null;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina = null;
        private DataDynamics.ActiveReports.Label lblPagina = null;
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.Balance.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghArticulo = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghArticulo"]));
            this.ghTanque = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTanque"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTanque = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTanque"]));
            this.gfArticulo = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfArticulo"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[10]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[11]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[12]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.TextBox14 = ((DataDynamics.ActiveReports.TextBox)(this.ghArticulo.Controls[0]));
            this.idTanque = ((DataDynamics.ActiveReports.TextBox)(this.ghTanque.Controls[0]));
            this.Label16 = ((DataDynamics.ActiveReports.Label)(this.ghTanque.Controls[1]));
            this.TextBox13 = ((DataDynamics.ActiveReports.TextBox)(this.ghTanque.Controls[2]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox15 = ((DataDynamics.ActiveReports.TextBox)(this.gfTanque.Controls[0]));
            this.Label17 = ((DataDynamics.ActiveReports.Label)(this.gfTanque.Controls[1]));
            this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.gfTanque.Controls[2]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[0]));
            this.Label18 = ((DataDynamics.ActiveReports.Label)(this.gfArticulo.Controls[1]));
            this.TextBox19 = ((DataDynamics.ActiveReports.TextBox)(this.gfArticulo.Controls[2]));
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

        #endregion

        #region QueryEncabezado
        /// <summary>
        /// Consulta para el encabezado del reporte
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
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
        /// <summary>
        /// Consulta principal del reporte
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void QueryPrincipal()
        {
            DataSet ds = Servipunto.Estacion.Libreria.Configuracion.Tanques.TanqueVariaciones.RptVariacionMensual(_fechaInicio, _fechaFin, _idTanque, _idArticulo, true);
            this.DataSource = ds.Tables[0];
        }
        #endregion

    }
}
