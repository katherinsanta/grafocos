<%@ Page Language="c#" Codebehind="ConfVentasGratis.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.ConfVentasGratis"
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
                                    <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="Label13" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                        <br />
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <span id="Acciones" runat="server"><a style="color: blue" href="ConfVentaGratis.aspx">
                                                            Crear</a> &nbsp;|&nbsp; <a style="color: blue" href="javascript:document.forms[0].submit();">
                                                                Eliminar</a> </span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <p>
                                                </p>
                                            <asp:Repeater ID="Results" runat="server" OnItemDataBound="Results_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Id</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Frec.</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Sum</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(583, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1480, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1481, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1482, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1483, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1484, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label7" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1485, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1486, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label9" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1487, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label10" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1488, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                %</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label11" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1489, Servipunto.Estacion.Web.Global.Idioma) %>'></asp:Label></td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="RowItem" ondblclick="window.navigate('ConfVentaGratis.aspx?IdConfVentaGratis=<%# DataBinder.Eval(Container.DataItem, "IdConfVentaGratis") %>');"
                                                        onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                        <td class="RowText" valign="middle">
                                                            <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdConfVentaGratis") %>'>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "Frecuencia") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "Acumulado") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "Puerto") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "FecInicial", "{0:d}") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "FecFinal", "{0:d}") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "HorInicial")) == 24 ? "Undefined" : Convert.ToInt32(DataBinder.Eval(Container.DataItem, "HorInicial")) > 12 ? (Convert.ToInt32(DataBinder.Eval(Container.DataItem, "HorInicial")) - 12).ToString() + ":00 p.m." : DataBinder.Eval(Container.DataItem, "HorInicial") + ":00 a.m."%>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "HorFinal")) == 24 ? "Undefined" : Convert.ToInt32(DataBinder.Eval(Container.DataItem, "HorFinal")) > 12 ? (Convert.ToInt32(DataBinder.Eval(Container.DataItem, "HorFinal")) - 12).ToString() + ":00 p.m." : DataBinder.Eval(Container.DataItem, "HorFinal") + ":00 a.m."%>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "TipoAutomotor").ToString().Length == 0? "ALL" : DataBinder.Eval(Container.DataItem, "TipoAutomotor") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <asp:Label ID="Label12" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Estado") %>'></asp:Label>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "NomCodForPag") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "NomCodForPagConf") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "TiempoAlarma").ToString() + " seg." %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "Porcentaje").ToString() + " %" %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "ValorMaximo") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr>
                                                        <td bgcolor="White" align="center" valign="middle" colspan="15">
                                                            <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                            &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1806, Servipunto.Estacion.Web.Global.Idioma) %></td>
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
