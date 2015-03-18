<%@ Page Language="c#" Codebehind="Impresora.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Impresora"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <p>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
    <br />
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="4" style="margin-left: 5%; border: solid 1px #917D82"
            width="80%" border="0">
            <tr style="background-color: #999999">
                <td style="width: 828px" colspan="2">
                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                <td align="right" colspan="2">
                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label1" runat="server" Text="Nombre de la Impresora"></asp:Label>:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlNombreImpresora" runat="server" Width="120px">
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label19" runat="server" Text="Cantidad de Copias de Canastilla"></asp:Label>:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCantCanastilla" runat="server" Width="120px" MaxLength="2">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label2" runat="server" Text="Cantidad de Copias de Cheques"></asp:Label>:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCantCheques" runat="server" Width="120px" MaxLength="2">0</asp:TextBox></td>
                <td style="width: 293px">
                    <asp:Label ID="Label20" runat="server" Text="Cantidad de Copias de Credito Directo"></asp:Label>:</td>
                <td align="left">
                    <asp:TextBox ID="txtCantCreditoDirecto" runat="server" Width="120px" MaxLength="2">0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label38" runat="server" Text="Cantidad de Copias de Ventas en Efectivo"></asp:Label>:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCantEfectivo" runat="server" Width="120px" MaxLength="2">0</asp:TextBox></td>
                <td style="width: 293px">
                    <asp:Label ID="Label21" runat="server" Text="Cantidad de Copias de Tarjeta de Credito"></asp:Label>:</td>
                <td align="left">
                    <asp:TextBox ID="txtCantTarjetaCredito" runat="server" Width="120px" MaxLength="2">0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label3" runat="server" Text="Cantidad de Copias de Tarjeta Débito / Ahorros"></asp:Label>:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCantDebitoAhorros" runat="server" Width="120px" MaxLength="2">0</asp:TextBox></td>
                <td style="width: 293px">
                    <asp:Label ID="Label22" runat="server" Text="Cantidad de Copias de Tarjeta Débito / Corriente"></asp:Label>:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCantDebitoCorriente" runat="server" Width="120px" MaxLength="2">0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label4" runat="server" Text="Número del POS"></asp:Label>:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNumeroPos" runat="server" Width="120px" MaxLength="2" Enabled="False">0</asp:TextBox></td>
                <td style="width: 293px">
                    <asp:Label ID="Label23" runat="server" Text="Tipo de Impresora"></asp:Label>:</td>
                <td align="left">
                    <!--
                                                                        //Fecha:        17-03-2011
                                                                        //Autor:        Miguel Cantor L.
                                                                        //Descripción:  Se añade el control ddlMensajes para definir el tipo de presentación para los mensajes
                                                                        //Presentes:    N/A
                                                                    -->
                    <!--
                                                                        //Fecha:        16-03-2011
                                                                        //Autor:        Miguel Cantor L.
                                                                        //Descripción:  Se añade el tipo de impresora DATAFONO
                                                                        //Presentes:    Luisa Maca
                                                                    -->
                    <asp:DropDownList ID="ddlTipoImpresora" runat="server" Width="120px" AutoPostBack="True">
                        <asp:ListItem Value="M" Selected="True">Matriz</asp:ListItem>
                        <asp:ListItem Value="T">Termica</asp:ListItem>
                        <asp:ListItem Value="L">Laser</asp:ListItem>
                        <asp:ListItem Value="I">Inyeccion</asp:ListItem>
                        <asp:ListItem Value="W">Wayne Axiom</asp:ListItem>
                        <asp:ListItem Value="D">Datafono</asp:ListItem>
                        <asp:ListItem Value="P">Wayne Fujitsu</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMensajes" runat="server" Width="120px" AutoPostBack="True"
                        Visible="False">
                        <asp:ListItem Value="I" Selected="True">Impresi&#243;n</asp:ListItem>
                        <asp:ListItem Value="P">Pantalla</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPuerto" runat="server" Visible="False" Width="120px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label5" runat="server" Text="Abrir Turno"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlAbrirTurno" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label24" runat="server" Text="Imprimir Formas de Pago en el Reporte Cierre de Turno"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlFormasPagoCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label6" runat="server" Text="Imprimir Tiquetes Canastilla"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlImprimirTiquetesCanastilla" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label25" runat="server" Text="Imprime Lecturas Mecánicas en el Reporte Cierre de Turno"
                        Width="173px"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlLectMecanciasCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label7" runat="server" Text="Imprimir Tiquetes Efectivo"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlImprimirTiquetesEfectivo" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label26" runat="server" Text="Imprimir Lecturas Mecánicas en el Reporte X"
                        Width="171px"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlLectMecanciasX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label8" runat="server" Text="Imprimir Bolsas de Turno en el Reporte de Cierre de Turno"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlBolsaCierreTurno" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label27" runat="server" Text="Imprimir Número de Vehículos en el Reporte Cierre de Turno"
                        Width="172px"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlNVehiculosCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label9" runat="server" Text="Imprimir Canastilla en el Reporte de Cierre de Turno"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlCanastillaCierreTurno" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label28" runat="server" Text="Imprimir Número de Vehículos en el Reporte X"
                        Width="173px"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlNVehiculosX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label10" runat="server" Text="Imprimir Cheques en el Reporte Cierre de Turno"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlChequesCierreTurno" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label29" runat="server" Text="Imprimir Ventas Crédito Directo en el Reporte Cierre de Turno"
                        Width="178px"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlCreditoDirectoCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px; height: 23px">
                    <asp:Label ID="Label11" runat="server" Text="Imprimir Detalle de Tanques en el Reporte Cierre de Turno"></asp:Label>:</td>
                <td style="height: 23px" align="left">
                    <asp:DropDownList ID="ddlDetalleTanquesCierreTurno" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px; height: 23px">
                    :<asp:Label ID="Label30" runat="server" Text="Imprimir Ventas Crédito Directo en el Reporte X"
                        Width="176px"></asp:Label></td>
                <td style="height: 23px" align="left">
                    <asp:DropDownList ID="ddlCreditoDirectoX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label12" runat="server" Text="Imprimir Detalle de Ventas en el Reporte Cierre de Turno"
                        Width="244px"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlDetalleVentasCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label31" runat="server" Text="Imprimir Ventas no Impresas en Cierre"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlVentasNoImpresasCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label13" runat="server" Text="Imprimir el Reporte X"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlReporteX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label32" runat="server" Text="Imprimir Detalle de Ventas en el Reporte X"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlDetalleVentasX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label14" runat="server" Text="Imprimir Canastilla en el Reporte X"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlCanastillaX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label33" runat="server" Text="Imprimir Bolsas de Turno en el Reporte X"
                        Width="187px"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlBolsaTurnoX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label15" runat="server" Text="Imprimir Cheques en el Reporte X"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlChequesX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label34" runat="server" Text="Imprimir el Reporte Cierre de Turno"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlReporteCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label16" runat="server" Text="Imprime Formas de Pago en el Reporte X"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlFormasPagoX" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label35" runat="server" Text="Imprime Tiquetes Venta a Venta"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlVentasNoCierre" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label17" runat="server" Text="Imprime Tiquete de Fidelizado"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlImprimeFidelizado" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label36" runat="server" Text="Imprime Ventas en Cero"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlImprimirVentaEnCero" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px">
                    <asp:Label ID="Label18" runat="server" Text="Imprime Cupo Disponible"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlImprimirCupoDisponible" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px">
                    <asp:Label ID="Label37" runat="server" Text="Imprime Tiquete Copia"></asp:Label>:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlImprimirTiqueteCopia" runat="server" Width="120px">
                        <asp:ListItem Value="1" Selected="True">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 298px; height: 27px">
                    <asp:Label ID="lblImprimirIqueteValidacionSuic" runat="server" Text="Imprime Tiquete Validación Suic:"></asp:Label></td>
                <td align="left" style="height: 27px">
                    <asp:DropDownList ID="ddlImprimirIqueteValidacionSuic" runat="server" Width="120px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 293px; height: 27px">
                </td>
                <td align="left" style="height: 27px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                    <input class="Button" visible="false" id="AcceptButton" type="submit" value="Crear"
                        name="AcceptButton" runat="server" />
                    <asp:Label ID="lblHidePos" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblHideCapturador" runat="server" Visible="False"></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
