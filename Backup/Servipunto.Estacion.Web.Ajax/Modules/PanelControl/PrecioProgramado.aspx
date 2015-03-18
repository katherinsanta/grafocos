<%@ Page Language="c#" Codebehind="PrecioProgramado.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.PrecioProgramado" 
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
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="600" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lbGuardar" runat="server">Guardar</asp:LinkButton>&nbsp;<asp:HyperLink
                                                                        ID="lblBack" runat="server" NavigateUrl="PreciosProgramados.aspx">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" width="100%" border="0">
                                                            <tr>
                                                                <td style="width: 87px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Artículo"></asp:Label>:</td>
                                                                <td style="width: 193px">
                                                                    <asp:DropDownList ID="ddlArticulo" runat="server" Width="160px">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblHideArticulo" runat="server" Visible="False"></asp:Label></td>
                                                                <td style="width: 49px">
                                                                    <asp:Label ID="Label6" runat="server" Text="Fecha"></asp:Label>:<br />
                                                                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox></td>
                                                                <td rowspan="7">
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFecha">
                                                                    </cc1:CalendarExtender>
                                                                    <asp:Calendar ID="Calendario" Visible="false" runat="server" ForeColor="#003399"
                                                                        Width="200px" DayNameFormat="FirstLetter" BorderWidth="1px" CellPadding="1" BorderColor="#3366CC"
                                                                        Font-Names="Verdana" Font-Size="8pt" CellSpacing="1" BackColor="White" Height="100px">
                                                                        <TodayDayStyle ForeColor="White" BackColor="#99CCCC"></TodayDayStyle>
                                                                        <SelectorStyle ForeColor="#336666" BackColor="#99CCCC"></SelectorStyle>
                                                                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>
                                                                        <DayHeaderStyle Height="1px" ForeColor="Blue" BackColor="LightSteelBlue"></DayHeaderStyle>
                                                                        <SelectedDayStyle Font-Bold="True" ForeColor="#0000C0" BackColor="RoyalBlue"></SelectedDayStyle>
                                                                        <TitleStyle Font-Size="10pt" Font-Bold="True" Height="25px" BorderWidth="1px" ForeColor="White"
                                                                            BorderStyle="Solid" BorderColor="Black" BackColor="#003399"></TitleStyle>
                                                                        <WeekendDayStyle BackColor="Gainsboro"></WeekendDayStyle>
                                                                        <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                                                                    </asp:Calendar>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 87px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Precio 1"></asp:Label>:</td>
                                                                <td style="width: 193px">
                                                                    <asp:TextBox ID="txtPrecio1" runat="server" Width="160px"></asp:TextBox></td>
                                                                <td style="width: 49px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 87px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Precio 2"></asp:Label>:</td>
                                                                <td style="width: 193px">
                                                                    <asp:TextBox ID="txtPrecio2" runat="server" Width="160px"></asp:TextBox></td>
                                                                <td style="width: 49px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 87px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Precio 3"></asp:Label>:</td>
                                                                <td style="width: 193px">
                                                                    <asp:TextBox ID="txtPrecio3" runat="server" Width="160px"></asp:TextBox></td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 87px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Precio 4"></asp:Label>:</td>
                                                                <td style="width: 193px">
                                                                    <asp:TextBox ID="txtPrecio4" runat="server" Width="160px"></asp:TextBox></td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <p>
                                            &nbsp;</p>
                                    </td>
                                </tr>
                            </table>
                            <!-- End Topic Content -->
                        </td>
                        <!-- End Topic Body -->
                    </tr>
                </table>
            </td>
        </tr>
        <!-- End Page Body -->
    </table>
</asp:Content>
