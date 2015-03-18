<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroOtrosIngresos.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroOtrosIngresos"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Titulo del Reporte</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="width: 78px; height: 22px" valign="top">
                                <asp:Label ID="lblArticulo" runat="server">Fecha de:</asp:Label></td>
                            <td style="width: 137px; height: 22px">
                                <asp:RadioButtonList ID="FechaDe" runat="server" Width="200px" OnSelectedIndexChanged="FechaDe_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="1">Turno</asp:ListItem>
                                    <asp:ListItem Value="2">Real</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="width: 84px; height: 22px" valign="top">
                                <asp:Label ID="lblTipoReporte" runat="server">
                                    Tipo de Reporte:
                                    </asp:Label></td>
                            <td style="height: 22px">
                                <asp:RadioButtonList ID="TipoReporte" runat="server" Width="200px">
                                    <asp:ListItem Value="1" Selected="True">Resumido</asp:ListItem>
                                    <asp:ListItem Value="2">Detallado</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 78px; height: 33px" valign="top">
                            </td>
                            <td style="width: 137px; height: 33px">
                            </td>
                            <td style="width: 84px; height: 33px" valign="top">
                                <asp:Label ID="lblFormato" runat="server">
                                    Formato
                                </asp:Label></td>
                            <td style="height: 33px">
                                <asp:RadioButtonList ID="rbFormato" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 78px" valign="top">
                                <asp:Label ID="lblInicial" runat="server">
                                    Fecha Inicial:
                                </asp:Label></td>
                            <td style="width: 137px">
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
                            <td style="width: 84px" valign="top">
                                <asp:Label ID="lblFinal" runat="server">
                                    Fecha Final:
                                </asp:Label></td>
                            <td>
                                <asp:Calendar ID="FechaFin" runat="server" BackColor="White" BorderColor="#999999"
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
                        </tr>
                        <tr>
                            <td style="width: 78px" valign="top">
                            </td>
                            <td style="width: 137px">
                            </td>
                            <td style="width: 84px" valign="top">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 78px" valign="top">
                            </td>
                            <td style="width: 137px">
                            </td>
                            <td style="width: 84px" valign="top">
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
                                    | <a  href="ReportesAuditoria.aspx">
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
