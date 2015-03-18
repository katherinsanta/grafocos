using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptIslaResumido.
    /// </summary>
    public partial class SubRptIslaResumido : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        int _numeroIsla;
        string _turno;
        #endregion

        #region Constructor de la Clase
        public SubRptIslaResumido(DateTime fechaInicio, int numeroIsla, string turno, bool todos)
        {
            _fechaInicio = fechaInicio;
            _numeroIsla = numeroIsla;
            _turno = turno;
            if (todos)
                turno = "0";
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
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2235, Global.Idioma);
            lblIsla.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            Label1.Text ="No. "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(483, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);

        }
        #endregion
        #region InitializeDatabase
        private void InitializeDatabase()
        {
            //Servipunto.Estacion.Libreria.Aplicacion.Refresh();

            this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("exec");
            sql.Append(" SP_RptIslaSurCaraMang");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" 0, 'I', " + this._numeroIsla + ", " + this._turno);
            return sql.ToString();
        }
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptIslaResumido.rpx");
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.lblIsla = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[1]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
            this.lblRecaudo = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[3]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[4]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[5]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[6]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[7]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[8]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[9]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[10]));
            this.txtIsla = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtUnidades = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtRecaudo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
        }

        #endregion

    }
}
