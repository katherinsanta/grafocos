<%@ Page Language="C#" AutoEventWireup="true" Codebehind="InterfazRecaudoGDO.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.InterfazRecaudoGDO" 
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
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta página encontrara los reportes asociados con la interfaz de Recaudo para GDO."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/archivo-48.gif" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,375,0,1,0,0,0,1,0)" href="FiltroInterfazGDO-EDS.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Importar Recaudos GDO"></asp:Label></u>
                                                                    </a>&nbsp;<br>
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Esta opción permite importar el archivo plano de novedades de recaudo para los clientes de GNCV, de acuerdo a las especificacion GDO"></asp:Label>
                                                                    </font>
                                                                </td>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/archivo-48.gif" width="48" border="0"></td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,375,0,1,0,0,0,1,0)" href="FiltroInterfazEDS-GDO.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Exportar Recaudos EDS"></asp:Label></u>
                                                                    </a>&nbsp;<br>
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label5" runat="server" Text="Esta opción permite generar el archivo plano con los recaudos diarios realizados por los clientes GNCV, de acuerdo a las especificaciones GDO "></asp:Label></font>
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
                            <div align="right">
                            </div>
                            <div align="center">
                                <table id="Table2" cellspacing="1" cellpadding="1" width="80%" border="0">
                                    <tr>
                                        <td style="width: 460px">
                                        </td>
                                        <td>
                                            <div align="right">
                                                <table id="Table1" cellspacing="0" cellpadding="2" width="300" align="right" bgcolor="#ffffcc"
                                                    border="0">
                                                    <tr>
                                                        <td align="right" style="height: 12px">
                                                            <p align="left">
                                                                <font color="gray">
                                                                    <asp:Label ID="Label6" runat="server" Text="NOTA"></asp:Label>:<br>
                                                                    <asp:Label ID="Label7" runat="server" Text="Los archivos de importación se deben de encontrar en la ruta"></asp:Label>:
                                                                    "C:\servipunto\administ\recibidos\nombreArchivo.txt"<br>
                                                                    <asp:Label ID="Label8" runat="server" Text="- Los archivos de exportación se crean en la ruta"></asp:Label>:C:\servipunto\administ\enviados\enviados\<br>
                                                                    <asp:Label ID="Label9" runat="server" Text="Por favor asegúrese de que existan las rutas anteriores."></asp:Label></font></p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <!-- End Topic Body -->
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
