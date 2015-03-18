using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// Concepto Otros Ingresos 
    /// </summary>
    public class ConceptoOtrosIngresos : Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones
		private object _idConceptoOtroIngreso = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos las compañías configuradas.
		/// </summary>
		public ConceptoOtrosIngresos()
		{
		}

		/// <summary>
		/// Consulta de una compañía en particular.
		/// </summary>
        internal ConceptoOtrosIngresos(int idConceptoOtroIngreso)
		{
			this._idConceptoOtroIngreso = idConceptoOtroIngreso;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
        new public ConceptoOtroIngreso this[string key]
		{
            get { return (ConceptoOtroIngreso)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
        new public ConceptoOtroIngreso this[int index]
		{
            get { return (ConceptoOtroIngreso)base[index]; }
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

			sql.Append("ConsultarConcentoOtroIngreso");
			sql.ParametersNumber = 1;
            sql.AddParameter("@IdConceptoOtroIngreso", SqlDbType.SmallInt, this._idConceptoOtroIngreso);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
                ConceptoOtroIngreso objConceptoOtroIngreso = new ConceptoOtroIngreso();
                objConceptoOtroIngreso.IdConceptoOtroIngreso = dr.GetInt32(0);
                objConceptoOtroIngreso.NombreOtroIngreso = dr.GetString(1).Trim();


                base.AddItem(objConceptoOtroIngreso.IdConceptoOtroIngreso.ToString(), objConceptoOtroIngreso);
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
        public static void Adicionar(ConceptoOtroIngreso objConceptoOtroIngreso)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("InsertarConceptoOtroIngreso");
			sql.ParametersNumber = 1;            
            sql.AddParameter("@NombreOtroIngreso", SqlDbType.VarChar, objConceptoOtroIngreso.NombreOtroIngreso);			
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				//objCompania.IdCompania = Convert.ToInt16(sql.Parameters[0].Value);
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
        public static void Eliminar(int IdConceptoOtroIngreso)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("EliminarConceptoOtroIngreso");
			sql.ParametersNumber = 1;
            sql.AddParameter("@IdConceptoOtroIngreso", SqlDbType.SmallInt, IdConceptoOtroIngreso);
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
		/// Método para obtener de manera directa una compañía en particular
		/// </summary>
        public static ConceptoOtroIngreso ObtenerItem(int IdConceptoOtroIngreso)
		{
            ConceptoOtrosIngresos objElementos = new ConceptoOtrosIngresos(IdConceptoOtroIngreso);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
    }
}
