using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Prepagos
{
    public class Denominaciones : Servipunto.Libreria.Collection
    {
        #region Sección de Declaraciones
        private object _idArticulo = null;
        private object _tipo = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Consulta de todos los artículos.
        /// </summary>
        public Denominaciones()
        {
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public Denominacion this[string key]
        {
            get { return (Denominacion)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public Denominacion this[int index]
        {
            get { return (Denominacion)base[index]; }
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

            sql.Append("Select denominacion from  denominacion");
            #endregion

            #region Execute Sql
            try
            {
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
                while (dr.Read())
                {
                    Denominacion objDenominacion = new Denominacion();
                    objDenominacion.ValorDenominacion = dr.GetDecimal(0);
                    base.AddItem(objDenominacion.ValorDenominacion.ToString(), objDenominacion);
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
    }
}
