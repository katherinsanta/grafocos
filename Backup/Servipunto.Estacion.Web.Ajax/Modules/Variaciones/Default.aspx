<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Variaciones.Default"
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
                                                <asp:Label ID="Label1" runat="server" Text="Las opciones para varición de tanques o balance de gas disponibles
                                                son las siguientes:"></asp:Label></font></p>
                                        <table cellspacing="5" cellpadding="10" align="center" border="0">
                                            <tr>
                                                <!-- -->
                                                <!--TANQUES-->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="Tanques.aspx">
                                                        <img alt="" src="../../BlueSkin/Icons/2011/MensajesParaVariacionOBalance.png" border="0" />&nbsp;<br />
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="200px">
                                                    <a href="Tanques.aspx" >
                                                        <asp:Label ID="Label2" runat="server" Text="Mensajes para variación o balance"></asp:Label></a><a
                                                            href="TanqueVariacionMensaje.aspx"> </a>
                                                            <p class="Descripcion" > Configura el mesaje de la variacion de tanques</p>
                                                            
                                                </td>
                                                <!-- ZETA-->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="Zetas.aspx">
                                                        <img alt="" src="../../BlueSkin/Icons/2011/AperturaOCierreZeta.png" border="0" />&nbsp;
                                                        <br />
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="200px">
                                                    <a href="Zetas.aspx">
                                                        <asp:Label ID="Label3" runat="server" Text="Apertura o cierre zeta "></asp:Label>
                                                        <br />                                                        
                                                    </a>
                                                     <p class="Descripcion" >Configurar apertura o cierre Z</p>
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
        <!-- End Page Body -->
    </table>
</asp:Content>
