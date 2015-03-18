
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
		case "CuentaEstandar":
			document.forms[0].ActiveTab.value = 'CuentaEstandar';
			ActivarTab('CuentaEstandar');
			DesactivarTab('CuentaSAP');
			
			MostrarFila('FilaCuentaEstandar');
			OcultarFila('FilaCuentaSAP');
			
			break;
		
		case "CuentaSAP":
			document.forms[0].ActiveTab.value = 'CuentaSAP';
			ActivarTab('CuentaSAP');
			DesactivarTab('CuentaEstandar');
			
			MostrarFila('FilaCuentaSAP');
			OcultarFila('FilaCuentaEstandar');
				
			break;
		
		default:
			DesactivarTab('CuentaSAP');
			OcultarFila('FilaCuentaEstandar');
			DesactivarTab('CuentaEstandar');
			OcultarFila('FilaCuentaSAP');		
		break
		
		
	}
}