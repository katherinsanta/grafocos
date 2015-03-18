<%@ Page Language="c#" Codebehind="Empleado.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Empleado"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table style="height: 100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" style="height: 100%">
                <table style="height: 100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" style="width: 100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
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
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCodigo" Width="120px" MaxLength="15" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text="Cédula"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCedula" Width="120px" MaxLength="15" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Estado:"></asp:Label></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEstado" runat="server" Width="120px">
                                                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNombre" Width="120px" MaxLength="35" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label5" runat="server" Text="Tipo"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTipoEmpleado" runat="server" Width="120px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" id="AcceptButton" type="submit" visible="false" value="Crear" name="AcceptButton"
                                                                        runat="server"/>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        &nbsp;
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
