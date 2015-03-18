<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SubirArchivos.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.SubirArchivos" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" Visible="false" ForeColor="Red" runat="server"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" width="90%" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Adjuntar Archivos</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td style="width: 80%; height: 33px" valign="top">
                                <table id="Table1" cellspacing="5" cellpadding="0" width="300" border="0">
                                    <tr>
                                        <td>
                                            <div style="display: inline; width: 48px; height: 15px" ms_positioning="FlowLayout">
                                                <asp:Label ID="Label1" runat="server" Text="Archivo"></asp:Label>:</div>
                                        </td>
                                        <td>
                                            <input type="file" id="inputFile" name="inputFile" runat="server" /></td>
                                        <td>
                                            <asp:Button ID="btnadjuntar" runat="server" Text="Adjuntar"></asp:Button></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80%; height: 33px" valign="top">
                                <table class="ResultsTable" cellspacing="1" cellpadding="5" width="100%" border="0">
                                    <tr>
                                        <td id="SeccionResultados" runat="server" bgcolor="#ffffff" colspan="6">
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="Results" runat="server">
                                        <HeaderTemplate>
                                            <tr>
                                                <td class="ResultsHeader2" valign="middle">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(876, 1)%>'></asp:Label> </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="RowItem" valign="middle">
                                                    <%# Container.DataItem %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>
                                                <td bgcolor="White" align="center" valign="middle" colspan="6">
                                                    <%# DataBinder.Eval(Results.DataSource, "Count") %>
                                                    <%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2131, 1)%>
                                                </td>
                                            </tr>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <!-- End Developer Custom Code -->
                    <br />
                    <br />
                    <table cellspacing="0" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td>
                                <div align="right">
                                    <a style="color: blue" href="ImportarTablasGNV.aspx">
                                        <asp:Label ID="Label3" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
