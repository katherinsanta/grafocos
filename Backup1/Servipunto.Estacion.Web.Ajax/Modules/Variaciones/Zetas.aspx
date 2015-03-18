<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Zetas.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Variaciones.Zetas"
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
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate">
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <p>
                                                            <span id="Acciones" runat="server">Actions</span></p>
                                                        <p>
                                                            <span id="SPAN1" runat="server"></span>
                                                            <table class="ResultsTable" id="Table2" style="width: 696px; height: 62px" cellspacing="1"
                                                                cellpadding="4" width="696" align="center" border="0">
                                                                <tr>
                                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="height: 16px">
                                                                        <table id="Table3" width="100%">
                                                                            <tr>
                                                                                <td style="width: 500px" width="745">
                                                                                    <b><asp:Label ID="lblTituloGenerales" runat="server" Text="Buscar por">
																							</asp:Label></b></td>
                                                                                <td align="right" width="5%">
                                                                                    <asp:LinkButton ID="btnBuscar" runat="server" Width="50px" Height="4px">Buscar</asp:LinkButton></td>
                                                                                <td align="right" width="5%">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                        <!-- Tabla que contiene las entradas generales -->
                                                                        <table id="TablaGeneral" style="width: 496px; height: 10px" cellpadding="4" width="496"
                                                                            border="0" align="center">
                                                                            <tr>
                                                                                <td style="width: 109px; height: 29px" valign="top">
                                                                                    <asp:Label ID="Label1" runat="server" Text="Fecha inicial"></asp:Label>
                                                                                    :</td>
                                                                                <td style="width: 99px; height: 29px">
                                                                                    <asp:TextBox ID="txtFechaInicial" runat="server" Width="88px" ToolTip="Dia/Mes/Año"></asp:TextBox><cc1:CalendarExtender
                                                                                        ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                                                                    </cc1:CalendarExtender>
                                                                                </td>
                                                                                <td style="width: 87px; height: 29px" valign="top">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                                                                                        ControlToValidate="txtFechaInicial">Falta!</asp:RequiredFieldValidator></td>
                                                                                <td style="width: 87px; height: 29px" valign="top">
                                                                                    <asp:Label ID="Label2" runat="server" Text="Fecha final"></asp:Label>:</td>
                                                                                <td style="width: 99px; height: 29px">
                                                                                    <asp:TextBox ID="txtFechaFinal" runat="server" Width="83px" ToolTip="Dia/Mes/Año"></asp:TextBox><cc1:CalendarExtender
                                                                                        ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFinal" Format="dd-MM-yyyy">
                                                                                    </cc1:CalendarExtender>
                                                                                </td>
                                                                                <td style="width: 68px; height: 29px">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
                                                                                        ControlToValidate="txtFechaFinal">Falta!</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br>
                                                        </p>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="400" border="0"
                                                align="center">
                                                <asp:Repeater ID="Results" runat="server">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(966, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                            <td class="ResultsHeader2" valign="middle" align="center">
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1469, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="RowItem" ondblclick="window.navigate('TanqueZeta.aspx?Fecha=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "Fecha")))%>'); "
                                                            onmouseout="this.className='RowItem';" onmouseover="this.className='SelectedRowItem';">
                                                            <td class="RowTextCentred" valign="middle" width="200">
                                                                <%# Convert.ToString(DataBinder.Eval(Container.DataItem, "Fecha")).Substring(0,10) %>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" align="right" width="150">
                                                                <%#Convert.ToString(DataBinder.Eval(Container.DataItem, "Estado"))=="A"?"Abierto":"Cerrado"%>
                                                            </td>
                                                            <td class="RowTextCentred" valign="middle" width="130">
                                                                <a href="TanqueZeta.aspx?Fecha=<%#EncryptText(Convert.ToString(DataBinder.Eval(Container.DataItem, "Fecha")))%>">
                                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1469, Servipunto.Estacion.Web.Global.Idioma)%>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td bgcolor="White" align="center" valign="middle" colspan="5">
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
