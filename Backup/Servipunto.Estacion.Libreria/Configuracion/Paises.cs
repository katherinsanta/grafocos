using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Colección de Departamentos
	/// </summary>
	public class Paises : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idPais;
		private object _idDepartamento;
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Filtro para recuperar un Pais en particular
		/// </summary>
		public int IdPais
		{
			set { this._idPais = value; }
		}

		/// <summary>
		/// Filtro para recuperar un Departamento en particular
		/// </summary>
		public int IdDepartamento
		{
			set { this._idDepartamento = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public Paises()
		{
		}		
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Pais this[string key]
		{
			get { return (Pais)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Pais this[int index]
		{
			get { return (Pais)base[index]; }
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

			sql.Append("RecuperarPais");

			sql.ParametersNumber = 2;
			sql.AddParameter("@IdPais", SqlDbType.Int, this._idPais);
			sql.AddParameter("@IdDepartamento", SqlDbType.Int, this._idDepartamento);

			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Pais objPais = new Pais();
				objPais.IdPais = dr.GetInt32(0);
				objPais.Nombre = dr.GetString(1);
				objPais.Codigo = dr.IsDBNull(2)?"":dr.GetString(2);

				base.AddItem(objPais.IdPais.ToString(), objPais);
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
		/// <param name="idPais">Código del Pais</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Pais Obtener(int idPais)
		{
			Paises objElementos = new Paises();
			objElementos.IdPais= idPais;
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}