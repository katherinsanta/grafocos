using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
    /// <summary>
    /// 
    /// </summary>
    public class TiposAutorizacionExterna : Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones
        private object _idTipoAutorizacionExterna = null;
        
        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public TipoAutorizacionExterna this[string key]
        {
            get { return (TipoAutorizacionExterna)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public TipoAutorizacionExterna this[int index]
        {
            get { return (TipoAutorizacionExterna)base[index]; }
        }
        #endregion

        #region Constructor
		/// <summary>
		/// Consulta de todas las formas de pago configuradas.
		/// </summary>
		public TiposAutorizacionExterna()
		{
		}

        /// <summary>
        ///  Constructor con id
        /// </summary>
        /// <param name="idTipoAutorizacionExterna"></param>
        internal TiposAutorizacionExterna(int idTipoAutorizacionExterna)
        {
            _idTipoAutorizacionExterna = idTipoAutorizacionExterna;

        }

		#endregion

        /// <summary>
        /// Recuperación de información contenida en la base de datos para poblar la colección.
        /// </summary>		
        protected override void Load(object sender, EventArgs e)
        {
            #region Prepare Sql Command
            SqlDataReader dr = null;
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ConsultarTipoAutorizacionExterna");
            sql.ParametersNumber = 1;
            sql.AddParameter("@IdTipoAutorizacionExterna", SqlDbType.SmallInt, this._idTipoAutorizacionExterna);
            #endregion

            #region Execute Sql
            dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            while (dr.Read())
            {
                TipoAutorizacionExterna objTipoAutorizacion = new TipoAutorizacionExterna();
               objTipoAutorizacion.IdTipoAutorizacion = (short)dr.GetByte(0);
               objTipoAutorizacion.TipoAutorizacion  = dr.GetString(1);
               objTipoAutorizacion.Descripcion = dr.GetString(2);

                base.AddItem(objTipoAutorizacion.IdTipoAutorizacion.ToString(), objTipoAutorizacion);
            }
            dr.Close();
            dr = null;
            sql = null;
            #endregion
        }

        #region Método Obtener
        /// <summary>
        /// Método para obtener de manera directa el tipo autorizacion en particular
        /// </summary>
        public static TipoAutorizacionExterna ObtenerItem(int idTipoAutorizacionExterna)
        {
            Libreria.TiposAutorizacionExterna objElementos = new  Libreria.TiposAutorizacionExterna(idTipoAutorizacionExterna);
            if (objElementos.Count == 1)
                return objElementos[0];
            else
                return null;
        }
        #endregion
    }
}
