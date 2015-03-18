<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Conductor.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Conductor"
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
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lbGuardar" runat="server">Guardar</asp:LinkButton>
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 452px; height: 137px">
                                                        <table cellpadding="4" width="100%" border="0">
                                                            <tr>
                                                                <td style="width: 65px">
                                                                    Código:</td>
                                                                <td style="width: 193px">
                                                                    <asp:TextBox ID="txtCodigo" runat="server" Width="120px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 65px; height: 30px;">
                                                                    Nombre:</td>
                                                                <td style="width: 193px; height: 30px;">
                                                                    <asp:TextBox ID="txtNombre" runat="server" Width="470px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 65px; height: 21px">
                                                                    Identificación:</td>
                                                                <td style="width: 193px; height: 21px">
                                                                    <asp:TextBox ID="txtIdentificacion" runat="server" Width="469px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 65px">
                                                                    Autorizado:</td>
                                                                <td style="width: 193px">
                                                                    <asp:DropDownList ID="ddlAutorizado" runat="server" Width="69px">
                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
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
    </table>
</asp:Content>
