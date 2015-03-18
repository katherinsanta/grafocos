<%@ Control Language="C#" AutoEventWireup="true" Codebehind="header.ascx.cs" Inherits="Servipunto.Estacion.Web.Ajax.ControlesdelUsuario.header" %>
<div style="width: 100%; height: 133px;">
    <table style="width: 100%; height: 75px;" class="CabezaLogo" cellpadding="0px" cellspacing="0px"
        border="0px">
        <tr>
            <td class="baner" style="width: 20%; height: 61px;">
                <asp:Image BorderStyle="None" ID="imgLogoCompania" runat="server" ImageUrl="~/BlueSkin/Update/Logoen.png"
                    Height="59" />
            </td>
            <td class="baner" valign="top" align="right" style="height: 83px; width: 80%; text-align: right;">
                <img id="ImagenBanner" src="../../BlueSkin/Update/banner.png" height="83px;" style="margin-right: 0px"
                    width="820px;">
            </td>
        </tr>
        <tr style="width: 100%; height: 14px;" class="Usuario">
            <td colspan="2" style="text-align: right">
                <asp:Label ID="lblFecha" ForeColor="silver" Font-Size="9px" runat="server"></asp:Label>
                <asp:Label ID="lblRol" ForeColor="silver" runat="server"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr style="width: 24px; height: 27px;">
            <!--PANEL DE CONTROL SUPERIOR -->
            <td colspan="2" style="border: 0px; height: 27px;" class="pestanas">
                <div style="float: left; width: 80%">
                    <table cellpadding="0" cellspacing="0" style="border-bottom: solid 1px #000000; border-top: solid 1px #000000;"
                        border="0">
                        <tr style="height: 24px;">
                            <!-- Hiperlink Home -->
                            <td style="width: 20px;">
                                <img id="Img7" style="margin-left: 4px;" src="../../BlueSkin/Update/home-16.png">
                            </td>
                            <td style="width: 100px;">
                                <a class="Link1" href="../Main/Default.aspx">Pagina Principal</a>
                            </td>
                            <td style="width: 4px;">
                                <img id="Img1" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <!-- Hiperlink Panel De Control -->
                            <td style="width: 20px;">
                                <img id="Img6" style="margin-left: 4px;" src="../../BlueSkin/Update/panelDeControl.png">
                            </td>
                            <td style="width: 100px;">
                                <a class="Link1" href="../PanelControl/Default.aspx">Panel De Control</a>
                            </td>
                            <td style="width: 4px;">
                                <img id="Img2" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <td style="width: 20px;" align="left">
                                <img id="Img8" style="margin-left: 4px;" src="../../BlueSkin/Update/Comerciales.png">
                            </td>
                            <!-- Hiperlink Reportes -->
                            <td style="width: 90px;">
                                <a class="Link1" href="../Comerciales/Default.aspx">Comerciales</a>
                            </td>
                            <td style="width: 4px;">
                                <img id="Img3" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <td style="width: 20px;">
                                <img id="Img9" style="margin-left: 4px;" src="../../BlueSkin/Update/Reportes.png">
                            </td>
                            <!-- Hiperlink Procesos -->
                            <td style="width: 90px;">
                                <a class="Link1" href="../ReportesEstacion/Default.aspx">Reportes</a>
                            </td>
                            <td style="width: 4px;">
                                <img id="Img4" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <td style="width: 20px;">
                                <img id="Img10" style="margin-left: 4px;" src="../../BlueSkin/Update/Procesos.png">
                            </td>
                            <!-- Hiperlink Comerciales -->
                            <td style="width: 90px;">
                                <a class="Link1" href="../Procesos/Default.aspx">Procesos</a>
                            </td>
                            <td style="width: 4px;">
                                <img id="Img5" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <!-- Hiperlink Variaciones-->
                            <td style="width: 20px;">
                                <img id="Img11" style="margin-left: 4px;" src="../../BlueSkin/Update/Variaciones.png">
                            </td>
                            <td style="width: 90px;">
                                <a class="Link1" href="../Variaciones/Default.aspx">Variaciones </a>
                            </td>
                            <td style="width: 4px;">
                                <img id="Img14" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <!-- Hiperlink Prepagos-->
                            <td style="width: 20px;">
                                <img id="Img12" style="margin-left: 4px;" src="../../BlueSkin/Update/prepago-16.png">
                            </td>
                            <td style="width: 90px;">
                                <a class="Link1" href="../Prepagos/default.aspx">Prepagos </a>
                            </td>
                            <td style="width: 4px;">
                                <img id="Img15" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <!-- Hiperlink Consultas-->
                            <td style="width: 20px;">
                                <img id="Img13" style="margin-left: 4px;" src="../../BlueSkin/Update/consultas-16.png">
                            </td>
                            <td style="width: 90px;">
                                <a class="Link1" href="../Consultas/default.aspx">Consultas </a>
                            </td>
                            <td align="right" style="width: 100px;">
                                <a href="" class="Link1">
                                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                </a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: right; height: 29px; width: 20%">
                    <table cellpadding="0px"cellspacing="0px" style="border-bottom: solid 1px #000000; width: 100%; height: 100%; border-top: solid 1px #000000;"
                        border="0">
                        <tr>
                            <!-- contrasena-->
                            <td align="right" style="width: 20px;">
                                <img style="margin-left: 4px;" src="../../BlueSkin/Update/contraseña-16.png" />
                            </td>
                            <td align="left" style="width: 90px;">
                                <a href="../Main/CambiarContrasena.aspx" class="Link1">Contraseña </a>
                            </td>
                            <!-- Cerrar sesion-->
                            <td style="width: 4px;">
                                <img id="Img16" src="../../BlueSkin/Update/separadorPestana.gif">
                            </td>
                            <td align="right" style="width: 20px;">
                                <img style="margin-left: 4px;" src="../../BlueSkin/Update/iniciar-sesion-16.png" />
                            </td>
                            <td align="left" style="width: 100px;">
                                <a href="" class="Link1">&nbsp;</a><asp:LinkButton ID="LnkCerrar" CssClass="Link1"
                                    runat="server" Text="Cerrar Sesión" OnClick="LnkCerrar_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>
