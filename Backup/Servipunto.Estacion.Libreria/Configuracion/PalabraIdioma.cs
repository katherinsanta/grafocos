using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    public class PalabraIdioma
    {
        #region variables publicas
        int _codigo;
        string _palabra;
        string _traduccion;
        #endregion

        #region Propiedades
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Palabra
        {
            get { return _palabra; }
            set { _palabra = value; }
        }

        public string Traduccion
        {
            get { return _traduccion; }
            set { _traduccion = value; }
        }
        #endregion

        

    }
}
