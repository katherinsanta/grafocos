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
		case 'Lotes':
			document.forms[0].ActiveTab.value = 'Lotes';
			DesactivarTab('General');
			ActivarTab('Lotes');
			OcultarFila('filaGenerales');
			MostrarFila('filaLotes');
		break;						
		
		default:
			document.forms[0].ActiveTab.value = 'General';
			ActivarTab('General');
			DesactivarTab('Lotes');
			MostrarFila('filaGenerales');
			OcultarFila('filaLotes');
		break;
	}
}
