<%@ Page Language="c#" Codebehind="ListaPrecioDiferencial.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.Comerciales.ListaPrecioDiferencial"
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
                            <table cellspacing="0"  style="padding-left:30px; padding-top:20px;" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="300" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Título</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lbGuardar" runat="server">Guardar</asp:LinkButton>&nbsp;<asp:HyperLink
                                                                        ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" width="100%" border="0">
                                                            <tr>
                                                                <td style="width: 87px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>:</td>
                                                                <td style="width: 193px">
                                                                    <asp:TextBox ID="txtCodigo" runat="server" Width="120px"></asp:TextBox></td>
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
