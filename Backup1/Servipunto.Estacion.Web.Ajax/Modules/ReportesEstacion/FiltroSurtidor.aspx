<%@ Page Language="c#" Codebehind="FiltroSurtidor.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroSurtidor" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br>
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" Visible="false" ForeColor="Red" runat="server"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Reporte de Ventas por Surtidor</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top" style="width: 80px">
                                <asp:Label ID="Label1" runat="server" Text="Surtidor"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlSurtidor" runat="server" Width="176px">
                                </asp:DropDownList></td>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Tipo de Reporte"></asp:Label>:</td>
                            <td>
                                <asp:RadioButtonList ID="TipoReporte" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Detallado">Detallado</asp:ListItem>
                                    <asp:ListItem Value="Resumido" Selected="True">Resumido</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 80px; height: 9px" valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Por Turno"></asp:Label>:</td>
                            <td style="height: 9px">
                                <asp:RadioButtonList ID="Radiobuttonlist1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Si">Si</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="height: 9px" valign="top">
                                <asp:Label ID="Label4" runat="server" Text="Turno"></asp:Label>:</td>
                            <td style="height: 9px" valign="top">
                                <asp:TextBox ID="txtTurno" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top" style="width: 80px">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Inicial"></asp:Label>:<br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaInicio" runat="server" BackColor="White" BorderColor="#999999"
                                    Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                            <td valign="top">
                                <asp:Label ID="Label6" runat="server" Text="Fecha Final"></asp:Label>:<br />
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaFin" runat="server" BackColor="White" BorderColor="#999999"
                                    Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label7" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a href="ReportesGenerales.aspx">
                                        <asp:Label ID="Label8" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
