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
		case "General":
			document.forms[0].ActiveTab.value = 'General';
			ActivarTab('General');
			DesactivarTab('Configuracion');
			//DesactivarTab('Tributario');
			DesactivarTab('Descuentos');
			DesactivarTab('Descuentos');
			DesactivarTab('Otros');
			DesactivarTab('Generar');
			
			MostrarFila('filaGenerales');
			OcultarFila('filaConfiguracion');
			//OcultarFila('filaTributario');
			OcultarFila('filaOtros');
			OcultarFila('filaDescuentos');
			OcultarFila('filaGas');
			OcultarFila('filaGenerar');
		break;
		
		case "Configuracion":
			document.forms[0].ActiveTab.value = 'Configuracion';
			DesactivarTab('General');
			ActivarTab('Configuracion');
			//DesactivarTab('Tributario');
			DesactivarTab('Descuentos');
			DesactivarTab('Gas');
			DesactivarTab('Otros');
			DesactivarTab('Generar');
			
			OcultarFila('filaGenerales');
			MostrarFila('filaConfiguracion');
			//OcultarFila('filaTributario');
			OcultarFila('filaOtros');
			OcultarFila('filaDescuentos');
			OcultarFila('filaGas');
			OcultarFila('filaGenerar');
		break;
		
		/*case "Tributario":
			document.forms[0].ActiveTab.value = 'Tributario';
			DesactivarTab('General');
			DesactivarTab('Configuracion');
			ActivarTab('Tributario');
			DesactivarTab('Generar');
			
			DesactivarTab('Descuentos');
			DesactivarTab('Gas');
			OcultarFila('filaGenerales');
			OcultarFila('filaConfiguracion');
			MostrarFila('filaTributario');
			OcultarFila('filaDescuentos');
			OcultarFila('filaGas');
			OcultarFila('filaGenerar');
		break;*/
		
		case "Descuentos":
			document.forms[0].ActiveTab.value = 'Descuentos';
			DesactivarTab('General');
			DesactivarTab('Configuracion');
			//DesactivarTab('Tributario');
			ActivarTab('Descuentos');
			DesactivarTab('Gas');
			DesactivarTab('Otros');
			DesactivarTab('Generar');
			
			OcultarFila('filaGenerales');
			OcultarFila('filaConfiguracion');
			//OcultarFila('filaTributario');
			OcultarFila('filaOtros');
			MostrarFila('filaDescuentos');
			OcultarFila('filaGas');
			OcultarFila('filaGenerar');
		break;
		
		case "Gas":
			document.forms[0].ActiveTab.value = 'Gas';
			DesactivarTab('General');
			DesactivarTab('Configuracion');
		//	DesactivarTab('Tributario');
			DesactivarTab('Descuentos');
			DesactivarTab('Otros');
			DesactivarTab('Generar');
			
			ActivarTab('Gas');
			OcultarFila('filaGenerales');
			OcultarFila('filaConfiguracion');
			//OcultarFila('filaTributario');
			OcultarFila('filaDescuentos');
			OcultarFila('filaOtros');			
			MostrarFila('filaGas');
			OcultarFila('filaGenerar');
		break;							
		
		case "Generar":
			document.forms[0].ActiveTab.value = 'Generar';
			DesactivarTab('General');
			DesactivarTab('Configuracion');
		//	DesactivarTab('Tributario');
			DesactivarTab('Descuentos');
			DesactivarTab('Gas');
			DesactivarTab('Otros');
			ActivarTab('Generar');
			

			OcultarFila('filaGenerales');
			OcultarFila('filaConfiguracion');
			//OcultarFila('filaTributario');
			OcultarFila('filaDescuentos');
			OcultarFila('filaGas');
			OcultarFila('filaOtros');
			MostrarFila('filaGenerar');
		break;	

		case "Otros":
			document.forms[0].ActiveTab.value = 'Otros';
			DesactivarTab('General');
			DesactivarTab('Configuracion');
		//	DesactivarTab('Tributario');
			DesactivarTab('Descuentos');
			DesactivarTab('Gas');
			ActivarTab('Otros');
			DesactivarTab('Generar');
			
			OcultarFila('filaGenerales');
			OcultarFila('filaConfiguracion');
			//OcultarFila('filaTributario');
			OcultarFila('filaDescuentos');
			OcultarFila('filaGas');
			MostrarFila('filaOtros');
			OcultarFila('filaGenerar');
		break;	
				
	}
}