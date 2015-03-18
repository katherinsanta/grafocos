<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AjustePago.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Procesos.AjustePago"
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
                                    <td>
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <input id="ActiveTab" type="hidden" value="CuentaEstandar" name="ActiveTab" />
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    &nbsp;&nbsp;
                                                                    <asp:HyperLink ID="lblBack" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" width="100%" border="0">
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
                                                                    <asp:TextBox ID="txtTiqueteEncontrado" runat="server" Visible="False" Width="24px"></asp:TextBox>
                                                                    <asp:TextBox ID="txtCodigoInicial" runat="server" Visible="False" Width="19px"></asp:TextBox>
                                                                    <asp:TextBox ID="txtValorInicial" runat="server" Visible="False" Width="19px"></asp:TextBox>
                                                                    <asp:TextBox ID="txtIdPago" runat="server" Visible="False" Width="19px"></asp:TextBox></td>
                                                                <td style="width: 187px">
                                                                    <p align="left">
                                                                        <asp:Label ID="Label3" runat="server" Text="Turno"></asp:Label>
                                                                    </p>
                                                                </td>
                                                                <td style="width: 187px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Isla"></asp:Label>
                                                                </td>
                                                                <td style="width: 187px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Buscar Tiquete"></asp:Label></td>
                                                                <td style="width: 187px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    <p align="center">
                                                                        <asp:TextBox ID="txtFecha" runat="server" Width="62px" ReadOnly="True">17/03/2007</asp:TextBox>
                                                                        <asp:ImageButton ID="btnFechaInicio" runat="server" Visible="false" ImageUrl="../../BlueSkin/Images/Calendar.png">
                                                                        </asp:ImageButton><cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFecha">
                                                                        </cc1:CalendarExtender>
                                                                    </p>
                                                                </td>
                                                                <td style="width: 187px">
                                                                    <asp:DropDownList ID="cboTurno" runat="server" Width="69px">
                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cboTurno"
                                                                        ErrorMessage="Required!"></asp:RequiredFieldValidator></td>
                                                                <td style="width: 187px">
                                                                    <asp:DropDownList ID="cboIsla" runat="server" Width="69px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboIsla"
                                                                        ErrorMessage="Required!"></asp:RequiredFieldValidator></td>
                                                                <td style="width: 187px">
                                                                    <asp:TextBox ID="txtTiquete" runat="server" Width="118px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTiquete"
                                                                        ErrorMessage="Required!"></asp:RequiredFieldValidator></td>
                                                                <td style="width: 187px">
                                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar"></asp:Button></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                    <asp:Calendar ID="CalendarioFechaInicio" runat="server" Visible="False" BackColor="White"
                                                                        BorderColor="SteelBlue">
                                                                        <SelectedDayStyle BackColor="Navy"></SelectedDayStyle>
                                                                    </asp:Calendar>
                                                                </td>
                                                                <td style="width: 187px">
                                                                </td>
                                                                <td style="width: 187px">
                                                                </td>
                                                                <td style="width: 187px">
                                                                </td>
                                                                <td style="width: 187px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                    <asp:Label ID="Label6" runat="server" Text="Forma de pago original"></asp:Label></td>
                                                                <td style="width: 187px">
                                                                    <asp:DropDownList ID="cboFormasPago2" runat="server" Width="131px" Enabled="False">
                                                                    </asp:DropDownList></td>
                                                                <td style="width: 187px">
                                                                    <p align="center">
                                                                        <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>&nbsp;
                                                                    </p>
                                                                </td>
                                                                <td style="width: 187px">
                                                                    <asp:TextBox ID="txtTotal" runat="server" Enabled="False"></asp:TextBox></td>
                                                                <td style="width: 187px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    &nbsp;</td>
                                                                <td style="width: 187px">
                                                                </td>
                                                                <td style="width: 187px">
                                                                </td>
                                                                <td style="width: 187px">
                                                                </td>
                                                                <td style="width: 187px">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="ResultsItem">
                                                    <td>
                                                        <!-- Tabs para cuentas -->
                                                        <table id="TabControl" width="100%" class="ResultsItem" >                                                            
                                                            <tr>
                                                                <td colspan="5">
                                                                    <cc1:TabContainer ID="TabContainer1" runat="server">
                                                                        <cc1:TabPanel ID="TabPanelFilaTab1" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, 1)%>'
                                                                            Width="100%" Visible="true">
                                                                            <ContentTemplate>
                                                                                <table id="tableFilaCuentaEstandar" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                    <!-- fin de los tabs para cuentas -->
                                                                                    <!-- Inicio fila para cuentas Estandar -->
                                                                                    <tr class="Oculto" id="FilaTab1">
                                                                                        <td colspan="5">
                                                                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td width="745" style="width: 745px">
                                                                                                                    <asp:Label ID="lblTituloGenerales" runat="server"><b>Trasladar todo el pago original</b></asp:Label></td>
                                                                                                                <td align="right" width="5%">
                                                                                                                    <asp:LinkButton ID="btnActualizarOriginal" runat="server" Width="50px" Height="4px">Trasladar</asp:LinkButton></td>
                                                                                                                <td align="right" width="5%">
                                                                                                                    &nbsp;</td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                        <!-- Tabla que contiene las entradas generales -->
                                                                                                        <table id="TablaGeneral" cellpadding="4" width="100%" border="0">
                                                                                                            <tbody>
                                                                                                                <tr>
                                                                                                                    <td style="width: 203px" valign="top">
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 203px" valign="top">
                                                                                                                        <asp:Label ID="Label8" runat="server" Text="Trasladar a"></asp:Label>&nbsp;&nbsp;
                                                                                                                        -&gt;</td>
                                                                                                                    <td>
                                                                                                                        <asp:DropDownList ID="cboFormasPago3" runat="server" Width="131px">
                                                                                                                        </asp:DropDownList></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 203px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="Label9" runat="server" Text="Observaciones"></asp:Label></p>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtObservacion2" runat="server" Width="275px" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 203px" valign="top">
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </cc1:TabPanel>
                                                                        <!-- Fin fila para cuentas Estandar -->
                                                                        <!-- Inicio fila para cuentas SAP -->
                                                                        <cc1:TabPanel ID="TabPanelFilaTab2" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, 1)%>'
                                                                            Width="100%" Visible="true">
                                                                            <ContentTemplate>
                                                                                <table id="table1" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                    <tr id="FilaTab2">
                                                                                        <td colspan="5">
                                                                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td width="90%">
                                                                                                                    <asp:Label ID="Label1" runat="server"><b>Pagos adicionales</b></asp:Label></td>
                                                                                                                <td align="right" width="5%">
                                                                                                                    <asp:LinkButton ID="btnGuardar" runat="server">Adicionar</asp:LinkButton></td>
                                                                                                                <td align="right" width="5%">
                                                                                                                    &nbsp;</td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                        <!-- Tabla que contiene las entradas generales -->
                                                                                                        <table id="TablaGeneral2" cellpadding="4" width="100%" border="0">
                                                                                                            <tr>
                                                                                                                <td style="width: 87px" valign="top">
                                                                                                                </td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:DataGrid ID="lstPagos" runat="server" Width="280px" BackColor="Linen" BorderColor="#FFC0C0"
                                                                                                                        BorderStyle="Dotted" AutoGenerateColumns="False" OnDataBinding="lstMensajes_DataBinding" >
                                                                                                                        <Columns>
                                                                                                                            <asp:BoundColumn DataField="Cod_For_Pag" HeaderText="Codigo"></asp:BoundColumn>
                                                                                                                            <asp:BoundColumn DataField="descripcion" HeaderText="Nombre"></asp:BoundColumn>
                                                                                                                            <asp:BoundColumn DataField="total" HeaderText="Valor"></asp:BoundColumn>
                                                                                                                            <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel"
                                                                                                                                EditText="Edit"></asp:EditCommandColumn>
                                                                                                                        </Columns>
                                                                                                                    </asp:DataGrid></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 87px" valign="top">
                                                                                                                    <p align="left">
                                                                                                                        <asp:Label ID="Label10" runat="server" Text="Forma de pago"></asp:Label></p>
                                                                                                                </td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:DropDownList ID="cboFormasPago" runat="server" Width="174px">
                                                                                                                    </asp:DropDownList></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 87px" valign="top">
                                                                                                                    <p align="left">
                                                                                                                        <asp:Label ID="Label11" runat="server" Text="Observaciones"></asp:Label></p>
                                                                                                                </td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:TextBox ID="txtObservacion" runat="server" Width="275px" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 87px; height: 21px" valign="top">
                                                                                                                    <asp:Label ID="Label12" runat="server" Text="Valor"></asp:Label></td>
                                                                                                                <td style="width: 244px; height: 21px">
                                                                                                                    <asp:TextBox ID="txtValor" runat="server"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td valign="top" style="width: 87px">
                                                                                                                </td>
                                                                                                                <td style="width: 251px">
                                                                                                                </td>
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
                                                        </table>
                                                        <p>
                                                            &nbsp;</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <!-- End Topic Content -->
                                    </td>
                                    <!-- End Topic Body -->
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- End Page Body -->
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
