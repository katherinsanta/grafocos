using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasConsecutivo.
    /// </summary>
    public partial class VentasConsecutivo : DataDynamics.ActiveReports.ActiveReport3
    {


        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _consecutivo;
        int _surtidor;
        int _turno;
        bool _todossurtidor;
        bool _todosturno;
        bool _todas;
        #endregion

        #region Costructor de la clase
        public VentasConsecutivo(DateTime fechaInicio, DateTime fechaFin, int consecutivo, bool todas, int surtidores, bool todossurtidores, int turnos, bool todosturnos)
        {
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _consecutivo = consecutivo;
            _todas = todas;
            _surtidor = surtidores;
            _turno = turnos;
            _todossurtidor = todossurtidores;
            _todosturno = todosturnos;

            //////////////////////////////////////////////
            ////Reporte dinamico

            System.Data.SqlClient.SqlDataAdapter query =
            new System.Data.SqlClient.SqlDataAdapter("Select Ventas_Pre From Dat_Gene",
            new System.Data.SqlClient.SqlConnection(
            Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString));

            System.Data.DataTable tabla = new System.Data.DataTable();
            query.Fill(tabla);

            InitializeComponent();

            if (tabla.Rows[0][0].ToString() != "A")
            {
                lblPreset.Visible = txPreset1.Visible = txPreset2.Visible =
                    txPreset3.Visible = lblCanje.Visible = txtCanje1.Visible =
                    txtCanje2.Visible = txtCanje3.Visible = false;


            }

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
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2264, Global.Idioma);
            lblConsecutivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);            
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma);
            lblSubTotal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1725, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblCanje.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2265, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);            
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

            sql.Append("exec");
            sql.Append(" RptVentasConsecutivo");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            if (_todas)
                sql.Append("null, ");
            else
                sql.Append(_consecutivo.ToString() + ", ");
            if (_todossurtidor)
                sql.Append("null, ");
            else
                sql.Append(_surtidor.ToString() + ", ");
            if (_todosturno)
                sql.Append("null ");
            else
                sql.Append(_turno.ToString());
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
            /*			System.Text.StringBuilder sql = new System.Text.StringBuilder();
			
                        if(_todas)
                        {
                            sql.Append("exec RptResumenFPago ");
                            sql.Append(this._fechaInicio.ToString("yyyyMMdd") + ", ");
                            sql.Append(this._fechaFin.ToString("yyyyMMdd") + ", S,");
                            if(!this._todas)
                                sql.Append(_surtidor + ",");
                            else
                                sql.Append("null, ");
                            if(!this._todas)
                                sql.Append(_turno + "");
                            else
                                sql.Append("null ");

                        }
                        else
                        {
                            lblCodigo.Visible = lblTituloFormasPago.Visible = lblFormaPago.Visible =
                            lblNumeroVentas.Visible = Label4.Visible = lblTotalFormasPago.Visible =	
                            Line3.Visible = srptFormasPago.Visible = false;

                            sql.Append("exec RptResumenFPago ");
                            sql.Append(this._fechaInicio.ToString("yyyyMMdd") + ", ");
                            sql.Append(this._fechaFin.ToString("yyyyMMdd") + ", P,");
                            if(!this._todas)
                                sql.Append(_consecutivo + ",");
                            else
                                sql.Append("null, ");
                            sql.Append("null");
                        }

                        return sql.ToString();
                        */
            //pendientex
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec RptResumenFPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            if (!this._todas)
            {
                sql.Append(",@Cod_sur = '" + _surtidor + "'");
                sql.Append(",@Num_tur = '" + _turno + "'");
            }
            return sql.ToString();
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.VentasConsecutivo.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghFecha = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghFecha"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfFecha = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfFecha"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.lblHora = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.lblConsecutivo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[2]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[3]));
            this.lblFecha = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
            this.srptEncabezado = ((DataDynamics.ActiveReports.SubReport)(this.PageHeader.Controls[5]));
            this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
            this.lblTituloFechas = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
            this.lblPreset = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
            this.lblCanje = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.ghFecha.Controls[0]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.ghFecha.Controls[1]));
            this.txPreset1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtConsecutivo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.txtCanje1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.txPreset2 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[0]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.gfFecha.Controls[1]));
            this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[2]));
            this.TextBox10 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[3]));
            this.txtCanje2 = ((DataDynamics.ActiveReports.TextBox)(this.gfFecha.Controls[4]));
            this.txPreset3 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[1]));
            this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.TextBox11 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.txtCanje3 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[4]));
            this.srptFormasPago = ((DataDynamics.ActiveReports.SubReport)(this.gfTotal.Controls[5]));
            this.lblModulo = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
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
