<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrosCompraCanastilla.aspx.cs" 
Inherits="Servipunto.Estacion.Web.Ajax.Modules.Procesos.RegistrosCompraCanastilla" 
MasterPageFile="~/PaginaMaestra/actualizacion.Master"%>
<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label><p/>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate"/>
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
                                                    <headerTemplate>
                                                        <tr>                                                            
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Id</td>
                                                                
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Fecha</td>
                                                                
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Hora</td>
                                                                
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Articulo</td>
                                                                                                                                
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Cantidad Anterior</td>
                                                                
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Compra</td>
                                                                
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Cantidad Actual</td>
                                                        </tr>
                                                    </headerTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowText" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdCompra") %>'>
                                                               
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Fecha", "{0:yyyy-MM-dd}")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Hora", "{0:hh:mm:ss}")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Articulo")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "CantidadAnterior")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Compra")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "CantidadActual")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="7">
                                                                <%# Results.Items.Count %>
                                                                &nbsp;elemento(s)</td>
                                                        </tr>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </asp:Panel>
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
    </table>
</asp:Content>


