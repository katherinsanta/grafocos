<%@ Page Language="c#" Codebehind="Empleados.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Empleados"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" style="height: 100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" style="width: 100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-left: 40px; padding-right: 30px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
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
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1288, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1124, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1070, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1084, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(342, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label7" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1067, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('Empleado.aspx?IdEmpleado=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "CodigoEmpleado")))%>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowTextCentred" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "CodigoEmpleado") %>'></td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "CodigoEmpleado") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "CedulaEmpleado") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "EstadoEmpleado") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "NombreEmpleado") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "TipoEmpleado") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <a href="Identificadores.aspx?IdEmpleado=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "CodigoEmpleado")))%>&Nombre=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "NombreEmpleado")))%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Servipunto.Estacion.Web.Global.Idioma)%></a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr align="center">
                                                            <td bgcolor="White" align="center" valign="middle" colspan="7">
                                                                <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                                &nbsp; <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1806, Servipunto.Estacion.Web.Global.Idioma)%></td>
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
