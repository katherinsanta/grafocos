using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Isla.
	/// </summary>
	public class Isla
	{
		#region Sección de Declaraciones
		private short _idIsla;
		private short _idEstacion;
		private string _descripcion;

		private POS _pos;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Isla()
		{
		}

		/// <summary>
		/// Destructor de la clase
		/// </summary>
		~Isla()
		{
			this._pos = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Isla
		/// </summary>
		public short IdIsla
		{
			get { return this._idIsla; }
			set { this._idIsla = value; }
		}

		/// <summary>
		/// Id Estación
		/// </summary>
		public short IdEstacion
		{
			get { return this._idEstacion; }
			set { this._idEstacion = value; }
		}

		/// <summary>
		/// Descripción
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: Descripcion
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarIsla");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdEstacion", SqlDbType.SmallInt, this._idIsla);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, this._descripcion);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region POS Configurado
		/// <summary>
		/// POS Configurado para la isla respectiva.
		/// </summary>
		public POS Pos
		{
			get
			{
				if (this._pos == null)
					this._pos = new POS();

				return this._pos;
			}
		}
		#endregion
	}
}