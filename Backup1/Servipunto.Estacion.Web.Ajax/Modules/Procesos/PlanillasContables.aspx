<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanillasContables.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Ajax.Modules.Procesos.PlanillasContables" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                                <asp:Label ID="Label1" runat="server" Text="En esta página encontrará un grupo de opciones para la generación de planillas y Generacion de planos XML para Facturación."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0" width="100%">
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table id="Table7">
                                                            <tr align="left">
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/planilla-turno-48px.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="FiltroPlantillaTurno.aspx"><u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Planilla de Turno"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label3" runat="server" Text="Genera la Planilla de Turno, de un turno cerrado"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table id="Table8">
                                                            <tr align="left">
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/planilla-dia-48px.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="FiltroPlanillaDia.aspx"><u>
                                                                            <asp:Label ID="Label24" runat="server" Text="Planilla Dia"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label25" runat="server" Text="Genera la Planilla Diaria y los archivos xml para interface contable"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table id="Table1">
                                                            <tr align="left">
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/reporte-modificacion-planilla-turno-48px.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="../ReportesEstacion/FiltroLogPlanilla.aspx"><u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Reporte Modificaciones Planilla de Turno"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label5" runat="server" Text="Genera  Reporte de  Modificaciones planillas turnos"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
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
    </td> </tr> </table>
</asp:Content>
