using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Servipunto.Estacion.Web.Ajax.lib
{
    public class NavigationPane
    {
        #region propiedades privadas

        private string _group;
        private string _icono;
        private string _rutaImg;
        private string _titulo;
        private string _descripcion;
        

        #endregion

        #region Propiedades publicas

        public string Group 
        {
            get { return _group; }
            set { _group = value; }
        }

        public string IconoList
        {
            get { return _icono; }
            set { _icono = value; }
        }
        public string RutaImg
        {
            get { return _rutaImg; }
            set { _rutaImg = value; }
        }
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion

        #region constructor
        public NavigationPane()
        {
           
        }
        #endregion

        #region obtener Panel
        public string ObtenerPanel() 
        {
            switch (Group)
            {
                case "PaginaPrincipal": return PaginaInicio();
                    break;
                case "Reportes": return Reportes();
                    break;
                case "PanelDeControl": PaneLDeControl();
                    break;
                case "Procesos": Procesos();
                    break;
                case "Comerciales": Comerciales();
                    break;
                case "Variaciones": Variaciones();
                    break;
                case "Prepagos": Prepagos();
                    break;
                case "Consultas": Consultas();
                    break;
            }
            return string.Empty;
        }
        #endregion

        #region GetHeader
        public string GetHeader(string rutaImg, string titulo, string descripcion)
        {
            StringBuilder _htmlCode = new StringBuilder();
            _rutaImg = string.Format("../../BlueSkin/Update/{0}", rutaImg);

            _htmlCode.Append("<table width='100%' border='0' cellspacing='0'>");
            _htmlCode.Append("<tr style='height:16px'>");
            _htmlCode.Append("<td width='16px'  rowspan='2' align='center' bgcolor='#666666' ");
            _htmlCode.Append("style='padding: 10px; color: #FFF; font-size: 14px; font-family: Tahoma, Geneva, sans-serif;'>");
            _htmlCode.AppendFormat("<img src='{0}' width='32' height='32' align='absmiddle' />",_rutaImg);
            _htmlCode.Append("</td><td width='181' valign='bottom' bgcolor='#666666' style='padding-left: 5px; padding-bottom:");
            _htmlCode.AppendFormat("5px; padding-right: 5px; padding-top: 15px; color: #FFF; font-size: 14px; font-family: Tahoma, Geneva, sans-serif;'>{0}</td></tr>",titulo);
            _htmlCode.Append("<tr style='height:16px'><td valign='top' bgcolor='#666666' style='padding-bottom: 10px; padding-left: 5px; padding-right: 5px; ");
            _htmlCode.AppendFormat("color: #FFF; font-size: 12px; font-family: Tahoma, Geneva, sans-serif;'>{0}</td></tr>",descripcion);
            _htmlCode.Append("</table>");
            _htmlCode.Append("<ul>");

            return _htmlCode.ToString();
        }
        #endregion

        #region GetList
        public string getList(string icono, string texto,string url) 
        {
            StringBuilder _htmlCode = new StringBuilder();
            _icono = string.Format("url(../../BlueSkin/{0})", icono);
            _htmlCode.AppendFormat("<li style='list-style-image:{0}; width:100%px; height:16px; align:absmiddle;'><a class='Link1' href='{1}'>{2}</a></li>",_icono,url,texto);
            
            return _htmlCode.ToString();               
        }
        #endregion

        #region FooterList
        public string footerList() 
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append("</ul>");

            return _htmlCode.ToString();
        }
        #endregion

        #region PaginaInicio
        public string PaginaInicio() 
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("home-32.png", "Pagina Principal", "Administración de la Estación"));
            _htmlCode.Append(getList("Update/panelDeControl.png", "Panel De Control", "../PanelControl/Default.aspx"));
            _htmlCode.Append(getList("Update/Reportes.png", "Reportes", "../ReportesEstacion/Default.aspx"));
            _htmlCode.Append(getList("Update/Procesos.png", "Procesos", "../Procesos/Default.aspx"));
            _htmlCode.Append(getList("Update/Comerciales.png", "Comerciales", "../Comerciales/Default.aspx"));
            _htmlCode.Append(getList("Update/Variaciones.png", "Variaciones", "../Variaciones/Default.aspx"));
            _htmlCode.Append(getList("Update/prepago-16.png", "Prepagos", "../Prepagos/default.aspx"));
            _htmlCode.Append(getList("Update/consultas-16.png", "Consultas", "../Consultas/default.aspx"));
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion

        #region PanelDeControl
        public string PaneLDeControl() 
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("panel-de-control-32.png", "Panel De Control", "Panel De Configuracion"));
            _htmlCode.Append(getList("Icons/2011/PerfilesUsuarios16.png", "Perfiles De Usuario", "../PanelControl/Roles.aspx"));
            _htmlCode.Append(getList("Icons/2011/Usuarios16.png", "Usuarios", "../PanelControl/Usuarios.aspx"));
            _htmlCode.Append(getList("Icons/2011/Articulos16.png", "Articulos", "../PanelControl/Articulos.aspx"));
            _htmlCode.Append(getList("Icons/2011/FormasDePago16.png", "Formas de pago", "../PanelControl/FormasPago.aspx"));
            _htmlCode.Append(getList("Icons/2011/Companias16.png", "Compañias", "../PanelControl/Companias.aspx"));
            _htmlCode.Append(getList("Icons/2011/Grupos16.png", "Grupos", "../PanelControl/Grupos.aspx"));
            _htmlCode.Append(getList("Icons/2011/Puertos16.png", "Puertos", "../PanelControl/Puertos.aspx"));
            _htmlCode.Append(getList("Icons/2011/lectores-16.png", "Lectores", "../PanelControl/Lectores.aspx"));
            _htmlCode.Append(getList("Icons/2011/controladores16.png", "Controladores", "../PanelControl/Controladores.aspx"));
            _htmlCode.Append(getList("Icons/2011/Capturadores16.png", "Capturadores", "../PanelControl/Capturadores.aspx"));
            _htmlCode.Append(getList("Icons/2011/estacion-16.png", "Estacion", "../PanelControl/Estaciones.aspx"));
            _htmlCode.Append(getList("Icons/2011/pos-16.png", "Pos", "../PanelControl/Poss.aspx"));
            _htmlCode.Append(getList("Icons/2011/Empleados16.png", "Empleados", "../PanelControl/Empleados.aspx"));
            _htmlCode.Append(getList("Icons/2011/DatosGenerales16.png", "Datos Generales", "../PanelControl/DatosGenerales.aspx"));
            _htmlCode.Append(getList("Icons/2011/Comunicaciones16.png", "Tipos De Comunicaciones", "../PanelControl/TiposComunicaciones.aspx"));
            _htmlCode.Append(getList("Icons/2011/tanques-16.png", "Tanques", "../PanelControl/Tanques.aspx"));
            _htmlCode.Append(getList("Icons/2011/PreciosProgramados16.png", "Precios Programados ", "../PanelControl/PreciosProgramados.aspx"));
            _htmlCode.Append(getList("Icons/2011/VentasGratis16.png", "Ventas Gratis", "../PanelControl/ConfVentasGratis.aspx"));
            _htmlCode.Append(getList("Icons/2011/BolNumOrdenes-16.png", "Resoluciones De Factura", "../PanelControl/Bol_NumOrdenes.aspx"));
            _htmlCode.Append(getList("Icons/2011/SelfService16.png", "Self Service", "../PanelControl/Selfservices.aspx"));
            _htmlCode.Append(getList("Icons/2011/lugares-16.png", "Lugares", "../PanelControl/Departamentos.aspx"));
            _htmlCode.Append(getList("Icons/2011/InterfazContable16.png", "Interfaz Contable", "../PanelControl/InterfazContable.aspx"));
            _htmlCode.Append(getList("Icons/2011/mantenimiento-16.png", "Mantenimiento", "../PanelControl/Mantenimiento.aspx"));
            _htmlCode.Append(getList("Icons/2011/TiqueteDeVenta16.png", "Configuracion Tiquete Venta", "../PanelControl/ConfiguracionTiqueteVenta.aspx"));
            _htmlCode.Append(getList("Icons/2011/OtrosIngresos16.png", "Otros Ingresos", "../PanelControl/OtrosIngresos.aspx"));
            _htmlCode.Append(getList("Icons/2011/Zeta16.png", "Configuracion Zeta Automatico", "../PanelControl/ConfiguracionZetaAutomatico.aspx"));
            _htmlCode.Append(getList("Icons/2011/Descuentos16.png", "Configuracion De Descuentos", "../PanelControl/Descuentos.aspx"));
            
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion

        #region reportes
        public string Reportes()
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("reportes-32.png", "Reportes", "Reportes Del Sistema"));
            _htmlCode.Append(getList("Icons/2011/Generales16.png", "Generales", "../ReportesEstacion/ReportesGenerales.aspx"));
            _htmlCode.Append(getList("Icons/2011/FormasDePago16.png", "Formas De Pago", "../ReportesEstacion/ReportesFormaPago.aspx"));
            _htmlCode.Append(getList("Icons/2011/PeriodoDeTiempo16.png", "Periodos De Tiempo", "../ReportesEstacion/ReportesPeriodoTiempo.aspx"));
            _htmlCode.Append(getList("Icons/2011/Clientes16.png", "Clientes", "../ReportesEstacion/ReportesClientes.aspx"));
            _htmlCode.Append(getList("Icons/2011/Automotores16.png", "Automotores", "../ReportesEstacion/ReportesAutomotor.aspx"));
            _htmlCode.Append(getList("Icons/2011/CreditoDirecto16.png", "Credito Directo", "../ReportesEstacion/ReportesCreditoDirecto.aspx"));
            _htmlCode.Append(getList("Icons/2011/facturacion-16.png", "Facturacion", "../ReportesEstacion/ReportesFacturacion.aspx"));
            _htmlCode.Append(getList("Icons/2011/Recaudos16.png", "Recaudo", "../ReportesEstacion/ReportesRecaudo.aspx"));
            _htmlCode.Append(getList("Icons/2011/Auditoria16.png", "Auditoria", "../ReportesEstacion/ReportesAuditoria.aspx"));
            _htmlCode.Append(getList("Icons/2011/Conductores16.png", "Conductor", "../ReportesEstacion/ReportesConductor.aspx"));
            
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion

        #region procesos
        public string Procesos()
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("procesos-32.png", "Procesos", "Procesos Del Sistema"));
            _htmlCode.Append(getList("Icons/2011/SincronizacionExternaGNV16.png", "Sincronizacion Externa GNV", "../Procesos/OpcionesGNV.aspx"));
            _htmlCode.Append(getList("Icons/2011/ArchivosPlanosContables16.png", "Archivos Planos Contables", "../Procesos/InterfazContable.aspx"));
            _htmlCode.Append(getList("Icons/2011/AjusteDePagos16.png", "Ajuste De Pagos", "../Procesos/AjustePago.aspx"));
            _htmlCode.Append(getList("Icons/2011/OtrosIngresos16.png", "Otros Ingresos", "../Procesos/RegistroOtrosIngresos.aspx"));
            _htmlCode.Append(getList("Icons/2011/FormaPago16.png", "Registro Inventario Canastilla", "../Procesos/RegistroCompraCanastilla.aspx"));
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion

        #region comerciales
        public string Comerciales()
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("Comerciales-32.png", "Procesos", "Procesos Del Sistema"));
            _htmlCode.Append(getList("Icons/2011/Clientes16.png", "Clientes", "../Comerciales/Clientes.aspx"));
            _htmlCode.Append(getList("Icons/2011/PreciosDiferenciales16.png", "Precios Diferenciales", "../Comerciales/ListaPreciosDiferenciales.aspx"));
            _htmlCode.Append(getList("Icons/2011/Conductores16.png", "Conductores", "../Comerciales/Conductores.aspx"));
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion

        #region variaciones
        public string Variaciones()
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("variaciones-32.png", "Procesos", "Procesos Del Sistema"));
            _htmlCode.Append(getList("Icons/2011/MensajesParaVariacionOBalance16.png", "Mensaje Para Variacion O Valance", "../Variaciones/Default.aspx"));
            _htmlCode.Append(getList("Icons/2011/AperturaOCierreZeta16.png", "Apertura O Cierre Z", "../Variaciones/Zetas.aspx"));
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion 

        #region prepagos
        public string Prepagos()
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("variaciones-32.png", "Procesos", "Procesos Del Sistema"));
            _htmlCode.Append(getList("Icons/2011/CrearPrepago16.png", "Crear Prepagos", "../Prepagos/Creaciones.aspx"));
            _htmlCode.Append(getList("Icons/2011/AsignarPrepago16.png", "Asignar Prepagos", "../Prepagos/Asignacion.aspx"));
            _htmlCode.Append(getList("Icons/2011/CancelarPrepago16.png", "Cancelar Prepagos", "../Prepagos/Anulacion.aspx"));
            _htmlCode.Append(getList("Icons/2011/RepotePrepagos16.png", "Reporte Prepagos", "../ReportesEstacion/FiltroPrepagos.aspx"));
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion

        #region consultas
        public string Consultas()
        {
            StringBuilder _htmlCode = new StringBuilder();
            _htmlCode.Append(GetHeader("consultas-32.png", "Consultas", "Consultas de Canastilla"));
            _htmlCode.Append(getList("Icons/2011/FacturaCanastilla16.png", "Facturas Canastilla", "../Consultas/FacturasCanastilla.aspx"));
            _htmlCode.Append(footerList());

            return _htmlCode.ToString();
        }
        #endregion
    }
}
