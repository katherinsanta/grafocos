<%@ Page Language="c#" Codebehind="FiltroRecaudo.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroRecaudo" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../BlueSkin/UserControls/FiltrosDeBusqueda.ascx" TagName="FiltrosDeBusqueda"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
   <script type="text/javascript">
  function VentanaEmergente()
    {
        var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=Cliente',window,'dialogWidth:700px;dialogHeight:450px;resizable:no;center:yes');
        var txtIdenficacion = document.getElementById('<%=txtCodigoCliente.ClientID%>');
        if(resultado != null)
        {
            var arreglo = resultado.split('©');
            txtIdenficacion.value = arreglo[0];
        }
        
    }  
    </script>
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
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtCodigoCliente" runat="server"></asp:TextBox>
                                <input id="Button1" onclick="VentanaEmergente()" title="Buscar clientes" type="button"
                                    value="..." /></a></td>
                                <td>
                                    <asp:CheckBox ID="cbTodos" runat="server" Checked="True" AutoPostBack="True" Text="All">
                                    </asp:CheckBox>
                                    <td valign="top">
                                        <asp:Label ID="Label2" runat="server" Text="Tipo de Reporte"></asp:Label>:</td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="TipoReporte" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="Detallado">Detallado</asp:ListItem>
                                            <asp:ListItem Value="Resumido" Selected="True">Resumido</asp:ListItem>
                                        </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Automotor"></asp:Label>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAutomotor" runat="server"></asp:TextBox>
                            </td>
                            <td valign="top">
                                <asp:CheckBox ID="cbTodosAutomotores" runat="server" Text="All" AutoPostBack="True"
                                    Checked="True"></asp:CheckBox></td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label4" runat="server" Text="Financiera"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtFinanciera" runat="server"></asp:TextBox></td>
                            <td valign="top">
                                <asp:CheckBox ID="cbTodasFinancieras" runat="server" Text="All" AutoPostBack="True"
                                    Checked="True"></asp:CheckBox></td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Inicial"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaInicio" Visible="false" runat="server" BackColor="White" BorderColor="#999999"
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
                            <td valign="top">
                            </td>
                            <td valign="top">
                                <asp:Label ID="Label6" runat="server" Text="Fecha Final"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                            </td>
                            <td>  <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server"  TargetControlID="txtFechaFin">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaFin" runat="server" Visible="false" Width="200px" BackColor="White" BorderColor="#999999"
                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="180px">
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
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label7" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a href="ReportesRecaudo.aspx">
                                        <asp:Label ID="Label8" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
