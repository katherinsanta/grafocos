<%@ Page Language="c#" Codebehind="ReportesFormaPago.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.ReportesFormaPago" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <!-- Developer Custom Content -->
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta pagina encontrara los reportes asociados a las formas de pago de las ventas realizadas en la estaci�n."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorFormasDePago.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,380,0,1,0,0,0,1,0)" href="FiltroFormasPago.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Reporte de Ventas por Formas de Pago"></asp:Label></u>
                                                                    </a>&nbsp;<br>
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Reporte de ventas donde se especifican las formas de pago"></asp:Label></font></td>
                                                                <td>
                                                                    <br>
                                                                    <td valign="top">
                                                                        <img height="48" src="../../BlueSkin/Icons/2011/PagosAjustados.png" width="48" border="0"></td>
                                                                    <td>
                                                                        <br>
                                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,380,0,1,0,0,0,1,0)" href="FiltroAjusteFormasPago.aspx">
                                                                            <u>
                                                                                <asp:Label ID="Label4" runat="server" Text="Reporte de Pagos Ajustados"></asp:Label></u>
                                                                        </a>&nbsp;<br>
                                                                        <br>
                                                                        <font color="gray">
                                                                            <asp:Label ID="Label5" runat="server" Text="Reporte de ventas en donde se hayan reajustado las formas de pago"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </blockquote>
                                        <p>
                                            &nbsp;</p>
                                        <!-- End Developer Custom Content -->
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
    </table>
</asp:Content>
