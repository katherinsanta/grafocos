<%@ Page Language="c#" Codebehind="Usuario.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Usuario"
    MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br/>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0">
                                            <tr>
                                                <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                            <td align="right">
                                                                <asp:HyperLink ID="lblBack" runat="server">
                                                                    <asp:Label ID="Label6" CssClass="LinkTbla" runat="server" Text="Volver"></asp:Label></asp:HyperLink></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="ResultsItem" valign="middle" align="left">
                                                    <table cellpadding="4" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Número de Identificación"></asp:Label>:</td>
                                                            <td>
                                                                <asp:TextBox ID="txtIdUsuario" runat="server" MaxLength="15"></asp:TextBox>
                                                                <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Nombre Completo"></asp:Label>:</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" Width="312px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" style="height: 27px">
                                                                <asp:Label ID="Label3" runat="server" Text="Perfil"></asp:Label>:</td>
                                                            <td style="height: 27px">
                                                                <asp:DropDownList ID="cboRol" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>:</td>
                                                            <td>
                                                                <asp:RadioButtonList ID="optEstado" runat="server" Width="80px">                                                                   
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text="Empleado"></asp:Label>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboEmpleado" runat="server">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td id="SeccionInicializar" runat="server">
                                                                <font color="dimgray">
                                                                    <asp:Label ID="Label7" runat="server" Text="Para reestablecer la contraseña"></asp:Label>, click </font>
                                                                <asp:LinkButton ID="lnkInicializar" runat="server"> 
                                                                    <asp:Label ID="Label8" runat="server" Text="Reestablecer Contraseña"></asp:Label></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>      
                                                                <asp:Button ID="btnCrear" runat="server" Text="Button" OnClick="btnCrear_Click" />                                                          
                                                                <input class="Button" visible="false" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                    runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
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