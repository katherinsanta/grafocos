using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubEncabezado.
    /// </summary>
    public partial class SubEncabezado : DataDynamics.ActiveReports.ActiveReport
    {

        public SubEncabezado()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            
        }
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubEncabezado.rpx");
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
            this.txtNit = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
            this.txtDive = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
            this.lblNit = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[3]));
            
        }

    }
}
