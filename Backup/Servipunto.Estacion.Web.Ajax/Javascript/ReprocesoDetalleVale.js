/* REPROCESO DETALLE VALE */
  var caracter = window.Event ? true : false;
    function ValidarNumero(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || (key>= 48 && key <= 57));
    }
    
    function ValidarNumeroDecimal(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        //if(key == 44)
            //key = 46;
        return (key <= 13 || (key>= 48 && key <= 57) || key == 46);
    }
    
    function CalcularValorFinal()
    {        
        var numeroInicial = parseInt(window.document.getElementById('ctl00$ContenidoMaestro1$txtNumeroInicial').getAttribute("value"));
        var catidad  =  parseInt(window.document.getElementById('ctl00$ContenidoMaestro1$txtCantidad').getAttribute("value"));        
        if(numeroInicial > 0 && catidad > 0)
            window.document.MyForm.ctl00$ContenidoMaestro1$txtNumeroFinal.value = numeroInicial + catidad - 1;    
        else 
            window.document.MyForm.ctl00$ContenidoMaestro1$txtNumeroFinal.value = "Ninguno";
    }
    
  