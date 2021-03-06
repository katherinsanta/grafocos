<%@ Page Language="c#" Codebehind="Puertos.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Puertos"
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
                                                            <td class="ResultsHeader2" valign="middle" align="center" style="width: 10%">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1288, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center" style="width: 15%">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1814, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center" style="width: 20%">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1290, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center" style="width: 20%">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1291, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center" style="width: 20%">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1292, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center" style="width: 25%">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1293, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('Puerto.aspx?Id=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "IdPuerto")))%>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowTextCentred" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdPuerto") %>'></td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "IdPuerto") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "BaudRate") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Parity") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "DataBits") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Stop") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="center" valign="middle" colspan="6">
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
