<%@ Page Language="c#" Codebehind="FiltroAuditoriaError.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroAuditoriaError" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br>
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Titulo del Reporte</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="width: 118px; height: 22px" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Aplicativo"></asp:Label>:</td>
                            <td style="width: 163px; height: 22px">
                                <asp:DropDownList ID="cboAplicacion" runat="server" Width="160px">
                                    <asp:ListItem Value="2" Selected="True">Administrativo</asp:ListItem>
                                    <asp:ListItem Value="1">Estacion</asp:ListItem>
                                    <asp:ListItem Value="7">Capturador Virtual</asp:ListItem>
                                    <asp:ListItem Value="8">Mantenimiento</asp:ListItem>
                                    <asp:ListItem Value="0">Todos</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 112px; height: 22px" valign="top">
                                <asp:Label ID="lblArticulo" runat="server">Tipo de error:</asp:Label></td>
                            <td style="height: 22px">
                                <asp:DropDownList ID="cboTipoError" runat="server" Width="160px">
                                    <asp:ListItem Value="0" Selected="True">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Base de datos</asp:ListItem>
                                    <asp:ListItem Value="2">.Net</asp:ListItem>
                                    <asp:ListItem Value="3">Dispositivo</asp:ListItem>
                                    <asp:ListItem Value="4">Socket</asp:ListItem>
                                    <asp:ListItem Value="5">Otro</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 118px; height: 33px" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Ordenar por"></asp:Label>:</td>
                            <td style="width: 163px; height: 33px">
                                <asp:DropDownList ID="cboOrdenar" runat="server" Width="160px">
                                    <asp:ListItem Value="e.fecha" Selected="True">Fecha</asp:ListItem>
                                    <asp:ListItem Value="p.aplicativo">Aplicativo</asp:ListItem>
                                    <asp:ListItem Value="tp.tipoError">Tipo de Error</asp:ListItem>
                                    <asp:ListItem Value="e.detallePersonal">Descripcion</asp:ListItem>
                                    <asp:ListItem Value="e.detalleDebug">Debug</asp:ListItem>
                                    <asp:ListItem Value="a.Descripcion">Posible Suceso</asp:ListItem>
                                    <asp:ListItem Value="s.idresponsable">Posible responsable</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 112px; height: 33px" valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label></td>
                            <td style="height: 33px">
                                <asp:RadioButtonList ID="rbFormato" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 118px" valign="top">
                                <asp:Label ID="Label4" runat="server" Text="Fecha Inicial"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td style="width: 163px">
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaInicio" runat="server" Visible="false" BackColor="White" BorderColor="#999999"
                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="180px" Width="200px">
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                </asp:Calendar>
                            </td>
                            <td style="width: 112px" valign="top">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Final"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender2"  Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaFin" Visible="false" runat="server" BackColor="White" BorderColor="#999999"
                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="180px" Width="200px">
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 118px" valign="top">
                                <asp:Label ID="Label6" runat="server" Text="Hora Inicial"></asp:Label>:</td>
                            <td style="width: 163px">
                                <asp:DropDownList ID="cboHoraInicial" runat="server" Width="56px">
                                </asp:DropDownList>
                                <asp:DropDownList ID="cboMinutoInicial" runat="server" Width="56px">
                                </asp:DropDownList></td>
                            <td style="width: 112px" valign="top">
                                <asp:Label ID="Label7" runat="server" Text="Hora Final"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="cboHoraFinal" runat="server" Width="56px">
                                </asp:DropDownList>
                                <asp:DropDownList ID="cboMinutoFinal" runat="server" Width="56px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 118px" valign="top">
                            </td>
                            <td style="width: 163px">
                            </td>
                            <td style="width: 112px" valign="top">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 118px" valign="top">
                                <p>
                                    <em>
                                        <asp:Label ID="Label8" runat="server" Text="Que contenga en"></asp:Label>:</em></p>
                            </td>
                            <td style="width: 163px">
                            </td>
                            <td style="width: 112px" valign="top">
                                <p>
                                    <strong></strong>&nbsp;</p>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 118px" valign="top">
                                <asp:Label ID="Label9" runat="server" Text="Descripción"></asp:Label>:</td>
                            <td style="width: 163px">
                                <asp:TextBox ID="txtDetallePersonal" runat="server" Width="160px"></asp:TextBox></td>
                            <td style="width: 112px" valign="top">
                                <asp:Label ID="Label10" runat="server" Text="Detalle Debug"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtDetalleDebug" runat="server" Width="160px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 118px" valign="top">
                                <asp:Label ID="Label11" runat="server" Text="Posible suceso que genero el error"></asp:Label>:</td>
                            <td style="width: 163px">
                                <asp:TextBox ID="txtPosibleSuceso" runat="server" Width="160px"></asp:TextBox></td>
                            <td style="width: 112px" valign="top">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label12" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="ReportesAuditoria.aspx">
                                        <asp:Label ID="Label13" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
