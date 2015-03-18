<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroImportarSAP.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.FiltroImportarSAP" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br>
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" align="center" bgcolor="#5482fc" border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server"> Importar Archivos Planos de SAP</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top">
                            </td>
                            <td style="width: 210px">
                                <asp:Calendar ID="FechaInicio" runat="server" Visible="False"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                            </td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtSeparador" runat="server" Width="24px" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top">
                            </td>
                            <td style="width: 210px">
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="lblImportarArchivo" runat="server"> Importar Archivos Planos</asp:LinkButton>&nbsp;|
                                    <a style="color: blue" href="ProcesosSAP.aspx">
                                        <asp:Label ID="Label1" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
