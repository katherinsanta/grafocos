<%@ Page Language="c#" Codebehind="ReportesAutomotor.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Reportes.ReportesAutomotor" 
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
                                        <!-- Developer Custom Content -->
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label11" runat="server" Text="En esta pagina encontrara todo tipo de reportes relacionados con los automotores de la estación."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0" align="left">
                                                <tr>
                                                    <td width="50%" align="left">
                                                        <table >
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/DatosDeLosAutomotores.png" width="48" border="0" align="left"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,205,150,0,1,0,0,0,1,0)" href="FiltroDatosAutomotores.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label6" runat="server" Text="Datos de los Automotores"></asp:Label></u></a>&nbsp;
                                                                    <br>
                                                                    <font color="gray"><font color="gray">
                                                                        <asp:Label ID="Label1" runat="server" Text="Informe de los datos basicos de los automotores"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%" align="left">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/VentasPorAutomotor.png" width="48" border="0" align="left"></td>
                                                                <td align="left">
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,445,0,1,0,0,0,1,0)" href="FiltroAutomotor.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label7" runat="server" Text="Ventas por Automotor"></asp:Label></u> </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label2" runat="server" Text="Informe de ventas realizadas por un automotor especifico"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" align="left">
                                                        <table>
                                                            <tr>
                                                                <td valign="top" style="height: 59px" align="left">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/Cupos.png" width="48" border="0" align="left"></td>
                                                                <td style="height: 59px" align="left">
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,345,205,0,1,0,0,0,1,0)" href="FiltroCuposAutomotores.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label8" runat="server" Text="Cupos"></asp:Label></u> </a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Informe de ventas realizadas por un automotor especifico"></asp:Label></font></td>
                                                            </tr>
                                                        </table>
                                                        <td width="50%" align="left">
                                                            <table>
                                                                <tr>
                                                                    <td valign="top" align="left">
                                                                        <img height="48" src="../../BlueSkin/Icons/2011/TiposDeAutomotor.png" width="48" border="0" align="left"></td>
                                                                    <td align="left">
                                                                        <br>
                                                                        <a onclick="return AbrirVentanaCentrada(this,null,690,345,0,1,0,0,0,1,0)" href="FiltroTiposAutomotores.aspx">
                                                                            <u>
                                                                                <asp:Label ID="Label9" runat="server" Text="Tipos de Automotor"></asp:Label></u> </a>&nbsp;
                                                                        <br>
                                                                        <font color="gray">
                                                                            <asp:Label ID="Label4" runat="server" Text="Informe de ventas realizadas agrupado por un tipo de automotor especifico"></asp:Label></font></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/ConsolidadoPorTipoYTiempo.png" width="48" border="0" align="left"></td>
                                                                <td align="left">
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,345,0,1,0,0,0,1,0)" href="FiltroConsolidadoAutomotores.aspx">
                                                                        <asp:Label ID="Label5" runat="server" Text="Consolidado por Tipo y Tiempo"></asp:Label></a>
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label10" runat="server" Text="Reporte consolidado por tipo de automotor&nbsp;analizado por día  o por meses."></asp:Label></font></td>
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
