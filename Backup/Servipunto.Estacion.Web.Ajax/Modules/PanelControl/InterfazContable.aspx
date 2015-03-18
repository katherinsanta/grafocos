<%@ Page Language="c#" Codebehind="InterfazContable.aspx.cs" AutoEventWireup="false"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.InterfazContable" MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

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
                                        <br>
                                        <p>
                                            <font color="gray">
                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></font>
                                        </p>
                                        <table cellspacing="5" cellpadding="10" align="center" border="0">
                                            <tr>
                                                <!--interfaz contable  -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="ConfInterfazContableNew.aspx">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/BlueSkin/Icons/2011/GenerarArchivoPlano32.png"
                                                            OnClick="img1_Click" />
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="ConfInterfazContableNew.aspx">
                                                        <asp:Label ID="Label2" runat="server" Text="Label">
                                                        </asp:Label>
                                                    </a>
                                                    <p class="Descripcion">
                                                        Genera la interface contable
                                                    </p>
                                                </td>
                                                <!-- estructura de archivos planos -->
                                                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                                                    <a href="EstructuraPlano.aspx">
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/BlueSkin/Icons/2011/GenerarArchivoPlano32.png"
                                                            OnClick="img2_Click" />
                                                    </a>
                                                </td>
                                                <td valign="top" align="left" style="height: 52px; margin: 0px;" width="128px">
                                                    <a href="EstructuraPlano.aspx">
                                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>&nbsp; </a>
                                                    <p class="Descripcion">
                                                        Configure las estructuras de los archivos planos
                                                    </p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
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
</asp:Content>
