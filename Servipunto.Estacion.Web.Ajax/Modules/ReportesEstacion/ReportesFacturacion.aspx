<%@ Page Language="c#" Codebehind="ReportesFacturacion.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Reportes.ReportesFacturacion" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                                <asp:Label ID="Label1" runat="server" Text="En esta pagina encontrara los reportes asociados a la facturación de la estación."></asp:Label></font>
                                        </p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorConsecutivo.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroConsecutivo.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Ventas por Consecutivo"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Informe de ventas filtrado por el consecutivo de venta"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/ReporteDeVentasSinNIT.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,280,0,1,0,0,0,1,0)" href="FiltroVentasSinNIT.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Reporte de Ventas Sin NIT"></asp:Label></u>
                                                                    </a>
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label5" runat="server" Text="En esta opción podra asignar un nit a las ventas que no tienen asignado un NIT"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Libros.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroLibroVentas.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label6" runat="server" Text="Historial Libro de Ventas"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label7" runat="server" Text="Muestra el historial de archivos planos para cada venta"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Archivo.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,300,170,0,1,0,0,0,1,0)" href="FiltroGenerarArchivoLibroVentas.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label8" runat="server" Text="Generar Archivo para Libro de Ventas"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label9" runat="server" Text="En esta opción usted podra crear un archivo para el libro de ventas"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/FacturaCanastilla.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroCanastillaCredito.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label10" runat="server" Text="Facturas Canastilla"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label11" runat="server" Text="En esta opción usted podra ver reporte de ventas de canastilla"></asp:Label></font></font>
                                                                </td>
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
        <!-- End Page Body -->
    </table>
</asp:Content>
