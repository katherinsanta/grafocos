namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasCanastillaAnuladas.
    /// </summary>
    partial class VentasCanastillaAnuladas
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(VentasCanastillaAnuladas));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtIdentificacion = new DataDynamics.ActiveReports.TextBox();
            this.txtNumero = new DataDynamics.ActiveReports.TextBox();
            this.txtCliente = new DataDynamics.ActiveReports.TextBox();
            this.txtEstado = new DataDynamics.ActiveReports.TextBox();
            this.txtSubTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalIvas = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.lblTotalVentas = new DataDynamics.ActiveReports.Label();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line1 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalIvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0.02083333F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtIdentificacion,
            this.txtNumero,
            this.txtCliente,
            this.txtEstado,
            this.txtSubTotal,
            this.txtTotal,
            this.txtTotalIvas,
            this.textBox1});
            this.detail.Height = 0.3125F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Border.BottomColor = System.Drawing.Color.Black;
            this.txtIdentificacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIdentificacion.Border.LeftColor = System.Drawing.Color.Black;
            this.txtIdentificacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIdentificacion.Border.RightColor = System.Drawing.Color.Black;
            this.txtIdentificacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIdentificacion.Border.TopColor = System.Drawing.Color.Black;
            this.txtIdentificacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIdentificacion.DataField = "Cod_Cli";
            this.txtIdentificacion.Height = 0.1979167F;
            this.txtIdentificacion.Left = 1.0625F;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Style = "";
            this.txtIdentificacion.Text = null;
            this.txtIdentificacion.Top = 0.0625F;
            this.txtIdentificacion.Width = 1F;
            // 
            // txtNumero
            // 
            this.txtNumero.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumero.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumero.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumero.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumero.DataField = "Consecutivo";
            this.txtNumero.Height = 0.1979167F;
            this.txtNumero.Left = 0F;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Style = "text-align: left; ";
            this.txtNumero.Text = null;
            this.txtNumero.Top = 0.0625F;
            this.txtNumero.Width = 1F;
            // 
            // txtCliente
            // 
            this.txtCliente.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCliente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCliente.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCliente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCliente.Border.RightColor = System.Drawing.Color.Black;
            this.txtCliente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCliente.Border.TopColor = System.Drawing.Color.Black;
            this.txtCliente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCliente.DataField = "Nombre";
            this.txtCliente.Height = 0.1875F;
            this.txtCliente.Left = 2.125F;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Style = "";
            this.txtCliente.Text = null;
            this.txtCliente.Top = 0.0625F;
            this.txtCliente.Width = 1.6875F;
            // 
            // txtEstado
            // 
            this.txtEstado.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEstado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEstado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.Border.RightColor = System.Drawing.Color.Black;
            this.txtEstado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.Border.TopColor = System.Drawing.Color.Black;
            this.txtEstado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.DataField = "Estado";
            this.txtEstado.Height = 0.1875F;
            this.txtEstado.Left = 5.0625F;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Style = "";
            this.txtEstado.Text = null;
            this.txtEstado.Top = 0.0625F;
            this.txtEstado.Width = 1.125F;
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
            this.txtSubTotal.Height = 0.1875F;
            this.txtSubTotal.Left = 6.25F;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Style = "text-align: right; ";
            this.txtSubTotal.Text = null;
            this.txtSubTotal.Top = 0.0625F;
            this.txtSubTotal.Width = 1.625F;
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
            this.txtTotal.Height = 0.1875F;
            this.txtTotal.Left = 9.625F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = null;
            this.txtTotal.Top = 0.0625F;
            this.txtTotal.Width = 1.625F;
            // 
            // txtTotalIvas
            // 
            this.txtTotalIvas.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalIvas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalIvas.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalIvas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalIvas.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalIvas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalIvas.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalIvas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalIvas.DataField = "TotalIva";
            this.txtTotalIvas.Height = 0.1875F;
            this.txtTotalIvas.Left = 7.9375F;
            this.txtTotalIvas.Name = "txtTotalIvas";
            this.txtTotalIvas.Style = "text-align: right; ";
            this.txtTotalIvas.Text = null;
            this.txtTotalIvas.Top = 0.0625F;
            this.txtTotalIvas.Width = 1.625F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "Placa";
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 3.9375F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "";
            this.textBox1.Text = null;
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 1F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblModulo,
            this.Label11,
            this.lblPagina,
            this.lblDe,
            this.lblAno,
            this.txtNumeroPagina,
            this.txtNumeroPaginas});
            this.pageFooter.Height = 0.5F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Height = 0.25F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.lblTotalVentas,
            this.line5,
            this.line1});
            this.groupFooter1.Height = 0.3875F;
            this.groupFooter1.Name = "groupFooter1";
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
            // Label11
            // 
            this.Label11.Border.BottomColor = System.Drawing.Color.Black;
            this.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.LeftColor = System.Drawing.Color.Black;
            this.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.RightColor = System.Drawing.Color.Black;
            this.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.TopColor = System.Drawing.Color.Black;
            this.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 0F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "font-size: 8pt; ";
            this.Label11.Text = "© Copyright           Servipunto Ltda. Todos los Derechos Reservados.";
            this.Label11.Top = 0.1875F;
            this.Label11.Width = 3.5F;
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
            this.lblPagina.Left = 6.218985F;
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
            this.lblDe.Left = 7.127952F;
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
            this.lblAno.Text = "2010";
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
            this.txtNumeroPagina.Left = 6.581193F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; font-size: 8pt; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.183563F;
            this.txtNumeroPagina.Width = 0.530025F;
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
            this.txtNumeroPaginas.Left = 7.294792F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; font-size: 8pt; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.183563F;
            this.txtNumeroPaginas.Width = 0.5792274F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "SubTotal";
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 6.25F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "text-align: right; ";
            this.textBox2.Text = null;
            this.textBox2.Top = 0.125F;
            this.textBox2.Width = 1.625F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "TotalIva";
            this.textBox3.Height = 0.1875F;
            this.textBox3.Left = 8F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "text-align: right; ";
            this.textBox3.Text = null;
            this.textBox3.Top = 0.125F;
            this.textBox3.Width = 1.625F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "Total";
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 9.625F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "text-align: right; ";
            this.textBox4.Text = null;
            this.textBox4.Top = 0.125F;
            this.textBox4.Width = 1.625F;
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTotalVentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVentas.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTotalVentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVentas.Border.RightColor = System.Drawing.Color.Black;
            this.lblTotalVentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVentas.Border.TopColor = System.Drawing.Color.Black;
            this.lblTotalVentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalVentas.Height = 0.2F;
            this.lblTotalVentas.HyperLink = null;
            this.lblTotalVentas.Left = 0F;
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Style = "font-weight: bold; font-size: 11pt; ";
            this.lblTotalVentas.Text = "Total Ventas:";
            this.lblTotalVentas.Top = 0.0625F;
            this.lblTotalVentas.Width = 1.033465F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 6.25F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.03F;
            this.line5.Width = 5F;
            this.line5.X1 = 6.25F;
            this.line5.X2 = 11.25F;
            this.line5.Y1 = 0.03F;
            this.line5.Y2 = 0.03F;
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
            this.line1.Left = 6.25F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.06F;
            this.line1.Width = 5F;
            this.line1.X1 = 6.25F;
            this.line1.X2 = 11.25F;
            this.line1.Y1 = 0.06F;
            this.line1.Y2 = 0.06F;
            // 
            // VentasCanastillaAnuladas
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 11.46875F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalIvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox txtIdentificacion;
        private DataDynamics.ActiveReports.TextBox txtNumero;
        private DataDynamics.ActiveReports.TextBox txtCliente;
        private DataDynamics.ActiveReports.TextBox txtEstado;
        private DataDynamics.ActiveReports.TextBox txtSubTotal;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.TextBox txtTotalIvas;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.Label lblModulo;
        private DataDynamics.ActiveReports.Label Label11;
        private DataDynamics.ActiveReports.Label lblPagina;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.Label lblTotalVentas;
        private DataDynamics.ActiveReports.Line line5;
        private DataDynamics.ActiveReports.Line line1;
    }
}
