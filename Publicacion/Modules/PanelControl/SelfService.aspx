<%@ Page Language="c#" Codebehind="SelfService.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.SelfService"
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
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        &nbsp;
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 192px;
                                                height: 363px">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 299px">
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <p>
                                                                        <asp:LinkButton ID="lkbEliminar" runat="server">Eliminar</asp:LinkButton></p>
                                                                </td>
                                                                <td align="right">
                                                                    |</td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 299px">
                                                        <table cellpadding="4" border="0" style="width: 264px; height: 299px">
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox ID="txtCodigo" runat="server" Width="40px" MaxLength="2"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Valor 1"></asp:Label>:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox ID="txtValor1" runat="server" Width="120px" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Valor 2"></asp:Label>:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox ID="txtValor2" runat="server" Width="120px" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Valor 3"></asp:Label>:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox ID="txtValor3" runat="server" Width="120px" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Valor 4"></asp:Label>:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox ID="txtValor4" runat="server" Width="120px" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label6" runat="server" Text="Valor 5"></asp:Label>:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox ID="txtValor5" runat="server" Width="120px" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label7" runat="server" Text="Valor 6"></asp:Label>:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox ID="txtValor6" runat="server" Width="120px" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    <asp:Label ID="Label8" runat="server" Text="Puerto de Lectura para Fidelización"></asp:Label>&nbsp;:</td>
                                                                <td style="width: 219px">
                                                                    <asp:TextBox onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                        ID="txtPuertoLecturaFidelizacion" runat="server" Width="120px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 103px">
                                                                    &nbsp;</td>
                                                                <td style="width: 219px">
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" id="AcceptButton" type="submit" visible="false" value="Crear"
                                                                        name="AcceptButton" runat="server" />
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
