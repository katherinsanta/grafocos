using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Opciones asociadas a un m�dulo
	/// </summary>
	public class Opciones : Servipunto.Libreria.Collection
	{
		#region Secci�n de Declaraciones
		private string _idModulo;
		private object _idOpcion;
		#endregion

		#region Propiedades P�blicas
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor para recuperar todas las opciones asociadas a un m�dulo en especial
		/// </summary>
		/// <param name="idModulo">C�digo del M�dulo</param>
		internal Opciones(string idModulo)
		{
			this._idModulo = idModulo;
		}

		/// <summary>
		/// Constructor para recuperar una opci�n del sistema en particular
		/// </summary>
		internal Opciones(string idModulo, string idOpcion)
		{
			this._idModulo = idModulo;
			this._idOpcion = idOpcion;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Opcion this[string key]
		{
			get { return (Opcion)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Opcion this[int index]
		{
			get { return (Opcion)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperaci�n de informaci�n contenida en la base de datos para poblar la colecci�n
		/// </summary>
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("Select IdModulo, IdOpcion From Opciones");
			if (this._idModulo != null && this._idOpcion != null)
			{
				sql.Append(" Where IdModulo = @IdModulo And IdOpcion = @IdOpcion");

				sql.ParametersNumber = 2;
				sql.AddParameter("@IdModulo", SqlDbType.VarChar, this._idModulo);
				sql.AddParameter("@IdOpcion", SqlDbType.VarChar, this._idOpcion);
			}
			else if (this._idModulo != null)
			{
				sql.Append(" Where IdModulo = @IdModulo");

				sql.ParametersNumber = 1;
				sql.AddParameter("@IdModulo", SqlDbType.VarChar, this._idModulo);
			}
			else
				throw new Exception("Consulta Invalida.  Debe utilizar una de las propiedades de filtro.");
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Opcion objOpcion = new Opcion();
				objOpcion.IdModulo = dr.GetString(0);
				objOpcion.IdOpcion = dr.GetString(1);

				base.AddItem(objOpcion.IdOpcion, objOpcion);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region M�todo Obtener
		/// <summary>
		/// M�todo para obtener de manera directa un elemento en particular
		/// </summary>
		/// <param name="idModulo">C�digo del M�dulo</param>
		/// <param name="idOpcion">C�digo de la Opci�n</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Opcion Obtener(string idModulo, string idOpcion)
		{
			Opciones objElementos = new Opciones(idModulo, idOpcion);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}