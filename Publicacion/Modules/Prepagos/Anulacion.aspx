<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Anulacion.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.Prepagos.Anulacion"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                <tr>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                        <!-- Page Body -->
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
                                                        <table class="border" cellspacing="1" cellpadding="4" border="0" style="height: 400px;
                                                            background-color: White; border-color: Black;">
                                                            <tr style="height: 30px; width: 502px" class="ResultsTable">
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ResultsItem" colspan="2" valign="middle" align="left" style="width: 461px;
                                                                    height: 393px;">
                                                                    <table cellpadding="4" border="0" style="width: 451px; height: 375px;">
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblNUMBER" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtNumeroInicial" runat="server" MaxLength="12" Width="135px">
                                                                                </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumeroInicial"
                                                                                    ErrorMessage="Requerido">
                                                                                </asp:RequiredFieldValidator>
                                                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="..." />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblCustome" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtCod_Cli" runat="server" MaxLength="12" ReadOnly="True" Width="135px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblName" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtNombre" runat="server" MaxLength="12" ReadOnly="True" Width="313px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblValue" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtValor" runat="server" MaxLength="12" ReadOnly="True" Width="135px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblEstado" runat="server" Height="22px" Text="Estado"></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtEstado" runat="server" MaxLength="12" ReadOnly="True" Width="135px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblFechCre" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtFechaCreacion" runat="server" MaxLength="12" ReadOnly="True"
                                                                                    Width="135px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblFechFinal" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtFechaAsignacion" runat="server" MaxLength="12" ReadOnly="True"
                                                                                    Width="135px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblFechaUso" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtFechaUtilizacion" runat="server" MaxLength="12" ReadOnly="True"
                                                                                    Width="135px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblAnul" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtFechaAnulacion" runat="server" MaxLength="12" ReadOnly="True"
                                                                                    Width="135px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Label ID="lblCausal" runat="server" Height="22px" Text=""></asp:Label>
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:TextBox ID="txtCausal" runat="server" Height="54px" MaxLength="12" Width="277px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="height: 29px; width: 150px;">
                                                                                <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Cancelacion"
                                                                                    Height="32px" />&nbsp;
                                                                                <asp:Label ID="lblHide" runat="server" Visible="False">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <uc1:Mensaje ID="Mensaje1" runat="server" />
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
                        <!-- End Page Body -->
                    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
