<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroMaestroTerceros.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.FiltroMaestroTerceros"
     MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
        <table cellspacing="1" cellpadding="5" width="650" align="center" bgcolor="#5482fc"
            border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server">Generar Archivo Plano Maestro de Terceros</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Fecha Inicial"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox><cc1:CalendarExtender
                                    ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaInicio" runat="server" Visible="false"></asp:Calendar>
                            </td>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Fecha Final"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>                                
                                <cc1:CalendarExtender ID="CalendarExtender2"  Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaFin" runat="server" Visible="false"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Separador"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtSeparador" runat="server" Width="32px">|</asp:TextBox></td>
                            <td>
                            </td>
                            <td>
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
                                    <a style="color: blue" onclick="document.forms[0].submit();" href="#">
                                        <asp:Label ID="Label4" runat="server" Text="Crear Archivo"></asp:Label>
                                    </a>| <a style="color: blue" href="ProcesosEstandar.aspx">
                                        <asp:Label ID="Label5" runat="server" Text="Cerrar"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
