<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Restricciones_.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Restricciones_" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
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
                    </table>
                    <table class="ResultsTable" cellspacing="1" width="100%" border="0">
                        <tr>
                            <td bgcolor="white" valign="middle" colspan="4">
                                <asp:Label ID="Display" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <asp:Repeater ID="Results" runat="server" OnItemDataBound="Results_ItemDataBound">
                            <HeaderTemplate>
                                <tr>
                                    <td class="ResultsHeader2" valign="middle" align="center" width="10%">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(775, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                    <td class="ResultsHeader2" valign="middle" align="center" width="10%">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2046, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                    <td class="ResultsHeader2" valign="middle" align="center" width="15%">
                                        <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(452, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                    <td class="ResultsHeader2" valign="middle" align="center" width="20%">
                                        <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(458, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="RowItem" ondblclick="window.navigate('Restriccion.aspx?Placa=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "Placa")))%>&IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>&Dia=<%# DataBinder.Eval(Container.DataItem, "Dia")%>&HoraInicio=<%# DataBinder.Eval(Container.DataItem, "HoraInicio") %>'); "
                                    onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                    <td class="RowTextCentred" valign="middle">
                                        <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "placa") %>&<%# DataBinder.Eval(Container.DataItem, "dia")%>&<%# DataBinder.Eval(Container.DataItem, "horaInicio") %>'></td>
                                    <td class="RowTextCentred" valign="middle">
                                        <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NombreDia") %>'></asp:Label>
                                    </td>
                                    <td class="RowTextCentred" valign="middle">
                                        <%# DataBinder.Eval(Container.DataItem, "HoraInicioDisplay") %>
                                    </td>
                                    <td class="RowTextCentred" valign="middle">
                                        <%# DataBinder.Eval(Container.DataItem, "HoraFinDisplay") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr>
                                    <td bgcolor="White" align="center" valign="middle" colspan="4">
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
</asp:Content>
