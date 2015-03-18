using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubEncabezadoExtracto.
    /// </summary>
    public partial class SubEncabezadoExtracto : DataDynamics.ActiveReports.ActiveReport
    {

        public SubEncabezadoExtracto()
        {
            InitializeComponent();
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            this.txtFecha.Text = System.DateTime.Now.ToString("d - MMMM - yyyy");
            lblTelefono.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(856, Global.Idioma);
        }
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubEncabezadoExtracto.rpx");
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.txtNIT = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtNombreEstacion = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.Direccion = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.txtTelefono = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
            this.lblTelefono = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[4]));
            this.txtCiudad = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
            this.txtFecha = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
            // Attach Report Events
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
        }
    }
}
