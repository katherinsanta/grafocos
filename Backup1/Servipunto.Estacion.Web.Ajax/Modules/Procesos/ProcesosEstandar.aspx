<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcesosEstandar.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.ProcesosEstandar" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                        <!-- Developer Custom Content -->
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label1" runat="server" Text="En esta página encontrará un grupo de opciones para la generación de planos de Terceros y Facturación."></asp:Label></font></p>
                                        <blockquote>
                                            <table cellspacing="5" cellpadding="5" border="0" width="100%">
                                                <tr align="left">
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <!--<td vAlign="top"><IMG height="48" src="../../BlueSkin/Icons/Isla-48.gif" width="48" border="0"></td>-->
                                                                <td>
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,690,310,0,1,0,0,0,1,0)" href="FiltroMaestroTerceros.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label2" runat="server" Text="Generación 
																				Maestro de Terceros"></asp:Label></u> </a>&nbsp;
                                                                    <br />
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label3" runat="server" Text="Generación de Plano de Maestro de Terceros (Clientes)."></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,350,360,0,1,0,0,0,1,0)" href="FiltroPlanoFacturas.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label4" runat="server" Text="Archivo Plano de Facturas"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                    <br />
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label5" runat="server" Text="Generación Archivo Plano de Facturas."></asp:Label></font>&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,350,340,0,1,0,0,0,1,0)"
                                                                        href="FiltroVentasArticulo.aspx"><u>
                                                                            <asp:Label ID="Label6" runat="server" Text="Archivo Plano Ventas por Artículo"></asp:Label></u>
                                                                    </a>&nbsp;
                                                                        <br>
                                                                        <font color="gray">
                                                                            <asp:Label ID="Label7" runat="server" Text="Generación Archivo Plano de Ventas por Artículo."></asp:Label></font></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <br>
                                                                    <a onclick="return AbrirVentanaCentrada(this,null,350,380,0,1,0,0,0,1,0)" href="FiltroImportarClientesCorporativos.aspx">
                                                                        <u>
                                                                            <asp:Label ID="Label8" runat="server" Text="Importar Clientes Corporativos"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                    <br>
                                                                    <font color="gray">
                                                                        <asp:Label ID="Label9" runat="server" Text="Importa un archivo plano con los clientes credito y sus vehiculos."></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table id="Table1">
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,350,340,0,1,0,0,0,1,0)"
                                                                        href="FiltroVentasCreditoContado.aspx"><u>
                                                                            <asp:Label ID="Label10" runat="server" Text="Archivo Plano de Ventas Crédito o Contado"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label11" runat="server" Text="Genera un archivo plano de ventas con forma de pago crédito ó contado."></asp:Label>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table id="Table2">
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="FiltroArchivosMaster.aspx"><u>
                                                                            <asp:Label ID="Label12" runat="server" Text="Archivos Planos Master"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label13" runat="server" Text="Genera archivos planos de Reporte de Ventas, Total de lecturas Electronicas, Mapa de articulos, Cuentas, Precios."></asp:Label>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table id="Table3">
                                                            <tr>
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="FiltroVentasNoTrasmitidas.aspx"><u>
                                                                            <asp:Label ID="Label14" runat="server" Text="Archivo Plano de Ventas no transmitidas"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label15" runat="server" Text="Genera un archivo de ventas pendientes por transmitir en linea."></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table id="Table4">
                                                            <tr align="left">
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="FiltroPlanoInventario.aspx"><u>
                                                                            <asp:Label ID="Label16" runat="server" Text="Archivo Plano de Inventarios"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label17" runat="server" Text="Genera un archivo de ventas para manejo de inventarios."></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table id="Table5">
                                                            <tr align="left">
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="FiltroPlanosSyscon.aspx"><u>
                                                                            <asp:Label ID="Label18" runat="server" Text="Archivo Planos de Lecturas y Ventas"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label19" runat="server" Text="Genera un archivo de Lecturas y ventas por fecha y turno"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table id="Table6">
                                                            <tr align="left">
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)"
                                                                        href="FiltroPlanoVentasInsepec.aspx"><u>
                                                                            <asp:Label ID="Label20" runat="server" Text="Archivo Planos de Ventas Credito/Contado"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label21" runat="server" Text="Genera un archivo de Lecturas y ventas por fecha"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="50%">
                                                        <table id="Table7">
                                                            <tr align="left">
                                                                <td valign="top">
                                                                    <img height="48" src="../../BlueSkin/Icons/2011/GenerarArchivoPlano.png" width="48"
                                                                        border="0">
                                                                </td>
                                                                <td>
                                                                    <font color="gray"><a onclick="return AbrirVentanaCentrada(this,null,650,350,0,1,0,0,0,1,0)" 
                                                                        href="FiltroPlanoMelisa.aspx"><u>
                                                                            <asp:Label ID="Label22" runat="server" Text="Archivo Planos de Ventas Credito o Contado MELISA"></asp:Label></u>&nbsp;</a>&nbsp;
                                                                        <br>
                                                                        <asp:Label ID="Label23" runat="server" Text="Genera un archivo de Lecturas y ventas por fecha MELISA"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                    </td>
                                </tr>
                            </table>
                            </blockquote>
                            <p>
                                &nbsp;</p>
                            <!-- End Developer Custom Content -->
                        </td>
                    </tr>
                </table>
                <!-- End Topic Content -->
            </td>
            <!-- End Topic Body -->
        </tr>
    </table>
    </td> </tr> </table>
</asp:Content>
