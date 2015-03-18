<%@ Page Language="c#" Codebehind="FiltroCuposAutomotores.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroCuposAutomotores" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
        <table cellspacing="1" cellpadding="5" width="90%" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server"><b>Cupos de Automotores</b></asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label1" runat="server" Text="Placa"></asp:Label>:</td>
                            <td valign="middle">
                                <asp:TextBox ID="txtCodigoCliente" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td valign="middle">
                                <asp:CheckBox ID="cbTodos" runat="server" Checked="True" AutoPostBack="True" Text="All">
                                </asp:CheckBox></td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label2" runat="server" Text="Filtrar por"></asp:Label>:</td>
                            <td valign="middle" colspan="2">
                                <asp:DropDownList ID="ddlTipo" runat="server">
                                    <asp:ListItem Value="-1">Todos Los Cupos</asp:ListItem>
                                    <asp:ListItem Value="0">Automotores que Han Usado el Cupo</asp:ListItem>
                                    <asp:ListItem Value="1">Automotores que NO Han Usado el Cupo</asp:ListItem>
                                    <asp:ListItem Value="2">Automotores Con Todo El Cupo Consumido</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>:</td>
                            <td valign="middle" colspan="2">
                                <asp:DropDownList ID="ddlOrden" runat="server">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="ReportesAutomotor.aspx">
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
