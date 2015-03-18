<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Prepagos._default"
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
                                                    <a href="Creaciones.aspx">
                                                        <img alt="Generales" src="../../BlueSkin/Icons/2011/CrearPrepago.png" border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="Creaciones.aspx">
                                                        <asp:Label ID="label1" runat="server" 
                                                            Text=''>
                                                        </asp:Label>
                                                    </a>
                                                    <p class="Descripcion">
                                                        Cree Modifique o Elimine Prepagos
                                                    </p>
                                                </td>
                                                <!--ASIGNAR -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="Asignacion.aspx">
                                                        <img alt="Interfaz Contable" src="../../BlueSkin/Icons/2011/AsignarPrepago.png" border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="Asignacion.aspx"> <asp:Label ID="lblAsing" runat="server" 
                                                            Text=''>
                                                        </asp:Label></a>
                                                    <p class="Descripcion">
                                                        Asigne Un Prepago a Un Cliente
                                                    </p>
                                                </td>
                                                <!--CANCELAR -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="Anulacion.aspx">
                                                        <img alt="Interfaz Recaudo GDO" src="../../BlueSkin/Icons/2011/CancelarPrepago.png"
                                                            border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="Anulacion.aspx"> <asp:Label ID="lblCancelattion" runat="server" 
                                                            Text=''>
                                                        </asp:Label> </a>
                                                    <p class="Descripcion">
                                                        Cancele Un Prepagos a Un Cliente</p>
                                                </td>
                                                <!--REPORTE -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="../ReportesEstacion/FiltroPrepagos.aspx">
                                                        <img height="48" src="../../BlueSkin/Icons/2011/RepotePrepagos.png" border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="../ReportesEstacion/FiltroPrepagos.aspx"><asp:Label ID="lblReport" runat="server" 
                                                            Text=''>
                                                        </asp:Label> </a>
                                                    <p class="Descripcion">
                                                        Vea El Reporte De Prepagos</p>
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
