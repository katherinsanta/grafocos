<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FiltroPlantillaTurno.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.FiltroPlantillaTurno"
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
        </style>
        <blockquote>
            <font class="NormalFont">
                <p>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
            </font>
        </blockquote>
        <asp:Panel ID="pnlForm" Visible="true" runat="server">
            <table cellspacing="1" cellpadding="5" align="center" bgcolor="#5482fc" border="0"
                style="width: 358px">
                <tr>
                    <td bgcolor="#eeeeee">
                        <asp:Label ID="lblReporte" runat="server">Titulo del Reporte</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#fefbff">
                        <!-- Developer Custom Code -->
                        <table cellspacing="1" cellpadding="5" width="100%" border="0">
                            <tr>
                                <td style="width: 79px" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha del Turno"> </asp:Label>:<br />
                                    <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
                                </td>
                                <caption>
                                    <br />
                                    <tr>
                                        <td style="width: 19px">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFechaInicial">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                </caption>
                            </tr>
                            <tr>
                                <td style="width: 79px" valign="top">
                                    Isla:
                                </td>
                                <td style="width: 19px">
                                    <asp:TextBox ID="txtIsla" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 79px" valign="top">
                                    Turno:
                                </td>
                                <td style="width: 19px">
                                    <asp:TextBox ID="txtTurno" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <!-- End Developer Custom Code -->
                        <table cellspacing="0" cellpadding="5" width="100%" border="0">
                            <tr>
                                <td>
                                    <div align="right">
                                        <asp:LinkButton ID="lnkGenerar" runat="server" Text="Generar"></asp:LinkButton>
                                        | <a href="planillascontables.aspx">
                                            <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="btnModal" runat="server" Text="Generar" Style="display: none" />
                       
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="btnCancel"
                            TargetControlID="btnModal" PopupControlID="Panel1" PopupDragHandleControlID="PopupHeader"
                            Drag="true" BackgroundCssClass="HellowWorldPopup">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="Panel1" Style="display: none" runat="server" ScrollBars="Vertical" >
                            <table>
                                <tr>
                                    <td>
                                       <span><strong>DETALLE VENTAS</strong></span><br />
                                        <div class="HellowWorldPopup">
                                            <div id="AdjResultsDiv">                                             
                                                <asp:GridView ID="grdDetalleVentas" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" Height="176px"
                                                    ShowFooter="True" OnRowDataBound="grdDetalleVentas_RowDataBound" OnSorting="SortingGrilla"
                                                    DataKeyNames="consecutivo" EmptyDataText="NO EXISTEN VENTAS PARA ESTA FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" SortExpression="Consecutivo" />
                                                        <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
                                                        <asp:BoundField DataField="cod_car" HeaderText="Cara" />
                                                        <asp:BoundField DataField="cod_isl" HeaderText="Isla" />
                                                        <asp:BoundField DataField="cod_cli" HeaderText="Cliente" />
                                                        <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
                                                        <asp:BoundField DataField="formaPago" HeaderText="FormaPago" />
                                                        <asp:BoundField DataField="Articulo" HeaderText="Articulo" />
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
                                                        <asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgbtn" ImageUrl="~/Edit.jpg" runat="server" Width="25" Height="25"
                                                                    OnClick="imgbtn_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" ShowDeleteButton="True" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                                <tr>
                                    <td>
                                        <div class="HellowWorldPopup1">
                                            <div id="Div1">
                                                <span ><strong>DETALLE LECTURAS</strong></span><br />
                                                <asp:GridView ID="GridLecturas" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                                    OnRowDataBound="GridLecturas_RowDataBound" DataKeyNames="cod_man" EmptyDataText="NO EXISTEN LECTURAS PARA ESTA FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
                                                    <Columns>
                                                        <asp:BoundField DataField="cod_man" HeaderText="Manguera" SortExpression="cod_man" />
                                                        <asp:BoundField DataField="articulo" HeaderText="articulo" />
                                                        <asp:BoundField DataField="LectInicial" HeaderText="Lect_Inicial" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:n3}" />
                                                        <asp:BoundField DataField="LectFinal" HeaderText="Lect_Final" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:n3}" />
                                                        <asp:BoundField DataField="diferencia" HeaderText="Diferencia" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:n3}" />
                                                        <asp:BoundField DataField="Calibracion" HeaderText="Calibracion" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:n3}" />
                                                        <asp:BoundField DataField="VentasGls" HeaderText="Volumen" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:n3}" />
                                                        <asp:BoundField DataField="VentasVentas" HeaderText="Valor" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                        <asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgbtnLecturas" ImageUrl="~/Edit.jpg" runat="server" Width="25"
                                                                    Height="25" OnClick="imgbtnLecturas_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" ShowDeleteButton="True" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                                <tr>
                                    <td>
                                        <div class="HellowWorldPopup1">
                                            <div id="Div2">
                                                <span class="style1"><strong>DETALLE CANASTILLA</strong></span><br />
                                                <asp:GridView ID="grdCanastilla" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                                    DataKeyNames="cod_man" EmptyDataText="NO EXISTE CANASTILLA PARA ESTA FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
                                                    <Columns>
                                                        <asp:BoundField DataField="cod_art" HeaderText="Cod_Art" SortExpression="cod_art" />
                                                        <asp:BoundField DataField="Nombrearticulo" HeaderText="Articulo" />
                                                        <asp:BoundField DataField="Precio" HeaderText="Lect_Inicial" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                        <asp:BoundField DataField="IVA" HeaderText="IVA" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:n3}" />
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:n3}" />
                                                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                        <asp:BoundField DataField="TotalIVa    " HeaderText="TotalIva" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                        <asp:BoundField DataField="Total    " HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                        <asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgbtnLecturas" ImageUrl="~/Edit.jpg" runat="server" Width="25"
                                                                    Height="25" OnClick="imgbtnLecturas_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" ShowDeleteButton="True" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                                <tr>
                                    <td>
                                        <div class="HellowWorldPopup1">
                                            <div id="Div3">
                                                <span class="style1"><strong>DETALLE BOLSA DE TURNOS</strong></span><br />
                                                <asp:GridView ID="grdBolsasTurno" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                                    DataKeyNames="Consecutivo" EmptyDataText="NO EXISTEN BOLSAS DE TURNO PARA ESTA FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
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
                                                                <asp:ImageButton ID="imgbtnLecturas" ImageUrl="~/Edit.jpg" runat="server" Width="25"
                                                                    Height="25" OnClick="imgbtnLecturas_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" ShowDeleteButton="True" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                                <tr>
                                    <td>
                                        <div class="HellowWorldPopup1">
                                            <div id="Div6">
                                                <span class="style1"><strong>DETALLE BOLSA DE TURNOS</strong></span><br />
                                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                                    DataKeyNames="Consecutivo" EmptyDataText="NO EXISTEN BOLSAS DE TURNO PARA ESTA FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
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
                                                                <asp:ImageButton ID="imgbtnLecturas" ImageUrl="~/Edit.jpg" runat="server" Width="25"
                                                                    Height="25" OnClick="imgbtnLecturas_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" ShowDeleteButton="True" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                                <tr>
                                    <td>
                                        <div class="HellowWorldPopup1">
                                            <div id="Div4">
                                                <span class="style1"><strong>RESUMEN ARTICULO</strong></span><br />
                                                <asp:GridView ID="grdArticulos" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                                    DataKeyNames="Cod_Art" EmptyDataText="NO EXISTEN RESUMEN ARTICULO PARA ESTA FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Cod_Art" HeaderText="Codigo" />
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                        <asp:BoundField DataField="Volumen" HeaderText="Volumen" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                        <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                                <tr>
                                    <td>
                                        <div class="HellowWorldPopup1">
                                            <div id="Div5">
                                                <span class="style1"><strong>RESUMEN FORMA PAGO</strong></span><br />
                                                <asp:GridView ID="grdFormasPago" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                                    DataKeyNames="Cod_For_Pag" EmptyDataText="NO EXISTEN RESUMEN FORMA PAGO PARA ESTA FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Cod_For_Pag" HeaderText="Codigo" />
                                                        <asp:BoundField DataField="NombreFormaPago" HeaderText="Descripcion" />
                                                        <asp:BoundField DataField="ValorFormaPago" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                            DataFormatString="{0:c3}" />
                                                        
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                                <tr>
                                    <td>
                                        <div class="HellowWorldPopup1">
                                            <div id="Div7">
                                                <span class="style1"><strong>DESCUADRE EMPLEADO</strong></span><br />
                                                <asp:GridView ID="grdDescuadre" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                    Width="1267px" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="True"
                                                    DataKeyNames="Cod_Emp" EmptyDataText="NO EXISTE FECHA-TURNO"
                                                    ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <HeaderStyle BackColor="#ffff99" />
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
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <RowStyle BackColor="#F7F7DE" />
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
                            <div class="Controls">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
                                <!--<asp:Button ID="Button1" runat="server" Text="Cancelar" />-->
                            </div>
                            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup"
                                PopupControlID="pnlpopup" CancelControlID="Button3" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="269px" Width="400px"
                                Style="display: none">
                                <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%"
                                    cellpadding="0" cellspacing="0">
                                    <tr style="background-color: #D55500">
                                        <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                                            align="center">
                                            Detalle Venta:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 45%">
                                            Consecutivo:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Hora:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtfname" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Cara:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtlname" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Isla:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Placa:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesg" runat="server" />
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
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
