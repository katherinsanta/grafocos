namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasCanastillaResumido.
    /// </summary>
    partial class VentasCanastillaResumido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasCanastillaResumido));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.ghTotal = new DataDynamics.ActiveReports.GroupHeader();
            this.gfTotal = new DataDynamics.ActiveReports.GroupFooter();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.lblTitulo = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            this.lblConsecutivo = new DataDynamics.ActiveReports.Label();
            this.lblUnidades = new DataDynamics.ActiveReports.Label();
            this.lblTotal = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.lblSubTotal = new DataDynamics.ActiveReports.Label();
            this.lblIva = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.lblEmpleado = new DataDynamics.ActiveReports.Label();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtIva = new DataDynamics.ActiveReports.TextBox();
            this.txtSubTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtCantidad = new DataDynamics.ActiveReports.TextBox();
            this.txtConsecutivo = new DataDynamics.ActiveReports.TextBox();
            this.txtFactura = new DataDynamics.ActiveReports.TextBox();
            this.txtGranTotalCantidad = new DataDynamics.ActiveReports.TextBox();
            this.txtGranTotalUndades = new DataDynamics.ActiveReports.TextBox();
            this.txtGranTotalIva = new DataDynamics.ActiveReports.TextBox();
            this.txtgranTotalTotal = new DataDynamics.ActiveReports.TextBox();
            this.srptFormasPago = new DataDynamics.ActiveReports.SubReport();
            this.lblTotalVenta = new DataDynamics.ActiveReports.Label();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblConsecutivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConsecutivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalUndades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).BeginInit();
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
            this.txtCantidad,
            this.txtConsecutivo,
            this.txtFactura});
            this.Detail.Height = 0.2708333F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.srptEncabezado,
            this.lblFecha,
            this.lblHora,
            this.lblTitulo,
            this.lblTituloFechas,
            this.lblConsecutivo,
            this.lblUnidades,
            this.lblTotal,
            this.Line,
            this.Line1,
            this.lblSubTotal,
            this.lblIva,
            this.Label1,
            this.lblEmpleado});
            this.PageHeader.Height = 1.788889F;
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
            this.lblTotalVenta});
            this.gfTotal.Height = 0.8541667F;
            this.gfTotal.Name = "gfTotal";
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
            this.srptEncabezado.Left = 0.5413386F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0F;
            this.srptEncabezado.Width = 5.536417F;
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
            this.lblFecha.Left = 6.126966F;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Style = "white-space: inherit; ";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Top = 0.6151575F;
            this.lblFecha.Width = 1.230315F;
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
            this.lblHora.Left = 6.126966F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora:";
            this.lblHora.Top = 0.8530514F;
            this.lblHora.Width = 1.181105F;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTitulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitulo.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTitulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitulo.Border.RightColor = System.Drawing.Color.Black;
            this.lblTitulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitulo.Border.TopColor = System.Drawing.Color.Black;
            this.lblTitulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitulo.Height = 0.2F;
            this.lblTitulo.HyperLink = null;
            this.lblTitulo.Left = 1.082677F;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTitulo.Text = "Reporte de Ventas Canastilla Resumido";
            this.lblTitulo.Top = 0.7874014F;
            this.lblTitulo.Width = 4.625985F;
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
            this.lblTituloFechas.Left = 0.1875F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTituloFechas.Text = "Titulo con las fechas";
            this.lblTituloFechas.Top = 1.033465F;
            this.lblTituloFechas.Width = 5.9375F;
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.Border.BottomColor = System.Drawing.Color.Black;
            this.lblConsecutivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblConsecutivo.Border.LeftColor = System.Drawing.Color.Black;
            this.lblConsecutivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblConsecutivo.Border.RightColor = System.Drawing.Color.Black;
            this.lblConsecutivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblConsecutivo.Border.TopColor = System.Drawing.Color.Black;
            this.lblConsecutivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblConsecutivo.Height = 0.2F;
            this.lblConsecutivo.HyperLink = null;
            this.lblConsecutivo.Left = 0.02460469F;
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Style = "text-align: left; ";
            this.lblConsecutivo.Text = "Cod";
            this.lblConsecutivo.Top = 1.554134F;
            this.lblConsecutivo.Width = 0.4675193F;
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
            this.lblUnidades.Left = 2.066927F;
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Style = "text-align: right; ";
            this.lblUnidades.Text = "Cantidad";
            this.lblUnidades.Top = 1.554134F;
            this.lblUnidades.Width = 0.8120105F;
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
            this.lblTotal.Left = 4.98081F;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Style = "text-align: right; ";
            this.lblTotal.Text = "Total";
            this.lblTotal.Top = 1.546875F;
            this.lblTotal.Width = 1.19439F;
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
            this.Line.Left = 0.0625F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 1.53125F;
            this.Line.Width = 7.406493F;
            this.Line.X1 = 0.0625F;
            this.Line.X2 = 7.468993F;
            this.Line.Y1 = 1.53125F;
            this.Line.Y2 = 1.53125F;
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
            this.Line1.Left = 0.0246063F;
            this.Line1.LineWeight = 2F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.77559F;
            this.Line1.Width = 7.406491F;
            this.Line1.X1 = 0.0246063F;
            this.Line1.X2 = 7.431098F;
            this.Line1.Y1 = 1.77559F;
            this.Line1.Y2 = 1.77559F;
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
            this.lblSubTotal.Left = 2.878938F;
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Style = "text-align: right; ";
            this.lblSubTotal.Text = "Sub Total";
            this.lblSubTotal.Top = 1.554134F;
            this.lblSubTotal.Width = 1.228346F;
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
            this.lblIva.Left = 4.107285F;
            this.lblIva.Name = "lblIva";
            this.lblIva.Style = "text-align: right; ";
            this.lblIva.Text = "Iva";
            this.lblIva.Top = 1.554134F;
            this.lblIva.Width = 0.873525F;
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
            this.Label1.Left = 0.4921241F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: left; ";
            this.Label1.Text = "Articulo";
            this.Label1.Top = 1.545965F;
            this.Label1.Width = 1.574803F;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.Border.BottomColor = System.Drawing.Color.Black;
            this.lblEmpleado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEmpleado.Border.LeftColor = System.Drawing.Color.Black;
            this.lblEmpleado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEmpleado.Border.RightColor = System.Drawing.Color.Black;
            this.lblEmpleado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEmpleado.Border.TopColor = System.Drawing.Color.Black;
            this.lblEmpleado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblEmpleado.Height = 0.2F;
            this.lblEmpleado.HyperLink = null;
            this.lblEmpleado.Left = 0.1875F;
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblEmpleado.Text = "Empleado";
            this.lblEmpleado.Top = 1.25F;
            this.lblEmpleado.Width = 5.9375F;
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
            this.txtTotal.Left = 4.98081F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat");
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = "Total";
            this.txtTotal.Top = 0.015625F;
            this.txtTotal.Width = 1.19439F;
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
            this.txtIva.DataField = "Iva";
            this.txtIva.Height = 0.2F;
            this.txtIva.Left = 4.107285F;
            this.txtIva.Name = "txtIva";
            this.txtIva.OutputFormat = resources.GetString("txtIva.OutputFormat");
            this.txtIva.Style = "text-align: right; ";
            this.txtIva.Text = "Iva";
            this.txtIva.Top = 0.02460631F;
            this.txtIva.Width = 0.873525F;
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
            this.txtSubTotal.Left = 2.878938F;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.OutputFormat = resources.GetString("txtSubTotal.OutputFormat");
            this.txtSubTotal.Style = "text-align: right; ";
            this.txtSubTotal.Text = "Sub Total";
            this.txtSubTotal.Top = 0.02460635F;
            this.txtSubTotal.Width = 1.228346F;
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
            this.txtCantidad.DataField = "Cantidad";
            this.txtCantidad.Height = 0.2F;
            this.txtCantidad.Left = 2.066927F;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat");
            this.txtCantidad.Style = "text-align: right; ";
            this.txtCantidad.Text = "Cantidad";
            this.txtCantidad.Top = 0.02460631F;
            this.txtCantidad.Width = 0.8120105F;
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtConsecutivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtConsecutivo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtConsecutivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtConsecutivo.Border.RightColor = System.Drawing.Color.Black;
            this.txtConsecutivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtConsecutivo.Border.TopColor = System.Drawing.Color.Black;
            this.txtConsecutivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtConsecutivo.DataField = "Cod";
            this.txtConsecutivo.Height = 0.2F;
            this.txtConsecutivo.Left = 0.02460469F;
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.Style = "text-align: left; ";
            this.txtConsecutivo.Text = "Art";
            this.txtConsecutivo.Top = 0.0246063F;
            this.txtConsecutivo.Width = 0.4675193F;
            // 
            // txtFactura
            // 
            this.txtFactura.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFactura.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFactura.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFactura.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFactura.Border.RightColor = System.Drawing.Color.Black;
            this.txtFactura.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFactura.Border.TopColor = System.Drawing.Color.Black;
            this.txtFactura.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFactura.DataField = "Articulo";
            this.txtFactura.Height = 0.2F;
            this.txtFactura.Left = 0.4921241F;
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Style = "font-size: 9pt; ";
            this.txtFactura.Text = "Articulo";
            this.txtFactura.Top = 0.02460628F;
            this.txtFactura.Width = 1.574803F;
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
            this.txtGranTotalCantidad.DataField = "Cantidad";
            this.txtGranTotalCantidad.Height = 0.2F;
            this.txtGranTotalCantidad.Left = 2.044539F;
            this.txtGranTotalCantidad.Name = "txtGranTotalCantidad";
            this.txtGranTotalCantidad.OutputFormat = resources.GetString("txtGranTotalCantidad.OutputFormat");
            this.txtGranTotalCantidad.Style = "text-align: right; ";
            this.txtGranTotalCantidad.SummaryGroup = "ghTotal";
            this.txtGranTotalCantidad.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtGranTotalCantidad.Text = "Cantidad";
            this.txtGranTotalCantidad.Top = 5.587935E-09F;
            this.txtGranTotalCantidad.Width = 0.8366167F;
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
            this.txtGranTotalUndades.Left = 2.895833F;
            this.txtGranTotalUndades.Name = "txtGranTotalUndades";
            this.txtGranTotalUndades.OutputFormat = resources.GetString("txtGranTotalUndades.OutputFormat");
            this.txtGranTotalUndades.Style = "text-align: right; ";
            this.txtGranTotalUndades.SummaryGroup = "ghTotal";
            this.txtGranTotalUndades.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtGranTotalUndades.Text = "Sub Total";
            this.txtGranTotalUndades.Top = 0F;
            this.txtGranTotalUndades.Width = 1.229167F;
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
            this.txtGranTotalIva.DataField = "Iva";
            this.txtGranTotalIva.Height = 0.2F;
            this.txtGranTotalIva.Left = 4.125F;
            this.txtGranTotalIva.Name = "txtGranTotalIva";
            this.txtGranTotalIva.OutputFormat = resources.GetString("txtGranTotalIva.OutputFormat");
            this.txtGranTotalIva.Style = "text-align: right; ";
            this.txtGranTotalIva.SummaryGroup = "ghTotal";
            this.txtGranTotalIva.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtGranTotalIva.Text = "Iva";
            this.txtGranTotalIva.Top = 5.587935E-09F;
            this.txtGranTotalIva.Width = 0.8125F;
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
            this.txtgranTotalTotal.Left = 4.9375F;
            this.txtgranTotalTotal.Name = "txtgranTotalTotal";
            this.txtgranTotalTotal.OutputFormat = resources.GetString("txtgranTotalTotal.OutputFormat");
            this.txtgranTotalTotal.Style = "text-align: right; ";
            this.txtgranTotalTotal.SummaryGroup = "ghTotal";
            this.txtgranTotalTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtgranTotalTotal.Text = "Total";
            this.txtgranTotalTotal.Top = 0F;
            this.txtgranTotalTotal.Width = 1.25F;
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
            this.srptFormasPago.Left = 0.04921419F;
            this.srptFormasPago.Name = "srptFormasPago";
            this.srptFormasPago.Report = null;
            this.srptFormasPago.ReportName = "SubFormasPagoCanastilla";
            this.srptFormasPago.Top = 0.497539F;
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
            this.lblTotalVenta.Left = 0.0492127F;
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Style = "font-weight: bold; font-size: 12pt; ";
            this.lblTotalVenta.Text = "Total Venta:";
            this.lblTotalVenta.Top = 0F;
            this.lblTotalVenta.Width = 1F;
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
            this.lblModulo.Text = "Servipunto M�dulo de Estaci�n";
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
            this.Label.Text = "� Copyright           Zencillo de Software Ltda. Todos los Derechos Reservados." +
                "";
            this.Label.Top = 0.1968504F;
            this.Label.Width = 5.093504F;
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
            this.lblPagina.Left = 5.726863F;
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
            this.lblDe.Left = 6.68503F;
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
            this.lblAno.Left = 0.6250001F;
            this.lblAno.Name = "lblAno";
            this.lblAno.Style = "font-size: 8pt; ";
            this.lblAno.Text = "A�o";
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
            this.txtNumeroPagina.Left = 6.102363F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.183563F;
            this.txtNumeroPagina.Width = 0.5772753F;
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
            this.txtNumeroPaginas.Left = 6.840551F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.183563F;
            this.txtNumeroPaginas.Width = 0.6151577F;
            // 
            // VentasCanastillaResumido
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.4097222F;
            this.PageSettings.Margins.Left = 0.4097222F;
            this.PageSettings.Margins.Right = 0.4097222F;
            this.PageSettings.Margins.Top = 0.4097222F;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 7.479167F;
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
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblConsecutivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConsecutivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalUndades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGranTotalIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).EndInit();
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
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);

        }
        #endregion

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.TextBox txtIva;
        private DataDynamics.ActiveReports.TextBox txtSubTotal;
        private DataDynamics.ActiveReports.TextBox txtCantidad;
        private DataDynamics.ActiveReports.TextBox txtConsecutivo;
        private DataDynamics.ActiveReports.TextBox txtFactura;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Label lblTitulo;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
        private DataDynamics.ActiveReports.Label lblConsecutivo;
        private DataDynamics.ActiveReports.Label lblUnidades;
        private DataDynamics.ActiveReports.Label lblTotal;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label lblSubTotal;
        private DataDynamics.ActiveReports.Label lblIva;
        private DataDynamics.ActiveReports.Label Label1;
        private DataDynamics.ActiveReports.Label lblEmpleado;
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
    }
}
