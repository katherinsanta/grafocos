<%@ Page Language="c#" Codebehind="FiltroAjusteFormasPago.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroAjusteFormasPago"
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
        <table width="90%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#5482fc">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Titulo del Reporte</asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table width="100%" cellpadding="5" cellspacing="1" border="0">
                        <tr>
                            <td valign="top">
                            </td>
                            <td>
                                <p align="center">
                                    <strong>
                                        <asp:Label ID="Label1" runat="server" Text="Fecha Inicial"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></strong></p>
                            </td>
                            <td valign="top">
                                <p align="center">
                                    <strong>
                                        <asp:Label ID="Label2" runat="server" Text="Fecha Inicial"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></strong></p>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                            </td>
                            <td>
                                <div align="center">
                                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                    </cc1:CalendarExtender>
                                    <asp:Calendar ID="FechaInicio" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                        Visible="false" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest"
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
                                </div>
                            </td>
                            <td valign="top">
                                <div align="center">
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
                                </div>
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
                                    | <a href="ReportesFormaPago.aspx">
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
