using System;

namespace Servipunto.Estacion.Libreria
{

    #region Enumerado EstadoPrepago
    /// <summary>
    /// Estado de Prepagos
    /// </summary>
    public enum EstadoPrepago
    {
        /// <summary>
        /// Creado
        /// </summary>
        Creado = 1,
        /// <summary>
        /// Asignado
        /// </summary>
        Asignado = 2,
        /// <summary>
        /// Utilizado
        /// </summary>
        Utilizado = 3,
        /// <summary>
        /// Anulado
        /// </summary>
        Anulado = 4


    }
    #endregion


	#region Enumerado TipoArticulo
	/// <summary>
	/// Tipos de Artículos
	/// </summary>
	public enum TipoArticulo
	{
		/// <summary>
		/// Canastilla
		/// </summary>
		Canastilla = 0,
		/// <summary>
		/// Combustible
		/// </summary>
		Combustible = 1
	}
	#endregion

	#region Enumerado EstadoUsuario
	/// <summary>
	/// Lista de posibles Estados
	/// </summary>
	public enum EstadoUsuario
	{
		/// <summary>
		/// Activo
		/// </summary>
		Activo,
		/// <summary>
		/// Inactivo
		/// </summary>
		Inactivo
	}
	#endregion

	#region Enumerado Colores de Articulos
	/// <summary>
	/// Colores para articulos
	/// </summary>
	public enum ColorEnum {
		/// <summary>
		/// Amarillo
		/// </summary>
		Amarillo = 16776960,

		/// <summary>
		/// Azul
		/// </summary>
		Azul = 255,

		/// <summary>
		/// Gris
		/// </summary>
		Gris = 8421504,

		/// <summary>
		/// Naranja
		/// </summary>
		Naranja = 16744576,

		/// <summary>
		/// Negro
		/// </summary>
		Negro = 4194368,

		/// <summary>
		/// Rojo
		/// </summary>
		Rojo = 16711680,

		/// <summary>
		/// Verde
		/// </summary>
		Verde = 4259584,

		/// <summary>
		/// Color no especificado --> Blanco
		/// </summary>
		NoColor = 16777215

	}
	#endregion

}