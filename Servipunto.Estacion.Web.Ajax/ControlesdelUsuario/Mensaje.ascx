<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensaje.ascx.cs" Inherits="Servipunto.ReconversionTarija.Web.ControlesDeUsuario.Mensaje" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../Estilos/Estilo1/Estilo1.css" rel="stylesheet" type="text/css" />
<cc1:ModalPopupExtender ID="mpeMensaje" runat="server" BackgroundCssClass="modalBackground"
    TargetControlID="pnlPopup" PopupControlID="pnlPopup">
</cc1:ModalPopupExtender>

<cc1:DragPanelExtender ID="dpePnlPopup" runat="server" TargetControlID="pnlPopup" >
</cc1:DragPanelExtender>
<asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none;"   >
    <table cellpadding="1" cellspacing="1" class="TablaPopup">
        <tr style="background-color:#909396;" >
            <td colspan="2" align="left" runat="server" id="tdCaption">
                <asp:Label ID="lblCaption" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="20">
        <td colspan="2"></td>
        </tr>
        <tr>
            <td style="width: 60px" valign="middle" align="center">
                <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Estilos/Estilo1/Imagenes/Info-48x48.png" />
            </td>
            <td valign="middle" align="left">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr height="20">
        <td colspan="2"></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
            <asp:ImageButton ID="ImgAceptar" runat="server" ImageUrl="~/BlueSkin/Icons/2011/Activo-48.png"
            OnClick="ImgAceptar_Click" />
            <asp:Button ID="btnOk1" runat="server" Text="Ok1" OnClick="btnOk1_Click" Visible="false" />
            </td>
        </tr>
    </table>
</asp:Panel>

<script type="text/javascript">
        function fnClickOK(sender, e)
        {
            __doPostBack(sender,e);
        }
</script>