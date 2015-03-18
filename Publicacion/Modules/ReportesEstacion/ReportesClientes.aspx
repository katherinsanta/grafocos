<%@ Page Language="c#" Codebehind="ReportesClientes.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Reportes.ReportesClientes" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta pagina encontrara todo tipo de reportes relacionados con los clientes de la estación."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr align="left">
                                                    <td style="width: 50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/DatosDeLosClientes.png" width="48"
                                                                        border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,205,170,0,1,0,0,0,1,0)" href="FiltroDatosClientes.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Datos de los Clientes"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Informe de los datos basicos de los clientes"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorNITOCodigo.png" width="48"
                                                                        border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,400,0,1,0,0,0,1,0)" href="FiltroCliente.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Ventas por NIT o Codigo"></asp:Label></u></a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label5" runat="server" Text="Informe de ventas realizadas a uno o todos los clientes"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td style="width: 50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Cupos.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,345,205,0,1,0,0,0,1,0)" href="FiltroCuposClientes.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label6" runat="server" Text="Cupos"></asp:Label></u></a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label7" runat="server" Text="Reporte de cupos asignados a los clientes"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table id="Table1">
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasNITUno.png" width="48" border="0"></td>
                                                                <td>
                                                                    <font color="gray"><font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,690,450,0,1,0,0,0,1,0)"
                                                                        href="FiltroClienteExterno.aspx"><u>
                                                                            <asp:Label ID="Label8" runat="server" Text="Ventas por NIT a Cliente"></asp:Label></u></a><br>
                                                                        <font color="gray"><font color="gray">
                                                                            <asp:Label ID="Label9" runat="server" Text="Informe de ventas realizadas para un cliente determinado con perfil de Cliente"></asp:Label></font></font>&nbsp;</font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <TD width="50%">
															<table>
																<TR>
																	<TD vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/2011/cierre-mes-cliente-32px.png" width="48" border="0"></TD>
																	<TD><BR>
																		<A onclick="return AbrirVentanaCentrada(this,null,545,405,0,1,0,0,0,1,0)" href="FiltroCierreMesColvanes.aspx">
																			<U>Cierres Mes Cliente</U></A>&nbsp;
																		<BR>
																		<FONT color="gray"><FONT color="gray">Reporte de cierre mes cliente</FONT></FONT>
																	</TD>
																</TR>
															</table>
														</TD>
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
    </td> </tr>
    <!-- End Page Body -->
    </table>
</asp:Content>
