using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// Clase Identificador Conductor
    /// Rodrigo Figueroa Rivera
    /// 08/07/2010
    /// </summary>
    public class IdentificadorConductor
    {
        #region Sección de Declaraciones
	    int _idConductor;
	    string _numero;
        string _estado;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public IdentificadorConductor()
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
		public string Numero
		{
			get { return this._numero; }
			set { this._numero = value; }
		}

		/// <summary>
		/// Descripción
		/// </summary>
		public string Estado
		{
			get { return this._estado; }
			set { this._estado = value; }
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

            sql.Append("ModificarIdentificadorConductor");
			sql.ParametersNumber = 3;
            sql.AddParameter("@IdConductor", SqlDbType.Int, this._idConductor);
            sql.AddParameter("@Numero", SqlDbType.VarChar, this._numero);
            sql.AddParameter("@Estado", SqlDbType.VarChar, this._estado);
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
