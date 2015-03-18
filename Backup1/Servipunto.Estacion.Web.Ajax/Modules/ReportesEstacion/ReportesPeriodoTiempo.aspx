<%@ Page Language="c#" Codebehind="ReportesPeriodoTiempo.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Reportes.ReportesPeriodoTiempo" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                                <asp:Label ID="Label1" runat="server" Text="En esta pagina encontrara los reportes que tienen como filtro de busqueda un periodo de tiempo."></asp:Label>
                                            </font>
                                        </p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorHoraEspeficica.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,310,0,1,0,0,0,1,0)" href="FiltroHoraDia.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Ventas Realizadas en Una Hora Especifica del Dia Laboral"></asp:Label></u>&nbsp;
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Informe de Ventas realizadas en una hora especifica"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorTurno.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,340,0,1,0,0,0,1,0)" href="FiltroTurno.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Ventas por Turno"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label5" runat="server" Text="Informe de ventas realizadas por turno"></asp:Label></font></font>
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
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorDia.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,310,0,1,0,0,0,1,0)" href="FiltroDiaSemana.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label6" runat="server" Text="Ventas por Día Calendario de la Semana"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label7" runat="server" Text="Informe de las ventas realizas en un día de la semana"></asp:Label><font
                                                                            color="gray"></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorCierreDeTurno.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,600,580,0,1,0,0,0,1,0)" href="FiltroCierreTurno.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label8" runat="server" Text="Ventas por Cierre de turno"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label9" runat="server" Text="Informe de ventas realizadas por cierre de turno"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorHoraYDiaDeCalendario.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,310,0,1,0,0,0,1,0)" href="FiltroHoraDiaReal.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label10" runat="server" Text="Ventas Realizadas en una hora específica del Día Calendariol"></asp:Label></u></a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label11" runat="server" Text="Informe de Ventas realizadas en una hora especifica del día"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasRealizadasPorMesLaboral.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,320,150,0,1,0,0,0,1,0)" href="FiltroMesReal.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label12" runat="server" Text="Ventas Realizadas por Mes(es) Laboral(es)"></asp:Label></u></a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label13" runat="server" Text="Informe de Ventas realizadas por Mes(es) Laboral(es)"></asp:Label></font>
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
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasGratisRealizadasPorPeriodoDeTiempoLaboral.png" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,280,0,1,0,0,0,1,0)" href="FiltroVentasGratis.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label14" runat="server" Text="Ventas Gratis Realizadas por Periodo de Tiempo Laboral"></asp:Label></u></a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label15" runat="server" Text="Informe de Ventas Gratis realizadas por Periodo de Tiempo Laboral"></asp:Label></font>
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
