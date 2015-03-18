using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Módulos del Sistema
	/// </summary>
	public class Modulos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idModulo;
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Filtro para recuperar un Modulo en particular
		/// </summary>
		public string IdModulo
		{
			set { this._idModulo = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public Modulos()
		{
		}		
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Modulo this[string key]
		{
			get { return (Modulo)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Modulo this[int index]
		{
			get { return (Modulo)base[index]; }
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

			sql.Append("Select IdModulo From Modulos");
			if (this._idModulo != null)
			{
				sql.Append(" Where IdModulo = @IdModulo");
				sql.ParametersNumber = 1;
				sql.AddParameter("@IdModulo", SqlDbType.VarChar, this._idModulo);
			}
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Modulo objModulo = new Modulo();
				objModulo.IdModulo = dr.GetString(0);

				base.AddItem(objModulo.IdModulo, objModulo);
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
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Modulo Obtener(string idModulo)
		{
			Modulos objElementos = new Modulos();
			objElementos.IdModulo = idModulo;
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}