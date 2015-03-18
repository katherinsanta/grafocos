<%@ Page Language="c#" Codebehind="FiltroAuditoriaUsuario.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroAuditoriaUsuario" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                            <td style="width: 78px; height: 22px" valign="top">
                                <asp:Label ID="lblArticulo" runat="server">Aplicativo:</asp:Label></td>
                            <td style="width: 137px; height: 22px">
                                <asp:DropDownList ID="cboAplicacion" runat="server" Width="160px">
                                    <asp:ListItem Value="2" Selected="True">Administrativo</asp:ListItem>
                                    <asp:ListItem Value="1">Estacion</asp:ListItem>
                                    <asp:ListItem Value="7">Capturador Virtual</asp:ListItem>
                                    <asp:ListItem Value="8">Mantenimiento</asp:ListItem>
                                    <asp:ListItem Value="0">Todos</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 84px; height: 22px" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Tipo de Reporte"></asp:Label>:</td>
                            <td style="height: 22px">
                                <asp:RadioButtonList ID="TipoReporte" runat="server" Width="200px">
                                    <asp:ListItem Value="1" Selected="True">Solo Aplicativo</asp:ListItem>
                                    <asp:ListItem Value="2">Aplicativo y Base de Datos</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 78px; height: 33px" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Ordenar por"></asp:Label>:</td>
                            <td style="width: 137px; height: 33px">
                                <asp:DropDownList ID="cboOrdenar" runat="server" Width="160px">
                                    <asp:ListItem Value="s.fecha" Selected="True">Fecha</asp:ListItem>
                                    <asp:ListItem Value="p.aplicativo">Aplicativo</asp:ListItem>
                                    <asp:ListItem Value="s.idresponsable">Responsable</asp:ListItem>
                                    <asp:ListItem Value="s.tipoResponsable">Tipo de Responsable</asp:ListItem>
                                    <asp:ListItem Value="m.modulo">Modulo</asp:ListItem>
                                    <asp:ListItem Value="o.opcion">Opcion</asp:ListItem>
                                    <asp:ListItem Value="a.accion">Accion</asp:ListItem>
                                    <asp:ListItem Value="ra.descripcion">Descripcion</asp:ListItem>
                                    <asp:ListItem Value="tb.tabla">Tabla</asp:ListItem>
                                    <asp:ListItem Value="ev.evento">Evento</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 84px; height: 33px" valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label></td>
                            <td style="height: 33px">
                                <asp:RadioButtonList ID="rbFormato" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 78px" valign="top">
                                <asp:Label ID="Label4" runat="server" Text="Fecha Inicial"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td style="width: 137px">
                                <cc1:CalendarExtender ID="CalendarExtender1"  Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
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
                            <td style="width: 84px" valign="top">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Final"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
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
                            <td style="width: 78px" valign="top">
                                <asp:Label ID="Label6" runat="server" Text="Hora Inicial"></asp:Label>:</td>
                            <td style="width: 137px">
                                <asp:DropDownList ID="cboHoraInicial" runat="server" Width="56px">
                                </asp:DropDownList>:
                                <asp:DropDownList ID="cboMinutoInicial" runat="server" Width="56px">
                                </asp:DropDownList></td>
                            <td style="width: 84px" valign="top">
                                <asp:Label ID="Label7" runat="server" Text="Hora Final"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="cboHoraFinal" runat="server" Width="56px">
                                </asp:DropDownList>:
                                <asp:DropDownList ID="cboMinutoFinal" runat="server" Width="56px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 78px" valign="top">
                            </td>
                            <td style="width: 137px">
                            </td>
                            <td style="width: 84px" valign="top">
                                <asp:CheckBox ID="ckbAvanzado" runat="server" Text="Advanced" AutoPostBack="True"></asp:CheckBox></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <asp:Panel ID="PnlAvanzado" Visible="False" runat="server" Height="106px" BorderStyle="Groove">
                        <p>
                            <br>
                            &nbsp;<asp:Label ID="Label8" runat="server" Text="Responsable"></asp:Label>:&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtIdResponsable" runat="server"></asp:TextBox><asp:Label ID="Label9"
                                runat="server" Text="Tipo de Responsable"></asp:Label>: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="cboTipoResponsable" runat="server" Width="128px" Enabled="False">
                                <asp:ListItem Value="U" Selected="True">Usuario</asp:ListItem>
                                <asp:ListItem Value="E">Empleado</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkTipoResponsable" runat="server" AutoPostBack="True" Text="All"
                                Checked="True"></asp:CheckBox><br>
                            <br>
                            &nbsp;<asp:Label ID="Label10" runat="server" Text="Modulo"></asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="cboModulo" runat="server" Width="168px" Enabled="False">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkModulo" runat="server" AutoPostBack="True" Text="All" Checked="True">
                            </asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br>
                            <br>
                            &nbsp;<asp:Label ID="Label11" runat="server" Text="Opción"></asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="cboOpcion" runat="server" Width="128px" Enabled="False">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkOpcion" runat="server" AutoPostBack="True" Text="All" Checked="True">
                            </asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;<asp:Label ID="Label12" runat="server" Text="Accion"></asp:Label>:&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;
                            <asp:DropDownList ID="cboAccion" runat="server" Width="128px" Enabled="False">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkAccion" runat="server" AutoPostBack="True" Text="All" Checked="True">
                            </asp:CheckBox><br>
                            <br>
                            &nbsp;<asp:Label ID="Label13" runat="server" Text="Tabla"></asp:Label>:&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="cboTabla" runat="server" Width="128px" Enabled="False">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkTabla" runat="server" AutoPostBack="True" Text="All" Checked="True">
                            </asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label14" runat="server" Text="Evento"></asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="cboEvento" runat="server" Width="128px" Enabled="False">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkEvento" runat="server" AutoPostBack="True" Text="All" Checked="True">
                            </asp:CheckBox><br>
                            <br>
                        </p>
                    </asp:Panel>
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label15" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a href="ReportesAuditoria.aspx">
                                        <asp:Label ID="Label16" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
