using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptDiferenciaLecturas.
    /// </summary>
    public partial class SubRptDiferenciaLecturas : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _manguera;
        string _turno;
        int _isla;
        #endregion

        #region Costructor de la clase
        public SubRptDiferenciaLecturas(DateTime fechaInicio, int isla, string turno, bool todos, int Idioma)
        {
            _fechaInicio = _fechaFin = fechaInicio;
            _turno = turno;
            _isla = isla;
            _manguera = 0;
            _turno = turno;
            if (todos)
                _turno = "0";
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                TraducirSubReporte();
        }
        #endregion

        #region QueryPrincipal
        private string QueryPrincipal()
        {
            /*System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" Exec");
            sql.Append(" SP_RptDifLects ");
            sql.Append(" '" + this._fechaInicio.ToString("yyyyMMdd") + "',");
            sql.Append(" '" + this._fechaFin.ToString("yyyyMMdd") + "',");
            sql.Append(this._manguera + ",");
            sql.Append(this._isla + ",");
            sql.Append(this._turno);
            return sql.ToString();
            */

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" exec SP_RptDifLects ");
            sql.Append("@FechaInicial = '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(",@FechaFinal = '" + this._fechaFin.ToString("yyyyMMdd") + "'");
            //sql.Append(",@cod_man = '" + _manguera.ToString() + "'");
            sql.Append(",@cod_isl = '" + _isla.ToString() + "'");
            sql.Append(",@num_tur = '" + _turno + "'");
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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptDiferenciaLecturas.rpx");
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.lblManguera = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[1]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[2]));
            this.lbllecturaFinal = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[4]));
            this.lblLecturaInicial = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[5]));
            this.lblLecturaSurtidor = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[6]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[7]));
            this.txtManguera = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtLecturaInicial = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtLecturaFinal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtLecturaSurtidor = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
        }

        private void GroupHeader1_Format(object sender, EventArgs e)
        {

        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirSubReporte()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23704, Global.Idioma);
            lblManguera.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23345, Global.Idioma);
            lblLecturaInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(841, Global.Idioma);
            lbllecturaFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(842, Global.Idioma);
            lblLecturaSurtidor.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(236, Global.Idioma);
            
        }
        #endregion
    }
}
