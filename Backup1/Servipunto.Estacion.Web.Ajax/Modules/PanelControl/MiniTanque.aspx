<%@ Page Language="c#" Codebehind="MiniTanque.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.MiniTanque"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="80%" border="0">
        <tr>
            <td style="padding-right: 30px; padding-left: 40px">
                <br>
                <p>
                    <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0">
                    <tr>
                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="ResultsItem" valign="middle" align="left">
                            <table cellpadding="4" border="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Capacidad"></asp:Label>:</td>
                                    <td>
                                        <asp:TextBox ID="txtCapacidad" Width="100px" MaxLength="100" runat="server"></asp:TextBox>
                                    </td>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Articulo"></asp:Label>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlArticulo" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <input class="Button" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                            runat="server">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>    
