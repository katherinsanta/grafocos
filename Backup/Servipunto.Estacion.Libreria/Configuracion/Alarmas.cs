using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Summary description for Alarmas.
	/// </summary>
	public class Alarmas : Servipunto.Libreria.Collection
	{
		#region Declaraciones
		private object _idConfVentaGratis;
		private Servipunto.Estacion.Libreria.FormasPago _objFormaPago = null;
		#endregion

		#region Constructora Destructora
		/// <summary>
		/// Constructora de la clase Alarmas sin parámetros
		/// </summary>
		public Alarmas()
		{		}
		/// <summary>
		/// Constructora Parametrizada, recibe la llave identity de la selección realizada por el usuario
		/// </summary>
		/// <param name="idConfVentaGratis">NULL ? consulta todas las configuraciones : Consulta tan solo una en particular</param>
		public Alarmas (byte idConfVentaGratis)
		{
			this._idConfVentaGratis = idConfVentaGratis;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por llave tipo string
		/// </summary>
		new public Alarma this[string key]
		{
			get {return(Alarma)base[key];}
		}
		/// <summary>
		/// Indexador por indice tipo int
		/// </summary>
		new public Alarma this[int index]
		{
			get {return(Alarma)base[index];}
		}
		#endregion

		#region Evento Load
		/// <summary>
		/// Recuperación de información contenida en la Base de Datos, tabla ConfVentaGratis
		/// _idConfVentaGratis==Null ? Consulta todos los registros : Consulta el registro seleccionado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e)
		{
			#region Prepara el Estamento SQL
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("AlarmasQuery");
			if(this._idConfVentaGratis != null)
			{
				sql.ParametersNumber = 1;
				sql.AddParameter("@IdConfVentaGratis", SqlDbType.Int, this._idConfVentaGratis);
			}
			#endregion

			#region Ejecución Estamento SQL
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Alarma objAlarma = new Alarma();
				objAlarma.IdConfVentaGratis = dr.GetInt32(0);
				objAlarma.Frecuencia = dr.GetInt32(1);
				objAlarma.Acumulado = dr.GetInt32(2);
				objAlarma.Puerto = dr.GetString(3);
				objAlarma.FecInicial = dr.GetDateTime(4);
				objAlarma.FecFinal = dr.GetDateTime(5);
				objAlarma.HorInicial = dr.GetInt32(6);
				objAlarma.HorFinal = dr.GetInt32(7);
				objAlarma.TipoAutomotor = dr.GetString(8).ToString();
				objAlarma.Estado = dr.GetBoolean(9);
				//objAlarma.CodForPag = dr.GetInt16(10);
				//Presentacion del nombre de la forma de pago
				objAlarma.CodForPag = dr.GetString(10).ToString();
				//La cadena completa de las formas de pago
				objAlarma.NomCodForPag = objAlarma.CodForPag;
				/*if(objAlarma.CodForPag>0)
					objAlarma.NomCodForPag = ConsultarFormaPago(objAlarma.CodForPag);
				else
					objAlarma.NomCodForPag = "Todas";*/
				objAlarma.CodForPagConf = dr.GetInt16(11);
				//Presentación del nombre de la forma de pago de configuracion
				if(objAlarma.CodForPagConf>0)
					objAlarma.NomCodForPagConf = ConsultarFormaPago(objAlarma.CodForPagConf);
				else
					objAlarma.NomCodForPagConf = "Error";
				objAlarma.TiempoAlarma = dr.GetInt16(12);
				objAlarma.Porcentaje = dr.GetInt32(13);
				objAlarma.ValorMaximo = dr.GetDecimal(14);
				objAlarma.TipoAlarma = dr.IsDBNull(15)?(Byte)1:(dr.GetByte(15));
				objAlarma.RutaArchivoAudio = dr.IsDBNull(16)?"":(dr.GetString(16));
				objAlarma.CodigoArticulo = dr.GetInt32(17);
				objAlarma.ValorMinimo = dr.GetDecimal(18);
				base.AddItem(objAlarma.IdConfVentaGratis.ToString(), objAlarma);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Consultar forma de Pago
		/// <summary>
		/// Método que permite la consulta del nombre de la forma de pago seleccionada por cada una de las configuraciones
		/// </summary>
		/// <param name="CodForPago">Id localizado en la BD</param>
		/// <returns>Nombre de la forma de pago</returns>
		public string ConsultarFormaPago(int CodForPago)
		{
			_objFormaPago = new Servipunto.Estacion.Libreria.FormasPago((short)CodForPago);
			return _objFormaPago[0].Nombre.Trim();
		}
		#endregion

		#region Método Adicionar
		/// <summary>
		/// Adiciona una configuración en la BD
		/// </summary>
		/// <param name="objAlarma">Recibe un objeto tipo Alarma con los datos a insertar</param>
		public static void Adicionar (Alarma objAlarma)
		{
			#region Prepara el Estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("AlarmasInsert");
			sql.ParametersNumber=18;
			sql.AddParameter("@Frecuencia", SqlDbType.Int, objAlarma.Frecuencia);
			sql.AddParameter("@Acumulado", SqlDbType.Int, objAlarma.Acumulado);
			sql.AddParameter("@Puerto", SqlDbType.Char, objAlarma.Puerto);
			sql.AddParameter("@FecInicial", SqlDbType.DateTime, objAlarma.FecInicial);
			sql.AddParameter("@FecFinal", SqlDbType.DateTime, objAlarma.FecFinal);
			sql.AddParameter("@HorInicial", SqlDbType.Int, objAlarma.HorInicial);
			sql.AddParameter("@HorFinal", SqlDbType.Int, objAlarma.HorFinal);
			sql.AddParameter("@TipoAutomotor", SqlDbType.VarChar, objAlarma.TipoAutomotor);
			sql.AddParameter("@Estado", SqlDbType.Bit, objAlarma.Estado);
			//sql.AddParameter("@Cod_For_Pag", SqlDbType.SmallInt, objAlarma.CodForPag);
			sql.AddParameter("@Cod_For_Pag", SqlDbType.VarChar, objAlarma.CodForPag);
			sql.AddParameter("@Cod_For_Pag_Conf", SqlDbType.SmallInt, objAlarma.CodForPagConf);
			sql.AddParameter("@Tiempo_Alarma", SqlDbType.SmallInt, objAlarma.TiempoAlarma);
			sql.AddParameter("@Porcentaje", SqlDbType.Int, objAlarma.Porcentaje);
			sql.AddParameter("@ValorMaximo", SqlDbType.Decimal, objAlarma.ValorMaximo);
			sql.AddParameter("@TipoAlarma", SqlDbType.TinyInt, objAlarma.TipoAlarma);
			sql.AddParameter("@rutaArchivoAudio", SqlDbType.VarChar, objAlarma.RutaArchivoAudio);
			sql.AddParameter("@CodigoArticulo", SqlDbType.Int, objAlarma.CodigoArticulo);
			sql.AddParameter("@ValorMinimo", SqlDbType.Decimal, objAlarma.ValorMinimo);
			#endregion

			#region Ejecuciónn Estamento SQL
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

//		#region Método Eliminar
//		public static void Eliminar(int idConfVentaGratis)
//		{
//			#region Prepara el Estamento SQL
//			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
//			sql.Append("AlarmasDelete");
//			sql.ParametersNumber = 1;
//			sql.AddParameter("@IdConfVentaGratis", SqlDbType.Int, idConfVentaGratis);
//			#endregion
//			#region Ejecución Estamento SQL
//			try
//			{
//				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
//			}
//			catch(Exception e)
//			{
//				
//			}
//			#endregion
//		}
//		#endregion

		#region Método Obtener
		/// <summary>
		/// Método que se encarga de obtener una configuración de Alarma específica
		/// </summary>
		/// <param name="idConfVentaGratis">Código de la configuración, valor del identity en la tabla ConfVentaGratis</param>
		/// <returns>Retorna un objeto que tenga el mismo id, de lo contrario devulve null</returns>
		public static Alarma Obtener(byte idConfVentaGratis)
		{
			Alarmas objAlarmas = new Alarmas(idConfVentaGratis);
			if(objAlarmas.Count==1)
				return objAlarmas[0];
			else
				return null;
		}
		#endregion
	}
}
