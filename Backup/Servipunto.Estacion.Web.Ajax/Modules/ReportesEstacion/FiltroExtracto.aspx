<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra/actualizacion.Master"
CodeBehind="FiltroExtracto.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion.FiltroExtracto" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="prueba" ContentPlaceHolderID="ContenidoMaestro1" runat="server">

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
                <asp:Label ID="lblError" Visible="false" ForeColor="Red" runat="server"></asp:Label>&nbsp;</p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="90%" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Extracto de Clientes</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>:</td>
                            <td>
                            
                            <asp:TextBox ID="txtCodigoCliente" runat="server"></asp:TextBox>&nbsp;<a onclick="Evaluar_check('SubFiltroCodigoCliente.aspx','ctl00$ContenidoMaestro1$cbTodos','ctl00$ContenidoMaestro1$txtCodigoCliente');"
                                    href="#"><u></u> </a>
                                <input id="Button1" onclick="VentanaEmergente()" title="Buscar clientes" type="button"
                                    value="..." />
                                <td style="width: 82px" >
                                <asp:CheckBox ID="cbTodos" runat="server" Width="107px" Text="Todos los clientes" AutoPostBack="True"
                                    Checked="True"></asp:CheckBox></td>
                            <td valign="top" style="width: 211px">
                                </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Automotor"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtAutomotor" runat="server" Width="160px"></asp:TextBox></td>
                            <td valign="top">
                                <asp:CheckBox ID="cbTodosAutomotores" runat="server" Checked="True" AutoPostBack="True"
                                    Text="Todos lo automotores"></asp:CheckBox></td>
                            <td valign="top" style="width: 211px">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Forma de Pago"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlFormaPago" runat="server" Width="160px">
                                </asp:DropDownList></td>
                            <td valign="top">
                                <asp:Label ID="Label4" runat="server" Text="Formato"></asp:Label></td>
                            <td valign="top" style="width: 211px">
                                <asp:RadioButtonList ID="rbFormato" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label5" runat="server" Text="Nivel de Detalle"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlNivelDetalle" runat="server" Width="160px">
                                    <asp:ListItem Value="-1" Selected="True"> Seleccione </asp:ListItem>
                                    <asp:ListItem Value="1">Bajo</asp:ListItem>
                                    <asp:ListItem Value="2">Medio</asp:ListItem>
                                    <asp:ListItem Value="3">Alto</asp:ListItem>
                                    <asp:ListItem Value="4">Clasico</asp:ListItem>
                                    <asp:ListItem Value="5">Detallado</asp:ListItem>
                                </asp:DropDownList></td>
                            <td valign="top">
                                    <asp:CheckBox ID="chkDetalle" runat="server" Text="Especifico" /></td>
                            <td valign="top" style="width: 211px">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label6" runat="server" Text="Fecha Inicial"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Calendar ID="FechaInicio" runat="server" BackColor="White" BorderColor="#999999"
                                    Visible="False" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                            <td valign="top">
                                <asp:Label ID="Label7" runat="server" Text="Fecha Final"></asp:Label>:
                                <br />
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                            <td valign="top" style="width: 211px">
                                <asp:Calendar ID="FechaFin" runat="server" BackColor="White" BorderColor="#999999"
                                    Visible="False" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label88" runat="server" Text="Hora Inicial (hh:mm):"></asp:Label></td>
                            <td>
                                &nbsp;<asp:DropDownList ID="ddlHoraInicio" runat="server" Width="59px">
                                </asp:DropDownList>&nbsp;
                                <asp:DropDownList ID="ddlMinutosInicio" runat="server" Width="59px">
                                </asp:DropDownList></td>
                            <td valign="top">
                                <asp:Label ID="Label10" runat="server" Text="Hora Final (hh:mm):"></asp:Label></td>
                            <td style="width: 211px" valign="top">
                                <asp:DropDownList ID="ddlHoraFinal" runat="server" Width="59px">
                                </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlMinutosFinal" runat="server" Width="59px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="height: 49px">
                                <div align="right">
                                    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label8" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a href="ReportesCreditoDirecto.aspx">
                                        <asp:Label ID="Label9" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
