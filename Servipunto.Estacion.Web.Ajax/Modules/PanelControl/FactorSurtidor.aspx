<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactorSurtidor.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.PanelControl.FactorSurtidor"  MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                                                    <asp:Label ID="lblNumeroSurtidor" runat="server" Text="Número de Surtidor:"></asp:Label></td>
                                                                
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtId" runat="server" MaxLength="2" ReadOnly="True" 
                                                                        Width="100px"></asp:TextBox>
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblHideSurtidor" runat="server" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblHideIsla" runat="server" Visible="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <strong>Tipo Factor</strong></td>
                                                                <td>
                                                                    <strong>Operador</strong></td>
                                                                <td>
                                                                    <strong>Valor</strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="lblValorVenta" runat="server" Text="Valor Venta:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOperadorValorVenta" runat="server">
                                                                        <asp:ListItem>*</asp:ListItem>
                                                                        <asp:ListItem>/</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtValorVenta" runat="server" MaxLength="4" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblCantidadVenta" runat="server" Text="Cantidad Venta:"></asp:Label></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOperadorCantidadVenta" runat="server">
                                                                        <asp:ListItem>*</asp:ListItem>
                                                                        <asp:ListItem>/</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCantidadVenta" runat="server" MaxLength="2" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPrecioVenta" runat="server" Text="Precio Venta:"></asp:Label></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOperadorPrecio" runat="server">
                                                                        <asp:ListItem>*</asp:ListItem>
                                                                        <asp:ListItem>/</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPrecioVenta" runat="server" MaxLength="4" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPreset" runat="server" Text="Valor Preset:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOperadorValorPreset" runat="server">
                                                                        <asp:ListItem>*</asp:ListItem>
                                                                        <asp:ListItem>/</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtValorPredeterminado" runat="server" MaxLength="4" 
                                                                        Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblValorLectura" runat="server" Text="Valor Lectura:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOperadorValorLectura" runat="server">
                                                                        <asp:ListItem>*</asp:ListItem>
                                                                        <asp:ListItem>/</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtValorLectura" runat="server" MaxLength="4" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPrecioProgramado" runat="server" Text="Precio Programado:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOperadorPrecioProgramado" runat="server">
                                                                        <asp:ListItem>*</asp:ListItem>
                                                                        <asp:ListItem>/</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPrecioProgramado" runat="server" MaxLength="4" 
                                                                        Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" 
                                                                        Text="Crear" onclick="btnCrear_Click" />
                                                                    &nbsp;</td>
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
