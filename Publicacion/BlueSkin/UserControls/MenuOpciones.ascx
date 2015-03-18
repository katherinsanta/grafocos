<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuOpciones.ascx.cs" Inherits="Servipunto.Cartera.Web.BlueSkin.UserControls.MenuOpciones" %>

<asp:TreeView ID="trvPanelDeControl" runat="server" Width="100%" HoverNodeStyle-CssClass="ItemMenu">
    <Nodes>
     <asp:TreeNode Text="Panel de Control" Value="Panel de Control" ImageUrl="~/BlueSkin/Icons/PanelControl-32.gif">
        <asp:TreeNode Text="Lista de Precios" Value="Lista de Precios" NavigateUrl="~/Modules/PanelControl/ListasPrecios.aspx" ImageUrl="~/BlueSkin/Icons/Hoja-16.gif">
            <asp:TreeNode Text="Categor&#237;as" Value="Categor&#237;as" NavigateUrl="~/Modules/PanelControl/Categorias.aspx" ></asp:TreeNode>
            <asp:TreeNode Text="Marcas" Value="Marcas" NavigateUrl="~/Modules/PanelControl/Marcas.aspx"></asp:TreeNode>
            <asp:TreeNode Text="Presentaciones" Value="Presentaciones" NavigateUrl="~/Modules/PanelControl/Presentaciones.aspx" ></asp:TreeNode>
            <asp:TreeNode Text="Embalajes" Value="Embalajes" NavigateUrl="~/Modules/PanelControl/Embalajes.aspx"></asp:TreeNode>
            <asp:TreeNode Text="Ubicaciones" Value="Ubicaciones" NavigateUrl="~/Modules/PanelControl/UbicacionesArticulos.aspx"></asp:TreeNode>
            <asp:TreeNode Text="Unidades de Medida" Value="Unidades de Medida" NavigateUrl="~/Modules/PanelControl/UnidadesMedidas.aspx"></asp:TreeNode>
            <asp:TreeNode Text="Iva" Value="Iva" NavigateUrl="~/Modules/PanelControl/UnidadesMedidas.aspx"></asp:TreeNode>
         </asp:TreeNode>
         <asp:TreeNode Text="Articulos" Value="Articulos" NavigateUrl="~/Modules/PanelControl/Articulos.aspx" ImageUrl="~/BlueSkin/Icons/articulos-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Tipos de Identificación" Value="Tipos de Identificación" NavigateUrl="~/Modules/PanelControl/TiposIdentificaciones.aspx" ImageUrl="~/BlueSkin/Icons/IContable-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Grupos Empresariales" Value="Grupos Empresariales" NavigateUrl="~/Modules/PanelControl/GruposEmpresariales.aspx" ImageUrl="~/BlueSkin/Icons/Compania-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Centros de Costos" Value="Centros de Costos" NavigateUrl="~/Modules/PanelControl/CentrosDeCostos.aspx" ImageUrl="~/BlueSkin/Icons/Comerciales-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Centros de Ventas" Value="Centros de Ventas" NavigateUrl="~/Modules/PanelControl/CentrosDeVentas.aspx" ImageUrl="~/BlueSkin/Icons/Estacion-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Clientes" Value="Clientes" NavigateUrl="~/Modules/PanelControl/Clientes.aspx" ImageUrl="~/BlueSkin/Icons/Cliente-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Resoluciones" Value="Resoluciones" NavigateUrl="~/Modules/PanelControl/Resoluciones.aspx" ImageUrl="~/BlueSkin/Icons/ubicaciones_16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Conceptos de Notas Crédito" Value="Conceptos de Notas Crédito" NavigateUrl="~/Modules/PanelControl/ConceptoNotaCredito.aspx" ImageUrl="~/BlueSkin/Icons/nota_credito-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Conceptos de Notas Débito" Value="Conceptos de Notas Débito" NavigateUrl="~/Modules/PanelControl/ConceptoNotaCredito.aspx" ImageUrl="~/BlueSkin/Icons/nota_debito-16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Paises" Value="Paises" NavigateUrl="~/Modules/PanelControl/Paises.aspx" ImageUrl="~/BlueSkin/Icons/zonas_16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Departamentos" Value="Departamentos" NavigateUrl="~/Modules/PanelControl/Departamentos.aspx" ImageUrl="~/BlueSkin/Icons/zonas_16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Ciudades" Value="Ciudades" NavigateUrl="~/Modules/PanelControl/Ciudades.aspx" ImageUrl="~/BlueSkin/Icons/zonas_16.gif">
            
         </asp:TreeNode>
         <asp:TreeNode Text="Zonas" Value="Zonas" NavigateUrl="~/Modules/PanelControl/Zonas.aspx" ImageUrl="~/BlueSkin/Icons/zonas_16.gif">
            
         </asp:TreeNode>
    
    </asp:TreeNode>
    </Nodes>
</asp:TreeView>
<asp:TreeView ID="trvPrincipal" runat="server" Width="100%">
<Nodes>
        <asp:TreeNode Text="P&#225gina Principal" ToolTip="Servipunto Centralizador CarteraNet" Value="P&#225gina Principal" NavigateUrl="~/Modules/PanelControl/ListasPrecios.aspx" ImageUrl="~/BlueSkin/Icons/cartera-32.gif">
            <asp:TreeNode Text="Modulo Panel de Control" Value="Zonas" NavigateUrl="~/Modules/PanelControl/Default.aspx" ImageUrl="~/BlueSkin/Icons/PanelControl-16.gif">
            
            </asp:TreeNode>
            <asp:TreeNode Text="Modulo Comerciales" Value="Zonas" NavigateUrl="~/Modules/Comerciales/Default.aspx" ImageUrl="~/BlueSkin/Icons/Comerciales-16.gif">
            
            </asp:TreeNode>
        </asp:TreeNode>
</Nodes>
</asp:TreeView>
<asp:TreeView ID="trvComerciales" runat="server" Width="100%">
    <Nodes>
        <asp:TreeNode Text="Comerciales" Value="Comerciales" ToolTip="Area Comercial del Sistema." NavigateUrl="~/Modules/PanelControl/ListasPrecios.aspx" ImageUrl="~/BlueSkin/Icons/cartera-32.gif">
            <asp:TreeNode Text="Vales" Value="Zonas" NavigateUrl="~/Modules/PanelControl/Default.aspx" ImageUrl="~/BlueSkin/Icons/vale-asignado_16.gif"></asp:TreeNode>
            <asp:TreeNode Text="Formas de Pago" Value="Formas de Pago" NavigateUrl="~/Modules/Comerciales/Default.aspx" ImageUrl="~/BlueSkin/Icons/FormaPago-16.gif"></asp:TreeNode>
            <asp:TreeNode Text="Recibos" Value="Recibos" NavigateUrl="~/Modules/Comerciales/RecibosDeCaja.aspx" ImageUrl="~/BlueSkin/Icons/Capturador-16.gif"></asp:TreeNode>
            <asp:TreeNode Text="Notas Crédito" Value="Zonas" NavigateUrl="~/Modules/Comerciales/NotasCredito.aspx" ImageUrl="~/BlueSkin/Icons/nota_debito-16.gif"></asp:TreeNode>
        </asp:TreeNode>
    </Nodes>
</asp:TreeView>
<asp:TreeView ID="trvReportes" runat="server" Width="100%">
    <Nodes>
        <asp:TreeNode Text="Reportes" Value="Reportes" ToolTip="Administración de Reportes"  ImageUrl="~/BlueSkin/Icons/Reportes-32.gif">
            <asp:TreeNode Text="Módulo de Reportes" Value="Módulo de Reportes" NavigateUrl="~/Modules/Reportes/Default.aspx" ImageUrl="~/BlueSkin/Icons/Reportes-16.gif"></asp:TreeNode>
            <asp:TreeNode Text="Módulo de Panel de Control" Value="Módulo de Panel de Control" NavigateUrl="~/Modules/PanelControl/Default.aspx" ImageUrl="~/BlueSkin/Icons/PanelControl-16.gif"></asp:TreeNode>
            <asp:TreeNode Text="Módulo de Procesos" Value="Módulo de Procesos"  ImageUrl="~/BlueSkin/Icons/Procesos-16.gif"></asp:TreeNode>
            <asp:TreeNode Text="Módulo de Comerciales" Value="Módulo de Comerciales" NavigateUrl="~/Modules/Comerciales/Default.aspx" ImageUrl="~/BlueSkin/Icons/Comerciales-16.gif"></asp:TreeNode>
        </asp:TreeNode>
    </Nodes>
</asp:TreeView>
