<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RegistroOtrosIngresos.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.RegistroOtrosIngresos" 
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate">
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
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Codigo</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Fecha</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Hora</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Otros Ingresos</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Valor</td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowText" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>
                                                                <%# DataBinder.Eval(Container.DataItem, "Id")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Fecha", "{0:yyyy-MM-dd}")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Hora")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Nombre")%>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Valor")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="6">
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
