using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// Clase configuracion Automatica Zeta
    /// </summary>
    public class ConfiguracionZetaAutomatica
    {
         #region Sección de Declaraciones
	    int _idConfiguracionZetaAutomatico;
	    DateTime  _fechaCreacion  ;
        DateTime _fechaActualizacion;
        string _usuario;
        DateTime _horaInicio;
        DateTime _horaFinal;        
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public ConfiguracionZetaAutomatica()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Grupo
		/// </summary>
        public int idConfiguracionZetaAutomatico
		{
			get { return this._idConfiguracionZetaAutomatico; }
            set { this._idConfiguracionZetaAutomatico = value; }
		}

		/// <summary>
		/// Nombre descriptivo
		/// </summary>
		public DateTime FechaCreacion
		{
			get { return this._fechaCreacion; }
			set { this._fechaCreacion = value; }
		}

		/// <summary>
		/// Descripción
		/// </summary>
		public DateTime FechaActualizacion
		{
			get { return this._fechaActualizacion; }
            set { this._fechaActualizacion = value; }
		}

        /// <summary>
        /// Descripción
        /// </summary>
        public string Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }   
        }

        /// <summary>
        /// Estado
        /// </summary>
        public DateTime HoraInicio
        {
            get { return this._horaInicio; }
            set { this._horaInicio = value; }
        }

        /// <summary>
        /// Estado
        /// </summary>
        public DateTime HoraFinal
        {
            get { return this._horaFinal; }
            set { this._horaFinal = value; }
        }

        

		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: Nombre, Descripcion
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ModificarConfiguracionZetaAutomatico");
			sql.ParametersNumber = 5;
            sql.AddParameter("@FechaCreacion", SqlDbType.DateTime, this._fechaCreacion);
            sql.AddParameter("@FechaActualizacion", SqlDbType.DateTime, this._fechaActualizacion);
            sql.AddParameter("@Usuario", SqlDbType.VarChar, this._usuario);
            sql.AddParameter("@HoraInicio", SqlDbType.DateTime, this._horaInicio);
            sql.AddParameter("@HoraFinal", SqlDbType.DateTime, this._horaFinal);
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
    }
}
