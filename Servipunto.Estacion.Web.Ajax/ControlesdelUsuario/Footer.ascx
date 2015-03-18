<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Footer.ascx.cs" Inherits="Servipunto.Estacion.Web.Ajax.ControlesdelUsuario.Footer" %>
<div style="clear: both; height: 55px; border: solido 1px black; background-color: #666666; margin-bottom: 0px;">
    <table style="width: 100%; height: 55px;">
        <tr style="height: 5px" >
            <td style="font-size:9px; text-align: center; color:#ffffff;">
            
                <asp:Label ID="lblVersion" runat="server" Text="Copyright 2012 Zencillo De Software S.A.S. Todos los Derechos Reservados. Administrativo 2012 Versión"></asp:Label>
                <asp:Label ID="lblNumVersion" runat="server" Text="7.0.00 NG"></asp:Label>
                <asp:Label ID="lblAVisoLegal" runat="server" Text="[Aviso Legal] [Privacidad]"></asp:Label>
            </td>
        </tr>
       
        <tr style="height: 5px">
            <td style="height: 2px; text-align: center; font-size: 9px; color:#ffffff;">
            
                    <asp:HyperLink ID="hipServipunto" runat="server" NavigateUrl="http://www.servipunto.com" ForeColor="White">Zencillo de Software S.A.S.</asp:HyperLink>
                    <a class="Link2" href="http://www.servipunto.com/" id="lnkServipunto"></a>&nbsp;&nbsp;<asp:Label
                        ID="lblDerechos" runat="server" Height="13px" Text="Todos los Derechos Reservados."></asp:Label>
            </td>
        </tr>
    </table>
</div>
