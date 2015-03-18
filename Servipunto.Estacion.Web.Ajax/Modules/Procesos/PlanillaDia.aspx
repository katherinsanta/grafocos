<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanillaDia.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.Procesos.PlanillaDia"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <div>
        <style type="text/css">
            .ModalPopupBG
            {
                background-color: #666699;
                filter: alpha(opacity=50);
                opacity: 0.7;
            }
            
            .HellowWorldPopup
            {
                background: white;
                overflow: scroll;
            }
            div#AdjResultsDiv
            {
                width: 1300px;
                height: 201px;
                overflow: scroll;
                position: relative;
            }
            
            
            .style1
            {
                text-decoration: underline;
            }
            .Controls
            {
                text-align: center;
            }
            .style2
            {
                font-size: small;
            }
        </style>
        <table>
            <tr>
                <td>
                    <table width="100%" border="1">
                        <tr>
                            <td class="td_c" colspan="7">
                                <strong><span class="style2">PLANILLA DIA</span></strong>&nbsp;
                            </td>
                            <td align="right">
                                <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            
                        </tr>
                    </table>
                    <table border="1" width="100%">
                        <tr>
                            <td align="center">
                                <span class="style2"><strong>Resumenes</strong></span><br />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="Ventas" Style="text-align: right; font-weight: 700;
                                    font-size: small;"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <div>
                                    <asp:GridView ID="grdDetalleVentas" CssClass="Grilla" HeaderStyle-CssClass="Cabeza"
                                        HeaderStyle-HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
                                        ShowFooter="True">
                                        <Columns>
                                            <asp:BoundField DataField="cod_isl" HeaderText="Isla" />
                                            <asp:BoundField DataField="num_tur" HeaderText="Turno" />
                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:n3}" />
                                            <asp:BoundField DataField="ValorNeto" HeaderText="Subtotal" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:c3}" />
                                            <asp:BoundField DataField="Descuento" HeaderText="Descuento" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:c3}" />
                                            <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:c3}" />
                                        </Columns>
                                        <FooterStyle ForeColor="#000000" />
                                        <FooterStyle BackColor="#eede86" />
                                        <HeaderStyle BackColor="#000000" />
                                        <HeaderStyle ForeColor="#ffe800" />
                                    </asp:GridView>
                                </div>
                                <div class="HellowWorldPopup1">
                                    <div id="Div4">
                                        <strong><span class="style2">Resumen Artículos</span></strong><asp:GridView ID="grdArticulos"
                                            runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal" AlternatingRowStyle-CssClass="FilaAlternada"
                                            HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center" Width="70%"
                                            AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="Cod_Art"
                                            EmptyDataText="NO EXISTEN RESUMEN ARTICULO PARA ESTA FECHA-TURNO" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:BoundField DataField="Cod_Art" HeaderText="Código" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                                <asp:BoundField DataField="Volumen" HeaderText="Volumen" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                            </Columns>
                                            <FooterStyle ForeColor="#000000" />
                                            <FooterStyle BackColor="#eede86" />
                                            <HeaderStyle BackColor="#000000" />
                                            <HeaderStyle ForeColor="#ffe800" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="HellowWorldPopup1">
                                    <div id="Div5">
                                        <span class="style2"><strong>Resumen Formas de Pago</strong></span><br />
                                        <asp:GridView ID="grdFormasPago" runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal"
                                            AlternatingRowStyle-CssClass="FilaAlternada" HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center"
                                            Width="40%" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                            DataKeyNames="Cod_For_Pag" EmptyDataText="NO EXISTEN RESUMEN FORMA PAGO PARA ESTA FECHA-TURNO"
                                            ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:BoundField DataField="Cod_For_Pag" HeaderText="Código" />
                                                <asp:BoundField DataField="NombreFormaPago" HeaderText="Descripción" />
                                                <asp:BoundField DataField="ValorFormaPago" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                            </Columns>
                                            <FooterStyle ForeColor="#000000" />
                                            <FooterStyle BackColor="#eede86" />
                                            <HeaderStyle BackColor="#000000" />
                                            <HeaderStyle ForeColor="#ffe800" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table border="1" width="100%">
                        <tr>
                            <td align="center">
                                <span class="style2"><strong>Consolidado Ingresos</strong></span><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="HellowWorldPopup1">
                                    <div id="Div1">
                                        <span><strong><span class="style2">Lecturas</span></strong></span><asp:GridView ID="GridLecturas"
                                            runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal" AlternatingRowStyle-CssClass="FilaAlternada"
                                            HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center" Width="100%"
                                            AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GridLecturas_RowDataBound"
                                            DataKeyNames="cod_man" EmptyDataText="NO EXISTEN LECTURAS PARA ESTA FECHA-TURNO"
                                            ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:BoundField DataField="cod_man" HeaderText="Manguera" />
                                                <asp:BoundField DataField="articulo" HeaderText="Artículo" />
                                                <asp:BoundField DataField="LectInicial" HeaderText="Lect. Inicial" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="LectFinal" HeaderText="Lect. Final" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="diferencia" HeaderText="Diferencia" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="Calibracion" HeaderText="Calibración" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="VentasGls" HeaderText="Volumen" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="VentasVentas" HeaderText="Valor" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="COD_ART" HeaderText="Código&nbsp;Art." />
                                            </Columns>
                                            <FooterStyle ForeColor="#000000" />
                                            <FooterStyle BackColor="#eede86" />
                                            <HeaderStyle BackColor="#000000" />
                                            <HeaderStyle ForeColor="#ffe800" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="HellowWorldPopup1">
                                    <div id="Div2">
                                        <strong><span class="style2">Canastilla</span></strong><span class="style1"><asp:Label
                                            ID="lblArticuloHideCanastilla" runat="server" Text="hideCodigoArticulo" Visible="False"></asp:Label>
                                        </span>
                                        <br />
                                        <asp:GridView ID="grdCanastilla" runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal"
                                            AlternatingRowStyle-CssClass="FilaAlternada" HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center"
                                            Width="100%" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                             EmptyDataText="NO EXISTE CANASTILLA PARA ESTA FECHA-TURNO"
                                            ShowHeaderWhenEmpty="true">
                                            <Columns>
                                             
                                                <asp:BoundField DataField="Cod_Art" HeaderText="Código Artículo" />
                                                <asp:BoundField DataField="NombreArticulo" HeaderText="Descripción" />
                                                <asp:BoundField DataField="precio" HeaderText="Precio" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="IVA" HeaderText="IVA" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="Totaliva" HeaderText="Total Iva" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                            </Columns>
                                            <FooterStyle ForeColor="#000000" />
                                            <FooterStyle BackColor="#eede86" />
                                            <HeaderStyle BackColor="#000000" />
                                            <HeaderStyle ForeColor="#ffe800" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                        </asp:GridView>
                                    </div>
                                </div>
                        </tr>
                        <!--<tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Total Ingresos:" Style="font-weight: 700;
                                                font-size: small;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalIngresos" runat="server" Text="0" Style="text-align: right;"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>-->
                       
                    </table>
                    <div class="HellowWorldPopup1">
                        <div id="Div7">
                            <span class="style2"><strong>Consolidado Empleado</strong></span><br />
                            <asp:GridView ID="grdDescuadre" runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal"
                                AlternatingRowStyle-CssClass="FilaAlternada" HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center"
                                Width="100%" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                DataKeyNames="Cod_Emp" EmptyDataText="NO EXISTE FECHA-TURNO" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="COD_EMP" HeaderText="Codigo" />
                                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                    <asp:BoundField DataField="TotalNetoCombustible" HeaderText="Neto Combustible" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="Calibraciones" HeaderText="Calibraciones" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="TotalCombustible" HeaderText="Tot. Combustible" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="TotalCanastilla" HeaderText="Tot. Canastilla" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="TotalTurno" HeaderText="Tot. Turno" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="Consignaciones" HeaderText="Tot. Consignaciones" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="VentasNoEfectivo" HeaderText="Tot. Ventas NE" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="Recaudos" HeaderText="Recaudos" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                    <asp:BoundField DataField="Descuadre" HeaderText="Descuadre" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:c3}" />
                                </Columns>
                                <FooterStyle ForeColor="#eede86" />
                                <FooterStyle BackColor="#eede86" />
                                <HeaderStyle BackColor="#000000" />
                                <HeaderStyle ForeColor="#ffe800" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                        </div>
                        <div class="HellowWorldPopup1">
                            <div id="Div6">
                                <span class="style2"><strong>Resumen Tanques</strong></span><br />
                                <asp:GridView ID="GrdDetalleTanques" runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal"
                                    AlternatingRowStyle-CssClass="FilaAlternada" HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center"
                                    Width="100%" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                    EmptyDataText="NO EXISTE VARIACION TANQUE" ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:BoundField DataField="Articulo" HeaderText="Artículo" />
                                        <asp:BoundField DataField="Saldo_Inicial" HeaderText="Saldo Inicial" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                        <asp:BoundField DataField="comprafactura" HeaderText="Compra Factura" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                        <asp:BoundField DataField="Transito" HeaderText="Transito" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                        <asp:BoundField DataField="Compras" HeaderText="Descargues" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                        <asp:BoundField DataField="Salidas" HeaderText="Salidas" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                        <asp:BoundField DataField="Inventario" HeaderText="Inventario" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                        <asp:BoundField DataField="Saldo_Final" HeaderText="Saldo Final" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                        <asp:BoundField DataField="Variacion_Diaria" HeaderText="Variación Diaria" ItemStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:c3}" />
                                    </Columns>
                                    <FooterStyle ForeColor="#eede86" />
                                    <FooterStyle BackColor="#eede86" />
                                    <HeaderStyle BackColor="#000000" />
                                    <HeaderStyle ForeColor="#ffe800" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                            </div>
                        </div>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="style2"><strong>Datos Aprobación</strong></span><br />
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkDiaVerificado" runat="server" Text="Aprobado" TextAlign="Right" />
                            </td>
                            <td>
                                <asp:Label ID="lblFechaConfirmacion" runat="server" Text="Fecha:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaConfirmacion" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblNombreConfirmacion" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombreConfirmacion" runat="server" Width="400px"></asp:TextBox>
                            </td>

                              <td>
                                  &nbsp;</td>
                              <td>
                                  <asp:Button ID="btnGenerarXML" runat="server" Text="Generar XML"  OnClick="btnGenerarXML_Click"/>
                               
                            </td>
                           <td>
                                <asp:Button ID="btnConfirmacion" runat="server" Text="Aprobar" 
                                    Height="44px" Style="font-size: large" Width="138px" />
                            </td> 
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="Controls">
            <!--<asp:Button ID="Button1" runat="server" Text="Cancelar" />-->
        </div>
    </div>
</asp:Content>
