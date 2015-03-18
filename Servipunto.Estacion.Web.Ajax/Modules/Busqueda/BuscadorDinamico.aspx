<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscadorDinamico.aspx.cs" Inherits="Servipunto.Cartera.Web.Modules.Busqueda.BuscadorDinamico"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
        <base target =_self></base>
        <title>Busqueda avanzada - Zencillo Automatización de Islas</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link href="../../BlueSkin/NS.css" type="text/css" rel="stylesheet"/>
    <link href="../../Estilos/Estilo1/Estilo1.css" rel="stylesheet" type="text/css" />
		<script src="../../BlueSkin/NS.js" type="text/javascript"></script>				
		
    <script  type="text/javascript" language="JavaScript">
    var caracter = window.Event ? true : false;
    function ValidarNumero(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || (key>= 48 && key <= 57));
    }
    
    function CalcularValorFinal()
    {        
        var numeroInicial = parseInt(window.document.getElementById('txtNumeroInicial').getAttribute("value"));
        var catidad  =  parseInt(window.document.getElementById('txtCantidad').getAttribute("value"));        
        if(numeroInicial > 0 && catidad > 0)
            window.document.MyForm.txtNumeroFinal.value = numeroInicial + catidad - 1;    
        else 
            window.document.MyForm.txtNumeroFinal.value = "Ninguno";
    }
    </script>
		
</head>

<body bottomMargin="0" bgColor="ghostwhite" leftMargin="0" topMargin="0" rightMargin="0">
  <form id="MyForm" runat="server">
      <div style="text-align: center">
          &nbsp;
    <table cellpadding="1" cellspacing="1" class="Tabla2Panel" >
        <tr>
            <td align="left" class="Titulo" colspan="0" valign="middle">
                            <asp:Label ID="lblTitulo" runat="server">Busqueda dinamica</asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td>
                <table border="0" cellpadding="0" style="width: 100%; height: 5%;">
                    <tr>
                        <td colspan="5" height="1">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 1px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100px; height: 23px">
                            <asp:Label ID="lblDatoABuscar" runat="server" Text="Dato a buscar:" Width="96px"></asp:Label></td>
                                    <td style="width: 100px; height: 23px">
                                        <asp:TextBox ID="txtDatoABuscar" runat="server"></asp:TextBox></td>
                                    <td style="width: 100px; height: 23px">
                            <asp:DropDownList ID="ddlCriterioBusqueda" runat="server" Width="127px">
                            </asp:DropDownList></td>
                                    <td style="width: 100px; height: 23px">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Label ID="Label1" runat="server" Text="Palabras que:" Width="108px"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="ddlComodin" runat="server" Width="127px" ToolTip="Define el lugar donde se buscara coincidencias del dato a buscar.">
                                            <asp:ListItem>Inicien</asp:ListItem>
                                            <asp:ListItem>Finalicen</asp:ListItem>
                                            <asp:ListItem Value="Contengan">Contengan</asp:ListItem>
                                            <asp:ListItem>Iguales</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td align="center" style="width: 100px">
                                        <table>
                                            <tr>
                                                <td align="right" style="width: 100px">
                                                    <asp:LinkButton ID="lnkAnterior" runat="server" OnClick="lnkAnterior_Click"><<</asp:LinkButton></td>
                                                <td align="left" style="width: 100px">
                                                    &nbsp;<asp:LinkButton ID="lnkSiguiente" runat="server" OnClick="lnkSiguiente_Click">>></asp:LinkButton></td>
                                                <td style="width: 100px">
                                                    <asp:Label ID="lblTotalPaginas" runat="server" ForeColor="Blue" Text="Pag. 0/0" Width="74px"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5" rowspan="4" >
                            <asp:DataGrid CssClass="Grilla" ID="grdResultadoBusqueda"
                             runat="server" AllowPaging="True"
                             CellPadding="1" 
                             OnPageIndexChanged="grdResultadoBusqueda_PageIndexChanged"
                             PageSize="20" ToolTip="Resultado de la busqueda"
                             Width="100%"
                             AllowSorting="True"
                             OnItemCommand="grdResultadoBusqueda_ItemCommand"
                             OnSortCommand="grdResultadoBusqueda_SortCommand"
                             ItemStyle-CssClass="FilaNormal" HeaderStyle-CssClass="Cabeza"
                             AlternatingItemStyle-CssClass="FilaAlternada"
                             SelectedItemStyle-CssClass="FilaSeleccionada" >
                                <Columns>
                                    <asp:ButtonColumn CommandName="Seleccionar" HeaderText="Seleccionar" Text="Seleccionar">
                                    </asp:ButtonColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
               <asp:TextBox ID="txtBusquedaDesignada" runat="server" Width="20px" Visible="False"></asp:TextBox></td>
        </tr>
    </table>
      </div>
    </form>
	</body>
</html>
