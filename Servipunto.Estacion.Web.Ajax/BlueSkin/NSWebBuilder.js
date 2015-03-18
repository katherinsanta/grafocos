//Tildes: a=&#225; e=&#233; i=&#237; o=&#243; u=&#250;

//Start Navigation Pane Management.
function HideNavigationPane()
{
}

function BuildNavigationPaneHeader()
{
	var HTMLCode;
	
	HTMLCode = "<!-- Navigation Pane -->";
	HTMLCode += "<td vAlign=top width=170 bgColor=#ffffff>";
		HTMLCode += "<br>";
		HTMLCode += "<table cellSpacing=0 cellPadding=2 width=170 border=0>";
			HTMLCode += "<!-- Start NavigationPane Items -->";
		
	document.write(HTMLCode);
}

function BuildNavigationPaneFooter()
{
	var HTMLCode;

			HTMLCode = "<!-- End NavigationPane Items -->";
			HTMLCode += "<tr>";
				HTMLCode += "<td><img height=10 src='../../BlueSkin/Images/spacer.gif' width=1 border=0></td>";
			HTMLCode += "</tr>";
		HTMLCode += "</table>";
	HTMLCode += "</td>";
	HTMLCode += "<!-- End Navigation Pane -->";

	document.write(HTMLCode);
}

function BuildLeftSplitter()
{
	var HTMLCode;
	
	HTMLCode = "<!-- Left Splitter -->";
	HTMLCode += "<td class=splitleft width=3><img height=1 src='../../BlueSkin/Images/spacer.gif' width=3 border=0></td>";
	HTMLCode += "<!-- End Left Splitter -->";
	
	document.write(HTMLCode);
}

function BuildRightSplitter()
{
	var HTMLCode;
	
	HTMLCode = "<!-- Right Splitter -->";
	HTMLCode += "<td class=splitright width=3><img height=1 src='../../BlueSkin/Images/spacer.gif' width=3 border=0></td>";
	HTMLCode += "<!-- End Right Splitter -->";
	
	document.write(HTMLCode);
}
//End Navigation Pane Management.

function GetPanelFooter()
{
	return "</ul></td></tr>";
}

function GetPanelHeader(title, shortDescription, image)
{
	var HTMLCode;
	
	image = "../../BlueSkin/Icons/" + image;
	
	HTMLCode = "<tr>";
		HTMLCode += "<td>";
			HTMLCode += "<table style='PADDING-LEFT: 5px' cellSpacing=0 cellPadding=0 border=0>";
				HTMLCode += "<tr>";
					HTMLCode += "<td><img height=32 src='" + image + "' width=32 border=0></td>";
					HTMLCode += "<td>";
						HTMLCode += "<b class=title>" + title + "</b>";
						HTMLCode += "<br>";
						HTMLCode += "<font style='COLOR: #8d9398'>" + shortDescription + "</font>";
					HTMLCode += "</td>";
				HTMLCode += "</tr>";
			HTMLCode += "</table>";
			HTMLCode += "<ul class=mainmenu>";
											
	return HTMLCode;
}

function AddItem(text, url)
{
	var HTMLCode;
	
	HTMLCode = "<li>";
		HTMLCode += "<div class=menu onmousedown=mDown('" + url + "') onmouseover=mOverMenu(this); onmouseout=mOutMenu(this);>"
			HTMLCode += text;
		HTMLCode += "</div>";
	HTMLCode += "</li>";
	
	return HTMLCode;
}

function AddImageItem(text, url, image)
{
	var HTMLCode;
	
	if (image == "")
	{
		return AddItem(text, url);	
	}
		
	HTMLCode = "<li>";
		HTMLCode += "<div class=menu style='LIST-STYLE-IMAGE: url(../../BlueSkin/Icons/" + image + ")' onmousedown=mDown('" + url + "') onmouseover=mOverMenu(this); onmouseout=mOutMenu(this);>"
			HTMLCode += text;
		HTMLCode += "</div>";
	HTMLCode += "</li>";
	
	return HTMLCode;
}

function AddImageItem2(text, url, image)
{
	var HTMLCode;
	
	if (image == "")
	{
		return AddItem(text, url);	
	}
		
	HTMLCode = "<li>";
		HTMLCode += "<div class=menu style='LIST-STYLE-IMAGE: url(../../BlueSkin/Icons/" + image + ")' onmouseover=mOverMenu(this); onmouseout=mOutMenu(this);>";
			HTMLCode += "<a style='color: black' href='" + url + "' target='_blank'>";
			HTMLCode += text;
			HTMLCode += "</a>";
		HTMLCode += "</div>";
	HTMLCode += "</li>";
	
	return HTMLCode;
}

//Another Sections.
function BuildTopicHeader(title, shortDescription, image, userName)
{
	var HTMLCode;
	
	HTMLCode = "<table class=pageheading cellSpacing=0 cellPadding=5 width='100%' bgColor=#0347bf border=0>";
		HTMLCode += "<tr>";
			HTMLCode += "<td width=48>";
				HTMLCode += "<img height=48 src='" + image + "' width=48 border=0>";
			HTMLCode += "</td>";
			HTMLCode += "<td class=pageheading noWrap height=61>";
				HTMLCode += "<font class=title>" + title + "</font>";
				HTMLCode += "<br>" + shortDescription
			HTMLCode += "</td>";
			HTMLCode += "<td vAlign=top align=right width='100%'>";
				if (userName != "") {
					HTMLCode += "<font color='#ffffff'>" + userName + "</font>";
				}
				HTMLCode += "<div style='PADDING-TOP: 3px'>";
					HTMLCode += "<a class=whitebold href='Default.aspx'>Acciones</a>";
					if (userName != "")
					{
						HTMLCode += "<img height=11 src='../../BlueSkin/Images/pipe_white.gif' width=11>";
						HTMLCode += "<a class=whitebold href='../../Modules/Main/Login.aspx?LogOff=true'>Cerrar Sesi&#243;n</a>";
					}
					
				HTMLCode += "</div>";
			HTMLCode += "</td>";
		HTMLCode += "</tr>";
	HTMLCode += "</table>";
	
	document.write(HTMLCode);
}

function BuildBottomSplitter()
{
	var HTMLCode;
	
	HTMLCode = "<tr>";
		HTMLCode += "<td valign=top>";
			HTMLCode += "<table cellSpacing=0 cellPadding=0 width='100%' bgColor=#a4c2f5 border=0>";
				HTMLCode += "<tr>";
					HTMLCode += "<td width=3><img height=4 src='../../BlueSkin/Images/spacer.gif' width=3 border=0></td>";
					HTMLCode += "<td class=splitbottom width=172><img height=4 src='../../BlueSkin/Images/spacer.gif' width=172 border=0></td>";
					HTMLCode += "<td width=3><img height=4 src='../../BlueSkin/Images/spacer.gif' width=3 border=0></td>";
					HTMLCode += "<td class=splitbottom><img height=4 src='../../BlueSkin/Images/spacer.gif' width=3 border=0></td>";
				HTMLCode += "</tr>";
			HTMLCode += "</table>";
		HTMLCode += "</td>";
	HTMLCode += "</tr>";
			
	document.write(HTMLCode);
}

function BuildFooter(title, shortDescription, image)
{
	var HTMLCode;
	
	HTMLCode = "<tr>";
		HTMLCode += "<td class='footer' align='middle' valign=top width='100%'>";
			HTMLCode += "<br>";
			HTMLCode += GetWebSiteFooter(); 
			HTMLCode += "<br><br>";
		HTMLCode += "</td>";
	HTMLCode +="</tr>";
	
	document.write(HTMLCode);
}

function GetWebSiteFooter()
{
	var HTMLCode;
	
	HTMLCode = "Versi&#243n 5.6.0";
	HTMLCode += "&nbsp; [ ";
	HTMLCode += "<a class='whitebold' href='Default.aspx'>Aviso Legal</a>";
	HTMLCode += " | ";
	HTMLCode += "<a class='whitebold' href='Default.aspx'>Privacidad</a>";
	HTMLCode += " ]";
	HTMLCode += "<br>";
	//HTMLCode += "Please direct your questions or comments to ";
	HTMLCode += "Copyright 2012 Zencillo de Software S.A.S. Todos los Derechos Reservados.";
	//HTMLCode += "<a class='white' href='mailto:webmaster@servipunto.com'>webmaster@servipunto.com</a>";

	return HTMLCode;
}