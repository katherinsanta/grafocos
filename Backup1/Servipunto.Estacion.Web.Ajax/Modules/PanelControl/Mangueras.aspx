<%@ Page Language="c#" Codebehind="Mangueras.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Mangueras"
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
                                        <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <span id="Acciones" runat="server">Actions</span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                <tr>
                                                    <td bgcolor="white" colspan="6">
                                                        <asp:Label ID="lblTitle" runat="server">Titulo</asp:Label></td>
                                                </tr>
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1630, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(152, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1378, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1299, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1070, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(81, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('Manguera.aspx?IdManguera=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "IdManguera")))%>&IdCara=<%=Request.QueryString["IdCara"]%>&IdSurtidor=<%=Request.QueryString["IdSurtidor"]%>&IdIsla=<%=Request.QueryString["IdIsla"]%>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowText" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdManguera") %>'>
                                                                <%# DataBinder.Eval(Container.DataItem, "IdManguera") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Articulo") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Grado") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "IdLector") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "DescripcionEstado") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "IdTanque") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="6">
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
