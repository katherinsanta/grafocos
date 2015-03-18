<%@ Page language="c#" Codebehind="ReportesVentas.aspx.cs" AutoEventWireup="false"
 Inherits="Servipunto.Estacion.Reportes.ReportesVentas" %>
<%@ Register TagPrefix="MyUserControls" TagName="Footer" Src="../../BlueSkin/UserControls/Footer.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="Header" Src="../../BlueSkin/UserControls/Header.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="TopicHeader" Src="../../BlueSkin/UserControls/TopicHeader.ascx" %>
<%@ Register TagPrefix="MyUserControls" TagName="NavigationPane" Src="../../BlueSkin/UserControls/NavigationPane.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Reportes de Servipunto Administrativo Automatización de Islas</title>
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
		<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<MYUSERCONTROLS:HEADER id="Header1" runat="server"></MYUSERCONTROLS:HEADER>
			<!-- Page Body -->
			<tr>
				<td vAlign="top" height="100%">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<MYUSERCONTROLS:NAVIGATIONPANE id="NavigationPane1" runat="server" GroupID="Estacion"></MYUSERCONTROLS:NAVIGATIONPANE>
							<!-- Topic Body -->
							<td vAlign="top" width="100%"><MYUSERCONTROLS:TOPICHEADER id="TopicHeader1" title="Reportes de Ventas" runat="server" Image="Reportes-48.png"
									ShortDescription="Reportes de las ventas relizadas en la estación"></MYUSERCONTROLS:TOPICHEADER>
								<!-- Topic Content -->
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td style="PADDING-RIGHT: 30px; PADDING-LEFT: 40px">
											<!-- Developer Custom Content -->
											<asp:label id="lblError" runat="server" Visible="false" ForeColor="Red"></asp:label><br>
											<p><font color="dimgray">En esta pagina encontrara todo tipo de reportes acerca de las 
													ventas realizadas en la estación durante un periodo de tiempo.</font></p>
											<blockquote>
												<table cellSpacing="5" cellPadding="5" border="0">
													<tr>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/CarroDinero-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,305,0,1,0,0,0,1,0)" href="FiltroIsla.aspx">
																			<u>Ventas por Isla</u> </A>
																		<br>
																		<br>
																		<font color="gray"><FONT color="gray">Informe de ventas realizadas por isla&nbsp;</FONT></font>
																	</td>
																</tr>
															</table>
														</td>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Credito-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,305,0,1,0,0,0,1,0)" href="FiltroCredito.aspx">
																			<u>Ventas por Credito Directo</u> </A>&nbsp;<br>
																		<br>
																		<FONT color="gray">Informe de ventas realizadas&nbsp;por credito directo</FONT></td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Canasta-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroArticulo.aspx">
																			<u>Ventas por Articulo</u> </A>&nbsp;
																		<br>
																		<FONT color="gray">Informe de ventas realizadas por articulo</FONT>
																	</td>
																</tr>
															</table>
														</td>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Cliente.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroCliente.aspx">
																			<u>Ventas por Clientes</u> </A>&nbsp;
																		<br>
																		<FONT color="gray"><FONT color="gray">Informe de ventas realizadas a cada cliente</FONT></FONT>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Carro-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroAutomotor.aspx">
																			<u>Ventas por Automotor</u> </A>&nbsp;
																		<br>
																		<FONT color="gray">Informe de ventas realizadas por un automotor especifico</FONT></td>
																</tr>
															</table>
														</td>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Turno-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroTurno.aspx">
																			<u>Ventas por Turno</u> </A>&nbsp;
																		<br>
																		<FONT color="gray"><FONT color="gray">Informe de ventas realizadas por turno</FONT></FONT>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Manguera-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroManguera.aspx">
																			<u>Ventas por Manguera</u> </A>&nbsp;
																		<br>
																		<FONT color="gray">Informe de ventas realizadas por las mangueras de la estación</FONT></td>
																</tr>
															</table>
														</td>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Cosecutivo-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroConsecutivo.aspx">
																			<u>Ventas por Consecutivo</u> </A>&nbsp;
																		<br>
																		<FONT color="gray"><FONT color="gray">Informe de ventas filtrado por el consecutivo de 
																				venta</FONT></FONT>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Libro-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroLecturas.aspx">
																			<u>Ventas por Lecturas</u> </A>&nbsp;
																		<br>
																		<FONT color="gray">Informe de ventas realizadas entre las lecturas inicial y final 
																			del surtido</FONT></td>
																</tr>
															</table>
														</td>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Calendario-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroDiaSemana.aspx">
																			<u>Ventas por Dia de la Semana</u> </A>&nbsp;
																		<br>
																		<FONT color="gray"><FONT color="gray">Informe de las ventas realizas en un dia de la 
																				semana</FONT></FONT>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td width="50%">
															<table>
																<tr>
																	<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/HoraEspecifica-48.gif" width="48" border="0"></td>
																	<td><br>
																		<A onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroHoraDia.aspx">
																			<u>Ventas Realizadas en Una Hora Especifica del Dia</u> </A>&nbsp;
																		<br>
																		<FONT color="gray">Informe de Ventas realizadas en una hora especifica</FONT>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</blockquote>
											<p>&nbsp;</p>
											<!-- End Developer Custom Content --></td>
									</tr>
								</table>
								<!-- End Topic Content --></td>
							<!-- End Topic Body --></tr>
					</table>
				</td>
			</tr>
			<!-- End Page Body --><MYUSERCONTROLS:FOOTER id="Footer1" runat="server"></MYUSERCONTROLS:FOOTER></table>
	</body>
</HTML>
