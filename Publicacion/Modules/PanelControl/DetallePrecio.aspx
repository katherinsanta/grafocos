<%@ Page Language="c#" Codebehind="DetallePrecio.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.DetallePrecio"
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
                                    <td style="padding-left: 40px; padding-right: 30px">
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate">
                                        <table width="100%">
                                            <tr>
                                                <td class="ActionsHeader" align="right">
                                                    <span id="Acciones" runat="server">Actions</span>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="100%">
                                            <asp:Repeater ID="Results" runat="server">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            Artículo</td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            Manguera</td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            Precio</td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            Estado</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="RowItem" onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                        <td class="RowTextCentred" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "NombreArticulo") %>
                                                        </td>
                                                        <td class="RowTextCentred" valign="middle" align="right">
                                                            <%# DataBinder.Eval(Container.DataItem, "MangueraArticulo") %>
                                                        </td>
                                                        <td class="RowTextCentred" valign="middle" align="right">
                                                            <%# DataBinder.Eval(Container.DataItem, "PrecioArticulo") %>
                                                        </td>
                                                        <td class="RowTextCentred" valign="middle" align="right">
                                                            <%# DataBinder.Eval(Container.DataItem, "EstadoAplicacion") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr>
                                                        <td bgcolor="White" align="right" valign="middle" colspan="4">
                                                            <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                            &nbsp;elemento(s)</td>
                                                    </tr>
                                                </FooterTemplate>
                                            </asp:Repeater>
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