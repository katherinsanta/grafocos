<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RegistroCompraCanastilla.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Ajax.Modules.Procesos.RegistroCompraCanastilla"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" style="height: 100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" style="width: 100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red">
                                        </asp:Label><p />
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 750px">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="height: 42px">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="height: 15px">
                                                                    <asp:Label ID="lblFormTitle" runat="server">Título</asp:Label>
                                                                </td>
                                                                <td align="right" style="height: 15px">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="height: 179px">
                                                        <table  border="0" style="width: 739px">
                                                            <tr>
                                                                <td colspan="2" style="height: 12px">
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 768px; height: 70px">
                                                                        <tr>
                                                                            <td style="width: 17px; height: 41px">
                                                                                &nbsp;
                                                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 359px; height: 30px">
                                                                                    <tr>
                                                                                        <td style="width: 47px; height: 9px">
                                                                                            Fecha Zeta:
                                                                                        </td>
                                                                                        <td style="width: 13px; height: 9px">
                                                                                            &nbsp;<asp:TextBox ID="txtFechaJornada" runat="server" Width="114px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="width: 100px; height: 9px">
                                                                                            <asp:ImageButton ID="img" runat="server" OnClick="img_Click" ImageUrl="~/BlueSkin/Icons/2011/Busqueda- 24.png" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 17px">
                                                                                <asp:Calendar ID="cldFechaInicio" runat="server" BackColor="White" BorderColor="SteelBlue"
                                                                                    Visible="False">
                                                                                    <SelectedDayStyle BackColor="Navy" />
                                                                                </asp:Calendar>
                                                                            </td>
                                                                        </tr>
                                                                       
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 90px;" colspan="2">
                                                                    <asp:DataGrid ID="dtgInventarioCanastilla" runat="server" Width="768px" AutoGenerateColumns="False"
                                                                        OnDataBinding="grdFacturas_DataBinding" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                                        Height="106px">
                                                                        <Columns>
                                                                            <asp:BoundColumn DataField="Cod_Art" HeaderText="Codigo"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Articulo" HeaderText="Articulo"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="FacturaCompra" HeaderText="Compra Fact." DataFormatString="{0:N0}">
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Salidas" HeaderText="Ventas" DataFormatString="{0:N0}"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="SaldoSistema" HeaderText="Saldo Sist." DataFormatString="{0:N0}">
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="SaldoFisico" HeaderText="Saldo Fis." DataFormatString="{0:N0}">
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Sobrante" HeaderText="Sobrante" DataFormatString="{0:N0}">
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Faltante" HeaderText="Faltante" DataFormatString="{0:N0}">
                                                                            </asp:BoundColumn>
                                                                            <asp:EditCommandColumn UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#DEDEDE" Font-Bold="True" ForeColor="White" />
                                                                        <EditItemStyle BackColor="#999999" />
                                                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <PagerStyle BackColor="#C5CDD9" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingItemStyle BackColor="White" ForeColor="#C5CDD9" />
                                                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                        <HeaderStyle BackColor="#C5CED9" Font-Bold="True" ForeColor="White" />
                                                                    </asp:DataGrid>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px; height: 13px">
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Larger" Text="Inventario Articulo:"
                                                                        Width="154px"></asp:Label></td>
                                                                <td align="left" style="width: 617px; height: 13px">
                                                                    <asp:TextBox ID="txtArticulo" runat="server" Width="542px" BackColor="Beige"></asp:TextBox>
                                                                    <asp:Label ID="lblCod_Art" runat="server" Text="Label" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px; height: 24px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Compra Factura:"></asp:Label>
                                                                </td>
                                                                <td style="width: 617px; height: 24px">
                                                                    <asp:TextBox ID="txtCompraFactura" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px; height: 24px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Ventas:"></asp:Label>
                                                                </td>
                                                                <td style="width: 617px; height: 24px">
                                                                    <asp:TextBox ID="txtVentas" runat="server" Enabled="False"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px; height: 24px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Saldo Sistema:"></asp:Label>
                                                                </td>
                                                                <td style="width: 617px; height: 24px">
                                                                    <asp:TextBox ID="txtSaldoSistema" runat="server" Enabled="False"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px">
                                                                    <asp:Label ID="lblSaldoFisico" runat="server" Text="Saldo Fisico:"></asp:Label>
                                                                </td>
                                                                <td style="width: 617px">
                                                                    <asp:TextBox ID="txtSaldoFisico" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px">
                                                                    <asp:Label ID="lblSobrante" runat="server" Text="Sobrante"></asp:Label>
                                                                </td>
                                                                <td style="width: 617px">
                                                                    <asp:TextBox ID="txtSobrante" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px; height: 29px;">
                                                                    <asp:Label ID="lblFaltante" runat="server">Faltante</asp:Label>
                                                                </td>
                                                                <td style="width: 617px; height: 29px;">
                                                                    <asp:TextBox ID="txtFaltante" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 114px; height: 29px">
                                                                </td>
                                                                <td style="width: 617px; height: 29px">
                                                                    <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click1" Text="Actualizar"
                                                                        Width="128px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
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
    </table>
</asp:Content>
