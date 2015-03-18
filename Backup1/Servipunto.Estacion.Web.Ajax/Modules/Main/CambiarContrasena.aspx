<%@ Page Language="c#" Codebehind="CambiarContrasena.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.Main.CambiarContrasena" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table style="height:100%" cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                    <td>
                                        <br />
                                        <table>
                                            <tr>
                                                <tr>
                                                    <td id="SeccionMensaje" valign="top" runat="server">
                                                        <font color="gray"></font>
                                                    </td>
                                                </tr>
                                        </table>
                                        <span id="InscriptionSection" runat="server"></span>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" align="center" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="center" colspan="2">
                                                        <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" border="0" style="width:450px" >
                                                            <!--<tr>
																	<td>Contraseña Anterior:</td>
																	<td style="WIDTH: 221px"><asp:textbox id="txtPasswordAnterior" tabIndex="2" TextMode="Password" Runat="server" MaxLength="20"></asp:textbox></td>
																</tr>-->
                                                            <tr>
                                                                <td style="width:160px;"> 
                                                                    <asp:Label ID="Label1" runat="server" Text="Contraseña Nueva"></asp:Label>:</td>
                                                                <td style="width: 221px">
                                                                    <asp:TextBox ID="txtPassword" TabIndex="2" MaxLength="20" runat="server" TextMode="Password">
                                                                    </asp:TextBox>
                                                                    <font color="dimgray" size="1">
                                                                        <asp:Label ID="Label2" runat="server" Text="(de 4 a 20 caracteres)"></asp:Label>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width:160px;">
                                                                    <asp:Label ID="Label3" runat="server" Text="Confirmar Contraseña"></asp:Label>:</td>
                                                                <td style="width: 221px">
                                                                    <asp:TextBox ID="txtConfirmar" TabIndex="2" MaxLength="20" runat="server" TextMode="Password"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td style="width: 221px">
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Cambiar" />
                                                                    <input class="Button" id="AcceptButton" visible="false" tabindex="3" type="submit"
                                                                        value="Cambiar Contraseña" name="AcceptButton" runat="server">
                                                                    &nbsp;<input class="Button" id="CancelButton" onclick="window.navigate('Default.aspx');"
                                                                        type="button" value="Cancelar" name="CancelButton" />
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
    </table>
</asp:Content>
