<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Credito.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Credito"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="1">
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
                                            <table id="Table1" cellspacing="0" cellpadding="0" width="450" border="0">
                                                <tr>
                                                    <td>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <table class="ResultsTable" cellspacing="1" cellpadding="4" width="300" border="0">
                                                            <tr>
                                                                <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblFormTitle" runat="server">Título</asp:Label></td>
                                                                            <td align="right">
                                                                                <asp:LinkButton ID="lbGuardar" runat="server">Guardar</asp:LinkButton>&nbsp;|
                                                                                <asp:LinkButton ID="lbBack1" runat="server">Volver</asp:LinkButton></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ResultsItem" valign="middle" align="left" colspan="1" rowspan="2">
                                                                    <asp:Panel ID="pnlResultados" runat="server" Enabled="True">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <!--Acciones para creditos-->
                                                                            <tr>
                                                                                <td class="ItemResults">
                                                                                    <table cellpadding="4" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td valign="middle" bgcolor="white" colspan="9">
                                                                                                <asp:Label ID="Display" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2021, 1)%>'></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblNumero" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label2" runat="server" Text="Entidad Consignación"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtEnt_Consig" runat="server"></asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label3" runat="server" Text="Placa"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblPlaca" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label4" runat="server" Text="Tipo"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtTipoCredito" runat="server" Enabled="False">KIT</asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label5" runat="server" Text="Monto"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:TextBox onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                                                    ID="txtMontoCredito" runat="server"></asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label6" runat="server" Text="Saldo"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:TextBox onkeypress="if (((event.keyCode < 48 || event.keyCode > 57)) &amp;&amp; event.keyCode != 44) event.returnValue = false;"
                                                                                                    ID="txtSaldoCredito" runat="server"></asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label7" runat="server" Text="Financiera"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlFinanciera" runat="server" Width="118px" AutoPostBack="True">
                                                                                                </asp:DropDownList></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label8" runat="server" Text="Tipo Porcentaje"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlPorcentaje" runat="server" Width="118px" AutoPostBack="True">
                                                                                                </asp:DropDownList></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="Label9" runat="server" Text="Porcentaje"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblPorcentaje" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:Label ID="lblFinanciera" Visible="false" runat="server"></asp:Label>
                                                                    </asp:Panel>
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblHide2" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;&nbsp; &nbsp;</td>
                                                    <td>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Panel ID="pnlDatosFinancieras" Visible="False" runat="server">
                                                            &nbsp;
                                                            <table class="ResultsTable" id="Table2" cellspacing="1" cellpadding="4" width="250"
                                                                border="0">
                                                                <tr>
                                                                    <td class="ResultsItem">
                                                                        <table cellpadding="4" width="100%">
                                                                            <tr>
                                                                                <td class="ResultsHeader4" colspan="2">
                                                                                    <strong>
                                                                                        <table id="Table5" width="100%">
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <strong>
                                                                                                        <asp:Label ID="Label10" runat="server" Text="Datos Generales de la Financiera"></asp:Label></strong>&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </strong>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label11" runat="server" Text="Código"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblCodigoFinanciera" runat="server"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label12" runat="server" Text="Nombre"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtNombreFinanciera" runat="server"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label13" runat="server" Text="Estado"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbEstadoFinanciera" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, 1)%>'
                                                                                        GroupName="Estado" Checked="True"></asp:RadioButton>
                                                                                    <asp:RadioButton ID="rbEstadoFinanciera1" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, 1)%>'
                                                                                        GroupName="Estado"></asp:RadioButton></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label14" runat="server" Text="F. Ultima Actualización"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblFechaUltActFinanciera" runat="server"></asp:Label></td>
                                                                            </tr>
                                                                            <tr valign="middle" align="center">
                                                                                <td>
                                                                                    <asp:LinkButton ID="lbGuardarFinanciera" runat="server">Guardar</asp:LinkButton></td>
                                                                                <td>
                                                                                    <asp:LinkButton ID="lbCancelarFinanciera" runat="server">Cancelar</asp:LinkButton></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlDatosPorcentajes" Visible="False" runat="server">
                                                            &nbsp;
                                                            <table class="ResultsTable" id="Table3" cellspacing="1" cellpadding="4" width="280"
                                                                border="0">
                                                                <tr>
                                                                    <td class="ResultsItem">
                                                                        <table cellpadding="4" width="100%">
                                                                            <tr>
                                                                                <td class="ResultsHeader4" colspan="2">
                                                                                    <p>
                                                                                        <table id="Table4" width="100%">
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <strong>
                                                                                                        <asp:Label ID="Label15" runat="server" Text="Datos Generales del Tipo de Porcentaje"></asp:Label></strong>&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr width="50%">
                                                                                <td>
                                                                                    <asp:Label ID="Label16" runat="server" Text="Financiera"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblFinancieraPorcentaje" runat="server"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label17" runat="server" Text="Tipo"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtTipoPorcentaje" runat="server" Enabled="False"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label18" runat="server" Text="Porcentaje"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtPorcentaje" runat="server" Enabled="False"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label19" runat="server" Text="F. Ultima Actualización"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblFechaActualizacionPorcentaje" runat="server"></asp:Label></td>
                                                                            </tr>
                                                                            <tr valign="middle" align="center">
                                                                                <td>
                                                                                    <asp:LinkButton ID="lbGuardarTiposPorcentajes" runat="server">Guardar</asp:LinkButton></td>
                                                                                <td>
                                                                                    <asp:LinkButton ID="lbCancelarTiposPorcentajes" runat="server">Cancelar</asp:LinkButton></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
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
