using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
    /// <summary>
    /// Inventario Items Cnastilla
    /// </summary>
    public class InventarioItemsCanastilla: Servipunto.Libreria.Collection
    {
        DateTime _fecha;
        short _cod_art;

        #region  Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fecha">Fecha Jornada</param>
        public InventarioItemsCanastilla(DateTime fecha, short cod_art)
        {
            _fecha = fecha;
            _cod_art = cod_art;
        }

        /// <summary>
        /// Registro  Otros Ingresos
        /// </summary>
        public InventarioItemsCanastilla()
        {
            
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public InventarioItemCanastilla this[string key]
        {
            get { return (InventarioItemCanastilla)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public InventarioItemCanastilla this[int index]
        {
            get { return (InventarioItemCanastilla)base[index]; }
        }
        #endregion




        #region Load Event
        /// <summary>
        /// Recuperación de información contenida en la base de datos para poblar la colección.
        /// </summary>		
        protected override void Load(object sender, EventArgs e)
        {
        //    #region Prepare Sql Command
        //    SqlDataReader dr = null;
        //    Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
        //    sql.Append("select dbo.finteger(Fecha), Cod_Art, SaldoInicial, SaldoFinal, Compras, Salidas From InventarioCanastilla	");
        //    if (this._fecha != null )
        //        sql.Append(" Where Dbo.Finteger(Fecha) = '" + this._fecha.ToString("yyyyMMdd") + "' And Cod_Art='" + this._cod_art.ToString() + "'");
        
        //    #endregion

        //    #region Execute Sql
        //    dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
        //    while (dr.Read())
        //    {
        //        InventarioItemCanastilla objRegistro = new InventarioItemCanastilla();                
        //        objRegistro.Fecha = dr.GetDateTime(0);
        //        objRegistro.Cod_Art = dr.GetInt16(1);
        //        objRegistro.SaldoInicial = dr.GetDecimal(2);
        //        objRegistro.SaldoFinal = dr.GetDecimal(3);
        //        objRegistro.Compras = dr.GetDecimal(4);
        //        objRegistro.Salidas = dr.GetDecimal(5);                
        //        base.AddItem(objRegistro.Fecha.ToString("yyyyMMdd") + objRegistro.Cod_Art.ToString().PadLeft(3,'0'), objRegistro);
        //    }
        //    dr.Close();
        //    dr = null;
        //    sql = null;
        //    #endregion
        }
        #endregion

        #region Adicionar
        /// <summary>
        /// Inserción de un registro en la base de datos.
        /// </summary>
        public static void Adicionar(InventarioItemCanastilla objRegistro)
        {
//            #region Prepare Sql Command
//            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

//            sql.Append("InsertarRegistroInventario");
//            /*
//             * @Usuario varchar(256),
//@Cod_art smallint, 
//@CantidadAnterior decimal(15,3), 
//@CantidadActual decimal(15,3), 	
//@Compra decimal(15,3),
//@Fecha datetime,
//@Hora datetime
//             */
//            sql.ParametersNumber = 10;
//            sql.AddParameter("@Fecha", SqlDbType.DateTime, objRegistro.Fecha);
//            sql.AddParameter("@Cod_art", SqlDbType.SmallInt, objRegistro.Cod_Art);
//            sql.AddParameter("@SaldoInicial", SqlDbType.Decimal, objRegistro.SaldoInicial);
//            sql.AddParameter("@SaldoFinal", SqlDbType.Decimal, objRegistro.SaldoFinal);
//            sql.AddParameter("@Compras", SqlDbType.Decimal, objRegistro.Compras);
//            sql.AddParameter("@Salidas", SqlDbType.Decimal, objRegistro.Salidas);            
//            #endregion

//            #region Execute Sql
//            try
//            {
//                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
//            }
//            catch (SqlException e)
//            {
//                throw new Exception(e.Message + " !ERROR BD! ");
//            }
//            finally
//            {
//                sql = null;
//            }
//            #endregion
        }
        #endregion

        
        /// <summary>
        /// Eliminar Registro
        /// </summary>
        /// <param name="id"></param>
        public static void EliminarRegistro(int id)
        {
            #region Execute Sql
            try
            {
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                sql.Append("Delete from dbo.compraCanastilla where IdCompra = " + id.ToString());             
               SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);                

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message + " !ERROR BD! ");
            }

            #endregion
        }

        /// <summary>
        /// Obtener datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable ObtenerDataTableInventarioItemCanastilla(DateTime fecha)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ObtenerInventarioArticulo");  
            sql.ParametersNumber = 1;
            sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);
            
         
            #endregion

            try
            {
                DataTable objtabla = new DataTable();
                DataSet ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

    }
}
