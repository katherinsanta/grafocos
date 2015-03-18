function AbrirVentana(mylink, windowname, InicialX, InicialY, Ancho, Largo)
{
	if (! window.focus)
		return true;
	var href;

	if (typeof(mylink) == 'string')
		href=mylink;
	else
		href=mylink.href;
   
	window.open(href,windowname,"top=" + InicialY + ",left=" + InicialX +
	",height=" + Largo + ",width=" + Ancho + ",status=no,toolbar=no,menubar=no,location=no");
	
	return false;
}

function AbrirVentanaCompleto(MyLink,Nombre,InicialX,InicialY,Ancho,Alto,ToolBar,Resizable,
Directories,Status,MenuBar,ScrollBars,Location)
{
	if (! window.focus)
		return true;
	var href;

	if (typeof(MyLink) == 'string')
		href=MyLink;
	else
		href=MyLink.href;
		
	window.open(MyLink,Nombre,'left=' + InicialX + ',top=' + InicialY + ',width=' + 
	Ancho + ',height=' + Alto + ',toolbar=' + ToolBar + ',resizable=' + Resizable + 
	',directories=' + Directories + ',status=' + Status + ',menubar=' + MenuBar + 
	',scrollbars=' + ScrollBars + ',Location=' + Location);
	
	return false;
}

function AbrirVentanaCentrada(MyLink,Nombre,Ancho,Alto,ToolBar,Resizable,
Directories,Status,MenuBar,ScrollBars,Location)
{
	if (! window.focus)
		return true;
	
	var href;

	if (typeof(MyLink) == 'string')
		href=MyLink;
	else
		href=MyLink.href;
		
	var InicialX;
	var InicialY;

	InicialX = (screen.availWidth+8)/2 - Ancho/2;
	InicialY = (screen.availHeight+8)/2 - Alto/2;
	
	window.open(MyLink,Nombre,'left=' + InicialX + ',top=' + InicialY + ',width=' + 
	Ancho + ',height=' + Alto + ',toolbar=' + ToolBar + ',resizable=' + Resizable + 
	',directories=' + Directories + ',status=' + Status + ',menubar=' + MenuBar + 
	',scrollbars=' + ScrollBars + ',Location=' + Location);
	
	return false;
}

function resizeOuterTo(w,h)
{
	if (parseInt(navigator.appVersion)>3)
	{
		if (navigator.appName=="Netscape")
		{
			top.outerWidth=w;
			top.outerHeight=h;
		}
		else
			top.resizeTo(w,h);
	}
}
		
function MaximizeWindow()
{
	if (parseInt(navigator.appVersion)>3)
	{
		if (navigator.appName=="Netscape")
		{
			if (top.screenX>0 || top.screenY>0)
				top.moveTo(0,0);
			if (top.outerWidth < screen.availWidth)
				top.outerWidth=screen.availWidth;
			if (top.outerHeight < screen.availHeight) 
				top.outerHeight=screen.availHeight;
		}
		else
		{
			top.moveTo(-4,-4);
			top.resizeTo(screen.availWidth+8,screen.availHeight+8);
		}
	}
}

function SeleccionarItem(nombre, nombrecontrol)
{
	var obj = window.parent.opener.document.getElementsByName(nombrecontrol);
	obj[0].value = nombre;
	window.close();
}

function Evaluar_check(direccion,controlcheck,nombrecontrol)
{
	var obj = document.getElementsByName(controlcheck);
	var obj2 = document.getElementsByName(nombrecontrol);
	
	if (obj[0].checked != true)
	{
		var querystring = direccion + '?Buscar=' + obj2[0].value;
		return AbrirVentanaCentrada(querystring,'VentanaBusqueda',550,305,0,1,0,0,0,1,0);		
	}
}

function AsignarRuta(nombrecontrol, Archivo)
{
	if(document.all["inputFile"].value != '')
	{
		if(Archivo == 0)
		{
			var indice = document.all["inputFile"].value.lastIndexOf('\\') + 1;
			var ruta = document.all["inputFile"].value.substring(0, indice);
			SeleccionarItem(ruta, nombrecontrol);
		}
		else
			SeleccionarItem(document.all["inputFile"].value, nombrecontrol);
	}
	else
		window.close();
}