<%@ Page language="c#" Codebehind="PruebaReporte.aspx.cs" AutoEventWireup="false"
 Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.PruebaReporte" %>
<%@ Register TagPrefix="MyUserControls" TagName="Footer" Src="../../BlueSkin/UserControls/Footer.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Header" Src="../../BlueSkin/UserControls/Header.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="TopicHeader" Src="../../BlueSkin/UserControls/TopicHeader.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="NavigationPane" Src="../../BlueSkin/UserControls/NavigationPane.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Reporte de Ventas por Empleado</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../BlueSkin/NS.css" type="text/css" rel="stylesheet">
		<script src="../../BlueSkin/NS.js" type="text/javascript"></script>
		<script src="../../BlueSkin/NSWebBuilder.js" type="text/javascript"></script>
		<script src="../../BlueSkin/NavigationPanels.js" type="text/javascript"></script>
		<script src="../../BlueSkin/Reportes.js" type="text/javascript"></script>
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0">
		<br>
		<blockquote><font class="NormalFont">
				<p><asp:label id="lblError" runat="server" ForeColor="Red" Visible="false"></asp:label></p>
			</font></blockquote>
		<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<MYUSERCONTROLS:HEADER id="Header1" runat="server"></MYUSERCONTROLS:HEADER>
			<!-- Page Body -->
			<tr>
				<td vAlign="top" height="100%">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<MYUSERCONTROLS:NAVIGATIONPANE id="NavigationPane1" runat="server" GroupID="PanelControl"></MYUSERCONTROLS:NAVIGATIONPANE>
							<!-- Topic Body -->
							<td vAlign="top" width="100%"><MYUSERCONTROLS:TOPICHEADER id="TopicHeader1" title="Dosificación de Facturas" runat="server" Image="BolNumOrdenes-48.png"
									ShortDescription="Creación de Dosificación de Facturas"></MYUSERCONTROLS:TOPICHEADER>
								<!-- Topic Content -->
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td style="PADDING-RIGHT: 30px; PADDING-LEFT: 40px"><br>
											<p><asp:label id="Label1" runat="server" ForeColor="Red" Visible="False"></asp:label></p>
											<form id="MyForm" action="FiltroGenericoVentas.aspx" method="post" runat="server">
												<table cellSpacing="1" cellPadding="5" width="90%" align="center" bgColor="#5482fc" border="0">
													<tr>
														<td bgColor="#eeeeee"><asp:label id="lblReporte" runat="server">Titulo del Reporte</asp:label></td>
													</tr>
													<tr>
														<td bgColor="#fefbff">
															<!-- Developer Custom Code -->
															<table cellSpacing="1" cellPadding="5" width="100%" border="0">
																<tr>
																	<td style="WIDTH: 19%; HEIGHT: 15px" vAlign="top">Empleado:</td>
																	<td style="WIDTH: 25%; HEIGHT: 15px">
																		<asp:textbox id="txtEmpleado" runat="server" Width="168px"></asp:textbox>
																	<TD style="WIDTH: 5%"><A onclick="Evaluar_check('SubFiltroCodigoEmpleado.aspx','cbTodosEmpleados','txtEmpleado')"
																			href="#"><U><IMG height="18" src="../../BlueSkin/Icons/Busqueda-16.gif" width="18" border="0"></U></A></TD>
																	<td style="WIDTH: 15%"><asp:checkbox id="cbTodosEmpleados" runat="server" AutoPostBack="True" Text="Todos" Width="46"
																			Checked="True"></asp:checkbox></td>
																	<td style="WIDTH: 36%">Tipo de Reporte:
																		<asp:radiobuttonlist id="TipoReporte" runat="server" RepeatDirection="Horizontal" Width="88px">
																			<asp:ListItem Value="Detallado">Detallado</asp:ListItem>
																			<asp:ListItem Value="Resumido" Selected="True">Resumido</asp:ListItem>
																		</asp:radiobuttonlist></td>
																<tr>
																	<TD style="WIDTH: 19%; HEIGHT: 33px" vAlign="top">Turno:</TD>
																	<TD style="WIDTH: 25%; HEIGHT: 33px"><asp:textbox id="txtTurno" runat="server" Width="168px"></asp:textbox></TD>
																	<TD style="WIDTH: 5%; HEIGHT: 33px" vAlign="top"></TD>
																	<TD style="WIDTH: 15%; HEIGHT: 33px" vAlign="top"><asp:checkbox id="cbTodosTurnos" runat="server" AutoPostBack="True" Text="Todos" Width="48px"
																			Checked="True"></asp:checkbox></TD>
																	<TD style="WIDTH: 36%; HEIGHT: 33px" vAlign="top"></TD>
																</tr>
																<tr>
																	<TD style="WIDTH: 19%; HEIGHT: 33px" vAlign="top">Isla:</TD>
																	<TD style="WIDTH: 25%; HEIGHT: 33px"><asp:dropdownlist id="cboIsla" runat="server" Width="168px"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 5%; HEIGHT: 33px" vAlign="top"></TD>
																	<TD style="WIDTH: 15%; HEIGHT: 33px" vAlign="top"></TD>
																	<TD style="WIDTH: 36%; HEIGHT: 33px" vAlign="top"></TD>
																</tr>
																<tr>
																	<TD style="WIDTH: 19%; HEIGHT: 33px" vAlign="top">Manguera:</TD>
																	<TD style="WIDTH: 25%; HEIGHT: 33px"><asp:textbox id="txtManguera" runat="server" Width="168px"></asp:textbox></TD>
																	<TD style="WIDTH: 5%; HEIGHT: 33px" vAlign="top"></TD>
																	<TD style="WIDTH: 15%; HEIGHT: 33px" vAlign="top"><asp:checkbox id="cbTodasManguera" runat="server" AutoPostBack="True" Text="Todas" Width="49px"
																			Checked="True"></asp:checkbox></TD>
																	<TD style="WIDTH: 36%; HEIGHT: 33px" vAlign="top"></TD>
																</tr>
																<tr>
																	<td style="WIDTH: 19%" vAlign="top">Fecha Inicial:</td>
																	<td style="WIDTH: 25%"><asp:calendar id="FechaInicio" runat="server"></asp:calendar></td>
																	<TD style="WIDTH: 5%" vAlign="top"></TD>
																	<td style="WIDTH: 15%" vAlign="top">Fecha&nbsp;Final:</td>
																	<td style="WIDTH: 36%" vAlign="top"><asp:calendar id="FechaFin" runat="server" Width="120px"></asp:calendar></td>
																</tr>
															</table> <!-- End Developer Custom Code --><BR>
															<BR>
															<TABLE cellSpacing="0" cellPadding="5" width="100%" border="0">
																<TR>
																	<TD>
																		<DIV align="right">
																			<asp:LinkButton id="LinkButton1" runat="server">Generar</asp:LinkButton>&nbsp;|
																			<A  href="javascript:MaximizeWindow();document.forms[0].submit();">Generar 
																				Reporte</A> | 
																				<A  href="javascript:window.close();">Cerrar</A>
																		</DIV>
																	</TD>
																</TR>
															</TABLE>
														</td>
													</tr>
												</table>
											</form>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
