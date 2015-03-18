 var caracter = window.Event ? true : false;
    function ValidarNumero(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key <= 13 || (key>= 48 && key <= 57));
    }
   
    function Calcular(evento, caso)
    {        
        var key = caracter ? evento.which : evento.keyCode;
        if(key == 9)
            return            

        var numeroInicial = parseInt(window.document.getElementById('txtNumeroInicial').getAttribute("value"));
        var catidad  =  parseInt(window.document.getElementById('txtCantidad').getAttribute("value"));        
        var numeroFinal  =  parseInt(window.document.getElementById('txtNumeroFinal').getAttribute("value"));        
        var resultado;
        if(caso == "1")
        {
            resultado = numeroInicial + catidad - 1;    
            if(isNaN(resultado))
                window.document.MyForm.txtNumeroFinal.value = 0;                
            else
                window.document.MyForm.txtNumeroFinal.value = resultado;
                
        }
        else
        {
            resultado = numeroFinal - numeroInicial + 1; 
            if(isNaN(resultado))
                window.document.MyForm.txtCantidad.value = 0;
            else
                window.document.MyForm.txtCantidad.value = resultado;
        }
    }

    function VentanaEmergente()
    {
        if(document.getElementById("txtIdentificacion").disabled == true)
            return;
        var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=ClienteParaVale','SelectValueWindow');              
        if(resultado != null)
        {
            var arreglo = resultado.split('©');
            document.getElementById("txtIdentificacion").value = arreglo[0];
            document.getElementById("txtNombreRazonSocial").value = arreglo[1];
            //document.getElementById("lblFormTitle").Text = arreglo[1];                        
        }
    }  
    
    function NoEdicion(evento)
    {   
        var key = caracter ? evento.which : evento.keyCode;           
        return (key > 300);
    }
