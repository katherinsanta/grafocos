<%@ Page Language="c#" Codebehind="PreciosProgramados.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.PreciosProgramados" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <asp:Image ID="ImgHelp" ImageUrl="~/BlueSkin/Update/consultas-32.png" runat="server" />
                                            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
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
                                                                Sel</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1022, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1243, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label>
                                                                1</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1243, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label>
                                                                2</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1243, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label>
                                                                3</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1243, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label>
                                                                4</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label7" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(251, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick=" window.navigate('PrecioProgramado.aspx?Fecha=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "Fecha")))%>&IdArticulo=<%# DataBinder.Eval(Container.DataItem, "CodigoArticulo") %>'); "
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowTextCentred" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "Fecha") %>|<%# DataBinder.Eval(Container.DataItem, "CodigoArticulo") %>'></td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Fecha") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <%# DataBinder.Eval(Container.DataItem, "NombreArticulo") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <%# DataBinder.Eval(Container.DataItem, "PrecioArticulo") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <%# DataBinder.Eval(Container.DataItem, "Precio2Articulo") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <%# DataBinder.Eval(Container.DataItem, "Precio3Articulo") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <%# DataBinder.Eval(Container.DataItem, "Precio4Articulo") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <%# DataBinder.Eval(Container.DataItem, "EstadoProgramacion") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right">
                                                                <a href="DetallePrecio.aspx?Fecha=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "Fecha")))%>&IdArticulo=<%#DataBinder.Eval(Container.DataItem, "CodigoArticulo")%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Servipunto.Estacion.Web.Global.Idioma) %>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="9">
                                                                <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                                &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1806, Servipunto.Estacion.Web.Global.Idioma) %></td>
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
