<%@ Page Language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Servipunto.Estacion.Comerciales._Default"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <!-- Custom Content -->
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label><br>
                                        <p>
                                            <font color="dimgray">
                                                <asp:Label ID="Label3" runat="server" Text="Las opciones de datos comerciales disponibles son las siguientes"></asp:Label>:</font></p>
                                        <table cellspacing="5" cellpadding="10" align="center" border="0">
                                            <tr>
                                            <!-- -->
                                            <!--CLIENTES -->
                                            <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="Clientes.aspx">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/BlueSkin/Icons/2011/Clientes.png"
                                                            OnClick="img1_Click" />
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height:52px; margin: 0px;" width="128px">
                                                    <a href="Clientes.aspx">
                                                        <asp:Label ID="Label1" runat="server" Text="Clientes"></asp:Label>
                                                    </a>
                                                    <p class="Descripcion" >Cree elimine o modifique sus clientes </p>
                                                </td>
                                                <!-- PRECIOS DIFERENCIALES-->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="ListaPreciosDiferenciales.aspx">
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/BlueSkin/Icons/2011/PreciosDiferenciales.png"
                                                            OnClick="img2_Click" />
                                                            </a>
                                                </td>
                                                
                                                <td valign="top" align="left" style="height:52px; margin: 0px;" width="128px">
                                                    <a href="ListaPreciosDiferenciales.aspx">
                                                        <asp:Label ID="Label2" runat="server" Text="Precios Diferenciales "></asp:Label>
                                                        </a>
                                                        <p class="Descripcion" >Configure Los Precios Diferenciales Para Surtidores Wayne </p>
                                                </td>
                                                <!--CONDUCTORES -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="Conductores.aspx">
                                                        <img alt="Conductores" src="../../BlueSkin/Icons/2011/Conductores.png" border="0">&nbsp;<br>
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height:52px; margin: 0px;" width="128px">
                                                    <a href="Conductores.aspx">
                                                        <asp:Label ID="Label4" runat="server" Text="Conductores"></asp:Label>
                                                    </a>
                                                    <p class="Descripcion" >Cree elimine o modifique Conductores </p>
                                                </td>
                                                <!--CLIENTE SUIC -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="ClienteSUIC.aspx">
                                                        <img alt="Conductores" src="../../BlueSkin/Icons/2011/ClienteSUIC48.png" border="0">&nbsp;<br>
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height:52px; margin: 0px;" width="128px">
                                                    <a href="ClienteSUIC.aspx">
                                                        <asp:Label ID="Label5" runat="server" Text="Cliente SIUC"></asp:Label>
                                                    </a>
                                                    <p class="Descripcion" >Asignar Cliente SUIC a Crédito</p>
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- End Custom Content -->
                                        <blockquote>
                                        </blockquote>
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
    </table>
</asp:Content>
