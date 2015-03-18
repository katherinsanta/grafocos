<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" AutoEventWireup="true" CodeBehind="ConsolaTanque.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.PanelControl.ConsolaTanque" Title="Página sin título" %>
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
                                                                <td style="height: 15px">
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right" style="height: 15px">
                                                                    <asp:HyperLink ID="lblBack" runat="server" NavigateUrl="ConsolaTanques.aspx">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="lblHide" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 454px">
                                                        <table cellpadding="4" border="0" style="width: 440px; height: 203px">
                                                            <tr id="filaCodigo" runat="server">
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" Width="100px" Enabled="true"></asp:TextBox>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="lblProtocolo" runat="server" Text="Protocolo"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtProtocolo" Width="100px" MaxLength="100" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTipoConsola" runat="server" OnSelectedIndexChanged="ddlTipoConsola_SelectedIndexChanged"
                                                                        Width="103px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="lblDireccionIp" runat="server" Text="Direccion IP:"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDireccionIp" Width="100px" MaxLength="100" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="lblPuertoLogico" runat="server" Text="Puerto Logico:"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPuertoLogico" Width="100px" MaxLength="100" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="lblPuertoSerial" runat="server" Text="Puerto Serial"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPuertoSerial" Width="100px" MaxLength="100" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;<input class="Button" visible="False" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
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

