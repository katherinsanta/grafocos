using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
    /// <summary>
    /// Otroa Ingresos
    /// </summary>
    public class RegistrosOtrosIngresos : Servipunto.Libreria.Collection
    {
        DateTime _fecha;

        #region  Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fecha">Fecha Jornada</param>
        public RegistrosOtrosIngresos(DateTime fecha)
        {
            _fecha = fecha;
        }

        /// <summary>
        /// Registro  Otros Ingresos
        /// </summary>
        public RegistrosOtrosIngresos()
        {
            
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public RegistroOtroIngreso this[string key]
        {
            get { return (RegistroOtroIngreso)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public RegistroOtroIngreso this[int index]
        {
            get { return (RegistroOtroIngreso)base[index]; }
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
            sql.Append("Select IdRegistroOtrosIngresos, Fecha, FechaReal, Hora, IdConceptoOtrosIngresos, ValorOtroIngreso From RegistroOtrosIngresos");
            if (this._fecha != null)
                sql.Append(" Where Dbo.Finteger(Fecha) = " + this._fecha.ToString("yyyyMMdd"));
        
            #endregion

            #region Execute Sql
            dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
            while (dr.Read())
            {
                RegistroOtroIngreso objRegistro = new RegistroOtroIngreso();
                objRegistro.IdRegistro = dr.GetInt32(0);
                objRegistro.Fecha = dr.GetDateTime(1);
                objRegistro.FechaReal = dr.GetDateTime(2);
                objRegistro.Hora = dr.GetDateTime(3);
                objRegistro.IdConcepto = dr.GetInt32(4);
                objRegistro.Valor = dr.GetDecimal(5);
                base.AddItem(objRegistro.IdRegistro.ToString(), objRegistro);
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
        public static void Adicionar(RegistroOtroIngreso objRegistro)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("InsertarRegistroOtroIngreso");
            sql.ParametersNumber = 10;
            sql.AddParameter("@Fecha", SqlDbType.DateTime, objRegistro.Fecha);
            sql.AddParameter("@FechaReal", SqlDbType.DateTime, objRegistro.FechaReal);
            sql.AddParameter("@Hora", SqlDbType.DateTime, objRegistro.Hora);
            sql.AddParameter("@IdConceptoOtrosIngresos", SqlDbType.Int, objRegistro.IdConcepto);
            sql.AddParameter("@ValorOtroIngreso", SqlDbType.Decimal, objRegistro.Valor);         
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
        /// Obtener datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable ObtenerDataTableOtrosIngresos()
        {
            Servipunto.Estacion.Libreria.Turnos.JornadaZeta objJornadaZeta;            
            objJornadaZeta = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(1);
            try
            {
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                sql.Append("Select  IdRegistroOtrosIngresos Id, dbo.finteger(r.Fecha) Fecha, dbo.hinteger(r.Hora) Hora, r.IdConceptoOtrosIngresos IdConcepto, c.NombreOtroIngreso Nombre, r.ValorOtroIngreso Valor From RegistroOtrosIngresos r inner join ConceptoOtroIngreso c on r.IdConceptoOtrosIngresos = c.IdConceptoOtroIngreso  Where dbo.Finteger(fecha) = '" + objJornadaZeta.Fecha.ToString("yyyyMMdd") + "'");
                DataTable objtabla = new DataTable();
                DataSet ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
            catch(Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        #region Adicionar
        /// <summary>
        /// Inserción de un registro en la base de datos.
        /// </summary>
        public static void Consolidar(DateTime fecha)
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("CalcularTotalOtrosIngresosJornada");
            sql.ParametersNumber = 1;
            sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);           
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
        /// Recuperar Consolidado
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DataTable RecuperarConsolidado(DateTime fecha)
        {
            #region Execute Sql
            try
            {
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
                sql.Append("Select r.IdConceptoOtrosIngresos IdConcepto, c.NombreOtroIngreso Nombre, Sum(r.ValorOtroIngreso) Total from RegistroOtrosIngresos r inner join dbo.ConceptoOtroIngreso c on c.IdConceptoOtroIngreso = r.IdConceptoOtrosIngresos Where dbo.Finteger(Fecha) = '" + fecha.ToString("yyyyMMdd") + " 'Group by r.IdConceptoOtrosIngresos,c.NombreOtroIngreso");
                DataTable objtabla = new DataTable();
                DataSet ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
                
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message + " !ERROR BD! ");
            }
       
            #endregion
        }

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
                sql.Append("Delete from dbo.RegistroOtrosIngresos where IdRegistroOtrosIngresos = " + id.ToString());             
               SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);                

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message + " !ERROR BD! ");
            }

            #endregion
        }

    }
}
