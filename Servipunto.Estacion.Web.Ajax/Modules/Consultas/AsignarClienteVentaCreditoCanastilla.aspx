<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AsignarClienteVentaCreditoCanastilla.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Consultas.AsignarClienteVentaCreditoCanastilla"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 51%">
                                            <tr>
                                                <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="width: 100%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="ResultsHeader4">
                                                                <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                            <td align="right" class="ResultsHeader4">
                                                                <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="ResultsItem" valign="middle" align="left" style="width: 104%; height: 144px">
                                                    <table cellpadding="4" border="0" style="width: 100%; height: 262px;">
                                                        <tr>
                                                            <td style="width: 286px; height: 29px">
                                                            </td>
                                                            <td style="width: 446px; height: 29px">
                                                            </td>
                                                            <td style="width: 446px; height: 29px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 29px">
                                                                <asp:Label ID="Label2" runat="server" Text="Número"></asp:Label>:</td>
                                                            <td style="width: 446px; height: 29px">
                                                                &nbsp;<asp:Label ID="lblNumero" runat="server" Enabled="False" Width="153px"></asp:Label>
                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                &nbsp;<asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>:
                                                            </td>
                                                            <td style="width: 446px; height: 29px">
                                                                <asp:Label ID="lblEstado" runat="server" Enabled="False" Width="109px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 29px">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 485px; height: 57px">
                                                                    <tr>
                                                                        <td style="width: 2168px">
                                                                            <asp:Label ID="Label4" runat="server" Text="Fecha Emisión"></asp:Label>:</td>
                                                                        <td style="width: 217px">
                                                                            <asp:Label ID="lblFechaEmision" runat="server" Enabled="False" Width="115px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 2168px; height: 20px">
                                                                            <asp:Label ID="Label5" runat="server" Text="Fecha Resolución"></asp:Label></td>
                                                                        <td style="width: 217px; height: 20px">
                                                                            &nbsp;<asp:Label ID="lblFechaResolucion" runat="server" Enabled="False" Width="115px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 2168px; height: 20px">
                                                                            <asp:Label ID="Label6" runat="server" Text="Fecha Vencimiento"></asp:Label>:</td>
                                                                        <td style="width: 217px; height: 20px">
                                                                            &nbsp;<asp:Label ID="lblFechaVencimiento" runat="server" Enabled="False" Width="115px"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 446px; height: 29px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 24px">
                                                                <asp:Label ID="Label7" runat="server" Text="Cliente"></asp:Label>:</td>
                                                            <td style="width: 446px; height: 24px">
                                                                <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" Width="429px"
                                                                    OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                            <td style="width: 446px; height: 24px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px">
                                                            </td>
                                                            <td style="width: 446px">
                                                                <asp:Label ID="lblCod_Cli" runat="server" Enabled="False" Width="229px"></asp:Label></td>
                                                            <td style="width: 446px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 25px">
                                                                <asp:Label ID="Label8" runat="server" Text="Placa"></asp:Label>:</td>
                                                            <td style="width: 446px; height: 25px">
                                                                <asp:DropDownList ID="ddlPlaca" runat="server" AutoPostBack="True" Width="151px">
                                                                </asp:DropDownList></td>
                                                            <td style="width: 446px; height: 25px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 25px">
                                                                <asp:Label ID="Label9" runat="server" Text="Forma Pago"></asp:Label>:</td>
                                                            <td style="width: 446px; height: 25px">
                                                                <asp:Label ID="lblFormaPago" runat="server" Enabled="False" Width="151px"></asp:Label></td>
                                                            <td style="width: 446px; height: 25px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 21px">
                                                                <asp:Label ID="Label10" runat="server" Text="SubTotal"></asp:Label>:</td>
                                                            <td style="width: 446px; height: 21px">
                                                                <asp:Label ID="lblSubTotal" runat="server" Enabled="False" Width="153px"></asp:Label></td>
                                                            <td style="width: 446px; height: 21px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 21px">
                                                                <asp:Label ID="Label11" runat="server" Text="Iva"></asp:Label>:</td>
                                                            <td style="width: 446px; height: 21px">
                                                                <asp:Label ID="lblIva" runat="server" Enabled="False" Width="153px"></asp:Label></td>
                                                            <td style="width: 446px; height: 21px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 21px">
                                                                <asp:Label ID="Label12" runat="server" Text="Total"></asp:Label>:</td>
                                                            <td style="width: 446px; height: 21px">
                                                                <asp:Label ID="lblTotal" runat="server" Enabled="False" Width="153px"></asp:Label></td>
                                                            <td style="width: 446px; height: 21px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2" style="height: 21px">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Width="85%">Detalle</asp:Label></td>
                                                            <td align="center" colspan="1" style="height: 21px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <asp:GridView ID="grdDetalle" runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal"
                                                                AlternatingRowStyle-CssClass="FilaAlternada" HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center"
                                                                AutoGenerateColumns="False" Width="100%" Enabled="False" ShowFooter="false" OnDataBinding="grdFacturas_DataBinding">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Cod_Art" HeaderText="C&#243;digo" />
                                                                    <asp:BoundField HeaderText="Precio" DataField="Precio_Uni" />
                                                                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                                                    <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" />
                                                                    <asp:BoundField DataField="Iva" HeaderText="Iva" />
                                                                    <asp:BoundField DataField="Vr_Iva" HeaderText="Valor Iva" />
                                                                    <asp:BoundField HeaderText="Total" DataField="Total" />
                                                                </Columns>
                                                                <RowStyle CssClass="FilaNormal" />
                                                                <HeaderStyle CssClass="Cabeza" HorizontalAlign="Center" />
                                                                <AlternatingRowStyle CssClass="FilaAlternada" />
                                                            </asp:GridView>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 29px">
                                                                &nbsp;</td>
                                                            <td style="width: 446px; height: 29px">
                                                                &nbsp;<asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 446px; height: 29px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 286px; height: 29px">
                                                            </td>
                                                            <td style="width: 446px; height: 29px">
                                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Asignar" /></td>
                                                            <td style="width: 446px; height: 29px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
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
