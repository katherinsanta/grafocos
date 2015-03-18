using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Pagos de una venta
	/// </summary>
	public class Pagos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		//private object _id_pagos = null;
		private object _consecutivo = null;

		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de pagos.
		/// </summary>
		public Pagos()
		{
		}

		/// <summary>
		/// Consulta de una forma de pago en particular.
		/// </summary>
		public Pagos(object consecutivo)
		{
			//this._id_pagos = id_Pago;
			this._consecutivo = consecutivo;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Pago this[string key]
		{
			get { return (Pago)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Pago this[int index]
		{
			get { return (Pago)base[index]; }
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

			sql.Append("RecuperarPago");
			sql.ParametersNumber = 1;
			//sql.AddParameter("@Id_Pagos", SqlDbType.Int, this._id_pagos);
			sql.AddParameter("@Consecutivo", SqlDbType.Int, this._consecutivo);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Pago objPago = new Pago();
				objPago.IdPago = dr.GetInt32(0);
				objPago.PrefijoVenta = dr.IsDBNull(1)?"(sin definir)":dr.GetString(1);
				objPago.ConsecutivoVenta = dr.GetInt32(2);
				objPago.Total = dr.GetValue(3).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(3).ToString().Trim());
				objPago.CodigoFormaPago = dr.GetInt32(4);
				objPago.Fecha = DateTime.Parse(dr.GetValue(5).ToString().Trim());
				objPago.FechaReal = DateTime.Parse(dr.GetValue(6).ToString().Trim());
				objPago.ConsecutivoFormaPago = dr.GetString(7);
				objPago.Cantidad = dr.GetValue(8).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(8).ToString().Trim());
				objPago.ValorNeto = dr.GetValue(9).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(9).ToString().Trim());
				objPago.Descuento = dr.GetValue(10).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(10).ToString().Trim());
				objPago.subTotal = dr.GetValue(11).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(11).ToString().Trim());
				objPago.Iva = dr.GetValue(12).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(12).ToString().Trim());
				objPago.TotalCuota = dr.GetValue(13).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(13).ToString().Trim());
				objPago.CodigoArticulo = int.Parse(dr.GetValue(14).ToString());

				base.AddItem(objPago.IdPago.ToString(), objPago);
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
		public static void Adicionar(Pago objPago)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarPago");
			sql.ParametersNumber = 15;
			sql.AddParameter("@Id_Pagos", SqlDbType.Int, objPago.IdPago);
			sql.AddParameter("@Prefijo", SqlDbType.VarChar, objPago.PrefijoVenta);
			sql.AddParameter("@Consecutivo", SqlDbType.Int, objPago.ConsecutivoVenta);
			sql.AddParameter("@Total", SqlDbType.Decimal, objPago.Total);
			sql.AddParameter("@Cod_for_Pag", SqlDbType.Int, objPago.CodigoFormaPago);
			sql.AddParameter("@Fecha", SqlDbType.DateTime, objPago.Fecha);
			sql.AddParameter("@Fecha_Real", SqlDbType.DateTime, objPago.FechaReal);
			sql.AddParameter("@Numero_Consecutivo_FP", SqlDbType.VarChar, objPago.ConsecutivoFormaPago);
			sql.AddParameter("@Cantidad", SqlDbType.Decimal, objPago.Cantidad);
			sql.AddParameter("@ValorNeto", SqlDbType.Decimal, objPago.ValorNeto);
			sql.AddParameter("@Descuento", SqlDbType.Decimal, objPago.Descuento);
			sql.AddParameter("@SubTotal", SqlDbType.Decimal, objPago.subTotal);
			sql.AddParameter("@Vr_Iva", SqlDbType.Decimal, objPago.Iva);
			sql.AddParameter("@Total_Cuota", SqlDbType.Decimal, objPago.TotalCuota);
			sql.AddParameter("@Cod_Art", SqlDbType.Int, objPago.CodigoArticulo);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.ToUpper().IndexOf("VIOLATION OF PRIMARY KEY") != -1)
					throw new Exception("Ya existe un pago identificada con el código " + objPago.IdPago.ToString() + "!");
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(int id_Pago, int consecutivo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarPago");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdFormaPago", SqlDbType.Int, id_Pago);
			sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);
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
		public static Pago ObtenerItem(int consecutivo)
		{
			Pagos objElementos = new Pagos(consecutivo);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region ObtenerItems
		/// <summary>
		/// Método para obtener de manera directa varias formas de pago asociadas a una venta
		/// </summary>
		public static DataSet ObtenerItems(int consecutivo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarPago");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);
			#endregion

			#region Execute Sql
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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
