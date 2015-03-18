using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ExtractoClienteDetalleBajo.
    /// </summary>
    public partial class ExtractoClienteDetalleBajo : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        string _codigoAutomotor;
        string _codigoCliente;
        int _formaPago;
        bool _todosClientes;
        bool _todosAutomotores;
        string _horaInicio;
        string _horaFinal;
        #endregion

        #region Constructor de la Clase
        public ExtractoClienteDetalleBajo(DateTime fechaInicio, DateTime fechaFin,  string horainicio, string horafinal, int formaPago, string codigoAutomotor, bool todosAutomotores, string codigoCliente, bool todosClientes)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _horaInicio = horainicio;
            _horaFinal = horafinal;
            _formaPago = formaPago;
            _codigoAutomotor = codigoAutomotor;
            _codigoCliente = codigoCliente;
            _todosClientes = todosClientes;
            _todosAutomotores = todosAutomotores;
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
            sql.Append(" LTrim(RTrim(Nit + Nit_Dive)) Nit,");
            sql.Append(" LTrim(RTrim(Razon_Social))R_Social,");
            sql.Append(" LTrim(RTrim(DIRECCION)) Dir,");
            sql.Append(" LTrim(RTrim(TELEFONO)) Tel, LTrim(RTrim(CIUDAD)) Ciudad");
            sql.Append(" From Dat_Gene");
            return sql.ToString();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("SP_RptExtractoCliente ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
            sql.Append("'" + this._fechaFin.ToString("yyyyMMdd") + "', 0, ");
            sql.Append(this._formaPago + ", ");

            if (this._todosClientes)
                sql.Append("'Todos', ");
            else
                sql.Append("'" + this._codigoCliente + "', ");

            if (this._todosAutomotores)
                sql.Append("'Todas'");
            else
                sql.Append(this._codigoAutomotor);

            sql.Append(",'" + this._horaInicio + "', ");
            sql.Append("'" + this._horaFinal + "'");

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

        #region Formato del grupo cliente
        private void ghCliente_Format(object sender, System.EventArgs eArgs)
        {
            #region fechas
            this.lblTexto2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2209, Global.Idioma) + ": " +
                this._fechaInicio.ToString("dd/MM/yyyy") + " " + this._horaInicio.Substring(0, 8) + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) + " " +
                this._fechaFin.ToString("dd/MM/yyyy") + " " + this._horaFinal.Substring(0,8);
            #endregion            

            this.srptEncabezado.Report = new SubEncabezadoExtracto();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #endregion
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            lblSenores.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(859, Global.Idioma);
            lblIdentificacion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Global.Idioma);
            lblTexto.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2210, Global.Idioma);
            
            txtReclamos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2208, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(864, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(863, Global.Idioma);
            #region Pie de pagina

            lblCopyRight.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.ExtractoClienteDetalleBajo.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghCliente = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghCliente"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfCliente = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfCliente"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.ghCliente.Controls[0]));
            this.lblSenores = ((DataDynamics.ActiveReports.Label)(this.ghCliente.Controls[1]));
            this.txtSenores = ((DataDynamics.ActiveReports.TextBox)(this.ghCliente.Controls[2]));
            this.lblIdentificacion = ((DataDynamics.ActiveReports.Label)(this.ghCliente.Controls[3]));
            this.txtIdentificacion = ((DataDynamics.ActiveReports.TextBox)(this.ghCliente.Controls[4]));
            this.lblTexto = ((DataDynamics.ActiveReports.Label)(this.ghCliente.Controls[5]));
            this.lblTexto2 = ((DataDynamics.ActiveReports.Label)(this.ghCliente.Controls[6]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.ghCliente.Controls[7]));
            this.txtReclamos = ((DataDynamics.ActiveReports.Label)(this.gfCliente.Controls[0]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.gfCliente.Controls[1]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.gfCliente.Controls[2]));
            this.Line2 = ((DataDynamics.ActiveReports.Line)(this.gfCliente.Controls[3]));
            this.Line3 = ((DataDynamics.ActiveReports.Line)(this.gfCliente.Controls[4]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.lblCopyRight = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
            this.lblPagina = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[2]));
            this.lblDe = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[3]));
            this.lblAno = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[4]));
            this.txtNumeroPagina = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[5]));
            this.txtNumeroPaginas = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[6]));
            // Attach Report Events
            this.ghCliente.Format += new System.EventHandler(this.ghCliente_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
        }

    }
}
