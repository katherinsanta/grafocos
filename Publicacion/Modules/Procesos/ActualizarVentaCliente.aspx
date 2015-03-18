<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" AutoEventWireup="true"
    Codebehind="ActualizarVentaCliente.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.Procesos.ActualizarVentaCliente"
    Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <blockquote>
        <font class="NormalFont">
            <asp:Label ID="lblError" Visible="false" ForeColor="Red" runat="server"></asp:Label>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 750px">
            <tr>
                <td align="right" style="height: 15px">
                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <!--Inicio Formulario-->
        <table style="width: 292px">
            <tr>
                <td style="width: 288px; height: 326px;">
                    <table>
                        <tr>
                            <td style="width: 111px">
                                <asp:Label ID="lblNTiquete" runat="server" Text="Nº Tiquete: "></asp:Label>
                            </td>
                            <td style="width: 127px">
                                <asp:TextBox ID="txtTiquete" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="BtnBuscarTiquete" runat="server" Text="Buscar" OnClick="BtnBuscarTiquete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 76px; height: 28px">
                                <br />
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="pnlDatos" runat="server" Enabled="False" >
                        <table>
                            <tr>
                                <td style="width: 111px">
                                    <asp:Label ID="LblPlaca" runat="server" Text="Placa"></asp:Label>
                                </td>
                                <td style="width: 127px">
                                    <asp:TextBox ID="txtPlaca" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 111px; height: 23px;">
                                    <asp:Label ID="lblCodCli" runat="server" Text="Codigo Cliente"></asp:Label>
                                </td>
                                <td style="width: 127px; height: 23px;">
                                    <asp:TextBox ID="txtCodCli" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 111px">
                                    <asp:Label ID="lblFormaPago" runat="server" Text="Forma De Pago"></asp:Label>
                                </td>
                                <td style="width: 127px">
                                    <asp:TextBox ID="txtFormaPago" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 111px">
                                    <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                </td>
                                <td style="width: 127px">
                                    <asp:TextBox ID="txtTotalVenta" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 111px; height: 23px;">
                                </td>
                                <td style="height: 23px">
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar" Width="59px" OnClick="btnEditar_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Panel ID="PnlEditar" runat="server" Enabled = "false" >
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Label ID="lblCodClienteEdit" runat="server" Text="Codigo Cliente"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCodCliEdit" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Label ID="lblPlacaEdit" runat="server" Text="Placa"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPlacaEdit" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 41px;">
                                        <asp:Label ID="lblFormaPagoEdit" runat="server" Text="Forma De Pago"></asp:Label>
                                    </td>
                                    <td style="height: 41px">
                                        <asp:DropDownList ID="ddlFormaDePagoEdit" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="ModificarDatosVenta">Guardar</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Cancelar</asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
