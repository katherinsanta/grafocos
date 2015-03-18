<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroCierreMesColvanes.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.ReportesEstacion.FiltroCierreMesColvanes"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>&nbsp;</p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="Label2" runat="server">Reporte Clientes</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td bgcolor="#eeeeee" style="width: 490px; height: 2px">
                                <asp:Label ID="lblReporte" runat="server">Cierre Mes  </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#fefbff" style="width: 490px; height: 43px">
                                <!-- Developer Custom Code -->
                                <table cellpadding="5" cellspacing="1" border="0">
                                    <!--<tr>
								<td valign="top">Hora:</td>
								<td>
									<asp:DropDownList id="cboHora" runat="server" Width="169px">
										<asp:ListItem Value="24" Selected="True">(Todas las Horas)</asp:ListItem>
										<asp:ListItem Value="0">12 a.m.</asp:ListItem>
										<asp:ListItem Value="1">1 a.m.</asp:ListItem>
										<asp:ListItem Value="2 ">2 a.m.</asp:ListItem>
										<asp:ListItem Value="3">3 a.m.</asp:ListItem>
										<asp:ListItem Value="4">4 a.m.</asp:ListItem>
										<asp:ListItem Value="5">5 a.m.</asp:ListItem>
										<asp:ListItem Value="6">6 a.m.</asp:ListItem>
										<asp:ListItem Value="7">7 a.m.</asp:ListItem>
										<asp:ListItem Value="8">8 a.m.</asp:ListItem>
										<asp:ListItem Value="9">9 a.m.</asp:ListItem>
										<asp:ListItem Value="10">10 a.m.</asp:ListItem>
										<asp:ListItem Value="11">11 a.m.</asp:ListItem>
										<asp:ListItem Value="12">12 p.m.</asp:ListItem>
										<asp:ListItem Value="13">1 p.m.</asp:ListItem>
										<asp:ListItem Value="14">2 p.m.</asp:ListItem>
										<asp:ListItem Value="15">3 p.m.</asp:ListItem>
										<asp:ListItem Value="16">4 p.m.</asp:ListItem>
										<asp:ListItem Value="17">5 p.m.</asp:ListItem>
										<asp:ListItem Value="18">6 p.m.</asp:ListItem>
										<asp:ListItem Value="19">7 p.m.</asp:ListItem>
										<asp:ListItem Value="20">8 p.m.</asp:ListItem>
										<asp:ListItem Value="21">9 p.m.</asp:ListItem>
										<asp:ListItem Value="22">10 p.m.</asp:ListItem>
										<asp:ListItem Value="23">11p.m.</asp:ListItem>
									</asp:DropDownList></td>
								<td valign="top">Tipo de Reporte:</td>
								<td>
									<asp:RadioButtonList id="TipoReporte" runat="server" RepeatDirection="Horizontal">
										<asp:ListItem Value="Detallado">Detallado</asp:ListItem>
										<asp:ListItem Value="Resumido" Selected="True">Resumido</asp:ListItem>
									</asp:RadioButtonList>
								</td>
							</tr>-->
                                    <tr>
                                        <td valign="top" style="width: 262px; height: 29px">
                                            Fecha Inicial:</td>
                                        <td style="width: 214px; height: 29px">
                                            &nbsp;Fecha Final:</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 262px; height: 29px" valign="top">
                                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
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
                                        <td style="width: 214px; height: 29px">
                                            <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999"
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
                                </table>
                                <!-- End Developer Custom Code -->
                                <table cellspacing="0" cellpadding="5" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <div align="right">
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                                    <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                                 <a href="ReportesClientes.aspx">
                                                    <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
        </table>
    </asp:Panel>
</asp:Content>
