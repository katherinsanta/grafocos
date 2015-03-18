<%@ Page Language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="true" Inherits="Servipunto.Estacion.Web.Modules.PanelControl._Default"
    MasterPageFile="~/PaginaMaestra/Actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <br />
    <br />
    <p style="margin-left: 20px;"><asp:Label ID="lblPanel" runat="server" Text="Este es el menú principal para acceder a cualquier área del panel de control del sistema. Para ingresar a las opciones simplemente haga clic sobre el link respectivo. "></asp:Label></p>
    
    <br />
    <table align="center" border="0" style="padding-right: 10px; padding-left: 15px;
        margin-left: 20px; margin-top: 0px">
            <tr>
                <!--PERFILES DE USUARIO -->
                <td valign="top" align="center" style="margin: 0px; height: 52px" width="48px">
                    <a href="Roles.aspx" class="linkForm">
                        <img alt="Perfiles de Usuario" src="../../BlueSkin/Icons/2011/PerfilesUsuarios.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="height: 52px; margin: 0px; width: 128px;">
                    <a href="Roles.aspx" class="linkForm">
                        <asp:Label ID="lblPerfilUsuario" runat="server" Text="Perfiles de Usuario"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Configure Los Permisos De Los Usuarios
                    </p>
                </td>
                <!--USUARIOS -->
                <td valign="top" align="center" width="48px" style="height: 52px">
                    <a href="Usuarios.aspx" class="linkForm">
                        <img alt="Usuarios" src="../../BlueSkin/Icons/2011/Usuarios.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="height: 52px; width: 128px;">
                    <a href="Usuarios.aspx" class="linkForm">
                        <asp:Label ID="Label1" runat="server" Text="Usuarios"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree o Elimine Los Usuarios Del Sistema
                    </p>
                </td>
                <!--ARTICULOS -->
                <td valign="top" align="center" width="48px" style="height: 52px">
                    <a href="Articulos.aspx" class="linkForm">
                        <img alt="Artículos" src="../../BlueSkin/Icons/2011/Articulos.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px" style="height: 52px">
                    <a href="Articulos.aspx" class="linkForm">
                        <asp:Label ID="Label2" runat="server" Text="Articulos"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Los articulos
                    </p>
                </td>
                <!--FORMAS DE PAGO -->
                <td valign="top" align="center" width="48px" style="height: 52px">
                    <a href="FormasPago.aspx" class="linkForm">
                        <img alt="Formas de Pago" src="../../BlueSkin/Icons/2011/FormasDePago.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="48px" style="height: 52px">
                    <a href="FormasPago.aspx" class="linkForm">
                        <asp:Label ID="Label3" runat="server" Text="Formas de Pago " Width="101px"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Configure o Cree Las Formas De Pago
                    </p>
                </td>
                <!--COMPANIAS -->
                <td valign="top" align="center" width="48px" style="height: 52px">
                    <a href="Companias.aspx" class="linkForm">
                        <img alt="Compañías" src="../../BlueSkin/Icons/2011/Companias.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px" style="height: 52px">
                    <a href="Companias.aspx" class="linkForm">
                        <asp:Label ID="Label4" runat="server" Text="Compañías "></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Compañia
                    </p>
                </td>
            </tr>
            <tr>
                <!--GRUPOS -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Grupos.aspx" class="linkForm">
                        <img alt="Grupos" src="../../BlueSkin/Icons/2011/Grupos.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="width: 128px">
                    <a href="Grupos.aspx" class="linkForm">
                        <asp:Label ID="Label5" runat="server" Text="Grupos "></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree o Elimine Grupos
                    </p>
                </td>
                <!-- PUERTOS-->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Puertos.aspx" class="linkForm">
                        <img alt="Puertos" src="../../BlueSkin/Icons/2011/Puertos.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="width: 128px">
                    <a href="Puertos.aspx" class="linkForm">
                        <asp:Label ID="Label6" runat="server" Text="Puertos ">
                        </asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree, Configure Puertos
                    </p>
                </td>
                <!--LECTORES -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Lectores.aspx" class="linkForm">
                        <img alt="Lectores" src="../../BlueSkin/Icons/2011/lectores-48.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px">
                    <a href="Lectores.aspx" class="linkForm">
                        <asp:Label ID="Label7" runat="server" Text="Lectores ">
                        </asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree o Configure Los Lectores
                    </p>
                </td>
                <!--CONTROLADORES -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Controladores.aspx" class="linkForm">
                        <img alt="Controladores" src="../../BlueSkin/Icons/2011/controladores48.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px">
                    <a href="Controladores.aspx" class="linkForm">
                        <asp:Label ID="Label8" runat="server" Text="Controladores"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Controladores
                    </p>
                </td>
                <!--CAPTURADORES -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Capturadores.aspx" class="linkForm">
                        <img alt="Capturadores" src="../../BlueSkin/Icons/2011/Capturadores.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px">
                    <a href="Capturadores.aspx" class="linkForm">
                        <asp:Label ID="Label9" runat="server" Text="Capturadores (MRs)"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Capturadores
                    </p>
                </td>
            </tr>
            <tr>
                <!--ESTACION -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Estaciones.aspx" class="linkForm">
                        <img alt="Configuración de la Estación" src="../../BlueSkin/Icons/2011/Estacion.png"
                            border="0"/>&nbsp;
                        
                    </a>
                </td>
                <td valign="top" align="left" style="width: 128px">
                    <a href="Estaciones.aspx" class="linkForm">
                        <asp:Label ID="Label10" runat="server" Text="Estación"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Estaciones</p>
                </td>
                <!-- POS-->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Poss.aspx" class="linkForm">
                        <img height="48" alt="Configuración de los POS" src="../../BlueSkin/Icons/2011/POS.png"
                            width="48" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="width: 128px">
                    <a href="Poss.aspx" class="linkForm">
                        <asp:Label ID="Label11" runat="server" Text="POS"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Los Pos
                    </p>
                </td>
                <!--EMPLEADOS -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Empleados.aspx" class="linkForm">
                        <img alt="Empleados" src="../../BlueSkin/Icons/2011/Empleados.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px">
                    <a href="Empleados.aspx" class="linkForm">
                        <asp:Label ID="Label12" runat="server" Text="Empleados"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Empleados</p>
                </td>
                <!--DATOS GENERALES -->
                <td valign="top" align="center" width="48px " style="height: 48px">
                    <a href="DatosGenerales.aspx">
                        <img alt="Datos Generales" src="../../BlueSkin/Icons/2011/DatosGenerales48.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128 px">
                    <a href="DatosGenerales.aspx" class="linkForm">
                        <asp:Label ID="Label13" runat="server" Text="Datos Generales ">
                        </asp:Label>
                    </a>
                    <p class="Descripcion">
                        Modifique Los Datos De Su Empresa
                    </p>
                </td>
                <!-- COMUNICACIONES-->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="TiposComunicaciones.aspx" class="linkForm">
                        <img alt="Tipos de Comunicaciones" src="../../BlueSkin/Icons/2011/Comunicaciones.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px">
                    <a href="TiposComunicaciones.aspx" class="linkForm">
                        <asp:Label ID="Label14" runat="server" Text="Tipos de Comunicaciones"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree o Elimine Las Comunicaciones</p>
                </td>
            </tr>
            <tr>
                <!--PRECIOS PROGRAMADOS -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="PreciosProgramados.aspx" class="linkForm">
                        <img alt="Programación de precios" src="../../BlueSkin/Icons/2011/PreciosProgramados.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="width: 128px">
                    <a href="PreciosProgramados.aspx" class="linkForm">
                        <asp:Label ID="Label16" runat="server" Text="Precios Programados"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Los Precios Programados</p>
                </td>
                <!--VENTAS GRATIS -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="ConfVentasGratis.aspx" class="linkForm">
                        <img alt="Ventas Gratis" src="../../BlueSkin/Icons/2011/VentasGratis.png" border="0"/>&nbsp;
                      
                    </a>
                </td>
                <td valign="top" align="left" style="height: 48px; width: 128px;">
                    <a href="ConfVentasGratis.aspx" class="linkForm">
                        <asp:Label ID="Label17" runat="server" Text="Ventas Gratis"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Sus Ventas Gratis</p>
                </td>
                <!--ORDENES -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Bol_NumOrdenes.aspx" class="linkForm">
                        <img alt="Dosificación de Facturas" src="../../BlueSkin/Icons/2011/resolucion-48.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px">
                    <a href="Bol_NumOrdenes.aspx" class="linkForm">
                        <asp:Label ID="Label18" runat="server" Text="Resolución Facturas Canastilla"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Los Numero De Orden
                    </p>
                </td>
                <!--SELF SERVICE -->
                <td valign="top" align="center" width="48px" style="height: 48px" class="linkForm">
                    <a href="Selfservices.aspx">
                        <img alt="Selfservice" src="../../BlueSkin/Icons/2011/SelfService.png" border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px" class="linkForm">
                    <a href="Selfservices.aspx" class="linkForm">Selfservice </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine El Self Service</p>
                </td>
                <!--DEPARTAMENTOS -->
                <td valign="top" align="center" width="48px" style="height: 48px">
                    <a href="Departamentos.aspx" class="linkForm">
                        <img alt="Países, departamentos y ciudades" src="../../BlueSkin/Icons/2011/Lugares.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px">
                    <a href="Departamentos.aspx" class="linkForm">
                        <asp:Label ID="Label19" runat="server" Text="Lugares"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Los Lugares</p>
                </td>
            </tr>
            <tr>
                <!--INTERFAZ CONTABLE -->
                <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="InterfazContable.aspx" class="linkForm">
                        <img alt="Configuración Interfaz Contable" src="../../BlueSkin/Icons/2011/InterfazContable.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="width: 128px; height: 67px;">
                    <a href="InterfazContable.aspx" class="linkForm">
                        <asp:Label ID="Label20" runat="server" Text="Interfaz Contable">
                        </asp:Label>
                    </a>
                    <p class="Descripcion">
                        Crea Una interfaz Contable</p>
                </td>
                <!--MANTENIMIENTO -->
                <td valign="top" align="left" width="48px" style="height: 67px">
                    <a href="Mantenimiento.aspx" class="linkForm">
                        <img alt="Opciones de mantenimiento al sistema de base de datos" src="../../BlueSkin/Icons/2011/Mantenimiento.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="width: 128px; height: 67px;">
                    <a href="Mantenimiento.aspx" class="linkForm">
                        <asp:Label ID="Label21" runat="server" Text="Mantenimiento"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Genere Sus Copias De Seguridad</p>
                </td>
                <!--TIQUETE VENTA -->
                <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="ConfiguracionTiqueteVenta.aspx" class="linkForm">
                        <img alt="Configuración Tiquete de Venta" src="../../BlueSkin/Icons/2011/TiqueteDeVenta.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" width="128px" style="height: 67px">
                    <a href="ConfiguracionTiqueteVenta.aspx" class="linkForm">
                        <asp:Label ID="Label22" runat="server" Text="Configuración Tiquete Venta"></asp:Label></a>
                    <p class="Descripcion">
                        Configure Su Tiquete De Venta
                    </p>
                </td>
                <!--OTROS INGRESOS -->
                <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="OtrosIngresos.aspx" class="linkForm">
                        <img alt="Otros Ingresos" src="../../BlueSkin/Icons/2011/OtrosIngresos.png" border="0" />
                    </a>
                </td>
                <td valign="top" align="left" width="128px" style="height: 67px">
                    <a href="OtrosIngresos.aspx" class="linkForm">Otros Ingresos </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Otros Ingresos
                    </p>
                </td>
                <!--ZETA -->
                <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="ConfiguracionZetaAutomatico.aspx" class="linkForm">
                        <img alt="Conf Zeta Automatico" src="../../BlueSkin/Icons/2011/Zeta.png" border="0" />
                    </a>
                </td>
                <td valign="top" align="left" width="128px" style="height: 67px">
                    <a href="ConfiguracionZetaAutomatico.aspx" class="linkForm">Configuración Zeta Automatico
                    </a>
                    <p class="Descripcion">
                        Configure Los Tiempos Del Z</p>
                </td>
            </tr>
            <tr>
                <!--DESCUENTO -->
                <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="Descuentos.aspx" class="linkForm">
                        <img alt="Conf Descuentos" src="../../BlueSkin/Icons/2011/Descuentos.png" border="0" />
                    </a>
                </td>
                <td valign="top" align="left" style="height: 67px; width: 128px;">
                    <a href="Descuentos.aspx" class="linkForm">Configuración Descuentos </a>
                    <p class="Descripcion">
                        Configure Los Descuentos De Su Estacion
                    </p>
                </td>
                <!--Consola Tanques-->
                <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="ConsolaTanques.aspx" class="linkForm">
                        <img alt="Administración de la consola Tanques tanques" src="../../BlueSkin/Icons/2011/consola-tanque-48px.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="height: 67px; width: 128px;">
                    <a href="consolatanques.aspx" class="linkForm">
                        <asp:Label ID="lblConsolaTanque" runat="server" Text="Consola Tanques"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Consola De Tanques</p>
                </td>
                <!--TANQUES -->
                <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="Tanques.aspx" class="linkForm">
                        <img alt="Administración de tanques" src="../../BlueSkin/Icons/2011/Tanques.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                <td valign="top" align="left" style="height: 67px; width: 128px;">
                    <a href="Tanques.aspx" class="linkForm">
                        <asp:Label ID="Label15" runat="server" Text="Tanques"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Tanques</p>
                </td>
                
                
                 <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="Tanques.aspx" class="linkForm">
                        <img alt="Administración de sorteos" src="../../BlueSkin/Icons/2011/boletas-48.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                
                 <td valign="top" align="left" style="height: 67px; width: 128px;">
                    <a href="ConfiguracionSorteos.aspx" class="linkForm">
                        <asp:Label ID="Label23" runat="server" Text="Configuración Sorteos"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique o Elimine Configuraciones de sorteos</p>
                </td>

                 <td valign="top" align="center" width="48px" style="height: 67px">
                    <a href="ConfiguracionSorteos.aspx" class="linkForm">
                        <img alt="Administración de sorteos" src="../../BlueSkin/Icons/2011/boletas-48.png"
                            border="0"/>&nbsp;
                    </a>
                </td>
                
                 <td valign="top" align="left" style="height: 67px; width: 128px;">
                    <a href="FactoresSurtidor.aspx" class="linkForm">
                        <asp:Label ID="Label24" runat="server" Text="Factores"></asp:Label>
                    </a>
                    <p class="Descripcion">
                        Cree Modifique Factores para valores de venta, preset, precio programado y valor lectura</p>
                </td>
            </tr>
    </table>
</asp:Content>
