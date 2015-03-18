using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.Tanques
{
    /// <summary>
    /// ConsolaTanques Metodos
    /// </summary>
    public class ConsolaTanques: Servipunto.Libreria.Collection
    {
        #region Declaraciones
        private object idConsola= null;
        #endregion

        #region Constructor/Destructor
		/// <summary>
		/// Obtener todas las consolas
		/// </summary>
		public ConsolaTanques() {
		}
		/// <summary>
		/// Obtiene un empleado en particular
		/// </summary>
		/// <param name="cod_Emp">Codigo de Empleado. </param>
		internal ConsolaTanques(int idConsola){
            this.idConsola = idConsola;
		}
		#endregion

        #region Indexer
        /// <summary>
        /// Indexar por Llave.
        /// </summary>
        new public ConsolaTanque this[string key]
        {
            get { return (ConsolaTanque)base[key]; }
        }
        /// <summary>
        /// Indexar por indice.
        /// </summary>
        new public ConsolaTanque this[int index]
        {
            get { return (ConsolaTanque)base[index]; }
        }
        #endregion

        #region Load Event
        /// <summary>
        /// Recuperación de información contenida en la base de datos para poblar la colección.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Load(object sender, EventArgs e)
        {

            #region Prepare Sql Command
            SqlDataReader dr = null;
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("ConsultarConsolaTanque");
            sql.ParametersNumber = 1;
            sql.AddParameter("@IdConsola", SqlDbType.Int, this.idConsola);
            #endregion

            #region Execute sql Command
            dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            while (dr.Read())
            {
                ConsolaTanque objConsola = new ConsolaTanque();
                objConsola.IdConsola = dr.GetInt32(0);
                objConsola.Nombre = dr.IsDBNull(1) ? "(Sin Definir)" : dr.GetString(1).TrimEnd();
                objConsola.Protocolo = dr.IsDBNull(2) ? "(Sin Definir)" : dr.GetString(2).TrimEnd();
                objConsola.Tipo = dr.IsDBNull(3) ? "(Sin Definir)" : dr.GetString(3).TrimEnd();
                objConsola.DireccionIP = dr.IsDBNull(4) ? "(Sin Definir)" : dr.GetString(4).TrimEnd();
                objConsola.PuertoLogico = dr.IsDBNull(5) ? "(Sin Definir)" : dr.GetString(5).TrimEnd();
                objConsola.PuertoSerial = dr.IsDBNull(6) ? "(Sin Definir)" : dr.GetString(6).TrimEnd();
                base.AddItem(objConsola.IdConsola.ToString(), objConsola);
            }
            dr.Close();
            dr = null;
            sql = null;
            #endregion
        }
        #endregion

        #region Add
        /// <summary>
        /// Inserta una consola de tanques en la BD.
        /// </summary>
        /// <param name="IdConsola"></param>
        /// <param name="objConsola"></param>
        public static void Adicionar(ConsolaTanque objConsola)
        {
            #region Prepare Sql
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("InsertarConsolaTanque");
            sql.ParametersNumber = 7;
            sql.AddParameter("@IdConsola", SqlDbType.Int, objConsola.IdConsola);
            sql.AddParameter("@Nombre", SqlDbType.VarChar, objConsola.Nombre);
            sql.AddParameter("@Protocolo", SqlDbType.VarChar,objConsola.Protocolo);
            sql.AddParameter("@Tipo", SqlDbType.VarChar, objConsola.Tipo);
            sql.AddParameter("@DireccionIP", SqlDbType.VarChar, objConsola.DireccionIP);
            sql.AddParameter("@PuertoLogico", SqlDbType.VarChar, objConsola.PuertoLogico);
            sql.AddParameter("@PuertoSerial", SqlDbType.VarChar, objConsola.PuertoSerial);
            #endregion

            #region Execute Sql
            try
            {
                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            }
            catch (SqlException e)
            {
                if (e.Message.IndexOf("Llave Duplicada!") != -1)
                    throw new Exception("Ya existe Consola Tanque " + objConsola.IdConsola+ " !ERROR BD! ");
                else
                    throw new Exception(e.Message + " !ERROR BD! ");
            }
            finally
            {
                sql = null;
            }
            #endregion
        }
        #endregion

        #region Delete
        /// <summary>
        /// Elimina una consola De Tanque
        /// </summary>
        /// <param name="idConsola">codigo de la consola a eliminar.</param>
        public static void Eliminar(int idConsola)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("EliminarConsolaTanque");
            sql.ParametersNumber = 1;
            sql.AddParameter("@IdConsola", SqlDbType.Int, idConsola);
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

        #region GetItem
        /// <summary>
        /// Metodo para obtener una consola en particular.
        /// </summary>
        /// <param name="IdConsola">Codigo de la consola a consultar</param>
        /// <returns>Consola si existe. Null si no.</returns>
        public static ConsolaTanque ObtenerItem(int idconsola)
        {
            ConsolaTanques objconsola = new ConsolaTanques(idconsola);
            if (objconsola.Count == 1)
                return objconsola[0];
            else
                return null;
        }
        #endregion

    }
}
