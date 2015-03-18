<%@ Page Language="c#" Codebehind="ReportesCreditoDirecto.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Reportes.ReportesCreditoDirecto" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top">
                <table  cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <!-- Developer Custom Content -->
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta pagina encontrara los reportes asociados a las ventas realizadas por credito directo y los extractos de sus clientes"></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr>
                                                    
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" alt="r" src="../../BlueSkin/Icons/2011/VentasPorCreditoDirecto.png" width="48" border="0"/></td>
                                                                <td>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,305,0,1,0,0,0,1,0)" href="FiltroCredito.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Ventas por Credito Directo"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Informe de ventas realizadas por credito directo"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" alt="s" src="../../BlueSkin/Icons/2011/ExtractoDeLosClientes.png" width="48" border="0"/></td>
                                                                <td>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,400,0,1,0,0,0,1,0)" href="FiltroExtracto.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Extractos de Clientes"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label5" runat="server" Text="En esta opción usted podra imprimir los extractos de sus clientes"></asp:Label>
                                                                    </font>
                                                                    </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </blockquote>
                                        <p>
                                           
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
        <!-- End Page Body -->
    </table>
</asp:Content>

