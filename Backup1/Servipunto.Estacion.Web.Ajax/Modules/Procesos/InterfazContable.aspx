<%@ Page Language="C#" AutoEventWireup="true" Codebehind="InterfazContable.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.InterfazContable"
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
                                    <td>
                                        <!-- Developer Custom Content -->
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta página encontrará un grupo de opciones para la generación de planos de Terceros y Facturación."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <!--<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Isla-48.gif" width="48" border="0"></td>-->
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48" border="0"></td>
                                                                <td>
                                                                    <font color="gray"><a href="ProcesosEstandar.aspx"><u>
                                                                        <asp:Label ID="Label2" runat="server" Text="Procesos Para Interfaz Contable Estandar"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                        <br>
                                                                        <font color="gray">
                                                                            <asp:Label ID="Label3" runat="server" Text="Generación de Archivos Planos de ventas para Interfaz Contable en General"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48" border="0"></td>
                                                                <td>
                                                                    &nbsp;<font color="gray"><a href="ProcesosSAP.aspx"><u><asp:Label ID="Label5" runat="server"
                                                                        Text="Procesos Para Interfaz Contable SAP"></asp:Label></u> </a>&nbsp;
                                                                        <br>
                                                                        <font color="gray">
                                                                            <asp:Label ID="Label4" runat="server" Text="Generación de Archivos Planos de ventas para la Interfaz Contable SAP"></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <tr>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td valign="top">
                                                                    </td>
                                                                    <td>
                                                                        <font color="gray"><font color="gray"></font></font>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td valign="top">
                                                                    </td>
                                                                    <td>
                                                                        <br>
                                                                        &nbsp;
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
    </table>
</asp:Content>
