<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Asignacion.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.Prepagos.Asignacion"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../BlueSkin/UserControls/FiltrosDeBusqueda.ascx" TagName="FiltrosDeBusqueda"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">

    <script type="text/javascript">
  function VentanaEmergente()
    {
        var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=Cliente',window,'dialogWidth:700px;dialogHeight:450px;resizable:no;center:yes');
        var txtIdenficacion = document.getElementById('<%=txtIdentificacion.ClientID%>');
        var txtNombreRazonSocial =  document.getElementById('<%=txtNombreRazonSocial.ClientID%>');
        if(resultado != null)
        {
            var arreglo = resultado.split('©');
            txtIdenficacion.value = arreglo[0];
            txtNombreRazonSocial.value = arreglo[1];  
        }
        
    }  
    </script>

    <table cellpadding="0px" cellspacing="0px">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMensaje1" runat="server" CssClass="Mensaje" Text=""></asp:Label>
                        <!-- Page Body -->
                        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                            <table class="ResultsTable" cellspacing="" cellpadding="0" border="0" style="width: 100%;
                                padding-left: 0px; padding-top: 0px; background-color: White">
                                <tr style="width: 100%; height: 30px; background-color: #CCCCCC;">
                                    <td style="height: 15px; width: 499px;">
                                        <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label>
                                    </td>
                                    <td align="right" style="height: 15px; width: 680px;">
                                        <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ResultsItem" valign="middle" align="left" colspan=2 style="width: 97%; height: 85px;">
                                        <asp:Panel ID="Panel3" runat="server" Width="150px">
                                            <table border="0" class="border" cellpadding="0" cellspacing="0" style="width: 95%;">
                                                <tr>
                                                    <td rowspan="1" style="width: 900px; height: 2px" valign="top">
                                                        &nbsp;&nbsp;
                                                        <table cellpadding="1" cellspacing="1">
                                                            <tr class="titulo">
                                                                <td colspan="11" style="height: 8px" align="center">
                                                                    <asp:Label ID="Label3" runat="server"   Height="22px"
                                                                        Text="" Width="222px">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 25px;">
                                                                    <asp:Label ID="lblCcode" runat="server"   Height="22px"
                                                                        Text="" >
                                                                    </asp:Label></td>
                                                                <td style="width: 150px; height: 25px">
                                                                    <asp:TextBox ID="txtIdentificacion" runat="server" Font-Bold="True" Width="96%">
                                                                    </asp:TextBox></td>
                                                                <td style="height: 25px">
                                                                    <input onclick="VentanaEmergente()" type="button" value="..." title="Buscar clientes"
                                                                        id="Button1" /></td>
                                                                <td style="width: 100px; height: 25px;">
                                                                     <asp:Label ID="lblname" runat="server"   Height="22px"
                                                                        Text="" >
                                                                    </asp:Label></td>
                                                                <td style="width: 300px; height: 25px;">
                                                                    <asp:TextBox ID="txtNombreRazonSocial" runat="server" Font-Bold="True" Width="97%">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 26px; width: 50px;">
                                                                     <asp:Label ID="lblValue" runat="server"   Height="22px"
                                                                        Text="" >
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="height: 26px; width: 150;">
                                                                    <asp:TextBox ID="txtValor" runat="server" Font-Bold="True" Width="85%" AutoPostBack="True"
                                                                        OnTextChanged="txtValor_TextChanged">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td style="height: 26px; width: 100px;">
                                                                     <asp:Label ID="lblCantidad" runat="server"   Height="22px"
                                                                        Text="">
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="height: 26px" width="100px">
                                                                    <asp:TextBox ID="txtCantidad" runat="server" Font-Bold="True" ReadOnly="true" Width="95%"
                                                                        BackColor="#E0E0E0"></asp:TextBox>
                                                                </td>
                                                                <td style="height: 26px; width: 100px;">
                                                                    <span closure_uid_9y98hg="102" style="color: #000; background-color: #e6ecf9" title=""
                                                                        xc="ASIGNADO" yc="ASSIGNED">
                                                                         <asp:Label ID="lblAsignado" runat="server"   Height="22px"
                                                                        Text="" >
                                                                    </asp:Label> </span>:
                                                                </td>
                                                                <td style="height: 26px; width: 100px;">
                                                                    <asp:TextBox ID="txtValorAsignado" runat="server" Font-Bold="True" ReadOnly="true"
                                                                        Width="95%" BackColor="#E0E0E0">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td style="height: 26px; width: 160px;">
                                                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span id="result_box" class="short_text" lang="en">
                                                                        <span closure_uid_9y98hg="108" title="" xc="POR ASIGNAR" yc="APPROPRIATE FOR">
                                                                         <asp:Label ID="lblAprop" runat="server"   Height="22px"
                                                                        Text="" >
                                                                    </asp:Label>
                                                                        </span>:
                                                                </td>
                                                                <td style="width: 100px; height: 26px">
                                                                    <asp:TextBox ID="txtValorPorAsignar" runat="server" Font-Bold="True" ReadOnly="true"
                                                                        Width="76%" BackColor="#E0E0E0">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel Width="898px" ID="Panel1" runat="server" class="subpanel">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 890px; height: 22px;">
                                                                <tr class="titulo">
                                                                    <td colspan="10" style="height: 8px; width: 947px;" align="center">
                                                                        <asp:Label ID="lblALLOCATION" runat="server"   Height="22px"
                                                                            Text="" >
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 890px; height: 1px"
                                                                class="subpanel">
                                                                <tr align="left" class="subpanel" valign="top">
                                                                    <td style="width: 1px; height: 27px" align="center">
                                                                        <asp:Label ID="lblSTOCKS" runat="server"   Height="22px"
                                                                            Text="" >
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="1" style="width: 660px; height: 27px" valign="top">
                                                                    </td>
                                                                </tr>
                                                                <tr align="left" valign="top" class="subpanel">
                                                                    <td style="width: 232px; border-top: solid 1px #917D82; border-bottom: solid 1px #917D82;
                                                                        height: 113px;">
                                                                        <asp:GridView ID="grdExistencias" runat="server" Height="1px" Width="26px" CellPadding="4"
                                                                            ForeColor="#333333" GridLines="None" Font-Size="Medium" OnRowDataBound="grdExistencias_RowDataBound">
                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                            <FooterStyle BackColor="#9FA2A6" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#72757A" ForeColor="White" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="CornflowerBlue" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#91979E" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                    <td align="left" colspan="1" valign="top" style="height: 113px; width: 660px; border-top: solid 1px #917D82;
                                                                        border-bottom: solid 1px #917D82; border-left: solid 1px #917D82;">
                                                                        <table cellpadding="0" cellspacing="0" style="width: 658px; height: 19px">
                                                                            <tr>
                                                                                <td style="height: 26px; width: 10%;">
                                                                                    &nbsp;
                                                                                    <asp:Label ID="lblVa" runat="server"   Height="22px"
                                                                            Text="" >
                                                                        </asp:Label>
                                                                                </td>
                                                                                <td style="height: 26px; width: 18%;">
                                                                                    &nbsp;
                                                                                    <asp:DropDownList ID="ddlDenominaciones" runat="server" Width="132px" AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="height: 26px; width: 12%;">
                                                                                    <asp:Label ID="lblCanti" runat="server"   Height="22px"
                                                                            Text="" >
                                                                        </asp:Label>
                                                                                </td>
                                                                                <td style="height: 26px" width="10%">
                                                                                    <asp:TextBox ID="txtCantidad_" runat="server" Font-Bold="True" Width="95%" AutoPostBack="True"
                                                                                        OnTextChanged="txtCantidad__TextChanged">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td style="height: 26px; width: 12%;">
                                                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                                     <asp:Label ID="lblAs" runat="server"   Height="22px"
                                                                            Text="" ></asp:Label>
                                                                                </td>
                                                                                <td style="height: 26px; width: 16%;">
                                                                                    <asp:TextBox ID="txtSubtotal" runat="server" Font-Bold="True" ReadOnly="true" Width="95%"
                                                                                        Enabled="False" BackColor="#E0E0E0">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td style="height: 22px; text-align: center">
                                                                                    <asp:Button ID="btnAsignar" runat="server" Text="ASIGN" Height="33px" Width="102px"
                                                                                        OnClick="btnAsignar_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr align="left">
                                                                                <td colspan="7" style="height: 148px; width: 658px; border-top: solid 1px #917D82;
                                                                                    border-bottom: solid 1px #917D82;" valign="top">
                                                                                    &nbsp;
                                                                                    <asp:GridView Width="650px" ID="grdAsignaciones" runat="server" DataKeyNames="Value"
                                                                                        CssClass="Grilla" AutoGenerateColumns="False" PageSize="100" ShowFooter="True"
                                                                                        RowStyle-CssClass="FilaNormal" AlternatingRowStyle-CssClass="FilaAlternada" HeaderStyle-CssClass="Cabeza"
                                                                                        SelectedRowStyle-CssClass="FilaSeleccionada" FooterStyle-CssClass="Pie" OnRowCommand="grdAsignaciones_RowCommand">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText='Valor'>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblValue" runat="server" Text='<%# Bind("Value","{0:c}") %>'>
                                                                                                    </asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText='Cantidad'>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity","{0:n}") %>'>
                                                                                                    </asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Subtotal">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSubtotal" runat="server" Text='<%# Bind("Subtotal","{0:c}") %>'>
                                                                                                    </asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Quitar">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:LinkButton ID="LnkBorrarTodosPorAsignar" CssClass="Link3" CommandName="Quitar"
                                                                                                        runat="server">Borrar
                                                                                                    </asp:LinkButton>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="ChkBorrarUnoPorAsignar" runat="server" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle CssClass="td_c" HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle CssClass="FilaNormal" />
                                                                                        <FooterStyle CssClass="Pie" />
                                                                                        <SelectedRowStyle CssClass="FilaSeleccionada" />
                                                                                        <HeaderStyle CssClass="Cabeza" />
                                                                                        <AlternatingRowStyle CssClass="FilaAlternada" />
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="7" style="text-align: center" align="center">
                                                                                    <asp:Button ID="Button2" runat="server" Text="Guardar" Height="33px" Width="102px" OnClick="Button2_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 1px; height: 18px;">
                                                                    </td>
                                                                    <td style="width: 723px; height: 18px;">
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                            <uc1:Mensaje ID="Mensaje1" runat="server" />
                                                        </asp:Panel>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <!-- Fin Rediseño de Pagina -->
            </td>
        </tr>
    </table>
</asp:Content>
