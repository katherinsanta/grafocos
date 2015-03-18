<%@ Page Language="c#" Codebehind="FiltroCierreTurno.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroCierreTurno" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br>
    <p>
        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    </p>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="90%" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Reporte de Ventas por Cierre de Turno</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top" style="width: 48px">
                                <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="Turno"></asp:Label></td>
                            <td style="width: 92px">
                                <asp:TextBox ID="txtTurno" runat="server"></asp:TextBox></td>
                            <td style="width: 170px">
                                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbFormato" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top" style="width: 48px">
                                <asp:Label ID="Label2" runat="server" Text="Isla"></asp:Label></td>
                            <td style="width: 92px">
                                <asp:DropDownList ID="cboIsla" runat="server" Width="120px">
                                </asp:DropDownList></td>
                            <td style="width: 170px">
                                <asp:Label ID="lblInfoTurno" runat="server">
								    Informacion de turno:
                                </asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbnInformacionTurno" runat="server" RepeatDirection="Horizontal"
                                    Height="8px">
                                    <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 48px" valign="top">
                            </td>
                            <td style="width: 92px">
                            </td>
                            <td style="width: 170px">
                                <asp:Label ID="lblResumenIsla" runat="server">
								    Resumen de Isla:
                                </asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbnTurnoIsla" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 48px" valign="top">
                            </td>
                            <td style="width: 92px">
                            </td>
                            <td style="width: 170px">
                                <asp:Label ID="lblDiffLecturas" runat="server">
								    Diferencia de Lecturas:
                                </asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbnLectuas" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 48px" valign="top">
                            </td>
                            <td style="width: 92px">
                            </td>
                            <td style="width: 170px">
                                <asp:Label ID="lblArticulos" runat="server">
								    Articulos:
                                </asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbnArticulos" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 48px" valign="top">
                            </td>
                            <td style="width: 92px">
                            </td>
                            <td style="width: 171px">
                                <asp:Label ID="lblFormasPago" runat="server">
								    Formas de pago:
                                </asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbnFormasPago" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 48px" valign="top">
                            </td>
                            <td style="width: 92px">
                            </td>
                            <td style="width: 171px">
                                <asp:Label ID="lblCreditoDirecto" runat="server">
								    Credito Directo:
                                </asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbnCreditoDirecto" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 48px" valign="top">
                            </td>
                            <td style="width: 92px">
                            </td>
                            <td style="width: 171px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="width: 48px">
                                <asp:Label ID="lblFecha" runat="server">
								    Fecha:
                                </asp:Label></td>
                            <td style="width: 92px">
                                <asp:Calendar ID="FechaInicio" runat="server" BackColor="White" BorderColor="#999999"
                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="180px" Width="200px">
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                </asp:Calendar>
                            </td>
                            <td style="width: 171px">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a href="ReportesGenerales.aspx">
                                        <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
