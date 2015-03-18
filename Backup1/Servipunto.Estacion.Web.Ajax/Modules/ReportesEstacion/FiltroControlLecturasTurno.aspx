<%@ Page Language="c#" Codebehind="FiltroControlLecturasTurno.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroControlLecturasTurno"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                    <asp:Label ID="lblReporte" runat="server">Reporte de Control de Lecturas de Turnos</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top" style="height: 44px">
                                <asp:Label ID="Label2" runat="server" Text="Isla"></asp:Label>:</td>
                            <td style="height: 44px">
                                <asp:DropDownList ID="cboIsla" runat="server" Width="182px">
                                </asp:DropDownList></td>
                            <td valign="top" style="height: 44px">
                                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>:</td>
                            <td style="height: 44px">
                                <asp:RadioButtonList ID="rbFormato" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                    <asp:ListItem Value="txt">csv</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 36px">
                                <asp:Label ID="Label4" runat="server" Text="Turno"></asp:Label>:</td>
                            <td style="height: 36px">
                                <asp:DropDownList ID="cboTurno" runat="server" Width="182px">
                                </asp:DropDownList></td>
                            <td valign="top" style="height: 36px">
                                <asp:Label ID="Label5" runat="server" Text="Consolidado por manguera"></asp:Label>:</td>
                            <td style="height: 36px">
                                <asp:RadioButtonList ID="rbnConsolidadoManguera" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Si</asp:ListItem>
                                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label6" runat="server" Text="Manguera"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="cboManguera" runat="server" Width="182px">
                                </asp:DropDownList></td>
                            <td valign="top">
                                <asp:Label ID="Label7" runat="server" Text="Resumen Formas Pago"></asp:Label>:</td>
                            <td>
                                <asp:RadioButtonList ID="rbnFormasPago" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Si</asp:ListItem>
                                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label8" runat="server" Text="Articulo"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlArticulo" runat="server" Width="160px">
                                </asp:DropDownList></td>
                            <td valign="top">
                                <asp:Label ID="Label9" runat="server" Text="Grafica"></asp:Label>:</td>
                            <td>
                                <asp:RadioButtonList ID="rbnGrafica" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Si</asp:ListItem>
                                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label10" runat="server" Text="Unidad de Medida"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlUnidadMedida" runat="server" Width="160px">
                                </asp:DropDownList></td>
                            <td valign="top">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label11" runat="server" Text="Separador"></asp:Label>
                                CSV</td>
                            <td>
                                <asp:TextBox ID="txtSeparador" runat="server" Width="24px">;</asp:TextBox></td>
                            <td valign="top">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label12" runat="server" Text="Fecha Inicial"></asp:Label>:<br />
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
                                <asp:Label ID="Label13" runat="server" Text="Fecha Final"></asp:Label>:<br />
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
                    <asp:Label ID="Label1" runat="server" ForeColor="Gray">Nota: Si activa "Formas de Pago" o activa "Grafica" el reporte se tornara más demorado en su proceso de generación</asp:Label><br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label14" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="ReportesGenerales.aspx">
                                        <asp:Label ID="Label15" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
