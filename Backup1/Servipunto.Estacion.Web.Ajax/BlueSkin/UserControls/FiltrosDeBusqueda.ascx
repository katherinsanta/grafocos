<%@ Control Language="C#" AutoEventWireup="true" Codebehind="FiltrosDeBusqueda.ascx.cs"
    Inherits="Servipunto.Cartera.Web.BlueSkin.UserControls.FiltrosDeBusqueda" %>
<link href="../Estilos/Estilo1/Estilo1.css"rel="stylesheet" type="text/css" />
<table cellpadding="0" cellspacing="0" class="controlespecial" width="100%">
    <tr align="center">
        <td width="15%" style="height: 38px">
            <asp:Label ID="Label2" runat="server" Text="Listado de datos..." Width="95%"></asp:Label></td>
        <td width="15%" style="height: 38px">
            <asp:Label ID="Label3" runat="server" Text="Registros por Página: " Width="95%"></asp:Label></td>
        <td width="15%" style="height: 38px">
            <asp:TextBox ID="txtTotalRegistrosPorPagina" runat="server" Width="95%" ToolTip="Define el total de registros a consultar, valor vacio o cero (0) para retornar todos los valores.">10</asp:TextBox>
        </td>
        <td width="15%" style="height: 38px">
            <asp:Label ID="Label1" runat="server" Text="Total Registros:" Width="95%"></asp:Label></td>
        <td width="15%" style="height: 38px">
            <asp:TextBox ID="txtTotalRegistros" runat="server" Width="95%" ToolTip="Define el total de registros a consultar, valor vacio o cero (0) para retornar todos los valores.">100</asp:TextBox>
        </td>
        <td width="15%" style="height: 38px">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                Visible="False" Width="95%">
                <asp:ListItem Selected="True">Digitados</asp:ListItem>
                <asp:ListItem>Todos</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td width="10%" style="height: 38px">
            <asp:ImageButton ID="lnkConsultar" runat="server" ImageUrl="~/BlueSkin/Icons/2011/Busqueda- 32.png"
                ToolTip="Actualiza la consulta" OnClick="lnkConsultar_Click"></asp:ImageButton>
        </td>
    </tr>
</table>
