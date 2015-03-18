<%@ Page Language="c#" Codebehind="Tanque.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Tanque"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="456"
                                                style="width: 456px; height: 267px">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server" NavigateUrl="Tanques.aspx">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 454px">
                                                        <table cellpadding="4" border="0" style="width: 440px; height: 203px">
                                                            <tr id="filaCodigo" runat="server">
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtId" runat="server" MaxLength="100" Width="100px" Enabled="False"></asp:TextBox>
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCapacidad" Width="100px" MaxLength="100" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label5" runat="server" Text="% Minimo Disponible:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPorcMinimoDisponible" runat="server" MaxLength="100" 
                                                                        Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Label ID="lblAviso" runat="server" ForeColor="Yellow" 
                                                                        Text="Cuando el  % del volumen disponible del tanque sea menor  a este  porcentaje, se enviara via electronico un mensaje indicando el agotamiento del tanque , para que se realize una nueva compra."></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboArticulo" runat="server" Width="264px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkLitrosAGalones" runat="server" Text="Convierte de litros a galones en variación (Incon)">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label1" runat="server">Variación o Balace:</asp:Label></td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblGasOLiquido" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="0" Selected="True">Liquido</asp:ListItem>
                                                                        <asp:ListItem Value="1">Gas</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" visible="false" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                        runat="server"/>
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
