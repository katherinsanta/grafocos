<%@ Page Language="c#" Codebehind="Permisos.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl.Permisos"
    MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
<!-- FUNCION PARA MARCAR Y DESMARCAR LOS PERMISOS -->
    <script language="javascript">

        function SetStatus(status){
				var aElements = document.forms[0].getElementsByTagName("input");

				for (var i = 0; i < aElements.length; i++)
				{
					var obj = aElements[i];
					if (obj.type=='checkbox')
						obj.checked = status;
				}
			}
    </script>

    <table style="height: 100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <!-- Page Body -->
        <tr>
            <td valign="top" height="100%">
                <table style="height: 100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" width="100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px">
                                        <br />
                                        <table id="Superior" width="100%">
                                            <tr>
                                                <td class="ActionsHeader" align="right">
                                                    <asp:LinkButton ID="lbAsignarTodosLosPermisos" CssClass="LinkTbla" runat="server">
                                                        <asp:Label ID="Label1" runat="server" Text="Otorgar Todos los Permisos"></asp:Label></asp:LinkButton>|
                                                    <asp:LinkButton ID="lbQuitarTodosLosPermisos" CssClass="LinkTbla" runat="server">
                                                        <asp:Label ID="Label2" runat="server" Text="Quitar Todos los Permisos"></asp:Label></asp:LinkButton><a
                                                            style="color: blue" href="Default.aspx"></a></td>
                                            </tr>
                                        </table>
                                        <p>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></p>
                                        <input id="SubmitSource" type="hidden" name="SubmitSource" runat="server" />
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" width="430" border="0">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" CssClass="LinkTbla" runat="server">
                                                                        <asp:Label ID="Label6" runat="server" Text="Volver"></asp:Label></asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left">
                                                        <table cellpadding="4" border="0">
                                                            <tr>
                                                                <td style="height: 16px">
                                                                    <asp:Label ID="Label3" runat="server" Text="Módulo:"></asp:Label></td>
                                                                <td style="height: 16px">
                                                                    <asp:DropDownList ID="cboModulos" runat="server" AutoPostBack="True" Width="248px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Opción:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboOpciones" runat="server" AutoPostBack="True" Width="248px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="Label5" runat="server" Text="Acciones:"></asp:Label></td>
                                                                <td align="right">
                                                                    <a class="LinkTbla" href="javascript:SetStatus(true);">
                                                                        <asp:Label ID="Label7" runat="server" Text="Seleccionar Todo"></asp:Label></a>
                                                                    &nbsp;|&nbsp; <a class="LinkTbla" href="javascript:SetStatus(false);">
                                                                        <asp:Label ID="Label8" runat="server" Text="Desmarcar Todo"></asp:Label></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    &nbsp;</td>
                                                                <td width="340">
                                                                    <asp:CheckBoxList ID="chkAcciones" runat="server">
                                                                    </asp:CheckBoxList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                                                    <input visible="false" class="Button" id="AcceptButton" type="submit" value="Guardar"
                                                                        name="AcceptButton" runat="server" />
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False" Text=""></asp:Label>
                                                                </td>
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
    </table>
    <!-- End Page Body -->
</asp:Content>
