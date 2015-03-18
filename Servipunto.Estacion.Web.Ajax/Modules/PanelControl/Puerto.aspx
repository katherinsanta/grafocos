<%@ Page Language="c#" Codebehind="Puerto.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Puerto"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>
<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0"  style="height:100%">
        <!-- Page Body -->
        <tr>
            <td valign="top"  style="height:100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0"  style="height:100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top"  style="width:100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="300">
                                            <tr>
                                                <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                            <td align="right">
                                                                <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="ResultsItem" valign="middle" align="left">
                                                    <table cellpadding="4" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Puerto"></asp:Label>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboPort" runat="server" Width="120px">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Bits por Segundo"></asp:Label>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboBaudRate" runat="server" Width="120px">
                                                                    <asp:ListItem Value="75">75</asp:ListItem>
                                                                    <asp:ListItem Value="110">110</asp:ListItem>
                                                                    <asp:ListItem Value="134">134</asp:ListItem>
                                                                    <asp:ListItem Value="150">150</asp:ListItem>
                                                                    <asp:ListItem Value="300">300</asp:ListItem>
                                                                    <asp:ListItem Value="600">600</asp:ListItem>
                                                                    <asp:ListItem Value="1200">1200</asp:ListItem>
                                                                    <asp:ListItem Value="1800">1800</asp:ListItem>
                                                                    <asp:ListItem Value="2400">2400</asp:ListItem>
                                                                    <asp:ListItem Value="4800">4800</asp:ListItem>
                                                                    <asp:ListItem Value="7200">7200</asp:ListItem>
                                                                    <asp:ListItem Value="9600" Selected="True">9600</asp:ListItem>
                                                                    <asp:ListItem Value="14400">14400</asp:ListItem>
                                                                    <asp:ListItem Value="19200">19200</asp:ListItem>
                                                                    <asp:ListItem Value="38400">38400</asp:ListItem>
                                                                    <asp:ListItem Value="57600">57600</asp:ListItem>
                                                                    <asp:ListItem Value="115200">115200</asp:ListItem>
                                                                    <asp:ListItem Value="128000">128000</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text="Paridad"></asp:Label>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboParity" runat="server" Width="120px">
                                                                    <asp:ListItem Value="Even">Even</asp:ListItem>
                                                                    <asp:ListItem Value="Odd">Odd</asp:ListItem>
                                                                    <asp:ListItem Value="None" Selected="True">None</asp:ListItem>
                                                                    <asp:ListItem Value="Mark">Mark</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Bits de Datos"></asp:Label>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboDataBits" runat="server" Width="120px">
                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                    <asp:ListItem Value="8" Selected="True">8</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text="Bits de Parada"></asp:Label>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboStopBits" runat="server" Width="120px">
                                                                    <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="btnCrear" runat="server" Text="Configurar" OnClick="btnCrear_Click" />
                                                                <input class="Button" visible="false" id="AcceptButton" type="submit" value="Configurar" name="AcceptButton"
                                                                    runat="server" />
                                                                <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        
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