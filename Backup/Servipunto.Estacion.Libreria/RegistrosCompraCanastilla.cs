using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
    /// <summary>
    /// Registro Compra Canastilla
    /// </summary>
    public class RegistrosCompraCanastilla : Servipunto.Libreria.Collection
    {
         DateTime _fecha;

        #region  Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fecha">Fecha Jornada</param>
        public RegistrosCompraCanastilla(DateTime fecha)
        {
            _fecha = fecha;
        }

        /// <summary>
        /// Registro  Otros Ingresos
        /// </summary>
        public RegistrosCompraCanastilla()
        {
            
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public RegistroCompraCanastilla this[string key]
        {
            get { return (RegistroCompraCanastilla)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public RegistroCompraCanastilla this[int index]
        {
            get { return (RegistroCompraCanastilla)base[index]; }
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
            sql.Append("select c.IdCompra, c.Fecha,	c.Hora , c.Usuario, a.descripcion, c.CantidadAnterior , c.CantidadActual,	c.Compra from compraCanastilla c inner join articulo a on a.cod_art = c.cod_art");
            if (this._fecha != null)
                sql.Append(" Where Dbo.Finteger(Fecha) = " + this._fecha.ToString("yyyyMMdd"));
        
            #endregion

            #region Execute Sql
            dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
            while (dr.Read())
            {
                RegistroCompraCanastilla objRegistro = new RegistroCompraCanastilla();
                objRegistro.IdCompra = dr.GetInt32(0);
                objRegistro.Fecha = dr.GetDateTime(1);
                objRegistro.Hora = dr.GetDateTime(2);
                objRegistro.Usuario = dr.GetString(3);
                objRegistro.Articulo = dr.GetString(4);
                objRegistro.CantidadAnterior = dr.GetDecimal(5);
                objRegistro.CantidadActual = dr.GetDecimal(6);
                objRegistro.Compra = dr.GetDecimal(7);
                base.AddItem(objRegistro.IdCompra.ToString(), objRegistro);
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
        public static void Adicionar(RegistroCompraCanastilla objRegistro)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("InsertarRegistroCompra");
            /*
             * @Usuario varchar(256),
@Cod_art smallint, 
@CantidadAnterior decimal(15,3), 
@CantidadActual decimal(15,3), 	
@Compra decimal(15,3),
@Fecha datetime,
@Hora datetime
             */
            sql.ParametersNumber = 10;
            sql.AddParameter("@Usuario", SqlDbType.VarChar, objRegistro.Usuario);
            sql.AddParameter("@Cod_art", SqlDbType.SmallInt, objRegistro.Cod_Art);
            sql.AddParameter("@CantidadAnterior", SqlDbType.Decimal, objRegistro.CantidadAnterior);
            sql.AddParameter("@CantidadActual", SqlDbType.Decimal, objRegistro.CantidadActual);
            sql.AddParameter("@Compra", SqlDbType.Decimal, objRegistro.Compra);
            sql.AddParameter("@Fecha", SqlDbType.DateTime, objRegistro.Fecha);
            sql.AddParameter("@Hora", SqlDbType.DateTime, objRegistro.Hora);         
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
        public static DataTable ObtenerDataTableComprasCanastilla()
        {
            Servipunto.Estacion.Libreria.Turnos.JornadaZeta objJornadaZeta;
            objJornadaZeta = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(1);
            try
            {
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                sql.Append("select c.IdCompra, c.Fecha,	c.Hora , c.Usuario, a.descripcion Articulo, c.CantidadAnterior , c.CantidadActual,	c.Compra from compraCanastilla c inner join articulo a on a.cod_art = c.cod_art");
                DataTable objtabla = new DataTable();
                DataSet ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
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
