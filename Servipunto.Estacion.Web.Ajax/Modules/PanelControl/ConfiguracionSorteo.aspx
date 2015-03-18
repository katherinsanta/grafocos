<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfiguracionSorteo.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.PanelControl.ConfiguracionSorteo"

MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" style="margin-left: 5%; height: 100%" cellpadding="0" width="80%"
        border="0">
        <tr>
            <td style="width: 599px">
                <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                <asp:Panel ID="pnlForm" Visible="true" runat="server">
                    <table width="100%" style="border: solid 1px #917D82">
                        <tr style="background-color:#917D82">
                            <td colspan="2">
                                <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                            <td colspan="2" align="right">
                                <asp:LinkButton ID="lblGuardar" runat="server" OnClick="lblGuardar_Click">Guardar</asp:LinkButton>&nbsp;
                                <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" valign="middle">
                                <asp:Label ID="Label1" runat="server" Text="Parámetros de Configuración"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                                <asp:Label ID="Label14" runat="server" Text="Valor Minimo:"></asp:Label></td>
                            <td width="25%">
                                <asp:TextBox ID="txtValorMinimo" runat="server" Width="90%"></asp:TextBox></td>
                            <td width="25%">
                                <asp:TextBox ID="txtRutaArchivoAudio" runat="server" Visible="False" Width="8px"></asp:TextBox></td>
                            <td width="25%">
                                <asp:Label ID="lblHide" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="25%" style="height: 23px">
                                <asp:Label ID="Label13" runat="server" Text="Articulos:"></asp:Label></td>
                            <td width="25%" style="height: 23px">
                                <asp:ListBox ID="lstArticulos" runat="server" Width="113px" AutoPostBack="True" SelectionMode="Multiple"></asp:ListBox></td>
                            <td width="25%" style="height: 23px">
                                <asp:Label ID="Label4" runat="server" Text="Consecutivo Inicial:"></asp:Label>:</td>
                            <td width="25%" style="height: 23px">
                                <asp:TextBox ID="txtConsecutivoInicial" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" valign="middle">
                                <b>
                                    </b></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Multiples Boletas:"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rbtMultiplesBoletas" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Consecutivo Actual:"></asp:Label></td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtConsecutivoActual" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Estado"></asp:Label></td>
                            <td>
                                &nbsp;<asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                                    <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr valign="middle" align="center">
                            <td colspan="2">
                                <asp:Label ID="Label16" runat="server" Text="Fecha Inicial"></asp:Label>:</td>
                            <td colspan="2">
                                <asp:Label ID="Label17" runat="server" Text="Fecha Final"></asp:Label>:</td>
                        </tr>
                        <tr valign="middle" align="center">
                            <td colspan="2">
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
                                <asp:Calendar ID="cldFecInicial" runat="server" Visible="false"></asp:Calendar>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
                                <asp:Calendar ID="cldFecFinal" runat="server" Visible="false"></asp:Calendar>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFinal">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
