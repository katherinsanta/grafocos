<%@ Page Language="c#" Codebehind="Bol_NumOrdenes.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Bol_NumOrdenes" 
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
                                    </br>
                                    <p>
                                    <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <br />
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <asp:Panel ID="pnlAlertaResolucion" runat="server" Width="100%" Visible="false">
                                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                                    width="400" height="20">
                                                    <param name="movie" value="../../BlueSkin/Aviso_ResolucionesPendientes.swf" />
                                                    <param name="quality" value="high" />
                                                    <embed src="../../BlueSkin/Aviso_ResolucionesPendientes.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                        type="application/x-shockwave-flash" width="400" height="20"></embed>
                                                </object>
                                            </asp:Panel>
                                            <table width="100%">
                                                <asp:Panel ID="PnlDiferenciaAviso" runat="server" Width="100%" Visible="false">
                                                    <tr>
                                                        <asp:Label ID="lblDiferencia" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <span id="Acciones" runat="server"><a style="color: blue" href="Bol_NumOrden.aspx">Crear</a>
                                                            &nbsp;|&nbsp; <a style="color: blue" href="javascript:document.forms[0].submit();">Eliminar</a>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <p>
                                                
                                            <asp:Repeater ID="Results" runat="server" OnItemDataBound="Results_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1512, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1513, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1514, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1515, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1516, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1524, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label7" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1718, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1719, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="RowItem" ondblclick="window.navigate('Bol_NumOrden.aspx?IdNumOrden=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "IdNumOrden"))) %>');"
                                                        onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "NumOrder") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "Prefijo") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "IniConsec") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "FinConsec") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# this.MostrarMensaje(DataBinder.Eval(Container.DataItem, "Estado"))%>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Regimen") %>'></asp:Label> 
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "FechaInicial", "{0:d}")%>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "FechaFinal", "{0:d}")%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr>
                                                        <td bgcolor="White" align="center" valign="middle" colspan="8">
                                                            <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                            &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1806, Servipunto.Estacion.Web.Global.Idioma)%></td>
                                                    </tr>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
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
