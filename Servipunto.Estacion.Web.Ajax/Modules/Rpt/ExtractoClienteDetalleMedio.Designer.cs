namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ExtractoClienteDetalleMedio.
    /// </summary>
    partial class ExtractoClienteDetalleMedio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractoClienteDetalleMedio));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtUnidades = new DataDynamics.ActiveReports.TextBox();
            this.txtKilometraje = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.lblCopyRight = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            this.ghCliente = new DataDynamics.ActiveReports.GroupHeader();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.lblSenores = new DataDynamics.ActiveReports.Label();
            this.txtSenores = new DataDynamics.ActiveReports.TextBox();
            this.lblIdentificacion = new DataDynamics.ActiveReports.Label();
            this.txtIdentificacion = new DataDynamics.ActiveReports.TextBox();
            this.lblTexto = new DataDynamics.ActiveReports.Label();
            this.lblTexto2 = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.lblUnidades = new DataDynamics.ActiveReports.Label();
            this.lblTotal = new DataDynamics.ActiveReports.Label();
            this.lblKilometraje = new DataDynamics.ActiveReports.Label();
            this.gfCliente = new DataDynamics.ActiveReports.GroupFooter();
            this.txtReclamos = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.ghTotal = new DataDynamics.ActiveReports.GroupHeader();
            this.gfTotal = new DataDynamics.ActiveReports.GroupFooter();
            this.txtTotalPlacaUnidades = new DataDynamics.ActiveReports.TextBox();
            this.TotalPlacaTotal = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKilometraje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSenores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIdentificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTexto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTexto2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKilometraje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReclamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPlacaUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPlacaTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTotal,
            this.txtUnidades,
            this.txtKilometraje});
            this.Detail.Height = 0.2597222F;
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
            this.txtTotal.Left = 4.158466F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat");
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = "Total";
            this.txtTotal.Top = 0.0246063F;
            this.txtTotal.Width = 1.747044F;
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
            this.txtUnidades.DataField = "Consumo";
            this.txtUnidades.Height = 0.2F;
            this.txtUnidades.Left = 2.706693F;
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.OutputFormat = resources.GetString("txtUnidades.OutputFormat");
            this.txtUnidades.Style = "text-align: right; ";
            this.txtUnidades.Text = "Consumo";
            this.txtUnidades.Top = 0.0246063F;
            this.txtUnidades.Width = 1.32874F;
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Border.BottomColor = System.Drawing.Color.Black;
            this.txtKilometraje.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtKilometraje.Border.LeftColor = System.Drawing.Color.Black;
            this.txtKilometraje.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtKilometraje.Border.RightColor = System.Drawing.Color.Black;
            this.txtKilometraje.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtKilometraje.Border.TopColor = System.Drawing.Color.Black;
            this.txtKilometraje.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtKilometraje.DataField = "Placa";
            this.txtKilometraje.Height = 0.2F;
            this.txtKilometraje.Left = 1.648619F;
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Style = "text-align: left; ";
            this.txtKilometraje.Text = "Placa";
            this.txtKilometraje.Top = 0.0246063F;
            this.txtKilometraje.Width = 0.9596487F;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0F;
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
            this.txtNumeroPaginas});
            this.PageFooter.Height = 0.3958333F;
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
            this.lblCopyRight.Left = 0F;
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Style = "font-size: 8pt; ";
            this.lblCopyRight.Text = "© Copyright           Zencillo de Software Ltda. Todos los Derechos Reservados." +
                "";
            this.lblCopyRight.Top = 0.1875F;
            this.lblCopyRight.Width = 4.749016F;
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
            this.lblPagina.Left = 6.194378F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt; ";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.1628937F;
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
            this.lblDe.Left = 7.029528F;
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
            this.lblAno.Left = 0.6250001F;
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
            this.txtNumeroPagina.Left = 6.594489F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.1589567F;
            this.txtNumeroPagina.Width = 0.4296341F;
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
            this.txtNumeroPaginas.Left = 7.209646F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.1589567F;
            this.txtNumeroPaginas.Width = 0.4429135F;
            // 
            // ghCliente
            // 
            this.ghCliente.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.srptEncabezado,
            this.lblSenores,
            this.txtSenores,
            this.lblIdentificacion,
            this.txtIdentificacion,
            this.lblTexto,
            this.lblTexto2,
            this.Line,
            this.Line1,
            this.lblUnidades,
            this.lblTotal,
            this.lblKilometraje});
            this.ghCliente.Height = 2.426389F;
            this.ghCliente.Name = "ghCliente";
            this.ghCliente.Format += new System.EventHandler(this.ghCliente_Format);
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
            this.srptEncabezado.Left = 0.0246063F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezadoExtracto";
            this.srptEncabezado.Top = 0F;
            this.srptEncabezado.Width = 7.627952F;
            // 
            // lblSenores
            // 
            this.lblSenores.Border.BottomColor = System.Drawing.Color.Black;
            this.lblSenores.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSenores.Border.LeftColor = System.Drawing.Color.Black;
            this.lblSenores.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSenores.Border.RightColor = System.Drawing.Color.Black;
            this.lblSenores.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSenores.Border.TopColor = System.Drawing.Color.Black;
            this.lblSenores.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSenores.Height = 0.2F;
            this.lblSenores.HyperLink = null;
            this.lblSenores.Left = 0.0246063F;
            this.lblSenores.Name = "lblSenores";
            this.lblSenores.Style = "";
            this.lblSenores.Text = "Señores:";
            this.lblSenores.Top = 0.6151574F;
            this.lblSenores.Width = 0.6151574F;
            // 
            // txtSenores
            // 
            this.txtSenores.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSenores.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSenores.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSenores.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSenores.Border.RightColor = System.Drawing.Color.Black;
            this.txtSenores.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSenores.Border.TopColor = System.Drawing.Color.Black;
            this.txtSenores.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSenores.DataField = "Cliente";
            this.txtSenores.Height = 0.2F;
            this.txtSenores.Left = 0.02460635F;
            this.txtSenores.Name = "txtSenores";
            this.txtSenores.Style = "";
            this.txtSenores.Text = "Señores XX";
            this.txtSenores.Top = 0.8612201F;
            this.txtSenores.Width = 2.780512F;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.Border.BottomColor = System.Drawing.Color.Black;
            this.lblIdentificacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIdentificacion.Border.LeftColor = System.Drawing.Color.Black;
            this.lblIdentificacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIdentificacion.Border.RightColor = System.Drawing.Color.Black;
            this.lblIdentificacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIdentificacion.Border.TopColor = System.Drawing.Color.Black;
            this.lblIdentificacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblIdentificacion.Height = 0.2F;
            this.lblIdentificacion.HyperLink = null;
            this.lblIdentificacion.Left = 0.0246063F;
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Style = "";
            this.lblIdentificacion.Text = "Identificación:";
            this.lblIdentificacion.Top = 1.107283F;
            this.lblIdentificacion.Width = 0.8858271F;
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
            this.txtIdentificacion.DataField = "CodCliente";
            this.txtIdentificacion.Height = 0.2F;
            this.txtIdentificacion.Left = 0.9350389F;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Style = "";
            this.txtIdentificacion.Text = "Identificación";
            this.txtIdentificacion.Top = 1.107283F;
            this.txtIdentificacion.Width = 2.362205F;
            // 
            // lblTexto
            // 
            this.lblTexto.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTexto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTexto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto.Border.RightColor = System.Drawing.Color.Black;
            this.lblTexto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto.Border.TopColor = System.Drawing.Color.Black;
            this.lblTexto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto.Height = 0.2F;
            this.lblTexto.HyperLink = null;
            this.lblTexto.Left = 0.0246063F;
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Style = "";
            this.lblTexto.Text = "El siguiente documento presenta el estado de cuenta que ustedes tienen en nuestra" +
                " empresa y que comprende el periodo";
            this.lblTexto.Top = 1.525591F;
            this.lblTexto.Width = 7.554132F;
            // 
            // lblTexto2
            // 
            this.lblTexto2.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTexto2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto2.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTexto2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto2.Border.RightColor = System.Drawing.Color.Black;
            this.lblTexto2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto2.Border.TopColor = System.Drawing.Color.Black;
            this.lblTexto2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTexto2.Height = 0.2F;
            this.lblTexto2.HyperLink = null;
            this.lblTexto2.Left = 0.0246063F;
            this.lblTexto2.Name = "lblTexto2";
            this.lblTexto2.Style = "";
            this.lblTexto2.Text = "";
            this.lblTexto2.Top = 1.747047F;
            this.lblTexto2.Width = 7.554132F;
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
            this.Line.Left = 1.52559F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 2.165353F;
            this.Line.Width = 4.502953F;
            this.Line.X1 = 1.52559F;
            this.Line.X2 = 6.028543F;
            this.Line.Y1 = 2.165353F;
            this.Line.Y2 = 2.165353F;
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
            this.Line1.Left = 1.52559F;
            this.Line1.LineWeight = 2F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 2.411416F;
            this.Line1.Width = 4.502953F;
            this.Line1.X1 = 1.52559F;
            this.Line1.X2 = 6.028543F;
            this.Line1.Y1 = 2.411416F;
            this.Line1.Y2 = 2.411416F;
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
            this.lblUnidades.Left = 2.68F;
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Style = "text-align: right; ";
            this.lblUnidades.Text = "Consumo";
            this.lblUnidades.Top = 2.2F;
            this.lblUnidades.Width = 1.32874F;
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
            this.lblTotal.Left = 4.109255F;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Style = "text-align: right; ";
            this.lblTotal.Text = "Total";
            this.lblTotal.Top = 2.189962F;
            this.lblTotal.Width = 1.820866F;
            // 
            // lblKilometraje
            // 
            this.lblKilometraje.Border.BottomColor = System.Drawing.Color.Black;
            this.lblKilometraje.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKilometraje.Border.LeftColor = System.Drawing.Color.Black;
            this.lblKilometraje.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKilometraje.Border.RightColor = System.Drawing.Color.Black;
            this.lblKilometraje.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKilometraje.Border.TopColor = System.Drawing.Color.Black;
            this.lblKilometraje.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKilometraje.Height = 0.2F;
            this.lblKilometraje.HyperLink = null;
            this.lblKilometraje.Left = 1.648621F;
            this.lblKilometraje.Name = "lblKilometraje";
            this.lblKilometraje.Style = "text-align: left; ";
            this.lblKilometraje.Text = "Placa";
            this.lblKilometraje.Top = 2.189962F;
            this.lblKilometraje.Width = 0.9350396F;
            // 
            // gfCliente
            // 
            this.gfCliente.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtReclamos,
            this.Label2,
            this.Label3,
            this.Line2,
            this.Line3});
            this.gfCliente.Height = 1.4375F;
            this.gfCliente.Name = "gfCliente";
            // 
            // txtReclamos
            // 
            this.txtReclamos.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReclamos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReclamos.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReclamos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReclamos.Border.RightColor = System.Drawing.Color.Black;
            this.txtReclamos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReclamos.Border.TopColor = System.Drawing.Color.Black;
            this.txtReclamos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReclamos.Height = 0.2F;
            this.txtReclamos.HyperLink = null;
            this.txtReclamos.Left = 0F;
            this.txtReclamos.Name = "txtReclamos";
            this.txtReclamos.Style = "";
            this.txtReclamos.Text = "En caso de cualquier duda, por favor acerquese a nuestra oficina donde con gusto " +
                "lo atenderemos.";
            this.txtReclamos.Top = 0.0246063F;
            this.txtReclamos.Width = 7.603347F;
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
            this.Label2.Left = 1.968504F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "";
            this.Label2.Text = "Jefe de Cartera";
            this.Label2.Top = 1.205708F;
            this.Label2.Width = 1F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 4.699803F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "";
            this.Label3.Text = "Recibido por";
            this.Label3.Top = 1.205708F;
            this.Label3.Width = 1F;
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
            this.Line2.Left = 1.550197F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.181102F;
            this.Line2.Width = 1.820867F;
            this.Line2.X1 = 1.550197F;
            this.Line2.X2 = 3.371064F;
            this.Line2.Y1 = 1.181102F;
            this.Line2.Y2 = 1.181102F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0F;
            this.Line3.Left = 4.207679F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.169783F;
            this.Line3.Width = 1.820862F;
            this.Line3.X1 = 4.207679F;
            this.Line3.X2 = 6.028541F;
            this.Line3.Y1 = 1.169783F;
            this.Line3.Y2 = 1.169783F;
            // 
            // ghTotal
            // 
            this.ghTotal.Height = 0F;
            this.ghTotal.Name = "ghTotal";
            // 
            // gfTotal
            // 
            this.gfTotal.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTotalPlacaUnidades,
            this.TotalPlacaTotal,
            this.Label1});
            this.gfTotal.Height = 0.4159722F;
            this.gfTotal.Name = "gfTotal";
            // 
            // txtTotalPlacaUnidades
            // 
            this.txtTotalPlacaUnidades.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalPlacaUnidades.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPlacaUnidades.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalPlacaUnidades.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPlacaUnidades.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalPlacaUnidades.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalPlacaUnidades.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalPlacaUnidades.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.txtTotalPlacaUnidades.DataField = "Consumo";
            this.txtTotalPlacaUnidades.Height = 0.2F;
            this.txtTotalPlacaUnidades.Left = 2.706693F;
            this.txtTotalPlacaUnidades.Name = "txtTotalPlacaUnidades";
            this.txtTotalPlacaUnidades.OutputFormat = resources.GetString("txtTotalPlacaUnidades.OutputFormat");
            this.txtTotalPlacaUnidades.Style = "text-align: right; ";
            this.txtTotalPlacaUnidades.SummaryGroup = "ghTotal";
            this.txtTotalPlacaUnidades.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtTotalPlacaUnidades.Text = "Consumo";
            this.txtTotalPlacaUnidades.Top = 0.0246063F;
            this.txtTotalPlacaUnidades.Width = 1.32874F;
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
            this.TotalPlacaTotal.Left = 4.13386F;
            this.TotalPlacaTotal.Name = "TotalPlacaTotal";
            this.TotalPlacaTotal.OutputFormat = resources.GetString("TotalPlacaTotal.OutputFormat");
            this.TotalPlacaTotal.Style = "text-align: right; ";
            this.TotalPlacaTotal.SummaryGroup = "ghTotal";
            this.TotalPlacaTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TotalPlacaTotal.Text = "Total";
            this.TotalPlacaTotal.Top = 0.0246063F;
            this.TotalPlacaTotal.Width = 1.796255F;
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
            this.Label1.Left = 0.0246063F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-weight: bold; font-size: 10pt; ";
            this.Label1.Text = "Total:";
            this.Label1.Top = 0.0246063F;
            this.Label1.Width = 1.894685F;
            // 
            // ExtractoClienteDetalleMedio
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.39375F;
            this.PageSettings.Margins.Left = 0.39375F;
            this.PageSettings.Margins.Right = 0.39375F;
            this.PageSettings.Margins.Top = 0.39375F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.6875F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ghCliente);
            this.Sections.Add(this.ghTotal);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.gfTotal);
            this.Sections.Add(this.gfCliente);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKilometraje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSenores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIdentificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTexto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTexto2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKilometraje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReclamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPlacaUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPlacaTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.TextBox txtUnidades;
        private DataDynamics.ActiveReports.TextBox txtKilometraje;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.Label lblModulo;
        private DataDynamics.ActiveReports.Label lblCopyRight;
        private DataDynamics.ActiveReports.Label lblPagina;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.GroupHeader ghCliente;
        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label lblSenores;
        private DataDynamics.ActiveReports.TextBox txtSenores;
        private DataDynamics.ActiveReports.Label lblIdentificacion;
        private DataDynamics.ActiveReports.TextBox txtIdentificacion;
        private DataDynamics.ActiveReports.Label lblTexto;
        private DataDynamics.ActiveReports.Label lblTexto2;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label lblUnidades;
        private DataDynamics.ActiveReports.Label lblTotal;
        private DataDynamics.ActiveReports.Label lblKilometraje;
        private DataDynamics.ActiveReports.GroupFooter gfCliente;
        private DataDynamics.ActiveReports.Label txtReclamos;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.Line Line3;
        private DataDynamics.ActiveReports.GroupHeader ghTotal;
        private DataDynamics.ActiveReports.GroupFooter gfTotal;
        private DataDynamics.ActiveReports.TextBox txtTotalPlacaUnidades;
        private DataDynamics.ActiveReports.TextBox TotalPlacaTotal;
        private DataDynamics.ActiveReports.Label Label1;
    }
}
