<%@ Page Language="c#" Codebehind="Usuarios.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Usuarios"
    MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

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
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate">
                                        <table width="100%">
                                            <tr>
                                                <td class="LinkTbla" align="right">
                                                    <span id="Acciones" runat="server"><a style="color: black" href="Grupo.aspx">Crear</a>
                                                        &nbsp;|&nbsp; <a style="color: black" href="javascript:document.forms[0].submit();">Eliminar</a>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Repeater ID="Results" runat="server" OnItemDataBound="Results_ItemDataBound">
                                            <HeaderTemplate>
                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                    <tr>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(739, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(966, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="RowItem" ondblclick="window.navigate('Usuario.aspx?Id=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "IdUsuario")))%>');"
                                                    onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                    <td class="RowText" valign="middle">
                                                        <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdUsuario") %>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "IdUsuario") %>
                                                    </td>
                                                    <td class="RowText" valign="middle">
                                                        <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                                                    </td>
                                                    <td class="RowText" valign="middle">
                                                        <%# DataBinder.Eval(Container.DataItem, "Rol") %>
                                                    </td>
                                                    <td class="RowText" valign="middle">
                                                        <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Estado") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <tr>
                                                    <td bgcolor="White" align="center" valign="middle" colspan="4">
                                                        <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                        &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1770, Servipunto.Estacion.Web.Global.Idioma)%></td>
                                                </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
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
