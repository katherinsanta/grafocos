using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;


using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Web;


using Servipunto.Estacion.AccesoDatos.CollectionClasses;
using Servipunto.Estacion.AccesoDatos.DaoClasses;
using Servipunto.Estacion.AccesoDatos.EntityClasses;
using Servipunto.Estacion.AccesoDatos.FactoryClasses;
using Servipunto.Estacion.AccesoDatos.HelperClasses;
using Servipunto.Estacion.AccesoDatos.StoredProcedureCallerClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Data;


namespace Servipunto.Estacion.Libreria
{
    [Serializable]
    public class Utilidades
    {
        #region SepararPalabras
        /// <summary>
        /// Incluye espacio " " antes de las letras en mayusculas en una cadena
        /// </summary>
        /// <param name="texto">Texto a separar</param>
        /// <param name="convertirMayusculaAMinuscual">Convierte todo caracter mayuscula en minuscula</param>
        /// <returns>La nueva cadena separada</returns>
        /// Referencia Documental: (Falta)
        /// Fecha: 26/06/2009
        /// Autor: Elvis Astaiza
        public string SepararPalabras(string texto, bool convertirMayusculaAMinuscual)
        {
            string resultado = "";
            char[] arreglo = texto.ToCharArray();
            foreach (char caracter in arreglo)
            {
                if (caracter >= 65 && caracter <= 90)
                    resultado += " ";

                resultado += caracter;
            }
            if (convertirMayusculaAMinuscual)
                resultado = resultado.ToLower();
            return resultado;
        }
        #endregion

        #region AsignarComodines
        /// <summary>
        /// Retorna el dato a buscar con los comodines de coincidencia
        /// </summary>
        /// <param name="datoABuscar">Dato a colocar los comodines</param>
        /// <param name="modoDeBusqueda">Ubicacion de comodines</param>
        /// <returns>Dato formateado</returns>
        /// Referencia Documental: (Falta)
        /// Fecha:  09/06/2009
        /// Autor:  Elvis Astaiza Gutierrez
        public string AsignarComodines(string datoABuscar, string modoDeBusqueda)
        {
            if (datoABuscar.Length == 0)
                return datoABuscar;
            if (modoDeBusqueda == "Inicien")
                datoABuscar += "%";
            else if (modoDeBusqueda == "Finalicen")
                datoABuscar = "%" + datoABuscar;
            else if (modoDeBusqueda == "Contengan")
                datoABuscar = "%" + datoABuscar + "%";
            return datoABuscar;
        }
        #endregion
       
    }
}
