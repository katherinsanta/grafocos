<%@ Page Language="c#" Codebehind="Articulo.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Articulo"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 20px; padding-left: 30px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="2" border="0">
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
                                                                <td style="width: 327px">
                                                                    <asp:TextBox ID="txtCodArt" runat="server" MaxLength="10" Width="312px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text="Descripción:"></asp:Label></td>
                                                                <td style="width: 327px">
                                                                    <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="40" Width="312px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="Label3" runat="server" Text="Categoría:"></asp:Label>
                                                                    <asp:TextBox ID="txtManejaCapturadorVirtual" runat="server" Visible="False" Width="17px">N</asp:TextBox></td>
                                                                <td style="width: 327px">
                                                                    <asp:RadioButtonList ID="optCategoria" runat="server" Width="176px" AutoPostBack="True"
                                                                        RepeatDirection="Horizontal">
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 29px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Unidad de Medida:"></asp:Label></td>
                                                                <td style="height: 29px; width: 327px;">
                                                                    <asp:TextBox ID="txtUnidadMedida" runat="server" MaxLength="4" Width="56px">UND</asp:TextBox>&nbsp;
                                                                    <asp:DropDownList ID="cboUnidadMedida" runat="server" Visible="False" Width="48px"
                                                                        AutoPostBack="True" Enabled="False">
                                                                        <asp:ListItem Value="GL">GL</asp:ListItem>
                                                                        <asp:ListItem Value="M3">M3</asp:ListItem>
                                                                        <asp:ListItem>Lt</asp:ListItem>
                                                                    </asp:DropDownList><asp:Label ID="txtAdvertenciaGas" runat="server" Visible="False"
                                                                        ForeColor="DimGray" Font-Size="XX-Small" Font-Bold="True">*</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 29px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Precio:"></asp:Label></td>
                                                                <td style="height: 29px; width: 327px;">
                                                                    <asp:TextBox onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 46 event.returnValue = false;"
                                                                        ID="txtPrecio" runat="server" MaxLength="10" Width="120px"></asp:TextBox><cc1:FilteredTextBoxExtender
                                                                            id="FilteredTextBoxExtender1" runat="server" targetcontrolid="txtPrecio" validchars="0123456789,.">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server" Text="% Iva:"></asp:Label></td>
                                                                <td style="width: 327px">
                                                                    <asp:TextBox onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                        ID="txtIva" runat="server" MaxLength="2" Width="56px">0</asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 27px">
                                                                    <asp:Label ID="Label7" runat="server" Text="Color:"></asp:Label></td>
                                                                <td style="height: 27px; width: 327px;">
                                                                    <asp:DropDownList ID="cboColor" runat="server" Width="120px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 47px">
                                                                    <asp:Label ID="Label8" runat="server" Text="Número de Cuenta Contable:"></asp:Label></td>
                                                                <td style="width: 327px; height: 47px">
                                                                    <asp:TextBox onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                        ID="txtNumCuenta" runat="server" MaxLength="16"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label9" runat="server" Text="Naturaleza de la Cuenta Contable:"></asp:Label></td>
                                                                <td style="width: 327px">
                                                                    <asp:RadioButtonList ID="optNatCuenta" runat="server" Width="80px" RepeatDirection="Horizontal">
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label10" runat="server" Text="Codigo Alterno:"></asp:Label></td>
                                                                <td style="width: 327px">
                                                                    <asp:TextBox ID="txtCodigoAlterno" runat="server" Width="312px"></asp:TextBox>&nbsp;
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td style="width: 327px">
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input class="Button" id="AcceptButton" visible="false" type="submit" value="Crear"
                                                                        name="AcceptButton" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="txtAdvertencia" runat="server" Visible="False" ForeColor="DimGray"
                                                                        Font-Size="XX-Small" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <!-- End Topic Content -->
                                    </td>
                                    <!-- End Topic Body -->
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
