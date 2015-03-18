<%@ Page Language="c#" Codebehind="EstructuraPlano.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.EstructuraPlano" 
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
                                        <br>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 528px;
                                                height: 529px">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 380px">
                                                                    <asp:Label ID="lblFormTitle" runat="server" Font-Bold="True">Estructura para archivos planos</asp:Label></td>
                                                                <td style="width: 211px" align="right">
                                                                    <asp:LinkButton ID="lblGuardar" runat="server">Guardar</asp:LinkButton></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="0" border="0" style="width: 520px; height: 454px">
                                                            <tr>
                                                                <td style="width: 9px; height: 2px">
                                                                </td>
                                                                <td style="width: 187px; height: 2px" colspan="3">
                                                                    <strong>
                                                                        <p align="left">
                                                                            <asp:Label ID="Label4" runat="server" Text="Archivo"></asp:Label>: &nbsp; &nbsp;&nbsp;<asp:DropDownList
                                                                                ID="ddlArchivo" runat="server" AutoPostBack="True">
                                                                                <asp:ListItem Value="FacturaEstandar" Selected="True">Plano de facturas</asp:ListItem>
                                                                                <asp:ListItem Value="Inventarios">Plano de inventarios</asp:ListItem>
                                                                                <asp:ListItem Value="Lecturas">Plano Lecturas</asp:ListItem>
                                                                                <asp:ListItem Value="SysconVentas">Plano Ventas</asp:ListItem>
                                                                                <asp:ListItem Value="Insepec">Plano Insepec</asp:ListItem>
                                                                            </asp:DropDownList></p>
                                                                    </strong>
                                                                </td>
                                                                <td style="height: 2px">
                                                                </td>
                                                                <td style="height: 2px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 16px;">
                                                                </td>
                                                                <td style="width: 187px; height: 16px;">
                                                                    <asp:Label ID="Label5" runat="server" Text="Columnas no incluidas"></asp:Label>:</td>
                                                                <td style="width: 13px; height: 16px;">
                                                                </td>
                                                                <td style="height: 16px">
                                                                    <asp:Label ID="Label6" runat="server" Text="Columnas incluidas"></asp:Label>:</td>
                                                                <td style="height: 16px">
                                                                </td>
                                                                <td style="height: 16px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 139px">
                                                                </td>
                                                                <td style="width: 187px; height: 139px">
                                                                    <asp:Label ID="Label2" runat="server" ForeColor="DimGray" Font-Bold="True" Font-Size="XX-Small"
                                                                        ToolTip="Descripción de las columnas de la lista">Tamaño|Alineación|Relleno|Descripción</asp:Label>
                                                                    <asp:ListBox ID="lstNoIncluidos" runat="server" Width="232px" Height="154px"></asp:ListBox></td>
                                                                <td style="width: 13px; height: 139px">
                                                                    <p align="center">
                                                                        <asp:Button ID="btnAgregar" runat="server" Text=">"></asp:Button>
                                                                        <asp:Button ID="btnQuitar" runat="server" Text="<"></asp:Button></p>
                                                                </td>
                                                                <td style="height: 139px">
                                                                    <p align="center">
                                                                        <asp:Label ID="Label3" runat="server" ForeColor="DimGray" Font-Bold="True" Font-Size="XX-Small">Tamaño|Alineación|Relleno|Descripción</asp:Label>
                                                                        <asp:ListBox ID="lstIncluidos" runat="server" Width="232px" AutoPostBack="True" Height="154px">
                                                                        </asp:ListBox>
                                                                        <asp:Button ID="btnSubir" runat="server" Text="Subir"></asp:Button>
                                                                        <asp:Button ID="btnBajar" runat="server" Text="Bajar"></asp:Button></p>
                                                                </td>
                                                                <td style="height: 139px">
                                                                    <asp:Panel ID="pnlValor" runat="server" Visible="False" Height="30px" DESIGNTIMEDRAGDROP="963">
                                                                        <table id="Table1" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 17px">
                                                                                    <asp:Label ID="lblValor" runat="server" Width="80px">Valor</asp:Label></td>
                                                                                <td style="width: 17px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 17px">
                                                                                    <asp:TextBox ID="txtValor" Width="88px" runat="server" MaxLength="50"></asp:TextBox></td>
                                                                                <td style="width: 17px">
                                                                                    <asp:Button ID="btnAplicarValor" runat="server" Text="Aplicar"></asp:Button></td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlParametros" runat="server" Visible="False" Height="30px">
                                                                        <table id="Table2" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 17px">
                                                                                    <asp:Label ID="lblParametro" runat="server" Width="80px">Valor 1</asp:Label></td>
                                                                                <td style="width: 17px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 17px">
                                                                                    <asp:DropDownList ID="ddlParametro" runat="server" AutoPostBack="True">
                                                                                    </asp:DropDownList></td>
                                                                                <td style="width: 17px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 17px">
                                                                                    <asp:TextBox ID="txtParametro" Width="88px" runat="server" MaxLength="50"></asp:TextBox></td>
                                                                                <td style="width: 17px">
                                                                                    <asp:Button ID="btnAplicarParametro" runat="server" Text="Aplicar"></asp:Button></td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                                <td style="height: 120px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 2px">
                                                                </td>
                                                                <td style="width: 187px; height: 2px">
                                                                    <asp:Label ID="Label7" runat="server" Text="Ancho fijo de columnas:"></asp:Label></td>
                                                                <td style="width: 13px; height: 2px">
                                                                </td>
                                                                <td style="height: 2px">
                                                                    <p align="left">
                                                                        <asp:Label ID="Label8" runat="server" Text="Tamaño de la columna"></asp:Label>:</p>
                                                                </td>
                                                                <td style="height: 2px">
                                                                </td>
                                                                <td style="height: 2px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" style="width: 9px; height: 17px">
                                                                </td>
                                                                <td style="width: 187px; height: 17px">
                                                                    <asp:RadioButtonList ID="rbAnchoFijo" runat="server" Width="80px" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Si" Selected="True">Si</asp:ListItem>
                                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:TextBox ID="txtIdAnchoFijo" runat="server" Visible="False" Width="16px"></asp:TextBox></td>
                                                                <td style="width: 13px; height: 17px">
                                                                </td>
                                                                <td style="height: 17px">
                                                                    <asp:DropDownList ID="ddlTamaño" runat="server" AutoPostBack="True">
                                                                    </asp:DropDownList></td>
                                                                <td style="height: 17px">
                                                                </td>
                                                                <td style="height: 17px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 10px">
                                                                </td>
                                                                <td style="width: 187px; height: 10px">
                                                                    <asp:Label ID="Label9" runat="server" Text="Alineación del relleno"></asp:Label>:</td>
                                                                <td style="width: 13px; height: 10px">
                                                                </td>
                                                                <td style="height: 10px">
                                                                    <asp:Label ID="Label10" runat="server" Text="Caracter de relleno"></asp:Label>:</td>
                                                                <td style="height: 10px">
                                                                </td>
                                                                <td style="height: 10px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 2px">
                                                                </td>
                                                                <td style="width: 187px; height: 2px">
                                                                    <asp:RadioButtonList ID="rbDireccionRelleno" runat="server" Height="2px" Width="166px"
                                                                        AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbDireccionRelleno_SelectedIndexChanged1">
                                                                        <asp:ListItem Value="&lt;" Selected="True">&lt; Izquierdo</asp:ListItem>
                                                                        <asp:ListItem Value="&gt;">&gt; Derecho</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                                <td style="width: 13px; height: 2px">
                                                                </td>
                                                                <td style="height: 2px">
                                                                    <asp:TextBox ID="txtCaracterRelleno" runat="server" Width="98px" AutoPostBack="True"
                                                                        MaxLength="1"></asp:TextBox>
                                                                    <asp:Button ID="btnAplicarRelleno" runat="server" Text="Aplicar"></asp:Button></td>
                                                                <td style="height: 2px">
                                                                </td>
                                                                <td style="height: 2px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 1px">
                                                                </td>
                                                                <td style="width: 187px; height: 1px">
                                                                    <asp:Label ID="Label11" runat="server" Text="Separador de columnas"></asp:Label>:</td>
                                                                <td style="width: 13px; height: 1px">
                                                                </td>
                                                                <td style="height: 1px">
                                                                    <asp:Label ID="Label12" runat="server" Text="Separador decimales"></asp:Label>:</td>
                                                                <td style="height: 1px">
                                                                </td>
                                                                <td style="height: 1px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 19px">
                                                                </td>
                                                                <td style="width: 187px; height: 19px">
                                                                    <asp:TextBox ID="txtSeparadorColumnas" runat="server" MaxLength="1">|</asp:TextBox>
                                                                    <asp:TextBox ID="txtIdSeparadorColumnas" runat="server" Visible="False" Width="16px"></asp:TextBox></td>
                                                                <td style="width: 13px; height: 19px">
                                                                </td>
                                                                <td style="height: 19px">
                                                                    <asp:TextBox ID="txtSeparadorDecimales" runat="server" MaxLength="1">.</asp:TextBox>
                                                                    <asp:TextBox ID="txtIdSeparadorDecimales" runat="server" Visible="False" Width="16px"></asp:TextBox></td>
                                                                <td style="height: 19px">
                                                                </td>
                                                                <td style="height: 19px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 1px">
                                                                </td>
                                                                <td style="width: 187px; height: 1px">
                                                                    (*)<asp:Label ID="Label13" runat="server" Text=" Formato Fecha"></asp:Label>
                                                                    :</td>
                                                                <td style="width: 13px; height: 1px">
                                                                </td>
                                                                <td style="height: 1px">
                                                                    (*)
                                                                    <asp:Label ID="Label14" runat="server" Text="Nombre Archivo"></asp:Label>:</td>
                                                                <td style="height: 1px">
                                                                </td>
                                                                <td style="height: 1px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 29px">
                                                                </td>
                                                                <td style="width: 187px; height: 29px">
                                                                    <asp:TextBox ID="txtFecha" runat="server" MaxLength="20">DD/MM/YYYY</asp:TextBox>
                                                                    <asp:TextBox ID="txtIdFecha" runat="server" Visible="False" Width="16px"></asp:TextBox></td>
                                                                <td style="width: 13px; height: 29px">
                                                                </td>
                                                                <td style="height: 29px">
                                                                    <asp:TextBox ID="txtNombreArchivo" runat="server" MaxLength="20">Fact-DD-MM-YYYY.txt</asp:TextBox>
                                                                    <asp:TextBox ID="txtIdNombreArchivo" runat="server" Visible="False" Width="16px"></asp:TextBox></td>
                                                                <td style="height: 29px">
                                                                </td>
                                                                <td style="height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 9px; height: 29px">
                                                                </td>
                                                                <td style="width: 187px; height: 29px">
                                                                    <asp:Button ID="btnReporte" runat="server" Text="Reporte de configuración"></asp:Button>
                                                                </td>
                                                                <td style="width: 13px; height: 29px">
                                                                </td>
                                                                <td style="height: 29px">
                                                                    <asp:Button ID="btnRestablecerPorDefecto" runat="server" Text="Restablecer por defecto">
                                                                    </asp:Button></td>
                                                                <td style="height: 29px">
                                                                </td>
                                                                <td style="height: 29px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="Label1" runat="server" ForeColor="DimGray" Font-Bold="True" Font-Size="XX-Small">(*) : Incluya  "DD" = día, "MM" = Mes,  "YYYY","YY" = Año, "HH" = Hora, "mm" = Minuto, "SS" = Segundo</asp:Label></td>
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
