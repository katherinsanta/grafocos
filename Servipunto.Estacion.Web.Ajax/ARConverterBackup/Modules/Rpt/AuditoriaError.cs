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
    /// Summary description for AuditoriaError.
    /// </summary>
    public partial class AuditoriaError : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de variables de la clase
        DateTime _fechaInicio;
        DateTime _fechaFinal;
        int _idAplicativo;
        int _idTipoError;
        string _campoOrdenar;
        string _detalledebug;
        string _detallepersonal;
        string _posibleSuceso;
        #endregion

        #region constructor y destructor
        public AuditoriaError(DateTime fechaInicial,
                                DateTime fechaFinal,
                                int idAplicativo,
                                int idTipoError,
                                string campoOrdenar,
                                string detalledebug,
                                string detallepersonal,
                                string posibleSuceso
                                )
        {
            _fechaInicio = fechaInicial;
            _fechaFinal = fechaFinal;
            _idAplicativo = idAplicativo;
            _idTipoError = idTipoError;
            _campoOrdenar = campoOrdenar;
            _detalledebug = detalledebug;
            _detallepersonal = detallepersonal;
            _posibleSuceso = posibleSuceso;

            InitializeComponent();
            QueryPrincipal();
            Traducir();
        }
        #endregion

        #region Cabecera y pie de pagina
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            #region fechas
            this.lblFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma) + ": " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma) + ": " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(836, Global.Idioma) + ": " +
                this._fechaInicio.ToString("dd/MM/yyyy") + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) +
                this._fechaFinal.ToString("dd/MM/yyyy");
            #endregion

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
            DataSet ds = Servipunto.Estacion.Libreria.Usuarios.RptAuditoriaError(_fechaInicio,
                                                                                _fechaFinal,
                                                                                _idAplicativo,
                                                                                _idTipoError,
                                                                                _campoOrdenar,
                                                                                _detalledebug,
                                                                                _detallepersonal,
                                                                                _posibleSuceso
                                                                                );
            if (ds.Tables[0].Rows.Count > 0)
                this.DataSource = ds.Tables[0];

        }
        #endregion

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.AuditoriaError.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[4]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[5]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[11]));
            this.Label16 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
            this.idTanque = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[1]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.Label7 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[5]));
            this.Label9 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[6]));
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
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(437, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1626, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(813, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(814, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(831, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(817, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(439, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(832, Global.Idioma);
            #region Pie de pagina            
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion
            
        }
        #endregion

    }
}
