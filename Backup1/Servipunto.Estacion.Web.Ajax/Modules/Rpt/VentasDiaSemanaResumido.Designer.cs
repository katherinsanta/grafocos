namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasDiaSemanaResumido.
    /// </summary>
    partial class VentasDiaSemanaResumido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasDiaSemanaResumido));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.ghTotal = new DataDynamics.ActiveReports.GroupHeader();
            this.gfTotal = new DataDynamics.ActiveReports.GroupFooter();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.lbl = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            this.lblUnidades = new DataDynamics.ActiveReports.Label();
            this.lblIva = new DataDynamics.ActiveReports.Label();
            this.lblTotal = new DataDynamics.ActiveReports.Label();
            this.lblSubTotal = new DataDynamics.ActiveReports.Label();
            this.lblRecaudo = new DataDynamics.ActiveReports.Label();
            this.lblDia = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtIva = new DataDynamics.ActiveReports.TextBox();
            this.txtSubTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtRecaudo = new DataDynamics.ActiveReports.TextBox();
            this.txtUnidades = new DataDynamics.ActiveReports.TextBox();
            this.txtDia = new DataDynamics.ActiveReports.TextBox();
            this.TextBox6 = new DataDynamics.ActiveReports.TextBox();
            this.txtGranTotalCantidad = new DataDynamics.ActiveReports.TextBox();
            this.txtGranTotalUndades = new DataDynamics.ActiveReports.TextBox();
            this.txtGranTotalIva = new DataDynamics.ActiveReports.TextBox();
            this.txtgranTotalTotal = new DataDynamics.ActiveReports.TextBox();
            this.srptFormasPago = new DataDynamics.ActiveReports.SubReport();
            this.lblTotalVenta = new DataDynamics.ActiveReports.Label();
            this.txtTotalVentaRecaudo = new DataDynamics.ActiveReports.TextBox();
            this.srptGrafica = new DataDynamics.ActiveReports.SubReport();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRecaudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecaudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalUndades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVentaRecaudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTotal,
            this.txtIva,
            this.txtSubTotal,
            this.txtRecaudo,
            this.txtUnidades,
            this.txtDia,
            this.TextBox6});
            this.Detail.Height = 0.2388889F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblHora,
            this.Line,
            this.Line1,
            this.lblFecha,
            this.srptEncabezado,
            this.lbl,
            this.lblTituloFechas,
            this.lblUnidades,
            this.lblIva,
            this.lblTotal,
            this.lblSubTotal,
            this.lblRecaudo,
            this.lblDia,
            this.Label2});
            this.PageHeader.Height = 1.540972F;
            this.PageHeader.Name = "PageHeader";
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
            // 
            // ghTotal
            // 
            this.ghTotal.Height = 0F;
            this.ghTotal.Name = "ghTotal";
            // 
            // gfTotal
            // 
            this.gfTotal.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtGranTotalCantidad,
            this.txtGranTotalUndades,
            this.txtGranTotalIva,
            this.txtgranTotalTotal,
            this.srptFormasPago,
            this.lblTotalVenta,
            this.txtTotalVentaRecaudo,
            this.srptGrafica,
            this.TextBox8});
            this.gfTotal.Height = 2.854167F;
            this.gfTotal.Name = "gfTotal";
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
            this.lblHora.Left = 6.643703F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora:";
            this.lblHora.Top = 0.8038382F;
            this.lblHora.Width = 1.181105F;
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
            this.Line.Width = 8.046257F;
            this.Line.X1 = 0F;
            this.Line.X2 = 8.046257F;
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
            this.Line1.Width = 8.046257F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 8.046257F;
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
            this.lblFecha.Left = 6.643703F;
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
            this.srptEncabezado.Left = 1.058069F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0F;
            this.srptEncabezado.Width = 5.536417F;
            // 
            // lbl
            // 
            this.lbl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl.Border.RightColor = System.Drawing.Color.Black;
            this.lbl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl.Border.TopColor = System.Drawing.Color.Black;
            this.lbl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl.Height = 0.2F;
            this.lbl.HyperLink = null;
            this.lbl.Left = 1.230315F;
            this.lbl.Name = "lbl";
            this.lbl.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lbl.Text = "Reporte de Ventas por Dia de la Semana Resumido";
            this.lbl.Top = 0.7627952F;
            this.lbl.Width = 5.093504F;
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
            this.lblTituloFechas.Left = 1.058069F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTituloFechas.Text = "Titulo con las fechas";
            this.lblTituloFechas.Top = 1.008858F;
            this.lblTituloFechas.Width = 5.536417F;
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
            this.lblUnidades.Left = 1.156496F;
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Style = "text-align: right; ";
            this.lblUnidades.Text = "Unidades";
            this.lblUnidades.Top = 1.304134F;
            this.lblUnidades.Width = 0.8612201F;
            // 
            // lblIva
            // 
            this.lblIva.Border.BottomColor = System.Drawing.Color.Black;
            this.lblIva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIva.Border.LeftColor = System.Drawing.Color.Black;
            this.lblIva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIva.Border.RightColor = System.Drawing.Color.Black;
            this.lblIva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIva.Border.TopColor = System.Drawing.Color.Black;
            this.lblIva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIva.Height = 0.2F;
            this.lblIva.HyperLink = null;
            this.lblIva.Left = 4.822833F;
            this.lblIva.Name = "lblIva";
            this.lblIva.Style = "text-align: right; ";
            this.lblIva.Text = "Descuento";
            this.lblIva.Top = 1.304134F;
            this.lblIva.Width = 0.7381909F;
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
            this.lblTotal.Left = 6.692914F;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Style = "text-align: right; ";
            this.lblTotal.Text = "Total";
            this.lblTotal.Top = 1.304134F;
            this.lblTotal.Width = 1.353345F;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.lblSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSubTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.lblSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSubTotal.Border.RightColor = System.Drawing.Color.Black;
            this.lblSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSubTotal.Border.TopColor = System.Drawing.Color.Black;
            this.lblSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSubTotal.Height = 0.2F;
            this.lblSubTotal.HyperLink = null;
            this.lblSubTotal.Left = 3.494095F;
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Style = "text-align: right; ";
            this.lblSubTotal.Text = "Sub Total";
            this.lblSubTotal.Top = 1.304134F;
            this.lblSubTotal.Width = 1.304133F;
            // 
            // lblRecaudo
            // 
            this.lblRecaudo.Border.BottomColor = System.Drawing.Color.Black;
            this.lblRecaudo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRecaudo.Border.LeftColor = System.Drawing.Color.Black;
            this.lblRecaudo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRecaudo.Border.RightColor = System.Drawing.Color.Black;
            this.lblRecaudo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRecaudo.Border.TopColor = System.Drawing.Color.Black;
            this.lblRecaudo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRecaudo.Height = 0.2F;
            this.lblRecaudo.HyperLink = null;
            this.lblRecaudo.Left = 5.610237F;
            this.lblRecaudo.Name = "lblRecaudo";
            this.lblRecaudo.Style = "text-align: right; ";
            this.lblRecaudo.Text = "Recaudo";
            this.lblRecaudo.Top = 1.304134F;
            this.lblRecaudo.Width = 1.058069F;
            // 
            // lblDia
            // 
            this.lblDia.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDia.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDia.Border.RightColor = System.Drawing.Color.Black;
            this.lblDia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDia.Border.TopColor = System.Drawing.Color.Black;
            this.lblDia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDia.Height = 0.2F;
            this.lblDia.HyperLink = null;
            this.lblDia.Left = 0.09842521F;
            this.lblDia.Name = "lblDia";
            this.lblDia.Style = "text-align: left; ";
            this.lblDia.Text = "Dia";
            this.lblDia.Top = 1.304134F;
            this.lblDia.Width = 0.9350396F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 2.066928F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: right; ";
            this.Label2.Text = "Valor Neto";
            this.Label2.Top = 1.303149F;
            this.Label2.Width = 1.377953F;
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
            this.txtTotal.Left = 6.742126F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat");
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = "Total";
            this.txtTotal.Top = 0.0246063F;
            this.txtTotal.Width = 1.30413F;
            // 
            // txtIva
            // 
            this.txtIva.Border.BottomColor = System.Drawing.Color.Black;
            this.txtIva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIva.Border.LeftColor = System.Drawing.Color.Black;
            this.txtIva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIva.Border.RightColor = System.Drawing.Color.Black;
            this.txtIva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIva.Border.TopColor = System.Drawing.Color.Black;
            this.txtIva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIva.DataField = "Descuento";
            this.txtIva.Height = 0.2F;
            this.txtIva.Left = 4.798229F;
            this.txtIva.Name = "txtIva";
            this.txtIva.OutputFormat = resources.GetString("txtIva.OutputFormat");
            this.txtIva.Style = "text-align: right; ";
            this.txtIva.Text = "Descuento";
            this.txtIva.Top = 0.02460633F;
            this.txtIva.Width = 0.7135819F;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.DataField = "SubTotal";
            this.txtSubTotal.Height = 0.2F;
            this.txtSubTotal.Left = 3.444882F;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.OutputFormat = resources.GetString("txtSubTotal.OutputFormat");
            this.txtSubTotal.Style = "text-align: right; ";
            this.txtSubTotal.Text = "Sub Total";
            this.txtSubTotal.Top = 0.02460633F;
            this.txtSubTotal.Width = 1.328741F;
            // 
            // txtRecaudo
            // 
            this.txtRecaudo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRecaudo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRecaudo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRecaudo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRecaudo.Border.RightColor = System.Drawing.Color.Black;
            this.txtRecaudo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRecaudo.Border.TopColor = System.Drawing.Color.Black;
            this.txtRecaudo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRecaudo.DataField = "Recaudo";
            this.txtRecaudo.Height = 0.2F;
            this.txtRecaudo.Left = 5.536418F;
            this.txtRecaudo.Name = "txtRecaudo";
            this.txtRecaudo.OutputFormat = resources.GetString("txtRecaudo.OutputFormat");
            this.txtRecaudo.Style = "text-align: right; ";
            this.txtRecaudo.Text = "Recau";
            this.txtRecaudo.Top = 0.0246063F;
            this.txtRecaudo.Width = 1.181101F;
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
            this.txtUnidades.DataField = "Unidades";
            this.txtUnidades.Height = 0.2F;
            this.txtUnidades.Left = 1.156496F;
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Style = "text-align: right; ";
            this.txtUnidades.Text = "Unidades";
            this.txtUnidades.Top = 0.0246063F;
            this.txtUnidades.Width = 0.8366139F;
            // 
            // txtDia
            // 
            this.txtDia.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDia.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDia.Border.RightColor = System.Drawing.Color.Black;
            this.txtDia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDia.Border.TopColor = System.Drawing.Color.Black;
            this.txtDia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDia.DataField = "Dia";
            this.txtDia.Height = 0.2F;
            this.txtDia.Left = 0.04921257F;
            this.txtDia.Name = "txtDia";
            this.txtDia.Style = "text-align: left; ";
            this.txtDia.Text = "Dia";
            this.txtDia.Top = 0.0246063F;
            this.txtDia.Width = 0.9842521F;
            // 
            // TextBox6
            // 
            this.TextBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.DataField = "ValorNeto";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 2.042322F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "text-align: right; ";
            this.TextBox6.Text = "ValorNeto";
            this.TextBox6.Top = 0.025F;
            this.TextBox6.Width = 1.353346F;
            // 
            // txtGranTotalCantidad
            // 
            this.txtGranTotalCantidad.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGranTotalCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalCantidad.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGranTotalCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalCantidad.Border.RightColor = System.Drawing.Color.Black;
            this.txtGranTotalCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalCantidad.Border.TopColor = System.Drawing.Color.Black;
            this.txtGranTotalCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.txtGranTotalCantidad.DataField = "Unidades";
            this.txtGranTotalCantidad.Height = 0.2F;
            this.txtGranTotalCantidad.Left = 1.13189F;
            this.txtGranTotalCantidad.Name = "txtGranTotalCantidad";
            this.txtGranTotalCantidad.OutputFormat = resources.GetString("txtGranTotalCantidad.OutputFormat");
            this.txtGranTotalCantidad.Style = "text-align: right; ";
            this.txtGranTotalCantidad.SummaryGroup = "ghTotal";
            this.txtGranTotalCantidad.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtGranTotalCantidad.Text = "Unidades";
            this.txtGranTotalCantidad.Top = 0.0246063F;
            this.txtGranTotalCantidad.Width = 0.8366139F;
            // 
            // txtGranTotalUndades
            // 
            this.txtGranTotalUndades.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGranTotalUndades.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalUndades.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGranTotalUndades.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalUndades.Border.RightColor = System.Drawing.Color.Black;
            this.txtGranTotalUndades.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalUndades.Border.TopColor = System.Drawing.Color.Black;
            this.txtGranTotalUndades.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.txtGranTotalUndades.DataField = "SubTotal";
            this.txtGranTotalUndades.Height = 0.2F;
            this.txtGranTotalUndades.Left = 3.444882F;
            this.txtGranTotalUndades.Name = "txtGranTotalUndades";
            this.txtGranTotalUndades.OutputFormat = resources.GetString("txtGranTotalUndades.OutputFormat");
            this.txtGranTotalUndades.Style = "text-align: right; ";
            this.txtGranTotalUndades.SummaryGroup = "ghTotal";
            this.txtGranTotalUndades.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtGranTotalUndades.Text = "Sub Total";
            this.txtGranTotalUndades.Top = 0.0246063F;
            this.txtGranTotalUndades.Width = 1.328741F;
            // 
            // txtGranTotalIva
            // 
            this.txtGranTotalIva.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGranTotalIva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalIva.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGranTotalIva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalIva.Border.RightColor = System.Drawing.Color.Black;
            this.txtGranTotalIva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGranTotalIva.Border.TopColor = System.Drawing.Color.Black;
            this.txtGranTotalIva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.txtGranTotalIva.DataField = "Descuento";
            this.txtGranTotalIva.Height = 0.2F;
            this.txtGranTotalIva.Left = 4.798228F;
            this.txtGranTotalIva.Name = "txtGranTotalIva";
            this.txtGranTotalIva.OutputFormat = resources.GetString("txtGranTotalIva.OutputFormat");
            this.txtGranTotalIva.Style = "text-align: right; ";
            this.txtGranTotalIva.SummaryGroup = "ghTotal";
            this.txtGranTotalIva.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtGranTotalIva.Text = "Descuento";
            this.txtGranTotalIva.Top = 0.0246063F;
            this.txtGranTotalIva.Width = 0.7135834F;
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
            this.txtgranTotalTotal.Left = 6.742126F;
            this.txtgranTotalTotal.Name = "txtgranTotalTotal";
            this.txtgranTotalTotal.OutputFormat = resources.GetString("txtgranTotalTotal.OutputFormat");
            this.txtgranTotalTotal.Style = "text-align: right; ";
            this.txtgranTotalTotal.SummaryGroup = "ghTotal";
            this.txtgranTotalTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtgranTotalTotal.Text = "Total";
            this.txtgranTotalTotal.Top = 0.0246063F;
            this.txtgranTotalTotal.Width = 1.304134F;
            // 
            // srptFormasPago
            // 
            this.srptFormasPago.Border.BottomColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.Border.LeftColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.Border.RightColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.Border.TopColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.CloseBorder = false;
            this.srptFormasPago.Height = 0.3198819F;
            this.srptFormasPago.Left = 0.08710785F;
            this.srptFormasPago.Name = "srptFormasPago";
            this.srptFormasPago.Report = null;
            this.srptFormasPago.ReportName = "SubFormasPago";
            this.srptFormasPago.Top = 0.4104325F;
            this.srptFormasPago.Width = 5.511809F;
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
            this.lblTotalVenta.Left = 0F;
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Style = "font-weight: bold; font-size: 12pt; ";
            this.lblTotalVenta.Text = "Total Ventas:";
            this.lblTotalVenta.Top = 0F;
            this.lblTotalVenta.Width = 1.107283F;
            // 
            // txtTotalVentaRecaudo
            // 
            this.txtTotalVentaRecaudo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalVentaRecaudo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalVentaRecaudo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalVentaRecaudo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalVentaRecaudo.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalVentaRecaudo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalVentaRecaudo.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalVentaRecaudo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.txtTotalVentaRecaudo.DataField = "Recaudo";
            this.txtTotalVentaRecaudo.Height = 0.2F;
            this.txtTotalVentaRecaudo.Left = 5.536418F;
            this.txtTotalVentaRecaudo.Name = "txtTotalVentaRecaudo";
            this.txtTotalVentaRecaudo.OutputFormat = resources.GetString("txtTotalVentaRecaudo.OutputFormat");
            this.txtTotalVentaRecaudo.Style = "text-align: right; ";
            this.txtTotalVentaRecaudo.SummaryGroup = "ghTotal";
            this.txtTotalVentaRecaudo.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtTotalVentaRecaudo.Text = "Reca";
            this.txtTotalVentaRecaudo.Top = 0.0246063F;
            this.txtTotalVentaRecaudo.Width = 1.181101F;
            // 
            // srptGrafica
            // 
            this.srptGrafica.Border.BottomColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.Border.LeftColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.Border.RightColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.Border.TopColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.CloseBorder = false;
            this.srptGrafica.Height = 1.885827F;
            this.srptGrafica.Left = 0.09842521F;
            this.srptGrafica.Name = "srptGrafica";
            this.srptGrafica.Report = null;
            this.srptGrafica.ReportName = "SubGraficaVentasPorManguera.rpx";
            this.srptGrafica.Top = 0.8799209F;
            this.srptGrafica.Width = 7.504923F;
            // 
            // TextBox8
            // 
            this.TextBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.TextBox8.DataField = "ValorNeto";
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 2.017715F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat");
            this.TextBox8.Style = "text-align: right; ";
            this.TextBox8.SummaryGroup = "ghTotal";
            this.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox8.Text = "ValorNeto";
            this.TextBox8.Top = 0.025F;
            this.TextBox8.Width = 1.377953F;
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
            this.Label.Width = 3.5F;
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
            this.lblPagina.Left = 6.465051F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt; ";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.1875F;
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
            this.lblDe.Left = 7.324785F;
            this.lblDe.Name = "lblDe";
            this.lblDe.Style = "font-size: 8pt; ";
            this.lblDe.Text = "de";
            this.lblDe.Top = 0.1875F;
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
            this.lblAno.Left = 0.6250003F;
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
            this.txtNumeroPagina.Left = 6.840551F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.1835629F;
            this.txtNumeroPagina.Width = 0.4788508F;
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
            this.txtNumeroPaginas.Left = 7.480313F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.1889764F;
            this.txtNumeroPaginas.Width = 0.5526695F;
            // 
            // VentasDiaSemanaResumido
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.1965278F;
            this.PageSettings.Margins.Left = 0.1965278F;
            this.PageSettings.Margins.Right = 0.1965278F;
            this.PageSettings.Margins.Top = 0.1965278F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.072917F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ghTotal);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.gfTotal);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRecaudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecaudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalUndades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVentaRecaudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);

        }
        #endregion

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.TextBox txtIva;
        private DataDynamics.ActiveReports.TextBox txtSubTotal;
        private DataDynamics.ActiveReports.TextBox txtRecaudo;
        private DataDynamics.ActiveReports.TextBox txtUnidades;
        private DataDynamics.ActiveReports.TextBox txtDia;
        private DataDynamics.ActiveReports.TextBox TextBox6;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label lbl;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
        private DataDynamics.ActiveReports.Label lblUnidades;
        private DataDynamics.ActiveReports.Label lblIva;
        private DataDynamics.ActiveReports.Label lblTotal;
        private DataDynamics.ActiveReports.Label lblSubTotal;
        private DataDynamics.ActiveReports.Label lblRecaudo;
        private DataDynamics.ActiveReports.Label lblDia;
        private DataDynamics.ActiveReports.Label Label2;
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
        private DataDynamics.ActiveReports.TextBox txtGranTotalCantidad;
        private DataDynamics.ActiveReports.TextBox txtGranTotalUndades;
        private DataDynamics.ActiveReports.TextBox txtGranTotalIva;
        private DataDynamics.ActiveReports.TextBox txtgranTotalTotal;
        private DataDynamics.ActiveReports.SubReport srptFormasPago;
        private DataDynamics.ActiveReports.Label lblTotalVenta;
        private DataDynamics.ActiveReports.TextBox txtTotalVentaRecaudo;
        private DataDynamics.ActiveReports.SubReport srptGrafica;
        private DataDynamics.ActiveReports.TextBox TextBox8;
    }
}
