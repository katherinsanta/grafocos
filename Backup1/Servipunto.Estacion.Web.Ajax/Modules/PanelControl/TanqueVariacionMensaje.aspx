<%@ Page Language="c#" Codebehind="TanqueVariacionMensaje.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.TanqueVariacionMensaje"
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
                                        <br>
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
                                                        <table id="Table6" cellpadding="4" border="0">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <div align="left">
                                                                        <asp:DataGrid ID="lstMensajes" runat="server" Width="280px" BorderColor="#FFC0C0"
                                                                            BackColor="Linen" AutoGenerateColumns="False" BorderStyle="Dotted" >
                                                                            <Columns>
                                                                                <asp:BoundColumn DataField="ValorInicial" HeaderText="Initial Value"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="ValorFinal" HeaderText="Final Value"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="Mensaje" HeaderText="Messages"></asp:BoundColumn>
                                                                                <asp:EditCommandColumn UpdateText="Update" CancelText="Cancelar"
                                                                                    EditText="Edit"></asp:EditCommandColumn>
                                                                                <asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
                                                                            </Columns>
                                                                        </asp:DataGrid></div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 27px" valign="top">
                                                                </td>
                                                                <td style="height: 27px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 27px" valign="top">
                                                                    <asp:Label ID="Label1" runat="server" Text="Valor Inicial"></asp:Label>:</td>
                                                                <td style="height: 27px">
                                                                    <asp:TextBox ID="txtValorInicial" Width="100px" runat="server" MaxLength="100" DESIGNTIMEDRAGDROP="839"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtValorInicial"
                                                                        ErrorMessage="Falta!"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" style="height: 29px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Valor Final"></asp:Label>:</td>
                                                                <td style="height: 29px">
                                                                    <asp:TextBox ID="txtValorFinal" Width="100px" runat="server" MaxLength="100"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtValorInicial"
                                                                        ErrorMessage="Falta!"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Mensaje"></asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMensaje" Width="100px" runat="server" MaxLength="100"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValorFinal"
                                                                        ErrorMessage="Falta!"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtIdTanque" runat="server" Visible="False" Width="24px"></asp:TextBox>
                                                                    <asp:TextBox ID="txtIdMensaje" runat="server" Visible="False" Width="24px"></asp:TextBox></td>
                                                                <td id="SeccionInicializar" runat="server">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
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
