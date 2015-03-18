<%@ Register TagPrefix="MyUserControls" TagName="NavigationPane" Src="../../BlueSkin/UserControls/NavigationPane.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="TopicHeader" Src="../../BlueSkin/UserControls/TopicHeader.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Header" Src="../../BlueSkin/UserControls/Header.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Footer" Src="../../BlueSkin/UserControls/Footer.ascx" %>
<%@ Page language="c#" Codebehind="ConfInterfaceContableSAP.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.ConfInterfaceContableSAP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Configuración Interface Contable - Servipunto Administrativo Automatización de Islas</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../BlueSkin/NS.css" type="text/css" rel="stylesheet">
		<LINK href="../../BlueSkin/Tabs.css" type="text/css" rel="stylesheet">
		<script src="../../BlueSkin/NS.js" type="text/javascript"></script>
		<script src="../../BlueSkin/NSWebBuilder.js" type="text/javascript"></script>
		<script src="../../BlueSkin/NavigationPanels.js" type="text/javascript"></script>
		<script src="../../BlueSkin/Clientes.js" type="text/javascript"></script>
		<script type="text/javascript">
		
		
function SelectTab(elemID)
		{
			switch (elemID)
			{	
				case 'Detalle':
					document.forms[0].ActiveTab.value = 'Detalle';
					DesactivarTab('Cabecera');
					ActivarTab('Detalle');
					OcultarFila('filaCabecera');					
					MostrarFila('filaDetalle');
				break;	
								
				default:
					document.forms[0].ActiveTab.value = 'Cabecera';
					DesactivarTab('Detalle');
					ActivarTab('Cabecera');
					OcultarFila('filaDetalle');					
					MostrarFila('filaCabecera');
				break;
			}
		}
		</script>
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0" onload="SelectTab('<%=Session["TabAutomotores"]%>')">
		<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<MYUSERCONTROLS:HEADER id="Header1" runat="server"></MYUSERCONTROLS:HEADER>
			<!-- Page Body -->
			<tr>
				<td vAlign="top" height="100%">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<MYUSERCONTROLS:NAVIGATIONPANE id="NavigationPane1" runat="server" GroupID="Estacion"></MYUSERCONTROLS:NAVIGATIONPANE>
							<!-- Topic Body -->
							<td vAlign="top" width="100%"><MYUSERCONTROLS:TOPICHEADER id="TopicHeader1" title="Configuración Interface Contable" runat="server" ShortDescription="Creación y modificación Interface Contable."
									Image="Automotor-48.png"></MYUSERCONTROLS:TOPICHEADER>
								<!-- Topic Content -->
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td style="PADDING-RIGHT: 30px; PADDING-LEFT: 40px"><br>
											<p><asp:label id="lblError" runat="server" ForeColor="Red" Visible="False"></asp:label></p>
											<form id="MyForm" action="ConfInterfaceContableSAP.aspx" method="post" runat="server">
												<input id="ActiveTab" type="hidden" value="General" name="ActiveTab"> 
												<!-- Comiezo del control de pestañas -->
												<TABLE id="TabControl" width="75%">
													<TR>
														<TD class="tabOn" id="Cabecera" onmouseover="ActivarTab('Cabecera')" onclick="SelectTab('Cabecera')"
															onmouseout="DesactivarTab('Cabecera')" width="50%">Registro Cabecera</TD>
														<TD class="tabOff" id="Detalle" onmouseover="ActivarTab('Detalle')" onclick="SelectTab('Detalle')"
															onmouseout="DesactivarTab('Detalle')" width="50%">Registro Detalle</TD>
													</TR>
													<!-- Comiezo de la fila datos basicos -->
													<tr id="filaCabecera">
														<td colSpan="2">
															<table class="ResultsTable" cellSpacing="1" cellPadding="4" width="100%" border="0">
																<tr>
																	<td class="ResultsHeader4" vAlign="middle" align="left" colSpan="2">
																		<table width="100%">
																			<tr>
																				<td width="90%"><asp:label id="lblFormTitle" runat="server"><b>Registro Cabecera</b></asp:label></td>
																				<TD width="5%"><asp:linkbutton id="lbGuardar" runat="server">Guardar</asp:linkbutton></TD>
																				<!--<td width="5%"><a href="Automotores.aspx?IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>">Volver</a></td>-->
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td class="ResultsItem" vAlign="middle" align="left">
																		<TABLE id="Table3" cellPadding="4" border="0">
																			<TR>
																				<TD vAlign="middle" align="center" colSpan="4">
																					<P align="left"><B>Parámetros Generales Registro&nbsp;de Ventas</B></P>
																				</TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Tipo de Registro:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList20" runat="server" Width="120px">
																						<asp:ListItem Value="0">Cabecera</asp:ListItem>
																						<asp:ListItem Value="1">Detalle</asp:ListItem>
																					</asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Clase de Pedido:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList19" runat="server" Width="120px"></asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Organización de Ventas:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList18" runat="server" Width="120px"></asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Canal:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList17" runat="server" Width="120px"></asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Sector:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList16" runat="server" Width="120px"></asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Oficina de Ventas:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList15" runat="server" Width="120px"></asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Grupo de Vendedores:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList14" runat="server" Width="120px"></asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Asignación:</TD>
																				<TD width="25%">
																					<asp:TextBox id="TextBox12" runat="server"></asp:TextBox></TD>
																			</TR>
																			<TR>
																				<TD align="center" colSpan="4">
																					<P align="left"><B><B>Parámetros Generales Registro&nbsp;de Traslados</B></B></P>
																				</TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px">Tipo de Registro:</TD>
																				<TD width="25%">
																					<P>
																						<asp:DropDownList id="DropDownList13" runat="server" Width="120px">
																							<asp:ListItem Value="0">Cabecera</asp:ListItem>
																							<asp:ListItem Value="1">Detalle</asp:ListItem>
																						</asp:DropDownList></P>
																				</TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Clase de Documento:</TD>
																				<TD width="25%">
																					<asp:DropDownList id="DropDownList12" runat="server" Width="120px"></asp:DropDownList></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Sociedad:</TD>
																				<TD width="25%">
																					<asp:TextBox id="TextBox11" runat="server">CM01</asp:TextBox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 159px" width="159">Tipo de Moneda:</TD>
																				<TD width="25%">
																					<asp:TextBox id="TextBox10" runat="server">COP</asp:TextBox></TD>
																			</TR>
																			<TR>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
															</table>
														</td>
													</tr> <!-- fin de la fila datos basicos --> <!-- Comiezo de la fila datos comerciales -->
													<TR id="filaDetalle">
														<TD colSpan="2">
															<TABLE class="ResultsTable" cellSpacing="1" cellPadding="4" width="100%" border="0">
																<TR>
																	<TD class="ResultsHeader4" vAlign="middle" align="left" colSpan="2">
																		<TABLE width="100%">
																			<TR>
																				<TD width="90%">
																					<asp:label id="Label1" runat="server">
																						<b>Registro Detalle</b></asp:label></TD>
																				<TD width="5%">
																					<asp:linkbutton id="lbGuardar1" runat="server">Guardar</asp:linkbutton></TD><TD width="5%"><a href="Automotores.aspx?IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>">Volver</a></TD></TR></TR></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD class="ResultsItem" vAlign="middle" align="left">
																		<TABLE id="Table8" cellPadding="4" border="0">
																			<TR>
																				<TD style="HEIGHT: 18px" colSpan="2">
																					<P align="left"><B><B>Parámetros Generales Registro&nbsp;de Traslados</B></B></P>
																				</TD>
																			</TR>
																			<TR>
																				<TD style="HEIGHT: 18px" align="center">
																					<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="300" border="0">
																						<TR>
																							<TD>Tipo Ingreso:</TD>
																							<TD></TD>
																							<TD></TD>
																						</TR>
																						<TR>
																							<TD>
																								<asp:DropDownList id="DropDownList22" runat="server" Width="145px">
																									<asp:ListItem Value="Tarjeta D&#233;bito Ahorros">Tarjeta D&#233;bito Ahorros</asp:ListItem>
																									<asp:ListItem Value="Tarjeta D&#233;bito Corriente">Tarjeta D&#233;bito Corriente</asp:ListItem>
																									<asp:ListItem Value="Tarjeta Cr&#233;dito">Tarjeta Cr&#233;dito</asp:ListItem>
																									<asp:ListItem Value="Efectivo">Efectivo</asp:ListItem>
																									<asp:ListItem Value="Cheque">Cheque</asp:ListItem>
																									<asp:ListItem Value="Cr&#233;dito Directo">Cr&#233;dito Directo</asp:ListItem>
																								</asp:DropDownList></TD>
																							<TD>&nbsp;&nbsp;&nbsp;
																							</TD>
																							<TD>
																								<TABLE id="Table7" cellPadding="0" width="300" border="0">
																									<TR>
																										<TD>Naturaleza Cuenta:</TD>
																										<TD>
																											<asp:DropDownList id="DropDownList21" runat="server" Width="120px">
																												<asp:ListItem Value="40">D&#233;bito</asp:ListItem>
																												<asp:ListItem Value="50">Cr&#233;dito</asp:ListItem>
																											</asp:DropDownList></TD>
																									</TR>
																									<TR>
																										<TD>Número Cuenta:</TD>
																										<TD>
																											<asp:TextBox id="TextBox15" runat="server"></asp:TextBox></TD>
																									</TR>
																									<TR>
																										<TD>Asignación:</TD>
																										<TD>
																											<asp:TextBox id="TextBox14" runat="server" Width="163px" Height="68px" TextMode="MultiLine"></asp:TextBox></TD>
																									</TR>
																									<TR>
																										<TD>Texto:</TD>
																										<TD>
																											<asp:TextBox id="TextBox13" runat="server" Width="163px" Height="68px" TextMode="MultiLine"></asp:TextBox></TD>
																									</TR>
																								</TABLE>
																							</TD>
																						</TR>
																					</TABLE>
																				</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR> <!-- fin de la fila datos comerciales --></TABLE>
											</form>
											<P>&nbsp;</P>
										</td>
									</tr>
								</table> <!-- End Topic Content --></td> <!-- End Topic Body --></tr>
					</table>
				</td>
			</tr> <!-- End Page Body -->
			<MYUSERCONTROLS:FOOTER id="Footer1" runat="server"></MYUSERCONTROLS:FOOTER></table>
	</body>
</HTML>
