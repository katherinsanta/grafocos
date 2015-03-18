using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


namespace Servipunto.Estacion.Libreria.Configuracion
{
    public class ConfiguracionDescuentos : Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones
        private int _idDescuento = 0;
		private object _idArticulo = null;
		private object _tipo = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los artículos.
		/// </summary>
		public ConfiguracionDescuentos()
		{
        }
        public ConfiguracionDescuentos(int IdDescuento) 
        {
            _idDescuento = IdDescuento;
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public ConfiguracionDescuento this[string key]
        {
            get { return (ConfiguracionDescuento)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public ConfiguracionDescuento this[int index]
        {
            get { return (ConfiguracionDescuento)base[index]; }
        }
        #endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e)
		{

            ObtenerRegistros(_idDescuento);           

			#region Prepare Sql Command
            //SqlDataReader dr = null;
            //Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            //sql.Append("ConsultarConfiguracionDescuentos");
	
            //#endregion

            //#region Execute Sql
            //try
            //{
            //    dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
            //    while (dr.Read())
            //    {
            //        ConfiguracionDescuento objConfDescuento = new ConfiguracionDescuento();
            //        objConfDescuento.IdDescuento = dr.GetInt16(0);
            //        objConfDescuento.TipoDescuento = dr.GetInt16(1);
            //        objConfDescuento.PorcDescuento = dr.GetDecimal(2);
            //        objConfDescuento.FechaInicio = dr.GetDateTime(3);
            //        objConfDescuento.FechaFinal = dr.GetDateTime(4);
            //        objConfDescuento.HoraInicio = Convert.ToDateTime(dr.GetString(5));
            //        objConfDescuento.HoraFinal = Convert.ToDateTime(dr.GetString(6));
            //        objConfDescuento.ItemsAfectados = dr.GetString(7);
            //        objConfDescuento.DiasSemana = dr.GetString(8);
            //        objConfDescuento.TodasHoras = dr.GetBoolean(9);

            //        base.AddItem(objConfDescuento.IdDescuento.ToString(), objConfDescuento);
            //    }
            //    dr.Close();
            //    dr = null;
            //    sql = null;
            //}
            //catch(Exception ex)
            //{
            //    string errorx = ex.ToString();
            //}
            #endregion
        }
		#endregion

		#region Adicionar
		/// <summary>
		/// Inserción de un registro en la base de datos.
		/// </summary>
		public static void Adicionar(ConfiguracionDescuento objDescuento)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("InsertarConfiguracionDescuento");
			sql.ParametersNumber = 16;
            sql.AddParameter("@TipoDescuento", SqlDbType.SmallInt, objDescuento.TipoDescuento);
            sql.AddParameter("@PorcentajeDescuento", SqlDbType.Decimal, objDescuento.PorcDescuento);
            sql.AddParameter("@FechaInicio", SqlDbType.DateTime, objDescuento.FechaInicio);
            sql.AddParameter("@FechaFinal", SqlDbType.DateTime, objDescuento.FechaFinal);
            sql.AddParameter("@HoraInicio", SqlDbType.DateTime, objDescuento.HoraInicio);
            sql.AddParameter("@HoraFinal", SqlDbType.DateTime, objDescuento.HoraFinal);
            sql.AddParameter("@Items", SqlDbType.VarChar, objDescuento.ItemsAfectados);
            sql.AddParameter("@DiasSemana", SqlDbType.VarChar, objDescuento.DiasSemana);
            sql.AddParameter("@TodasHoras", SqlDbType.VarChar, objDescuento.TodasHoras);
            sql.AddParameter("@Valor", SqlDbType.Int, objDescuento.Valor);
            sql.AddParameter("@Redondear", SqlDbType.Bit,objDescuento.Redondear );
            sql.AddParameter("@FechaCreacion", SqlDbType.DateTime,objDescuento.FechaCreacion );
            sql.AddParameter("@FechaModificacion", SqlDbType.DateTime, objDescuento.FechaModificacion);
            sql.AddParameter("@IdUsuario", SqlDbType.VarChar, objDescuento.IdUsuario);
            sql.AddParameter("@Estado", SqlDbType.Bit, objDescuento.Estado);
            sql.AddParameter("@Aplica", SqlDbType.VarChar, objDescuento.Aplica);

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
		public static void Eliminar(short idArticulo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("EliminarDescuento");
			sql.ParametersNumber = 1;
            sql.AddParameter("@IdDescuento", SqlDbType.SmallInt, idArticulo);
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

		#region Método ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa un artículo en particular
		/// </summary>
		public static ConfiguracionDescuento ObtenerItem(short idDescuento)
		{
			ConfiguracionDescuentos objElementos = new ConfiguracionDescuentos();
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

        #region Método ObtenerRegistros
        /// <summary>
        /// Método para obtener de manera directa uno o varios elementos en particular
        /// </summary>
        /// <param name="objUsuario">Objeto con la informacion a filtrar</param>
        /// <returns>Retorna un dataset con los registros encontrados</returns>
        /// 
        public void  ObtenerRegistros(int id) 
        {
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("RecuperarDescuentos");
            sql.ParametersNumber = 1;
            sql.AddParameter("@id", SqlDbType.Int, id);
            try 
            {       
		        SqlDataReader dr=SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure,sql.Text,sql.Parameters);
                while (dr.Read())
                {
                    //ConfiguracionDescuento objConfDescuento = new ConfiguracionDescuento();
                    ConfiguracionDescuento objConfi = new ConfiguracionDescuento();
                    objConfi.IdDescuento = dr.GetInt16(0);
                    objConfi.TipoDescuento = dr.GetInt16(1);
                    #region Traer TipoDescuento
                    switch (objConfi.TipoDescuento)
	                    {
                            case 0: objConfi.TipoDes = "General";
                                break;
                        case 1: objConfi.TipoDes= "Articulo";
                            break;
                        case 2: objConfi.TipoDes= "Manguera";
                            break;
                        case 3: objConfi.TipoDes= "Surtidor";
                            break;
                        case 4: objConfi.TipoDes= "Isla";
                            break;
                        
                    }
                    #endregion

                    objConfi.PorcDescuento = dr.GetDecimal(2);
                    objConfi.FechaInicio = dr.GetDateTime(3);
                    objConfi.FechaFinal = dr.GetDateTime(4);
                    objConfi.HoraInicio = Convert.ToDateTime(dr.GetString(5));
                    objConfi.HoraFinal = Convert.ToDateTime(dr.GetString(6));
                    objConfi.ItemsAfectados = dr.GetString(7);
                    objConfi.DiasSemana = dr.GetString(8);
                    objConfi.TodasHoras = dr.GetBoolean(9);
                    objConfi.Valor = dr.GetInt32(10);
                    objConfi.Redondear = dr.GetBoolean(11);
                    objConfi.FechaCreacion = dr.GetDateTime(12);
                    objConfi.FechaModificacion = dr.GetDateTime(13);
                    objConfi.IdUsuario = dr.GetString(14);
                    objConfi.Estado = dr.GetBoolean(15);
                    objConfi.Aplica = dr.GetString(16);
                    #region Tipo estado
                    if (objConfi.Estado)
                    {
                        objConfi.EstadoStr = "activo";
                    }
                    else 
                    {
                        objConfi.EstadoStr = "false";
                    }
                    #endregion

                    base.AddItem(objConfi.IdDescuento.ToString(), objConfi);
                }
	        }
	        catch (SqlException e)
	        {

		        throw new Exception (e.Message+ "Error BD! ");
	        }finally
            {
                sql= null;
            }


        }


        #endregion

    }
}
