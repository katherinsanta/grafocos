<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FacturasCanastilla.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Consultas.FacturasCanastilla" EnableEventValidation="false"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="../../BlueSkin/UserControls/FiltrosDeBusqueda.ascx" TagName="FiltrosDeBusqueda"
    TagPrefix="uc1" %>
<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-left: 40px; padding-right: 30px">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <input type="hidden" id="HiddenUpdate" runat="server" name="HiddenUpdate" />
                                            <table width="100%">
                                                <tr>
                                                    <td class="ActionsHeader" align="right">
                                                        <span id="Acciones" runat="server">Actions</span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="border" cellspacing="1" cellpadding="4" border="0" style="width: 100%;
                                                background-color: #cccccc">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="width: 611px">
                                                        <table id="Table3" width="100%">
                                                            <tr>
                                                                <td style="width: 745px" width="745">
                                                                    <asp:Label ID="lblTituloGenerales" runat="server">
																									<b>Buscar por</b></asp:Label></td>
                                                                <td align="right" width="5%">
                                                                </td>
                                                                <td align="right" style="width: 5%">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="border">
                                                <tr>
                                                    <td style="width: 6140px; height: 25px" valign="middle">
                                                        <asp:Label ID="Label1" runat="server" Text="Fecha Inicial"></asp:Label>:</td>
                                                    <td style="width: 1996px; height: 25px">
                                                        <asp:TextBox ID="txtFechaInicio" runat="server" Width="127px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicio">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td style="height: 25px">
                                                        <asp:ImageButton ID="ibMostrarCalendarioInicial" runat="server" Height="16px" ImageUrl="~/BlueSkin/Icons/2011/Activo-16.png"
                                                            OnClick="ibMostrarCalendarioInicial_Click" Width="16px" Visible="false" /></td>
                                                    <td style="width: 2539px; height: 25px">
                                                        <asp:Label ID="Label2" runat="server" Text="Estado"></asp:Label>:</td>
                                                    <td style="width: 369px; height: 25px">
                                                        <asp:DropDownList ID="ddlEstado" runat="server" Width="143px">
                                                            <asp:ListItem Value="2">Todos</asp:ListItem>
                                                            <asp:ListItem Value="0">Activos</asp:ListItem>
                                                            <asp:ListItem Value="1">Inactivos</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 4229px; height: 25px">
                                                        <asp:Label ID="Label6" runat="server" Text="Identificación Cliente"></asp:Label>:</td>
                                                    <td style="width: 2640px; height: 25px">
                                                        <asp:TextBox ID="txtIdentificacion" runat="server" Width="320px"></asp:TextBox></td>
                                                    <td style="width: 249px; height: 25px">
                                                        <asp:DropDownList ID="ddlComodin2" runat="server">
                                                            <asp:ListItem Value="1">Inicien</asp:ListItem>
                                                            <asp:ListItem Value="2">Finalicen</asp:ListItem>
                                                            <asp:ListItem Value="3">Contengan</asp:ListItem>
                                                            <asp:ListItem Value="0">Iguales</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" style="width: 6140px">
                                                    </td>
                                                    <td style="width: 1996px">
                                                        <asp:Calendar ID="FechaInicio" runat="server" BackColor="White" BorderColor="#999999"
                                                            CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                            ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="FechaInicio_SelectionChanged"
                                                            Visible="False">
                                                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                                            <SelectorStyle BackColor="#CCCCCC" />
                                                            <WeekendDayStyle BackColor="#FFFFCC" />
                                                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                            <OtherMonthDayStyle ForeColor="Gray" />
                                                            <NextPrevStyle VerticalAlign="Bottom" />
                                                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                                        </asp:Calendar>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="width: 2539px">
                                                    </td>
                                                    <td style="width: 369px">
                                                    </td>
                                                    <td style="width: 4229px">
                                                    </td>
                                                    <td style="width: 2640px">
                                                    </td>
                                                    <td style="width: 249px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 6140px; height: 24px" valign="middle">
                                                        <asp:Label ID="Label3" runat="server" Text="Fecha Final"></asp:Label>:</td>
                                                    <td style="width: 1996px; height: 24px">
                                                        <asp:TextBox ID="txtFechaFinal" runat="server" Width="129px"></asp:TextBox><cc1:CalendarExtender
                                                            ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFinal">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td style="height: 24px">
                                                        <asp:ImageButton ID="ibMostrarCalendarioFinal" runat="server" Height="16px" ImageUrl="~/BlueSkin/Icons/2011/Activo-16.png"
                                                            OnClick="ibMostrarCalendarioFinal_Click1" Width="16px" Visible="false" /></td>
                                                    <td style="width: 2539px; height: 24px">
                                                        <asp:Label ID="Label4" runat="server" Text="Turno"></asp:Label>:</td>
                                                    <td style="width: 369px; height: 24px">
                                                        <asp:TextBox ID="txtTurno" runat="server"></asp:TextBox></td>
                                                    <td style="width: 4229px; height: 24px">
                                                        <asp:Label ID="Label5" runat="server" Text="Nombre Cliente"></asp:Label>:</td>
                                                    <td style="width: 2640px; height: 24px">
                                                        <asp:TextBox ID="txtNombreCliente" runat="server" Width="311px"></asp:TextBox></td>
                                                    <td style="width: 249px; height: 24px">
                                                        <asp:DropDownList ID="ddlComodin" runat="server">
                                                            <asp:ListItem Value="1">Inicien</asp:ListItem>
                                                            <asp:ListItem Value="2">Finalicen</asp:ListItem>
                                                            <asp:ListItem Value="3">Contengan</asp:ListItem>
                                                            <asp:ListItem Value="0">Iguales</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 6140px; height: 16px" valign="top">
                                                    </td>
                                                    <td style="width: 1996px; height: 16px">
                                                        <asp:Calendar ID="FechaFin" runat="server" BackColor="White" BorderColor="#999999"
                                                            CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                            ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="FechaFin_SelectionChanged"
                                                            Visible="False">
                                                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                                            <SelectorStyle BackColor="#CCCCCC" />
                                                            <WeekendDayStyle BackColor="#FFFFCC" />
                                                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                            <OtherMonthDayStyle ForeColor="Gray" />
                                                            <NextPrevStyle VerticalAlign="Bottom" />
                                                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                                        </asp:Calendar>
                                                    </td>
                                                    <td style="height: 16px">
                                                    </td>
                                                    <td style="width: 2539px; height: 16px">
                                                    </td>
                                                    <td style="width: 369px; height: 16px">
                                                    </td>
                                                    <td style="width: 4229px; height: 16px">
                                                    </td>
                                                    <td style="width: 2640px; height: 16px">
                                                    </td>
                                                    <td style="width: 249px; height: 16px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 6140px; height: 16px" valign="top">
                                                    </td>
                                                    <td style="width: 1996px; height: 16px">
                                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMultiAsDataTable"
                                                            TypeName="Servipunto.Estacion.Libreria.ConsultaCanastillaGrilla">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="FiltrosDeBusqueda1" DefaultValue="NULL" Name="selectFilter"
                                                                    PropertyName="Filtro" Type="Object" />
                                                                <asp:ControlParameter ControlID="FiltrosDeBusqueda1" DefaultValue="0" Name="maxNumberOfItemsToReturn"
                                                                    PropertyName="Total" Type="Int64" />
                                                                <asp:ControlParameter ControlID="FiltrosDeBusqueda1" DefaultValue="NULL" Name="sortClauses"
                                                                    PropertyName="Orden" Type="Object" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                    <td style="height: 16px">
                                                    </td>
                                                    <td style="width: 2539px; height: 16px">
                                                    </td>
                                                    <td style="width: 369px; height: 16px">
                                                    </td>
                                                    <td style="width: 4229px; height: 16px">
                                                    </td>
                                                    <td style="width: 2640px; height: 16px">
                                                    </td>
                                                    <td style="width: 249px; height: 16px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="8" style="height: 16px">
                                                        <uc1:FiltrosDeBusqueda ID="FiltrosDeBusqueda1" runat="server" />
                                                    </td>
                                                </tr>
                                                <asp:GridView ID="grdFacturas" CssClass="Grilla" RowStyle-CssClass="FilaNormal" AlternatingRowStyle-CssClass="FilaAlternada"
                                                    HeaderStyle-CssClass="Cabeza" HeaderStyle-HorizontalAlign="Center" runat="server"
                                                    AutoGenerateColumns="false" DataKeyNames="Prefijo,Consecutivo" OnRowCommand="grdFacturas_RowCommand"
                                                    OnDataBinding="grdFacturas_DataBinding" DataSourceID="ObjectDataSource1" AllowPaging="True"
                                                    AllowSorting="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPrefijoFacturacion" runat="server" Text='<%# Bind("Prefijo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblConsecutivo" runat="server" Text='<%# Bind("Consecutivo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCod_cli" runat="server" Text='<%# Bind("codcli") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubtotal" runat="server" Text='<%# Bind("Subtotal") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalIva" runat="server" Text='<%# Bind("TotalIva") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTurno" runat="server" Text='<%# Bind("NumTurn") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgVer" ImageUrl="~/BlueSkin/Icons/2011/Busqueda- 32.png" runat="server"
                                                                    CommandName="Ver" CommandArgument='<%#Bind("Consecutivo")%>' />
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="FooterGrilla" />
                                                            <ItemStyle CssClass="td_c" />
                                                            <HeaderStyle CssClass="CabeceraColumna" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgAsignar" ImageUrl="~/BlueSkin/Icons/2011/Clientes16.png"
                                                                    runat="server" CommandName="Asignar" CommandArgument='<%#Bind("Consecutivo")%>' />
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="FooterGrilla" />
                                                            <ItemStyle CssClass="td_c" />
                                                            <HeaderStyle CssClass="CabeceraColumna" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgAnular" ImageUrl="~/BlueSkin/Icons/2011/Inactivo-16.png"
                                                                    runat="server" CommandName="Anular" CommandArgument='<%#Bind("Consecutivo")%>' />
                                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="ImgAnular"
                                                                    ConfirmText="Esta seguro de eliminar lo seleccionado?">
                                                                </cc1:ConfirmButtonExtender>
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="FooterGrilla" />
                                                            <ItemStyle CssClass="td_c" />
                                                            <HeaderStyle CssClass="CabeceraColumna" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgImprimir" ImageUrl="~/BlueSkin/Icons/2011/TiqueteDeVenta16.png"
                                                                    runat="server" CommandName="Imprimir" CommandArgument='<%#Bind("Consecutivo")%>' />
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="FooterGrilla" />
                                                            <ItemStyle CssClass="td_c" />
                                                            <HeaderStyle CssClass="CabeceraColumna" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </table>
                                            <p>
                                                &nbsp;</p>
                                        </asp:Panel>
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
