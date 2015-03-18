<%@ Page Language="c#" Codebehind="FiltroMesReal.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroMesReal" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br>
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#5482fc">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server"> Reporte de Ventas por Mes Laboral</asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellpadding="5" cellspacing="1" border="0">
                        <!--<tr>
								<td valign="top">Hora:</td>
								<td>
									<asp:DropDownList id="cboHora" runat="server" Width="169px">
										<asp:ListItem Value="24" Selected="True">(Todas las Horas)</asp:ListItem>
										<asp:ListItem Value="0">12 a.m.</asp:ListItem>
										<asp:ListItem Value="1">1 a.m.</asp:ListItem>
										<asp:ListItem Value="2 ">2 a.m.</asp:ListItem>
										<asp:ListItem Value="3">3 a.m.</asp:ListItem>
										<asp:ListItem Value="4">4 a.m.</asp:ListItem>
										<asp:ListItem Value="5">5 a.m.</asp:ListItem>
										<asp:ListItem Value="6">6 a.m.</asp:ListItem>
										<asp:ListItem Value="7">7 a.m.</asp:ListItem>
										<asp:ListItem Value="8">8 a.m.</asp:ListItem>
										<asp:ListItem Value="9">9 a.m.</asp:ListItem>
										<asp:ListItem Value="10">10 a.m.</asp:ListItem>
										<asp:ListItem Value="11">11 a.m.</asp:ListItem>
										<asp:ListItem Value="12">12 p.m.</asp:ListItem>
										<asp:ListItem Value="13">1 p.m.</asp:ListItem>
										<asp:ListItem Value="14">2 p.m.</asp:ListItem>
										<asp:ListItem Value="15">3 p.m.</asp:ListItem>
										<asp:ListItem Value="16">4 p.m.</asp:ListItem>
										<asp:ListItem Value="17">5 p.m.</asp:ListItem>
										<asp:ListItem Value="18">6 p.m.</asp:ListItem>
										<asp:ListItem Value="19">7 p.m.</asp:ListItem>
										<asp:ListItem Value="20">8 p.m.</asp:ListItem>
										<asp:ListItem Value="21">9 p.m.</asp:ListItem>
										<asp:ListItem Value="22">10 p.m.</asp:ListItem>
										<asp:ListItem Value="23">11p.m.</asp:ListItem>
									</asp:DropDownList></td>
								<td valign="top">Tipo de Reporte:</td>
								<td>
									<asp:RadioButtonList id="TipoReporte" runat="server" RepeatDirection="Horizontal">
										<asp:ListItem Value="Detallado">Detallado</asp:ListItem>
										<asp:ListItem Value="Resumido" Selected="True">Resumido</asp:ListItem>
									</asp:RadioButtonList>
								</td>
							</tr>-->
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Mes"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="cboMes" runat="server" Width="200px">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <br>
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="ReportesPeriodoTiempo.aspx">
                                        <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
