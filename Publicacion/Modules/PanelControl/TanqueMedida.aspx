<%@ Page Language="c#" Codebehind="TanqueMedida.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.TanqueMedida" 
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
                                                                <td style="width: 1100px">
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td style="width: 100px" align="right">
                                                                    <asp:LinkButton ID="lblNuevo" runat="server" Height="4px" Width="50px">Nuevo</asp:LinkButton></td>
                                                                <td style="width: 50px" align="right">
                                                                    <asp:LinkButton ID="lblGuardarMedidas" runat="server" Height="4px" Width="50px">Guardar</asp:LinkButton></td>
                                                                <td style="width: 37px" align="right">
                                                                    <asp:LinkButton ID="lblBuscar" runat="server" Height="4px" Width="50px">Buscar</asp:LinkButton>
                                                                    <td align="right">
                                                                        &nbsp;<asp:HyperLink ID="lblBack" runat="server" NavigateUrl="Tanques.aspx">Volver</asp:HyperLink></td>
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
                                                                        <asp:TextBox ID="txtFecha" runat="server" Width="62px" ReadOnly="True">17/03/2007</asp:TextBox>
                                                                        <asp:ImageButton
                                                                            ID="btnFechaInicio" runat="server" ImageUrl="../../BlueSkin/Images/Calendar.png" Visible="false">
                                                                        </asp:ImageButton>
                                                                        <asp:TextBox ID="txtIdTanque" runat="server" Visible="False" Width="13px"></asp:TextBox>
                                                                        <asp:Label ID="lblExisteMedida" runat="server" Visible="False"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 171px" valign="top">
                                                                    <div align="center">
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFecha">
                                                                        </cc1:CalendarExtender>
                                                                        <asp:Calendar ID="FechaInicio" runat="server" Visible="False" BackColor="White" BorderColor="SteelBlue" >
                                                                            <SelectedDayStyle BackColor="Navy"></SelectedDayStyle>
                                                                        </asp:Calendar><asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="SteelBlue" OnSelectionChanged="Calendar1_SelectionChanged" >
                                                                            <SelectedDayStyle BackColor="Navy" />
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
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                        <!-- Tabs para cuentas -->
                                                        <table id="TabControl" width="100%">
                                                            <tr>
                                                                <td colspan="5">
                                                                    <cc1:TabContainer ID="TabContainer1" runat="server">
                                                                     
                                                                        <!-- Fin fila para cuentas Estandar -->
                                                                        <!-- Inicio fila para cuentas SAP -->
                                                                        <cc1:TabPanel ID="TabPanelBasicoFinal" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
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
                                                                                                                    <asp:Label ID="Label1" runat="server"><b>Datos Iniciales del Tanque</b></asp:Label></td>
                                                                                                                <td align="right" width="5%">
                                                                                                                </td>
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
                                                                                                                <td style="width: 97px" valign="top">
                                                                                                                </td>
                                                                                                                <td style="width: 244px">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 97px" valign="top">
                                                                                                                    <p align="left">
                                                                                                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>:</p>
                                                                                                                </td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:TextBox ID="txtSaldoInicial" runat="server"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 97px" valign="top">
                                                                                                                    <p align="left">
                                                                                                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>:</p>
                                                                                                                </td>
                                                                                                                <td style="width: 244px">
                                                                                                                    <asp:TextBox ID="txtAgua" runat="server"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 97px; height: 21px" valign="top">
                                                                                                                </td>
                                                                                                                <td style="width: 244px; height: 21px">
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
                                                                           <cc1:TabPanel ID="TabPanelBasicoInicial" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                            Width="100%" Visible="true">
                                                                            <ContentTemplate>
                                                                                <table id="tableFilaBasicoInicial" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                    <!-- fin de los tabs para cuentas -->
                                                                                    <!-- Inicio fila para cuentas Estandar -->
                                                                                    <tr class="Oculto" id="FilaTab1">
                                                                                        <td colspan="5">
                                                                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td style="width: 745px" width="745">
                                                                                                                    <asp:Label ID="lblTituloGenerales" runat="server"><b>Datos 
																										Finales del Tanque</b></asp:Label></td>
                                                                                                                <td align="right" width="5%">
                                                                                                                </td>
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
                                                                                                            <tr>
                                                                                                                <td style="width: 236px" valign="top">
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 236px" valign="top">
                                                                                                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtCompras" runat="server"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 236px" valign="top">
                                                                                                                    <p align="left">
                                                                                                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>:</p>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtSaldoFinal" runat="server"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 236px" valign="top">
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
                                                                    </cc1:TabContainer>
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
    <!-- End Page Body -->
</asp:Content>
