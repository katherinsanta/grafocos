<%@ Page language="c#" Codebehind="ActiveReportViewer.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Modules.Visor.ActiveReportViewer" %>
<%@ Register TagPrefix="MyUserControls" TagName="TopicHeader" Src="../../BlueSkin/UserControls/TopicHeader.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Footer" Src="../../BlueSkin/UserControls/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Visor Web - Servipunto de Fidelización</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../BlueSkin/NS.css" type="text/css" rel="stylesheet">
		<script src="../../BlueSkin/NS.js" type="text/javascript"></script>
		<script src="../../BlueSkin/NSWebBuilder.js" type="text/javascript"></script>
		<script src="../../BlueSkin/NavigationPanels.js" type="text/javascript"></script>
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0">
		<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<!-- Page Body -->
			<TBODY>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<tr>
									<!-- Topic Body -->
									<td vAlign="top" width="100%"><MYUSERCONTROLS:TOPICHEADER id="TopicHeader1" title="Visor Web" runat="server" Image="Reportes-48.png" ShortDescription="Visor Web para la vista previa de reportes"></MYUSERCONTROLS:TOPICHEADER>
										<!-- Topic Content -->
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<tr>
													<td style="PADDING-RIGHT: 30px; PADDING-LEFT: 40px">
														<!-- Custom Content -->
														<p><asp:label id="lblError" runat="server" ForeColor="Red" Visible="False"></asp:label></p>
														<form id="MyForm" action="ActiveReportViewer.aspx" method="post" runat="server">
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																</tr>
																<tr>
																	<td><br>
																		<font color="gray">&nbsp;&nbsp;&nbsp;&nbsp; * Para&nbsp;exportar&nbsp;el 
																			reporte&nbsp;a Adobe Reader, necesita tener instalada esta herramienta. 
																			Para&nbsp;instalarla gratis&nbsp;haga clic en&nbsp;este link&nbsp; <a style="COLOR: blue" href="http://www.latinamerica.adobe.com/products/acrobat/readstep2.html"
																				target="_blank">Descargar Adobe Reader.</a> </font>
																	</td>
																</tr>
																<tr>
																	<td style="HEIGHT: 38px" vAlign="top"><br>
																		<font color="gray">&nbsp;&nbsp;&nbsp;&nbsp; * Para exportar el reporte haga clic en 
																			alguna de las siguientes opciones:</font>&nbsp; [
																		<asp:linkbutton id="lbtnAdobe" runat="server">Adobe Acrobat</asp:linkbutton>&nbsp;|
																		<asp:linkbutton id="lbtnHtml" runat="server">HTML</asp:linkbutton>&nbsp;]
																	</td>
																</tr>
																<tr>
																</tr>
															</table>
														</form>
													</td>
												</tr>
											</TBODY>
										</table>
										<!-- End Topic Content --> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</td>
									<!-- End Topic Body --></tr>
							</TBODY>
						</table>
					</td>
				</tr>
				<!-- End Page Body --><MYUSERCONTROLS:FOOTER id="Footer1" runat="server"></MYUSERCONTROLS:FOOTER></TBODY></table>
		</TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
