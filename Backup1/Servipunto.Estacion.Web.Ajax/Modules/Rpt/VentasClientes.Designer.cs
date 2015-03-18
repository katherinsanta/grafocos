namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasClientes.
    /// </summary>
    partial class VentasClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasClientes));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.ghTotal = new DataDynamics.ActiveReports.GroupHeader();
            this.gfTotal = new DataDynamics.ActiveReports.GroupFooter();
            this.ghFecha = new DataDynamics.ActiveReports.GroupHeader();
            this.gfFecha = new DataDynamics.ActiveReports.GroupFooter();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.lblTitulo = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            this.lblCodigo = new DataDynamics.ActiveReports.Label();
            this.lblCliente = new DataDynamics.ActiveReports.Label();
            this.lblTotal = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.lblTurno = new DataDynamics.ActiveReports.Label();
            this.lblFechaVenta = new DataDynamics.ActiveReports.Label();
            this.txtFechaVenta = new DataDynamics.ActiveReports.TextBox();
            this.txtCodigo = new DataDynamics.ActiveReports.TextBox();
            this.txtCliente = new DataDynamics.ActiveReports.TextBox();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtTurno = new DataDynamics.ActiveReports.TextBox();
            this.lblTotalFecha = new DataDynamics.ActiveReports.Label();
            this.txtTotalFecha = new DataDynamics.ActiveReports.TextBox();
            this.txtgranTotalTotal = new DataDynamics.ActiveReports.TextBox();
            this.lblTotalVenta = new DataDynamics.ActiveReports.Label();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.lblCopyRight = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyRight)).BeginInit();
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
            this.txtCodigo,
            this.txtCliente,
            this.txtTotal,
            this.txtTurno});
            this.Detail.Height = 0.3222222F;
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
            this.lblCodigo,
            this.lblCliente,
            this.lblTotal,
            this.Line1,
            this.Line,
            this.lblTurno});
            this.PageHeader.Height = 1.677083F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblModulo,
            this.lblCopyRight,
            this.lblPagina,
            this.lblDe,
            this.lblAno,
            this.txtNumeroPagina,
            this.txtNumeroPaginas,
            this.Line2});
            this.PageFooter.Height = 0.4159722F;
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
            this.txtgranTotalTotal,
            this.lblTotalVenta});
            this.gfTotal.Height = 0.40625F;
            this.gfTotal.Name = "gfTotal";
            // 
            // ghFecha
            // 
            this.ghFecha.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblFechaVenta,
            this.txtFechaVenta});
            this.ghFecha.DataField = "Fecha";
            this.ghFecha.Height = 0.2597222F;
            this.ghFecha.Name = "ghFecha";
            // 
            // gfFecha
            // 
            this.gfFecha.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTotalFecha,
            this.txtTotalFecha});
            this.gfFecha.Height = 0.25F;
            this.gfFecha.Name = "gfFecha";
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
            this.srptEncabezado.Left = 0.2952756F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0.0492126F;
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
            this.lblFecha.Left = 5.536416F;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Style = "white-space: inherit; ";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Top = 0.66437F;
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
            this.lblHora.Left = 5.536416F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora:";
            this.lblHora.Top = 0.9022639F;
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
            this.lblTitulo.Left = 0.66437F;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTitulo.Text = "Reporte de ventas por Cliente";
            this.lblTitulo.Top = 0.8366139F;
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
            this.lblTituloFechas.Left = 0.6397638F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTituloFechas.Text = "Titulo con las fechas";
            this.lblTituloFechas.Top = 1.082677F;
            this.lblTituloFechas.Width = 4.72441F;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCodigo.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCodigo.Border.RightColor = System.Drawing.Color.Black;
            this.lblCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCodigo.Border.TopColor = System.Drawing.Color.Black;
            this.lblCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCodigo.Height = 0.2F;
            this.lblCodigo.HyperLink = null;
            this.lblCodigo.Left = 0.09842521F;
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Style = "text-align: center; font-weight: bold; ";
            this.lblCodigo.Text = "Codigo";
            this.lblCodigo.Top = 1.377953F;
            this.lblCodigo.Width = 1.353346F;
            // 
            // lblCliente
            // 
            this.lblCliente.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCliente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCliente.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCliente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCliente.Border.RightColor = System.Drawing.Color.Black;
            this.lblCliente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCliente.Border.TopColor = System.Drawing.Color.Black;
            this.lblCliente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCliente.Height = 0.2F;
            this.lblCliente.HyperLink = null;
            this.lblCliente.Left = 2.46063F;
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Style = "text-align: right; font-weight: bold; ";
            this.lblCliente.Text = "Cliente";
            this.lblCliente.Top = 1.389274F;
            this.lblCliente.Width = 2.411417F;
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
            this.lblTotal.Left = 4.921259F;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Style = "text-align: right; font-weight: bold; ";
            this.lblTotal.Text = "Total";
            this.lblTotal.Top = 1.389273F;
            this.lblTotal.Width = 1.845472F;
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
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.353346F;
            this.Line1.Width = 6.815945F;
            this.Line1.X1 = 0.0246063F;
            this.Line1.X2 = 6.840551F;
            this.Line1.Y1 = 1.353346F;
            this.Line1.Y2 = 1.353346F;
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
            this.Line.Left = 0.0246063F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 1.612697F;
            this.Line.Width = 6.815945F;
            this.Line.X1 = 0.0246063F;
            this.Line.X2 = 6.840551F;
            this.Line.Y1 = 1.612697F;
            this.Line.Y2 = 1.612697F;
            // 
            // lblTurno
            // 
            this.lblTurno.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTurno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTurno.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTurno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTurno.Border.RightColor = System.Drawing.Color.Black;
            this.lblTurno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTurno.Border.TopColor = System.Drawing.Color.Black;
            this.lblTurno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTurno.Height = 0.2F;
            this.lblTurno.HyperLink = null;
            this.lblTurno.Left = 1.52559F;
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Style = "text-align: center; font-weight: bold; ";
            this.lblTurno.Text = "Turno";
            this.lblTurno.Top = 1.377953F;
            this.lblTurno.Width = 0.8612201F;
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFechaVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaVenta.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFechaVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaVenta.Border.RightColor = System.Drawing.Color.Black;
            this.lblFechaVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaVenta.Border.TopColor = System.Drawing.Color.Black;
            this.lblFechaVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFechaVenta.Height = 0.2F;
            this.lblFechaVenta.HyperLink = null;
            this.lblFechaVenta.Left = 0F;
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Style = "font-weight: bold; ";
            this.lblFechaVenta.Text = "Fecha:";
            this.lblFechaVenta.Top = 0F;
            this.lblFechaVenta.Width = 0.492126F;
            // 
            // txtFechaVenta
            // 
            this.txtFechaVenta.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFechaVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechaVenta.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFechaVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechaVenta.Border.RightColor = System.Drawing.Color.Black;
            this.txtFechaVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechaVenta.Border.TopColor = System.Drawing.Color.Black;
            this.txtFechaVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFechaVenta.DataField = "Fecha";
            this.txtFechaVenta.Height = 0.2F;
            this.txtFechaVenta.Left = 0.5167323F;
            this.txtFechaVenta.Name = "txtFechaVenta";
            this.txtFechaVenta.OutputFormat = resources.GetString("txtFechaVenta.OutputFormat");
            this.txtFechaVenta.Style = "font-weight: bold; ";
            this.txtFechaVenta.Text = "Fecha";
            this.txtFechaVenta.Top = 0F;
            this.txtFechaVenta.Width = 1F;
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
            this.txtCodigo.DataField = "Codigo";
            this.txtCodigo.Height = 0.2F;
            this.txtCodigo.Left = 0.125F;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Style = "text-align: center; ";
            this.txtCodigo.Text = "Codigo";
            this.txtCodigo.Top = 0F;
            this.txtCodigo.Width = 1.353346F;
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
            this.txtCliente.DataField = "Cliente";
            this.txtCliente.Height = 0.2F;
            this.txtCliente.Left = 2.436024F;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Style = "text-align: right; ";
            this.txtCliente.Text = "Cliente";
            this.txtCliente.Top = 0F;
            this.txtCliente.Width = 2.460629F;
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
            this.txtTotal.Left = 4.9375F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat");
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = "Total";
            this.txtTotal.Top = 0F;
            this.txtTotal.Width = 1.845473F;
            // 
            // txtTurno
            // 
            this.txtTurno.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTurno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTurno.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTurno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTurno.Border.RightColor = System.Drawing.Color.Black;
            this.txtTurno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTurno.Border.TopColor = System.Drawing.Color.Black;
            this.txtTurno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTurno.DataField = "Turno";
            this.txtTurno.Height = 0.2F;
            this.txtTurno.Left = 1.550197F;
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Style = "text-align: center; ";
            this.txtTurno.Text = "Turno";
            this.txtTurno.Top = 2.04891E-08F;
            this.txtTurno.Width = 0.8120077F;
            // 
            // lblTotalFecha
            // 
            this.lblTotalFecha.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTotalFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalFecha.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTotalFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalFecha.Border.RightColor = System.Drawing.Color.Black;
            this.lblTotalFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalFecha.Border.TopColor = System.Drawing.Color.Black;
            this.lblTotalFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotalFecha.Height = 0.2F;
            this.lblTotalFecha.HyperLink = null;
            this.lblTotalFecha.Left = 3.764766F;
            this.lblTotalFecha.Name = "lblTotalFecha";
            this.lblTotalFecha.Style = "text-decoration: none; font-weight: bold; ";
            this.lblTotalFecha.Text = "Total por Fecha:";
            this.lblTotalFecha.Top = 0.0246063F;
            this.lblTotalFecha.Width = 1.181103F;
            // 
            // txtTotalFecha
            // 
            this.txtTotalFecha.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalFecha.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalFecha.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalFecha.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.txtTotalFecha.DataField = "Total";
            this.txtTotalFecha.Height = 0.2F;
            this.txtTotalFecha.Left = 5.019686F;
            this.txtTotalFecha.Name = "txtTotalFecha";
            this.txtTotalFecha.OutputFormat = resources.GetString("txtTotalFecha.OutputFormat");
            this.txtTotalFecha.Style = "text-align: right; ";
            this.txtTotalFecha.SummaryGroup = "ghFecha";
            this.txtTotalFecha.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtTotalFecha.Text = "Total";
            this.txtTotalFecha.Top = 0.0246063F;
            this.txtTotalFecha.Width = 1.796256F;
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
            this.txtgranTotalTotal.Left = 5.044291F;
            this.txtgranTotalTotal.Name = "txtgranTotalTotal";
            this.txtgranTotalTotal.OutputFormat = resources.GetString("txtgranTotalTotal.OutputFormat");
            this.txtgranTotalTotal.Style = "text-align: right; ";
            this.txtgranTotalTotal.SummaryGroup = "ghTotal";
            this.txtgranTotalTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtgranTotalTotal.Text = "Total";
            this.txtgranTotalTotal.Top = 0.1476378F;
            this.txtgranTotalTotal.Width = 1.747047F;
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
            this.lblTotalVenta.Left = 3.912403F;
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Style = "font-weight: bold; font-size: 12pt; ";
            this.lblTotalVenta.Text = "Total Venta:";
            this.lblTotalVenta.Top = 0.1476378F;
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
            this.lblModulo.Left = 0.0378937F;
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Style = "font-weight: bold; ";
            this.lblModulo.Text = "Servipunto Módulo de Estación";
            this.lblModulo.Top = 0F;
            this.lblModulo.Width = 2.125F;
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCopyRight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCopyRight.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCopyRight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCopyRight.Border.RightColor = System.Drawing.Color.Black;
            this.lblCopyRight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCopyRight.Border.TopColor = System.Drawing.Color.Black;
            this.lblCopyRight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCopyRight.Height = 0.2F;
            this.lblCopyRight.HyperLink = null;
            this.lblCopyRight.Left = 0.0378937F;
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Style = "font-size: 8pt; ";
            this.lblCopyRight.Text = "© Copyright           Zencillo de Software Ltda. Todos los Derechos Reservados." +
                "";
            this.lblCopyRight.Top = 0.1875F;
            this.lblCopyRight.Width = 4.194389F;
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
            this.lblPagina.Left = 5.216537F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt; ";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.1722441F;
            this.lblPagina.Width = 0.3937005F;
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
            this.lblDe.Left = 6.132385F;
            this.lblDe.Name = "lblDe";
            this.lblDe.Style = "font-size: 8pt; ";
            this.lblDe.Text = "de";
            this.lblDe.Top = 0.1628937F;
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
            this.lblAno.Left = 0.6628938F;
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
            this.txtNumeroPagina.Left = 5.610237F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.1589567F;
            this.txtNumeroPagina.Width = 0.5167418F;
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
            this.txtNumeroPaginas.Left = 6.299212F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.1589567F;
            this.txtNumeroPaginas.Width = 0.5167565F;
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
            this.Line2.Top = 0.0113189F;
            this.Line2.Width = 13.13976F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 13.13976F;
            this.Line2.Y1 = 0.0113189F;
            this.Line2.Y2 = 0.0113189F;
            // 
            // VentasClientes
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.1965278F;
            this.PageSettings.Margins.Left = 0.1965278F;
            this.PageSettings.Margins.Right = 0.1965278F;
            this.PageSettings.Margins.Top = 0.1965278F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.885417F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ghTotal);
            this.Sections.Add(this.ghFecha);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.gfFecha);
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
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgranTotalTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);

        }
        #endregion

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox txtCodigo;
        private DataDynamics.ActiveReports.TextBox txtCliente;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.TextBox txtTurno;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Label lblTitulo;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
        private DataDynamics.ActiveReports.Label lblCodigo;
        private DataDynamics.ActiveReports.Label lblCliente;
        private DataDynamics.ActiveReports.Label lblTotal;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.Label lblTurno;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.Label lblModulo;
        private DataDynamics.ActiveReports.Label lblCopyRight;
        private DataDynamics.ActiveReports.Label lblPagina;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.GroupHeader ghTotal;
        private DataDynamics.ActiveReports.GroupFooter gfTotal;
        private DataDynamics.ActiveReports.TextBox txtgranTotalTotal;
        private DataDynamics.ActiveReports.Label lblTotalVenta;
        private DataDynamics.ActiveReports.GroupHeader ghFecha;
        private DataDynamics.ActiveReports.Label lblFechaVenta;
        private DataDynamics.ActiveReports.TextBox txtFechaVenta;
        private DataDynamics.ActiveReports.GroupFooter gfFecha;
        private DataDynamics.ActiveReports.Label lblTotalFecha;
        private DataDynamics.ActiveReports.TextBox txtTotalFecha;
    }
}
