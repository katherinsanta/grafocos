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
    /// Summary description for SubRptTurnoInformacion.
    /// </summary>
    public partial class SubRptTurnoInformacion : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        string _turno;
        int _isla;
        #endregion

        public SubRptTurnoInformacion(DateTime fechaInicio, string turno, int isla, int Idioma)
        {
            _fechaInicio = fechaInicio;
            _turno = turno;
            _isla = isla;
            this.PageSettings.PaperName = "";
            InitializeComponent();
            if (Idioma == 1)
                TraducirSubReporte();
            FormatoInformacionTurnos();
        }
        #region Consulta Principal
        private void FormatoInformacionTurnos()
        {
            DataSet ds = Servipunto.Estacion.Libreria.Turnos.TurnosLaborales.ReporteTurnos(_fechaInicio, _turno, _isla);
            //DataSet ds = Servipunto.Estacion.Libreria.Pagos.ObtenerItems(1);
            this.DataSource = ds.Tables[0];
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubRptTurnoInformacion.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
            this.Label5 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[0]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[3]));
            this.txtIsla = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[5]));
            this.txtTurno = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[7]));
            this.Label3 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[8]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirSubReporte()
        {
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1074, Global.Idioma)+":";
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma)+":";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(940, Global.Idioma)+":";
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(827, Global.Idioma)+":";
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(828, Global.Idioma)+":";
        }
        #endregion
    }
}
