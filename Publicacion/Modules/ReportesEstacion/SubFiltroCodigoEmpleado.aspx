<%@ Page language="c#" Codebehind="SubFiltroCodigoEmpleado.aspx.cs" AutoEventWireup="false" 
Inherits="Servipunto.Estacion.Reportes.SubFiltroCodigoEmpleado" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Filtro Empleado</title>
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
				<p><asp:label id="lblError" Visible="false" ForeColor="Red" runat="server"></asp:label></p>
			</font></blockquote>
		<form id="MyForm" action="SubFiltroCodigoEmpleado.aspx" method="post" runat="server">
			<table cellSpacing="1" cellPadding="5" width="90%" align="center" bgColor="#5482fc" border="0">
				<tr>
					<td bgColor="#eeeeee"><asp:label id="lblReporte" runat="server">Filtro Empleado</asp:label></td>
				</tr>
				<tr>
					<td bgColor="#fefbff">
						<!-- Developer Custom Code -->
						<table cellSpacing="1" cellPadding="5" width="100%" border="0">
							<tr>
								<TD style="WIDTH: 80%; HEIGHT: 33px" vAlign="top">
									<table class="ResultsTable" cellSpacing="1" cellPadding="5" width="100%" border="0">
										<tr>
											<td id="SeccionResultados" runat="server" bgcolor="#ffffff" colspan="6"><asp:label id="lblNombre" runat="server" Visible="True">Resultados de la búsqueda</asp:label>
											</td>
										</tr>
										<asp:Repeater id="Results" runat="server">
											<HeaderTemplate>
											<tr>
													<td class="ResultsHeader2" vAlign="middle">Codigo</td>
													<td class="ResultsHeader2" vAlign="middle" colspan=2>Nombre del Cliente</td>
											</tr>
											</HeaderTemplate>
											<ItemTemplate>
												<tr onclick = "SeleccionarItem('<%# DataBinder.Eval(Container.DataItem, "IdEmpleado")%>','txtEmpleado')">
													<td class="RowItem" vAlign="middle"><%# DataBinder.Eval(Container.DataItem, "IdEmpleado") %></td>
													<td class="RowItem" vAlign="middle"><%# DataBinder.Eval(Container.DataItem, "Nombre") %></td>
												</tr>
											</ItemTemplate>
											<FooterTemplate>
												<tr>
													<td bgcolor="White" align="center" vAlign="middle" colspan="6">
														<%# DataBinder.Eval(Results.DataSource, "Count") %> resultado(s) encontrado(s)
													</td>
												</tr>
											</FooterTemplate>
										</asp:Repeater>
									</table>
								</TD>
							</tr>
						</table> <!-- End Developer Custom Code --><BR>
						<BR>
						<TABLE cellSpacing="0" cellPadding="5" width="100%" border="0">
							<TR>
								<TD>
									<DIV align="right">
										<A href="javascript:window.close();">Cerrar</A>
									</DIV>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
