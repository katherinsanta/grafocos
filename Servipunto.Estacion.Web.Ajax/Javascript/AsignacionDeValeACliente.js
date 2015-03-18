function CalcularValorFinal()
    {        
        var numeroInicial = parseInt(window.document.getElementById('txtNumeroInicial').getAttribute("value"));
        var catidad  =  parseInt(window.document.getElementById('txtCantidad').getAttribute("value"));        
        if(numeroInicial > 0 && catidad > 0)
            window.document.MyForm.txtNumeroFinal.value = numeroInicial + catidad - 1;    
        else 
            window.document.MyForm.txtNumeroFinal.value = "Ninguno";
    }
    
    function VentanaEmergente()
    {
        var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=ClienteParaVale','SelectValueWindow');              
        if(resultado != null)
        {
            var arreglo = resultado.split('©');
            document.getElementById("txtIdentificacion").value = arreglo[0];
            document.getElementById("txtNombreRazonSocial").value = arreglo[1];
            //document.getElementById("lblFormTitle").Text = arreglo[1];                        
        }
    }  
