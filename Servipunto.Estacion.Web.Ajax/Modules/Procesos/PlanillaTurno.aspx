<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanillaTurno.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Ajax.Modules.Procesos.PlanillaTurno" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../BlueSkin/UserControls/FiltrosDeBusqueda.ascx" TagName="FiltrosDeBusqueda"
    TagPrefix="ucb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <script type="text/javascript">
        function VentanaEmergente() {
            var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=Cliente', window, 'dialogWidth:700px;dialogHeight:450px;resizable:no;center:yes');
            var txtCodigoCliente = document.getElementById('<%=txtCodigoCliente.ClientID%>');
            var txtNombreCliente = document.getElementById('<%=txtNombreCliente.ClientID%>');

            if (resultado == null) {
                alert('otra');
                resultado = window.returnValue;
            }

            if (resultado != null) {
                var arreglo = resultado.split('©');
                txtCodigoCliente.value = arreglo[0];

                txtNombreCliente.value = arreglo[1];
            }



        }

    </script>
    <script type="text/javascript">
        function MostrarMensaje(mensaje) {

            alert(mensaje);

        }

    </script>
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
            .style3
            {
                text-decoration: underline;
                font-size: small;
            }
        </style>
        <table>
            <tr>
                <td>
                    <table width="100%" border="1">
                        <tr>
                            <td class="td_c" colspan="7">
                                <strong><span class="style2">PLANILLA DE TURNO</span></strong>&nbsp;
                            </td>
                            <td align="right">
                                <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFechaTurno" runat="server" Text="Fecha:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="lblFechaInicial" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblIsla" runat="server" Text="Isla:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIsla" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblTurno" runat="server" Text="Turno:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTurno" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblHoraInicio" runat="server" Text="Hora&nbsp;Inicio:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHoraInico" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCodEmpleado" runat="server" Text="Código&nbsp;Empleado:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodigoEmpleado" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblNombreEmpleado" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtNombreEmpleado" runat="server" ReadOnly="True" Width="600"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblHoraFinal" runat="server" Text="Hora&nbsp;Final:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHoraFinal" runat="server" ReadOnly="True"></asp:TextBox>
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
                                <asp:Label ID="Label2" runat="server" Text="Detalle Ventas" Style="text-align: right;
                                    font-weight: 700; font-size: small;"></asp:Label>
                                &nbsp;
                                <asp:ImageButton ID="imgAdicionVenta" runat="server" ImageUrl="~/BlueSkin/Update/crear16px.png"
                                    OnClick="imgAdicionVenta_Click" ToolTip="Adicionar Venta" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <div style="overflow-x: auto; width: 100%">
                                    <asp:GridView ID="grdDetalleVentas" CssClass="Grilla" HeaderStyle-CssClass="Cabeza"
                                        HeaderStyle-HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="Consecutivo" OnRowCommand="grdDetalleVentas_RowCommand" OnRowDataBound="grdDetalleVentas_RowDataBound"
                                        ShowFooter="True">
                                        <Columns>
                                            <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" SortExpression="Consecutivo" />
                                            <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
                                            <asp:BoundField DataField="cod_car" HeaderText="Cara" />
                                            <asp:BoundField DataField="cod_isl" HeaderText="Isla" />
                                            <asp:BoundField DataField="cod_cli" HeaderText="Cliente" />
                                            <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
                                            <asp:BoundField DataField="formaPago" HeaderText="Forma_Pago" />
                                            <asp:BoundField DataField="Articulo" HeaderText="Artículo" />
                                            <asp:BoundField DataField="precio_uni" HeaderText="Precio" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:c3}" />
                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:n3}" />
                                            <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:c3}" />
                                            <asp:BoundField DataField="Descuento" HeaderText="Descuento" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:c3}" />
                                            <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:c3}" />
                                            <asp:BoundField DataField="kil_Act" HeaderText="Kilometraje" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="IdentificadorManifiesto" HeaderText="Manifiesto" ItemStyle-HorizontalAlign="Right" />
                                            <asp:TemplateField HeaderText="Editar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtn" ImageUrl="~/BlueSkin/Icons/2011/modificar16px.png" runat="server"
                                                        Width="25" Height="25" OnClick="imgbtn_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eliminar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnEliminarVentaTurno" ImageUrl="~/BlueSkin/Icons/2011/eliminar16px.png"
                                                        runat="server" Width="25" Height="25" OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');"
                                                        CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="cod_art" HeaderText="cod_art" Visible="true" />
                                            <asp:BoundField DataField="cod_for_pag" HeaderText="cod_for_pag" Visible="true" />
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
                                            EmptyDataText="NO EXISTEN RESUMEN ARTICULO PARA ESTA FECHA-TURNO" ShowHeaderWhenEmpty="true"
                                            OnRowDataBound="grdArticulos_RowDataBound">
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
                                            ShowHeaderWhenEmpty="true" OnRowDataBound="grdFormasPago_RowDataBound">
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
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnLecturas" ImageUrl="~/BlueSkin/Icons/2011/modificar16px.png"
                                                            runat="server" Width="25" Height="25" OnClick="imgbtnLecturas_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                                            DataKeyNames="Consecutivo" EmptyDataText="NO EXISTE CANASTILLA PARA ESTA FECHA-TURNO"
                                            ShowHeaderWhenEmpty="true" OnRowDataBound="grdCanastilla_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Prefijo" HeaderText="Prefijo" />
                                                <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" />
                                                <asp:BoundField DataField="Cod_Art" HeaderText="Código Artículo" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                                <asp:BoundField DataField="precio_uni" HeaderText="Precio" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="IVA" HeaderText="IVA" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:n3}" />
                                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="vr_iva" HeaderText="Total Iva" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnCanastilla" ImageUrl="~/BlueSkin/Icons/2011/modificar16px.png"
                                                            runat="server" Width="25" Height="25" OnClick="imgbtnCanastilla_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Anular">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgEliminarVentaCanastilla" ImageUrl="~/BlueSkin/Icons/2011/eliminar16px.png"
                                                            runat="server" Width="25" Height="25" OnClick="imgEliminarVentaCanastilla_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                        <tr>
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
                        </tr>
                        <tr>
                            <td>
                                <div class="HellowWorldPopup1">
                                    <div id="Div3">
                                        <span class="style2"><strong>Consignaciones&nbsp;&nbsp; </strong></span><span class="style3">
                                            <asp:ImageButton ID="imgAdiconarBolsa" runat="server" ImageUrl="~/BlueSkin/Update/crear16px.png"
                                                OnClick="imgAdiconarBolsa_Click" ToolTip="Adicionar Bolsa de Turno" />
                                        </span>
                                        <br />
                                        <asp:GridView ID="grdBolsasTurno" runat="server" CssClass="Grilla" RowStyle-CssClass="FilaNormal"
                                            AlternatingRowStyle-CssClass="FilaAlternada" HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center"
                                            Width="70%" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                            DataKeyNames="Consecutivo" EmptyDataText="NO EXISTEN BOLSAS DE TURNO PARA ESTA FECHA-TURNO"
                                            ShowHeaderWhenEmpty="true" OnRowDataBound="grdBolsasTurno_RowDataBound" OnRowCommand="grdBolsasTurno_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" />
                                                <asp:BoundField DataField="Vr_moneda" HeaderText="Moneda" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="Vr_billete" HeaderText="Billete" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:BoundField DataField="Vr_total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                    DataFormatString="{0:c3}" />
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnBolsas" ImageUrl="~/BlueSkin/Icons/2011/modificar16px.png"
                                                            runat="server" Width="25" Height="25" OnClick="imgbtnBolsa_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgEliminarBolsaTurno" ImageUrl="~/BlueSkin/Icons/2011/eliminar16px.png"
                                                            runat="server" Width="25" Height="25" OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');"
                                                            CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                            </td>
                        </tr>
                        <tr>
                            <td>
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
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="style2"><strong>Datos Aprobación</strong></span><br />
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkTurnoVerificado" runat="server" Text="Aprobado" TextAlign="Right" />
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
                                            <asp:Button ID="btnConfirmacion" runat="server" Text="Aprobar" OnClick="btnConfirmacion_Click"
                                                Height="44px" Style="font-size: large" Width="138px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="Controls">
            <!--<asp:Button ID="Button1" runat="server" Text="Cancelar" />-->
        </div>
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup"
            PopupControlID="pnlpopup" CancelControlID="Button3" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="600px" Width="350px"
            Style="display: none">
            <table width="100%" style="border: Solid 3px #6087b9; width: 100%; height: 100%"
                cellpadding="0" cellspacing="0">
                <tr style="background-color: #000000">
                    <td colspan="3" style="height: 10%; color: #ffe800; font-weight: bold; font-size: larger"
                        align="center">
                        Detalle Venta
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        *Indica&nbsp;Campo&nbsp;obligatorio
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
               
                <tr>
                    <td align="left">
                        <br />
                        &nbsp;*Consecutivo:
                    </td>
                    <td align="left">
                        <br />
                        <asp:Label ID="lblConsecutivo" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;    
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Cara:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCaraVenta" runat="server" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;Cliente:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigoCliente" runat="server" Style="text-align: right;" MaxLength="12" />
                        <asp:RegularExpressionValidator ID="rgCodigoCliente" runat="server" ErrorMessage="Error: Código Cliente invalido"
                            ValidationExpression="^(?:\+|-)?\d+$" ControlToValidate="txtCodigoCliente"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left">
                        <input id="Button1" onclick="VentanaEmergente()" title="Buscar clientes" type="button"
                            value="..." tyle="text-align: left;" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;Nombre&nbsp;Cliente:
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNombreCliente" runat="server" Style="text-align: left;" ReadOnly="true" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;Placa:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPlaca" runat="server" Style="text-align: left;" MaxLength="10" />
                    </td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Artículo:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlArticuloVenta" runat="server" OnSelectedIndexChanged="ArticuloVenta_OnSelectedIndexChanged"
                            AutoPostBack="true" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Precio:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrecio" runat="server" Style="text-align: right;" maxlenght="10"
                            OnTextChanged="txtPrecio_TextChanged" AutoPostBack="true" />
                        <asp:RegularExpressionValidator ID="erPrecioVenta" runat="server" ControlToValidate="txtPrecio"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$" ErrorMessage="Error: precio no Valido" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Cantidad:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCantidad" runat="server" Style="text-align: right;" OnTextChanged="txtCantidad_TextChanged"
                            AutoPostBack="true" />
                        <asp:RegularExpressionValidator ID="erCantidadVenta" runat="server" ControlToValidate="txtCantidad"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: Cantidad no Valida" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Valor Neto:
                    </td>
                    <td>
                        <asp:TextBox ID="txtValorNeto" runat="server" Style="text-align: right;" OnTextChanged="txtValorNeto_TextChanged"
                            AutoPostBack="true" />
                        <asp:RegularExpressionValidator ID="erValorNeto" runat="server" ControlToValidate="txtValorNeto"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: Valor Neto no Valido" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;Descuento:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescuento" runat="server" Style="text-align: right;" maxlenght="12"
                            OnTextChanged="txtDescuento_TextChanged" AutoPostBack="true" />
                        <asp:RegularExpressionValidator ID="erDescuento" runat="server" ControlToValidate="txtDescuento"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: Descuento no Valido" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Total:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotal" runat="server" Style="text-align: right;" maxlenght="12" />
                        <asp:RegularExpressionValidator ID="erTotal" runat="server" ControlToValidate="txtTotal"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: Total no Valido" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Forma Pago:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFormasPagoVenta" runat="server" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;Kilometraje:
                    </td>
                    <td>
                        <asp:TextBox ID="txtKilometraje" runat="server" Style="text-align: right;" MaxLenght="12" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Error: Kilometraje invalido"
                            ValidationExpression="^(?:\+|-)?\d+$" ControlToValidate="txtKilometraje"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;Manifiesto:
                    </td>
                    <td>
                        <asp:TextBox ID="txtManifiesto" runat="server" Style="text-align: right;" maxlenght="12" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Manifiesto invalido"
                            ValidationExpression="^(?:\+|-)?\d+$" ControlToValidate="txtManifiesto"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button2" CommandName="Update" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
                        <asp:Button ID="Button3" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="BtnPopPupLecturas" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="ModalPopupExtenderLects" runat="server" TargetControlID="BtnPopPupLecturas"
            PopupControlID="pnlpopupLects" CancelControlID="Button5" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnlpopupLects" runat="server" BackColor="White" Height="260px" Width="300px"
            Style="display: none">
            <table width="100%" style="border: Solid 3px #6087b9; width: 100%; height: 100%"
                cellpadding="0" cellspacing="0">
                <tr style="background-color: #000000">
                    <td colspan="2" style="height: 10%; color: #ffe800; font-weight: bold; font-size: larger"
                        align="center">
                        Detalle Lectura:
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 45%">
                        &nbsp;*Manguera:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMangueraLec" runat="server" Style="text-align: right;" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Artículo:
                    </td>
                    <td>
                        <asp:TextBox ID="txtArticulolec" runat="server" Style="text-align: right;" ReadOnly="true" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Lectura Inicial:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLecturaInicialLec" runat="server" Style="text-align: right;" />
                        <asp:RegularExpressionValidator ID="egLecturaInicial" runat="server" ControlToValidate="txtLecturaInicialLec"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: Lectura inicial no Valida" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Lectura&nbsp;Final:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLecturaFinallec" runat="server" Style="text-align: right;" />
                        <asp:RegularExpressionValidator ID="erLecturaFinal" runat="server" ControlToValidate="txtLecturaFinallec"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: Lectura final no Valida" />
                       
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                     <asp:CompareValidator ID="compareLecturas" runat="server" ErrorMessage="Error:lectura final inferior a la inicial "
                            ControlToValidate="txtLecturaFinallec" ControlToCompare="txtLecturaInicialLec"
                            Type="Double" Operator="GreaterThanEqual"></asp:CompareValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="Button4" CommandName="Update" runat="server" Text="Actualizar" OnClick="btnUpdateLectura_Click" />
                        <asp:Button ID="Button5" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="BtnPopPupCanastilla" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="MpeCanastilla" runat="server" TargetControlID="BtnPopPupCanastilla"
            PopupControlID="pnlpopupCanastilla" CancelControlID="Button5" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnlpopupCanastilla" runat="server" BackColor="White" Height="310px"
            Width="300px" Style="display: none">
            <table width="100%" style="border: Solid 3px #6087b9; width: 100%; height: 100%"
                cellpadding="0" cellspacing="0">
                <tr style="background-color: #000000">
                    <td colspan="2" style="height: 10%; color: #ffe800; font-weight: bold; font-size: larger"
                        align="center">
                        Detalle Canastilla:
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 45%">
                        &nbsp;Prefijo:
                    </td>
                    <td>
                        <asp:Label ID="txtPrefijoCanastilla" runat="server" ReadOnly="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 45%">
                        &nbsp;*Consecutivo:
                    </td>
                    <td>
                        <asp:Label ID="lblConsecutivoCanastilla" runat="server" ReadOnly="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 45%">
                        &nbsp;*Código Articulo:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCod_artCanastilla" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Precio:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrecioCanastila" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPrecioCanastila"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: precio canastilla no Valida" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Cantidad:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCantidadCanastilla" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCantidadCanastilla"
                            ValidationExpression="^[0-9]{1,7}(\,[0-9]{0,3})?$(\.[0-9]{0,3})?$" ErrorMessage="Error: cantidad no Valida" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button6" CommandName="Update" runat="server" Text="Actualizar" OnClick="btnUpdateCanastilla_Click" />
                        <asp:Button ID="Button7" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="btnPopPupBolsaTurno" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="mdlBolsaTurno" runat="server" TargetControlID="btnPopPupBolsaTurno"
            PopupControlID="pnlpopupBolsaTurno" CancelControlID="Button5" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnlpopupBolsaTurno" runat="server" BackColor="White" Height="210px"
            Width="300px" Style="display: none">
            <table width="100%" style="border: Solid 3px #6087b9; width: 100%; height: 100%"
                cellpadding="0" cellspacing="0">
                <tr style="background-color: #000000">
                    <td colspan="2" style="height: 10%; color: #ffe800; font-weight: bold; font-size: larger"
                        align="center">
                        Detalle Bolsa de Turno:
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 45%">
                        &nbsp;Consecutivo:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConsecutivoBolsa" runat="server" Style="text-align: right;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Moneda:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMonedaBolsa" runat="server" Style="text-align: right;" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;*Billete:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBilleteBolsa" runat="server" Style="text-align: right;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button8" CommandName="Update" runat="server" Text="Actualizar" OnClick="btnUpdateBolsa_Click" />
                        <asp:Button ID="Button9" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="BtnAprobarCierre" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="mdlAprobarCierre" runat="server" TargetControlID="BtnAprobarCierre"
            PopupControlID="pnlAprobarCierre" CancelControlID="Button5" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnlAprobarCierre" runat="server" BackColor="White" Height="150px"
            Width="300px" Style="display: none">
            <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%"
                cellpadding="0" cellspacing="0">
                <tr style="background-color: #000000">
                    <td colspan="2" style="height: 10%; color: #ffe800; font-weight: bold; font-size: larger"
                        align="center">
                        Aprobación de Planilla Turno:
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="center">
                        <asp:Button ID="Button11" CommandName="Update" runat="server" Text="Aprobacion Turno OK"
                            OnClick="btnTurnoAprobado_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
