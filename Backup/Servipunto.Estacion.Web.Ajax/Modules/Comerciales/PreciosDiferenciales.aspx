<%@ Page Language="c#" Codebehind="PreciosDiferenciales.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.Comerciales.PreciosDiferenciales"
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
                                    <td>
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />&nbsp;
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <asp:LinkButton ID="lbAgregarLista" runat="server">Agregar Artículo</asp:LinkButton>
                                                        &nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lbEliminar" runat="server">Eliminar Precios Seleccionados</asp:LinkButton>&nbsp;|&nbsp;
                                                        <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="ListaPreciosDiferenciales.aspx">Volver</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="50%">
                                                <tr>
                                                    <td bgcolor="white" valign="middle" colspan="3">
                                                        <b>
                                                            <asp:Label ID="Label1" runat="server" Text="Lista de Precios"></asp:Label>:</b>
                                                        <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="True" Width="120px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <asp:Repeater ID="Results" runat="server" OnItemDataBound="Results_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Sel</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('PrecioDiferencial.aspx?IdPrecio=<%# DataBinder.Eval(Container.DataItem, "IdPrecioDiferencial") %>&CodigoArticulo=<%# DataBinder.Eval(Container.DataItem, "CodigoArticulo") %>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowTextCentred" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdPrecioDiferencial") %>|<%# DataBinder.Eval(Container.DataItem, "CodigoArticulo") %>'></td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NombreArticulo") %>'></asp:Label> 
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <%# DataBinder.Eval(Container.DataItem, "PrecioDiferencialArticulo") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="3">
                                                                <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                                &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1806, Servipunto.Estacion.Web.Global.Idioma)%></td>
                                                        </tr>
                                                    </FooterTemplate>
                                                </asp:Repeater>
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
