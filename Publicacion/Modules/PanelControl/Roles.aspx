<%@ Page Language="c#" Codebehind="Roles.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Roles"
    MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-left: 40px; padding-right: 30px">
                                        <!-- Custom Content -->
                                        <br />
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                        <table width="100%">
                                            <tr>
                                                <td  align="right">
                                                    <span id="Acciones" runat="server">
                                                    <a style="color:Black;" href="Default.aspx">Nuevo</a>
                                                    &nbsp;|&nbsp; <a class="LinkTbla" href="javascript:document.forms[0].submit();">Eliminar</a>
                                                    &nbsp;|&nbsp; <a style="color:Black;" href="Default.aspx">Volver</a> </span>
                                                </td>
                                            </tr>
                                        </table>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <asp:Repeater ID="Results" runat="server">
                                                <HeaderTemplate>
                                                    <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" colspan="2">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1695,Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="RowItem" ondblclick="window.navigate('Rol.aspx?Id=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "IdRol")))%>');"
                                                        onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                        <td class="RowText" valign="middle">
                                                            <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdRol") %>'>
                                                            <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                                                        </td>
                                                        <td class="RowText" valign="middle" width="130">
                                                            <a class="LinkTbla" href="Permisos.aspx?Id=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "IdRol")))%>">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1044,Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></a>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr>
                                                        <td bgcolor="White" align="center" valign="middle" colspan="2">
                                                            <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                            &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1755, Servipunto.Estacion.Web.Global.Idioma)%></td>
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
