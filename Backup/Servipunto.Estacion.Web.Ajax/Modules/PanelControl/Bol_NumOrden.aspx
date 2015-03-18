<%@ Page Language="c#" Codebehind="Bol_NumOrden.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Bol_NumOrden" 
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 307px;
                                                height: 400px">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="height: 15px">
                                                                    <asp:Label ID="lblFormTitle" runat="server">Título</asp:Label></td>
                                                                <td align="right" style="height: 15px">
                                                                    &nbsp;
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 418px">
                                                        <!--PRSENTACION I/O DE DATOS SEGUN LA SELECCION REALIZADA-->
                                                        <table cellpadding="4" border="0">
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Id Resolución:"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                    <asp:Label ID="lblIdNumOrden" runat="server"></asp:Label>
                                                                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Resolución Facturación:"></asp:Label>:</td>
                                                                <td style="width: 132px">
                                                                    <asp:TextBox ID="txtNumOder" runat="server"></asp:TextBox></td>
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Prefijo Facturación:"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                    <asp:TextBox ID="txtPrefijo" runat="server"></asp:TextBox></td>
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Consecutivo Inicial:"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                    <asp:TextBox ID="txtIniConsec" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="Label6" runat="server" Text="Consecutivo Final:"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                    <asp:TextBox ID="txtFinConsec" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px; height: 21px">
                                                                    <asp:Label ID="Label7" runat="server" Text="Fecha Asignación:"></asp:Label></td>
                                                                <td style="width: 132px; height: 21px">
                                                                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="122px" ></asp:TextBox>
                                                                    &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio">
                                                                    </cc1:CalendarExtender>
                                                                    <td style="width: 132px; height: 21px">
                                                                        <asp:ImageButton ID="ibMostrarCalendarioInicial" runat="server" Width="16px" Height="16px"
                                                                            ImageUrl="../../BlueSkin/Icons/calendario-16.gif" Visible="false"></asp:ImageButton></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px; height: 21px">
                                                                </td>
                                                                <td style="width: 132px; height: 21px">
                                                                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                                                                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                                        ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged"
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
                                                                <td style="width: 132px; height: 21px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="Label8" runat="server" Text="Fecha Expiración Rango:"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                    <asp:TextBox ID="txtFechaFinal" runat="server" ></asp:TextBox><cc1:CalendarExtender
                                                                        ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFinal">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                                <td style="width: 132px">
                                                                    <asp:ImageButton ID="ibMostrarCalendarioFinal" runat="server" Height="16px" ImageUrl="../../BlueSkin/Icons/calendario-16.gif"
                                                                        Width="16px" Visible="false"/></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                </td>
                                                                <td style="width: 132px">
                                                                    &nbsp;<asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999"
                                                                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                                        ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar2_SelectionChanged"
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
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px; height: 37px;">
                                                                    <asp:Label ID="Label9" runat="server" Text="Actividad Economica:"></asp:Label></td>
                                                                <td style="width: 132px; height: 37px;">
                                                                    <asp:TextBox ID="txtActividadEconomica" runat="server"></asp:TextBox></td>
                                                                <td style="width: 132px; height: 37px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="Label10" runat="server" Text="Régimen"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                    <asp:DropDownList ID="ddlTributarioRegimen" runat="server" Width="120px">
                                                                        <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                        <asp:ListItem Value="Comun">Comun</asp:ListItem>
                                                                        <asp:ListItem Value="Simplificado">Simplificado</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 199px">
                                                                    <asp:Label ID="lblEstado" runat="server" Width="64px">Activo</asp:Label>
                                                                </td>
                                                                <td style="width: 132px">
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                        runat="server" visible="false" />
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                                <td style="width: 132px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
