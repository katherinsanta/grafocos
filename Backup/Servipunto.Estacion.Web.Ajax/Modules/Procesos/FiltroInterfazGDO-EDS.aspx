<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroInterfazGDO-EDS.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.FiltroInterfazGDO_EDS" 
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br>
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" Visible="false" ForeColor="Red" runat="server"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" align="center" bgcolor="#5482fc" border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Importación Archivo Novedades Recaudo GDO</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:Calendar ID="FechaInicio" runat="server"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 43px">
                                <asp:Label ID="Label2" runat="server" Text="Archivo"></asp:Label>:</td>
                            <td style="width: 210px; height: 43px">
                                <asp:Label ID="lblArchivo" runat="server" ForeColor="Red" Width="192px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>:</td>
                            <td style="width: 210px">
                                &nbsp;
                                <asp:Label ID="lblEstado" runat="server" ForeColor="Red" Width="192px"></asp:Label>
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
                                    <!--<A style="COLOR: blue" onclick="document.forms[0].submit();" href="#">
											Crear Plano Facturas</A>| -->
                                    <asp:LinkButton ID="lblImportarNovedades" runat="server">Importar Archivo Novedades |</asp:LinkButton>&nbsp;
                                    <a style="color: blue" href="InterfazRecaudoGDO.aspx">
                                        <asp:Label ID="Label4" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
