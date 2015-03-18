using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Administración de Clientes configurados
	/// </summary>
	public class Clientes : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private string _filtro = null;
		private object _idCliente;
		#endregion

		#region Propiedades Públicas
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de Todos los Clientes
		/// </summary>
		public Clientes()
		{
		}

		/// <summary>
		/// Consulta de un Cliente en Particular
		/// </summary>
		internal Clientes(string idCliente)
		{
			this._idCliente = idCliente;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Cliente this[string key]
		{
			get { return (Cliente)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Cliente this[int index]
		{
			get { return (Cliente)base[index]; }
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

			sql.Append("Select COD_CLI, NOMBRE From Clientes");
			if (this._filtro != null)
			{
				sql.Append(this._filtro);

			}
			else if (this._idCliente != null)
			{
				sql.Append(" Where COD_CLI = @IdCliente");
				sql.ParametersNumber = 1;
				sql.AddParameter("@IdCliente", SqlDbType.VarChar, this._idCliente);
			}
			sql.Append(" Order By NOMBRE");
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Cliente objCliente = new Cliente();
				objCliente.IdCliente = dr.GetString(0);
				objCliente.Nombre = dr.GetString(1);

				base.AddItem(objCliente.IdCliente, objCliente);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Buscar
		/// <summary>
		/// Busqueda de clientes por Nombre
		/// </summary>
		public int Buscar(string nombre)
		{
			this._filtro = " Where NOMBRE LIKE '%" + nombre + "%'";
			this.Load(this, new EventArgs());
			return this.Count;
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un cliente en particular
		/// </summary>
		public static Cliente Obtener(string idCliente)
		{
			Clientes objElementos = new Clientes(idCliente);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}