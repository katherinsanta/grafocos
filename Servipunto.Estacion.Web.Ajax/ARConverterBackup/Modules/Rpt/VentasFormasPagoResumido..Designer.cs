namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasFormasPagoResumido.
    /// </summary>
    partial class VentasFormasPagoResumido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasFormasPagoResumido));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtFecha = new DataDynamics.ActiveReports.TextBox();
            this.txtCodArt = new DataDynamics.ActiveReports.TextBox();
            this.txtArticulo = new DataDynamics.ActiveReports.TextBox();
            this.txtUnidades = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.lblTituloFecha = new DataDynamics.ActiveReports.Label();
            this.lblPrecio = new DataDynamics.ActiveReports.Label();
            this.lblUnidades = new DataDynamics.ActiveReports.Label();
            this.lblTotal = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            this.lblArticulo = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            this.ghTotal = new DataDynamics.ActiveReports.GroupHeader();
            this.gfTotal = new DataDynamics.ActiveReports.GroupFooter();
            this.txtgranTotalTotal = new DataDynamics.ActiveReports.TextBox();
            this.lblTotalVenta = new DataDynamics.ActiveReports.Label();
            this.ghFormaPago = new DataDynamics.ActiveReports.GroupHeader();
            this.txtFPago = new DataDynamics.ActiveReports.TextBox();
            this.lblFPago = new DataDynamics.ActiveReports.Label();
            this.gfFormaPago = new DataDynamics.ActiveReports.GroupFooter();
            this.TotalPlacaTotal = new DataDynamics.ActiveReports.TextBox();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPlacaTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTotal,
            this.txtFecha,
            this.txtCodArt,
            this.txtArticulo,
            this.txtUnidades});
            this.Detail.Height = 0.2291667F;
            this.Detail.Name = "Detail";
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
            this.txtTotal.DataField = "Total";
            this.txtTotal.Height = 0.2F;
            this.txtTotal.Left = 6.988188F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat");
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = "Total";
            this.txtTotal.Top = 0.02460633F;
            this.txtTotal.Width = 1.058065F;
            // 
            // txtFecha
            // 
            this.txtFecha.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFecha.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFecha.Border.RightColor = System.Drawing.Color.Black;
            this.txtFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFecha.Border.TopColor = System.Drawing.Color.Black;
            this.txtFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFecha.DataField = "Fecha";
            this.txtFecha.Height = 0.2F;
            this.txtFecha.Left = 0.02460629F;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat");
            this.txtFecha.Style = "text-align: right; ";
            this.txtFecha.Text = "Fecha";
            this.txtFecha.Top = 0.02460632F;
            this.txtFecha.Width = 0.8858271F;
            // 
            // txtCodArt
            // 
            this.txtCodArt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCodArt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodArt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCodArt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodArt.Border.RightColor = System.Drawing.Color.Black;
            this.txtCodArt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodArt.Border.TopColor = System.Drawing.Color.Black;
            this.txtCodArt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCodArt.DataField = "Turno";
            this.txtCodArt.Height = 0.2F;
            this.txtCodArt.Left = 0.9350361F;
            this.txtCodArt.Name = "txtCodArt";
            this.txtCodArt.Style = "text-align: right; ";
            this.txtCodArt.Text = "Turno";
            this.txtCodArt.Top = 0.0246063F;
            this.txtCodArt.Width = 0.3690979F;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.Border.RightColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.Border.TopColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.DataField = "Cliente";
            this.txtArticulo.Height = 0.2F;
            this.txtArticulo.Left = 2.091532F;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Style = "";
            this.txtArticulo.Text = "Cliente";
            this.txtArticulo.Top = 0.0246063F;
            this.txtArticulo.Width = 4.283467F;
            // 
            // txtUnidades
            // 
            this.txtUnidades.Border.BottomColor = System.Drawing.Color.Black;
            this.txtUnidades.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUnidades.Border.LeftColor = System.Drawing.Color.Black;
            this.txtUnidades.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUnidades.Border.RightColor = System.Drawing.Color.Black;
            this.txtUnidades.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUnidades.Border.TopColor = System.Drawing.Color.Black;
            this.txtUnidades.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUnidades.DataField = "Codigo";
            this.txtUnidades.Height = 0.2F;
            this.txtUnidades.Left = 1.328739F;
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Style = "text-align: right; ";
            this.txtUnidades.Text = "Codigo";
            this.txtUnidades.Top = 0.02460632F;
            this.txtUnidades.Width = 0.7381909F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblHora,
            this.lblTituloFecha,
            this.lblPrecio,
            this.lblUnidades,
            this.lblTotal,
            this.Line,
            this.Line1,
            this.lblFecha,
            this.srptEncabezado,
            this.Label15,
            this.lblTituloFechas,
            this.lblArticulo});
            this.PageHeader.Height = 1.552083F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // lblHora
            // 
            this.lblHora.Border.BottomColor = System.Drawing.Color.Black;
            this.lblHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Border.LeftColor = System.Drawing.Color.Black;
            this.lblHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Border.RightColor = System.Drawing.Color.Black;
            this.lblHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Border.TopColor = System.Drawing.Color.Black;
            this.lblHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Height = 0.2F;
            this.lblHora.HyperLink = null;
            this.lblHora.Left = 6.692915F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora:";
            this.lblHora.Top = 0.8038382F;
            this.lblHora.Width = 1.181105F;
            // 
            // lblTituloFecha
            // 
            this.lblTituloFecha.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTituloFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFecha.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTituloFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFecha.Border.RightColor = System.Drawing.Color.Black;
            this.lblTituloFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFecha.Border.TopColor = System.Drawing.Color.Black;
            this.lblTituloFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFecha.Height = 0.2F;
            this.lblTituloFecha.HyperLink = null;
            this.lblTituloFecha.Left = 0F;
            this.lblTituloFecha.Name = "lblTituloFecha";
            this.lblTituloFecha.Style = "text-align: right; ";
            this.lblTituloFecha.Text = "Fecha";
            this.lblTituloFecha.Top = 1.3125F;
            this.lblTituloFecha.Width = 0.8612201F;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPrecio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrecio.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPrecio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrecio.Border.RightColor = System.Drawing.Color.Black;
            this.lblPrecio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrecio.Border.TopColor = System.Drawing.Color.Black;
            this.lblPrecio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrecio.Height = 0.2F;
            this.lblPrecio.HyperLink = null;
            this.lblPrecio.Left = 0.9104313F;
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Style = "text-align: right; ";
            this.lblPrecio.Text = "Turno";
            this.lblPrecio.Top = 1.304134F;
            this.lblPrecio.Width = 0.3937027F;
            // 
            // lblUnidades
            // 
            this.lblUnidades.Border.BottomColor = System.Drawing.Color.Black;
            this.lblUnidades.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblUnidades.Border.LeftColor = System.Drawing.Color.Black;
            this.lblUnidades.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblUnidades.Border.RightColor = System.Drawing.Color.Black;
            this.lblUnidades.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblUnidades.Border.TopColor = System.Drawing.Color.Black;
            this.lblUnidades.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblUnidades.Height = 0.2F;
            this.lblUnidades.HyperLink = null;
            this.lblUnidades.Left = 1.328739F;
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Style = "text-align: right; ";
            this.lblUnidades.Text = "Codigo";
            this.lblUnidades.Top = 1.304134F;
            this.lblUnidades.Width = 0.7381909F;
            // 
            // lblTotal
            // 
            this.lblTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Border.RightColor = System.Drawing.Color.Black;
            this.lblTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Border.TopColor = System.Drawing.Color.Black;
            this.lblTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Height = 0.2F;
            this.lblTotal.HyperLink = null;
            this.lblTotal.Left = 6.963583F;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Style = "text-align: right; ";
            this.lblTotal.Text = "Total";
            this.lblTotal.Top = 1.304134F;
            this.lblTotal.Width = 1.033465F;
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
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 1.279528F;
            this.Line.Width = 8.021652F;
            this.Line.X1 = 0F;
            this.Line.X2 = 8.021652F;
            this.Line.Y1 = 1.279528F;
            this.Line.Y2 = 1.279528F;
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
            this.Line1.LineWeight = 2F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.52559F;
            this.Line1.Width = 8.021652F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 8.021652F;
            this.Line1.Y1 = 1.52559F;
            this.Line1.Y2 = 1.52559F;
            // 
            // lblFecha
            // 
            this.lblFecha.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Border.RightColor = System.Drawing.Color.Black;
            this.lblFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Border.TopColor = System.Drawing.Color.Black;
            this.lblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Height = 0.2F;
            this.lblFecha.HyperLink = null;
            this.lblFecha.Left = 6.692915F;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Style = "white-space: inherit; ";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Top = 0.5905511F;
            this.lblFecha.Width = 1.230315F;
            // 
            // srptEncabezado
            // 
            this.srptEncabezado.Border.BottomColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.Border.LeftColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.Border.RightColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.Border.TopColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.CloseBorder = false;
            this.srptEncabezado.Height = 0.5905511F;
            this.srptEncabezado.Left = 1.082676F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0F;
            this.srptEncabezado.Width = 5.536417F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 1.254922F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label15.Text = "Reporte de Ventas por Formas de Pago Resumido";
            this.Label15.Top = 0.7627952F;
            this.Label15.Width = 5.093504F;
            // 
            // lblTituloFechas
            // 
            this.lblTituloFechas.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Border.RightColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Border.TopColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Height = 0.2F;
            this.lblTituloFechas.HyperLink = null;
            this.lblTituloFechas.Left = 1.082676F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTituloFechas.Text = "Titulo con las fechas";
            this.lblTituloFechas.Top = 1.008858F;
            this.lblTituloFechas.Width = 5.536417F;
            // 
            // lblArticulo
            // 
            this.lblArticulo.Border.BottomColor = System.Drawing.Color.Black;
            this.lblArticulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblArticulo.Border.LeftColor = System.Drawing.Color.Black;
            this.lblArticulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblArticulo.Border.RightColor = System.Drawing.Color.Black;
            this.lblArticulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblArticulo.Border.TopColor = System.Drawing.Color.Black;
            this.lblArticulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblArticulo.Height = 0.2F;
            this.lblArticulo.HyperLink = null;
            this.lblArticulo.Left = 2.091532F;
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Style = "";
            this.lblArticulo.Text = "Cliente";
            this.lblArticulo.Top = 1.304134F;
            this.lblArticulo.Width = 1.230317F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblModulo,
            this.Label,
            this.lblPagina,
            this.lblDe,
            this.lblAno,
            this.txtNumeroPagina,
            this.txtNumeroPaginas});
            this.PageFooter.Height = 0.40625F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // lblModulo
            // 
            this.lblModulo.Border.BottomColor = System.Drawing.Color.Black;
            this.lblModulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Border.LeftColor = System.Drawing.Color.Black;
            this.lblModulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Border.RightColor = System.Drawing.Color.Black;
            this.lblModulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Border.TopColor = System.Drawing.Color.Black;
            this.lblModulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Height = 0.2F;
            this.lblModulo.HyperLink = null;
            this.lblModulo.Left = 0F;
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Style = "font-weight: bold; ";
            this.lblModulo.Text = "Servipunto Módulo de Estación";
            this.lblModulo.Top = 0F;
            this.lblModulo.Width = 2.125F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 8pt; ";
            this.Label.Text = "© Copyright           Zencillo de Software Ltda. Todos los Derechos Reservados." +
                "";
            this.Label.Top = 0.1875F;
            this.Label.Width = 4.306102F;
            // 
            // lblPagina
            // 
            this.lblPagina.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPagina.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPagina.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Border.RightColor = System.Drawing.Color.Black;
            this.lblPagina.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Border.TopColor = System.Drawing.Color.Black;
            this.lblPagina.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Height = 0.2F;
            this.lblPagina.HyperLink = null;
            this.lblPagina.Left = 6.375F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt; ";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.1914371F;
            this.lblPagina.Width = 0.375F;
            // 
            // lblDe
            // 
            this.lblDe.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDe.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDe.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Border.RightColor = System.Drawing.Color.Black;
            this.lblDe.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Border.TopColor = System.Drawing.Color.Black;
            this.lblDe.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Height = 0.2F;
            this.lblDe.HyperLink = null;
            this.lblDe.Left = 7.308563F;
            this.lblDe.Name = "lblDe";
            this.lblDe.Style = "font-size: 8pt; ";
            this.lblDe.Text = "de";
            this.lblDe.Top = 0.1914371F;
            this.lblDe.Width = 0.1668492F;
            // 
            // lblAno
            // 
            this.lblAno.Border.BottomColor = System.Drawing.Color.Black;
            this.lblAno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Border.LeftColor = System.Drawing.Color.Black;
            this.lblAno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Border.RightColor = System.Drawing.Color.Black;
            this.lblAno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Border.TopColor = System.Drawing.Color.Black;
            this.lblAno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Height = 0.2F;
            this.lblAno.HyperLink = null;
            this.lblAno.Left = 0.6250004F;
            this.lblAno.Name = "lblAno";
            this.lblAno.Style = "font-size: 8pt; ";
            this.lblAno.Text = "Año";
            this.lblAno.Top = 0.1875F;
            this.lblAno.Width = 0.375F;
            // 
            // txtNumeroPagina
            // 
            this.txtNumeroPagina.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Height = 0.2F;
            this.txtNumeroPagina.Left = 6.750501F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.1875F;
            this.txtNumeroPagina.Width = 0.5526695F;
            // 
            // txtNumeroPaginas
            // 
            this.txtNumeroPaginas.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Height = 0.2F;
            this.txtNumeroPaginas.Left = 7.488688F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.1875F;
            this.txtNumeroPaginas.Width = 0.5167322F;
            // 
            // ghTotal
            // 
            this.ghTotal.Height = 0.01041667F;
            this.ghTotal.Name = "ghTotal";
            // 
            // gfTotal
            // 
            this.gfTotal.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtgranTotalTotal,
            this.lblTotalVenta});
            this.gfTotal.Height = 0.2388889F;
            this.gfTotal.Name = "gfTotal";
            // 
            // txtgranTotalTotal
            // 
            this.txtgranTotalTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtgranTotalTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtgranTotalTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtgranTotalTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtgranTotalTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtgranTotalTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtgranTotalTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtgranTotalTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.txtgranTotalTotal.DataField = "Total";
            this.txtgranTotalTotal.Height = 0.2F;
            this.txtgranTotalTotal.Left = 6.988188F;
            this.txtgranTotalTotal.Name = "txtgranTotalTotal";
            this.txtgranTotalTotal.OutputFormat = resources.GetString("txtgranTotalTotal.OutputFormat");
            this.txtgranTotalTotal.Style = "text-align: right; ";
            this.txtgranTotalTotal.SummaryGroup = "ghTotal";
            this.txtgranTotalTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtgranTotalTotal.Text = "Total";
            this.txtgranTotalTotal.Top = 0.0246063F;
            this.txtgranTotalTotal.Width = 1.033464F;
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTotalVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVenta.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTotalVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVenta.Border.RightColor = System.Drawing.Color.Black;
            this.lblTotalVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVenta.Border.TopColor = System.Drawing.Color.Black;
            this.lblTotalVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVenta.Height = 0.2F;
            this.lblTotalVenta.HyperLink = null;
            this.lblTotalVenta.Left = 0.0246063F;
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Style = "font-weight: bold; font-size: 12pt; ";
            this.lblTotalVenta.Text = "Total Venta:";
            this.lblTotalVenta.Top = 0.0246063F;
            this.lblTotalVenta.Width = 1F;
            // 
            // ghFormaPago
            // 
            this.ghFormaPago.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtFPago,
            this.lblFPago});
            this.ghFormaPago.DataField = "Forma_De_Pago";
            this.ghFormaPago.Height = 0.25F;
            this.ghFormaPago.Name = "ghFormaPago";
            // 
            // txtFPago
            // 
            this.txtFPago.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFPago.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFPago.Border.RightColor = System.Drawing.Color.Black;
            this.txtFPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFPago.Border.TopColor = System.Drawing.Color.Black;
            this.txtFPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFPago.DataField = "Forma_De_Pago";
            this.txtFPago.Height = 0.2F;
            this.txtFPago.Left = 1.181103F;
            this.txtFPago.Name = "txtFPago";
            this.txtFPago.Style = "font-weight: bold; font-style: normal; font-size: 9.75pt; ";
            this.txtFPago.Text = "##";
            this.txtFPago.Top = 0.0246063F;
            this.txtFPago.Width = 5.193896F;
            // 
            // lblFPago
            // 
            this.lblFPago.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFPago.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFPago.Border.RightColor = System.Drawing.Color.Black;
            this.lblFPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFPago.Border.TopColor = System.Drawing.Color.Black;
            this.lblFPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFPago.Height = 0.2F;
            this.lblFPago.HyperLink = null;
            this.lblFPago.Left = 0.0246063F;
            this.lblFPago.Name = "lblFPago";
            this.lblFPago.Style = "font-weight: bold; font-style: normal; font-size: 9.75pt; ";
            this.lblFPago.Text = "Forma de Pago:";
            this.lblFPago.Top = 0.0246063F;
            this.lblFPago.Width = 1.13189F;
            // 
            // gfFormaPago
            // 
            this.gfFormaPago.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TotalPlacaTotal,
            this.TextBox,
            this.Label1});
            this.gfFormaPago.Height = 0.3125F;
            this.gfFormaPago.Name = "gfFormaPago";
            // 
            // TotalPlacaTotal
            // 
            this.TotalPlacaTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalPlacaTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPlacaTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalPlacaTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPlacaTotal.Border.RightColor = System.Drawing.Color.Black;
            this.TotalPlacaTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPlacaTotal.Border.TopColor = System.Drawing.Color.Black;
            this.TotalPlacaTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.TotalPlacaTotal.DataField = "Total";
            this.TotalPlacaTotal.Height = 0.2F;
            this.TotalPlacaTotal.Left = 6.988188F;
            this.TotalPlacaTotal.Name = "TotalPlacaTotal";
            this.TotalPlacaTotal.OutputFormat = resources.GetString("TotalPlacaTotal.OutputFormat");
            this.TotalPlacaTotal.Style = "text-align: right; ";
            this.TotalPlacaTotal.SummaryGroup = "ghFormaPago";
            this.TotalPlacaTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalPlacaTotal.Text = "Total";
            this.TotalPlacaTotal.Top = 0.02460633F;
            this.TotalPlacaTotal.Width = 1.033459F;
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.DataField = "Forma_De_Pago";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.525592F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-weight: bold; ";
            this.TextBox.Text = "##";
            this.TextBox.Top = 0.0246063F;
            this.TextBox.Width = 4.849408F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-weight: bold; ";
            this.Label1.Text = "Total Forma de Pago:";
            this.Label1.Top = 0.0246063F;
            this.Label1.Width = 1.476378F;
            // 
            // VentasFormasPagoResumido
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.39375F;
            this.PageSettings.Margins.Left = 0.5118055F;
            this.PageSettings.Margins.Right = 0.5118055F;
            this.PageSettings.Margins.Top = 0.39375F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.041667F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ghTotal);
            this.Sections.Add(this.ghFormaPago);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.gfFormaPago);
            this.Sections.Add(this.gfTotal);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPlacaTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.TextBox txtFecha;
        private DataDynamics.ActiveReports.TextBox txtCodArt;
        private DataDynamics.ActiveReports.TextBox txtArticulo;
        private DataDynamics.ActiveReports.TextBox txtUnidades;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Label lblTituloFecha;
        private DataDynamics.ActiveReports.Label lblPrecio;
        private DataDynamics.ActiveReports.Label lblUnidades;
        private DataDynamics.ActiveReports.Label lblTotal;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label Label15;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
        private DataDynamics.ActiveReports.Label lblArticulo;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.Label lblModulo;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.Label lblPagina;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.GroupHeader ghTotal;
        private DataDynamics.ActiveReports.GroupFooter gfTotal;
        private DataDynamics.ActiveReports.TextBox txtgranTotalTotal;
        private DataDynamics.ActiveReports.Label lblTotalVenta;
        private DataDynamics.ActiveReports.GroupHeader ghFormaPago;
        private DataDynamics.ActiveReports.TextBox txtFPago;
        private DataDynamics.ActiveReports.Label lblFPago;
        private DataDynamics.ActiveReports.GroupFooter gfFormaPago;
        private DataDynamics.ActiveReports.TextBox TotalPlacaTotal;
        private DataDynamics.ActiveReports.TextBox TextBox;
        private DataDynamics.ActiveReports.Label Label1;
    }
}
