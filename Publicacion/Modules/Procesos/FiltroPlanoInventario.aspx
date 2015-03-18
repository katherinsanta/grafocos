<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroPlanoInventario.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.FiltroPlanoInventario" 
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
                    <asp:Label ID="lblReporte" runat="server"> Generar Archivo de Inventarios</asp:Label></td>
            </tr>
            <tr>
                <td bgcolor="#fefbff">
                    <!-- Developer Custom Code -->
                    <table cellspacing="1" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>:<br />
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox></td>
                            <td style="width: 210px">
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MM-yyyy" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                                <asp:Calendar ID="FechaInicio" runat="server" Visible="false"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                            </td>
                            <td style="width: 210px">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" Text="No. Isla"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtIsla" runat="server" Width="32px">1</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" Text="No. Turno"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtTurno" runat="server" Width="32px">1</asp:TextBox>
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
                                    <asp:LinkButton ID="lblGuardarFacturas" runat="server">Crear Plano Inventarios |</asp:LinkButton>&nbsp;
                                    <a style="color: blue" href="ProcesosEstandar.aspx">
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
