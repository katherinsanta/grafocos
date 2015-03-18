namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubArticulosDinamico.
    /// </summary>
    partial class SubArticulosDinamico
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubArticulosDinamico));
            this.ghArticulos = new DataDynamics.ActiveReports.Detail();
            this.txtNombre = new DataDynamics.ActiveReports.TextBox();
            this.txtCodigo = new DataDynamics.ActiveReports.TextBox();
            this.txtCantidad = new DataDynamics.ActiveReports.TextBox();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.gfArticulos = new DataDynamics.ActiveReports.PageFooter();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ghArticulos
            // 
            this.ghArticulos.ColumnSpacing = 0F;
            this.ghArticulos.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtNombre,
            this.txtCodigo,
            this.txtCantidad,
            this.txtTotal});
            this.ghArticulos.Height = 0.2076389F;
            this.ghArticulos.Name = "ghArticulos";
            // 
            // txtNombre
            // 
            this.txtNombre.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombre.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombre.Border.RightColor = System.Drawing.Color.Black;
            this.txtNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombre.Border.TopColor = System.Drawing.Color.Black;
            this.txtNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNombre.DataField = "DescripcionArticulo";
            this.txtNombre.Height = 0.2F;
            this.txtNombre.Left = 0.5625F;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.OutputFormat = resources.GetString("txtNombre.OutputFormat");
            this.txtNombre.Style = "";
            this.txtNombre.Text = "NombreArticulo";
            this.txtNombre.Top = 0.008587598F;
            this.txtNombre.Width = 3.0625F;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodigo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodigo.Border.RightColor = System.Drawing.Color.Black;
            this.txtCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodigo.Border.TopColor = System.Drawing.Color.Black;
            this.txtCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodigo.DataField = "CodigoArticulo";
            this.txtCodigo.Height = 0.2F;
            this.txtCodigo.Left = 0F;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Style = "text-align: right; ";
            this.txtCodigo.Text = "CodigoArticulo";
            this.txtCodigo.Top = 0.008587598F;
            this.txtCodigo.Width = 0.5625F;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.Border.RightColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.Border.TopColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.DataField = "cantidadArticulo";
            this.txtCantidad.Height = 0.2F;
            this.txtCantidad.Left = 3.625F;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat");
            this.txtCantidad.Style = "text-align: right; ";
            this.txtCantidad.Text = "CantidadArticulo";
            this.txtCantidad.Top = 0F;
            this.txtCantidad.Width = 1.062008F;
            // 
            // txtTotal
            // 
            this.txtTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.DataField = "TotalArticulo";
            this.txtTotal.Height = 0.2F;
            this.txtTotal.Left = 4.687008F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat");
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = "TotalArticulo";
            this.txtTotal.Top = 0F;
            this.txtTotal.Width = 1.687992F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label6,
            this.Line});
            this.PageHeader.Height = 0.2076389F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.125F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label6.Text = "Resumen";
            this.Label6.Top = 0F;
            this.Label6.Width = 1F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.1875F;
            this.Line.Width = 6.5625F;
            this.Line.X1 = 0F;
            this.Line.X2 = 6.5625F;
            this.Line.Y1 = 0.1875F;
            this.Line.Y2 = 0.1875F;
            // 
            // gfArticulos
            // 
            this.gfArticulos.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line1,
            this.Line2});
            this.gfArticulos.Height = 0.1451389F;
            this.gfArticulos.Name = "gfArticulos";
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0F;
            this.Line1.Width = 6.5625F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 6.5625F;
            this.Line1.Y1 = 0F;
            this.Line1.Y2 = 0F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.046875F;
            this.Line2.Width = 6.546875F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 6.546875F;
            this.Line2.Y1 = 0.046875F;
            this.Line2.Y2 = 0.046875F;
            // 
            // SubArticulosDinamico
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ghArticulos);
            this.Sections.Add(this.gfArticulos);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Detail ghArticulos;
        private DataDynamics.ActiveReports.TextBox txtNombre;
        private DataDynamics.ActiveReports.TextBox txtCodigo;
        private DataDynamics.ActiveReports.TextBox txtCantidad;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label Label6;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.PageFooter gfArticulos;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Line Line2;
    }
}
