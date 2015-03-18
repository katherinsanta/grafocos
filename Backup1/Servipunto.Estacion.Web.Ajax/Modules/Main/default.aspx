<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.Main._default"
    MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">

    <script language="javascript" type="text/javascript">

    </script>
<br />
    <table style="height: 100%; width: 100%">
        <tr style="height: 80px">
            <!--PANEL DE CONTROL-->
            <td valign="top" style="width: 5%;" align="center">
                <a href="../../Modules/PanelControl/Default.aspx" class="linkForm">
                    <img height="48" src="../../BlueSkin/Icons/2011/PanelDeControl.png" width="48" border="0"
                        alt="" id="IMG1" />&nbsp;<br />
                </a>
            </td>
            <td style="width: 20%;" valign="top">
                <a href="../../Modules/PanelControl/Default.aspx" class="linkForm">
                    <asp:Label ID="Label1" runat="server" Text="Panel de Control"></asp:Label>
                </a>
                <p class="Descripcion">
                    Configuracion general del sistema, parametrizacion de tablas y definicion de ploiticas
                    de seguridad
                </p>
            </td>
            <!--reportes -->
            <td valign="top" style="width: 5%">
                <a href="../ReportesEstacion/Default.aspx" class="linkForm">
                    <img height="48" src="../../BlueSkin/Icons/2011/Reportes.png" width="48" border="0"
                        alt="" /><br />
                </a>
            </td>
            <td style="width: 20%" valign="top">
                <a href="../ReportesEstacion/Default.aspx" class="linkForm">
                    <asp:Label ID="Label3" runat="server" Text="Reportes"></asp:Label>
                </a>
                <p class="Descripcion">
                    Informes detallados, estadisticas de gestion que permiten la toma de decisiones
                </p>
            </td>
            <!--COMERCIALES -->
            <td valign="top" style="width: 5%">
                <a href="../Comerciales/Default.aspx" class="linkForm">
                    <img height="48" src="../../BlueSkin/Icons/2011/Comerciales.png" width="48" border="0"
                        alt="" /><br />
                </a>
            </td>
            <td style="width: 20%" valign="top">
                <a href="../Comerciales/Default.aspx" class="linkForm">
                    <asp:Label ID="Label2" runat="server" Text="Comerciales"></asp:Label>
                </a>
                <p class="Descripcion">
                    Configuracion de datos comerciales de clientes y automotores
                </p>
            </td>
        </tr>
        <tr style="height: 80px">
            <!--PROCESOS -->
            <td valign="top" style="height: 50px; width: 5%;">
                <a href="../Procesos/Default.aspx" class="linkForm">
                    <img height="48" src="../../BlueSkin/Icons/2011/procesos-48.png" width="48" border="0"
                        alt="" /><br />
                </a>
            </td>
            <td style="width: 20%" valign="top">
                <a href="../Procesos/Default.aspx" class="linkForm">
                    <asp:Label ID="Label4" runat="server" Text="Procesos "></asp:Label>
                </a>
                <p class="Descripcion">
                    Importe y exporte archivos planos o sincronice su base de datos con una base de
                    datos externa
                </p>
            </td>
            <!--VARIACIONES -->
            <td valign="top" style="height: 50px; width: 5%;">
                <a href="../Variaciones/Default.aspx" class="linkForm">
                    <img height="48" src="../../BlueSkin/Icons/2011/Variaciones.png" width="48" border="0"
                        alt="" /><br />
                </a>
            </td>
            <td style="width: 20%" valign="top">
                <a href="../Variaciones/Default.aspx" class="linkForm">
                    <asp:Label ID="Label6" runat="server" Text="Variaciones "></asp:Label>
                </a>
                <p class="Descripcion">
                    Configuracion de datos para generar reporte de variacion de tanques o balance de
                    gas
                </p>
            </td>
            <!--PREPAGO -->
            <td valign="top" style="height: 50px; width: 5%;">
                <a href="../Prepagos/Default.aspx" class="linkForm">
                    <img height="48" src="../../BlueSkin/Icons/2011/Prepago.png" width="48" border="0"
                        alt="" /><br />
                </a>
            </td>
            <td style="width: 20%" valign="top">
                <a href="../Prepagos/Default.aspx" class="linkForm">
                    <asp:Label ID="Label7" runat="server" Text="Prepaid"></asp:Label>
                </a>
                <p class="Descripcion">
                    Configuracion de prepagos para asignar a los clientes
                </p>
            </td>
        </tr>
        <tr style="height: 80px">
            <!--CONSULTAS -->
            <td valign="top" style="height: 5%">
                <a href="../Consultas/default.aspx" class="linkForm">
                    <img height="48" src="../../BlueSkin/Icons/2011/Consultas.png" width="48" border="0"
                        alt="" /><br />
                </a>
            </td>
            <td style="width: 20%" valign="top">
                <a href="../Consultas/default.aspx" class="linkForm">
                    <asp:Label ID="Label5" runat="server" Text="Consultas"></asp:Label>
                </a>
                <p class="Descripcion">
                    Consulte la informacion de las facturas de canastilla
                </p>
            </td>
        </tr>
    </table>
    <uc1:Mensaje ID="Mensaje1" runat="server" />
</asp:Content>
