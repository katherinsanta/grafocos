using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Summary description for Bol_NumOrdenes.
	/// </summary>
	public class Bol_NumOrdenes : Servipunto.Libreria.Collection
	{
		#region Declaraciones
		private object _idNumOrden = null;
		private object _estado = null;
		#endregion

		#region Constructora Destructora
		/// <summary>
		/// Constructora de clase
		/// </summary>
		public Bol_NumOrdenes()
		{ 
		}
		/// <summary>
		/// Consulta de Dosificaciones para un Estado específico.
		/// </summary>
		public Bol_NumOrdenes(byte estado)
		{
			this._estado = estado;
		}
		
		/// <summary>
		/// Constructora Parametrizada, recibe el identity del campo como tal
		/// </summary>
		/// <param name="idNumOrden"></param>
		internal Bol_NumOrdenes(int idNumOrden)
		{
			this._idNumOrden = idNumOrden;
		}
		
		#endregion
		
		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Bol_NumOrden this[string key]
		{
			get { return (Bol_NumOrden)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Bol_NumOrden this[int index]
		{
			get { return (Bol_NumOrden)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperaciòn de informaciòn contenida en la Base de Datos para poblar la colecciòn
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e)
		{
			#region Prepara el Estamento SQL
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("Bol_NumOrdenesQuery");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdNumOrden", SqlDbType.Int, this._idNumOrden);
			sql.AddParameter("@Estado", SqlDbType.TinyInt, this._estado);
			
			#endregion

			#region Ejecuta Estamento SQL
            try
            {
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
                while (dr.Read())
                {
                    Bol_NumOrden objBolNumOrden = new Bol_NumOrden();
                    objBolNumOrden.IdNumOrden = dr.GetInt32(0);
                    objBolNumOrden.NumOrder = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    objBolNumOrden.Prefijo = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    objBolNumOrden.IniConsec = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                    objBolNumOrden.FinConsec = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);
                    objBolNumOrden.ActEconomica = dr.IsDBNull(5) ? "" : dr.GetString(5);
                    objBolNumOrden.Regimen = dr.IsDBNull(6) ? "(Sin Definir)" : (dr.GetString(6).Trim() == "C" ? "Comun" : "Simplificado");
                    objBolNumOrden.Estado = dr.IsDBNull(7) ? (byte)0 : dr.GetByte(7);
                    objBolNumOrden.FechaInicial = dr.IsDBNull(8) ? new DateTime(1900, 1, 1) : dr.GetDateTime(8);
                    objBolNumOrden.FechaFinal = dr.IsDBNull(9) ? new DateTime(1900, 1, 1) : dr.GetDateTime(9);
                    objBolNumOrden.LeyendaAdicional = dr.IsDBNull(10) ? "" : dr.GetString(10);
                    base.AddItem(objBolNumOrden.IdNumOrden.ToString(), objBolNumOrden);
                }
                dr.Close();
                dr = null;
                sql = null;
            }
            catch(Exception ex)
            {

            }
			#endregion
		}
		#endregion

		#region Método Adicionar
		/// <summary>
		/// Inserción de un registro Bol_NumOrden en la Base de Datos
		/// </summary>
		/// <param name="objBolNumOrden">Instancia del objeto que contiene la información</param>
		public static void Adicionar (Bol_NumOrden objBolNumOrden)
		{
			try
			{
				#region Prepara el Estamento SQL
				Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
				sql.Append("Bol_NumOrdenInsert");
				sql.ParametersNumber=10;
				sql.AddParameter("@NumOrder", SqlDbType.VarChar, objBolNumOrden.NumOrder);
				sql.AddParameter("@Prefijo", SqlDbType.VarChar, objBolNumOrden.Prefijo);
				sql.AddParameter("@IniConsec", SqlDbType.Int, objBolNumOrden.IniConsec);
				sql.AddParameter("@FinConsec", SqlDbType.Int, objBolNumOrden.FinConsec);
				sql.AddParameter("@ActEconomica", SqlDbType.VarChar, objBolNumOrden.ActEconomica);
				sql.AddParameter("@Regimen", SqlDbType.VarChar, (objBolNumOrden.Regimen == "Comun"?"C":"S"));				
				sql.AddParameter("@Estado", SqlDbType.TinyInt, objBolNumOrden.Estado);
                sql.AddParameter("@FechaInicio", SqlDbType.DateTime, objBolNumOrden.FechaInicial);
                sql.AddParameter("@FechaFinal", SqlDbType.DateTime, objBolNumOrden.FechaFinal);
                sql.AddParameter("@LeyendaAdicional", SqlDbType.VarChar, objBolNumOrden.LeyendaAdicional);
				#endregion

				#region Ejecución SQL
				try
				{
					SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				}
				catch(SqlException e)
				{
					throw new Exception(e.Message + " !ERROR BD! ");
				}
				finally
				{
					sql = null;
				}
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);

			}

			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método que se encarga de obtener de forma directa una dosificación específica
		/// </summary>
		/// <param name="idNumOrden">Código de la dosificación, valor del identity en la tabla Bol_NumOrdenes</param>
		/// <returns>Si encuentra alguna consistencia, retorna una referencia a ese objeto en particular, por el contrario, retorna null</returns>
		public static Bol_NumOrden Obtener(int idNumOrden)
		{
			Bol_NumOrdenes objBolNumOrdenes = new Bol_NumOrdenes(idNumOrden);
			if(objBolNumOrdenes.Count == 1)
				return objBolNumOrdenes[0];
			else
				return null;
		}
		#endregion


        #region Verificar Alarma
        /// <summary>
        /// Verificar si hay aviso de resolucion activa por vencer
        /// </summary>
        /// <returns></returns>
        public static int VerificarAlarma(ref int diferencia)
        {
            #region Prepara el Estamento SQL
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            int aviso = 0;

            //Servipunto.Estacion.AccesoDatos.EntityClasses.GrillaConsultaVentaCanastillaEntity OBJ = new Servipunto.Estacion.AccesoDatos.EntityClasses.GrillaConsultaVentaCanastillaEntity();
            
            sql.Append("VerificarVencimientoResolucionCanastilla");			
			
			#endregion

			#region Ejecuta Estamento SQL
            try
            {
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, null);
                if (dr.Read())
                {
                    aviso = dr.GetInt32(0);
                    diferencia = dr.GetInt32(1);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + " !ERROR BD! ");
            }

            finally
            {
                sql = null;
            }
            #endregion

            return aviso;
        }
        #endregion
    }
}
