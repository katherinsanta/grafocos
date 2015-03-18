using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubFormasPagoCanastilla.
    /// </summary>
    public partial class SubFormasPagoCanastilla : DataDynamics.ActiveReports.ActiveReport
    {

        public SubFormasPagoCanastilla()
        {
            InitializeComponent();
            Traducir();
        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            lblTituloFormasPago.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2233, Global.Idioma);
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            lblFormaPago.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(148, Global.Idioma);
            lblNumeroVentas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(723, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);

        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubFormasPagoCanastilla.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghTotal = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghTotal"]));
            this.ghPagos = ((DataDynamics.ActiveReports.Detail)(this.Sections["ghPagos"]));
            this.gfPagos = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfPagos"]));
            this.gfTotal = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["gfTotal"]));
            this.lblFormaPago = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[0]));
            this.lblNumeroVentas = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[1]));
            this.lblTotalFormasPago = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[2]));
            this.lblTituloFormasPago = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[3]));
            this.Label2 = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[4]));
            this.Line3 = ((DataDynamics.ActiveReports.Line)(this.ghTotal.Controls[5]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.ghTotal.Controls[6]));
            this.txtFormaPago = ((DataDynamics.ActiveReports.TextBox)(this.ghPagos.Controls[0]));
            this.txtCantidad = ((DataDynamics.ActiveReports.TextBox)(this.ghPagos.Controls[1]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.ghPagos.Controls[2]));
            this.txtCodigo = ((DataDynamics.ActiveReports.TextBox)(this.ghPagos.Controls[3]));
            this.txtCantidadPagos = ((DataDynamics.ActiveReports.TextBox)(this.ghPagos.Controls[4]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.gfPagos.Controls[0]));
            this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.gfPagos.Controls[1]));
            this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.gfPagos.Controls[2]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.gfPagos.Controls[3]));
            this.Label1 = ((DataDynamics.ActiveReports.Label)(this.gfPagos.Controls[4]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.gfPagos.Controls[5]));
            this.Line2 = ((DataDynamics.ActiveReports.Line)(this.gfPagos.Controls[6]));
            this.Line4 = ((DataDynamics.ActiveReports.Line)(this.gfPagos.Controls[7]));
            this.Line5 = ((DataDynamics.ActiveReports.Line)(this.gfPagos.Controls[8]));
            this.Line6 = ((DataDynamics.ActiveReports.Line)(this.gfPagos.Controls[9]));
        }



    }
}
