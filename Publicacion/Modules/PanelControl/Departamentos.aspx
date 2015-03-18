<%@ Page Language="c#" Codebehind="Departamentos.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Departamentos"
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
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <!-- Custom Content -->
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate">
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <asp:LinkButton ID="lnkNuevo" runat="server" ForeColor="black">Crear un Nuevo Departamento</asp:LinkButton>
                                                        &nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lnkEliminar" runat="server" ForeColor="black">Eliminar los Departamentos Seleccionados</asp:LinkButton>
                                                        <span id="Acciones" runat="server">&nbsp;|&nbsp; <a style="color: black" href="Default.aspx">
                                                            Volver</a> </span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                <tr>
                                                    <td id="Sec" runat="server" class="RowItem" valign="middle" colspan="2">
                                                        <asp:Label ID="Label1" runat="server" Text="Pais"></asp:Label>
                                                        :
                                                        <asp:DropDownList ID="cboPais" runat="server" Width="150px" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" colspan="2">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1145, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('Departamento.aspx?IdPais=<%#DataBinder.Eval(Container.DataItem, "IdPais")%>&IdDpto=<%#EncryptText(Convert.ToString( DataBinder.Eval(Container.DataItem, "IdDepartamento"))) %>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowText" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "IdDepartamento") %>'>
                                                                <%# DataBinder.Eval(Container.DataItem, "Nombre") %>
                                                            </td>
                                                            <td class="RowText" valign="middle" width="150">
                                                                <a style="color: blue" href="Ciudades.aspx?IdDpto=<%#EncryptText(Convert.ToString( DataBinder.Eval(Container.DataItem, "IdDepartamento"))) %>&IdPais=<%#DataBinder.Eval(Container.DataItem, "IdPais")%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1539, Servipunto.Estacion.Web.Global.Idioma)%>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="center" valign="middle" colspan="2">
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
