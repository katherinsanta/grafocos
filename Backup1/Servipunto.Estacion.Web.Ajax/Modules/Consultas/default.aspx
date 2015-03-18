<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Consultas._default"
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
                                                <asp:Label ID="Label1" runat="server" Text="Las opciones para la Consulta de documentos son las siguientes:"></asp:Label></font></p>
                                        <table cellspacing="5" cellpadding="10" align="center" border="0">
                                            <tr>
                                                <!-- facturas canastilla-->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="FacturasCanastilla.aspx">
                                                        <img alt="Facturas Canastilla" src="../../BlueSkin/Icons/2011/FacturaCanastilla.png"
                                                            border="0">&nbsp;<br>
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="FacturasCanastilla.aspx">
                                                        <asp:Label ID="Label2" runat="server" Text="Facturas Canastilla"></asp:Label>
                                                    </a>
                                                    <p class="Descripcion" >Informe detallado de las faturas de canastilla generados </p>
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
