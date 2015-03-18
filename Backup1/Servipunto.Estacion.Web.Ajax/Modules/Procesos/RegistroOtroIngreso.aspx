<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RegistroOtroIngreso.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.RegistroOtroIngreso" 
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
                                        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Título</asp:Label></td>
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
                                                                    <asp:Label ID="Label1" runat="server" Text="Nombre de Otro Ingreso:"></asp:Label></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlConcenptosOtrosIngresos" runat="server">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text="Valor:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <input class="Button" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                        runat="server" onserverclick="AcceptButton_ServerClick" />
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
