<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Conductores.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Conductores"
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
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="100%">
                                                <tr>
                                                    <td bgcolor="white" valign="middle" colspan="9">
                                                        <asp:Label ID="Display" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Sel</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Codigo</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Nombre</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Identificación</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Autorizado</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Identificadores</td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr ondblclick="window.navigate('Conductor.aspx?IdConductor=<%# DataBinder.Eval(Container.DataItem, "Idconductor") %>');"
                                                         class="RowItem" onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">                                                              
                                                       
                                                            <td class="RowTextCentred" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "Idconductor") %>'></td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Codigo") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Identificacion") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Autorizacion") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <a href="IdentificadoresConductor.aspx?IdConductor=<%#EncryptText(Convert.ToString( DataBinder.Eval(Container.DataItem, "IdConductor") ))%>">
                                                                    Ver</a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="6">
                                                                <%# DataBinder.Eval(Results.DataSource, "Count") %>
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
