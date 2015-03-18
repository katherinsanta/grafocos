<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra/Actualizacion.Master" AutoEventWireup="true"
    Codebehind="Descuentos.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.PanelControl.Descuentos1"
    Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
<br/>
<p>
<asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
   </p> 
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <div style="width: 100%; height: 100%;">
            <table cellpadding="2" cellspacing="4" width="100%" border="0">
                <tr style="height: 30px">
                    <td align="right">
                        <a href="descuento.aspx?id=null">Crear un Nuevo Descuento</a> &nbsp;|&nbsp;
                        
                        <asp:LinkButton ID="LinkButton1" ForeColor="black" runat="server" OnClick="LinkButton1_Click">Eliminar</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td>
                        <asp:GridView ID="gvwDescuentos" CellPadding="1" CellSpacing="4" Width="100%" runat="server"
                            AutoGenerateColumns="False" OnRowCommand="gvwDescuentos_RowCommand" DataKeyNames="IdDescuento">
                            <HeaderStyle Height="21px" CssClass="ResultsHeader2" />
                            <RowStyle Height="25px" CssClass="RowText" />
                            <Columns>
                                <asp:BoundField HeaderText="IdDescuento" DataField="IdDescuento" Visible ="false"  />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <input type="checkbox" name="Check" value='<%# DataBinder.Eval(Container.DataItem, "IdDescuento") %>'>
                                        <%# DataBinder.Eval (Container.DataItem, "IdDescuento") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Descuento" DataField="TipoDes" />
                                <asp:BoundField HeaderText="Valor" DataField="valor" />
                                <asp:BoundField HeaderText="Porcentaje" DataField="PorcDescuento" />
                                <asp:BoundField HeaderText="Estado" DataField="EstadoStr" />
                                
                                <asp:buttonfield buttontype="Link" 
                  commandname="Editar" 
                  text="Editar"/>


                              
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
