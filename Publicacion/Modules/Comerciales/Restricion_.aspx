<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restricion_.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Restricion_" %>
<%@ Register TagPrefix="MyUserControls" TagName="Footer" Src="../../BlueSkin/UserControls/Footer.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Header" Src="../../BlueSkin/UserControls/Header.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="TopicHeader" Src="../../BlueSkin/UserControls/TopicHeader.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="NavigationPane" Src="../../BlueSkin/UserControls/NavigationPane.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Horarios - Servipunto Administrativo Automatización de Islas</title>
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
			<MYUSERCONTROLS:HEADER id="Header1" runat="server"></MYUSERCONTROLS:HEADER>
			<!-- Page Body -->
			<tr>
				<td vAlign="top" height="100%">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<MYUSERCONTROLS:NAVIGATIONPANE id="NavigationPane1" runat="server" GroupID="Comerciales"></MYUSERCONTROLS:NAVIGATIONPANE>
							<!-- Topic Body -->
							<td vAlign="top" width="100%"><MYUSERCONTROLS:TOPICHEADER id="TopicHeader1" title="Configuración de Horarios" runat="server" ShortDescription="Creación y modificación de Horarios de Consumo."
									Image="Automotor-48.png"></MYUSERCONTROLS:TOPICHEADER>
								<!-- Topic Content -->
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td style="PADDING-RIGHT: 30px; PADDING-LEFT: 40px"><br>
											<p><asp:label id="lblError" runat="server" Visible="False" ForeColor="Red"></asp:label></p>
											<form id="MyForm" action="Restricion_.aspx" method="post" runat="server">
												<table class="ResultsTable" cellSpacing="1" cellPadding="4" width="350" border="0">
													<tr>
														<td class="ResultsHeader4" vAlign="middle" align="left" colSpan="2">
															<table width="100%">
																<tr>
																	<td><asp:label id="lblFormTitle" runat="server">Titulo</asp:label></td>
																	<td align="right">
																		<asp:linkbutton id="lblGuardar" runat="server" OnClick="lblGuardar_Click1">Guardar</asp:linkbutton>&nbsp; 
																		&nbsp;<asp:hyperlink id="lblBack" runat="server">Volver</asp:hyperlink></td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td class="ResultsItem" vAlign="middle" align="left">
															<table cellPadding="4" border="0">
																<TR id="filaEmpleado" runat="server">
																	<TD style="HEIGHT: 28px">Placa del Automor:</TD>
																	<TD style="HEIGHT: 28px"><asp:label id="lblPlaca" runat="server" Width="120px" Font-Bold="True"></asp:label></TD>
																</TR>
																<tr>
																	<td style="HEIGHT: 28px">Día:</td>
																	<td style="HEIGHT: 28px"><asp:dropdownlist id="cboDia" runat="server" Width="120px">
																			<asp:ListItem Value="7" Selected="True">Lunes - Viernes</asp:ListItem>
																			<asp:ListItem Value="0">Domingo</asp:ListItem>
																			<asp:ListItem Value="1">Lunes</asp:ListItem>
																			<asp:ListItem Value="2">Martes</asp:ListItem>
																			<asp:ListItem Value="3">Miercoles</asp:ListItem>
																			<asp:ListItem Value="4">Jueves</asp:ListItem>
																			<asp:ListItem Value="5">Viernes</asp:ListItem>
																			<asp:ListItem Value="6">Sabado</asp:ListItem>
																			<asp:ListItem Value="8">Todos los d&#237;as</asp:ListItem>
																		</asp:dropdownlist></td>
																</tr>
																<tr>
																	<td style="HEIGHT: 48px">Hora Inicio:</td>
																	<td style="HEIGHT: 48px" align="center">
																		<P>
																			<asp:dropdownlist id="cboHoraInicio" runat="server" Width="46px">
<asp:ListItem Value="0" Selected="True">00</asp:ListItem>
<asp:ListItem Value="1">01</asp:ListItem>
<asp:ListItem Value="2">02</asp:ListItem>
<asp:ListItem Value="3">03</asp:ListItem>
<asp:ListItem Value="4">04</asp:ListItem>
<asp:ListItem Value="5">05</asp:ListItem>
<asp:ListItem Value="6">06</asp:ListItem>
<asp:ListItem Value="7">07</asp:ListItem>
<asp:ListItem Value="8">08</asp:ListItem>
<asp:ListItem Value="9">09</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
<asp:ListItem Value="13">13</asp:ListItem>
<asp:ListItem Value="14">14</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="16">16</asp:ListItem>
<asp:ListItem Value="17">17</asp:ListItem>
<asp:ListItem Value="18">18</asp:ListItem>
<asp:ListItem Value="19">19</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="21">21</asp:ListItem>
<asp:ListItem Value="22">22</asp:ListItem>
<asp:ListItem Value="23">23</asp:ListItem>
																			</asp:dropdownlist>:
																			<asp:TextBox id="cboMinutoInicio" runat="server" Width="20px"></asp:TextBox>
																			<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Invalido!" ControlToValidate="cboMinutoInicio"
																				ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator></P>
																	</td>
																</tr>
																<TR>
																	<TD>Hora Fin:</TD>
																	<TD>
																		<P align="center">
																			<asp:dropdownlist id="cboHoraFin" runat="server" Width="46px">
																				<asp:ListItem Value="0" Selected="True">00</asp:ListItem>
																				<asp:ListItem Value="1">01</asp:ListItem>
																				<asp:ListItem Value="2">02</asp:ListItem>
																				<asp:ListItem Value="3">03</asp:ListItem>
																				<asp:ListItem Value="4">04</asp:ListItem>
																				<asp:ListItem Value="5">05</asp:ListItem>
																				<asp:ListItem Value="6">06</asp:ListItem>
																				<asp:ListItem Value="7">07</asp:ListItem>
																				<asp:ListItem Value="8">08</asp:ListItem>
																				<asp:ListItem Value="9">09</asp:ListItem>
																				<asp:ListItem Value="10">10</asp:ListItem>
																				<asp:ListItem Value="11">11</asp:ListItem>
																				<asp:ListItem Value="12">12</asp:ListItem>
																				<asp:ListItem Value="13">13</asp:ListItem>
																				<asp:ListItem Value="14">14</asp:ListItem>
																				<asp:ListItem Value="15">15</asp:ListItem>
																				<asp:ListItem Value="16">16</asp:ListItem>
																				<asp:ListItem Value="17">17</asp:ListItem>
																				<asp:ListItem Value="18">18</asp:ListItem>
																				<asp:ListItem Value="19">19</asp:ListItem>
																				<asp:ListItem Value="20">20</asp:ListItem>
																				<asp:ListItem Value="21">21</asp:ListItem>
																				<asp:ListItem Value="22">22</asp:ListItem>
																				<asp:ListItem Value="23">23</asp:ListItem>
																			</asp:dropdownlist>:
																			<asp:TextBox id="cboMinutoFin" runat="server" Width="20px"></asp:TextBox>
																			<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Invalido!" ControlToValidate="cboMinutoFin"
																				ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator></P>
																	</TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 22px"></TD>
																	<TD style="HEIGHT: 22px">
																		<asp:textbox id="txtLlaveCompuesta" runat="server" Width="16px" MaxLength="16" Visible="False"></asp:textbox></TD>
																</TR>
																<TR id="filaPlaca" runat="server">
																	<TD></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD>&nbsp;</TD>
																	<TD>&nbsp;
                                                                        <asp:Label ID="lblHide" runat="server"></asp:Label></TD>
																</TR>
															</table>
														</td>
													</tr>
												</table>
											</form>
											<P>&nbsp;</P>
										</td>
									</tr>
								</table> <!-- End Topic Content --></td> <!-- End Topic Body --></tr>
					</table>
				</td>
			</tr> <!-- End Page Body --><MYUSERCONTROLS:FOOTER id="Footer1" runat="server"></MYUSERCONTROLS:FOOTER></table>
	</body>
</html>
