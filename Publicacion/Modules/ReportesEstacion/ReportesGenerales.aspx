<%@ Page Language="c#" Codebehind="ReportesGenerales.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.ReportesGenerales" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                    <td>
                                        <!-- Developer Custom Content -->
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta pagina encontrara un grupo de reportes generales acerca de las ventas realizadas en la estación durante un periodo de tiempo."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorIsla.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,350,0,1,0,0,0,1,0)" href="FiltroIsla.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Ventas por Isla"></asp:Label></u>
                                                                    </a>
                                                                    <br>
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Informe de ventas realizadas por isla"></asp:Label>&nbsp;</font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Canasta.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,380,0,1,0,0,0,1,0)" href="FiltroArticulo.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Ventas por Articulo"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label5" runat="server" Text="Informe de ventas realizadas por articulo"></asp:Label></font>
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
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorLecturas.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,500,0,1,0,0,0,1,0)" href="FiltroControlLecturasTurno.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label6" runat="server" Text="Ventas por Lecturas"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label7" runat="server" Text="Informe de ventas realizadas entre las lecturas inicial y final del surtidor para control de Lecturas de Turnos"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Empleado.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,430,0,1,0,0,0,1,0)" href="FiltroEmpleado.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label8" runat="server" Text="Ventas por Empleado"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label9" runat="server" Text="Permite combinar varios parametros de filtro como empleado, turno, isla y manguera "></asp:Label></font>
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
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorManguera.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroManguera.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label10" runat="server" Text="Ventas por Manguera"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label11" runat="server" Text="Informe de ventas realizadas por las mangueras de la estación"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorSurtidor.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroSurtidor.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label12" runat="server" Text="Ventas por Surtidor"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label13" runat="server" Text="Informe de ventas realizadas por los surtidores de la estación"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Turno.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroTurnoSurtidorArticulo.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label14" runat="server" Text="Ventas por Turno - Surtidor -  Articulo"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label15" runat="server" Text="Informe de ventas realizadas por Turno, Surtidor, Articulo"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorCara.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,345,0,1,0,0,0,1,0)" href="FiltroCara.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label16" runat="server" Text="Ventas por Cara"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label17" runat="server" Text="Informe de ventas realizadas filtrado por las caras del surtidor"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VariacionDeTanquesOBalanceDeGas.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,400,0,1,0,0,0,1,0)" href="FiltroTanques.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label18" runat="server" Text="Variación de Tanques o Balance de Gas"></asp:Label></u>&nbsp;
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label19" runat="server" Text="Informe de variación de tanques o balance de gas"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table id="Table1">
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Report-TiqueteDeVenta.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,345,0,1,0,0,0,1,0)" href="FiltroTiqueteVenta.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label20" runat="server" Text="Tiquete de Venta "></asp:Label></u></a>
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label21" runat="server" Text="Impresión de un tiquete de venta por consecutivo de venta"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
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
