<%@ Page Language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Reportes._Default"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                        <!-- Custom Content -->
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label><br>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <p>
                                                <font color="dimgray">
                                                    <asp:Label ID="Label10" runat="server" Text="Categorias de reportes disponibles"></asp:Label>:</font></p>
                                            <table cellspacing="5" cellpadding="10" align="center" border="0">
                                                <tr>
                                                    <!--REPORTES GENERALES -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesGenerales.aspx">
                                                            <img alt="Generales" src="../../BlueSkin/Icons/2011/Generales.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesGenerales.aspx">
                                                            <asp:Label ID="Label1" runat="server" Text="Generales"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea los reportes generales del sistema</p>
                                                    </td>
                                                    <!--REPORTES FORMAS PAGO -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesFormaPago.aspx">
                                                            <img alt="Formas de pago" src="../../BlueSkin/Icons/2011/FormasDePago.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesFormaPago.aspx">
                                                            <asp:Label ID="Label2" runat="server" Text="Formas de Pago"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Configure las Formas De Pago
                                                        </p>
                                                    </td>
                                                    <!--REPORTES PERIODO DE TIEMPO -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesPeriodoTiempo.aspx">
                                                            <img alt="Periodos de Tiempo" src="../../BlueSkin/Icons/2011/PeriodoDeTiempo.png"
                                                                border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesPeriodoTiempo.aspx">
                                                            <asp:Label ID="Label3" runat="server" Text="Periodo de Tiempo"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea los reportes de los productos, empleados, mangueras e.t.c por un periodo de
                                                            tiempo</p>
                                                    </td>
                                                    <!--REPORTES CLIENTES -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesClientes.aspx">
                                                            <img alt="Clientes" src="../../BlueSkin/Icons/2011/Clientes.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesClientes.aspx">
                                                            <asp:Label ID="Label4" runat="server" Text="Clientes"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea los reportes de sus clientes
                                                        </p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <!--REPORTES AUTOMOTOR -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesAutomotor.aspx">
                                                            <img alt="Automotor" src="../../BlueSkin/Icons/2011/Automotores.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesAutomotor.aspx">
                                                            <asp:Label ID="Label5" runat="server" Text="Automotores"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea los reportes de los vehiculos</p>
                                                    </td>
                                                    <!--REPORTES CREDITO DIRECTO -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesCreditoDirecto.aspx">
                                                            <img alt="Credito Directo" src="../../BlueSkin/Icons/2011/CreditoDirecto.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesCreditoDirecto.aspx">
                                                            <asp:Label ID="Label6" runat="server" Text="Credito Directo "></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea los reportes por los tipos de creditos
                                                        </p>
                                                    </td>
                                                    <!--FACTURACION -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesFacturacion.aspx">
                                                            <img alt="Facturación" src="../../BlueSkin/Icons/2011/Facturacion.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesFacturacion.aspx">
                                                            <asp:Label ID="Label7" runat="server" Text="Facturación"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea los reportes de las facturas que se han realizado
                                                        </p>
                                                    </td>
                                                    <!--RECAUDO -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesRecaudo.aspx">
                                                            <img alt="Recaudo" src="../../BlueSkin/Icons/2011/Recaudos.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesRecaudo.aspx">
                                                            <asp:Label ID="Label8" runat="server" Text="Recaudo"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea los reporte por lo recaudado en la estacion</p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <!--AUDITORIA -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesAuditoria.aspx">
                                                            <img height="48" src="../../BlueSkin/Icons/2011/Auditoria.png" width="48" border="0">&nbsp;<br>
                                                        </a>
                                                        <br>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesAuditoria.aspx">
                                                            <asp:Label ID="Label9" runat="server" Text="Auditoria"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Vea quienes han ingresado al sistema</p>
                                                    </td>
                                                    <!--CONDUCTOR -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                        <a href="ReportesConductor.aspx">
                                                            <img height="48" src="../../BlueSkin/Icons/2011/Conductores.png" width="48" border="0">&nbsp;<br>
                                                        </a>
                                                        <br>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                        <a href="ReportesConductor.aspx">
                                                            <asp:Label ID="lblConductor" runat="server">
															Conductor
                                                            </asp:Label></a>
                                                        <p class="Descripcion">
                                                            Vea el reporte De Consumo Por Conductores
                                                        </p>
                                                    </td>
                                                    <td>
                                                        <a href="ReportesSuic.aspx">
                                                            <img height="48" src="../../BlueSkin/Icons/2011/Consulta-Suic-48.png" width="48"
                                                                border="0">&nbsp;<br>
                                                        </a>
                                                        <br>
                                                    </td>
                                                    <td>
                                                        <a href="ReportesSuic.aspx">
                                                            <asp:Label ID="Label11" runat="server">
															Suic
                                                            </asp:Label></a>
                                                        <p class="Descripcion">
                                                            Vea el reporte De Ventas por vehiculos suic
                                                        </p>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- End Custom Content -->
                                            <blockquote>
                                            </blockquote>
                                        </asp:Panel>
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
