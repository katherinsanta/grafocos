<%@ Page Language="c#" Codebehind="Upd_SUIC.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Upd_SUIC"
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
                            <table cellspacing="0" style="padding-left:20px; padding-top:20px;" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <span id="Acciones" runat="server">Actions</span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0">
                                                <tr>
                                                    <td class="RowText">
                                                        Buscar Placa:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPlaca" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnBuscarPlaca" Text="Buscar" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0">
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Placa</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Cliente
                                                            </td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Forma Pago
                                                            </td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Placa") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "Descripcion") %>
                                                            </td>
                                                            <td>
                                                                <input type="button" value="Asignar Nuevo Cliente" id="Button1" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="right" valign="middle" colspan="4">
                                                                <%# DataBinder.Eval(Results.DataSource, "Tables[0].Rows.Count")%>
                                                                &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1806, 1)%></td>
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
        <!-- End Page Body -->
    </table>
</asp:Content>
