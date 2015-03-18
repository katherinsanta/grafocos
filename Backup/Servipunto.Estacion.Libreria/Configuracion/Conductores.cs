using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// Conductores
    /// </summary>
    public class Conductores : Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones
		private object _idConductor = null;
        private string _filtro = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los grupos configurados.
		/// </summary>
		public Conductores()
		{

		}

		/// <summary>
		/// Consulta de un grupo en particular.
		/// </summary>
        internal Conductores(string idConductor)
		{
            this._idConductor = idConductor;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Conductor this[string key]
		{
            get { return (Conductor)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
        new public Conductor this[int index]
		{
            get { return (Conductor)base[index]; }
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

            sql.Append("RecuperarConductor");
			sql.ParametersNumber = 1;
            sql.AddParameter("@IdConductor", SqlDbType.VarChar, this._idConductor);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
                Conductor objConductor = new Conductor();
                objConductor.IdConductor = dr.GetInt32(0);
                objConductor.Identificacion = dr.GetString(1);
                objConductor.Nombre = dr.GetString(2).Trim();
                objConductor.Autorizacion = dr.GetString(3).Trim()=="S" ? "Si":"No";
                objConductor.Codigo = dr.GetString(4).Trim();
                base.AddItem(objConductor.Codigo.ToString(), objConductor);
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
		public static void Adicionar(Conductor objConductor)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("InsertarConductor");
			sql.ParametersNumber = 4;
            sql.AddParameter("@Nombre", SqlDbType.VarChar, objConductor.Nombre/*, ParameterDirection.InputOutput*/);
            sql.AddParameter("@Identificacion", SqlDbType.VarChar, objConductor.Identificacion);
            sql.AddParameter("@Autorizacion", SqlDbType.VarChar, objConductor.Autorizacion);
            sql.AddParameter("@Codigo", SqlDbType.VarChar, objConductor.Codigo);

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
		public static void Eliminar(string idConductor)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarConductor");
			sql.ParametersNumber = 1;
            sql.AddParameter("@idConductor", SqlDbType.VarChar, idConductor);
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

		#region ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa un grupo en particular
		/// </summary>
        public static Conductor ObtenerItem(string idConductor)
		{
            Conductores objElementos = new Conductores(idConductor);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
    }
}
