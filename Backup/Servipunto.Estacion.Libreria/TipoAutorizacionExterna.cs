using System;
using System.Collections.Generic;
using System.Text;

namespace Servipunto.Estacion.Libreria
{
   public class TipoAutorizacionExterna
    {
        #region Sección de Declaraciones
		private short  _idTipoAutorizacionExterna;
       private string _tipoAutorizacionExterna;
        private string _descripcion;

		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public TipoAutorizacionExterna()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Forma de Pago
		/// </summary>

        public short  IdTipoAutorizacion
        {
            get { return _idTipoAutorizacionExterna; }
            set { _idTipoAutorizacionExterna = value; }
        }

       public string TipoAutorizacion
        {
            get { return _tipoAutorizacionExterna; }
            set { _tipoAutorizacionExterna = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        #endregion
    }
}
