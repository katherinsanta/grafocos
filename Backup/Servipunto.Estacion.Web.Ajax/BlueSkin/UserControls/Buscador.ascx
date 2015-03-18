<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Buscador.ascx.cs" Inherits="Servipunto.Cartera.Web.BlueSkin.UserControls.Buscador" %>
<link href="../../BlueSkin/estilos.css" rel="stylesheet" type="text/css" />
<table cellpadding="1" cellspacing="1" width="350px" border="0" >
    <tr>
        <td>
        <div class="cajapanelcontrol">
            <table cellpadding="0" cellspacing="0" border="0" class="RoundedPanel" width="98%">
                <tr>
                    <td style="width: 100px">
            <asp:TextBox ID="txtConceptoaBuscar" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnBuscarConcepto" runat="server"  Text="Buscar" /></td>
                    <td style="width: 100px">
                        <asp:HyperLink ID="hlnkActivarPopup" runat="server" Text="Buscar..."></asp:HyperLink></td>
                </tr>
            </table>
        </div>
        </td>
    </tr>
    <tr>
        <td >
            
            <table cellpadding="0" cellspacing="0" width="100%" border="0" class="RoundedPanel">
            <tr>
            <td align="center"><p class="TituloPanelControl"">Buscador Dinámico<asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
            </p>
            </td>
            </tr>
            </table>
            </td>
    </tr>
    <tr>
        <td >
        <div class="cajapanelcontrol">
            <table cellpadding="0" cellspacing="0" width="100%" border="0" class="RoundedPanel">
                <tr>
                    <td width="25%" >
                        <asp:Label ID="lblDatoABuscar" runat="server" Text="Dato a buscar:" Width="96px"></asp:Label></td>
                    <td width="25%" >
                        <asp:TextBox ID="txtDatoABuscar" runat="server"></asp:TextBox></td>
                    <td width="25%" >
                        <asp:DropDownList ID="ddlCriterioBusqueda" runat="server" Width="127px">
                        </asp:DropDownList></td>
                    <td width="25%" >
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" /></td>
                </tr>
                <tr>
                    <td style="height: 22px" >
                        <asp:Label ID="Label1" runat="server" Text="Palabras que:" Width="108px"></asp:Label></td>
                    <td style="height: 22px" >
                        <asp:DropDownList ID="ddlComodin" runat="server" ToolTip="Define el lugar donde se buscara coincidencias del dato a buscar."
                            Width="127px">
                            <asp:ListItem>Inicien</asp:ListItem>
                            <asp:ListItem>Finalicen</asp:ListItem>
                            <asp:ListItem Value="Contengan">Contengan</asp:ListItem>
                            <asp:ListItem>Iguales</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="height: 22px" >
                    </td>
                    <td style="height: 22px" >
                    </td>
                </tr>
            </table>
        </div>
        </td>
    </tr>
    <tr>
        <td>
        
            <asp:GridView ID="grdBusqueda" runat="server">
            </asp:GridView>  
 </td>
    </tr>
    <tr>
        <td >
            <asp:Label ID="lblCampoVisible1" runat="server"></asp:Label>
            <asp:Label ID="lblCampoVisible2" runat="server"></asp:Label>
            <asp:Label ID="lblCampoVisible3" runat="server"></asp:Label>
            <asp:Label ID="lblCampoVisible4" runat="server"></asp:Label>
            
            <asp:Label ID="lblCampoInVisible1" runat="server"></asp:Label>
            <asp:Label ID="lblCampoInVisible2" runat="server"></asp:Label>
            <asp:Label ID="lblCampoInVisible3" runat="server"></asp:Label>
            <asp:Label ID="lblCampoInVisible4" runat="server"></asp:Label>
            <asp:Label ID="lblNoColumnas" runat="server"></asp:Label>
            
        </td>
    </tr>
</table>
