namespace Servipunto.Estacion.Web.Ajax.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasSuic.
    /// </summary>
    partial class VentasSuic
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(VentasSuic));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.lblPlaca = new DataDynamics.ActiveReports.Label();
            this.lblFechaMant = new DataDynamics.ActiveReports.Label();
            this.lblCantVentas = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.lblfechaVe = new DataDynamics.ActiveReports.Label();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtFechMant = new DataDynamics.ActiveReports.TextBox();
            this.txtVenta = new DataDynamics.ActiveReports.TextBox();
            this.txtVenUlti = new DataDynamics.ActiveReports.TextBox();
            this.txtPlaca = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlaca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaMant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCantVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblfechaVe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechMant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenUlti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.srptEncabezado,
            this.lblTitle,
            this.lblHora,
            this.lblFecha,
            this.line1,
            this.lblPlaca,
            this.lblFechaMant,
            this.lblCantVentas,
            this.line2,
            this.lblfechaVe,
            this.lblTituloFechas});
            this.pageHeader.Height = 1.59375F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
            this.srptEncabezado.Left = 0.4375F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0F;
            this.srptEncabezado.Width = 5.536417F;
            // 
            // lblTitle
            // 
            this.lblTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Height = 0.2F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0.375F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTitle.Text = "Reporte De Vehiculo Suic ";
            this.lblTitle.Top = 0.75F;
            this.lblTitle.Width = 5.093504F;
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
            this.lblHora.Left = 5.6875F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora:";
            this.lblHora.Top = 0.8125F;
            this.lblHora.Width = 1.181105F;
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
            this.lblFecha.Left = 5.6875F;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Style = "white-space: inherit; ";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Top = 0.5625F;
            this.lblFecha.Width = 1.230315F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0.125F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 1.25F;
            this.line1.Width = 7.0625F;
            this.line1.X1 = 0.125F;
            this.line1.X2 = 7.1875F;
            this.line1.Y1 = 1.25F;
            this.line1.Y2 = 1.25F;
            // 
            // lblPlaca
            // 
            this.lblPlaca.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPlaca.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPlaca.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPlaca.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPlaca.Border.RightColor = System.Drawing.Color.Black;
            this.lblPlaca.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPlaca.Border.TopColor = System.Drawing.Color.Black;
            this.lblPlaca.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPlaca.Height = 0.1875F;
            this.lblPlaca.HyperLink = null;
            this.lblPlaca.Left = 0.4375F;
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.RightToLeft = true;
            this.lblPlaca.Style = "";
            this.lblPlaca.Text = "Placa";
            this.lblPlaca.Top = 1.3125F;
            this.lblPlaca.Width = 1.3125F;
            // 
            // lblFechaMant
            // 
            this.lblFechaMant.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFechaMant.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaMant.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFechaMant.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaMant.Border.RightColor = System.Drawing.Color.Black;
            this.lblFechaMant.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaMant.Border.TopColor = System.Drawing.Color.Black;
            this.lblFechaMant.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaMant.Height = 0.1875F;
            this.lblFechaMant.HyperLink = null;
            this.lblFechaMant.Left = 1.8125F;
            this.lblFechaMant.Name = "lblFechaMant";
            this.lblFechaMant.Style = "";
            this.lblFechaMant.Text = "Fecha Mantenimieto";
            this.lblFechaMant.Top = 1.3125F;
            this.lblFechaMant.Width = 1.625F;
            // 
            // lblCantVentas
            // 
            this.lblCantVentas.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCantVentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCantVentas.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCantVentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCantVentas.Border.RightColor = System.Drawing.Color.Black;
            this.lblCantVentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCantVentas.Border.TopColor = System.Drawing.Color.Black;
            this.lblCantVentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCantVentas.Height = 0.1875F;
            this.lblCantVentas.HyperLink = null;
            this.lblCantVentas.Left = 3.5F;
            this.lblCantVentas.Name = "lblCantVentas";
            this.lblCantVentas.Style = "";
            this.lblCantVentas.Text = "Cantidad De Ventas";
            this.lblCantVentas.Top = 1.3125F;
            this.lblCantVentas.Width = 1.3125F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0.125F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 1.5625F;
            this.line2.Width = 7.0625F;
            this.line2.X1 = 0.125F;
            this.line2.X2 = 7.1875F;
            this.line2.Y1 = 1.5625F;
            this.line2.Y2 = 1.5625F;
            // 
            // lblfechaVe
            // 
            this.lblfechaVe.Border.BottomColor = System.Drawing.Color.Black;
            this.lblfechaVe.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblfechaVe.Border.LeftColor = System.Drawing.Color.Black;
            this.lblfechaVe.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblfechaVe.Border.RightColor = System.Drawing.Color.Black;
            this.lblfechaVe.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblfechaVe.Border.TopColor = System.Drawing.Color.Black;
            this.lblfechaVe.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblfechaVe.Height = 0.1875F;
            this.lblfechaVe.HyperLink = null;
            this.lblfechaVe.Left = 4.875F;
            this.lblfechaVe.Name = "lblfechaVe";
            this.lblfechaVe.Style = "";
            this.lblfechaVe.Text = "Ultima Venta";
            this.lblfechaVe.Top = 1.3125F;
            this.lblfechaVe.Width = 1.5625F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtFechMant,
            this.txtVenta,
            this.txtVenUlti,
            this.txtPlaca});
            this.detail.Height = 0.2395833F;
            this.detail.Name = "detail";
            // 
            // txtFechMant
            // 
            this.txtFechMant.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFechMant.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechMant.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFechMant.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechMant.Border.RightColor = System.Drawing.Color.Black;
            this.txtFechMant.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechMant.Border.TopColor = System.Drawing.Color.Black;
            this.txtFechMant.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechMant.DataField = "fechamante";
            this.txtFechMant.Height = 0.1875F;
            this.txtFechMant.Left = 1.8125F;
            this.txtFechMant.Name = "txtFechMant";
            this.txtFechMant.Style = "";
            this.txtFechMant.Text = "Fecha Mantenimiento";
            this.txtFechMant.Top = 0F;
            this.txtFechMant.Width = 1.6875F;
            // 
            // txtVenta
            // 
            this.txtVenta.Border.BottomColor = System.Drawing.Color.Black;
            this.txtVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenta.Border.LeftColor = System.Drawing.Color.Black;
            this.txtVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenta.Border.RightColor = System.Drawing.Color.Black;
            this.txtVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenta.Border.TopColor = System.Drawing.Color.Black;
            this.txtVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenta.DataField = "cant";
            this.txtVenta.Height = 0.1875F;
            this.txtVenta.Left = 3.5F;
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Style = "text-align: center; ";
            this.txtVenta.Text = "Cantidad De Ventas";
            this.txtVenta.Top = 0F;
            this.txtVenta.Width = 1.3125F;
            // 
            // txtVenUlti
            // 
            this.txtVenUlti.Border.BottomColor = System.Drawing.Color.Black;
            this.txtVenUlti.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenUlti.Border.LeftColor = System.Drawing.Color.Black;
            this.txtVenUlti.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenUlti.Border.RightColor = System.Drawing.Color.Black;
            this.txtVenUlti.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenUlti.Border.TopColor = System.Drawing.Color.Black;
            this.txtVenUlti.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVenUlti.DataField = "fechareal";
            this.txtVenUlti.Height = 0.1875F;
            this.txtVenUlti.Left = 4.875F;
            this.txtVenUlti.Name = "txtVenUlti";
            this.txtVenUlti.Style = "";
            this.txtVenUlti.Text = "Ultima Venta";
            this.txtVenUlti.Top = 0F;
            this.txtVenUlti.Width = 1.75F;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPlaca.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPlaca.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPlaca.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPlaca.Border.RightColor = System.Drawing.Color.Black;
            this.txtPlaca.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPlaca.Border.TopColor = System.Drawing.Color.Black;
            this.txtPlaca.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPlaca.DataField = "placa";
            this.txtPlaca.Height = 0.1875F;
            this.txtPlaca.Left = 0.4375F;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.RightToLeft = true;
            this.txtPlaca.Style = "";
            this.txtPlaca.Text = "Placa";
            this.txtPlaca.Top = 0F;
            this.txtPlaca.Width = 1.3125F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblModulo,
            this.Label2,
            this.lblPagina,
            this.txtNumeroPagina,
            this.txtNumeroPaginas,
            this.lblDe,
            this.lblAno});
            this.pageFooter.Height = 0.4375F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
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
            this.Label2.Height = 0.1875F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; ";
            this.Label2.Text = "© Copyright                 Zencillo de Software Ltda. Todos los Derechos Reser" +
                "vados.";
            this.Label2.Top = 0.1875F;
            this.Label2.Width = 4.25F;
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
            this.lblPagina.Left = 5.25F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt; ";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.125F;
            this.lblPagina.Width = 0.375F;
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
            this.txtNumeroPagina.Left = 5.625F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.125F;
            this.txtNumeroPagina.Width = 0.5772762F;
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
            this.txtNumeroPaginas.Left = 6.4375F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.125F;
            this.txtNumeroPaginas.Width = 0.5659451F;
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
            this.lblDe.Left = 6.25F;
            this.lblDe.Name = "lblDe";
            this.lblDe.Style = "font-size: 8pt; ";
            this.lblDe.Text = "de";
            this.lblDe.Top = 0.125F;
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
            this.lblAno.Left = 0.75F;
            this.lblAno.Name = "lblAno";
            this.lblAno.Style = "font-size: 8pt; ";
            this.lblAno.Text = "Año";
            this.lblAno.Top = 0.1875F;
            this.lblAno.Width = 0.375F;
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
            this.lblTituloFechas.Left = 0.25F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTituloFechas.Text = "Titulo con las fechas";
            this.lblTituloFechas.Top = 1F;
            this.lblTituloFechas.Width = 5.536417F;
            // 
            // VentasSuic
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.1875F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlaca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaMant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCantVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblfechaVe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechMant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenUlti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Label lblPlaca;
        private DataDynamics.ActiveReports.Label lblFechaMant;
        private DataDynamics.ActiveReports.Label lblCantVentas;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.TextBox txtPlaca;
        private DataDynamics.ActiveReports.TextBox txtFechMant;
        private DataDynamics.ActiveReports.TextBox txtVenta;
        private DataDynamics.ActiveReports.Label lblModulo;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.Label lblPagina;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.Label lblfechaVe;
        private DataDynamics.ActiveReports.TextBox txtVenUlti;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
    }
}
