<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfiguracionSorteos.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.PanelControl.ConfiguracionSorteos" 
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
                                                        <span id="Acciones" runat="server"><a style="color: blue" href="ConfiguracionSorteo.aspx">
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
                                                                IdSorteo</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Articulos</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Valor Minimo</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='Consecutivo Inicial'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text='Consecutivo Final'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label11" runat="server" Text='Fecha Inicial'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='Fecha Final'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='Multiples'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='Estado'></asp:Label></td>  
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="RowItem" ondblclick="window.navigate('ConfiguracionSorteo.aspx?IdSorteo=<%# DataBinder.Eval(Container.DataItem, "IdSorteo") %>');"
                                                        onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                        <td class="RowText" valign="middle">
                                                            <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdSorteo") %>'>
                                                        </td>
                                                       
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "Articulos") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "ValorMinimo") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "ConsecutivoInicial") %>
                                                        </td>
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "ConsecutivoActual")%>
                                                        </td>
                                                        
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "FechaInicio", "{0:d}")%>
                                                        </td>
                                                        
                                                        <td class="RowText" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "FechaFinal", "{0:d}")%>
                                                        </td>
                                                       
                                                       
                                                        <td class="RowText" valign="middle">
                                                            <asp:Label ID="Label12" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "MultiplesBoletas") %>'></asp:Label>
                                                        </td>
                                                        
                                                         <td class="RowText" valign="middle">
                                                            <asp:Label ID="Label6" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Estado") %>'></asp:Label>
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
