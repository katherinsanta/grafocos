<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProcesosSAP.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Procesos.ProcesosSAP"
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
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><font
                                            color="gray"><font color="gray"><font color="gray"></font></font></font><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta página encontrará un grupo de opciones para la generación de planos para SAP."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0">
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <!--<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Isla-48.gif" width="48" border="0"></td>-->
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48" border="0"></td>
                                                                <td>
                                                                    &nbsp;<font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,350,380,0,1,0,0,0,1,0)"
                                                                        href="FiltroVentasSAP.aspx"> <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Archivo Plano de Ventas para SAP"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                        <br>
                                                                        <font color="gray">
                                                                            <asp:Label ID="Label3" runat="server" Text="Generación de archivo plano de ventas para SAP"></asp:Label></font></font>
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
                                                                    &nbsp;&nbsp;<font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,350,380,0,1,0,0,0,1,0)"
                                                                        href="FiltroTrasladosSAP.aspx"> <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Archivo Plano de Traslados para SAP"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                        <br>
                                                                        <font color="gray">
                                                                            <asp:Label ID="Label5" runat="server" Text="Generación de archivo plano de traslados para SAP"></asp:Label></font></font>&nbsp;
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
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48" border="0"></td>
                                                                <td>
                                                                    <font color="gray"><font color="gray"><font color="gray">
                                                                        <br>
                                                                        &nbsp;<font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,350,380,0,1,0,0,0,1,0)"
                                                                            href="FiltroImportarSAP.aspx"> <u>
                                                                                <asp:Label ID="Label6" runat="server" Text="Importar Archivos Planos de SAP para Servipunto"></asp:Label></u>&nbsp;
                                                                        </a>&nbsp;&nbsp;
                                                                            <br>
                                                                        </font>
                                                                        <asp:Label ID="Label7" runat="server" Text="Importa archivos planos de SAP para Servipunto"></asp:Label></font></font>
                                                                    </font>
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
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,350,380,0,1,0,0,0,1,0)"
                                                                        href="FiltroLecturasSAP.aspx"><u>
                                                                            <asp:Label ID="Label8" runat="server" Text="Archivo Plano de Total de Lecturas para SAP"></asp:Label></u>&nbsp;&nbsp;</a>&nbsp;&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label9" runat="server" Text="Generación de un archivo plano con el total de lecturas por día"></asp:Label></font>
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
