
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
		case "Tab1x":
			document.forms[0].ActiveTab.value = 'Tab1x';
			ActivarTab('Tab1x');
			DesactivarTab('Tab2x');
			
			MostrarFila('FilaTab1');
			OcultarFila('FilaTab2');
			
			break;
		
		case "Tab2x":
			document.forms[0].ActiveTab.value = 'Tab2x';
			ActivarTab('Tab2x');
			DesactivarTab('Tab1x');
			
			MostrarFila('FilaTab2');
			OcultarFila('FilaTab1');
				
			break;
		
		/*default:
			DesactivarTab('Tab2x');
			OcultarFila('FilaTab2');
			DesactivarTab('Tab2x');
			OcultarFila('FilaTab2');		
		break
		*/
		
	}
}