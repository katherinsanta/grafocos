<%@ Page Language="c#" Codebehind="Manguera.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Manguera"
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
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" border="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" Text="Número de la Manguera"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtId" runat="server" MaxLength="2" Width="100px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="Label2" runat="server" Text="Artículo"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboArticulo" runat="server" Width="320px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Grado"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboGrado" runat="server" Width="144px">
                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                        <asp:ListItem Value="4" Selected="True">4</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Lector"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboLector" runat="server" Width="144px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboEstado" runat="server" Width="144px">
                                                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                                                        <asp:ListItem Value="B">Ventas Bloqueadas</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblHideSurtidor" runat="server" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblHideIsla" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <a href="MiniTanque.aspx" onclick="return AbrirVentanaCentrada(this,null,330,180,0,0,0,0,0,1,0)">
                                                                        <asp:Label ID="Label6" runat="server" Text="Tanque"></asp:Label>:</a>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTanque" runat="server" Width="144px">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblHideCara" runat="server" Visible="False"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                        runat="server" visible="false"/>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
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
