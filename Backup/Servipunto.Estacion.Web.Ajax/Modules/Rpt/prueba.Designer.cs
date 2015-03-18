namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for prueba.
    /// </summary>
    partial class prueba
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(prueba));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // pageHeader
            //
            this.pageHeader.Height = 0.25F;
            this.pageHeader.Name = "pageHeader";
            //
            // detail
            //
            this.detail.Height = 2.0F;
            this.detail.Name = "detail";
            //
            // pageFooter
            //
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            //
            // prueba
            //
            this.MasterReport = false;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
        #endregion
    }
}
