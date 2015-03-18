<%@ Page Language="c#" Codebehind="Automotores.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Automotores"
    ValidateRequest="false" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" >
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
                                            <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <span id="Acciones" runat="server">Actions</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCliente" runat="server" Visible="true" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr class="ResultsTable">
                                                            <td  valign="middle" align="center">
                                                                Sel</td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(318, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label>
                                                            </td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(858, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(551, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(526, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label7" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(535, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td  valign="middle" align="center">
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(550, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('Automotor.aspx?IdAutomotor=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "PlacaAutomotor")))%>&IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowTextCentred" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "PlacaAutomotor") %>'></td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "PlacaAutomotor") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "CodigoFormaDePagoAutomtor") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "CodigoCausalDeBloqueoAutomotor") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "DescuentoAutomtor") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <a href="Identificadores.aspx?IdAutomotor=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "PlacaAutomotor"))) %>&IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Servipunto.Estacion.Web.Global.Idioma)%>
                                                                </a>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <a href="Combustibles.aspx?Placa=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "PlacaAutomotor")))%>&IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Servipunto.Estacion.Web.Global.Idioma)%>
                                                                </a>
                                                            </td>
                                                            <!--<td class="RowTextCentred" valign="middle"><a href="Creditos.aspx?Placa=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "PlacaAutomotor")))%>>&IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>&Numero=0">Ver</a></td>-->
                                                            <td class="RowTextCentred" valign="middle">
                                                                <a href="Creditos.aspx?Placa=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "PlacaAutomotor")))%>&Numero=0">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Servipunto.Estacion.Web.Global.Idioma)%>
                                                                </a>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <a href="Restricciones_.aspx?Placa=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "PlacaAutomotor")))%>&IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Servipunto.Estacion.Web.Global.Idioma)%>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr align="center">
                                                            <td bgcolor="White" align="center" valign="middle" colspan="10">
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
