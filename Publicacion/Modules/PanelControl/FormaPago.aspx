<%@ Page Language="c#" Codebehind="FormaPago.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.FormaPago"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table style="height: 100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" style="height: 100%">
                <table style="height: 100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" style="width: 100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <input id="ActiveTab" type="hidden" value="CuentaEstandar" name="ActiveTab" />
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lblGuardar1" runat="server">Guardar</asp:LinkButton>&nbsp;&nbsp;<asp:HyperLink
                                                                        ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                        <input class="Button" id="AcceptButton" style="width: 8px; height: 7px" type="submit"
                                                            value="Crear" name="AcceptButton" runat="server" visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" width="100%" border="0">
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>:</td>
                                                                <td style="width: 187px">
                                                                    <asp:TextBox ID="txtId" runat="server" MaxLength="2" Width="48px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>:</td>
                                                                <td style="width: 187px">
                                                                    <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="30" Width="312px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                    <asp:Label ID="Label4" runat="server" Text="Soporta transmisión en línea"></asp:Label>:</td>
                                                                <td style="width: 187px">
                                                                    <asp:RadioButtonList ID="optTransmisionOnline" runat="server" Width="80px" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                    <asp:Label ID="Label5" runat="server" Text="Requiere consecutivo de ventas"></asp:Label>:</td>
                                                                <td style="width: 187px">
                                                                    <asp:RadioButtonList ID="optConsecutivo" runat="server" Width="80px" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                    <asp:Label ID="Label6" runat="server" Text="Imprimir Detalle en Cierre de Turno"></asp:Label></td>
                                                                <td style="width: 187px">
                                                                    <asp:RadioButtonList ID="optDetalleCierreTurno" runat="server" Width="80px" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    &nbsp;</td>
                                                                <td style="width: 187px">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <!-- Tabs para cuentas -->
                                                        <table id="TabControl" width="100%">
                                                            <tr>
                                                                <td colspan="5">
                                                                    <cc1:TabContainer ID="TabContainer1" runat="server">
                                                                        <cc1:TabPanel ID="TabPanelFilaCuentaEstandar" runat="server" HeaderText='<%# Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma) %>'
                                                                            Width="100%">
                                                                            <ContentTemplate>
                                                                                <table id="tableFilaCuentaEstandar" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                    <!-- Inicio fila para cuentas Estandar -->
                                                                                    <tr>
                                                                                        <td style="width: 90%">
                                                                                            <asp:Label ID="lblTituloGenerales" runat="server"><b>Parametros para la 
																										generación de archivos planos estandares</b></asp:Label></td>
                                                                                        <td align="right" style="width: 5%">
                                                                                            <asp:LinkButton ID="lblGuardar2" runat="server">Guardar</asp:LinkButton></td>
                                                                                        <td align="right" style="width: 5%">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas generales -->
                                                                                            <table id="TablaGeneral" cellpadding="4" width="100%" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 203px" valign="top">
                                                                                                            <asp:Label ID="Label9" runat="server" Text="     de Cuenta Contable"></asp:Label>:</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) && event.keyCode != 44) event.returnValue = false;"
                                                                                                                ID="txtNumCuenta" runat="server"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 203px" valign="top">
                                                                                                            <asp:Label ID="Label10" runat="server" Text="Naturaleza de la Cuenta Contable"></asp:Label>:</td>
                                                                                                        <td>
                                                                                                            <asp:RadioButtonList ID="optNatCuenta" runat="server" Width="80px" RepeatDirection="Horizontal">
                                                                                                            </asp:RadioButtonList></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 203px" valign="top">
                                                                                                            <asp:Label ID="Label11" runat="server" Text="Definición de Terceros"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:CheckBox ID="chkTerCuenta" runat="server" Text="Tiene Terceros"></asp:CheckBox>
                                                                                                            <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                                                                            *</td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" style="height: 34px">
                                                                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="True" Text="* Si tiene terceros afectara el Nit del cliente"
                                                                                                                Width="330px"></asp:Label></td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <!-- Fin fila para cuentas Estandar -->
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </cc1:TabPanel>
                                                                        <cc1:TabPanel ID="TabPanelFilaCuentaSAP" runat="server" HeaderText='<%# Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1279, Servipunto.Estacion.Web.Global.Idioma) %>'
                                                                            Width="100%">
                                                                            <ContentTemplate>
                                                                                <table id="tableFilaCuentaSAP" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                    <!-- Inicio fila para cuentas SAP -->
                                                                                    <tr class="Oculto" id="FilaCuentaSAP">
                                                                                        <td colspan="5">
                                                                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                                <tr class="ResultsHeader4" valign="middle" align="left">
                                                                                                    <td width="90%">
                                                                                                        <asp:Label ID="Label1" runat="server"><b>Parametros para la generación de 
																							archivos planos de SAP</b></asp:Label></td>
                                                                                                    <td align="right" width="5%">
                                                                                                        <asp:LinkButton ID="lblGuardar3" runat="server">Guardar</asp:LinkButton>
                                                                                                    </td>
                                                                                                    <td align="right" width="5%">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                        <!-- Tabla que contiene las entradas generales -->
                                                                                                        <table id="TablaGeneral2" cellpadding="4" width="100%" border="0">
                                                                                                            <tr>
                                                                                                                <td style="width: 396px; font-style: italic; height: 20px" valign="top" align="center"
                                                                                                                    colspan="2">
                                                                                                                    <asp:Label ID="Label12" runat="server" Text="Cuenta Crédito"></asp:Label></td>
                                                                                                                <td style="width: 199px; font-style: italic; height: 20px" valign="top" align="center"
                                                                                                                    colspan="3">
                                                                                                                    <asp:Label ID="Label13" runat="server" Text="Cuenta Debito"></asp:Label></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 142px" valign="top">
                                                                                                                    <asp:Label ID="Label14" runat="server" Text="Reporta Traslados"></asp:Label>:</td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:RadioButtonList ID="optTraslados" runat="server" Width="80px" RepeatDirection="Horizontal">
                                                                                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                                                                    </asp:RadioButtonList></td>
                                                                                                                <td>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 142px" valign="top">
                                                                                                                    <asp:Label ID="Label15" runat="server" Text="Número de cuenta"></asp:Label>:</td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:TextBox ID="txtNumCuentaC" runat="server" MaxLength="30" Width="120px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label16" runat="server" Text="Número de cuenta"></asp:Label>:<br />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtNumCuentaD" runat="server" MaxLength="30" Width="120px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 142px" valign="top">
                                                                                                                    <asp:Label ID="Label17" runat="server" Text="Asignación"></asp:Label>:</td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:TextBox ID="txtAsignacionC" runat="server" MaxLength="30" Width="168px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label18" runat="server" Text="Asignación"></asp:Label><br />
                                                                                                                    <br>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtAsignacionD" runat="server" MaxLength="30" Width="177px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 142px" valign="top">
                                                                                                                    <asp:Label ID="Label19" runat="server" Text="Texto"></asp:Label>:</td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:TextBox ID="txtTextoC" runat="server" MaxLength="30" Width="175px" TextMode="MultiLine"
                                                                                                                        Height="50px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label20" runat="server" Text="Texto"></asp:Label>:<br />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtTextoD" runat="server" MaxLength="30" Width="176px" TextMode="MultiLine"
                                                                                                                        Height="47px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td valign="top" style="width: 142px">
                                                                                                                    <asp:Label ID="Label21" runat="server" Text="Division"></asp:Label>:</td>
                                                                                                                <td style="width: 251px">
                                                                                                                    <asp:TextBox ID="txtDivisionC" runat="server" MaxLength="30" Width="120px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <p>
                                                                                                                        <asp:Label ID="Label22" runat="server" Text="Division"></asp:Label>:<br />
                                                                                                                    </p>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtDivisionD" runat="server" MaxLength="30" Width="120px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <!-- Fin fila para cuentas SAP -->
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </cc1:TabPanel>
                                                                    </cc1:TabContainer>
                                                                </td>
                                                            </tr>
                                                            <!-- fin de los tabs para cuentas -->
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
    <!-- End Page Body -->
</asp:Content>
