//Tildes: a=&#225; e=&#233; i=&#237; o=&#243; u=&#250; 


function BuildNavigationPane(groupID)
{
	BuildLeftSplitter();	
	BuildNavigationPaneHeader();
	switch (groupID) {
		case "Login":
			PanelLogin();
			break;
		case "Principal":
			PanelPrincipal();
			break;
		case "Estacion":
			PanelReportes();
			break;			
		case "PanelControl":
			PanelControl();
			break;
		case "Procesos":
			PanelProcesos();
			break;
		case "Comerciales":
			PanelComerciales();
			break;						
		case "Error":
			PanelErrores();
			break;
		case "Variaciones":
			PanelVariacion();
			break;		
			
		case "Consultas":
			PanelConsultas();
			break;		
		default:
			break;
	}
	BuildNavigationPaneFooter();
	BuildRightSplitter();
}

//Panel de Navegación para el PANEL DE CONTROL
function PanelControl()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Panel de Control", "Configuraci&#243n del Sistema", "PanelControl-32.gif");
	HTMLCode += AddImageItem("Perfiles de Usuario", "../../Modules/PanelControl/Roles.aspx", "Roles-16.gif");
	HTMLCode += AddImageItem("Usuarios", "../../Modules/PanelControl/Usuarios.aspx", "Usuarios-16.gif");
	HTMLCode += AddImageItem("Art&#237culos", "../../Modules/PanelControl/Articulos.aspx", "Articulo-16.gif");
	HTMLCode += AddImageItem("Formas de Pago", "../../Modules/PanelControl/FormasPago.aspx", "FormaPago-16.gif");
	HTMLCode += AddImageItem("Compan&#237as", "../../Modules/PanelControl/Companias.aspx", "Compania-16.gif");
	HTMLCode += AddImageItem("Grupos", "../../Modules/PanelControl/Grupos.aspx", "Grupo-16.gif");
	HTMLCode += AddImageItem("Puertos", "../../Modules/PanelControl/Puertos.aspx", "Puerto-16.gif");
	HTMLCode += AddImageItem("Lectores", "../../Modules/PanelControl/Lectores.aspx", "Lector-16.gif");
	HTMLCode += AddImageItem("Controladores", "../../Modules/PanelControl/Controladores.aspx", "Controlador-16.gif");
	HTMLCode += AddImageItem("Capturadores", "../../Modules/PanelControl/Capturadores.aspx", "Capturador-16.gif");
	HTMLCode += AddImageItem("Estaci&#243n", "../../Modules/PanelControl/Estaciones.aspx", "Estacion-16.gif");
	HTMLCode += AddImageItem("Pos", "../../Modules/PanelControl/Poss.aspx", "Pos-16.gif");
	HTMLCode += AddImageItem("Empleado", "../../Modules/PanelControl/Empleados.aspx", "Empleado-16.gif");
	HTMLCode += AddImageItem("Datos Generales", "../../Modules/PanelControl/DatosGenerales.aspx", "DatosGenerales-16.gif");
	HTMLCode += AddImageItem("Tipos de Comunicaciones", "../../Modules/PanelControl/TiposComunicaciones.aspx", "Comunicaciones-16.gif");
	HTMLCode += AddImageItem("Tanques", "../../Modules/PanelControl/Tanques.aspx", "Tanque-16.gif");
	HTMLCode += AddImageItem("Precios Programados", "../../Modules/PanelControl/PreciosProgramados.aspx", "PreciosProgramados-16.gif");
	HTMLCode += AddImageItem("Ventas Gratis" , "../../Modules/PanelControl/ConfVentasGratis.aspx", "ConfVentasGratis-16.gif");
	HTMLCode += AddImageItem("Dosificaci&#243n Facturas", "../../Modules/PanelControl/Bol_NumOrdenes.aspx", "BolNumOrdenes-16.gif");
	HTMLCode += AddImageItem("Selfservice", "../../Modules/PanelControl/Selfservice.aspx", "selfservice-16.gif");
	HTMLCode += AddImageItem("Lugares", "../../Modules/PanelControl/Departamentos.aspx", "Lugar-16.gif");
	HTMLCode += AddImageItem("Interfaz Contable", "../../Modules/PanelControl/InterfazContable.aspx", "CIContable-16.gif");
	HTMLCode += AddImageItem("Mantenimiento", "../../Modules/PanelControl/Mantenimiento.aspx", "GenBackup-16.gif");

	
	HTMLCode += GetPanelFooter();
	
	document.write(HTMLCode);
}

//Panel de Navegación para el PANEL DE ERRORES
function PanelErrores()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Seguridad", "Control de Errores", "Error32.ico");
	HTMLCode += AddImageItem("Acceso Denegado", "", "Help16.ico");
	HTMLCode += GetPanelFooter();
	
	document.write(HTMLCode);
}

//Panel de Navegación para VENTANA DE AUTENTICACIÓN
function PanelLogin()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Seguridad", "Proceso de Autenticaci&#243n", "Login32.gif");
	HTMLCode += AddImageItem("Ingresar al Sistema", "../../Modules/Main/Login.aspx", "Login16.ico");
	//HTMLCode += AddImageItem2("Manual de Usuario", "../../Modules/General/Manual.pdf", "Manual-16.gif");
	HTMLCode += GetPanelFooter();
	
	document.write(HTMLCode);
}

//Panel de Navegación para la PAGINA REPORTES
function PanelReportes()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Reportes", "Categorias de reportes", "Reportes-32.gif");
	HTMLCode += AddImageItem("Generales", "../../Modules/ReportesEstacion/ReportesGenerales.aspx", "Generales-16.gif");
	HTMLCode += AddImageItem("Formas de Pago", "../../Modules/ReportesEstacion/ReportesFormaPago.aspx", "FormasPago-16.gif");
	HTMLCode += AddImageItem("Periodo de Tiempo", "../../Modules/ReportesEstacion/ReportesPeriodoTiempo.aspx", "Tiempo-16.gif");
	HTMLCode += AddImageItem("Clientes", "../../Modules/ReportesEstacion/ReportesClientes.aspx", "Cliente-16.gif");
	HTMLCode += AddImageItem("Automotores", "../../Modules/ReportesEstacion/ReportesAutomotor.aspx", "Automotor-16.gif");
	HTMLCode += AddImageItem("Credito Directo", "../../Modules/ReportesEstacion/ReportesCreditoDirecto.aspx", "CreditoDirecto-16.gif");
	HTMLCode += AddImageItem("Facturaci&#243n", "../../Modules/ReportesEstacion/ReportesFacturacion.aspx", "Hoja-16.gif");
	HTMLCode += AddImageItem("Recaudo", "../../Modules/ReportesEstacion/ReportesRecaudo.aspx", "Recaudo-16.gif");
	HTMLCode += AddImageItem("Auditoria", "../../Modules/ReportesEstacion/ReportesAuditoria.aspx", "");

			
	HTMLCode += GetPanelFooter();
	document.write(HTMLCode);
}

//Panel de Navegación para la PAGINA COMERCIALES
function PanelComerciales()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Comerciales", "Modulo Comerciales", "Comerciales-32.gif");
	HTMLCode += AddImageItem("Clientes", "../../Modules/Comerciales/Clientes.aspx", "Cliente-16.gif");
	HTMLCode += AddImageItem("Precios Diferenciales", "../../Modules/Comerciales/ListaPreciosDiferenciales.aspx", "FormaPago-16.gif");
			
	HTMLCode += GetPanelFooter();
	document.write(HTMLCode);
}

//Panel de Navegación para la PAGINA DE PROCESOS
function PanelProcesos()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Procesos", "M&#243dulo de Procesos", "Procesos-32.gif");
	HTMLCode += AddImageItem("Sincronizaci&#243n externa GNV", "../../Modules/Procesos/OpcionesGNV.aspx", "Sincronizar-16.gif");
	HTMLCode += AddImageItem("Archivos planos Contables", "../../Modules/Procesos/InterfazContable.aspx", "IContable-16.gif");
	HTMLCode += AddImageItem("Archivos planos de Recaudo GDO", "../../Modules/Procesos/InterfazRecaudoGDO.aspx", "Recaudo-16.gif");
	HTMLCode += AddImageItem("Ajuste de Pagos", "../../Modules/Procesos/AjustePago.aspx", "FormaPago-16.gif");
	HTMLCode += GetPanelFooter();
	document.write(HTMLCode);
}

//Panel de Navegación para la pagina de variaciones
function PanelVariacion()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Variaci&#243n", "M&#243dulo de variacion tanques/Balance de gas", "Tanques-32.gif");
	HTMLCode += AddImageItem("Mensajes para variaci&#243n de tanques", "../../Modules/Variaciones/Tanques.aspx", "mensaje-16.gif");
	HTMLCode += AddImageItem("Apertura o cierre zeta", "../../Modules/Variaciones/Zetas.aspx", "AbrirZeta-16.gif");
	HTMLCode += GetPanelFooter();
	document.write(HTMLCode);
}


//Panel de Navegación para la PAGINA PRINCIPAL
function PanelPrincipal()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("P&#225gina Principal", "Administraci&#243n de la Estaci&#243n", "automatizacion-32.gif");
	HTMLCode += AddImageItem("M&#243dulo de Reportes", "../../Modules/ReportesEstacion/Default.aspx", "Reportes-16.gif");
	HTMLCode += AddImageItem("M&#243dulo Panel de Control", "../../Modules/PanelControl/Default.aspx", "PanelControl-16.gif");
	HTMLCode += AddImageItem("M&#243dulo de Procesos", "../../Modules/Procesos/Default.aspx", "Procesos-16.gif");
	HTMLCode += AddImageItem("M&#243dulo Comerciales", "../../Modules/Comerciales/Default.aspx", "Comerciales-16.gif");
	HTMLCode += AddImageItem("M&#243dulo Variaciones", "../../Modules/Variaciones/Default.aspx", "Tanques-16.gif");
	HTMLCode += AddImageItem("M&#243dulo Consultas", "../../Modules/Consultas/Default.aspx", "ConsultaFactura_16.ico");
	//HTMLCode += AddImageItem2("Manual de Usuario", "../../Modules/General/Manual.pdf", "Manual-16.gif");			
	HTMLCode += GetPanelFooter();
	document.write(HTMLCode);
}


//Panel de Navegación para la pagina de variaciones
function PanelConsultas()
{
	var HTMLCode;
	
	HTMLCode = GetPanelHeader("Consultas", "M&#243dulo de Consultas", "Tanques-32.gif");
	HTMLCode += AddImageItem("Facturas Canastilla", "../../Modules/Consultas/FacturasCanastilla.aspx", "ConsultaFactura_16.ico");
	HTMLCode += GetPanelFooter();
	document.write(HTMLCode);
}

