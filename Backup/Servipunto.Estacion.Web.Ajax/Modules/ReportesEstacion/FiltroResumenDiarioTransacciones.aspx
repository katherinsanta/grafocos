<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroResumenDiarioTransacciones.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroResumenDiarioTransacciones"
  MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Titulo del Reporte</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr><td>
                        <table cellspacing="1" cellpadding="5" width="100%" border="0">
                            <tr>
                                <td style="width: 114px; height: 31px" valign="top">
                                    <asp:Label ID="lblTipoReporte" runat="server">
                                    Tipo de Reporte:
                                    </asp:Label></td>
                                <td style="width: 163px; height: 31px">
                                    <asp:RadioButtonList ID="TipoReporte" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Detallado">Detallado</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="Resumido">Resumido</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td style="width: 100px; height: 31px">
                                </td>
                                <td style="width: 163px; height: 31px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 114px" valign="top">
                                    <asp:Label ID="lblInicial" runat="server">
                                    Fecha Inicial:
                                    </asp:Label></td>
                                <td style="width: 163px">
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
                                <td style="width: 100px" valign="top">
                                    <asp:Label ID="lblFinal" runat="server">
                                    Fecha Final:
                                    </asp:Label></td>
                                <td style="width: 163px">
                                    <asp:Calendar ID="FechaFinal" runat="server" BackColor="White" BorderColor="#999999"
                                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                        ForeColor="Black" Height="180px" Width="200px">
                                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" />
                                        <WeekendDayStyle BackColor="#FFFFCC" />
                                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <OtherMonthDayStyle ForeColor="Gray" />
                                        <NextPrevStyle VerticalAlign="Bottom" />
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    </asp:Calendar>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 114px">
                                    <asp:Label ID="lblAviso" runat="server">Solo se puede generar este reporte si la fecha final seleccionada se realizo cierre de jornada Zeta.</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <!-- End Developer Custom Code -->
                        <table cellspacing="0" cellpadding="5" width="100%" border="0">
                            <tr>
                                <td>                                    
                                     <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="ReportesAuditoria.aspx">
                                        <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                                </td>
                            </tr>
                        </table>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
