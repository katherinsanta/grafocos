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
	public class PDF : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;

		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["LastReport"] == null)
				this.SetError("Reporte no Disponible!");
			else
				GenerarReporte(Session["Formato"]);				
		}
		#endregion
		
		#region GenerarPDF
		private void GenerarReporte(Object formato)
		{
			DataDynamics.ActiveReports.ActiveReport rpt;

			try
			{
				rpt = (DataDynamics.ActiveReports.ActiveReport)Session["LastReport"];
				if (rpt == null)
					return;
				rpt.Document.Printer.PrinterName = "";
				rpt.Run(false);
			}
			catch (DataDynamics.ActiveReports.ReportException eRunReport)
			{
				Response.Clear();
				this.SetError("Error running report:" + eRunReport.Message);
				return;
			}
			catch (Exception ex)
			{
				Response.Clear();
				this.SetError(ex.Message);
				return;
			}
			finally
			{
				Session["LastReport"] = null;
			}

			System.IO.MemoryStream memStream = new System.IO.MemoryStream();

			if(formato == null || formato.ToString() == "pdf")
			{
				Response.ContentType = "application/pdf";
				Response.AddHeader("content-disposition","inline; filename=Reporte.PDF");
                Response.Charset = "Unicode";
				PdfExport pdf = new PdfExport();
				pdf.Export(rpt.Document , memStream);
			}
			else
			{
				Response.ContentType = "application/x-msexcel";
				Response.AddHeader("content-disposition","inline; filename=Reporte.xls");
				XlsExport xls = new XlsExport();
				xls.Export(rpt.Document , memStream);
			}

			Session["Formato"] = null;

			Response.BinaryWrite(memStream.ToArray());

			// Write the file stream out
			Response.BinaryWrite(memStream.ToArray());
			// Send all buffered content to the client
			Response.End();
		}
		#endregion

		#region SetError
		private void SetError(string message)
		{
			this.lblError.Visible = true;
			this.lblError.Text = message;
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

		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		
		
	}
}
