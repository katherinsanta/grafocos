<%@ Page Language="c#" Codebehind="Identificador.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Identificador" 
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
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="350" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" border="0">
                                                            <tr>
                                                                <td style="height: 28px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Código Del Empleado:"></asp:Label></td>
                                                                <td style="height: 28px">
                                                                    <asp:Label ID="lblCodigoEmpleado" runat="server" Font-Bold="True" Width="120px"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 28px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Número del Identificador"></asp:Label>:</td>
                                                                <td style="height: 28px">
                                                                    <asp:TextBox ID="txtIdIdentificador" Width="120px" MaxLength="50" runat="server"
                                                                        Enabled="False"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>:</td>
                                                                <td style="height: 18px" align="center">
                                                                    <img height="16" alt="Ativo" src="../../BlueSkin/Icons/2011/Activo-16.png" width="16"><input
                                                                        id="EstadoActivo" type="radio" checked value="Activo" name="Estado" runat="server">&nbsp;&nbsp;&nbsp;
                                                                    <img height="16" alt="Inactivo" src="../../BlueSkin/Icons/2011/Inactivo-16.png" width="16"><input
                                                                        id="EstadoInactivo" type="radio" value="Inactivo" name="Estado" runat="server"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Código ROM:"></asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCodigoROM" runat="server" MaxLength="16"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label5" runat="server" Text="Tipo"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTipoIdentificador" runat="server" Width="120px">
                                                                        <asp:ListItem Value="Magnetica">Magnetica</asp:ListItem>
                                                                        <asp:ListItem Value="Boton">Bot&#243;n</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr id="filaPlaca" runat="server">
                                                                <td style="height: 29px">
                                                                    <asp:Label ID="Label6" runat="server" Text="Placa"></asp:Label>:<asp:Label ID="lblHideEmp"
                                                                        runat="server" Visible="False"></asp:Label></td>
                                                                <td style="height: 29px">
                                                                    <asp:TextBox ID="txtPlaca" runat="server" Width="120px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;<asp:Label ID="lblHideNombre" runat="server" Visible="False"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                        runat="server" visible="false">
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <p>
                                            &nbsp;</p>
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
