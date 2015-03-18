using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptCreditoDirecto.
    /// </summary>
    public partial class SubRptCreditoDirecto : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _isla;
        string _turno;
        bool _todos;
        #endregion

        #region Constructor de la Clase
        public SubRptCreditoDirecto(DateTime fechaInicio, int isla, string turno, bool todos)
        {
            _fechaInicio = _fechaFin = fechaInicio;
            _isla = isla;
            _turno = turno;
            if (todos)
                _turno = "0";
            _todos = todos;
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2234, Global.Idioma);
            lblConsecutivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(531, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(154, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);

        }
        #endregion
        #region QueryPrincipal
        private string QueryPrincipal()
        {
            //pendientex
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("SP_RptFormasPago ");
            sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
            sql.Append("'" + this._fechaFin.ToString("yyyyMMdd") + "', 1,6, ");
            sql.Append("'Todos',0, ");
            sql.Append(this._isla + ", " + this._turno);
            return sql.ToString();
            */

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("SP_RptFormasPago ");
            sql.Append("@FechaInicial = " + this._fechaInicio.ToString("yyyyMMdd"));
            sql.Append(",@FechaFinal = " + this._fechaFin.ToString("yyyyMMdd"));
            sql.Append(",@Cod_Isl = '" + this._isla.ToString() + "'");
            sql.Append(",@Num_tur = '" + this._turno.ToString() + "'");
            sql.Append(",@Opcion = '" + "3'");

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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptCreditoDirecto.rpx");
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.lblConsecutivo = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[1]));
            this.lblArticulo = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[3]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[4]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[5]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[6]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[7]));
            this.Label4 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[8]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[9]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[10]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtConsecutivo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtArticulo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
        }

        private void GroupHeader1_Format(object sender, EventArgs e)
        {

        }

    }
}
