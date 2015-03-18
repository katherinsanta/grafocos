<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroVentasCombustible.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroVentasCombustible"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <blockquote>
        <font class="NormalFont">
            <p>
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">            
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Content -->
                    
                    <p>
                    </p>
                    <!-- Topic Content -->
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td style="padding-left: 40px; padding-right: 30px; width: 872px;">
                                <table width="100%">
                                    <tr>
                                        <td align="right" style="height: 15px; width: 100%;">
                                            &nbsp;
                                            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="ReportesAuditoria.aspx">Volver</asp:LinkButton></td>
                                    </tr>
                                </table>
                                <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 100%">
                                    <tr>
                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="width: 735px">
                                            <table id="Table3" width="100%">
                                                <tr>
                                                    <td style="width: 745px; height: 15px;" width="745">
                                                        <asp:Label ID="lblTituloGenerales" runat="server">
																									<b>Buscar por</b></asp:Label></td>
                                                    <td align="right" width="5%" style="height: 15px">
                                                    </td>
                                                    <td align="right" style="width: 5%; height: 15px;">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="1" cellpadding="4" border="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%; height: 25px" valign="middle">
                                            <asp:Label ID="lblInicial" runat="server">
                                    Fecha Inicial:
                                    </asp:Label></td>
                                        <td style="width: 247px; height: 25px">
                                            <asp:TextBox ID="txtFechaInicio" runat="server" Enabled="False" Width="127px"></asp:TextBox>
                                        </td>
                                        <td style="height: 25px">
                                            <asp:ImageButton ID="ibMostrarCalendarioInicial" runat="server" Height="16px" ImageUrl="~/BlueSkin/Icons/2011/Busqueda- 16.png"
                                                OnClick="ibMostrarCalendarioInicial_Click" Width="16px" /></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width: 1525px">
                                        </td>
                                        <td style="width: 247px">
                                            <asp:Calendar ID="FechaInicio" runat="server" BackColor="White" BorderColor="#999999"
                                                CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="FechaInicio_SelectionChanged"
                                                Visible="False">
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
                                        <td>
                                        </td>
                                        <td style="width: 2539px">
                                        </td>
                                        <td style="width: 369px">
                                        </td>
                                        <td style="width: 4229px">
                                        </td>
                                        <td style="width: 2640px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1525px; height: 24px" valign="middle">
                                            <asp:Label ID="lblFinal" runat="server">
                                    Fecha Final:
                                    </asp:Label></td>
                                        <td style="width: 247px; height: 24px">
                                            <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="False" Width="129px"></asp:TextBox>
                                        </td>
                                        <td style="height: 24px">
                                            <asp:ImageButton ID="ibMostrarCalendarioFinal" runat="server" Height="16px" ImageUrl="~/BlueSkin/Icons/2011/Busqueda- 16.png"
                                                OnClick="ibMostrarCalendarioFinal_Click1" Width="16px" /></td>
                                        <td style="width: 2539px; height: 24px">
                                        </td>
                                        <td style="width: 369px; height: 24px">
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Consultar" /></td>
                                        <td style="width: 4229px; height: 24px">
                                        </td>
                                        <td style="width: 2640px; height: 24px">
                                        </td>
                                        <td style="height: 24px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1525px; height: 16px" valign="top">
                                        </td>
                                        <td style="width: 247px; height: 16px">
                                            <asp:Calendar ID="FechaFin" runat="server" BackColor="White" BorderColor="#999999"
                                                CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="FechaFin_SelectionChanged"
                                                Visible="False">
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
                                        <td style="height: 16px">
                                        </td>
                                        <td style="width: 2539px; height: 16px">
                                        </td>
                                        <td style="width: 369px; height: 16px">
                                        </td>
                                        <td style="width: 4229px; height: 16px">
                                        </td>
                                        <td style="width: 2640px; height: 16px">
                                        </td>
                                        <td style="height: 16px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1525px; height: 16px" valign="top">
                                        </td>
                                        <td style="width: 247px; height: 16px">
                                            &nbsp;</td>
                                        <td style="height: 16px">
                                        </td>
                                        <td style="width: 2539px; height: 16px">
                                        </td>
                                        <td style="width: 369px; height: 16px">
                                        </td>
                                        <td style="width: 4229px; height: 16px">
                                        </td>
                                        <td style="width: 2640px; height: 16px">
                                        </td>
                                        <td style="height: 16px">
                                        </td>
                                    </tr>
                                    <!-- grilla -->
                                </table>
                                <asp:GridView ID="GrVentasCombustible" Width="100%" runat="server" AutoGenerateColumns="False"
                                    AllowPaging="True" AllowSorting="True" OnRowDataBound="GrVentasCombustible_RowDataBound"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" OnSelectedIndexChanged="GrVentasCombustible_SelectedIndexChanged"
                                    DataKeyNames="Consecutivo,Prefijo" OnRowCommand="GrVentasCombustible_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="Prefijo" HeaderText="PREFIJO">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Consecutivo" HeaderText="CONSECUTIVO">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha" HeaderText="FECHA">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Hora" HeaderText="HORA">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Subtotal" HeaderText="SUBTOTAL">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TotalIva" HeaderText="TOTALIVA">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total" HeaderText="TOTAL">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="REPORTE">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/BlueSkin/Icons/2011/reportes-16.png"
                                                    CommandArgument='<%#Bind("Consecutivo")%>' CommandName="Reporte" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="FilaNormal" BackColor="White" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Center" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <AlternatingRowStyle CssClass="FilaAlternada" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                </asp:GridView>                                
                                <p>
                                    &nbsp;</p>
                            </td>
                        </tr>
                    </table>
                    <!-- End Topic Content -->
                    <p>
                        &nbsp;&nbsp;</p>
                    <!-- End Developer Custom Content -->
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
