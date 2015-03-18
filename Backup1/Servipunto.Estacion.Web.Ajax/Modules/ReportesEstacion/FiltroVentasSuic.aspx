<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" AutoEventWireup="true"
    Codebehind="FiltroVentasSuic.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion.FiltroVentasSuic"
    Title="Página sin título" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <p>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label><br />
    <br /></p>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table style="border-bottom: solid 1px black; border-top: solid 1px black; border-right: solid 1px black;
            border-left: solid 1px black;" align="center" cellpadding="5" cellspacing="1"
            width="90%">
            <tr>
                <td style="border-bottom: solid 1px black; height: 25px" bgcolor="#DBD7D7" colspan="4"
                    align="center">
                    <asp:Label ID="lblReporte" runat="server">
                <b>
                Ventas De Vehiculos Suic
                </b>
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#eeeeee" colspan="4" align="center">
                    <asp:Label ID="Label3" runat="server">
                <b>
                Con ventas Entre :
                </b>
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblFeIni" runat="server" Text="Fecha Inicial">
                    </asp:Label>:
                    <br />
                    <asp:TextBox ID="txtFechaInicial" runat="server">
                    </asp:TextBox>
                </td>
                <td style="width: 186px">
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                    </cc1:CalendarExtender>
                    <asp:Calendar ID="FechaInicio" runat="server" BackColor="White" BorderColor="#999999"
                        Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="Black" Height="61px" Width="153px">
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
                <td valign="top">
                    <asp:Label ID="Label5" runat="server" Text="Fecha Final"></asp:Label>:
                    <br />
                    <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                <td>
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                    </cc1:CalendarExtender>
                    <asp:Calendar ID="FechaFin" runat="server" BackColor="White" BorderColor="#999999"
                        Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="Black" Height="94px" Width="156px">
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
                <td bgcolor="#eeeeee" colspan="4" align="center">
                    <asp:Label ID="Label4" runat="server">
                <b>
                y Vencimiento De Mantenimiento Suic Entre:
                </b>
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Fecha Inicial">
                    </asp:Label>:
                    <br />
                    <asp:TextBox ID="TxtFechMantIni" runat="server"></asp:TextBox>
                </td>
                <td style="width: 186px">
                    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                    </cc1:CalendarExtender>
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                        Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="Black" Height="61px" Width="153px">
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
                <td valign="top">
                    <asp:Label ID="Label2" runat="server" Text="Fecha Final"></asp:Label>:
                    <br />
                    <asp:TextBox ID="TxtFechMantFin" runat="server"></asp:TextBox></td>
                <td>
                    <cc1:CalendarExtender ID="CalendarExtender4" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                    </cc1:CalendarExtender>
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999"
                        Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="Black" Height="94px" Width="156px">
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
                <td valign="middle" colspan="2">
                    Cantidad de veces que el vehiculo ha tanqueado:
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox></td>
                <td valign="middle" colspan="2">
                    Formato:&nbsp;<asp:DropDownList ID="ddlOrden" runat="server">
                        <asp:ListItem Selected="True" Value="pdf">pdf</asp:ListItem>
                        <asp:ListItem Value="xls">xls</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 30px">
                    <div align="right">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                            <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                        | <a href="ReportesAutomotor.aspx">
                            <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
