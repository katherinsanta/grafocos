<%@ Page Language="c#" Codebehind="Clientes.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Clientes"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table  cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <!-- Topic Body -->
            <td valign="top" width="100%">
                <!-- Topic Content -->
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td style="height: 353px">
                            <br />
                            <p>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                            <input id="HiddenUpdate" type="hidden" name="HiddenUpdate" runat="server" />
                            <table width="100%">
                                <tr>
                                    <td class="ActionsHeader" align="right">
                                        <p>
                                            <span id="Acciones" runat="server">Actions</span>
                                        </p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server" Width="100%">
                                            <table id="TabControl" width="100%">
                                                <!-- fin de los tabs para cuentas -->
                                                <!-- Inicio fila para cuentas Estandar -->
                                                <tr class="Oculto" id="FilaTab1">
                                                    <td colspan="5">
                                                        <table class="ResultsTable" id="Table2" cellspacing="1" cellpadding="4" width="100%"
                                                            border="0">
                                                            <tr>
                                                                <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                    <table id="Table3" width="100%">
                                                                        <tr>
                                                                            <td style="width: 745px" width="745">
                                                                                <asp:Label ID="lblTituloGenerales" runat="server">
																									<b>Buscar por</b></asp:Label></td>
                                                                            <td align="right" width="5%">
                                                                                <asp:LinkButton ID="btnBuscar" runat="server" Height="4px" Width="50px">Buscar</asp:LinkButton></td>
                                                                            <td align="right" width="5%">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ResultsItem" valign="middle" align="left">
                                                                    <!-- Tabla que contiene las entradas generales -->
                                                                    <table id="TablaGeneral" cellpadding="4" width="100%" border="0">
                                                                        <tr>
                                                                            <td style="width: 105px" valign="top">
                                                                                <asp:Label ID="Label1" runat="server" Text="Dato a buscar"></asp:Label></td>
                                                                            <td style="width: 185px">
                                                                                <asp:TextBox ID="txtBuscar2" runat="server" Width="168px" ></asp:TextBox><asp:TextBox
                                                                                    ID="txtBuscar" runat="server" Visible="False" Width="8px"></asp:TextBox></td>
                                                                            <td style="width: 89px">
                                                                                <asp:Label ID="Label2" runat="server" Text="Buscar por"></asp:Label>:</td>
                                                                            <td style="width: 102px">
                                                                                <asp:DropDownList ID="ddlCriterioBusqueda" runat="server">
                                                                                    <asp:ListItem Value="4">Cedula</asp:ListItem>
                                                                                    <asp:ListItem Value="6">Ciudad</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Codigo</asp:ListItem>
                                                                                    <asp:ListItem Value="5">Forma de pago</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Nombre</asp:ListItem>
                                                                                    <asp:ListItem Value="2" Selected="True">Nit</asp:ListItem>
                                                                                    <asp:ListItem Value="7">Placa</asp:ListItem>
                                                                                    <asp:ListItem Value="8">Tipo Automotor</asp:ListItem>
                                                                                </asp:DropDownList></td>
                                                                            <td style="width: 173px">
                                                                                <asp:Label ID="Label3" runat="server" Text="Registros por pagina"></asp:Label>:</td>
                                                                            <td style="width: 40px">
                                                                                <asp:DropDownList ID="ddlRegistrosPorPagina" runat="server">
                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                                    <asp:ListItem Value="40">40</asp:ListItem>
                                                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                                                </asp:DropDownList></td>
                                                                            <td style="width: 85px">
                                                                                <asp:Label ID="Label4" runat="server" Text="Ir a pagina"></asp:Label>:</td>
                                                                            <td>
                                                                                <p align="left">
                                                                                    <asp:DropDownList ID="ddlNumeroPagina" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                                                    </asp:DropDownList></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 105px" valign="top">
                                                                                <asp:Label ID="Label5" runat="server" Text="Ordenar por"></asp:Label>:</td>
                                                                            <td style="width: 185px">
                                                                                <asp:RadioButtonList ID="rbtOrden" runat="server" Height="16px" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="2">Nombre</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Identificaci&#243;n</asp:ListItem>
                                                                                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                                </asp:RadioButtonList></td>
                                                                            <td style="width: 89px">
                                                                            </td>
                                                                            <td style="width: 102px">
                                                                                <asp:CheckBox ID="cbxContenga" runat="server" 
                                                                                    Text="Contega"></asp:CheckBox></td>
                                                                            <td style="width: 173px">
                                                                            </td>
                                                                            <td style="width: 40px">
                                                                            </td>
                                                                            <td style="width: 85px">
                                                                                <p align="center">
                                                                                    <asp:LinkButton ID="lblanterior" runat="server" Height="4px" Width="18px" ><<</asp:LinkButton><asp:LinkButton
                                                                                        ID="lblSiguiente" runat="server" Height="4px" Width="13px" >>></asp:LinkButton></p>
                                                                            </td>
                                                                            <td>
                                                                                <p align="left">
                                                                                    <asp:Label ID="lblTotalPaginas" runat="server" >0/0</asp:Label></p>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- Inicio Repeat para mostrar los clientes -->
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                Sel.</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1092, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label7" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(855, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label>
                                                            </td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                NIT</td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label9" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(307, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('Cliente.aspx?IdCliente=<%#EncryptText(Convert.ToString( DataBinder.Eval(Container.DataItem, "CodigoCliente"))) %>');"
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowText" valign="middle">
                                                                <input type="checkbox" name="chkID" value='<%# DataBinder.Eval(Container.DataItem, "CodigoCliente") %>'></td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "NombreCliente") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "DireccionCliente") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "EstadoCliente") %>
                                                            </td>
                                                            <td class="RowText" valign="middle">
                                                                <%# DataBinder.Eval(Container.DataItem, "NitCedulaCliente") %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle">
                                                                <a href="Automotores.aspx?IdCliente=<%#EncryptText(Convert.ToString( DataBinder.Eval(Container.DataItem, "CodigoCliente") ))%>&IdNombreCliente=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "NombreCliente")))%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1862, Servipunto.Estacion.Web.Global.Idioma)%>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                            <!--Fin del repeat para mostrar clientes-->
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
