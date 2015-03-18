<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroPrepagos.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion.FiltroPrepagos"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
     <script type="text/javascript">
  function VentanaEmergente()
    {
        var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=Cliente',window,'dialogWidth:700px;dialogHeight:450px;resizable:no;center:yes');
        var txtIdenficacion = document.getElementById('<%=txtCodigoCliente.ClientID%>');
        var txtNombreRazonSocial =  document.getElementById('<%=txtNombreCliente.ClientID%>');
        if(resultado != null)
        {
            var arreglo = resultado.split('©');
            txtIdenficacion.value = arreglo[0];
            txtNombreRazonSocial.value = arreglo[1];  
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
                            <td style="width: 64px; height: 15px" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>:</td>
                            <td style="width: 154px; height: 15px">
                                <asp:TextBox ID="txtCodigoCliente" runat="server"></asp:TextBox>&nbsp;<a onclick="Evaluar_check('SubFiltroCodigoCliente.aspx','ctl00$ContenidoMaestro1$cbTodos','ctl00$ContenidoMaestro1$txtCodigoCliente');"
                                    href="#"><u></u> </a>
                                <input onclick="VentanaEmergente()" title="Buscar clientes" type="button" value="..." id="Button1" />
                                <td style="width: 82px">
                                <asp:Label ID="Label4" runat="server" Text="Formato"></asp:Label></td>
                                    <td style="width: 84px; height: 15px" valign="top">
                                <asp:RadioButtonList ID="rbFormato" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 64px; height: 15px" valign="top">
                                Nombre:</td>
                            <td style="width: 154px; height: 15px">
                                <asp:TextBox ID="txtNombreCliente" runat="server" Width="290px"></asp:TextBox></td>
                            <td style="width: 82px">
                                Estado:</td>
                            <td style="width: 84px; height: 15px" valign="top">
                                <asp:DropDownList ID="ddlEstado" runat="server" Width="149px">
                                    <asp:ListItem Value="-1">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Disponible</asp:ListItem>
                                    <asp:ListItem Value="2">Asignado</asp:ListItem>
                                    <asp:ListItem Value="3">Utilizado</asp:ListItem>
                                    <asp:ListItem Value="4">Anulado</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 64px" valign="top">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Inicial"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td style="width: 154px">
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaInicio" runat="server" BackColor="White" BorderColor="#999999"
                                    Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                            <td style="width: 82px" valign="top">
                                <asp:Label ID="Label6" runat="server" Text="Fecha Final"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaFin" runat="server" Width="200px" BackColor="White" BorderColor="#999999"
                                    Visible="false" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="Black" Height="180px">
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
                                <div align="right" style="text-align: center">
                                    <asp:RadioButton ID="RadioButton1" runat="server" />
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label7" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a  href="/Modules/Prepagos/default.aspx">
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
