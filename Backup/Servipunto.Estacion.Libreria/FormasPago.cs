using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Administración de Formas de Pago.
	/// </summary>
	public class FormasPago : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idFormaPago;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de Todos los Clientes
		/// </summary>
		public FormasPago()
		{
		}

		/// <summary>
		/// Consulta de un Cliente en Particular
		/// </summary>
		internal FormasPago(short idFormaPago)
		{
			this._idFormaPago = idFormaPago;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public FormaPago this[string key]
		{
			get { return (FormaPago)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public FormaPago this[int index]
		{
			get { return (FormaPago)base[index]; }
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

			sql.Append("Select Cod_For_Pag, Descripcion From Form_Pag");
			if (this._idFormaPago != null)
			{
				sql.Append(" Where Cod_For_Pag = @IdFormaPago");
				sql.ParametersNumber = 1;
				sql.AddParameter("@IdFormaPago", SqlDbType.SmallInt, this._idFormaPago);
			}
			sql.Append(" Order By Cod_For_Pag");
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				FormaPago objFormaPago = new FormaPago();
				objFormaPago.IdFormaPago = dr.GetInt16(0);
				objFormaPago.Nombre = dr.IsDBNull(1)?"(sin definir)":dr.GetString(1);

				base.AddItem(objFormaPago.IdFormaPago.ToString(), objFormaPago);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un empleado en particular
		/// </summary>
		public static FormaPago Obtener(short idFormaPago)
		{
			FormasPago objElementos = new FormasPago(idFormaPago);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}