<%@ Page Language="c#" Codebehind="Grupos.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Grupos"
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
                                    <td style="padding-left: 40px; padding-right: 30px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <span id="Acciones" runat="server">Actions</span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1089, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1085, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('Grupo.aspx?Id=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "IdGrupo")))%>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowText" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdGrupo") %>'>
                                                                <%# DataBinder.Eval(Container.DataItem, "IdGrupo") %>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Descripcion") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="3">
                                                                <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                                &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1470, Servipunto.Estacion.Web.Global.Idioma)%></td>
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
