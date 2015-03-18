<%@ Page Language="c#" Codebehind="FiltroTiqueteVenta.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroTiqueteVenta"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br>
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" Visible="false" ForeColor="Red" runat="server"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Tiquete de venta por Consecutivo</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="width: 68px; height: 30px" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Consecutivo"></asp:Label>:</td>
                            <td style="width: 86px; height: 30px">
                                <asp:TextBox ID="txtConsecutivos" runat="server"></asp:TextBox></td>
                            <td style="width: 43px; height: 30px" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Impresora"></asp:Label>:</td>
                            <td style="width: 193px; height: 30px">
                                <asp:DropDownList ID="ddlImpresoras" runat="server" Width="192px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 68px; height: 30px" valign="top">
                            </td>
                            <td style="width: 86px; height: 30px">
                            </td>
                            <td style="width: 43px; height: 30px" valign="top">
                                <asp:TextBox ID="txtRutaArchivo" Visible="False" runat="server"></asp:TextBox></td>
                            <td style="width: 193px; height: 30px">
                                <asp:TextBox ID="txtImpresora" Visible="False" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="ReportesGenerales.aspx">
                                        <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
