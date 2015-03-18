<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ReportesConductor.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.ReportesConductor"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Reportes por conductor</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Content -->
                    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><br>
                    <p>
                        <font color="dimgray">
                        <asp:Label ID="lblDesc" runat="server">
                        En esta pagina encontrara los reportes asociados con conductores.
                        </asp:Label></font></p>
                    <blockquote>
                        <table cellspacing="5" cellpadding="5" border="0">
                            <tr>
                                <td width="50%">
                                    <table>
                                        <tr>
                                            <td valign="top">
                                                <img height="48" src="../../BlueSkin/Icons/2011/ReporteConsumoConductor.png" width="48" border="0"></td>
                                            <td>
                                                <br>
                                                <a onclick="return AbrirVentanaCentrada(this,null,690,375,0,1,0,0,0,1,0)" href="FiltroConductorConsumo.aspx">
                                                <u><asp:Label ID="lblConsumo" runat="server">
                                                Reporte Consumo Conductor
                                                </asp:Label></u></a>&nbsp;<br>
                                                <br>
                                                <font color="gray">
                                                <asp:Label ID="lblDescConsumo" runat="server">
                                                Esta opción le permite obtener el reporte de tanqueos por conductores
                                                </asp:Label> 
                                                </font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="50%">
                                    <table>
                                        <tr>
                                            <td valign="top">
                                                <img height="48" src="../../BlueSkin/Icons/2011/ReporteTiemposConsumo.png" width="48" border="0"></td>
                                            <td>
                                                <br>
                                                <a onclick="return AbrirVentanaCentrada(this,null,690,375,0,1,0,0,0,1,0)" href="FiltroConductorHorometro.aspx">
                                                    <u><asp:Label ID="lblTiempos" runat="server">
                                                    Reporte de Tiempos de Consumo
                                                    </asp:Label></u> </a>&nbsp;<br>
                                                <br>
                                                <font color="gray">
                                                <asp:Label ID="lblDescTiempos" runat="server">
                                                Esta opción le permite obtener el reporte de clientes de consumo
                                                </asp:Label>
                                                </font>
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
    </asp:Panel>
</asp:Content>
