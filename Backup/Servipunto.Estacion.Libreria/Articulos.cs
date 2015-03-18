using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Artículos registrados en el sistema.
	/// </summary>
	public class Articulos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idArticulo = null;
		private object _tipo = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los artículos.
		/// </summary>
		public Articulos()
		{
		}

		/// <summary>
		/// Consulta de artículos de un tipo en especial.
		/// </summary>
		public Articulos(TipoArticulo tipo)
		{
			this._tipo = tipo;
		}

		/// <summary>
		/// Consulta de un artículo en particular.
		/// </summary>
		internal Articulos(short idArticulo)
		{
			this._idArticulo = idArticulo;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Articulo this[string key]
		{
			get { return (Articulo)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Articulo this[int index]
		{
			get { return (Articulo)base[index]; }
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

			sql.Append("Select Cod_Art, Descripcion From Articulo");
			if (this._idArticulo != null)
				sql.Append(" Where Cod_Art = " + this._idArticulo.ToString());
			else if (this._tipo != null)                
				sql.Append(" Where Combustible = " + Convert.ToByte(this._tipo));
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Articulo objArticulo = new Articulo();
				objArticulo.IdArticulo = dr.GetInt16(0);
				objArticulo.Descripcion = dr.IsDBNull(1)?"":dr.GetString(1);
				
				base.AddItem(objArticulo.IdArticulo.ToString(), objArticulo);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un artículo en particular
		/// </summary>
		public static Articulo Obtener(short idArticulo)
		{
			Articulos objElementos = new Articulos(idArticulo);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

        #region Recuperar Articulos
        /// <summary>
        /// Recupera todos los Articulos
        /// </summary>		
        public static DataTable RecuperarArticulos()
        {
            #region Prepare Sql Command
            SqlDataReader dr = null;
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("Select COD_ART, DESCRIPCION From Articulo");

            #endregion

            DataTable TablaArticulo = new DataTable();
            TablaArticulo.Columns.Add("Codigo", typeof(int));
            TablaArticulo.Columns.Add("Descripcion", typeof(string));

            #region Execute Sql
            dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
            while (dr.Read())
            {
                DataRow FilaArticulo = TablaArticulo.NewRow();

                for (int i = 0; i < dr.FieldCount; i++)
                    FilaArticulo[i] = dr.GetValue(i);

                TablaArticulo.Rows.Add(FilaArticulo);

            }
            dr.Close();
            dr = null;
            sql = null;
            return TablaArticulo;
            #endregion
        }
        #endregion
	}
}