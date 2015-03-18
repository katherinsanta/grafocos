<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ImportarTablasGNV.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.ImportarTablasGNV" 
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <br />
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="90%" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server" Text="Exportar Tabla de Ventas a un Archivo Plano"> </asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="width: 60%" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Cargar Archivos"></asp:Label>:</td>
                            <td style="width: 40%" valign="top">
                                <a onclick="return AbrirVentanaCentrada(this,'UpLoad',690,375,0,1,0,0,0,1,0)" href="SubirArchivos.aspx">
                                    <img height="16" alt="Click" src="../../BlueSkin/Icons/2011/Activo-16.png"
                                        width="16" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 60%" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Separador"></asp:Label>:</td>
                            <td style="width: 40%" valign="top">
                                <input type="text" maxlength="1" size="1" name="txtSeparador" id="txtSeparador" /></td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <asp:Label ID="lblConfirmacion" Visible="False" ForeColor="Navy" runat="server" Font-Size="8pt"></asp:Label><br/>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <a style="color: blue" onclick="document.forms[0].submit();" href="#">
                                        <asp:Label ID="Label3" runat="server" Text="Actualizar"></asp:Label></a>| <a style="color: blue"
                                            href="OpcionesGNV.aspx">
                                            <asp:Label ID="Label4" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
