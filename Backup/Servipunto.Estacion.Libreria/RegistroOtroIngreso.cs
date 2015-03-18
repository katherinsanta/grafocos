using System;
using System.Collections.Generic;
using System.Text;

namespace Servipunto.Estacion.Libreria
{
    /// <summary>
    /// Registro Otros Ingresos
    /// </summary>
    public class RegistroOtroIngreso
    {
        #region Sección de Declaraciones
        DateTime _fecha;
        DateTime _fechaReal;
        DateTime _hora;        
        int _idConcepto;
        int _idRegistro;
        decimal _valor;
        #endregion

        #region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public RegistroOtroIngreso()
		{
		}
		#endregion


        #region Propiedades Públicas
        /// <summary>
        /// Id Registro
        /// </summary>
        public int IdRegistro
        {
            get { return this._idRegistro; }
            set { this._idRegistro = value; }

        }
        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Fecha
        {
            get { return this._fecha; }
            set { this._fecha = value; }
        }

        /// <summary>
        /// Fecha Real
        /// </summary>
        public DateTime FechaReal
        {
            get { return this._fechaReal; }
            set { this._fechaReal = value; }
        }

        /// <summary>
        /// Hora
        /// </summary>
        public DateTime Hora
        {
            get { return _hora; }
            set { this._hora = value; }
        }

        /// <summary>
        /// Id Concepto
        /// </summary>
        public int IdConcepto
        {
            get { return _idConcepto; }
            set { this._idConcepto = value; }
        }

        /// <summary>
        /// Valor
        /// </summary>
    
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value;}
        }
        #endregion
    }
}
