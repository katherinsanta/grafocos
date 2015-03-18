<%@ Page Language="c#" Codebehind="DatosGenerales.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.DatosGenerales" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <!-- Comiezo del control de pestañas -->
                                            <table id="TabControl" width="100%">
                                                <tr>
                                                    <td colspan="6">
                                                        <cc1:TabContainer ID="TabContainer1" runat="server">
                                                            <cc1:TabPanel ID="TabPanelGeneral" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1404, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="tableFilaCuentaEstandar" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <!-- Comiezo de la fila generales -->
                                                                        <tr id="filaGenerales">
                                                                            <td colspan="6">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="height: 41px">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 90%">
                                                                                                        <asp:Label ID="lblTituloGenerales" runat="server"><b>Datos Generales de la 
																							Estación</b></asp:Label></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:LinkButton ID="lbGeneral" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        &nbsp;<asp:HyperLink ID="lblBackGeneral" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas generales -->
                                                                                            <table id="TablaGeneral" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label3" runat="server" Text="Compañia"></asp:Label>:
                                                                                                        <asp:HyperLink ID="hlCompañia" runat="server" Visible="False" NavigateUrl="Companias.aspx">Crear...</asp:HyperLink></td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGeneralCompañia" runat="server" Width="120px">
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label4" runat="server" Text="Nit"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtGeneralNit" runat="server" Width="120px"></asp:TextBox>
                                                                                                        DV.
                                                                                                        <asp:TextBox ID="txtGeneralNitDive" runat="server" Width="20px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label5" runat="server" Text="Grupo"></asp:Label>:
                                                                                                        <asp:HyperLink ID="hlgrupo" runat="server" Visible="False" NavigateUrl="Grupos.aspx">Crear...</asp:HyperLink></td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGeneralGrupo" runat="server" Width="120px">
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label6" runat="server" Text="Dirección"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtGeneralDireccion" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label7" runat="server" Text="Estación"></asp:Label>:
                                                                                                        <asp:HyperLink ID="hlEstacion" runat="server" Visible="False" NavigateUrl="Estaciones.aspx">Crear...</asp:HyperLink></td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGeneralEstacion" runat="server" Width="120px">
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtGeneralTelefono" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label9" runat="server" Text="Tipo de Razón Social"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGeneralRazonSocial" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="Nit" Selected="True">Nit</asp:ListItem>
                                                                                                            <asp:ListItem Value="C&#233;dula Ciudadan&#237;a">C&#233;dula Ciudadan&#237;a</asp:ListItem>
                                                                                                            <asp:ListItem Value="C&#233;dula Extanjer&#237;a">C&#233;dula Extanjer&#237;a</asp:ListItem>
                                                                                                            <asp:ListItem Value="Pasaporte">Pasaporte</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label10" runat="server" Text="País"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="cboPais" runat="server" Width="120px" AutoPostBack="True">
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label11" runat="server" Text="Departamento"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="cboDepartamento" runat="server" Width="120px" AutoPostBack="True">
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label12" runat="server" Text="Ciudad"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="cboCiudad" runat="server" Width="120px">
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label13" runat="server" Text="Razón Social o Nombre Compañia"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtGeneralRazonSocial" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label14" runat="server" Text="Slogan"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtGeneralSlogan" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkImprimirMensajeAdicional" runat="server" TextAlign="Left" Text="Imprimir Mensaje Adicional"
                                                                                                            AutoPostBack="True"></asp:CheckBox>
                                                                                                        <asp:Label ID="Label15" runat="server" Text="Valor Mayor A"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtMensajeAdicionalMayoresA" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label16" runat="server" Text="Mensaje Adicional"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtMensajeAdicional" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <!-- fin de la Tabla que contiene las entradas generales -->
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <!-- fin de la fila generales -->
                                                            <!-- Inicio de la fila Configuracion -->
                                                            <cc1:TabPanel ID="TabPanelConfiguracion" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1157, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="table1" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr class="Oculto" id="filaConfiguracion">
                                                                            <td colspan="6">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 90%">
                                                                                                        <asp:Label ID="lblTituloConfiguracion" runat="server"><b>Configuracion de 
																							la Estación</b></asp:Label></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:LinkButton ID="lbConf" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        &nbsp;<asp:HyperLink ID="lblBackConf" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas configuracion -->
                                                                                            <table id="TablaGeneralConfiguracion" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label17" runat="server" Text="Tipo de Estacion"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlConfiguracionTipoEstacion" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Gasolina">Gasolina</asp:ListItem>
                                                                                                            <asp:ListItem Value="Gas">Gas</asp:ListItem>
                                                                                                            <asp:ListItem Value="Dual">Dual</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label18" runat="server" Text="Valor Definido Para Bolsa"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtConfiguracionValorBolsa" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label19" runat="server" Text="Ventas Predefinidas"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlConfiguracionVentasPredefinidas" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Activo</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label20" runat="server" Text="Código Sucursal Transmisión en Lotes"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtConfiguracionCodigoSucursal" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label21" runat="server" Text="Fidelizado"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlConfiguracionFidelizado" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">NO</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label22" runat="server" Text="Capturador Pantalla"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlConfiguracionCapturarPantalla" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Activo</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:Label ID="Label23" runat="server" Text="Permitir la Creación de Empleados y Tarjetas en Modo Activo"></asp:Label></td>
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:DropDownList ID="ddlConfiguracionPermitirCreacionEmpleadosTarjetas" runat="server"
                                                                                                            Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:Label ID="Label24" runat="server" Text="Limpiar Display"></asp:Label>:</td>
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:DropDownList ID="ddlConfiguracionLimpiarDisplay" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label25" runat="server" Text="Código de orden (Bol)"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtCodigoOrden" runat="server" Width="120px">0</asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label26" runat="server" Text="Tipo de Tiquete"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlTributarioTipoTiquete" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Factura">Factura</asp:ListItem>
                                                                                                            <asp:ListItem Value="Tiquete">Tiquete</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label27" runat="server" Text="Prefijo para Combustibles"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtTributarioPrefijo" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:Label ID="Label28" runat="server" Text="Registra lecturas por venta"></asp:Label>:</td>
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:DropDownList ID="ddlLecturasPorVenta" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:Label ID="Label29" runat="server" Text="Tipo de Autorización Cara:"></asp:Label>:</td>
                                                                                                    <td style="height: 22px">
                                                                                                    <asp:DropDownList ID="ddlTipoAutorizacionCaraManguera" runat="server">
                                                                                                      <asp:ListItem Value="1" Selected="True">Manguera</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">Cara</asp:ListItem>
                                                                                                    </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkSeguridadImpresion" runat="server" TextAlign="Left" Text="Seguridad de Impresión"
                                                                                                            AutoPostBack="True"></asp:CheckBox>
                                                                                                        <asp:Label ID="Label30" runat="server" Text="Tiempo (min)"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtTiempoSeguridadImpresion" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label31" runat="server" Text="Clave Impresion"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtClaveImpresion" runat="server" Width="120px" MaxLength="4" TextMode="Password"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label32" runat="server" Text="Número de días para Aviso Vencimiento Resolución Canastilla"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtDiasAvisoResolucionCanastilla" runat="server" Width="120px">0</asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label33" runat="server" Text="Número de Facturas para Aviso Vencimiento Resolución Canastilla"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtFacturasAvisoResolucionCanastilla" runat="server" Width="120px">0</asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ChkVentaAutorizadaConConductor" runat="server" TextAlign="Left"
                                                                                                            Text="Autorización ventas con conductor:" AutoPostBack="True"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <b>*Las ventas se autorizaran verificando el identificador de conductor antes del tanqueo</b></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkDescargueInventario" runat="server" TextAlign="Left" Text="Ventas de canastilla con descargue en Inventario:"
                                                                                                            AutoPostBack="True"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkZetaAutomatico" runat="server" TextAlign="Left" Text="Zeta Automatico:"
                                                                                                            AutoPostBack="True"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblTipoAutorizacionExterna" runat="server" Text="Tipo De Autorización:"></asp:Label>
                                                                                                    </td>
                                                                                                    
                                                                                                    <td style="height: 22px">
                                                                                                        <asp:DropDownList ID="ddlTipoAutorizacionExterna" runat="server" Width="120px" AutoPostBack="true">
                                                                                                           
                                                                                                        </asp:DropDownList>
                                                                                                        
                                                                                                    </td>
                                                                                                    
                                                                                                    <td colspan="2">
                                                                                                        <asp:Label ID="lblLeyendaTipo" runat="server" Text="Autorización"></asp:Label>:
                                                                                                        <asp:Label ID="lblLeyendaTipoAutorizacion" runat="server" Text="Autorización Predeterminada"></asp:Label>
                                                                                                    </td>
                                                                                                    
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label34" runat="server" Text="Clave Venta de Calibración y Cheque:"></asp:Label>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPasswordCalibracion" runat="server" Width="120px" TextMode="Password" MaxLength="10"></asp:TextBox>
                                                                                                    </td>
                                                                                                
                                                                                                </tr>
                                                                                                
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <!-- fin de la Tabla que contiene las entradas de configuracion -->
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <!-- fin de la fila Configuracion -->
                                                            <!-- inicio de la fila Tributario -->
                                                            <%--<cc1:TabPanel ID="TabPanelDescuento" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1175, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="table2" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr class="Oculto" id="filaDescuentos">
                                                                            <td colspan="6">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas del form descuentos -->
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <!-- fin de la Tabla que contiene las entradas del form descuentos -->
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>--%>
                                                            <!-- fin de la fila descuentos -->
                                                            <!-- inicio  de la fila gas -->
                                                            <cc1:TabPanel ID="TabPanelGas" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1186, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="table3" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr class="Oculto" id="filaGas">
                                                                            <td colspan="6">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 90%">
                                                                                                        <asp:Label ID="lblTituloGas" runat="server">
																						<b>Información Sobre la Configuración del Gas</b></asp:Label></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:LinkButton ID="lbGas" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:HyperLink ID="lblBackGas" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas del form Gas -->
                                                                                            <table id="TablaGeneralGas" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label41" runat="server" Text="Control Mantenimiento"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGasControlMantenimiento" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Activo">Activo</asp:ListItem>
                                                                                                            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label42" runat="server" Text=" Versión Cliente Suic"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGasVersionIdentificador" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Si">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                                                                            <asp:ListItem Value="NTC4829">NTC4829</asp:ListItem>
                                                                                                            <asp:ListItem Value="Enable">Suic</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label43" runat="server" Text="Tipo Centro de Cómputo"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGasTipoCentroComputo" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="SQL">Sql</asp:ListItem>
                                                                                                            <asp:ListItem Value="TPS">TopSpeed</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label44" runat="server" Text="Recaudo"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGasRecaudo" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Activo">Activo</asp:ListItem>
                                                                                                            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label45" runat="server" Text="Actualizar Formas de Pago"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlGasActualizarFormasPago" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Activo">Activo</asp:ListItem>
                                                                                                            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label47" runat="server" Text="Solicitar lecturas mecánicas"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlLecturasMecanicas" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="Si" Selected="True">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <!-- fin de la Tabla que contiene las entradas del form Gas -->
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <!-- fin  de la fila gas -->
                                                            <!-- Inicio de la configuracion de generar -->
                                                            <!-- inicio  de la fila generar -->
                                                            <cc1:TabPanel ID="TabPanelGenerar" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1195, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="table4" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr class="Oculto" id="filaGenerar">
                                                                            <td colspan="6">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 90%">
                                                                                                        <asp:Label ID="Label2" runat="server">
																						<b>Al cierrre de turno o de día realizar la siguientes tareas</b></asp:Label></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:LinkButton ID="lblGuardarGenerar" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:HyperLink ID="Hyperlink1" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas del form Otros -->
                                                                                            <table id="TablaGeneralGenerar" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label48" runat="server" Text="Ruta predeterminada para Importar Planos"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtRutaImportarPredeterminada" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label49" runat="server" Text="Ruta predeterminada para Exportar Planos"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtRutaExportarPredeterminada" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label50" runat="server" Text="Ruta Plano de Ventas Pendientes"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtRutaPlanoVentasPendientes" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label51" runat="server" Text="Ruta predeterminada para Planos Procesados"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtRutaPlanoVentasProcesadas" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label52" runat="server" Text="Ruta Plano de Ventas "></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtRutaPlanoVentas" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label53" runat="server" Text="Ruta Planos de Lecturas"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtRutaPlanoLecturas" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label54" runat="server" Text="Separador predeterminado para Planos"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtSeparadorPlanosPredeterminado" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <b>
                                                                                                            <asp:Label ID="Label55" runat="server" Text="Archivos planos a generar"></asp:Label>:</b>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoCreditoContado" runat="server" TextAlign="Right"
                                                                                                            Text="Ventas Credito-Contado" AutoPostBack="False"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoVentaSap" runat="server" TextAlign="Right" Text="Ventas para SAP"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoTrasladoSap" runat="server" TextAlign="Right" Text="Traslados para SAP"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoLecturaSap" runat="server" TextAlign="Right" Text="Lecturas para SAP"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoReporte" runat="server" TextAlign="Right" Text="Reportes"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoTotalElectronico" runat="server" TextAlign="Right"
                                                                                                            Text="Totales electrónicos" AutoPostBack="False"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoMapa" runat="server" TextAlign="Right" Text="Mapa"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoCuenta" runat="server" TextAlign="Right" Text="Cuentas"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoPrecio" runat="server" TextAlign="Right" Text="Precios"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="ckbGenerarPlanoInventarios" runat="server" TextAlign="Right" Text="Inventario"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkGenerarPlanoVentas" runat="server" TextAlign="Right" Text="Ventas"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkGenerarPlanoLecturas" runat="server" TextAlign="Right" Text="Lecturas"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <!--<TD align="left">Exporta e Importa para SAP?:</TD>	
																					<TD align="left">
																							
																							<asp:DropDownList id="cboSAP" Width="120px" runat="server">
																								<asp:ListItem Value="0">No</asp:ListItem>
																								<asp:ListItem Value="1">Ventas y traslados</asp:ListItem>
																								<asp:ListItem Value="2">Total de lecturas por día</asp:ListItem>
																								<asp:ListItem Value="3">Todos</asp:ListItem>
																							</asp:DropDownList>&nbsp;
																					</td>																							 
																					</TD>
																					-->
                                                                                            </table>
                                                                                            <!-- fin de la Tabla que contiene las entradas del form generar -->
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <!-- fin  de la fila generar -->
                                                            <!-- fin de la configuracion de generar -->
                                                            <!-- Inicio de la configuracion de otros -->
                                                            <!-- inicio  de la fila otros -->
                                                            <cc1:TabPanel ID="TabPanelOtros" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1217, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="table5" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr class="Oculto" id="filaOtros">
                                                                            <td colspan="6">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 90%">
                                                                                                        <asp:Label ID="Label1" runat="server">
																						<b>Otros items opcionales de configuración</b></asp:Label></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:LinkButton ID="lblGuardarOtros" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" style="width: 5%">
                                                                                                        <asp:HyperLink ID="lblBackOtros" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas del form Otros -->
                                                                                            <table id="TablaGeneralOtros" cellpadding="4" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label56" runat="server" Text="Utiliza Jornada Fiscal Zeta"></asp:Label>:</td>
                                                                                                    <td align="left">
                                                                                                        <asp:RadioButtonList ID="rblZeta" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="S">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                                        </asp:RadioButtonList>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label57" runat="server" Text="Utiliza Capturadores Virtuales"></asp:Label>:</td>
                                                                                                    <td align="left">
                                                                                                        <asp:RadioButtonList ID="rblCapturadores" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="S">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                                        </asp:RadioButtonList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label58" runat="server" Text="IP del Servidor Automatización"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtIPServidorMRVirtual" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label59" runat="server" Text="Puerto"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPuerto" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label60" runat="server" Text="IP de Tanques"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtIpTanques" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label61" runat="server" Text="Periodo de Variación de Tanques"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="cboPeriodoVariacionTanque" runat="server" Width="120px" AutoPostBack="False">
                                                                                                            <asp:ListItem Value="M">Mensual</asp:ListItem>
                                                                                                            <asp:ListItem Value="S">Semanal</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label62" runat="server" Text="Utiliza Servidor Capturadores Virtuales"></asp:Label>:</td>
                                                                                                    <td align="left">
                                                                                                        <asp:RadioButtonList ID="rblUtilizaServidorCapturadores" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="S">Si</asp:ListItem>
                                                                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                                        </asp:RadioButtonList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label63" runat="server" Text="Puerto Servidor Capturadores Virtuales"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPuertoServidorCapturadores" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label64" runat="server" Text="Intentos adicionales a Estación"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtIntentosAEstacion" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label65" runat="server" Text="Tiempo Entre Intentos a Estación (mls)"></asp:Label>
                                                                                                        :</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtIntervaloAEstacion" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label66" runat="server" Text="Intentos adicionales a Capturadores Virtuales"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtIntentosACapturador" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label67" runat="server" Text="Tiempo Entre Intentos a Capturadores (mls)"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtIntervaloACapturador" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="cbDebug" runat="server" TextAlign="Right" Text="Debug para Capturadores Virtuales"
                                                                                                            AutoPostBack="false"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="cbDebugSurtidores" runat="server" TextAlign="Right" Text="Debug para Surtidores"
                                                                                                            AutoPostBack="false"></asp:CheckBox></td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkTiqueteVentaConfigurable" runat="server" TextAlign="Right" Text="Tiquete Venta Configurable"
                                                                                                            AutoPostBack="false"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="cbConexionOracle" runat="server" TextAlign="Right" Text="Conexión Oracle"
                                                                                                            AutoPostBack="False"></asp:CheckBox></td>
                                                                                                    <!--<TD>Codigo Aterno de Estación:</TD>
																					<TD><asp:textbox id="txtCodigoAlternoEstacion" runat="server" Width="120px"> </asp:TextBox></TD>																																																												
																					-->
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label68" runat="server" Text="Url Web Service Centro de Información Suic"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtUrlWebServiceCi" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label69" runat="server" Text="Usuario Centro Información Suic "></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtUsuarioCi" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label70" runat="server" Text=" Contraseña Centro Información Suic "></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPasswordCI" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label71" runat="server" Text="Dias de actualización Centro Información Suic"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtDiasActualizaCI" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label72" runat="server" Text="Tiempo encuesta WS Centro Información Suic (Minutos) "></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtMinutosEncuestaCI" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <!-- fin de la Tabla que contiene las entradas del form otros -->
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
                                            <!-- fin  de la fila otros -->
                                            <!-- fin de la configuracion de otros -->
                                            <!-- fin del control de pestañas -->
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <!-- End Topic Content -->
                        </td>
                    </tr>
                    <!-- End Topic Body -->
                </table>
                <!-- End Page Body -->
            </td>
        </tr>
    </table>
</asp:Content>
