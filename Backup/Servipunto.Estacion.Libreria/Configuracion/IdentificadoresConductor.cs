using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// IdentificadorConductor
    /// </summary>
    public class IdentificadoresConductor : Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones
        private object _numero = null;
        private int _idConductor;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los grupos configurados.
		/// </summary>
		public IdentificadoresConductor(int idConductor, string numero)
		{
            _idConductor = idConductor;
            _numero = numero;
		}

		/// <summary>
		/// Consulta de un grupo en particular.
		/// </summary>
        public IdentificadoresConductor(int idConductor)
		{
            _idConductor = idConductor;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public IdentificadorConductor this[string key]
		{
            get { return (IdentificadorConductor)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
        new public IdentificadorConductor this[int index]
		{
            get { return (IdentificadorConductor)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("RecuperarIdentificadorConductor");
			sql.ParametersNumber = 2;
            sql.AddParameter("@IdConductor", SqlDbType.Int, this._idConductor);
            sql.AddParameter("@Numero", SqlDbType.VarChar, this._numero);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
                IdentificadorConductor objIdentificadorConductor = new IdentificadorConductor();
                objIdentificadorConductor.IdConductor = dr.GetInt32(0);
                objIdentificadorConductor.Numero = dr.IsDBNull(1) ? "" : dr.GetString(1).Trim();
                objIdentificadorConductor.Estado = dr.IsDBNull(2) ? "Inactivo": dr.GetString(2).Trim() == "S" ? "Activo": "Inactivo" ;
                base.AddItem(objIdentificadorConductor.Numero.ToString(), objIdentificadorConductor);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Adicionar
		/// <summary>
		/// Inserción de un registro en la base de datos.
		/// </summary>
        public static void Adicionar(IdentificadorConductor objIdentificadorConductor)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("InsertarIdentificadorConductor");
			sql.ParametersNumber = 3;
            sql.AddParameter("@IdConductor", SqlDbType.Int, objIdentificadorConductor.IdConductor);
            sql.AddParameter("@Numero", SqlDbType.VarChar, objIdentificadorConductor.Numero);
            sql.AddParameter("@Estado", SqlDbType.VarChar, objIdentificadorConductor.Estado);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				//objGrupo.IdGrupo = Convert.ToInt16(sql.Parameters[0].Value);
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(string numero)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("EliminarIdentificadorConductor");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Numero", SqlDbType.VarChar, numero);
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

		#region ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa un grupo en particular
		/// </summary>
		public static IdentificadorConductor ObtenerItem(int idConductor, string numero)
		{
			Libreria.Configuracion.IdentificadoresConductor objElementos = new IdentificadoresConductor(idConductor, numero);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
    }
}
