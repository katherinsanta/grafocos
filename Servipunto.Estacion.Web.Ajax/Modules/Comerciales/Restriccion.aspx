<%@ Page Language="c#" Codebehind="Restriccion.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.Comerciales.Restriccion"
    ValidateRequest="false" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="350" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lblGuardar" runat="server">Guardar</asp:LinkButton>&nbsp; &nbsp;<asp:HyperLink
                                                                        ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" border="0">
                                                            <tr id="filaEmpleado" runat="server">
                                                                <td style="height: 28px">
                                                                    <asp:Label ID="Label1" runat="server" Text="Placa del Automor"></asp:Label>:</td>
                                                                <td style="height: 28px">
                                                                    <asp:Label ID="lblPlaca" runat="server" Width="120px" Font-Bold="True"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 28px">
                                                                    <asp:Label ID="Label2" runat="server" Text="Día"></asp:Label>:</td>
                                                                <td style="height: 28px">
                                                                    <asp:DropDownList ID="cboDia" runat="server" Width="120px">
                                                                        <asp:ListItem Value="7" Selected="True">Lunes - Viernes</asp:ListItem>
                                                                        <asp:ListItem Value="0">Domingo</asp:ListItem>
                                                                        <asp:ListItem Value="1">Lunes</asp:ListItem>
                                                                        <asp:ListItem Value="2">Martes</asp:ListItem>
                                                                        <asp:ListItem Value="3">Miercoles</asp:ListItem>
                                                                        <asp:ListItem Value="4">Jueves</asp:ListItem>
                                                                        <asp:ListItem Value="5">Viernes</asp:ListItem>
                                                                        <asp:ListItem Value="6">Sabado</asp:ListItem>
                                                                        <asp:ListItem Value="8">Todos los d&#237;as</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 48px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Hora Inicio"></asp:Label>:</td>
                                                                <td style="height: 48px" align="center">
                                                                    <p>
                                                                        <asp:DropDownList ID="cboHoraInicio" runat="server" Width="46px">
                                                                            <asp:ListItem Value="0" Selected="True">00</asp:ListItem>
                                                                            <asp:ListItem Value="1">01</asp:ListItem>
                                                                            <asp:ListItem Value="2">02</asp:ListItem>
                                                                            <asp:ListItem Value="3">03</asp:ListItem>
                                                                            <asp:ListItem Value="4">04</asp:ListItem>
                                                                            <asp:ListItem Value="5">05</asp:ListItem>
                                                                            <asp:ListItem Value="6">06</asp:ListItem>
                                                                            <asp:ListItem Value="7">07</asp:ListItem>
                                                                            <asp:ListItem Value="8">08</asp:ListItem>
                                                                            <asp:ListItem Value="9">09</asp:ListItem>
                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                        </asp:DropDownList>:
                                                                        <asp:TextBox ID="cboMinutoInicio" runat="server" Width="20px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalido!"
                                                                            ControlToValidate="cboMinutoInicio" ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Hora Fin"></asp:Label>:</td>
                                                                <td>
                                                                    <p align="center">
                                                                        <asp:DropDownList ID="cboHoraFin" runat="server" Width="46px">
                                                                            <asp:ListItem Value="0" Selected="True">00</asp:ListItem>
                                                                            <asp:ListItem Value="1">01</asp:ListItem>
                                                                            <asp:ListItem Value="2">02</asp:ListItem>
                                                                            <asp:ListItem Value="3">03</asp:ListItem>
                                                                            <asp:ListItem Value="4">04</asp:ListItem>
                                                                            <asp:ListItem Value="5">05</asp:ListItem>
                                                                            <asp:ListItem Value="6">06</asp:ListItem>
                                                                            <asp:ListItem Value="7">07</asp:ListItem>
                                                                            <asp:ListItem Value="8">08</asp:ListItem>
                                                                            <asp:ListItem Value="9">09</asp:ListItem>
                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                        </asp:DropDownList>:
                                                                        <asp:TextBox ID="cboMinutoFin" runat="server" Width="20px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalido!"
                                                                            ControlToValidate="cboMinutoFin" ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 22px">
                                                                </td>
                                                                <td style="height: 22px">
                                                                    <asp:TextBox ID="txtLlaveCompuesta" runat="server" Width="16px" MaxLength="16" Visible="False"></asp:TextBox></td>
                                                            </tr>
                                                            <tr id="filaPlaca" runat="server">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;
                                                                    <asp:Label ID="lblHide" runat="server"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <p>
                                            &nbsp;</p>
                                    </td>
                                </tr>
                            </table>
                            <!-- End Topic Content -->
                        </td>
                        <!-- End Topic Body -->
                    </tr>
                </table>
            </td>
        </tr>
        <!-- End Page Body -->
    </table>
</asp:Content>
