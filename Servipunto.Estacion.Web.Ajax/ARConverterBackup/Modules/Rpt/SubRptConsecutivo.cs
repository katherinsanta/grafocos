using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptConsecutivo.
    /// </summary>
    public partial class SubRptConsecutivo : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _isla;
        string _turno;
        #endregion

        #region Costructor de la clase
        public SubRptConsecutivo(DateTime fechaInicio, int isla, string turno)
        {
            _fechaInicio = _fechaFin = fechaInicio;
            _isla = isla;
            _turno = turno;
            InitializeComponent();
            InitializeDatabase();
            Traducir();
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(385, Global.Idioma);
            lblConsecutivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(385, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);

        }
        #endregion
        #region QueryPrincipal
        private string QueryPrincipal()
        {
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append(" Select");
            sql.Append(" Dbo.Finteger(V.Fecha) Fecha,");
            sql.Append(" LTrim(RTrim(V.Prefijo)) + Cast(V.Consecutivo As Varchar) Consecutivo,");
            sql.Append(" IsNull(V.Cantidad, 0) Unidades,");
            sql.Append(" IsNull(V.ValorNeto, 0) ValorNeto,");
            sql.Append(" IsNull(V.Descuento, 0) Descuento,");
            sql.Append(" IsNull(V.SubTotal, 0) SubTotal,");
            sql.Append(" IsNull(V.Vr_Iva, 0) Iva,");
            sql.Append(" IsNull(V.Total_Cuota, 0) Recaudo,");
            sql.Append(" IsNull(V.Total, 0) Total");
            sql.Append(" From Ventas V");
            sql.Append(" Where (Dbo.Finteger(V.Fecha) Between '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(" And '" + this._fechaFin.ToString("yyyyMMdd") + "')");
            sql.Append(" And Cod_Isl = " + this._isla);
            sql.Append(" And Num_Tur = " + this._turno);
            sql.Append(" Order By V.Consecutivo");

            return sql.ToString();
            */
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec rptVentasPorTurno ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            sql.Append(",@Opcion = " + "4");
            sql.Append(",@turno = " + this._turno);
            sql.Append(",@isla = " + this._isla);

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

        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptConsecutivo.rpx");
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.lblConsecutivo = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[0]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.ghTotal.Controls[1]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ghTotal.Controls[2]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[3]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[4]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[5]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[6]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[7]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[8]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[9]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtConsecutivo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.lblTotalVenta = ((DataDynamics.ActiveReports.Label)(this.gfTotal.Controls[4]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[5]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
        }

    }
}
