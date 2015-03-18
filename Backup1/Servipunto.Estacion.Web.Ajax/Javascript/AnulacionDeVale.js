var caracter = window.Event ? true : false;
    function ValidarNumero(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || (key>= 48 && key <= 57));
    }
   
    function NoEdicion(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key > 300);
    }   
   
    function Calcular(evento, caso)
    {        
        var key = caracter ? evento.which : evento.keyCode;
        if(key == 9)
            return            

        var numeroInicial = parseInt(window.document.getElementById('ctl00$ContenidoMaestro1$txtNumeroInicial').getAttribute("value"));
        var catidad  =  parseInt(window.document.getElementById('ctl00$ContenidoMaestro1$txtCantidad').getAttribute("value"));        
        var numeroFinal  =  parseInt(window.document.getElementById('ctl00$ContenidoMaestro1$txtNumeroFinal').getAttribute("value"));        
        var resultado;
        if(caso == "1")
        {
            resultado = numeroInicial + catidad - 1;    
            if(isNaN(resultado))
                document.getElementById("ctl00$ContenidoMaestro1$txtNumeroFinal").value =0;
                //window.document.MyForm.ctl00$ContenidoMaestro1$txtNumeroFinal.value = 0;                
            else
                document.getElementById("ctl00$ContenidoMaestro1$txtNumeroFinal").value =resultado;
                //window.document.MyForm.ctl00$ContenidoMaestro1$txtNumeroFinal.value = resultado;
                
        }
        else
        {
            resultado = numeroFinal - numeroInicial + 1; 
            if(isNaN(resultado))
                document.getElementById("ctl00$ContenidoMaestro1$txtCantidad").value =0;
                //window.document.MyForm.ctl00$ContenidoMaestro1$txtCantidad.value = 0;
            else
                document.getElementById("ctl00$ContenidoMaestro1$txtCantidad").value =resultado;
                //window.document.MyForm.ctl00$ContenidoMaestro1$txtCantidad.value = resultado;
        }
    }
    
    function VentanaEmergente()
    {
        if(document.getElementById("ctl00$ContenidoMaestro1$txtIdentificacion").disabled == true)
            return;
        var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=ClienteParaVale',window,'dialogWidth:790px;dialogHeight:520px;resizable:no;center:yes');             
        if(resultado != null)
        {
            var arreglo = resultado.split('©');
            document.getElementById("ctl00$ContenidoMaestro1$txtIdentificacion").value = arreglo[0];
            document.getElementById("ctl00$ContenidoMaestro1$txtNombreRazonSocial").value = arreglo[1];
            //document.getElementById("lblFormTitle").Text = arreglo[1];                        
        }
    }
    
    function NoEdicion(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key > 300);
    }         
