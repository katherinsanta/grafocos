<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Creaciones.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Prepagos.Creaciones"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="padding-left: 40px; padding-right: 30px">
                <br />
                <p>
                    <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                </p>
                <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate">
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
                                    <asp:Label ID="Label1" runat="server" Text=''></asp:Label></td>
                                <td class="ResultsHeader2" valign="middle" align="center">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(915, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                <td class="ResultsHeader2" valign="middle" align="center">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23589, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                <td class="ResultsHeader2" valign="middle" align="center">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23590, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                <td class="ResultsHeader2" valign="middle" align="center">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                <td class="ResultsHeader2" valign="middle" align="center">
                                    <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23591, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                <td class="ResultsHeader2" valign="middle" align="center">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(977, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="RowItem" onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                <td class="RowText" valign="middle" width="10%">
                                    <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdCreacion") %>'>
                                </td>
                                <td class="RowText" valign="middle" width="15%">
                                    <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "Fecha")).ToString("dd/MM/yyyy") %>
                                </td>
                                <td class="RowText" valign="middle" width="15%">
                                    <%# DataBinder.Eval(Container.DataItem, "NumeroInicialCreacion") %>
                                </td>
                                <td class="RowText" valign="middle" width="15%">
                                    <%# DataBinder.Eval(Container.DataItem, "NumeroFinalCreacion") %>
                                </td>
                                <td class="RowText" valign="middle" width="15%">
                                    <%# DataBinder.Eval(Container.DataItem, "CantidadPrepagosCreados") %>
                                </td>
                                <td class="RowText" valign="middle" width="15%">
                                    <%# DataBinder.Eval(Container.DataItem, "Denominacion", "{00:c}")%>
                                </td>
                                <td class="RowText" valign="middle" width="15%">
                                    <%# DataBinder.Eval(Container.DataItem, "TotalDenominacion", "{00:c}")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td bgcolor="White" align="right" valign="middle" colspan="9">
                                    <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                    &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1470, Servipunto.Estacion.Web.Global.Idioma)%></td>
                            </tr>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
                <p>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
    <!-- End Page Body -->
</asp:Content>
