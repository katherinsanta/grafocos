<%@ Page Language="c#" Codebehind="Capturador.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Capturador"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" style="height: 100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" style="width: 100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="392"
                                                style="width: 392px; height: 268px">
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
                                                        <table cellpadding="4" border="0" style="width: 368px; height: 204px">
                                                            <tr>
                                                                <td style="width: 170px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Número del Capturador:"></asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtId" runat="server" MaxLength="2" Width="100px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 169px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Capturador Via:"></asp:Label></td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblCapturador" runat="server" RepeatDirection="Horizontal"
                                                                        AutoPostBack="True">
                                                                        <asp:ListItem Value="1" Selected="True">Serial</asp:ListItem>
                                                                        <asp:ListItem Value="0">IP</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:CheckBox ID="chkVirtual" runat="server" Text="Virtual"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 169px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Puerto Serial:"></asp:Label></td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboPuerto" runat="server" Width="120px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 169px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Dirección IP Capturador:"></asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDireccionIp" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 169px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Puerto Escucha del Capturador:"></asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPuertoSocket" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 169px">
                                                                    <asp:Label ID="Label6" runat="server" Text="Direccion IP Servidor Externo:"></asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDireccionIp3ro" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 169px; height: 21px">
                                                                    <asp:Label ID="Label7" runat="server" Text="Puerto del Servidor Externo:"></asp:Label></td>
                                                                <td style="height: 21px">
                                                                    <asp:TextBox ID="txtPuertoSocket3ro" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 169px">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" visible="false" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                        runat="server" />
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
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
