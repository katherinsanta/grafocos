<%@ Page Language="c#" Codebehind="FiltroEmpleado.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroEmpleado" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
        <table cellspacing="1" cellpadding="5" width="90%" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Titulo del Reporte</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="width: 19%; height: 15px" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Empleado"></asp:Label>:</td>
                            <td style="width: 25%; height: 15px">
                                <asp:TextBox ID="txtEmpleado" runat="server" Width="168px"></asp:TextBox>
                                <td style="width: 5%">
                                    <a onclick="Evaluar_check('SubFiltroCodigoEmpleado.aspx','cbTodosEmpleados','txtEmpleado')"
                                        href="#"><u>
                                            <img height="18" src="../../BlueSkin/Icons/2011/Busqueda- 16.png" width="18" border="0"></u></a></td>
                                <td style="width: 15%">
                                    <asp:CheckBox ID="cbTodosEmpleados" runat="server" AutoPostBack="True" Text="All"
                                        Width="46" Checked="True"></asp:CheckBox></td>
                                <td style="width: 36%">
                                    <asp:Label ID="Label2" runat="server" Text="Tipo de Reporte"></asp:Label>:
                                    <asp:RadioButtonList ID="TipoReporte" runat="server" RepeatDirection="Horizontal"
                                        Width="88px">
                                        <asp:ListItem Value="Detallado">Detallado</asp:ListItem>
                                        <asp:ListItem Value="Resumido" Selected="True">Resumido</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <tr>
                                    <td style="width: 19%; height: 33px" valign="top">
                                        <asp:Label ID="Label3" runat="server" Text="Turno"></asp:Label>:</td>
                                    <td style="width: 25%; height: 33px">
                                        <asp:TextBox ID="txtTurno" runat="server" Width="168px"></asp:TextBox></td>
                                    <td style="width: 5%; height: 33px" valign="top">
                                    </td>
                                    <td style="width: 15%; height: 33px" valign="top">
                                        <asp:CheckBox ID="cbTodosTurnos" runat="server" AutoPostBack="True" Text="All" Width="48px"
                                            Checked="True"></asp:CheckBox></td>
                                    <td style="width: 36%; height: 33px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 19%; height: 33px" valign="top">
                                        <asp:Label ID="Label4" runat="server" Text="Isla"></asp:Label>:</td>
                                    <td style="width: 25%; height: 33px">
                                        <asp:DropDownList ID="cboIsla" runat="server" Width="168px">
                                        </asp:DropDownList></td>
                                    <td style="width: 5%; height: 33px" valign="top">
                                    </td>
                                    <td style="width: 15%; height: 33px" valign="top">
                                    </td>
                                    <td style="width: 36%; height: 33px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 19%; height: 33px" valign="top">
                                        <asp:Label ID="Label5" runat="server" Text="Manguera"></asp:Label>:</td>
                                    <td style="width: 25%; height: 33px">
                                        <asp:TextBox ID="txtManguera" runat="server" Width="168px"></asp:TextBox></td>
                                    <td style="width: 5%; height: 33px" valign="top">
                                    </td>
                                    <td style="width: 15%; height: 33px" valign="top">
                                        <asp:CheckBox ID="cbTodasManguera" runat="server" AutoPostBack="True" Text="All"
                                            Width="49px" Checked="True"></asp:CheckBox></td>
                                    <td style="width: 36%; height: 33px" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 19%" valign="top">
                                        <asp:Label ID="Label6" runat="server" Text="Fecha Inicial"></asp:Label>:<br />
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
                                    <td style="width: 5%" valign="top">
                                    </td>
                                    <td style="width: 15%" valign="top">
                                        <asp:Label ID="Label7" runat="server" Text="Fecha Final"></asp:Label>:<br />
                                        <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                                    <td>
                                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                                        </cc1:CalendarExtender>
                                        <asp:Calendar ID="FechaFin" runat="server" Width="200px" BackColor="White" BorderColor="#999999"
                                            Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                                            Font-Size="8pt" ForeColor="Black" Height="180px">
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
                                        <asp:Label ID="Label8" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="ReportesGenerales.aspx">
                                        <asp:Label ID="Label9" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
