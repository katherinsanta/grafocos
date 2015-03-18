<%@ Page language="c#" Codebehind="ModificarNITVentas.aspx.cs" AutoEventWireup="false"
 Inherits="Servipunto.Estacion.Reportes.ModificarNITVentas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Filtro Cliente</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
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
		<form id="MyForm" action="ModificarNITVentas.aspx" method="post" runat="server">
			<table cellSpacing="1" cellPadding="5" width="90%" align="center" bgColor="#5482fc" border="0">
				<tr>
					<td bgColor="#eeeeee"><asp:label id="lblReporte" runat="server">Ventas Sin NIT</asp:label></td>
				</tr>
				<tr>
					<td bgColor="#fefbff">
						<!-- Developer Custom Code -->
						<table cellSpacing="1" cellPadding="5" width="100%" border="0">
							<tr>
								<td style="WIDTH: 11.84%; HEIGHT: 15px" vAlign="top"><asp:Label ID="lblNewNIT" runat="server">
								Nuevo NIT:
								</asp:Label></td>
								<td style="WIDTH: 80%; HEIGHT: 15px" vAlign="top"><asp:textbox id="txtNuevoNIT" runat="server"></asp:textbox><asp:linkbutton id="lbResultado" runat="server">Modificar...</asp:linkbutton></td>
								<TD style="WIDTH: 80%; HEIGHT: 15px" vAlign="top"><asp:Label ID="lblPrefijo" runat="server">
								Prefijo:
								</asp:Label></td>
								<TD style="WIDTH: 75.05%; HEIGHT: 15px" vAlign="top"><asp:textbox id="txtPrefijo" runat="server"></asp:textbox></TD>
								<TD style="WIDTH: 80%; HEIGHT: 15px" vAlign="top"><asp:Label ID="lblConsInicial" runat="server">
								Consecutivo Inicial:
								</asp:Label></td>
								<TD style="WIDTH: 44.75%; HEIGHT: 15px" vAlign="top"><asp:textbox id="txtConsecInicial" runat="server"></asp:textbox></TD>
								<TD style="WIDTH: 80%; HEIGHT: 15px" vAlign="top"><asp:Label ID="lblConsFinal" runat="server">
								Consecutivo Final:
								</asp:Label></td>
								<TD style="WIDTH: 80%; HEIGHT: 15px" vAlign="top"><asp:textbox id="txtConsecFinal" runat="server"></asp:textbox></TD>
							</tr>
							<TR>
								<TD style="WIDTH: 11.84%; HEIGHT: 23px" vAlign="top"></TD>
								<TD style="WIDTH: 80%; HEIGHT: 23px" vAlign="top"><asp:checkbox id="cbFecha" runat="server" Text="Por Fecha" AutoPostBack="True"></asp:checkbox></TD>
								<TD style="WIDTH: 80%; HEIGHT: 23px" vAlign="top">
                                    <asp:Label ID="lblInicial" runat="server">
                                    Fecha Inicial:
                                    </asp:Label></TD>
								<TD style="WIDTH: 75.05%; HEIGHT: 23px" vAlign="top"><asp:calendar id="FechaInicial" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                </asp:calendar></TD>
								<TD style="WIDTH: 80%; HEIGHT: 23px" vAlign="top">
                                    <asp:Label ID="lblFinal" runat="server">
                                    Fecha Final:
                                    </asp:Label></TD>
								<TD style="WIDTH: 44.75%; HEIGHT: 23px" vAlign="top"><asp:calendar id="FechaFinal" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                </asp:calendar></TD>
								<TD style="WIDTH: 80%; HEIGHT: 23px" vAlign="top"></TD>
								<TD style="WIDTH: 80%; HEIGHT: 23px" vAlign="top"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80%; HEIGHT: 33px" vAlign="top" colSpan="8">
									<table class="ResultsTable" cellSpacing="1" cellPadding="5" width="100%" border="0">
										<tr>
											<td id="SeccionResultados" runat="server" bgcolor="#ffffff" colspan="4"><asp:label id="lblNombre" runat="server" Visible="True">Ventas sin NIT</asp:label>
											</td>
										</tr>
										<asp:Repeater id="Results" runat="server">
											<HeaderTemplate>
												<tr>
													<td class="ResultsHeader2" vAlign="middle" align="center">Date</td>
													<td class="ResultsHeader2" vAlign="middle">Invoice #</td>
													<td class="ResultsHeader2" vAlign="middle" align="center">NIT</td>
													<td class="ResultsHeader2" vAlign="middle" align="right">Price</td>
												</tr>
											</HeaderTemplate>
											<ItemTemplate>
												<tr>
													<td class="RowItem" vAlign="middle" align="center"><%# DataBinder.Eval(Container.DataItem, "Fecha") %></td>
													<td class="RowItem" vAlign="middle"><%# DataBinder.Eval(Container.DataItem, "NumFact") %></td>
													<td class="RowItem" vAlign="middle" align="center"><%# DataBinder.Eval(Container.DataItem, "Nit") %></td>
													<td class="RowItem" vAlign="middle" align="right"><%# DataBinder.Eval(Container.DataItem, "ValorNeto") %></td>
												</tr>
											</ItemTemplate>
										</asp:Repeater></table>
								</TD>
							</TR>
						</table> <!-- End Developer Custom Code --><BR>
						<BR>
						<TABLE cellSpacing="0" cellPadding="5" width="100%" border="0">
							<TR>
								<TD align="right">
									<a  href="ReportesAuditoria.aspx">
                                        <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
