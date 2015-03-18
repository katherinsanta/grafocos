<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FiltroLogPlanilla.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion.FiltroLogPlanilla"MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <div>
        <style type="text/css">
            .ModalPopupBG
            {
                background-color: #666699;
                filter: alpha(opacity=50);
                opacity: 0.7;
            }
            
            .HellowWorldPopup
            {
                background: white;
                overflow: scroll;
            }
            div#AdjResultsDiv
            {
                width: 1300px;
                height: 201px;
                overflow: scroll;
                position: relative;
            }
            
            
            .style1
            {
                text-decoration: underline;
            }
        </style>
        <blockquote>
            <font class="NormalFont">
                <p>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label></p>
            </font>
        </blockquote>
        <asp:Panel ID="pnlForm" Visible="true" runat="server">
            <table cellspacing="1" cellpadding="5" align="center" bgcolor="#5482fc" border="0"
                style="width: 426px">
                <tr>
                    <td bgcolor="#eeeeee">
                        <asp:Label ID="lblReporte" runat="server">Titulo del Reporte</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#fefbff">
                        <!-- Developer Custom Code -->
                        <table cellspacing="1" cellpadding="5" width="100%" border="0">
                            <tr>
                                <td style="width: 110px" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha del Turno"> </asp:Label>:<br />
                                </td>
                                <td style="width: 79px" valign="top">
                                    <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
                                </td>
                                <caption>
                                    <br />
                                    <tr>
                                        <td style="width: 19px">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFechaInicial">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td style="width: 19px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </caption>
                            </tr>
                        </table>
                        <!-- End Developer Custom Code -->
                        <table cellspacing="0" cellpadding="5" width="100%" border="0">
                            <tr>
                                <td>
                                    <div align="right">
                                        <asp:LinkButton ID="lnkGenerar" runat="server" Text="Generar" 
                                            onclick="LinkButton1_Click"></asp:LinkButton>
                                        <a href="../procesos/planillascontables.aspx">
                                        <asp:Label ID="Label7" runat="server" Text="Cerrar"></asp:Label></a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
