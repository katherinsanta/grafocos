<%@ Page Language="c#" Codebehind="Cliente.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Cliente"
    ValidateRequest="false" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    <input id="ActiveTab" type="hidden" value="General" name="ActiveTab" />
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <!-- Comiezo del control de pestañas -->
        <table id="TabControl" width="40%">
            <tr>
                <td colspan="5" style="width: 286px">
                    <cc1:TabContainer ID="TabContainer1" runat="server">
                        <cc1:TabPanel ID="TabPanelfilaBasicos" runat="server" HeaderText='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, 1)%>'
                            Width="100%" Visible="true">
                            <ContentTemplate>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="100%">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="160" style="height: 15px">
                                                                    <asp:Label ID="lblFormTitle" runat="server"><b>Datos Básicos</b></asp:Label>
                                                                </td>
                                                                <td align="right" style="height: 15px">
                                                                    <asp:LinkButton ID="lbGuardar" runat="server" >Guardar</asp:LinkButton>
                                                                </td>
                                                                <td align="right" style="height: 15px">
                                                                    <asp:HyperLink ID="lblBack1" runat="server" NavigateUrl="Clientes.aspx">Volver</asp:HyperLink>
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
                                                                    <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:TextBox ID="txtCodigo" MaxLength="11" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                        Width="120px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label19" runat="server" Text="NIT"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:TextBox ID="txtNIT" MaxLength="11" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                        Width="120px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Tipo de Documento"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px" >
                                                                    <asp:DropDownList ID="ddlTipoDoc" runat="server" Width="120px">
                                                                        <asp:ListItem Value="(Sin Definir)" Selected="True">(Sin Definir)</asp:ListItem>
                                                                        <asp:ListItem Value="Nit">Nit</asp:ListItem>
                                                                        <asp:ListItem Value="Cédula Ciudadanía">Cédula Ciudadanía</asp:ListItem>
                                                                        <asp:ListItem Value="Cédula Extanjeréa">Cédula Extanjería</asp:ListItem>
                                                                        <asp:ListItem Value="Pasaporte">Pasaporte</asp:ListItem>
                                                                    </asp:DropDownList>&nbsp;&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label5" runat="server" Text="Dirección"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label6" runat="server" Text="País"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="cboPais" runat="server" Width="120px" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label7" runat="server" Text="Departamento"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="cboDepartamento" runat="server" Width="120px" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label8" runat="server" Text="Ciudad"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="cboCiudad" runat="server" Width="120px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="filaPlaca" runat="server">
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label9" runat="server" Text="Teléfono"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:TextBox ID="txtTelefono" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                        Width="120px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label10" runat="server" Text="Estado"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="ddlEstado" runat="server" Width="120px">
                                                                        <asp:ListItem Value="Activo" Selected="True">Activo</asp:ListItem>
                                                                        <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label11" runat="server" Text="Forma de Pago"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="ddlFormasPago" runat="server" Width="120px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label12" runat="server" Text="Precio Diferencial"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="ddlPrecioDiferencial" runat="server" Width="120px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label13" runat="server" Text="Tipo de Credito"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:TextBox ID="txtTipoCredito" runat="server"></asp:TextBox>
                                                                </td>  
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label14" runat="server" Text="Tipo de Transacción"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="ddlTipoTransaccion" runat="server" Width="120px">
                                                                        <asp:ListItem Value="" Selected="True">NINGUNA</asp:ListItem>
                                                                        <asp:ListItem Value="CREDITO">CREDITO</asp:ListItem>
                                                                        <asp:ListItem Value="EFECTIVO">EFECTIVO</asp:ListItem>
                                                                        <asp:ListItem Value="PRIVADA">PRIVADA</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label15" runat="server" Text="Codigo Alterno"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px">
                                                                    <asp:TextBox ID="txtCodigoAlterno" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="lblTipoAutorizacion" runat="server" Text="Tipo Autorizacion:"></asp:Label></td>
                                                                <td style="height: 18px">
                                                                    <asp:DropDownList ID="ddlTipoAutorizacionExterna" runat="server" Width="120px" AutoPostBack="true">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                            <td colspan="2">
                                                            <asp:Label ID="lblleyendatipo" runat="server" Text="Autorizacion Predeterminada"></asp:Label>:
                                                                <asp:Label ID="lblLeyendaTipoAutorizacion" runat="server" Text="Autorizacion Predeterminada"></asp:Label>
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
                                <table id="table1" cellpadding="1" class="Tabla1Panel" width="100%">
                                    <tr id="filaComerciales">
                                        <td colspan="2">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" width="100%">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="160">
                                                                    <asp:Label ID="Label1" runat="server"><b>Datos Comerciales</b></asp:Label>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lbGuardar1" runat="server">Guardar</asp:LinkButton>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack2" runat="server" NavigateUrl="Clientes.aspx">
																						Volver
                                                                    </asp:HyperLink>
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
                                                                    <asp:Label ID="Label22" runat="server" Text="Tipo de Cupo"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px" align="center">
                                                                    <asp:DropDownList ID="ddlTipo" runat="server"> 
                                                                    <asp:ListItem Value="Estandar">Estandar</asp:ListItem>
                                                                    <asp:ListItem Value="Global">Global</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label20" runat="server" Text="Unidad"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px" align="center">
                                                                    <asp:DropDownList ID="ddlModo" runat="server">
                                                                         <asp:ListItem Value="Valor" Selected="True">Valor</asp:ListItem>
                                                                            <asp:ListItem Value="Volumen">Volumen</asp:ListItem>
                                                                            
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            
                                                             <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label21" runat="server" Text="Periodicidad"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px" align="center">
                                                                    <asp:DropDownList ID="ddlPeriodicidad" runat="server">
                                                                          <asp:ListItem Value="Semanal" Selected="True">Semanal</asp:ListItem>
                                                                            <asp:ListItem Value="Quincenal">Quincenal</asp:ListItem>
                                                                            <asp:ListItem Value="Mensual">Mensual</asp:ListItem>
                                                                            
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            
                                                            
                                                           
                                                            <tr>
                                                                <td style="height: 18px">
                                                                    <asp:Label ID="Label16" runat="server" Text="Cupo Asignado"></asp:Label>:
                                                                </td>
                                                                <td style="height: 18px" align="center">
                                                                    <asp:TextBox ID="txtCupoAsignado" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" Text="Cupo Disponible"></asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCupoDisponible" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label18" runat="server" Text="Pagar Cupo"></asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPagar" runat="server" onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ID="lbEliminarCupo" runat="server">Eliminar Cupo</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
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
</asp:Content>
