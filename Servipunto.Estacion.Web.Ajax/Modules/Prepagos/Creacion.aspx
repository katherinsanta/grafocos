<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Creacion.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Prepagos.Creacion"
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
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">
                                                                    <asp:Label ID="lblTitulo" runat="server"  Height="22px" Text="" Width="232px"></asp:Label>
                                                                    </asp:Label></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 438px">
                                                        <table cellpadding="4" border="0" style="width: 387px">
                                                            <tr>
                                                                <td style="height: 29px">
                                                                    <span closure_uid_9y98hg="162" title="" xc="NUMERO INICIAL" yc="INITIAL ISSUE">
                                                                     <asp:Label ID="lblIniNumber" runat="server"  Height="22px" Text="" Width="232px"></asp:Label>
                                                                    </span></td>
                                                                <td style="height: 29px; width: 263px;">
                                                                    <asp:TextBox ID="txtNumeroInicial" runat="server" MaxLength="12" Width="135px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumeroInicial"
                                                                        ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span closure_uid_9y98hg="164" style="color: #000; background-color: #e6ecf9" title=""
                                                                        xc="NUMERO FINAL" yc="FINAL NUMBER">
                                                                         <asp:Label ID="lblFinalNumber" runat="server"  Height="22px" Text="" Width="232px"></asp:Label></span></td>
                                                                <td style="width: 263px">
                                                                    <asp:TextBox ID="txtNumeroFinal" runat="server" MaxLength="12" Width="135px" AutoPostBack="True"
                                                                        OnTextChanged="txtNumeroFinal_TextChanged"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumeroFinal"
                                                                        ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                 <asp:Label ID="lblQUANTITY" runat="server"  Height="22px" Text="" Width="232px"></asp:Label>
                                                                    </td>
                                                                <td style="width: 263px">
                                                                    <asp:TextBox ID="txtCantidad" runat="server" MaxLength="10" Width="135px" AutoPostBack="True"
                                                                        OnTextChanged="txtCantidad_TextChanged"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCantidad"
                                                                        ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 27px">
                                                                     <asp:Label ID="lblValue" runat="server"  Height="22px" Text="" Width="232px"></asp:Label></td>
                                                                <td style="height: 27px; width: 263px;">
                                                                    <asp:DropDownList ID="ddlDenominaciones" runat="server" AutoPostBack="True" OnTextChanged="ddlDenominaciones_TextChanged"
                                                                        Width="135px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 27px">
                                                                 <asp:Label ID="lblTotalValue" runat="server"  Height="22px" Text="" Width="232px"></asp:Label>
                                                                    </td>
                                                                <td style="height: 27px; width: 263px;">
                                                                    <asp:TextBox ID="txtTotalDenominacion" runat="server" Enabled="False" MaxLength="15"
                                                                        ReadOnly="True" Width="135px" AutoPostBack="True" OnTextChanged="txtTotalDenominacion_TextChanged"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 29px">
                                                                    &nbsp;</td>
                                                                <td style="width: 263px; height: 29px;">
                                                                    <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Crear" />&nbsp;
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <p>
                                                &nbsp;</p>
                                        </asp:Panel>
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
