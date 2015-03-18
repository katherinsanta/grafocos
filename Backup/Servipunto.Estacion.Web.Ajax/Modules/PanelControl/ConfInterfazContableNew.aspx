<%@ Page Language="c#" Codebehind="ConfInterfazContableNew.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.ConfInterfazContableNew"
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
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <input id="ActiveTab" type="hidden" value="Estandar" name="ActiveTab" />
                                        <!-- Comiezo del control de pestañas -->
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table id="TabControl" width="100%">
                                                <tr>
                                                    <td colspan="5">
                                                        <cc1:TabContainer ID="TabContainer1" runat="server">
                                                            <cc1:TabPanel ID="TabPanelEstandar" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="tableEstandar" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <!-- Comiezo de la fila estandar -->
                                                                        <tr id="filaEstandar">
                                                                            <td colspan="2">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="90%">
                                                                                                        <asp:Label ID="lblTituloGenerales" runat="server"><b>Parametros para la generación de archivos  
																								planos estandares</b></asp:Label></td>
                                                                                                    <td align="right" width="5%">
                                                                                                        <asp:LinkButton ID="lblGuardar" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" width="5%">
                                                                                                        &nbsp;<asp:HyperLink ID="lblBack" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <!-- Tabla que contiene las entradas generales -->
                                                                                            <table id="TablaGeneral" cellpadding="4" width="100%" border="0">
                                                                                                <tr align="center">
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <i>
                                                                                                            <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label></i></td>
                                                                                                    <td width="25%">
                                                                                                        <i>
                                                                                                            <asp:Label ID="Label4" runat="server" Text="Cuenta Contable"></asp:Label></i></td>
                                                                                                    <td width="25%">
                                                                                                        <i>
                                                                                                            <asp:Label ID="Label5" runat="server" Text="Naturaleza"></asp:Label></i></td>
                                                                                                    <td width="25%">
                                                                                                        <i>
                                                                                                            <asp:Label ID="Label6" runat="server" Text="Tercero"></asp:Label></i></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <asp:Label ID="Label7" runat="server" Text="Cuenta Abono a Créditos"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtNCAbono" MaxLength="16" runat="server"></asp:TextBox></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:RadioButtonList ID="optNCAbono" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="0">D&#233;bito</asp:ListItem>
                                                                                                            <asp:ListItem Value="1" Selected="True">Cr&#233;dito</asp:ListItem>
                                                                                                        </asp:RadioButtonList></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:CheckBox ID="chkNTAbono" runat="server" Text="Tiene Tercero" Checked="True"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <asp:Label ID="Label8" runat="server" Text="Cuenta Descuentos"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtNCDescuentos" MaxLength="16" runat="server"></asp:TextBox></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:RadioButtonList ID="optNCDescuentos" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="0" Selected="True">D&#233;bito</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Cr&#233;dito</asp:ListItem>
                                                                                                        </asp:RadioButtonList></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:CheckBox ID="chkNTDescuentos" runat="server" Text="Tiene Tercero"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <asp:Label ID="Label9" runat="server" Text="Cuenta IVA"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtNCIva" MaxLength="16" runat="server"></asp:TextBox></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:RadioButtonList ID="optNCIva" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="0">D&#233;bito</asp:ListItem>
                                                                                                            <asp:ListItem Value="1" Selected="True">Cr&#233;dito</asp:ListItem>
                                                                                                        </asp:RadioButtonList></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:CheckBox ID="chkNTIva" runat="server" Text="Tiene Tercero"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                    </td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtNCVentasGNV" Visible="False" MaxLength="20" runat="server"></asp:TextBox></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:RadioButtonList ID="optNCVentasGNV" Visible="False" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="0">D&#233;bito</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Cr&#233;dito</asp:ListItem>
                                                                                                        </asp:RadioButtonList></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:CheckBox ID="chkNCVentasGNV" Visible="False" runat="server" Text="Tiene Tercero">
                                                                                                        </asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                    </td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtNCVentasCanas" Visible="False" MaxLength="20" runat="server"></asp:TextBox></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:RadioButtonList ID="optNCVentasCanas" Visible="False" runat="server" RepeatDirection="Horizontal">
                                                                                                            <asp:ListItem Value="0">D&#233;bito</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Cr&#233;dito</asp:ListItem>
                                                                                                        </asp:RadioButtonList></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:CheckBox ID="chkNCVentasCanas" Visible="False" runat="server" Text="Tiene Tercero">
                                                                                                        </asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="center" colspan="4">
                                                                                                        <b><asp:Label ID="Label10" runat="server" Text="Parámetros Específicos"></asp:Label></b></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <asp:Label ID="Label11" runat="server" Text="Código Centro de Costos"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtCodCentroCostos" MaxLength="10" runat="server"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <asp:Label ID="Label12" runat="server" Text="Num. Comprobante Facturas"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtNumCompFacturas" MaxLength="3" runat="server"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <asp:Label ID="Label13" runat="server" Text="Código Sucursal"></asp:Label></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtCodSucursal" MaxLength="3" runat="server"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                    </td>
                                                                                                    <td width="25%">
                                                                                                        <p align="center">
                                                                                                            <strong>
                                                                                                                <asp:Label ID="Label14" runat="server" Text="Otros"></asp:Label></strong></p>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                        <asp:Label ID="Label15" runat="server" Text="Ruta y Nombre de archivo para importación de Clientes Corporativos"></asp:Label></td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtRutaImportarClientesCorporativos" runat="server" MaxLength="500"
                                                                                                            Width="200px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 174px" width="174">
                                                                                                    </td>
                                                                                                    <td width="25%">
                                                                                                    </td>
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
                                                            <!-- fin de la fila ESTANDAR -->
                                                            <cc1:TabPanel ID="TabPanelSAP" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="tableSAP" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr  id="filaSAP">
                                                                            <td >
                                                                                <table>
                                                                                    <tr>
                                                                                        <td >
                                                                                            <cc1:TabContainer ID="TabContainer2" runat="server">
                                                                                                <cc1:TabPanel ID="TabPanelFilaCabeceraTraslados" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                                                    Width="100%" Visible="true">
                                                                                                    <ContentTemplate>
                                                                                                        <table id="tableFilaFilaCabeceraTraslados" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                                            <!-- fin de los tab de SAP -->
                                                                                                            <!-- inicio de la fila cabecera de TRASLADOS -->
                                                                                                            <tr class="Oculto" id="FilaCabeceraTraslados">
                                                                                                                <td >
                                                                                                                    <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsHeader4" valign="middle" align="left" >
                                                                                                                                <table width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td width="90%">
                                                                                                                                            <asp:Label ID="Label1" runat="server"><b>Parametros para la generación de archivos 
																							planos de traslado para SAP</b></asp:Label></td>
                                                                                                                                        <td align="right" width="5%">
                                                                                                                                            <asp:LinkButton ID="lblGuardar3" runat="server">Guardar</asp:LinkButton></td>
                                                                                                                                        <td align="right" width="5%">
                                                                                                                                            &nbsp;<asp:HyperLink ID="Hyperlink1" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                <!-- Tabla que contiene las entradas configuracion CABECERA TRASLADOS -->
                                                                                                                                <table id="TablaGeneralConfiguracion2" cellpadding="4" border="0">
                                                                                                                                    <tr>
                                                                                                                                        <td >
                                                                                                                                            <i>
                                                                                                                                                <asp:Label ID="Label16" runat="server" Text="Registro de Cabecera de Traslados"></asp:Label></i></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label17" runat="server" Text="Clase de Documento"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtClaseDoc" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label18" runat="server" Text="Sociedad"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtSociedad" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label19" runat="server" Text="Tipo de moneda"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtTipoMoneda" runat="server" Width="120px"> </asp:TextBox></td>
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
                                                                                                <!-- Fin de la cabecera de TRASLADOS -->
                                                                                                <!-- inicio de la fila cabecera de VENTAS -->
                                                                                                <cc1:TabPanel ID="TabPanelFilaCabeceraVentas" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                                                    Width="100%" Visible="true">
                                                                                                    <ContentTemplate>
                                                                                                        <table id="tableFilaCabeceraVentas" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                                            <tr class="Oculto" id="FilaCabeceraVentas">
                                                                                                                <td colspan="5">
                                                                                                                    <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                                                <table width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td width="90%">
                                                                                                                                            <asp:Label ID="lblTituloConfiguracion" runat="server"><b>Parametros para la generación de archivos de 
																							planos ventas de SAP</b></asp:Label></td>
                                                                                                                                        <td align="right" width="5%">
                                                                                                                                            <asp:LinkButton ID="lblGuardar2" runat="server">Guardar</asp:LinkButton></td>
                                                                                                                                        <td align="right" width="5%">
                                                                                                                                            &nbsp;<asp:HyperLink ID="lblBackConf" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                <!-- Tabla que contiene las entradas configuracion caBECERA SAP -->
                                                                                                                                <table id="TablaGeneralConfiguracion" cellpadding="4" width="50%" border="0">
                                                                                                                                    <tr>
                                                                                                                                        <td width="25%">
                                                                                                                                            <i>
                                                                                                                                                <asp:Label ID="Label20" runat="server" Text="Registro de Cabecera de Ventas"></asp:Label></i></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label21" runat="server" Text="Clase de pedido"></asp:Label>:
                                                                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe de ser menor o igual a 4 caracteres!"
                                                                                                                                                ControlToValidate="txtClasePedido" ValidationExpression="\w{1,4}"></asp:RegularExpressionValidator></td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtClasePedido" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label22" runat="server" Text="Organización de ventas"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtOrganizacionVentas" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label23" runat="server" Text="Canal"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtCanal" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label24" runat="server" Text="Sector"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtSector" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label25" runat="server" Text="Oficina de ventas"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtOficinaVentas" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label26" runat="server" Text="Grupo de vendedores"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtGrupoVendedores" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label27" runat="server" Text="Asignación"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtAsignacion" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label28" runat="server" Text="Codigo clientes de contado"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtCodClientesContado" runat="server" Width="120px"> </asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label29" runat="server" Text="Puesto de expedición"></asp:Label>:</td>
                                                                                                                                        <td>
                                                                                                                                            <asp:TextBox ID="txtPuestoExpedicion" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                                <!-- fin de la Tabla que contiene las entradas del form SAP -->
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </ContentTemplate>
                                                                                                </cc1:TabPanel>
                                                                                                <!-- fin  de la fila SAP -->
                                                                                                <!-- inicio de la fila cabecera de TRASLADOS -->
                                                                                                <cc1:TabPanel ID="TabPanelFilaVarios" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                                                    Width="100%" Visible="true">
                                                                                                    <ContentTemplate>
                                                                                                        <table id="tableFilaVarios" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                                                            <tr class="Oculto" id="FilaVarios">
                                                                                                                <td colspan="5">
                                                                                                                    <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                                                                <table width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td width="90%">
                                                                                                                                            <asp:Label ID="Label2" runat="server"><b>Importar - Exportar y otros </b></asp:Label></td>
                                                                                                                                        <td align="right" width="5%">
                                                                                                                                            <asp:LinkButton ID="lblGuardar4" runat="server">Guardar</asp:LinkButton></td>
                                                                                                                                        <td align="right" width="5%">
                                                                                                                                            &nbsp;<asp:HyperLink ID="Hyperlink2" runat="server" NavigateUrl="Default.aspx">Volver</asp:HyperLink></td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <!-- Tabla que contiene las entradas configuracion CABECERA TRASLADOS -->
                                                                                                                        <tr>
                                                                                                                            <td colspan="4">
                                                                                                                                <table id="Table1" cellspacing="1" cellpadding="4" width="100%" bgcolor="gainsboro"
                                                                                                                                    border="0">
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <asp:Label ID="Label30" runat="server" Text="Directorios de importación y exportación"></asp:Label>:&nbsp;&nbsp;</td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td align="center">
                                                                                                                                            <table class="ResultsTable" id="TablaArchivos" cellspacing="1" cellpadding="4" width="90%"
                                                                                                                                                border="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="ResultsHeader4" valign="middle" align="left" width="10%">
                                                                                                                                                        <asp:Label ID="Label31" runat="server" Text="Arcivos"></asp:Label></td>
                                                                                                                                                    <td class="ResultsHeader4" valign="middle" align="left" width="90%">
                                                                                                                                                        <asp:Label ID="Label32" runat="server" Text="Ruta"></asp:Label></td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                                        <asp:Label ID="Label33" runat="server" Text="Importar de"></asp:Label>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                                        <asp:TextBox ID="txtRutaImportar" runat="server" Width="432px"></asp:TextBox></td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                                        <asp:Label ID="Label34" runat="server" Text="Exportar a"></asp:Label></td>
                                                                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                                        <asp:TextBox ID="txtRutaExportar" runat="server" Width="432px"></asp:TextBox></td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                                        <asp:Label ID="Label35" runat="server" Text="Codigo de Estacion"></asp:Label></td>
                                                                                                                                                    <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                                        <asp:TextBox ID="txtCodigoEstacionSap" runat="server"></asp:TextBox></td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
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
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                        </cc1:TabContainer>
                                                    </td>
                                                </tr>
                                                <!-- Fin de la cabecera de TRASLADOS -->
                                            </table>
                                        </asp:Panel>
                                        <!-- fin del control de pestañas -->
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
