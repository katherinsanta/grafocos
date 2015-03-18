<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FiltroVentasSAP.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.Procesos.FiltroVentasSAP" 
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
                    <asp:Label ID="lblReporte" runat="server">Generar Archivo Plano de Ventas para SAP</asp:Label></td>
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
                                <asp:TextBox ID="txtSeparador" Visible="False" runat="server" Width="24px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" Text="No. Isla"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtNum_Isl" runat="server" Width="24px">1</asp:TextBox><asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNum_Isl"
                                    ValidationExpression="\d+" ErrorMessage="Valor numerico!"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNum_Isl" ErrorMessage="Valor vacio!"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" Text="No. Turno"></asp:Label>:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtNum_Tur" runat="server" Width="24px">1</asp:TextBox><asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNum_Tur"
                                    ValidationExpression="\d+" ErrorMessage="Valor numerico!"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNum_Tur" ErrorMessage="Valor vacio!"></asp:RequiredFieldValidator></td>
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
                                    <a style="color: blue" href="ProcesosSAP.aspx">
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
