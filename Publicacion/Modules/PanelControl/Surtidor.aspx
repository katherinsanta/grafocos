<%@ Page Language="c#" Codebehind="Surtidor.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Surtidor"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" style="height: 100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" style="width: 100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="350">
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
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 395px">
                                                        <table cellpadding="4" border="0">
                                                            <tr>
                                                                <td style="width: 184px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Número del Surtidor"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtId" runat="server" MaxLength="2" Width="100px"></asp:TextBox>
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblHideIsla" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" style="width: 184px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Marca"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboMarca" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                    <br/>
                                                                    <asp:Label ID="Label9" runat="server" Text="Protocolo Especial"></asp:Label>:
                                                                    <asp:TextBox ID="txtProtocolo" runat="server" MaxLength="10" Width="104px">L00</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Densidad"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDensidad" runat="server" MaxLength="10" Width="100px">0</asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Factor de División"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFactorDivision" runat="server" MaxLength="4" Width="100px">1</asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Tiempo de Espera para Estado"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTiempoEstado" runat="server" Width="96px">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px">
                                                                    <asp:Label ID="Label6" runat="server" Text="Tiempo de Espera para Despacho"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTiempoDespacho" runat="server" Width="96px">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px; height: 34px">
                                                                    <asp:Label ID="Label7" runat="server" Text="Tiempo de Autorización"></asp:Label>:</td>
                                                                <td style="height: 34px">
                                                                    <asp:TextBox ID="txtAutorizacion" runat="server" Width="96px">0</asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px">
                                                                    <asp:Label ID="Label8" runat="server" Text="Tiempo de Totalizadores"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTotalizadores" runat="server" Width="96px">0</asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px">
                                                                </td>
                                                                <td bgcolor="#ffffcc">
                                                                    <p align="center">
                                                                        <br/>
                                                                        <asp:Label ID="Label10" runat="server" Text="Ayuda para configuración"></asp:Label>
                                                                        <br/>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 184px">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" id="AcceptButton" type="submit" visible="false" value="Crear" name="AcceptButton"
                                                                        runat="server"/>
                                                                </td>
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
