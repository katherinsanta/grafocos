<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TanqueVariacionMensaje.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Variaciones.TanqueVariacionMensaje"
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
                            <table cellspacing="0" cellpadding="0" style="padding-left:30px; padding-top:20px;" width="100%" border="0">
                                <tr>
                                    <td>
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" id="Table4" cellspacing="1" cellpadding="4" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table id="Table5" width="100%">
                                                            <tr>
                                                                <td style="width: 224px">
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lblGuardar" runat="server">Adicionar</asp:LinkButton>&nbsp;
                                                                    <asp:LinkButton ID="lblCancelar" runat="server">Cancelar</asp:LinkButton>&nbsp;
                                                                    <asp:HyperLink ID="lblBack" runat="server" NavigateUrl="Tanques.aspx">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table id="Table6" cellpadding="0" border="0">
                                                            <tr>
                                                                <td style="width: 258px; height: 14px" colspan="2">
                                                                </td>
                                                                <td style="width: 82px; height: 14px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 82px" colspan="3">
                                                                    <div align="left">
                                                                        <asp:DataGrid ID="lstMensajes" runat="server" Width="376px" BorderColor="#FFC0C0"
                                                                            BackColor="Linen" AutoGenerateColumns="False" BorderStyle="Dotted" OnDataBinding="lstMensajes_DataBinding">
                                                                            <Columns>
                                                                                <asp:BoundColumn DataField="ValorInicial" HeaderText="Valor Inicial"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="ValorFinal" HeaderText="Valor Final"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="Mensaje" HeaderText="Mensaje"></asp:BoundColumn>
                                                                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel"
                                                                                    EditText="Edit"></asp:EditCommandColumn>
                                                                                <asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
                                                                            </Columns>
                                                                        </asp:DataGrid></div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 89px">
                                                                </td>
                                                                <td style="width: 137px">
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 89px">
                                                                </td>
                                                                <td style="width: 137px">
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 89px; height: 27px" valign="top">
                                                                    <p align="left">
                                                                        <asp:Label ID="Label1" runat="server" Text="Valor Inicial"></asp:Label>:</p>
                                                                </td>
                                                                <td style="width: 137px; height: 27px">
                                                                    <asp:TextBox ID="txtValorInicial" Width="100px" runat="server" MaxLength="100" DESIGNTIMEDRAGDROP="839"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtValorInicial"
                                                                        ErrorMessage="Falta!"></asp:RequiredFieldValidator></td>
                                                                <td style="height: 27px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 89px" valign="top">
                                                                    <p align="left">
                                                                        <asp:Label ID="Label2" runat="server" Text="Valor Final"></asp:Label>:</p>
                                                                </td>
                                                                <td style="width: 137px">
                                                                    <asp:TextBox ID="txtValorFinal" Width="100px" runat="server" MaxLength="100"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtValorInicial"
                                                                        ErrorMessage="Falta!"></asp:RequiredFieldValidator></td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 89px; height: 21px">
                                                                    <p align="left">
                                                                        <asp:Label ID="Label3" runat="server" Text="Mensaje"></asp:Label>:</p>
                                                                </td>
                                                                <td style="width: 137px; height: 21px">
                                                                    <asp:TextBox ID="txtMensaje" Width="100px" runat="server" MaxLength="100"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValorFinal"
                                                                        ErrorMessage="Falta!"></asp:RequiredFieldValidator></td>
                                                                <td style="height: 21px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 89px">
                                                                    <asp:TextBox ID="txtIdTanque" runat="server" Visible="False" Width="24px"></asp:TextBox><asp:TextBox
                                                                        ID="txtIdMensaje" runat="server" Visible="False" Width="24px"></asp:TextBox></td>
                                                                <td id="SeccionInicializar" style="width: 137px" runat="server">
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 89px">
                                                                    &nbsp;</td>
                                                                <td style="width: 137px">
                                                                    &nbsp;</td>
                                                                <td>
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
