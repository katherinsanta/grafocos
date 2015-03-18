<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="defaut.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.Administracion.defaut"
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
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label3" runat="server" Text="The trade data available options are as follows"></asp:Label>:</font></p>
                                        <table cellspacing="5" cellpadding="10" align="center" border="0">
                                            <tr>
                                                <!-- -->
                                                <!--CREAR PREPAGO -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="../Procesos/planillascontables.aspx">
                                                        <img alt="Generales" src="../../BlueSkin/Icons/2011/VentasNITUno.png" border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="../Procesos/planillascontables.aspx">
                                                        <asp:Label ID="label1" runat="server" Text='Contabilidad'>
                                                        </asp:Label>
                                                    </a>
                                                    <p class="Descripcion">
                                                        Contabilidad
                                                    </p>
                                                </td>
                                                <!--ASIGNAR -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="../Prepagos/default.aspx">
                                                        <img alt="Interfaz Contable" src="../../BlueSkin/Update/prepago-32.png" border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="../Prepagos/default.aspx">
                                                        <asp:Label ID="lblAsing" runat="server" Text='Prepagos'>
                                                        </asp:Label></a>
                                                    <p class="Descripcion">
                                                       Prepagos
                                                    </p>
                                                </td>
                                                
                                            </tr>
                                        </table>
                                        <!-- End Custom Content -->
                                        <blockquote>
                                        </blockquote>
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
