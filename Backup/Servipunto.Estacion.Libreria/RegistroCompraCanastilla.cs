using System;
using System.Collections.Generic;
using System.Text;

namespace Servipunto.Estacion.Libreria
{
    /// <summary>
    /// Registro de compra de canastilla
    /// </summary>
    public class RegistroCompraCanastilla
    {
        #region Sección de Declaraciones
        int _idCompra;
        DateTime _fecha;
        DateTime _hora;
        short _cod_art;        
        decimal _cantidadAnterior;
        decimal _cantidadActual;
        decimal _compra;
        string _usuario;
        string _articulo;
        #endregion

        #region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public RegistroCompraCanastilla()
		{
		}
		#endregion


        #region Propiedades Públicas
        /// <summary>
        /// Id Compra
        /// </summary>
        public int IdCompra
        {
            get { return this._idCompra; }
            set { this._idCompra = value; }

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
        /// Hora
        /// </summary>
        public DateTime Hora
        {
            get { return this._hora; }
            set { this._hora = value; }
        }       

        /// <summary>
        /// Codigo Articulo
        /// </summary>
        public short Cod_Art
        {
            get { return _cod_art; }
            set { this._cod_art = value; }
        }

        /// <summary>
        /// Compra
        /// </summary>
    
        public decimal Compra
        {
            get { return _compra; }
            set { _compra = value; }
        }

        /// <summary>
        /// Cantidad Anterior
        /// </summary>
        public decimal CantidadAnterior
        {
            get { return _cantidadAnterior; }
            set { _cantidadAnterior = value; }
        }

        /// <summary>
        /// cantidad Actual
        /// </summary>
        public decimal CantidadActual
        {
            get { return _cantidadActual; }
            set { _cantidadActual = value; }
        }

        /// <summary>
        /// Usuario
        /// </summary>
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }

        }

        /// <summary>
        /// Usuario
        /// </summary>
        public string Articulo
        {
            get { return _articulo; }
            set { _articulo = value; }

        }
        #endregion
    }
}
