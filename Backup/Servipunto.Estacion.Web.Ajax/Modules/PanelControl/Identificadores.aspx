<%@ Page Language="c#" Codebehind="Identificadores.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Identificadores"
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
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate">
                                        <table width="100%">
                                            <tr>
                                                <td class="ActionsHeader" align="right">
                                                    <span id="Acciones" runat="server">Actions</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblNombre" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                            <asp:Repeater ID="Results" runat="server" OnItemDataBound="Results_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1104, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label>
                                                        </td>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2016, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        <%if(Request.QueryString["IdEmpleado"] == null && Request.QueryString["IdEmpleado"] == ""){%>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        <%}%>
                                                        <td class="ResultsHeader2" valign="middle" align="center">
                                                            <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1127, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="RowItem" ondblclick=" window.navigate('Identificador.aspx?IdIdentificador=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "NumeroIdentificador")))%>&IdEmpleado=<%=Request.QueryString["IdEmpleado"]%>&Nombre=<%=Request.QueryString["Nombre"]%>'); "
                                                        onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                        <td class="RowTextCentred" valign="middle">
                                                            <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "NumeroIdentificador") %>'></td>
                                                        <td class="RowTextCentred" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "NumeroIdentificador") %>
                                                        </td>
                                                        <td class="RowTextCentred" valign="middle">
                                                            <img height="16" width="16" src="../../BlueSkin/Icons/2011/<%#DataBinder.Eval(Container.DataItem, "IdentificadorActivo")%>-16.png"
                                                                alt="<%#DataBinder.Eval(Container.DataItem, "IdentificadorActivo")%>" />
                                                        </td>
                                                        <td class="RowTextCentred" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "IdRom") %>
                                                        </td>
                                                        <%if(Request.QueryString["IdEmpleado"] == null && Request.QueryString["IdEmpleado"] == ""){%>
                                                        <td class="RowTextCentred" valign="middle">
                                                            <%# DataBinder.Eval(Container.DataItem, "Placa") %>
                                                        </td>
                                                        <%}%>
                                                        <td class="RowTextCentred" valign="middle">
                                                            <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoIdentificador") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr align="center">
                                                        <td bgcolor="White" align="center" valign="middle" colspan="6">
                                                            <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                            &nbsp;<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1806, Servipunto.Estacion.Web.Global.Idioma)%></td>
                                                    </tr>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </table>
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