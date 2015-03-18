using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Manguera.
	/// </summary>
	public class Manguera
	{
		#region Sección de Declaraciones
		private short _idIsla;
		private short _idSurtidor;
		private short _idCara;
		private short _idManguera;
		private short _idTanque;
		private short _idArticulo;
		private short _grado;
		private bool _lectorConfigurado;
		private string _idLector;
		private string _estado;	//A ctivo, I nactivo, B loquear ventas

		private string _articulo;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Manguera()
		{
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
		/// Id Surtidor
		/// </summary>
		public short IdSurtidor
		{
			get { return this._idSurtidor; }
			set { this._idSurtidor = value; }
		}

		/// <summary>
		/// Id Cara
		/// </summary>
		public short IdCara
		{
			get { return this._idCara; }
			set { this._idCara = value; }
		}

		/// <summary>
		/// Id Manguera
		/// </summary>
		public short IdManguera
		{
			get { return this._idManguera; }
			set { this._idManguera = value; }
		}

		/// <summary>
		/// Id Tanque
		/// </summary>
		public short IdTanque
		{
			get { return this._idTanque; }
			set { this._idTanque = value; }
		}

		/// <summary>
		/// Id Articulo
		/// </summary>
		public short IdArticulo
		{
			get { return this._idArticulo; }
			set { this._idArticulo = value; }
		}

		/// <summary>
		/// Grado
		/// </summary>
		public short Grado
		{
			get { return this._grado; }
			set { this._grado = value; }
		}

		/// <summary>
		/// Indicador que determina si tiene una DS asociada.
		/// </summary>
		public bool LectorConfigurado
		{
			get { return this._lectorConfigurado; }
			set { this._lectorConfigurado = value; }
		}

		/// <summary>
		/// Id Lector (DS Room)
		/// </summary>
		public string IdLector
		{
			get { return this._idLector; }
			set { this._idLector = value; }
		}

		/// <summary>
		/// Estado
		/// </summary>
		public string Estado
		{
			get { return this._estado; }
			set { this._estado = value; }
		}

		/// <summary>
		/// Nombre del Artículo
		/// </summary>
		public string Articulo
		{
			get { return this._articulo; }
			set { this._articulo = value; }
		}

		/// <summary>
		/// Descripción Estado
		/// </summary>
		public string DescripcionEstado
		{
			get
			{
				switch (this._estado)
				{
					case "A":
						return "Activo";
					case "I":
						return "Inactivo";
					case "B":
						return "Ventas Bloqueadas";
					default:
						return "(sin definir)";
				}
			}
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: IdTanque, IdArtículo, Grado, LectorConfigurado, IdLector, Estado
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarManguera");
			sql.ParametersNumber = 7;
			sql.AddParameter("@IdManguera", SqlDbType.SmallInt, this._idManguera);
			if (this._idTanque == 0)
				sql.AddParameter("@IdTanque", SqlDbType.SmallInt, null);
			else
				sql.AddParameter("@IdTanque", SqlDbType.SmallInt, this._idTanque);
			sql.AddParameter("@IdArticulo", SqlDbType.SmallInt, this._idArticulo);
			sql.AddParameter("@Grado", SqlDbType.SmallInt, this._grado);
			if (this._lectorConfigurado)
			{
				sql.AddParameter("@LectorConfigurado", SqlDbType.TinyInt, 1);
				sql.AddParameter("@IdLector", SqlDbType.VarChar, this._idLector);
			}
			else
			{
				sql.AddParameter("@LectorConfigurado", SqlDbType.TinyInt, 0);
				sql.AddParameter("@IdLector", SqlDbType.VarChar, null);
			}
			sql.AddParameter("@Estado", SqlDbType.VarChar, this._estado);
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
	}
}