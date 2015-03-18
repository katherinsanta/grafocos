using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// Configuraciones Zeta Automatica
    /// </summary>
    public class ConfiguracionesZetaAutomatico:Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones		
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los grupos configurados.
		/// </summary>
		public ConfiguracionesZetaAutomatico()
		{
		}		
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
        new public ConfiguracionZetaAutomatica this[string key]
		{
            get { return (ConfiguracionZetaAutomatica)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
        new public ConfiguracionZetaAutomatica this[int index]
		{
            get { return (ConfiguracionZetaAutomatica)base[index]; }
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
            sql.Append("Select IdConfiguracionJorndada, dbo.finteger(FechaCreacion), dbo.finteger(FechaActualizacion), Usuario, dbo.hinteger(HoraInicio), dbo.hinteger(HoraFinal) from ConfiguracionCierreZetaAutomatico");			
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
                ConfiguracionZetaAutomatica objConf = new ConfiguracionZetaAutomatica();
                objConf.idConfiguracionZetaAutomatico = dr.GetInt32(0);
                objConf.FechaCreacion = dr.GetDateTime(1);
                objConf.FechaActualizacion = dr.GetDateTime(2);
                objConf.Usuario = dr.GetString(3);
                objConf.HoraInicio = Convert.ToDateTime(dr.GetString(4));
                objConf.HoraFinal = Convert.ToDateTime(dr.GetString(5));
                base.AddItem(objConf.idConfiguracionZetaAutomatico.ToString(), objConf);
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
		public static void Adicionar(ConfiguracionZetaAutomatica objConfiguracion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("InsertarConfiguracionZetaAutomatico");
			sql.ParametersNumber = 5;
            sql.AddParameter("@FechaCreacion", SqlDbType.DateTime, objConfiguracion.FechaCreacion/*, ParameterDirection.InputOutput*/);
            sql.AddParameter("@FechaActualizacion", SqlDbType.DateTime, objConfiguracion.FechaActualizacion);
            sql.AddParameter("@Usuario", SqlDbType.VarChar, objConfiguracion.Usuario);
            sql.AddParameter("@HoraInicio", SqlDbType.DateTime, objConfiguracion.HoraInicio);
            sql.AddParameter("@HoraFinal", SqlDbType.DateTime, objConfiguracion.HoraFinal);

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
		

    }
}
