<%@ Page Language="c#" Codebehind="FiltroArchivos.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Reportes.FiltroArchivo" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <!-- Developer Custom Code -->
    <table class="ResultsTable" cellspacing="1" cellpadding="4" width="350" border="0">
        <tr>
            <td class="RowItem">
                Seleccione un Archivo:</td>
            <td class="RowItem">
                <input type="file" id="Archivo" name="Archivo"></td>
        </tr>
    </table>
    <!-- End Developer Custom Code -->
</asp:Content>