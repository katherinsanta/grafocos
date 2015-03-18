<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroConductorConsumo.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroConductorConsumo"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <blockquote>
    <p>
        <font class="NormalFont">
            
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </font>
        </p>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Reporte Consumos por conductor</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="width: 64px; height: 15px" valign="top">
                                <asp:Label ID="lblConductor" runat="server">
                                    Conductor:
                                </asp:Label></td>
                            <td style="width: 154px; height: 15px">
                                <asp:TextBox ID="txtCodigoCliente" runat="server"></asp:TextBox>
                                <a onclick="Evaluar_check('SubFiltroIdConductor.aspx','cbTodos','txtCodigoCliente')"
                                    href="#"><u>
                                        <img height="18" src="../../BlueSkin/Icons/2011/Busqueda- 16.png" width="18" border="0"
                                            id="IMAGEN"></u> </a></td>
                                <td style="width: 82px">
                                    &nbsp;<td style="width: 84px; height: 15px" valign="top">
                                    </td>
                        </tr>
                        <tr>
                            <td style="width: 64px; height: 33px" valign="top">
                            </td>
                            <td style="width: 154px; height: 33px">
                                <asp:CheckBox ID="cbTodos" runat="server" Checked="True" AutoPostBack="True" Text="Todos los conductores">
                                </asp:CheckBox>
                            </td>
                            <td style="width: 82px; height: 33px" valign="top">
                            </td>
                            <td style="height: 33px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 64px" valign="top">
                                <asp:Label ID="Label4" runat="server" Text="Fecha Inicial"></asp:Label></td>
                            <td style="width: 154px">
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
                            <td style="width: 82px" valign="top">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Final"></asp:Label></td>
                            <td>
                                <asp:Calendar ID="FechaFin" runat="server" Width="200px" BackColor="White" BorderColor="#999999"
                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="180px">
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
                                        <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a href="ReportesConductor.aspx">
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