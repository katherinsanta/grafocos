using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{

    /// <summary>
    /// Pagos de una venta
    /// </summary>
    public class Auditorias : Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones
        private object _consecutivo;
        #endregion

        #region Constructor
		/// <summary>
		/// Consulta de un tiquete en Particular
		/// </summary>
		internal Auditorias(object consecutivo)
		{
			this._consecutivo = consecutivo;
		}
		#endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public Auditoria this[string key]
        {
            get { return (Auditoria)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public Auditoria this[int index]
        {
            get { return (Auditoria)base[index]; }
        }
        #endregion

        //override
        #region Load Event
        /// <summary>
        /// Recuperación de información contenida en la base de datos para poblar la colección.
        /// </summary>		
        protected override void Load(object sender, EventArgs e)
        {
            #region Prepare Sql Command
            SqlDataReader dr = null;
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("RecuperarConsecutivo");
            sql.ParametersNumber = 1;
            //sql.AddParameter("@Id_Pagos", SqlDbType.Int, this._id_pagos);
            sql.AddParameter("@Consecutivo", SqlDbType.Int, this._consecutivo);
            #endregion

            #region Execute Sql
            dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            while (dr.Read())
            {
                
                Auditoria objAuditoria = new Auditoria();
                objAuditoria.Consecutivo=dr.GetInt32(0);
                objAuditoria.Placa = dr.GetString(1);
                objAuditoria.Cod_Cli = dr.GetString(2);
                objAuditoria.FormaDepago = dr.GetInt32(3);
                objAuditoria.Total = dr.GetDecimal(4);

                base.AddItem(objAuditoria.Consecutivo.ToString(), objAuditoria);
            }
            dr.Close();
            dr = null;
            sql = null;
            #endregion
        }
        #endregion

        #region Modificar
        /// <summary>
        /// Modificacion de un registro de la base de datos
        /// </summary>
        public static void ActualizarVenta(Auditoria objAuditoria)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ActualizarVentaPorCliente");
            sql.ParametersNumber = 4;
            sql.AddParameter("@Consecutivo", SqlDbType.Int, objAuditoria.Consecutivo);
            sql.AddParameter("@Placa", SqlDbType.VarChar,objAuditoria.Placa);
            sql.AddParameter("@Cod_Cli", SqlDbType.Int, objAuditoria.Cod_Cli);
            sql.AddParameter("@Cod_for_pag", SqlDbType.Int, objAuditoria.FormaDepago);

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
        /// Método para obtener de manera directa una forma de pago en particular
        /// </summary>
        public static Auditoria ObtenerItem(int consecutivo)
        {
            Auditorias objElementos = new Auditorias(consecutivo);
            if (objElementos.Count == 1)
                return objElementos[0];
            else
                return null;
        }
        #endregion

        #region ObtenerItems
        /// <summary>
        /// Método para obtener de manera directa la venta por consecutivo
        /// </summary>
        public static DataSet ObtenerItems(int consecutivo)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("RecuperarConsecutivo");
            sql.ParametersNumber = 1;
            sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);
            #endregion

            #region Execute Sql
            try
            {
                return (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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
