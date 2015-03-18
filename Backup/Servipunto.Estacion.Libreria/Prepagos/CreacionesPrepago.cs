using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Prepagos
{    
    public class CreacionPrepagos: Servipunto.Libreria.Collection
    {
        #region Constructor
        /// <summary>
        /// Recuperar todas las acciones asociadas a una opción en particular
        /// </summary>
        /// <param name="idModulo">Código del Módulo</param>
        /// <param name="idOpcion">Código de la Opción</param>
        public CreacionPrepagos()
        {
        
        }

        public CreacionPrepagos(int IdInventario)
        {
            _idInventario = IdInventario;
        }

        #endregion

        #region Sección de Declaraciones		

		private object _idInventario;
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Filtro para extraer los permisos actuales del rol
		/// </summary>
		public int IdIventario
		{
			set { this._idInventario = value; }
		}
		#endregion

		

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
        new public CreacionPrepago this[string key]
		{
            get { return (CreacionPrepago)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
        new public CreacionPrepago this[int index]
		{
            get { return (CreacionPrepago)base[index]; }
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

			if (this._idInventario == null)
			{
				sql.Append("Select IdInventario, NumeroInicialPrepagoCreado, NumeroFinalPrepagoCreado, Fecha, IdUsuario,	CantidadPrepagosCreados, Denominacion, TotalDenominacion from InventarioPrepago");				
				sql.ParametersNumber = 0;
				
			}
            else if (this._idInventario != null)
			{
                sql.Append("Select IdInventario, NumeroInicialPrepagoCreado, NumeroFinalPrepagoCreado, Fecha, IdUsuario,	CantidadPrepagosCreados, Denominacion, TotalDenominacion from InventarioPrepago");
                sql.Append(" Where IdInventario = @IdInventario");
                sql.ParametersNumber = 1;
				sql.AddParameter("@IdInventario", SqlDbType.Int, this._idInventario);
				
			}
			
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
                CreacionPrepago objCreacion = new CreacionPrepago();
                objCreacion.IdCreacion = dr.GetInt32(0);
                objCreacion.NumeroInicialCreacion = dr.GetInt32(1);
                objCreacion.NumeroFinalCreacion = dr.GetInt32(2);
                objCreacion.Fecha = dr.GetDateTime(3);
                objCreacion.IdUsuario = dr.GetString(4);
                objCreacion.CantidadPrepagosCreados = dr.GetInt32(5);
                objCreacion.Denominacion = dr.GetDecimal(6);
                objCreacion.TotalDenominacion = dr.GetDecimal(7);
                base.AddItem(objCreacion.IdCreacion.ToString(), objCreacion);
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
		/// <param name="idModulo">Código del Módulo</param>
		/// <param name="idOpcion">Código de la Opción</param>
		/// <param name="idAccion">Código de la Acción</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static CreacionPrepago Obtener(int idInventario)
		{
            CreacionPrepagos objElementos = new CreacionPrepagos(idInventario);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

        #region Adicionar
        /// <summary>
        /// Inserción de un registro en la base de datos.
        /// </summary>
        public static void Adicionar(CreacionPrepago objCreacion)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("InsertarRangoCreacionPrepagos");
            sql.ParametersNumber = 7;
            sql.AddParameter("@NumeroInicialPrepagoCreado", SqlDbType.Int, objCreacion.NumeroInicialCreacion);
            sql.AddParameter("@NumeroFinalPrepagoCreado", SqlDbType.Int, objCreacion.NumeroFinalCreacion);
            sql.AddParameter("@Fecha", SqlDbType.DateTime, objCreacion.Fecha);
            sql.AddParameter("@IdUsuario", SqlDbType.VarChar, objCreacion.IdUsuario);
            sql.AddParameter("@Denominacion", SqlDbType.Decimal, objCreacion.Denominacion);
            sql.AddParameter("@TotalDenominacion", SqlDbType.Decimal, objCreacion.TotalDenominacion);
            sql.AddParameter("@CantidadPrepagosCreados", SqlDbType.Int, objCreacion.CantidadPrepagosCreados);           
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


        #region Eliminar
        /// <summary>
        /// Eliminación de un registro de la base de datos.
        /// </summary>
        public static void Eliminar(int idInventario)
        {
            #region Prepare Sql Command
            Libreria.Prepagos.CreacionPrepago objCreacion = Libreria.Prepagos.CreacionPrepagos.Obtener(idInventario);
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            if (objCreacion == null)
                return;

            sql.Append("delete from inventarioprepago where idinventario=" + idInventario.ToString());            
            #endregion

            #region Execute Sql
            try
            {
                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
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


            #region prepagos
            sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("delete from prepago where NumeroInicialTiqueteCreado >=" + objCreacion.NumeroInicialCreacion + " and NumeroFinalTiqueteCreado <= " + objCreacion.NumeroFinalCreacion);
            #endregion

            #region Execute Sql
            try
            {
                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
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
