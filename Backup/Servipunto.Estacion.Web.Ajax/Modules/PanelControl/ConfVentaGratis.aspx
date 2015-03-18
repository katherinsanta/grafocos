<%@ Page Language="c#" Codebehind="ConfVentaGratis.aspx.cs" AutoEventWireup="true"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.ConfVentaGratis" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table cellspacing="0" style="margin-left: 5%; height: 100%" cellpadding="0" width="80%"
        border="0">
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                <asp:Panel ID="pnlForm" Visible="true" runat="server">
                    <table width="100%" style="border: solid 1px #917D82">
                        <tr style="background-color:#917D82">
                            <td colspan="2">
                                <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                            <td colspan="2" align="right">
                                <asp:LinkButton ID="lblGuardar" runat="server">Guardar</asp:LinkButton>&nbsp;
                                <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" valign="middle">
                                <asp:Label ID="Label1" runat="server" Text="Parámetros Generales"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%">
                                <asp:Label ID="Label2" runat="server" Text="Tipo Alarma"></asp:Label>:</td>
                            <td width="25%">
                                <asp:DropDownList ID="ddlTipoAlarma" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="1" Selected="True">Sirena</asp:ListItem>
                                    <asp:ListItem Value="2">Archivo Audio</asp:ListItem>
                                </asp:DropDownList></td>
                            <td width="25%">
                                <asp:TextBox ID="txtRutaArchivoAudio" runat="server" Visible="False" Width="8px"></asp:TextBox></td>
                            <td width="25%">
                                <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="25%">
                                <asp:Label ID="Label3" runat="server" Text="Frecuencia"></asp:Label>:</td>
                            <td width="25%">
                                <asp:TextBox ID="txtFrecuencia" runat="server" Width="90%"></asp:TextBox></td>
                            <td width="25%">
                                <asp:Label ID="Label4" runat="server" Text="Acumulado"></asp:Label>:</td>
                            <td width="25%">
                                <asp:TextBox ID="txtAcumulado" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Puerto"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlPuerto" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="F.P. Sorteo"></asp:Label>:</td>
                            <td>
                                <asp:ListBox ID="lstCodForPagConf" runat="server" SelectionMode="Multiple"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Tiempo Duración"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlTiempoAlarma" runat="server">
                                    <asp:ListItem Value="5">5 Seg.</asp:ListItem>
                                    <asp:ListItem Value="10">10 Seg.</asp:ListItem>
                                    <asp:ListItem Value="15">15 Seg.</asp:ListItem>
                                    <asp:ListItem Value="20">20 Seg.</asp:ListItem>
                                    <asp:ListItem Value="25">25 Seg.</asp:ListItem>
                                    <asp:ListItem Value="30">30 Seg.</asp:ListItem>
                                    <asp:ListItem Value="35">35 Seg.</asp:ListItem>
                                    <asp:ListItem Value="40">40 Seg.</asp:ListItem>
                                    <asp:ListItem Value="45">45 Seg.</asp:ListItem>
                                    <asp:ListItem Value="50">50 Seg.</asp:ListItem>
                                    <asp:ListItem Value="55">55 Seg.</asp:ListItem>
                                    <asp:ListItem Value="60">60 Seg.</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Porcentaje"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtPorcentaje" runat="server" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" valign="middle">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1505, Servipunto.Estacion.Web.Global.Idioma)%>'></asp:Label></b></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Estado"></asp:Label>:</td>
                            <td>
                                <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">Activo</asp:ListItem>
                                    <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text=" F.P. Ventas"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlCodForPagConf" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Tipo Automotor"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlTipoAutomotor" runat="server">
                                </asp:DropDownList></td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Articulo"></asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlArticulos" runat="server" Width="120px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Valor Minimo"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtvalorMinimo" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="Valor Máximo"></asp:Label>:</td>
                            <td>
                                <asp:TextBox ID="txtValorMaximo" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr valign="middle" align="center">
                            <td colspan="2">
                                <asp:Label ID="Label16" runat="server" Text="Fecha Inicial"></asp:Label>:</td>
                            <td colspan="2">
                                <asp:Label ID="Label17" runat="server" Text="Fecha Final"></asp:Label>:</td>
                        </tr>
                        <tr valign="middle" align="center">
                            <td colspan="2">
                                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
                                <asp:Calendar ID="cldFecInicial" runat="server" Visible="false"></asp:Calendar>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicial">
                                </cc1:CalendarExtender>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
                                <asp:Calendar ID="cldFecFinal" runat="server" Visible="false"></asp:Calendar>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFinal">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr valign="middle" align="center">
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="Hora Inicial"></asp:Label>:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHorInicial" runat="server">
                                    <asp:ListItem Value="24" Selected="True">(Ninguna)</asp:ListItem>
                                    <asp:ListItem Value="0">12 a.m.</asp:ListItem>
                                    <asp:ListItem Value="1">1 a.m.</asp:ListItem>
                                    <asp:ListItem Value="2 ">2 a.m.</asp:ListItem>
                                    <asp:ListItem Value="3">3 a.m.</asp:ListItem>
                                    <asp:ListItem Value="4">4 a.m.</asp:ListItem>
                                    <asp:ListItem Value="5">5 a.m.</asp:ListItem>
                                    <asp:ListItem Value="6">6 a.m.</asp:ListItem>
                                    <asp:ListItem Value="7">7 a.m.</asp:ListItem>
                                    <asp:ListItem Value="8">8 a.m.</asp:ListItem>
                                    <asp:ListItem Value="9">9 a.m.</asp:ListItem>
                                    <asp:ListItem Value="10">10 a.m.</asp:ListItem>
                                    <asp:ListItem Value="11">11 a.m.</asp:ListItem>
                                    <asp:ListItem Value="12">12 p.m.</asp:ListItem>
                                    <asp:ListItem Value="13">1 p.m.</asp:ListItem>
                                    <asp:ListItem Value="14">2 p.m.</asp:ListItem>
                                    <asp:ListItem Value="15">3 p.m.</asp:ListItem>
                                    <asp:ListItem Value="16">4 p.m.</asp:ListItem>
                                    <asp:ListItem Value="17">5 p.m.</asp:ListItem>
                                    <asp:ListItem Value="18">6 p.m.</asp:ListItem>
                                    <asp:ListItem Value="19">7 p.m.</asp:ListItem>
                                    <asp:ListItem Value="20">8 p.m.</asp:ListItem>
                                    <asp:ListItem Value="21">9 p.m.</asp:ListItem>
                                    <asp:ListItem Value="22">10 p.m.</asp:ListItem>
                                    <asp:ListItem Value="23">11 p.m.</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="Hora Final"></asp:Label>:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHorFinal" runat="server">
                                    <asp:ListItem Value="24" Selected="True">(Ninguna)</asp:ListItem>
                                    <asp:ListItem Value="0">12 a.m.</asp:ListItem>
                                    <asp:ListItem Value="1">1 a.m.</asp:ListItem>
                                    <asp:ListItem Value="2 ">2 a.m.</asp:ListItem>
                                    <asp:ListItem Value="3">3 a.m.</asp:ListItem>
                                    <asp:ListItem Value="4">4 a.m.</asp:ListItem>
                                    <asp:ListItem Value="5">5 a.m.</asp:ListItem>
                                    <asp:ListItem Value="6">6 a.m.</asp:ListItem>
                                    <asp:ListItem Value="7">7 a.m.</asp:ListItem>
                                    <asp:ListItem Value="8">8 a.m.</asp:ListItem>
                                    <asp:ListItem Value="9">9 a.m.</asp:ListItem>
                                    <asp:ListItem Value="10">10 a.m.</asp:ListItem>
                                    <asp:ListItem Value="11">11 a.m.</asp:ListItem>
                                    <asp:ListItem Value="12">12 p.m.</asp:ListItem>
                                    <asp:ListItem Value="13">1 p.m.</asp:ListItem>
                                    <asp:ListItem Value="14">2 p.m.</asp:ListItem>
                                    <asp:ListItem Value="15">3 p.m.</asp:ListItem>
                                    <asp:ListItem Value="16">4 p.m.</asp:ListItem>
                                    <asp:ListItem Value="17">5 p.m.</asp:ListItem>
                                    <asp:ListItem Value="18">6 p.m.</asp:ListItem>
                                    <asp:ListItem Value="19">7 p.m.</asp:ListItem>
                                    <asp:ListItem Value="20">8 p.m.</asp:ListItem>
                                    <asp:ListItem Value="21">9 p.m.</asp:ListItem>
                                    <asp:ListItem Value="22">10 p.m.</asp:ListItem>
                                    <asp:ListItem Value="23">11 p.m.</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
