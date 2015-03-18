<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" AutoEventWireup="true"
    Codebehind="ReportesSuic.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion.ReportesSuic"
    Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <p>
                                                <font color="dimgray">
                                                    <asp:Label ID="Label10" runat="server" Text="Categorias de reportes disponibles"></asp:Label>:</font></p>
                                            <table cellspacing="5" cellpadding="10" align="center" border="0" width="100%">
                                                <tr>
                                                    <!--REPORTES GENERALES -->
                                                    <td valign="top" align="center" style="margin: 0px; height: 50%" width="48px">
                                                        <a href="FiltroVentasSuic.aspx">
                                                            <img alt="Generales" src="../../BlueSkin/Icons/2011/Consulta-Suic-48.png" border="0">&nbsp;<br>
                                                        </a>
                                                    </td>
                                                    <td valign="top" align="left" style="height: 50%; margin: 0px; width: 219px;">
                                                        <a href="FiltroVentasSuic.aspx">
                                                            <asp:Label ID="Label1" runat="server" Text="Vehiculos Suic"></asp:Label>
                                                        </a>
                                                        <p class="Descripcion">
                                                            Consulte cuantas veces asisten los vehiculo en su estacion.</p>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- End Custom Content -->
                                            <blockquote>
                                            </blockquote>
                                        </asp:Panel>
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
