<%@ Page Language="c#" Codebehind="ReportesAuditoria.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.ReportesAuditoria" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
<script language="javascript" type="text/javascript">
// <!CDATA[
// ]]>
</script>

    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                    <!-- Topic Body -->
                    <!-- Topic Content -->
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                                <!-- Developer Custom Content -->
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label><br />
                                <p>
                                    <font color="dimgray">
                                        <asp:Label ID="Label1" runat="server" Text="En esta pagina encontrara los reportes de auditoria de aplicaciones Servipunto."></asp:Label></font>&nbsp;</p>
                                <table cellspacing="5" cellpadding="5" border="0">
                                    <tr>
                                        <td width="50%">
                                            <table>
                                                <tr>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/VentasPorLecturas.png" width="48" border="0" id="IMG1" onclick="return IMG1_onclick()" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroControlLecturasTurno.aspx"
                                                            id="refAuditoriaUsuarios">
                                                            <asp:Label ID="Label2" runat="server" Text="Ventas por Lecturas"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label3" runat="server" Text="Informe de ventas realizadas entre las lecturas inicial y final del
                                                                        surtidor"></asp:Label></font></font>
                                                    </td>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/VariacionDeTanquesOBalanceDeGas.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroTanques.aspx"
                                                            id="A1">
                                                            <asp:Label ID="Label4" runat="server" Text="Variación de Tanques o Balance de Gas"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label5" runat="server" Text="Informe de variación de tanques o balance de gas"></asp:Label></font></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/ReporteDeCalibracion.png" width="48" border="0" id="IMG2" onclick="return IMG2_onclick()" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroCalibración.aspx"
                                                            id="A2">
                                                            <asp:Label ID="Label6" runat="server" Text="Reporte de Calibración "></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label7" runat="server" Text="Reporte de todas las ventas generadas por Calibración"></asp:Label></font></font>
                                                    </td>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/ResumenDiarioDeTransacciones.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroResumenDiarioTransacciones.aspx"
                                                            id="A3">
                                                            <asp:Label ID="Label8" runat="server" Text="Resumen Diario de Transacciones"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label9" runat="server" Text="Informe de variación de tanques o balance de gas"></asp:Label></font></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/AuditoriaDeUsuarios.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroAuditoriaUsuario.aspx"
                                                            id="A4">
                                                            <asp:Label ID="Label10" runat="server" Text="Auditoria de Usuarios"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label11" runat="server" Text="Informe de&nbsp;actividades de usuarios"></asp:Label></font></font>
                                                    </td>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/AuditoriaDeErrores.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroAuditoriaError.aspx"
                                                            id="A5">
                                                            <asp:Label ID="Label12" runat="server" Text="Auditoria de errores"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label13" runat="server" Text="Informe de registro de errores"></asp:Label></font></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/ReporteOtrosNuevosIngresos.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroOtrosIngresos.aspx"
                                                            id="A6">
                                                            <asp:Label ID="Label14" runat="server" Text="Reporte otros nuevos ingresos"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label15" runat="server" Text="Registros de otros nuevos ingresos"></asp:Label></font></font>
                                                    </td>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/ReporteDeVentasPor Combustible.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroVentasCombustible.aspx"
                                                            id="A7">
                                                            <asp:Label ID="Label16" runat="server" Text="Reporte de Ventas por Combustible"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label17" runat="server" Text="Registros de Ventas por Combustibles"></asp:Label></font></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/ReporteVentasCanastilla.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroArticulo.aspx?filtro=1"
                                                            id="A8">
                                                            <asp:Label ID="Label18" runat="server" Text="Reporte Ventas Canastilla"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label19" runat="server" Text="Informe de ventas por canastilla"></asp:Label></font></font>
                                                    </td>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/ReporteDeCierreDeTurno.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroCierreTurno.aspx"
                                                            id="A9">
                                                            <asp:Label ID="Label20" runat="server" Text="Reporte Cierre de Turno"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label21" runat="server" Text="Informe de ventas por cierre de turno"></asp:Label></font></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/ReporteInventarioCanastilla.png" width="48" border="0" /></td>
                                                    <td style="width: 212px">
                                                        <br />
                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,580,0,1,0,0,0,1,0)" href="FiltroInventarioCanastilla.aspx"
                                                            id="A10">
                                                            <asp:Label ID="Label22" runat="server" Text="Reporte Inventario Canastilla"></asp:Label>
                                                        </a>
                                                        <br />
                                                        <font color="gray"><font color="gray">
                                                            <asp:Label ID="Label23" runat="server" Text="Informe de inventario canastilla"></asp:Label></font></font>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
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
</asp:Content>
