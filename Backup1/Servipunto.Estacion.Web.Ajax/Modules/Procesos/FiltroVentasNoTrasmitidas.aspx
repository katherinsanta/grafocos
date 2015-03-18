<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroVentasNoTrasmitidas.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.FiltroVentasNoTrasmitidas"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <blockquote>
        <font class="NormalFont">
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
        </font>
    </blockquote>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table cellspacing="1" cellpadding="5" align="center" bgcolor="#5482fc" border="0">
            <tr>
                <td bgcolor="#eeeeee">
                    <asp:Label ID="lblReporte" runat="server"> Generar archivo de ventas no transmitidas</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Fecha Inicial"></asp:Label>:<br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaInicio" runat="server" Visible="false"></asp:Calendar>
                            </td>
                            <td style="width: 69px" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Fecha Final"></asp:Label>:<br />
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                            <td>
                                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaFin">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaFin" Visible="false" runat="server"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Separador"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtSeparador" runat="server" Width="40px">;</asp:TextBox></td>
                            <td style="width: 69px" valign="top">
                                <asp:Label ID="Label4" runat="server" Text="Guardar como Transmitidas"></asp:Label>?</td>
                            <td style="width: 210px">
                                <asp:RadioButtonList ID="rbnTransmitir" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td valign="top">
                            </td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtUltimoConsecutivo" runat="server" Visible="False" Width="16px"></asp:TextBox></td>
                            <td style="width: 69px">
                            </td>
                            <td style="width: 210px">
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
                                    <asp:LinkButton ID="lblGenerarArchivo" runat="server"> Generar Archivo Plano</asp:LinkButton>&nbsp;|
                                    <a style="color: blue" href="ProcesosEstandar.aspx">
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
