using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    /// <summary>
    /// Concepto Otro Ingreso
    /// </summary>
    public class ConceptoOtroIngreso
    {
        #region Sección de Declaraciones
		private int _idConceptoOtroIngreso;
		private string _nombreOtroIngreso;		
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public ConceptoOtroIngreso()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Compania
		/// </summary>
        public int IdConceptoOtroIngreso
		{
			get { return this._idConceptoOtroIngreso; }
			set { this._idConceptoOtroIngreso = value; }
		}

		/// <summary>
		/// Nombre descriptivo
		/// </summary>
        public string NombreOtroIngreso
		{
			get { return this._nombreOtroIngreso; }
			set { this._nombreOtroIngreso = value; }
		}		

		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: Nombre
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarConceptoOtroIngreso");
			sql.ParametersNumber = 2;
            sql.AddParameter("@IdConceptoOtroIngreso", SqlDbType.SmallInt, this._idConceptoOtroIngreso);
            sql.AddParameter("@NombreOtroIngreso", SqlDbType.VarChar, this._nombreOtroIngreso);			
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
