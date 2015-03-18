function ActivarTab(elemID)
{				
	var elem = (document.all) ? document.all(elemID) : document.getElementById(elemID)
	if (elem.className == "tabOff") 
	{
		elem.className = "tabOn";
	}
}

function DesactivarTab(elemID)
{
	var elem = (document.all) ? document.all(elemID) : document.getElementById(elemID)
	if (elem.className == "tabOn" && elemID != document.forms[0].ActiveTab.value)
	{
		elem.className = "tabOff";
	}
}

function OcultarFila(elemID)
{
	var elem = (document.all) ? document.all(elemID) : document.getElementById(elemID)
		elem.className = "Oculto";
}

function MostrarFila(elemID)
{
	var elem = (document.all) ? document.all(elemID) : document.getElementById(elemID)
		elem.className = "Visible";
}

function SelectTab(elemID)
{
	switch (elemID)
	{	
		case "Estandar":
			document.forms[0].ActiveTab.value = 'Estandar';
			ActivarTab('Estandar');
			DesactivarTab('SAP');
			DesactivarTab('CabeceraTraslados');
			DesactivarTab('CabeceraTraslados');
			DesactivarTab('Varios');
			
			MostrarFila('filaEstandar');
			OcultarFila('FilaCabeceraVentas');
			OcultarFila('filaSAP');
			OcultarFila('FilaCabeceraTraslados');
			OcultarFila('filaVarios');
			
		break;
		
		case "SAP":
			document.forms[0].ActiveTab.value = 'SAP';
			ActivarTab('SAP');
			DesactivarTab('Estandar');
			DesactivarTab('CabeceraTraslados');
			DesactivarTab('Varios');
			DesactivarTab('CabeceraTraslados');
			OcultarFila('filaEstandar');
			
			MostrarFila('FilaCabeceraVentas');			
			MostrarFila('filaSAP');
			OcultarFila('FilaCabeceraTraslados');
			OcultarFila('filaVarios');
			break;
		
		case "CabeceraVentas":
			document.forms[0].ActiveTab.value = 'CabeceraVentas';
			ActivarTab('CabeceraVentas');		
			DesactivarTab('CabeceraTraslados');
			DesactivarTab('Varios');
			DesactivarTab('Estandar');
			OcultarFila('filaEstandar');
			OcultarFila('FilaCabeceraTraslados');
			
			MostrarFila('FilaCabeceraVentas');			
			MostrarFila('filaSAP');	
			OcultarFila('filaVarios');
					
		break;							
		
		case "CabeceraTraslados":
			document.forms[0].ActiveTab.value = 'CabeceraTraslados';
			ActivarTab('CabeceraTraslados');
			DesactivarTab('CabeceraVentas');
			DesactivarTab('Varios');
			DesactivarTab('Estandar');
			OcultarFila('filaEstandar');
			OcultarFila('FilaCabeceraVentas');		
			
			MostrarFila('filaSAP');		
			MostrarFila('FilaCabeceraTraslados');			
			OcultarFila('filaVarios');
		break;							
		

		case "Varios":
			document.forms[0].ActiveTab.value = 'Varios';
			ActivarTab('Varios');
			DesactivarTab('CabeceraVentas');
			DesactivarTab('CabeceraTraslados');
			DesactivarTab('Estandar');
			OcultarFila('filaEstandar');
			OcultarFila('FilaCabeceraVentas');		
			
			MostrarFila('filaSAP');		
			MostrarFila('filaVarios');			
			OcultarFila('FilaCabeceraTraslados');
		break;							

		
	}
}