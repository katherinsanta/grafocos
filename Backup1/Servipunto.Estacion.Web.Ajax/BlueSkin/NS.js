//Generic Functions for the Web User Interface Management.

function mOver(menuItem)
{
	menuItem.style.cursor = 'hand';
	menuItem.style.color = '#ffd275';
}

function mOut(menuItem)
{
	menuItem.style.cursor = 'default';
	menuItem.style.color = '#ffffff';
}

function mOverMenu(menuItem)
{
	menuItem.style.cursor = 'hand';
	menuItem.style.borderColor = "#9d9d9d";
	menuItem.style.backgroundColor = "#f1f1f1";
	menuItem.style.color = "#000000";
}

function mOutMenu(menuItem)
{
	menuItem.style.cursor = 'default';
	menuItem.style.borderColor = "#ffffff";
	menuItem.style.backgroundColor = "#ffffff";
	menuItem.style.color = "#000000";
}

function mDown(url)
{
	window.location = url;
}

//To Remove Them...
function GetDay(iDay) {
	var DayArray = new Array("Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado") ;
	return DayArray[iDay] ;
}

function GetMonth(iMonth) {
	var arMonth = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio","Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre") ;
	return arMonth[iMonth] ;
}

function GetYear(year) {
	if (year < 2000) {
		year = year + 1900;
	}
	return year;
}

function getDateStrWithDOW() {
	var today = new Date() ;
	var mon = GetMonth(today.getMonth()) ;
	var day = GetDay(today.getDay()) ;
	var year = GetYear(today.getYear()) ;
	var hours = today.getHours() ;
	return ('<font color=\"#ffffff\">' + day + ', ' + mon + ' ' + today.getDate() + ', ' + year + '</font>') ;
}


function PrintCurrentUser() {
	return ('<font color=\"#ffffff\">' + 'Carlos Ariel Berm&#250;dez Cort&#233;s' + '</font>') ;
}

//Tildes: a=&#225; e=&#233; i=&#237; o=&#243; u=&#250;
