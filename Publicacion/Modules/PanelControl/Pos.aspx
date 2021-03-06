<%@ Page Language="c#" Codebehind="Pos.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Pos"
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
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="350">
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
                                                                    <asp:Label ID="Label1" runat="server" Text="N�mero del POS"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtId" runat="server" MaxLength="2" Width="100px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text="N�mero del Capturador"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIdCapturador" runat="server" MaxLength="2" Width="100px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="N�mero de la Isla"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIdIsla" runat="server" MaxLength="2" Width="100px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 27px">
                                                                    Maneja PolyDisplay:</td>
                                                                <td style="height: 27px">
                                                                    <asp:DropDownList ID="ddlManejaPolyDisplay" runat="server" Width="100px" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlManejaPolyDisplay_SelectedIndexChanged">
                                                                        <asp:ListItem Selected="True">No</asp:ListItem>
                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Puerto PolyDisplay:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlPuertos" runat="server" Width="100px" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlManejaPolyDisplay_SelectedIndexChanged" Enabled="False">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    Modelo &nbsp;PolyDisplay:</td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="ddlModeloPolyDisplay" runat="server" Width="187px" AutoPostBack="True"
                                                                        Enabled="False">
                                                                        <asp:ListItem>BCD-1100</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" visible="false" id="AcceptButton" type="submit" value="Crear"
                                                                        name="AcceptButton" runat="server" />
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
