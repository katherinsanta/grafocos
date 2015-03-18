<%@ Page language="c#" Codebehind="FiltroVentasArticulo.aspx.cs" AutoEventWireup="false" 
Inherits="Servipunto.Estacion.Reportes.FiltroVentasArticulo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Generación Archivo Ventas por Artículo</title>
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
		<form id="MyForm" action="FiltroVentasArticulo.aspx" method="post" runat="server">
			<table cellSpacing="1" cellPadding="5" align="center" bgColor="#5482fc" border="0">
				<tr>
					<td bgColor="#eeeeee"><asp:label id="lblReporte" runat="server">Generar Archivo Plano de Ventas por Artículo</asp:label></td>
				</tr>
				<tr>
					<td bgColor="#fefbff">
						<!-- Developer Custom Code -->
						<table cellSpacing="1" cellPadding="5" width="100%" border="0">
							<TR>
								<TD vAlign="top">Fecha:</TD>
								<TD style="WIDTH: 210px">
									<asp:Calendar id="FechaInicio" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" />
                                        <WeekendDayStyle BackColor="#FFFFCC" />
                                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <OtherMonthDayStyle ForeColor="#808080" />
                                        <NextPrevStyle VerticalAlign="Bottom" />
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    </asp:Calendar></TD>
							</TR>
							<TR>
								<TD vAlign="top">Separador:</TD>
								<TD style="WIDTH: 210px">
									<input type="text" name="txtSeparador" value="|" maxlength="1" size="1"></TD>
							</TR>
							<tr>
								<td valign="top">No. Turno:</td>
								<td style="WIDTH:210px">
									<input type="text" name="txtNum_Tur" value="0" maxlength="1" size="1" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;">
								</td>
							</tr>
						</table>
						<!-- End Developer Custom Code --><br>
						<br>
						<table cellSpacing="0" cellPadding="5" width="100%" border="0">
							<tr>
								<td>
									<div align="right"><A  onclick="document.forms[0].submit();" href="#">Crear 
											Archivo</A>&nbsp;| <A  href="javascript:window.close();">Cerrar</A>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
