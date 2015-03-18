using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptArticulo.
    /// </summary>
    public partial class SubRptArticulo : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _isla;
        string _turno;
        #endregion

        #region Constructor de la Clase
        public SubRptArticulo(DateTime fechaInicio, int isla, string turno, bool todos)
        {
            _fechaInicio = _fechaFin = fechaInicio;
            _turno = turno;
            if (todos)
                _turno = "0";
            _isla = isla;
            InitializeComponent();
            InitializeDatabase();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("exec");
            sql.Append(" RptVentsArticulo");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(" 0, 1,0," + this._isla + ", " + this._turno);
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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptArticulo.rpx");
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.lblConsecutivo = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
            this.lblUnidades = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[1]));
            this.lblTotal = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[3]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[4]));
            this.lblSubTotal = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[5]));
            this.lblIva = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[6]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[7]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[8]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[9]));
            this.txtCantidad = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtSubTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtIva = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.txtArticulo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
        }

    }
}
