<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Servipunto.Estacion.Web.Modules.Procesos.Default"
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
                                    <td style="padding-right: 30px; padding-left: 40px; height: 225px;">
                                        <!-- Custom Content -->
                                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label5" runat="server" Text="Categoria de procesos disponibles:"></asp:Label></font></p>
                                        <table cellspacing="5" cellpadding="10" align="center" border="0">
                                            <tr>
                                                <!--OPCIONES GNV -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="OpcionesGNV.aspx">
                                                        <img alt="Generales" src="../../BlueSkin/Icons/2011/SincronizacionExternaGNV.png"
                                                            border="0">&nbsp;<br>
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="OpcionesGNV.aspx">
                                                        <asp:Label ID="Label1" runat="server" Text="Sincronización externa GNV"></asp:Label>
                                                    </a>
                                                    <p class="Descripcion" >Actualice Tablas A partir DeArchivos Planos</p>
                                                </td>
                                                <!--INTERFAZ CONTABLE -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="InterfazContable.aspx">
                                                        <img alt="Interfaz Contable" src="../../BlueSkin/Icons/2011/ArchivosPlanosContables.png"
                                                            border="0">&nbsp;<br>
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="InterfazContable.aspx">
                                                        <asp:Label ID="Label2" runat="server" Text="Archivos planos Contables"></asp:Label>
                                                    </a>
                                                    <p class="Descripcion" >Genere Archivos pLanos Contables</p>
                                                </td>
                                                <%--<td valign="top" align="center" width="138">
                                                    <a href="InterfazRecaudoGDO.aspx">
                                                        <img alt="Interfaz Recaudo GDO" src="../../BlueSkin/Icons/Recaudo-48.gif" border="0">&nbsp;<br>--%>
                                                <asp:Label Visible="false" ID="Label3" runat="server" Text="Archivos planos de Recaudo GDO"></asp:Label><%--</a>
                                                </td>--%><!--AJUSTE PREPAGOS --><td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="AjustePago.aspx">
                                                        <img alt="Ajuste de Pagos" src="../../BlueSkin/Icons/2011/AjusteDePagos.png" border="0">&nbsp;<br>
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="AjustePago.aspx">
                                                        <asp:Label ID="Label4" runat="server" Text="Ajuste de pagos"></asp:Label>
                                                    </a>
                                                    <p class="Descripcion" >Ajuste Pagos De Clientes</p>
                                                </td>
                                                <!--REGISTRO OTROS INGRESOS -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="RegistroOtrosIngresos.aspx">
                                                        <img alt="Otros Ingresos" src="../../BlueSkin/Icons/2011/OtrosIngresos.png" border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="RegistroOtrosIngresos.aspx">
                                                        Otros Ingresos </a>
                                                        <p class="Descripcion" >Cree Modifique o Elimine Otros Ingresos</p>
                                                </td>
                                                <!--INVENTARIO CANASTILLA -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="RegistroCompraCanastilla.aspx">
                                                        <img alt="Otros Ingresos" src="../../BlueSkin/Icons/2011/FormaPago.png" border="0">
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="148px">
                                                    <a href="RegistroCompraCanastilla.aspx">Registro Inventario Canastilla </a>
                                                    <p class="Descripcion" >Actualice Los Registros De Canastilla </p>
                                                </td>
                                            </tr>
                                            <tr>
                                            <!--ACTUALIZAR VENTA -->
                                            <td valign="top" align="center" style="margin: 0px; height: 52px" width="68px">
                                                    <a href="RegistroCompraCanastilla.aspx">
                                                        <img alt="Actualizar Venta Por Tiquete" src="../../BlueSkin/Icons/2011/VentasNITUno.png" border="0">
                                                    </a>
                                                </td>
                                          <td valign="top" align="left" style="height: 52px; margin: 0px;" width="148px">
                                                    <a href="ActualizarVentaCliente.aspx">Actualizar Venta Cliente </a>
                                                    <p class="Descripcion" >Actualice La Venta Generada Para Un Cliente
                                                    </p>
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- End Custom Content -->
                                        <blockquote>
                                        </blockquote>
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
    </table>
</asp:Content>
