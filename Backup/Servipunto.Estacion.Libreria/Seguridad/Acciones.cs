using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Acciones pertenecientes a una opción del sistema
	/// </summary>
	public class Acciones : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private string _idModulo;
		private string _idOpcion;
		private object _idAccion;

		private object _idRol;
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Filtro para extraer los permisos actuales del rol
		/// </summary>
		public byte IdRol
		{
			set { this._idRol = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Recuperar todas las acciones asociadas a una opción en particular
		/// </summary>
		/// <param name="idModulo">Código del Módulo</param>
		/// <param name="idOpcion">Código de la Opción</param>
		internal Acciones(string idModulo, string idOpcion)
		{
			this._idModulo = idModulo;
			this._idOpcion = idOpcion;
		}

		/// <summary>
		/// Recuperar una acción en particular
		/// </summary>
		/// <param name="idModulo">Código del Modulo</param>
		/// <param name="idOpcion">Código de la Opción</param>
		/// <param name="idAccion">Código de la Acción</param>
		internal Acciones(string idModulo, string idOpcion, string idAccion)
		{
			this._idModulo = idModulo;
			this._idOpcion = idOpcion;
			this._idAccion = idAccion;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Accion this[string key]
		{
			get { return (Accion)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Accion this[int index]
		{
			get { return (Accion)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección
		/// </summary>
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			if (this._idModulo != null && this._idOpcion != null && this._idRol == null)
			{
				sql.Append("Select IdModulo, IdOpcion, IdAccion, Descripcion, 0 As Existe From Acciones");
				sql.Append(" Where IdModulo = @IdModulo And IdOpcion = @IdOpcion");
				sql.ParametersNumber = 2;
				sql.AddParameter("@IdModulo", SqlDbType.VarChar, this._idModulo);
				sql.AddParameter("@IdOpcion", SqlDbType.VarChar, this._idOpcion);
			}
			if (this._idModulo != null && this._idOpcion != null && this._idRol != null)
			{
				sql.Append("Select IdModulo, IdOpcion, IdAccion, Descripcion,");
				sql.Append(" Existe = IsNull((Select 1 From Permiso Where IdRol = " + this._idRol.ToString() + " And IdModulo = Acciones.IdModulo And IdOpcion = Acciones.IdOpcion And IdAccion = Acciones.IdAccion), 0)");
				sql.Append(" From Acciones");
				sql.Append(" Where IdModulo = @IdModulo And IdOpcion = @IdOpcion");
				sql.ParametersNumber = 2;
				sql.AddParameter("@IdModulo", SqlDbType.VarChar, this._idModulo);
				sql.AddParameter("@IdOpcion", SqlDbType.VarChar, this._idOpcion);
			}
			else
				throw new Exception("Consulta Invalida.  Debe utilizar una de las propiedades de filtro.");
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Accion objAccion = new Accion();
				objAccion.IdModulo = dr.GetString(0);
				objAccion.IdOpcion = dr.GetString(1);
				objAccion.IdAccion = dr.GetString(2);
				objAccion.Descripcion = dr.GetString(3);
				objAccion.Existe = dr.GetInt32(4)==1?true:false;

				base.AddItem(objAccion.IdAccion, objAccion);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un elemento en particular
		/// </summary>
		/// <param name="idModulo">Código del Módulo</param>
		/// <param name="idOpcion">Código de la Opción</param>
		/// <param name="idAccion">Código de la Acción</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Accion Obtener(string idModulo, string idOpcion, string idAccion)
		{
			Acciones objElementos = new Acciones(idModulo, idOpcion, idAccion);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}