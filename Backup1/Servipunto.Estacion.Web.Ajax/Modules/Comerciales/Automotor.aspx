<%@ Page Language="c#" Codebehind="Automotor.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Automotor"
    ValidateRequest="false" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                        <input id="ActiveTab" type="hidden" value="General" name="ActiveTab" />
                                        <!-- Comiezo del control de pestañas -->
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table id="TabControl" width="75%">
                                                <tr>
                                                    <td colspan="5">
                                                        <cc1:TabContainer ID="TabContainer1" runat="server">
                                                            <cc1:TabPanel ID="TabPanelfilaBasicos" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, 1)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="tableFilaCuentaEstandar" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <!-- Comiezo de la fila datos basicos -->
                                                                        <tr id="filaBasicos">
                                                                            <td colspan="2">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="90%">
                                                                                                        <asp:Label ID="lblFormTitle" runat="server"><b>Datos Básicos</b></asp:Label></td>
                                                                                                    <td width="5%">
                                                                                                        <asp:LinkButton ID="lbGuardar" runat="server" >Guardar</asp:LinkButton></td>
                                                                                                    <td width="5%">
                                                                                                        <a href="Automotores.aspx?IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>">
                                                                                                            <asp:Label ID="Label2" runat="server" Text="Volver"></asp:Label></a></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ResultsItem" valign="middle" align="left">
                                                                                            <table cellpadding="1" border="0" width="100%" bordercolor="#93bee2">
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label3" runat="server" Text="Cliente"></asp:Label>:</td>
                                                                                                    <td width="35%">
                                                                                                        <asp:Label ID="lblCliente" runat="server" Width="120px" Font-Bold="True" Text="Codigo del Cliente"></asp:Label></td>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label4" runat="server" Text="Forma de Pago"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:DropDownList ID="ddlFormasPago" runat="server" Width="120px">
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label5" runat="server" Text="Placa"></asp:Label>:</td>
                                                                                                    <td width="35%">
                                                                                                        <asp:TextBox ID="txtPlaca" Width="120px" MaxLength="50" runat="server"></asp:TextBox></td>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label6" runat="server" Text="Causal del Bloqueo"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:DropDownList ID="ddlCausalBloqueo" runat="server" Width="120px">
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label7" runat="server" Text="Descuento"></asp:Label>:</td>
                                                                                                    <td>
                                                                                                        <table id="Table1" cellspacing="0" cellpadding="0" border="0">
                                                                                                            <tr>
                                                                                                                <td style="height: 23px">
                                                                                                                    <asp:DropDownList ID="ddlTipoDescuento" runat="server" Width="120px" AutoPostBack="True">
                                                                                                                        <asp:ListItem Value="0" Selected="True">Sin Descuento</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">$</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">%</asp:ListItem>
                                                                                                                    </asp:DropDownList></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 6px">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtDescuento" runat="server" Width="120px" Enabled="False"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td width="35%">
                                                                                                        <asp:Label ID="Label8" runat="server" Text="Linea"></asp:Label>:</td>
                                                                                                    <td width="20%">
                                                                                                        <asp:TextBox ID="txtModelo" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label9" runat="server" Text="Marca"></asp:Label>:</td>
                                                                                                    <td width="35%">
                                                                                                        <asp:TextBox ID="txtMarca" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label10" runat="server" Text="Modelo"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtAño" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label11" runat="server" Text="Monitoreo"></asp:Label>:</td>
                                                                                                    <td valign="bottom" align="left" width="35%">
                                                                                                        <img height="16" alt="Ativo" src="../../BlueSkin/Icons/2011/Activo-16.png" width="16">
                                                                                                        <input id="EstadoActivo" type="radio" value="Activo" name="Estado" runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                        <img height="16" alt="Inactivo" src="../../BlueSkin/Icons/2011/Inactivo-16.png" width="16">
                                                                                                                <input id="EstadoInactivo" type="radio" value="Inactivo" name="Estado" runat="server"></td>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label12" runat="server" Text="Tipo"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:DropDownList ID="ddlTipoAutomotor" runat="server" Width="120px">
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label13" runat="server" Text="Número de Tanques"></asp:Label>:</td>
                                                                                                    <td valign="bottom" align="left" width="35%">
                                                                                                        <asp:TextBox ID="txtNumTanques" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label14" runat="server" Text="Capacidad Total"></asp:Label>:</td>
                                                                                                    <td width="25%">
                                                                                                        <asp:TextBox ID="txtCapacidadTotal" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="Label15" runat="server" Text="Prox. Mantenimiento"></asp:Label>:</td>
                                                                                                    <td width="35%">
                                                                                                        <asp:TextBox ID="txtFecha" runat="server" Width="120px"></asp:TextBox>
                                                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFecha">
                                                                                                        </cc1:CalendarExtender>
                                                                                                        <asp:Label ID="lblFecha" Visible="false" runat="server" Font-Bold="True" Width="88px"></asp:Label>
                                                                                                        <asp:ImageButton ID="ibMostrarCalendario" Visible="false" runat="server" Width="16px"
                                                                                                            Height="16px" ImageUrl="../../BlueSkin/Icons/2011/Canasta16.png"></asp:ImageButton></td>
                                                                                                    <td width="35%">
                                                                                                        <asp:Label ID="Label16" runat="server" Text="Máximo de Tanqueos Diarios"></asp:Label></td>
                                                                                                    <td width="35%">
                                                                                                        <asp:TextBox ID="txtMaximoTanques" runat="server" Width="120px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        Codigo Interno:</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtCodigoInterno" runat="server"></asp:TextBox></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblTipoAutorizacion" runat="server" Text="Tipo de Autorizacion" ></asp:Label></td>
                                                                                                    <td>
                                                                                                        &nbsp;<asp:DropDownList ID="ddlTipoAutorizacion" runat="server" Width="120px" OnSelectedIndexChanged="ddlTipoAutorizacion_SelectedIndexChanged">
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td colspan="2"></td>
                                                                                                </tr>
                                                                                                <td colspan="2">
                                                                                                        <asp:Label ID="lbLeyendaTipo" runat="server" Text="Autorización Predeterminada"></asp:Label>:
                                                                                                        <asp:Label ID="lblLeyendaTipoAutorizacion" runat="server" Text="Autorización Predeterminada"></asp:Label>
                                                                                                </td>
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                    </td>
                                                                                                    <td width="35%">
                                                                                                        <asp:Calendar ID="Calendario" runat="server" Visible="False" ForeColor="Black" Width="170px"
                                                                                                            Height="120px" CellPadding="4" BorderColor="#999999" Font-Names="Tahoma" Font-Size="XX-Small"
                                                                                                            DayNameFormat="FirstLetter" BackColor="White">
                                                                                                            <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
                                                                                                            <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
                                                                                                            <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
                                                                                                            <DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="Gainsboro"></DayHeaderStyle>
                                                                                                            <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
                                                                                                            <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="LightSteelBlue"></TitleStyle>
                                                                                                            <WeekendDayStyle BackColor="LightSteelBlue"></WeekendDayStyle>
                                                                                                            <OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
                                                                                                        </asp:Calendar>
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
                                                            <!-- fin de la fila datos basicos -->
                                                            <!-- Comiezo de la fila datos comerciales -->
                                                            <cc1:TabPanel ID="TabPanelfilaComerciales" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, 1)%>'
                                                                Width="100%" Visible="true">
                                                                <ContentTemplate>
                                                                    <table id="table2" cellpadding="1" class="Tabla1Panel" width="100%">
                                                                        <tr id="filaComerciales">
                                                                            <td colspan="2">
                                                                                <table class="ResultsTable" cellspacing="1" cellpadding="4" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="90%">
                                                                                                        <asp:Label ID="Label1" runat="server">
																						                <b>Datos Comerciales</b></asp:Label>
																						                </td>
                                                                                                    <td width="5%">
                                                                                                        <asp:LinkButton ID="lbGuardar1" runat="server">Guardar</asp:LinkButton>
                                                                                                        </td>
                                                                                                    <td width="5%">
                                                                                                        <a href="Automotores.aspx?IdCliente=<%=Request.QueryString["IdCliente"]%>&IdNombreCliente=<%=Request.QueryString["IdNombreCliente"]%>">
                                                                                                            <asp:Label ID="Label17" runat="server" Text="Volver"></asp:Label></a></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="ResultsItem" valign="middle" align="left">
                                                                                <table cellpadding="4" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 18px">
                                                                                            <asp:Label ID="Label18" runat="server" Text="Cupo Asignado"></asp:Label>:
                                                                                        </td>
                                                                                        <td style="height: 18px" align="center">
                                                                                            <asp:TextBox ID="txtCupoAsignado" runat="server"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label19" runat="server" Text="Cupo Disponible"></asp:Label>:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtCupoDisponible" runat="server"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label20" runat="server" Text="Pagar Cupo"></asp:Label>:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtPagar" runat="server"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="lbEliminarCupo" runat="server">Eliminar Cupo</asp:LinkButton>>
                                                                                            <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                                                            <asp:Label ID="lblHideIdCliente" runat="server" Visible="False"></asp:Label>
                                                                                            <asp:Label ID="lblHideIdNombreCliente" runat="server" Visible="False"></asp:Label></td>
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
                                                <!-- fin de la fila datos comerciales -->
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
