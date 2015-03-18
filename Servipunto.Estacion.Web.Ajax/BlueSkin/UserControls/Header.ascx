<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Servipunto.Cartera.Web.BlueSkin.UserControls.Header" %>
<script type="text/javascript" language="JavaScript">
    var caracter = window.Event ? true : false;    

        /// Descipcion: Valida que los caracteres ingresados sean correctos para un numero entero
        /// caso 1: Decimal normal, caso 2: Decimal monetario
        /// Referencia Documental: (Falta)
        /// Fecha: 03/08/2009
        /// Autor: Elvis Astaiza        
    function ValidarNumeroEntero(evento)
    { 
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || (key>= 48 && key <= 57));
    }
    
        /// Descipcion: Valida que los caracteres ingresados sean correctos para un numero decimal
        /// caso 1: Decimal normal, caso 2: Decimal monetario
        /// Referencia Documental: (Falta)
        /// Fecha: 03/08/2009
        /// Autor: Elvis Astaiza        
    function ValidarNumeroDecimal(evento, caso)
    {              
        var key = caracter ? evento.which : evento.keyCode;                                 
        var valor               
        switch(caso)
        {
            case "1":
                valor = <%=Session["SeperadorDecimal"]%>;
                break;
                
            case "2":
                valor = <%=Session["SeperadorDecimalMoneda"]%>;
                break;
        }
        if(key == 44  || key == 46)
        {            
            evento.keyCode = valor;            
            return evento.keyCode;
        }
        return (key <= 13 || (key>= 48 && key <= 57));                     
    }  
    
        /// Descipcion: Valida que los caracteres ingresados sean correctos para una cadena alfanumerica
        /// caso 1: Decimal normal, caso 2: Decimal monetario
        /// Referencia Documental: (Falta)
        /// Fecha: 03/08/2009
        /// Autor: Elvis Astaiza            
    function ValidarAlfanumerico(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || key == 95 (key>= 48 && key <= 57) || (key >= 65  && key <= 90) || (key >= 97  && key <= 122));
    }
             
        /// Descipcion: Convierte un tipo de dato moneda en un tipo de dato flotante en cadena
        /// caso 1: Decimal normal, caso 2: Decimal monetario
        /// Referencia Documental: (Falta)
        /// Fecha: 03/08/2009
        /// Autor: Elvis Astaiza                         
    function ConvertirCadenaADecimal(cadena, caso)
    {        
        var arreglo;        
        var codigoAscci;
        var resultado = "";
        var separador = "";
        
        if(caso == 1)
            separador = <%=Session["SeperadorDecimal"]%>;
        else
            separador = <%=Session["SeperadorDecimalMoneda"]%>;               
        arreglo = cadena.split('');
        for(i=0; i<arreglo.length; i++)
        {        
            codigoAscci = arreglo[i].charCodeAt(0)
            if(codigoAscci >= 48 &&  codigoAscci <= 57)
                resultado += String.fromCharCode(codigoAscci);
            else if(codigoAscci == separador)
                resultado += ".";
        }        
        return parseFloat(resultado);
    }	
             
        /// Descipcion: Convierte un tipo de dato flotante a un tipo de datos moneda en cadena
        /// caso 1: Decimal normal, caso 2: Decimal monetario
        /// Referencia Documental: (Falta)
        /// Fecha: 03/08/2009
        /// Autor: Elvis Astaiza                         
    function ConvertirDecimalACadena(flotante, caso)
    {        
        var arreglo;        
        var codigoAscci;
        var resultado = "";
        var separador = "";
        
        if(caso == 1)
            separador = <%=Session["SeperadorDecimal"]%>;
        else
            separador = <%=Session["SeperadorDecimalMoneda"]%>;               
        arreglo = flotante.toString().split('');        
        for(i=0; i<arreglo.length; i++)
        {        
            codigoAscci = arreglo[i].charCodeAt(0)
            if(codigoAscci >= 48 &&  codigoAscci <= 57)
                resultado += String.fromCharCode(codigoAscci);
            else if(arreglo[i] == ".")
                resultado += String.fromCharCode(separador);;
        }        
        return resultado;                
    }	

             
  </script>  
  <!-- Page Header -->
<tr>
	<td>
		<!-- Logo's Section -->
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td colSpan="2">
					<table cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td align="center"><A href="../../Modules/Main/Default.aspx"><IMG border="0" src="../../BlueSkin/Images/Logo.jpg"></A></td>
							<td align="right">
								<OBJECT codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
									height="59" width="820" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>
									<PARAM NAME="_cx" VALUE="21696">
									<PARAM NAME="_cy" VALUE="1561">
									<PARAM NAME="FlashVars" VALUE="">
									<PARAM NAME="Movie" VALUE="../../BlueSkin/Icons/banner.swf">
									<PARAM NAME="Src" VALUE="../../BlueSkin/Icons/banner.swf">
									<PARAM NAME="WMode" VALUE="Window">
									<PARAM NAME="Play" VALUE="-1">
									<PARAM NAME="Loop" VALUE="-1">
									<PARAM NAME="Quality" VALUE="High">
									<PARAM NAME="SAlign" VALUE="">
									<PARAM NAME="Menu" VALUE="-1">
									<PARAM NAME="Base" VALUE="">
									<PARAM NAME="AllowScriptAccess" VALUE="">
									<PARAM NAME="Scale" VALUE="ShowAll">
									<PARAM NAME="DeviceFont" VALUE="0">
									<PARAM NAME="EmbedMovie" VALUE="0">
									<PARAM NAME="BGColor" VALUE="">
									<PARAM NAME="SWRemote" VALUE="">
									<PARAM NAME="MovieData" VALUE="">
									<PARAM NAME="SeamlessTabbing" VALUE="1">
									<PARAM NAME="Profile" VALUE="0">
									<PARAM NAME="ProfileAddress" VALUE="">
									<PARAM NAME="ProfilePort" VALUE="0">
									<PARAM NAME="AllowNetworking" VALUE="all">
									<PARAM NAME="AllowFullScreen" VALUE="false">
									<!--<embed src="../../BlueSkin/Icons/banner.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
										type="application/x-shockwave-flash" width="820" height="59"> </embed> 
									-->
								</OBJECT>
							</td>
							<td align="center" width="100%" background="../../BlueSkin/Images/spacer.gif"></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="middle" align="right" colSpan="2"><asp:label id="lblCompania" ForeColor="gray" Visible="True" runat="server">Servipunto de Software</asp:label></td>
			</tr>
		</table>
		<!-- End Logo's Section -->
		<!-- Top Menu -->
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td align="center" bgColor="#2e52af" colSpan="3"><IMG height="1" src="../../BlueSkin/Images/spacer.gif" width="1" border="0"></td>
			</tr>
			<tr>
				<!-- Top Left Items -->
				<td background="../../BlueSkin/Images/dark_blue_back.gif" bgColor="#000080">
					<table cellSpacing="0" cellPadding="3" border="0">
						<tr>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/Home16.ico" width="16" border="0">
							</td>
							<td vAlign="middle"><A class="whitebold" href="../../Modules/Main/Default.aspx">Página 
									Principal</A>
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0">
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/Reportes16.ico" width="16" border="0">
							</td>
							<td vAlign="middle"><A class="whitebold" href="../../Modules/ReportesEstacion/Default.aspx">Reportes</A>
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0">
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/PanelControl16.ico" width="16" border="0">
							</td>
							<td vAlign="middle"><A class="whitebold" href="../../Modules/PanelControl/Default.aspx">Panel 
									de Control</A>
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0">
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/Procesos-16.ico" width="16" border="0">
							</td>
							<td vAlign="middle"><A class="whitebold" href="../../Modules/Procesos/Default.aspx">Procesos</A>
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0">
							</td>
							<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/Comerciales-16.ico" width="16" border="0">
							</td>
							<td vAlign="middle"><A class="whitebold" href="../../Modules/Comerciales/Default.aspx">Comerciales</A>
							</td>
							<TD vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0"></TD>
							<TD vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/Tanques-16.png" width="16" border="0"></TD>
							<TD vAlign="middle">&nbsp;<A class="whitebold" href="../../Modules/Variaciones/Default.aspx">Variaciones</A></TD>							
							
							<TD vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0"></TD>
							<TD vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/ConsultaFactura_16.ico" width="16" border="0"></TD>
							<TD vAlign="middle">&nbsp;<A class="whitebold" href="../../Modules/Consultas/Default.aspx">Consultas</A></TD>							
							
						</tr>
					</table>
				</td>
				<!-- End Top Left Items -->
				<!-- Top Right Items -->
				<td align="right" background="../../BlueSkin/Images/dark_blue_back.gif" bgColor="#000080">
					<table cellSpacing="0" cellPadding="0" border="0">
						<tr>
							<td id="LogOnTD" runat="server">
								<table cellSpacing="0" cellPadding="3" border="0">
									<tr>
                                        <td valign="middle">
                                            &nbsp;</td>
										<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/LogOn16.ico" width="16" border="0">
										</td>
										<td vAlign="middle"><A class="whitebold" href="../../Modules/Main/Login.aspx">Iniciar 
												Sesión</A>
										</td>
									</tr>
								</table>
							</td>
							<td id="LogOffTD" runat="server">
								<table cellSpacing="0" cellPadding="3" border="0">
									<tr>
										<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/LogOff16.ico" width="16" border="0">
										</td>
										<td vAlign="middle"><A class="whitebold" href="../../Modules/Main/Login.aspx?LogOff=true">Cerrar 
												Sesión</A>
										</td>
										<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0">
										</td>
									</tr>
								</table>
							</td>
							<td id="UserNameTD" runat="server">
								<table cellSpacing="0" cellPadding="3" border="0">
									<tr>
										<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/Key-16.ico" width="16" border="0">
										</td>
										<td valign="middle"><A class="whitebold" href="../../Modules/Main/CambiarContrasena.aspx" title="Cambiar Contraseña">
												Contraseña</A>
										</td>
										<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Images/top_blue_separator.gif" width="2" border="0">
										</td>
										<td vAlign="middle"><IMG height="16" src="../../BlueSkin/Icons/Usuario16.ico" width="16" border="0">
										</td>
										<td vAlign="middle"><asp:label id="lblUserName" ForeColor="White" Visible="True" runat="server" Font-Bold="True"
												CssClass="whitebold">User Name</asp:label></td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
				<!-- End Top Right Items --></tr>
		</table>
		<!-- End Top Menu -->
		<!-- Splitter Top -->
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td class="ltblue" width="3"><IMG height="4" src="../../BlueSkin/Images/spacer.gif" width="3" border="0"></td>
				<td class="ltblueborder" align="center" width="172"><IMG height="4" src="../../BlueSkin/Images/spacer.gif" width="172" border="0"></td>
				<td class="ltblue" width="3"><IMG height="4" src="../../BlueSkin/Images/spacer.gif" width="3" border="0"></td>
				<td class="ltblueborder"><img height="4" src="../../BlueSkin/Images/spacer.gif" width="3" border="0"></td>
			</tr>
		</table>
		<!-- End Splitter Top --></td>
</tr>
<!-- End Page Header -->