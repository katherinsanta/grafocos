<%@ Page Language="c#" Codebehind="Login.aspx.cs"  AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.Main.Login"
    MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">

    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="top" width="100%" style="height: 315px">
                <!-- Topic Content -->
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td style="padding-right: 30px; padding-left: 40px">
                            <br>
                            <br>
                            <span id="InscriptionSection" runat="server"></span>
                            <p>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                <table class="ResultsTable" cellspacing="1" cellpadding="3" border="0" align="center">
                                    <tr>
                                        <td  valign="middle" align="center" colspan="1">
                                            <asp:Label ID="lblBienvenida" Font-Size="14 px" ForeColor="black" Font-Names="tahoma,geneva,sans-serif" runat="server" Text="Bienvenido a Servipunto Administrativo"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="ResultsItem" valign="middle" align="left">
                                            <div align="center">
                                                <table cellpadding="4" border="0" align="center">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUser" runat="server"  Font-Size="14 px" ForeColor="black" Font-Names="tahoma,geneva,sans-serif" Text="Identificación del Usuario:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtUserID" MaxLength="20" runat="server" TabIndex="1">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblContrasena" runat="server" Font-Size="14 px" ForeColor="black" Font-Names="tahoma,geneva,sans-serif" Text="Contraseña:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPassword" TabIndex="2" MaxLength="20" runat="server" TextMode="Password">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <input class="Button" id="AcceptButton" tabindex="3" type="submit" value="Iniciar Sesión"
                                                                runat="server"><br />
                                                                
                                                                <asp:Label ID="lblInactividad" runat="server" Text="Session Finalizada" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                         
                            <p>
                                &nbsp;</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <uc1:Mensaje ID="Mensaje1" runat="server" />
</asp:Content>
