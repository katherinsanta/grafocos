<%@ Register TagPrefix="MyUserControls" TagName="NavigationPane" Src="../../BlueSkin/UserControls/NavigationPane.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="TopicHeader" Src="../../BlueSkin/UserControls/TopicHeader.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Header" Src="../../BlueSkin/UserControls/Header.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Footer" Src="../../BlueSkin/UserControls/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Restricciones.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Restricciones" ValidateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<head>
		<title>Horario de Consumo - Servipunto Administrativo Automatización de Islas</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
		<link href="../../BlueSkin/NS.css" type="text/css" rel="stylesheet">
		<script src="../../BlueSkin/NS.js" type=text/javascript></script>
		<script src="../../BlueSkin/NSWebBuilder.js" type=text/javascript></script>
		<script src="../../BlueSkin/NavigationPanels.js" type=text/javascript></script>
	</head>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
			<MyUserControls:Header id="Header1" runat="server" />
			<!-- Page Body -->
			<tr>
				<td valign=top height="100%">
					<table cellSpacing=0 cellPadding=0 width="100%" border=0 height="100%">
						<tr>
							<MyUserControls:NavigationPane GroupID="Comerciales" id="NavigationPane1" runat="server" />
							
							<!-- Topic Body -->
							<td vAlign=top width="100%">
								<MyUserControls:TopicHeader Title="Horario de consumo permitido al Automotor" ShortDescription="Lista el horario de consumo establecido para tanqueo del automotor, si no tiene horario; significa que puede tanquear en cualquier momento de cualquier día." Image="Automotor-48.png" id="TopicHeader1" runat="server" />
								<!-- Topic Content -->
								<table cellSpacing=0 cellPadding=0 width="100%" border=0>
									<tr>
										<td style="PADDING-LEFT: 40px; PADDING-RIGHT: 30px">
											<br>
											<p><asp:label id="lblError" runat="server" Visible="False" ForeColor="Red"></asp:label></p>
											<form id="MyForm" action="Restricciones.aspx" method="post" runat="server">
												<input type=hidden id="HiddenUpdate" runat=server NAME="HiddenUpdate">
												<table width="100%">
													<tr>
														<td class="ActionsHeader" align="right">
															<span id="Acciones" runat=server>Actions</span>
														</td>
													</tr>
												</table>
												<table class="ResultsTable" cellSpacing="1" cellPadding="4" width="100%" border="0">
														<tr>
														<td bgcolor="white" vAlign="middle" colspan = 9>
															<asp:Label id="Display" runat="server"></asp:Label>
														</td>
													</tr>
													<asp:Repeater id="Results" runat="server">
														<HeaderTemplate>
															<tr>
																<td class="ResultsHeader2" vAlign="middle" align="center" width="10%">Eliminar</td>
																<td class="ResultsHeader2" vAlign="middle" align="center" width="10%">Dia</td>
																<td class="ResultsHeader2" vAlign="middle" align="center" width="15%">Hora Inicio</td>
																<td class="ResultsHeader2" vAlign="middle" align="center" width="20%">Hora Fin</td>
														
															</tr>
														</HeaderTemplate>
														<ItemTemplate>
															<tr class="RowItem" ondblclick="if (HiddenUpdate.value!='Allow') { alert('Acceso Denegado. Su cuenta de usuario no tiene privilegios suficientes para modificar datos.'); } else { window.navigate('Restriccion.aspx?Placa=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "Placa")))%>&IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>&Dia=<%# DataBinder.Eval(Container.DataItem, "Dia")%>&HoraInicio=<%# DataBinder.Eval(Container.DataItem, "HoraInicio") %>'); }"  onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
																<td class="RowTextCentred" vAlign="middle"><input type=checkbox name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "placa") %>&<%# DataBinder.Eval(Container.DataItem, "dia")%>&<%# DataBinder.Eval(Container.DataItem, "horaInicio") %>'></td>
																<td class="RowTextCentred"  vAlign="middle"><%# DataBinder.Eval(Container.DataItem, "NombreDia") %></td>
																<td class="RowTextCentred" vAlign="middle"><%# DataBinder.Eval(Container.DataItem, "HoraInicioDisplay") %></td>
																<td class="RowTextCentred" vAlign="middle"><%# DataBinder.Eval(Container.DataItem, "HoraFinDisplay") %></td>
															</tr>
														</ItemTemplate>
														<FooterTemplate>
															<tr>
																<td bgcolor="White" align=center vAlign="middle" colspan="6"><%# DataBinder.Eval(Results.DataSource, "Count") %>&nbsp;elemento(s)</td>
															</tr>
														</FooterTemplate>
													</asp:Repeater>
												</table>
											</form>

											<p>&nbsp;</p>
										</td>										
									</tr>
								</table>
								<!-- End Topic Content -->							
							</td>
							<!-- End Topic Body -->
						</tr>
					</table>
				</td>
			</tr>
			<!-- End Page Body -->
			<MyUserControls:Footer id="Footer1" runat="server" />
		</table>
	</body>
</HTML>
