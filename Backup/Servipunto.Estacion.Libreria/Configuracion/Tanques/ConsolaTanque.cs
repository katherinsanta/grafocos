using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Libreria.Configuracion.Tanques
{
    /// <summary>
    /// Clase de Objetos Pra Consola de Tanques
    /// Autor: Maria Angelica Guerrero
    /// Fecha: 22 Diciembre 2011
    /// </summary>
   public class ConsolaTanque
    {
        #region Declaracion Variables
        int idConsola;
        string nombre, protocolo, tipo, direccionIp, puertoLogico, puertoSerial;
        #endregion

        
		#region Constructor/Destructor
			/// <summary>
			/// ConsolaTanques Class Constructor
			/// </summary>
        public ConsolaTanque() 
        {

        }
		#endregion

        /// <summary>
        /// Representa El ID de la ConsolaTanques
        /// </summary>
        public int IdConsola
        {
            get { return idConsola; }
            set { idConsola = value; }
        }
        /// <summary>
        /// Representa el Nombre de la consola
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /// <summary>
        /// Representa el protocolo 
        /// </summary>
        public string Protocolo
        {
            get { return protocolo; }
            set { protocolo = value; }
        }
        /// <summary>
        /// Representa el Tipo De consola
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        /// <summary>
        /// Representa La direccion IP 
        /// </summary>
        public string DireccionIP
        {
            get { return direccionIp; }
            set { direccionIp = value; }
        }
        /// <summary>
        /// Representa el puerto logico
        /// </summary>
        public string PuertoLogico
        {
            get { return puertoLogico; }
            set { puertoLogico = value; }
        }

        public string PuertoSerial
        {
            get { return puertoSerial; }
            set { puertoSerial = value; }
        }
        #region Modify
        /// <summary>
        /// Actualiza Propiedades de la consola de tanques
        /// </summary>
        public void Modificar()
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("ActualizarConsolaTanque");
            sql.ParametersNumber = 7;
            sql.AddParameter("IdConsola", SqlDbType.Int, this.idConsola);
            sql.AddParameter("@Nombre", SqlDbType.VarChar, this.nombre);
            sql.AddParameter("@Protocolo", SqlDbType.VarChar, this.protocolo);
            sql.AddParameter("@Tipo", SqlDbType.VarChar, this.tipo);
            sql.AddParameter("@DireccionIP", SqlDbType.VarChar, this.direccionIp);
            sql.AddParameter("@PuertoLogico", SqlDbType.VarChar, this.puertoLogico);
            sql.AddParameter("@PuertoSerial", SqlDbType.VarChar, this.puertoSerial);

            #endregion

            #region Execute SqlCommand
            try
            {
                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            }
            catch (SqlException exx)
            {
                throw new Exception(exx.Message + " !ERROR BD! ");
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
