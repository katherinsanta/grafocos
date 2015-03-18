using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Prepagos
{
    /// <summary>
    /// Prepagos
    /// </summary>
    public class Prepagos : Servipunto.Libreria.Collection
    {
        int _numero = 0;
        decimal _denominacion = 0;
        decimal _estado; 

        #region Constructor
        /// <summary>
        /// Consulta de todos los artículos.
        /// </summary>
        public Prepagos()
        {
        }

        public Prepagos(int numeroPrepago)
        {
            _numero = numeroPrepago;
        }


        public Prepagos(decimal denominacion, int estado)
        {
            _denominacion = denominacion;
            _estado = estado;
        }

        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public Prepago this[string key]
        {
            get { return (Prepago)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public Prepago this[int index]
        {
            get { return (Prepago)base[index]; }
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
            sql.Append("Select NumeroPrepago,IdCompania,NumeroInicialTiqueteCreado,NumeroFinalTiqueteCreado,NumeroTiqueteInicialAsignacion,NumeroTiqueteFinalAsignacion,FechaCreacion,FechaAsignacion,FechaAnulacion,FechaTurnoUtilizacion,FechaRealUtilizacion,Placa,Cod_Cli,CodigoCentroVenta,Denominacion,EstadoPrepago,IdUsuarioCreo,IdUsuarioAsigno,IdUsuarioUtilizo from prepago");

            if ( _numero != 0)
                sql.Append(" where numeroPrepago = '" + _numero.ToString() + "'");

            else if (_denominacion != 0)
                sql.Append(" where denominacion = '" + _denominacion.ToString().Replace(',', '.') + "'" + " and " + " estadoPrepago = '" +_estado.ToString() + "'" );


            #endregion

            #region Execute Sql
            try
            {
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
                while (dr.Read())
                {
                    Prepago objPrepago = new Prepago();
                    objPrepago.NumeroPrepago = dr.GetInt32(0);
                    objPrepago.IdCompania = dr.GetString(1);
                    objPrepago.NumeroInicialTiqueteCreado = dr.GetInt32(2);
                    objPrepago.NumeroFinalTiqueteCreado = dr.GetInt32(3);
                    objPrepago.NumeroTiqueteInicialAsignacion = dr.GetInt32(4);
                    objPrepago.NumeroTiqueteFinalAsignacion = dr.GetInt32(5);
                    objPrepago.FechaCreacion = dr.GetDateTime(6);
                    objPrepago.FechaAsignacion = dr.GetDateTime(7);
                    objPrepago.FechaAnulacion = dr.GetDateTime(8);
                    objPrepago.FechaTurnoUtilizacion = dr.GetDateTime(9);
                    objPrepago.FechaRealUtilizacion = dr.GetDateTime(10);
                    objPrepago.Placa = dr.GetString(11);
                    objPrepago.Cod_Cli = dr.GetString(12);
                    objPrepago.CodigoCentroVenta = dr.GetString(13);
                    objPrepago.Denominacion = dr.GetDecimal(14);
                    int valor = dr.GetInt32(15);
                    objPrepago.EstadoPrepago = valor == 1 ? EstadoPrepago.Creado : valor == 2 ? EstadoPrepago.Asignado : valor == 3 ? EstadoPrepago.Utilizado : EstadoPrepago.Anulado;
                    objPrepago.IdUsuarioCreo = dr.GetString(16);
                    objPrepago.IdUsuarioAsigno = dr.GetString(17);
                    objPrepago.IdUsuarioUtilizo = dr.GetString(18);
                    base.AddItem(objPrepago.NumeroPrepago.ToString(), objPrepago);
                }
                dr.Close();
                dr = null;
                sql = null;
            }
            catch (Exception ex)
            {
                string errorx = ex.ToString();
            }
            #endregion
        }
        #endregion

        #region Adicionar
        /// <summary>
        /// Inserción de un registro en la base de datos.
        /// </summary>
        public static void Adicionar(Prepago objPrepago)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("InsertarPrepago");
            sql.ParametersNumber = 19;
            sql.AddParameter("@NumeroPrepago", SqlDbType.Int, objPrepago.NumeroPrepago);
            sql.AddParameter("@IdCompania", SqlDbType.VarChar, objPrepago.IdCompania);
            sql.AddParameter("@NumeroInicialTiqueteCreado", SqlDbType.Int, objPrepago.NumeroInicialTiqueteCreado);
            sql.AddParameter("@NumeroFinalTiqueteCreado", SqlDbType.Int, objPrepago.NumeroFinalTiqueteCreado);
            sql.AddParameter("@NumeroTiqueteInicialAsignacion", SqlDbType.Int, objPrepago.NumeroTiqueteInicialAsignacion);
            sql.AddParameter("@NumeroTiqueteFinalAsignacion", SqlDbType.Int, objPrepago.NumeroTiqueteFinalAsignacion);
            sql.AddParameter("@FechaCreacion", SqlDbType.DateTime, objPrepago.FechaCreacion);
            sql.AddParameter("@FechaAsignacion", SqlDbType.DateTime, objPrepago.FechaAsignacion);
            sql.AddParameter("@FechaAnulacion", SqlDbType.DateTime, objPrepago.FechaAnulacion);
            sql.AddParameter("@FechaTurnoUtilizacion", SqlDbType.DateTime, objPrepago.FechaTurnoUtilizacion);
            sql.AddParameter("@FechaRealUtilizacion", SqlDbType.DateTime, objPrepago.FechaRealUtilizacion);
            sql.AddParameter("@Placa", SqlDbType.VarChar, objPrepago.Placa);
            sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, objPrepago.Cod_Cli);
            sql.AddParameter("@CodigoCentroVenta", SqlDbType.VarChar, objPrepago.CodigoCentroVenta);
            sql.AddParameter("@Denominacion", SqlDbType.Decimal, objPrepago.Denominacion);
            sql.AddParameter("@EstadoPrepago", SqlDbType.Int, objPrepago.EstadoPrepago);
            sql.AddParameter("@IdUsuarioCreo", SqlDbType.VarChar, objPrepago.IdUsuarioCreo);
            sql.AddParameter("@IdUsuarioAsigno", SqlDbType.VarChar, objPrepago.IdUsuarioAsigno);
            sql.AddParameter("@IdUsuarioUtilizo", SqlDbType.VarChar, objPrepago.IdUsuarioUtilizo);

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

        #region ObtenerExistencias
        /// <summary>
        /// Obtener existencias
        /// </summary>
        /// <returns>Datatable</returns>
        public static DataTable ObtenerExistencias()        
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Value",typeof(decimal));
            tabla.Columns.Add("Quantity", typeof(int));

            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("Select Denominacion Value,  count(*) Quantity from prepago where estadoprepago = 1 group by denominacion");
            SqlDataReader datos = null;
            #region Execute Sql
            try
            {
               datos =  SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
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

            while (datos.Read())
            {
                decimal deno = datos.GetDecimal(0);
                int cant = datos.GetInt32(1);                
                tabla.Rows.Add(deno, cant);
            }            
            return tabla;
        }
        #endregion

    }


}
