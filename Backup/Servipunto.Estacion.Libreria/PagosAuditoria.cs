using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Biblioteca de Colección de clases para adminsitrar la auditoria de cambios a las formas de pago de las venta(s)
	/// </summary>
	public class PagosAuditoria : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		//private object _id_pagos = null;
		private object _consecutivo = null;

		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de pagos.
		/// </summary>
		public PagosAuditoria()
		{
		}

		/// <summary>
		/// Consulta de una forma de pago en particular.
		/// </summary>
		public PagosAuditoria(object consecutivo)
		{
			//this._id_pagos = id_Pago;
			this._consecutivo = consecutivo;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public PagoAuditoria this[string key]
		{
			get { return (PagoAuditoria)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public PagoAuditoria this[int index]
		{
			get { return (PagoAuditoria)base[index]; }
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

			sql.Append("RecuperarPagoAuditoria");
			sql.ParametersNumber = 1;
			//sql.AddParameter("@Id_Pagos", SqlDbType.Int, this._id_pagos);
			sql.AddParameter("@Consecutivo", SqlDbType.Int, this._consecutivo);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				PagoAuditoria objPagoAuditoria = new PagoAuditoria();
				objPagoAuditoria.CodigoPagosAuditoria = dr.GetInt32(0);
				objPagoAuditoria.Consecutivo = dr.GetInt32(1);
				objPagoAuditoria.ValorInicial = dr.GetValue(2).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(2).ToString().Trim());
				objPagoAuditoria.CodigoFormaPagoInicial = dr.GetInt32(3);
				objPagoAuditoria.ValorFinal = dr.GetValue(4).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(4).ToString().Trim());
				objPagoAuditoria.CodigoFormaPagoFinal = dr.GetInt32(5);
				objPagoAuditoria.IdUsuario = dr.GetValue(6).ToString();
				objPagoAuditoria.FechaCambio = DateTime.Parse(dr.GetValue(7).ToString().Trim());
				objPagoAuditoria.Observaciones = dr.GetValue(8).ToString();
				base.AddItem(objPagoAuditoria.CodigoPagosAuditoria.ToString(), objPagoAuditoria);
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
		public static void Adicionar(PagoAuditoria objPagoAuditoria)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarPagoAduditoria");
			sql.ParametersNumber = 9;
			sql.AddParameter("@IdPagosA", SqlDbType.Int, objPagoAuditoria.CodigoPagosAuditoria);
			sql.AddParameter("@Consecutivo", SqlDbType.Int, objPagoAuditoria.Consecutivo);
			sql.AddParameter("@ValorInicial", SqlDbType.Decimal, objPagoAuditoria.ValorInicial);
			sql.AddParameter("@CodigoFormaPagoInicial", SqlDbType.Int, objPagoAuditoria.CodigoFormaPagoInicial);
			sql.AddParameter("@ValorFinal", SqlDbType.Decimal, objPagoAuditoria.ValorFinal);
			sql.AddParameter("@CodigoFormaPagoFinal", SqlDbType.Int, objPagoAuditoria.CodigoFormaPagoFinal);
			sql.AddParameter("@IdUsuario", SqlDbType.VarChar, objPagoAuditoria.IdUsuario);
			sql.AddParameter("@FechaCambio", SqlDbType.DateTime, objPagoAuditoria.FechaCambio);
			sql.AddParameter("@Observaciones", SqlDbType.VarChar, objPagoAuditoria.Observaciones);

			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.ToUpper().IndexOf("VIOLATION OF PRIMARY KEY") != -1)
					throw new Exception("Ya existe un pago identificada con el código " + objPagoAuditoria.CodigoPagosAuditoria.ToString() + "!");
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
		public static void Eliminar(int codigoPagosAuditoria)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarPagoAuditoria");
			sql.ParametersNumber = 1;
			sql.AddParameter("@CodigoPagosAuditoria", SqlDbType.SmallInt, codigoPagosAuditoria);
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
		/// Método para obtener de manera directa una auditoria de pago en particular
		/// </summary>
		public static PagoAuditoria ObtenerItem(int consecutivo)
		{
			PagosAuditoria objElementos = new PagosAuditoria(consecutivo);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region ObtenerItems
		/// <summary>
		/// Método para obtener de manera directa varias auditorias de pago asociadas a una venta
		/// </summary>
		public static DataSet ObtenerItems(int consecutivo, DateTime fechaInicio, DateTime fechaFin,int opcion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarPagoAuditoria");
			sql.ParametersNumber = 4;
			sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);
			sql.AddParameter("@FechaInicio", SqlDbType.DateTime, fechaInicio);
			sql.AddParameter("@FechaFin", SqlDbType.DateTime, fechaFin);
			sql.AddParameter("@Opcion", SqlDbType.Int, opcion);

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
