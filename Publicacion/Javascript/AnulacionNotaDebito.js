    var caracter = window.Event ? true : false;
    
    function ValidarNumero(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || (key>= 48 && key <= 57) );
    }

    function ValidarNumeroDecimal(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || (key>= 48 && key <= 57) || key == 46);
    }

    function ValidarAlfanumerico(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || key == 95 (key>= 48 && key <= 57) || (key >= 65  && key <= 90) || (key >= 97  && key <= 122));
    }
      

    function Calcular(evento, caso)
    {    
        var key = caracter ? evento.which : evento.keyCode;
        if(key == 9)
            return            
        var total = parseFloat(window.document.getElementById('txtTotal').getAttribute("value"));
        var cantidad  =  parseFloat(window.document.getElementById('txtCantidad').getAttribute("value"));
        //var precio = parseFloat(window.document.getElementById('lblPrecio').innerText);
        var precio = parseFloat(window.document.getElementById('txtPrecio').getAttribute("value"));
        var resultado;
        switch(caso)
        {
            case "Total":
                resultado =  cantidad * precio;
                if(isNaN(resultado))
                    window.document.MyForm.txtTotal.value = 0
                else 
                    window.document.MyForm.txtTotal.value = resultado
                break;                            
            case "Cantidad":
                resultado = total / precio;
                if(isNaN(resultado))
                    window.document.MyForm.txtCantidad.value = 0
                else 
                    window.document.MyForm.txtCantidad.value = resultado
                    
                if(window.document.getElementById('txtCantidad').getAttribute("value") == "Infinity")
                    window.document.MyForm.txtCantidad.value = 0;
                break;            
        }       
        /*
        alert(total)
        alert(cantidad)
        alert(precio)
        alert(resultado)
        */
        
    }
    
    function moveVerticalScroll()
    {
        document.body.scrollTop=0;
        //window.onload=moveVerticalScroll;
    }



    
    function VentanaEmergente(caso)
    {
        switch(caso)
        {
            case "Tiquete":
                var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=TiqueteActivoAsignado','SelectValueWindow');              
                if(resultado != null)
                {
                    var arreglo = resultado.split('©');
                    document.getElementById("txtNumeroTiquete").value = arreglo[0];
                    __doPostBack('btnConsultarTiquete', '' );
                }
                break;            
            case "Articulo":
                var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=Articulo','SelectValueWindow');              
                if(resultado != null)
                {
                    var arreglo = resultado.split('©');
                    document.getElementById("txtCodigoArticulo").value = arreglo[0];
                    document.getElementById("lblDescripcionArticulo").value = arreglo[1];
                    document.getElementById("lblPresentacion").value = arreglo[2];
                    __doPostBack('btnConsultarArticulo', '' );
                }                
                break;           
            
                 
             case "Cliente":
                var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=Cliente','SelectValueWindow');
                if(resultado != null)
                {
                    var arreglo = resultado.split('©');
                    document.getElementById("txtIdentificacion").value = arreglo[0];
                    document.getElementById("lblNombreCliente").value = arreglo[1];
                    __doPostBack('btnConsultarCliente', '' );
                }                                
                break;
        }       
    }  
