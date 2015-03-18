using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    public class Conductor
    {
          #region Sección de Declaraciones
	    int _idConductor;
	    string _codigo  ;
        string _nombre;
        string _identificacion;
        string _autorizacion;

		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public Conductor()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Grupo
		/// </summary>
		public int IdConductor
		{
			get { return this._idConductor; }
            set { this._idConductor = value; }
		}

		/// <summary>
		/// Nombre descriptivo
		/// </summary>
		public string Codigo
		{
			get { return this._codigo; }
			set { this._codigo = value; }
		}

		/// <summary>
		/// Descripción
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

        /// <summary>
        /// Descripción
        /// </summary>
        public string Identificacion
        {
            get { return this._identificacion; }
            set { this._identificacion = value; }   
        }

        /// <summary>
        /// Estado
        /// </summary>
        public string Autorizacion
        {
            get { return this._autorizacion; }
            set { this._autorizacion = value; }
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

            sql.Append("ModificarConductor");
			sql.ParametersNumber = 5;
            sql.AddParameter("@IdConductor", SqlDbType.Int, this._idConductor);          
            sql.AddParameter("@Nombre", SqlDbType.VarChar, this._nombre);
            sql.AddParameter("@Identificacion", SqlDbType.VarChar, this._identificacion);
            sql.AddParameter("@Autorizacion", SqlDbType.VarChar, this._autorizacion);
            sql.AddParameter("@Codigo", SqlDbType.VarChar, this._codigo);
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
