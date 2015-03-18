<%@ Page Language="c#" Codebehind="ConfiguracionTiqueteVenta.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.ConfiguracionTiqueteVenta"
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
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" style="width: 416px; height: 959px" cellspacing="1" cellpadding="4"
                                                width="416" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="center" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 780px">
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
                                                    <td class="ResultsItem" valign="middle" align="center">
                                                        <table style="width: 367px; height: 895px" height="895" cellpadding="4" width="367"
                                                            border="0">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:CheckBox ID="chkRazonSocial" runat="server" Checked="True" Text="Razón Social">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:CheckBox ID="chkNit" runat="server" Checked="True" Text="Nit" OnCheckedChanged="chkNit_CheckedChanged">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:CheckBox ID="ChkNombreEstacion" runat="server" Checked="True" Text="Nombre Estación">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:CheckBox ID="chkTituloTiquete" runat="server" Checked="True" Text="Titulo Tiquete">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkDireccion" runat="server" Checked="True" Text="Dirección"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 27px" align="left">
                                                                    <asp:CheckBox ID="chkTelefono" runat="server" Checked="True" Text="Teléfono"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkFechaHora" runat="server" Checked="True" Text="Fecha y Hora"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkConsecutivoPlaca" runat="server" Checked="True" Text="Consecutivo y Placa">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkTurnoIsla" runat="server" Text="Turno e Isla" Checked="True"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkSurtidorCara" runat="server" Checked="True" Text="Surtidor y Cara">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkManguera" runat="server" Checked="True" Text="Manguera"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkKilometraje" runat="server" Checked="True" Text="Kilometraje"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkArticulo" runat="server" Checked="True" Text="Articulo"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkMedidaPrecio" runat="server" Checked="True" Text="Medida y Precio">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkValorNeto" runat="server" Checked="True" Text="Valor Neto"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkDescuento" runat="server" Text="Descuento" Checked="True"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkSubtotal" runat="server" Checked="True" Text="Subtotal"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkAbonoCuota" runat="server" Checked="True" Text="Abono Cuota"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkTotal" runat="server" Checked="True" Text="Total"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkFormaPago" runat="server" Text="Forma de Pago" Checked="True"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkNombreCliente" runat="server" Checked="True" Text="Nombre Cliente">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <p align="center">
                                                                        <asp:CheckBox ID="chkAtendio" runat="server" Checked="True" Text="Atendió"></asp:CheckBox></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:CheckBox ID="chkFechaProximaRevision" runat="server" Checked="True" Text="Fecha Proxima Revisión">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:CheckBox ID="chkSlogan" runat="server" Checked="True" Text="Slogan"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkNombreFidelizado" runat="server" Checked="True" Text="Nombre Fidelizado"
                                                                        Enabled="False"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkPuntosFidelizado" runat="server" Checked="True" Text="Puntos"
                                                                        Enabled="False"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkPuntosReservados" runat="server" Checked="True" Text="Puntos Reservados">
                                                                    </asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:CheckBox ID="chkActualizacionPuntos" runat="server" Checked="True" Text="Fecha Actualización Puntos"
                                                                        Enabled="False"></asp:CheckBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                                                                    <input visible="false" class="Button" id="AcceptButton" type="submit" value="Crear" name="AcceptButton"
                                                                        runat="server"></td>
                                                            </tr>
                                                            <tr>
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
