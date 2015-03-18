<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TanqueZeta.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Variaciones.TanqueZeta"
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
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <input id="ActiveTab" type="hidden" value="CuentaEstandar" name="ActiveTab" />
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0"
                                                height="100%">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 743px">
                                                                    <asp:Label ID="lblFormTitle" runat="server">Administración de registros de inicio o cierre Zeta</asp:Label></td>
                                                                <td style="width: 100px" align="right">
                                                                    <asp:LinkButton ID="lnkbAbrirCerrarZeta" runat="server" Width="96px" Height="4px">Abrir Jornada zeta</asp:LinkButton></td>
                                                                <td style="width: 1px" align="right">
                                                                </td>
                                                                <td style="width: 1px" align="right">
                                                                    &nbsp;<asp:HyperLink ID="lblBack" runat="server" NavigateUrl="Zetas.aspx">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" width="100%" border="0">
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    <p align="center">
                                                                        <asp:Label ID="lblEstadoZeta" runat="server">Estado Zeta:</asp:Label>&nbsp;
                                                                        <asp:TextBox ID="txtFecha" runat="server" Width="62px" BorderStyle="Groove" Enabled="False"
                                                                            ReadOnly="True">17/03/2007</asp:TextBox>
                                                                        <asp:ImageButton ID="imgFechaInicio" runat="server" Visible="False" ImageUrl="../../BlueSkin/Images/Calendar.png">
                                                                        </asp:ImageButton><asp:TextBox ID="txtIdTanque" runat="server" Visible="False" Width="13px"></asp:TextBox>
                                                                        <asp:TextBox ID="txtVariacionesRegistradas" runat="server" Visible="False" Width="7px">0</asp:TextBox>
                                                                        <asp:TextBox ID="txtFechaConsultada" runat="server" Visible="False" Width="13px"></asp:TextBox>
                                                                        <asp:TextBox ID="txtAprobarMedidas" runat="server" Visible="False" Width="11px">0</asp:TextBox></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                    <div align="center">
                                                                        <asp:Calendar ID="cldFechaInicio" runat="server" Visible="False" BorderColor="SteelBlue"
                                                                            BackColor="White">
                                                                            <SelectedDayStyle BackColor="Navy"></SelectedDayStyle>
                                                                        </asp:Calendar>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px">
                                                                    &nbsp;
                                                                    <div align="right">
                                                                        <asp:DataGrid ID="dtgTanques" runat="server" Visible="False" Width="608px" BorderStyle="Dotted"
                                                                            BorderColor="#FFC0C0" BackColor="Linen" AutoGenerateColumns="False" OnDataBinding="grdFacturas_DataBinding">
                                                                            <Columns>
                                                                                <asp:BoundColumn DataField="idTanque" HeaderText="Tanque"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="Articulo" HeaderText="Articulo"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="SaldoInicial" HeaderText="Saldo Inicial"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="AguaInicial" HeaderText="Agua Inicial"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="Transito" HeaderText="Transito"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="CompraFactura" HeaderText="CompraFactura"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="Compras" HeaderText="Compras"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="SaldoFinal" HeaderText="Saldo Final"></asp:BoundColumn>
                                                                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel"
                                                                                    EditText="Edit"></asp:EditCommandColumn>
                                                                                <asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
                                                                                <asp:BoundColumn Visible="False" DataField="ConvierteLitrosAGalones" HeaderText="Unidad">
                                                                                </asp:BoundColumn>
                                                                                <asp:BoundColumn Visible="False" DataField="GasOLiquido" HeaderText="GasOLiquido"></asp:BoundColumn>
                                                                            </Columns>
                                                                        </asp:DataGrid>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <!-- Tabs para cuentas -->
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlEntrada" runat="server" Height="100%">
                                                            <table id="TabControl" width="100%">
                                                                <tr>
                                                                    <td colspan="5">
                                                                    
                                                                        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1">
                                                                            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText='Detalle Variación Tanque'
                                                                                Width="100%" Visible="true">
                                                                                <ContentTemplate>
                                                                                    <table id="Table10" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                        <!-- fin de los tabs para cuentas -->
                                                                                        <!-- Inicio fila para cuentas Estandar -->
                                                                                        <tr class="Oculto" id="Tr2">
                                                                                            <td colspan="5">
                                                                                                <table class="ResultsTable" id="Table9" cellspacing="1" cellpadding="4" width="100%"
                                                                                                    border="0">
                                                                                                    <tr>
                                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                            <table id="Table2" width="100%">
                                                                                                                <tr>
                                                                                                                    <td style="width: 806px" width="806">
                                                                                                                        <asp:Label ID="lblTituloDatosFinales" runat="server">
																											<b>Datos Finales del Tanque</b></asp:Label></td>
                                                                                                                    <td style="width: 50px" align="right" width="50">
                                                                                                                        <asp:LinkButton ID="lnkbActualiza1" runat="server" Height="4px" Width="37px" Enabled="False">Actualizar</asp:LinkButton></td>
                                                                                                                    <td align="right" width="5%">
                                                                                                                        &nbsp;</td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                                            <!-- Tabla que contiene las entradas generales -->
                                                                                                            <table id="Table1" cellpadding="4" width="100%" border="0">
                                                                                                                <tr>
                                                                                                                    <td style="width: 230px" valign="top">
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 230px" valign="top">
                                                                                                                        <asp:Label ID="Label1" runat="server" Text="Compras"></asp:Label>:</td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtCompras" runat="server"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            &nbsp;<asp:Label ID="Label3" runat="server" Text="Compra Factura"></asp:Label>:</p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        &nbsp;<asp:TextBox ID="txtCompraFactura" runat="server"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            &nbsp;<asp:Label ID="Label2" runat="server" Text="Transito"></asp:Label>:</p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        &nbsp;<asp:TextBox ID="txtTransito" runat="server" Enabled="False"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 230px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="lblSaldoFinal" runat="server" Width="120px">Saldo  final:</asp:Label></p>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtSaldoFinal" runat="server"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 230px" valign="top">
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
                                                                            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, 1)%>'
                                                                                Width="100%" Visible="true">
                                                                                <ContentTemplate>
                                                                                    <table id="table5" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                        <!-- Fin fila para cuentas Estandar -->
                                                                                        <!-- Inicio fila para cuentas SAP -->
                                                                                        <tr id="FilaTab2" height="100%">
                                                                                            <td colspan="5">
                                                                                                <table class="ResultsTable" id="Table3" cellspacing="1" cellpadding="4" width="100%"
                                                                                                    border="0" height="100%">
                                                                                                    <tr>
                                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                            <table id="Table4" width="100%">
                                                                                                                <tr>
                                                                                                                    <td width="813" style="width: 813px">
                                                                                                                        <asp:Label ID="lblTituloDatosIniciales" runat="server">
																										<b>Datos Iniciales del Tanque</b></asp:Label></td>
                                                                                                                    <td align="right" width="45" style="width: 45px">
                                                                                                                        <asp:LinkButton ID="lnkbActualiza2" runat="server" Height="4px" Width="37px" Enabled="False">Actualizar</asp:LinkButton></td>
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
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="lblSaldoInicial" runat="server" Width="100px" Text=":"></asp:Label></p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        <asp:TextBox ID="txtSaldoInicial" runat="server"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="Label4" runat="server" Text="Agua"></asp:Label>:</p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        <asp:TextBox ID="txtAgua" runat="server"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
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
                                                                           
                                                                            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText='Inventario Canastilla' Width="100%"
                                                                                Visible="true">
                                                                                <ContentTemplate>
                                                                                    <table id="table6" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                        <!-- Fin fila para cuentas Estandar -->
                                                                                        <!-- Inicio fila para cuentas SAP -->
                                                                                        <tr id="Tr1" height="100%">
                                                                                            <td colspan="5">
                                                                                                <table class="ResultsTable" id="Table7" cellspacing="1" cellpadding="4" width="100%"
                                                                                                    border="0" height="100%">
                                                                                                    <tr>
                                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                            <table id="Table8" width="100%">
                                                                                                                <tr>
                                                                                                                    <td width="813" style="width: 813px">
                                                                                                                        <asp:Label ID="Label5" runat="server">
																										<b>Inventario Canastilla</b></asp:Label></td>
                                                                                                                    <td align="right" width="45" style="width: 45px">
                                                                                                                        <asp:LinkButton ID="lnkIActualizarInventarioCanastilla" runat="server" Height="4px" Width="37px">Actualizar</asp:LinkButton></td>
                                                                                                                    <td align="right" width="5%">
                                                                                                                        &nbsp;</td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                                            <!-- Tabla que contiene las entradas generales -->
                                                                                                            <table id="Table11" cellpadding="4" width="100%" border="0">
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="Label10" runat="server" Width="100px" Text="Item Canastilla:"></asp:Label></p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        <asp:DropDownList ID="ddlItemsCanastilla" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlItemsCanastilla_SelectedIndexChanged">
                                                                                                                        </asp:DropDownList>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="Label6" runat="server" Width="100px" Text="Saldo Inicial:"></asp:Label></p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        <asp:TextBox ID="txtSaldoInicialItemCanastilla" runat="server" AutoPostBack="false" ></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="Label7" runat="server" Text="Compras"></asp:Label>:</p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        <asp:TextBox ID="txtComprasItemCanastilla" runat="server" AutoPostBack="false" ></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="Label8" runat="server" Text="Salidas"></asp:Label>:</p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        <asp:TextBox ID="txtSalidasItemCanastilla" runat="server" AutoPostBack="false" ></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
                                                                                                                        <p align="left">
                                                                                                                            <asp:Label ID="Label9" runat="server" Text="Saldo Final"></asp:Label>:</p>
                                                                                                                    </td>
                                                                                                                    <td style="width: 244px">
                                                                                                                        <asp:TextBox ID="txtSaldoFinalItemCanastilla" runat="server" Enabled="false"></asp:TextBox></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 88px" valign="top">
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
                                                        </asp:Panel>
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
        <!-- End Page Body -->
    </table>
</asp:Content>
