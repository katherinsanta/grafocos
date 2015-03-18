<%@ Page Language="c#" Codebehind="FiltroCuposClientes.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Reportes.FiltroCuposClientes" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
    <asp:Panel ID="pnlForm" Visible="true" runat="server" Width="408px">
        <table cellspacing="1" cellpadding="5" width="90%" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee" style="width: 522px">
                    <asp:Label ID="lblReporte" runat="server"><b>Cupos de Clientes</b></asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff" style="width: 522px">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" border="0" style="width: 116%">
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>:</td>
                            <td valign="middle">
                                <asp:TextBox ID="txtCodigoCliente" runat="server" Enabled="False"></asp:TextBox><a
                                    onclick="Evaluar_check('SubFiltroCodigoCliente.aspx','cbTodos','txtCodigoCliente')"
                                    href="#"><u></u> 
                                <input id="Button1" onclick="VentanaEmergente()" title="Buscar clientes" type="button"
                                    value="..." /></a></td>
                            <td valign="middle">
                                <asp:CheckBox ID="cbTodos" runat="server" Checked="True" AutoPostBack="True" Text="All"
                                    Visible="False"></asp:CheckBox></td>
                        </tr>
                        <tr>
                            <td valign="middle" style="height: 21px">
                                <asp:Label ID="Label2" runat="server" Text="Filtrar por"></asp:Label>:</td>
                            <td valign="middle" colspan="2" style="height: 21px">
                                <asp:DropDownList ID="ddlTipo" runat="server">
                                    <asp:ListItem Value="-1">Todos Los Cupos</asp:ListItem>
                                    <asp:ListItem Value="0">Clientes que Han Usado el Cupo</asp:ListItem>
                                    <asp:ListItem Value="1">Clientes que NO Han Usado el Cupo</asp:ListItem>
                                    <asp:ListItem Value="2">Clientes Con Todo El Cupo Consumido</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>:</td>
                            <td valign="middle" colspan="2">
                                <asp:DropDownList ID="ddlOrden" runat="server">
                                    <asp:ListItem Value="pdf" Selected="True">pdf</asp:ListItem>
                                    <asp:ListItem Value="xls">xls</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br>
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                        <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label></asp:LinkButton>
                                    | <a href="ReportesClientes.aspx">
                                        <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
