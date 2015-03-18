using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;
using DataDynamics.ActiveReports.Export.Xls;

namespace Servipunto.Estacion.Modules.Visor
{
	public class ActiveReportViewer : System.Web.UI.Page
	{		
		#region Controles
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.LinkButton lbtnAdobe;
		protected System.Web.UI.WebControls.LinkButton lbtnHtml;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;

		DataDynamics.ActiveReports.ActiveReport rpt;
		protected DataDynamics.ActiveReports.Export.Xls.XlsExport xlsExport1;
		Visor.Reporte _objReport = new Reporte();

		#endregion

		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{			
			if (Request.QueryString["rpt"] == null)
				this.SetError("Datos Insuficientes!",true);
			else
				EjecutarReporte();		
		
		}
		#endregion
		
		#region Método DecryptText
		/// <summary>
		/// Desencripta el query string 
		/// </summary>
		/// <param name="strText">texto a desencriptar</param>
		/// <returns>texto desencriptado</returns>
		private string DecryptText(string strText)
		{	
			return Servipunto.Libreria.Cryptography.DecryptQueryString(strText, "!#$a54?3");
		}
		#endregion

		#region Ejecutar Reporte
		private void EjecutarReporte()
		{					
				try
				{
					rpt = CargarReporte();
					if (rpt == null)
						return;

					rpt.Document.Printer.PrinterName = "";
					rpt.Run(false);
				}
				catch (DataDynamics.ActiveReports.ReportException eRunReport)
				{
					Response.Clear();	// Failure running report, just report the error to the user:
					this.SetError("Error running report:" + eRunReport.Message,true); //	Response.Write("<h1>Error running report:</h1>");
					return;  //Response.Write(eRunReport.ToString());
				}
				catch (Exception ex)
				{
					Response.Clear();
					this.SetError(ex.Message + "Detalle: (" + ex.StackTrace + ")",true);
					return;
				}

				string formato = Request.QueryString["formato"].Trim().ToUpper();

				switch (formato)
				{
					case "PDF":
						this.ExportarPdf();
					break;
					case "XSL":
						this.ExportarXsl();
					break;
				}

		}
		#endregion

		#region Exportar a Pdf
		private void ExportarPdf()
		{			
			//				// Tell the browser this is a PDF document so it will use an appropriate viewer.
			//				// If the report has been exported in a different format, the content-type will 
			//				// need to be changed as noted in the following table:
			//				//  ExportType  ContentType
			//				//    PDF       "application/pdf"  (needs to be in lowercase)
			//				//    RTF       "application/rtf"
			//				//    TIFF      "image/tiff"       (will open in separate viewer instead of browser)
			//				//    HTML      "message/rfc822"   (only applies to compressed HTML pages that includes images)
			//				//    Excel     "application/vnd.ms-excel"
			//				//    Excel     "application/excel" (either of these types should work. 
			//				//    Text      "text/plain"  
			Response.ContentType = "application/pdf";
			//			
			//				// IE & Acrobat seam to require "content-disposition" header being in the response.  If you don't add it, the doc still works most of the time, but not always.
			//				//this makes a new window appear: Response.AddHeader("content-disposition","attachment; filename=MyPDF.PDF");
			Response.AddHeader("content-disposition","inline; filename=MyPDF.PDF");
			//				// Create the PDF export object
			PdfExport pdf = new PdfExport();
			//				// Create a new memory stream that will hold the pdf output
			System.IO.MemoryStream memStream = new System.IO.MemoryStream();
			//				// Export the report to PDF:
			pdf.Export(rpt.Document , memStream);
			//				// Write the PDF stream out
			Response.BinaryWrite(memStream.ToArray());
			//				// Send all buffered content to the client
			Response.End();		
		}
		#endregion

		#region Exportar a Xsl
		private void ExportarXsl()
		{
			Response.ContentType = "application/x-msexcel";
			Response.AddHeader("content-disposition","attachment; filename=" + Request.QueryString["rpt"].ToString() + ".xls");
			Response.AddHeader("content-disposition","inline; filename=" + Request.QueryString["rpt"].ToString() + ".xls");

			XlsExport xsl = new XlsExport();

			System.IO.MemoryStream memStream = new System.IO.MemoryStream();

			xsl.Export(rpt.Document, memStream);

			Response.BinaryWrite(memStream.ToArray());

			Response.End();
			
		}
		#endregion

		#region Cargar Reporte
		private DataDynamics.ActiveReports.ActiveReport CargarReporte()
		{
			string reporte = Request.QueryString["rpt"].Trim().ToUpper();
			
			switch (reporte)
			{
				case "VENTAS_EMPLEADO":
					return _objReport.VentasPorEmpleadoTurnoIslaManguera(Convert.ToDateTime(Request.QueryString["fechaInicio"]), Convert.ToDateTime(Request.QueryString["fechaFin"]), Convert.ToInt32(Request.QueryString["empleado"]), Convert.ToBoolean(Request.QueryString["todosEmpleados"]),  Convert.ToInt32(Request.QueryString["turno"]), Convert.ToBoolean(Request.QueryString["todosTurnos"]), Convert.ToInt32(Request.QueryString["isla"]), Convert.ToInt32(Request.QueryString["manguera"]), Convert.ToBoolean(Request.QueryString["todasMangueras"]));
				default:
					return null;
			}

		}
		#endregion				
	
		#region Método SetError
		private void SetError(string message, bool hideForm)
		{
			this.lblError.Text = message;
			this.lblError.Visible = true;
			if (hideForm)
				this.MyForm.Visible = false;
		}
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.xlsExport1 = new DataDynamics.ActiveReports.Export.Xls.XlsExport();
			// 
			// xlsExport1
			// 
			this.xlsExport1.Tweak = 0;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		
		
	}
}
