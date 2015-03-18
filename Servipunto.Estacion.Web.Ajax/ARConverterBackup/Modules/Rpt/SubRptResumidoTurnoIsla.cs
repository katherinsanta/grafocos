using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumidoTurnoIsla.
    /// </summary>
    public partial class SubRptResumidoTurnoIsla : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _turno;
        int _isla;
        bool _todosTurnos;
        #endregion

        #region Costructor de la clase
        public SubRptResumidoTurnoIsla(DateTime fechaInicio, int turno, bool todosTurnos, int isla)
        {
            _fechaInicio = _fechaFin = fechaInicio;
            _turno = turno;
            _isla = isla;
            _todosTurnos = todosTurnos;
            InitializeReport();
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2236, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label1.Text = "No. "+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(483, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1729, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            
        }
        #endregion
        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("Exec ");
            sql.Append("SP_RptEmployee ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
            sql.Append("'" + this._fechaFin.ToString("yyyyMMdd") + "', 0, ");
            sql.Append("'Todos', ");
            if (this._todosTurnos)
                sql.Append("0, ");
            else
                sql.Append(this._turno + ", ");
            sql.Append(this._isla + ", ");
            sql.Append("0");
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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptResumidoTurnoIsla.rpx");
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfTotal = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfTotal"]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.ghTotal.Controls[0]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ghTotal.Controls[1]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[2]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[3]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[4]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[5]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[6]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[7]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[8]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[9]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[10]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[11]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
            this.txtGranTotalCantidad = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[0]));
            this.txtGranTotalUndades = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[1]));
            this.txtGranTotalIva = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[2]));
            this.txtgranTotalTotal = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[3]));
            this.txtTotalVentaRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[4]));
            this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[5]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[6]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.gfTotal.Controls[7]));
        }

    }
}
