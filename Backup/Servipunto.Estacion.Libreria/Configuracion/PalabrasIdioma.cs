using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// Maneja el diccionario de palabras `para un idioma especifico
    /// </summary>
    public class PalabrasIdioma :Servipunto.Libreria.Collection
    {
        #region variables publicas
        int _codigo;
        int _idIdioma;
        #endregion

        #region constructores
        /// <summary>
        /// Palabras Idioma
        /// </summary>
        public PalabrasIdioma()
        {

        }

        /// <summary>
        /// Palabras Idioma por codigo e Idioma
        /// </summary>
        /// <param name="codigo"></param>
        public PalabrasIdioma(int codigo, int idIdioma)
        {
            _codigo = codigo;
            _idIdioma = idIdioma;

        }


        /// <summary>
        /// Palabras Idioma por Idioma
        /// </summary>
        /// <param name="codigo"></param>
        public PalabrasIdioma(int idIdioma)
        {            
            _idIdioma = idIdioma;

        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexador por Llave
        /// </summary>
        new public PalabraIdioma this[string key]
        {
            get { return (PalabraIdioma)base[key]; }
        }

        /// <summary>
        /// Indexador por Indice
        /// </summary>
        new public PalabraIdioma this[int index]
        {
            get { return (PalabraIdioma)base[index]; }
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
            sql.Append("ConsultarPalabrasIdioma");
            sql.ParametersNumber = 2;            
            sql.AddParameter("@Codigo", SqlDbType.Int, this._codigo);
            sql.AddParameter("@IdIdioma", SqlDbType.Int, this._idIdioma);           
            #endregion

            #region Execute Sql
            dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            while (dr.Read())
            {
                PalabraIdioma objPalabra = new PalabraIdioma();
                objPalabra.Codigo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                objPalabra.Palabra = dr.IsDBNull(1) ? "" : dr.GetString(1).Trim();
                objPalabra.Traduccion = dr.IsDBNull(2) ? "" : dr.GetString(2).Trim();
                base.AddItem(objPalabra.Codigo.ToString(), objPalabra);
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
        public static void Adicionar(PalabraIdioma objPalabraIdioma)
        {
            //#region Prepare Sql Command
            //Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            //sql.Append("InsertarCapturador");
            //sql.ParametersNumber = 8;
            //sql.AddParameter("@IdCapturador", SqlDbType.SmallInt, objCapturador.IdCapturador);
            //sql.AddParameter("@IdPuerto", SqlDbType.VarChar, objCapturador.IdPuerto);
            //sql.AddParameter("@CapturadorSerial", SqlDbType.TinyInt, objCapturador.CapturadorSerial);
            //sql.AddParameter("@DireccionIP", SqlDbType.VarChar, objCapturador.DireccionIP);
            //sql.AddParameter("@Puerto_Socket_Escucha", SqlDbType.Int, objCapturador.PuertoSocketEscucha);
            //sql.AddParameter("@DireccionIP3ro", SqlDbType.VarChar, objCapturador.DireccionIP3ro);
            //sql.AddParameter("@Puerto_Socket3ro", SqlDbType.Int, objCapturador.PuertoSocket3ro);
            //sql.AddParameter("@IdRegistro", SqlDbType.Int, objCapturador.IdRegistro);

            //#endregion

            //#region Execute Sql
            //try
            //{
            //    SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            //}
            //catch (SqlException e)
            //{
            //    if (e.Message.IndexOf("Llave Duplicada!") != -1)
            //        throw new Exception("Ya existe un capturador identificado con el número " + objCapturador.IdCapturador.ToString());
            //    else
            //        throw new Exception(e.Message + " !ERROR BD! ");
            //}
            //finally
            //{
            //    sql = null;
            //}
            //#endregion
        }
        #endregion

        #region Eliminar
        /// <summary>
        /// Eliminación de un registro de la base de datos.
        /// </summary>
        public static void Eliminar(short idCapturador)
        {
            #region Prepare Sql Command
            //Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            //sql.Append("EliminarCapturador");
            //sql.ParametersNumber = 1;
            //sql.AddParameter("@IdCapturador", SqlDbType.SmallInt, idCapturador);
            //#endregion

            //#region Execute Sql
            //try
            //{
            //    SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            //}
            //catch (SqlException e)
            //{
            //    throw new Exception(e.Message + " !ERROR BD! ");
            //}
            //finally
            //{
            //    sql = null;
            //}
            #endregion
        }
        #endregion

        #region ObtenerItem
        /// <summary>
        /// Método para obtener de manera directa un controlador en particular
        /// </summary>
        public static PalabraIdioma ObtenerItem(int codigo, int idIdioma)
        {
            PalabrasIdioma objElementos = new PalabrasIdioma(codigo, idIdioma);
            if (objElementos.Count == 1)
                return objElementos[0];
            else
                return null;
        }
        #endregion

        /// <summary>
        /// Traduccion Palabra
        /// </summary>
        /// <param name="codigoPalabra"></param>
        /// <param name="IdIdioma"></param>
        /// <returns></returns>
        public static string Traduccion(int codigoPalabra, int IdIdioma)
        {
            try
            {
                PalabraIdioma objFrase = new PalabraIdioma();
                if ((objFrase = ObtenerItem(codigoPalabra, IdIdioma)) != null)
                    return objFrase.Traduccion; 
            }
            catch
            {                
                return "";
            }
            
            return "";
        }
    }
}
