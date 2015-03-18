using System;
using System.Collections.Generic;
using System.Text;

namespace Servipunto.Estacion.Libreria.Prepagos
{
    public class Denominacion
    {
        #region Sección de Declaraciones      
        decimal _valorDenominacion;
        #endregion

        public decimal ValorDenominacion
        {
            get { return _valorDenominacion; }
            set { _valorDenominacion = value; }
        }


    }
    
}
