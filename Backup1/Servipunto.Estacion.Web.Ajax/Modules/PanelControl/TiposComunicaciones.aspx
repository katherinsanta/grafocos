<%@ Page Language="c#" Codebehind="TiposComunicaciones.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.TiposComunicaciones" 
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
                                        <input id="ActiveTab" type="hidden" value="General" name="ActiveTab" />
                                        <!-- Comienzo del control de pestañas -->
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table id="TabControl" width="90%">
                                                <tr>
                                                    <td colspan="5">
                                                        <cc1:TabContainer ID="TabContainer1" runat="server">
                                                            <cc1:TabPanel ID="TabPanelGeneral" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="tableFilaCuentaEstandar" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <!-- Comiezo de la fila generales -->
                                                                        <tr id="filaGenerales">
                                                                            <td colspan="5">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="90%">
                                                                                                        <asp:Label ID="lblTituloGenerales" runat="server"><b>Datos Generales de 
																							Configuración</b></asp:Label></td>
                                                                                                    <td align="right" width="5%">
                                                                                                        <asp:LinkButton ID="lbGeneral" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" width="5%">
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
                                                                                                        <asp:Label ID="Label1" runat="server" Text="Dispositivo"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlDispositivo" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Avantel">Avantel</asp:ListItem>
                                                                                                            <asp:ListItem Value="CDPD">CDPD</asp:ListItem>
                                                                                                            <asp:ListItem Value="L&#237;nea Telef&#243;nica">L&#237;nea Telef&#243;nica</asp:ListItem>
                                                                                                            <asp:ListItem Value="Linea Dedicada">Linea Dedicada</asp:ListItem>
                                                                                                            <asp:ListItem Value="Fibra Optica">Fibra Optica</asp:ListItem>
                                                                                                            <asp:ListItem Value="VSAT">VSAT</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label2" runat="server" Text="Tipo"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlTipo" runat="server" Width="120px" AutoPostBack="True">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Lote">Lote</asp:ListItem>
                                                                                                            <asp:ListItem Value="L&#237;nea">L&#237;nea</asp:ListItem>
                                                                                                            <asp:ListItem Value="Tarjetas">Tarjetas</asp:ListItem>
                                                                                                            <asp:ListItem Value="Total">Total</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label3" runat="server" Text="Puerto Serial"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPuertoSerial" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    <td colspan="2">
                                                                                                        <asp:CheckBox ID="cbGasonet" runat="server" Text="Gasonet:" TextAlign="Left" AutoPostBack="True">
                                                                                                        </asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr id="FilaDatosEnLinea" runat="server">
                                                                                                    <td valign="middle" align="center" colspan="4">
                                                                                                        <table cellpadding="4" width="100%" bgcolor="#dcdcdc" border="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label4" runat="server" Text="Servidor FTP"></asp:Label>:
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtServidorFTP" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label5" runat="server" Text="Path del Cliente FTP"></asp:Label>:
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="PathFTP" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblIpServidor" runat="server"></asp:Label></td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtIPServidor" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label6" runat="server" Text="Usuario"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtUsuario" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label7" runat="server" Text="Socket Servidor ES"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtSocketServidor" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label8" runat="server" Text="Contraseña"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" Width="120px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label9" runat="server" Text="TimeOut"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtTimeOut" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label10" runat="server" Text="Directorio Virtual"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtDirectorioVirtual" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label11" runat="server" Text="In Active TimeOut"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtActiveTimeOut" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label12" runat="server" Text="Puerto FTP"></asp:Label>:</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtPuertoFTP" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label13" runat="server" Text="Modo Inicio Estación"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlModoInicioEstacion" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Ventas">Ventas</asp:ListItem>
                                                                                                            <asp:ListItem Value="Manual">Manual</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label14" runat="server" Text="Estado"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlEstado" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Activo">Activo</asp:ListItem>
                                                                                                            <asp:ListItem Value="InActivo">InActivo</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <tr>
                                                                                                        <!--		<TD>Ruta Web Service Centro de Computo:</TD>
																						<TD><asp:textbox id="txtRutaWebServiceCC" runat="server" Width="120px"></asp:textbox></TD>																				
																					-->
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label15" runat="server" Text="Intervalo de Sincronización con Centro de Computo"></asp:Label>:</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtIntervaloSincronizacionCC" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    </tr>
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
                                                            <cc1:TabPanel ID="TabPanelLotes" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Servipunto.Estacion.Web.Global.Idioma)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="table2" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr class="Oculto" id="filaLotes">
                                                                            <td colspan="5">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="90%">
                                                                                                        <asp:Label ID="lblTituloConfiguracion" runat="server">
																						<b>Configuración de Lotes</b></asp:Label></td>
                                                                                                    <td align="right" width="5%">
                                                                                                        <asp:LinkButton ID="lbConf" runat="server">Guardar</asp:LinkButton></td>
                                                                                                    <td align="right" width="5%">
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
                                                                                                        <asp:Label ID="Label16" runat="server" Text="Modo"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlModo" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(Sin Definir)</asp:ListItem>
                                                                                                            <asp:ListItem Value="Manual">Manual</asp:ListItem>
                                                                                                            <asp:ListItem Value="Autom&#225;tico">Autom&#225;tico</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label17" runat="server" Text="Periodo de Recepción"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlPeriodoRecepcion" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(No Set)</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">0</asp:ListItem>
                                                                                                            <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                            <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                            <asp:ListItem Value="60">60</asp:ListItem>
                                                                                                            <asp:ListItem Value="120">120</asp:ListItem>
                                                                                                            <asp:ListItem Value="240">240</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 14px">
                                                                                                        <asp:Label ID="Label18" runat="server" Text="Periodo de Envio"></asp:Label>:</td>
                                                                                                    <td style="height: 14px">
                                                                                                        <asp:DropDownList ID="ddlPeriodoEnvio" runat="server" Width="120px">
                                                                                                            <asp:ListItem Value="(Sin Definir)">(No set)</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">0</asp:ListItem>
                                                                                                            <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                            <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                            <asp:ListItem Value="60">60</asp:ListItem>
                                                                                                            <asp:ListItem Value="120">120</asp:ListItem>
                                                                                                            <asp:ListItem Value="240">240</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                    <td style="height: 14px">
                                                                                                    </td>
                                                                                                    <td style="height: 14px">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4">
                                                                                                        <table id="Table1" cellspacing="1" cellpadding="4" width="100%" bgcolor="gainsboro"
                                                                                                            border="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label19" runat="server" Text="Directorios de Almacenamiento"></asp:Label>:&nbsp;&nbsp;</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="center">
                                                                                                                    <table id="TablaArchivos" class="ResultsTable" cellspacing="1" cellpadding="4" border="0"
                                                                                                                        width="90%">
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsHeader4" valign="middle" align="left" width="10%">
                                                                                                                                <asp:Label ID="Label20" runat="server" Text="Campo"></asp:Label></td>
                                                                                                                            <td class="ResultsHeader4" valign="middle" align="left" width="90%">
                                                                                                                                <asp:Label ID="Label21" runat="server" Text="Ruta"></asp:Label></td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                <asp:Label ID="Label22" runat="server" Text="Envios"></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td class="ResultsItem" onclick="return AbrirVentanaCentrada('SubirArchivos.aspx?NombreControl=ArchivosEnvio&amp;File=0', null,500,70,0,1,0,0,0,1,0)"
                                                                                                                                valign="middle" align="left">
                                                                                                                                <asp:TextBox ID="ArchivosEnvio" CssClass="Hand" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                <asp:Label ID="Label23" runat="server" Text="Procesados"></asp:Label></td>
                                                                                                                            <td class="ResultsItem" onclick="return AbrirVentanaCentrada('SubirArchivos.aspx?NombreControl=ArchivosProcesados&amp;File=0', null,500,70,0,1,0,0,0,1,0)"
                                                                                                                                valign="middle" align="left">
                                                                                                                                <asp:TextBox ID="ArchivosProcesados" CssClass="Hand" runat="server" Width="100%"
                                                                                                                                    ReadOnly="True"></asp:TextBox>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                <asp:Label ID="Label24" runat="server" Text="Generador"></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td class="ResultsItem" onclick="return AbrirVentanaCentrada('SubirArchivos.aspx?NombreControl=Generador&amp;File=1', null,500,70,0,1,0,0,0,1,0)"
                                                                                                                                valign="middle" align="left">
                                                                                                                                <asp:TextBox ID="Generador" CssClass="Hand" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td class="ResultsItem" valign="middle" align="left">
                                                                                                                                <asp:Label ID="lblCliser" runat="server"></asp:Label></td>
                                                                                                                            <td class="ResultsItem" onclick="return AbrirVentanaCentrada('SubirArchivos.aspx?NombreControl=Cliser&amp;File=1', null,500,70,0,1,0,0,0,1,0)"
                                                                                                                                valign="middle" align="left">
                                                                                                                                <asp:TextBox ID="Cliser" CssClass="Hand" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                                                                                                                        </tr>
                                                                                                                    </table>
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
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                        </cc1:TabContainer>
                                                    </td>
                                                </tr>
                                                <!-- fin de la fila Configuracion -->
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
