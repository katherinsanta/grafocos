using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.CargarPlanosGNV
{
	/// <summary>
	/// Planos a cargar en la DB de la estacion. C.C. de Gas Natural.
	/// </summary>
	public class PlanosGNV
	{
		#region Sección de Declaraciones
		private string _rutaArchivos = null;
		private string _terminadorCampo = null;
		//private int _numArchivo = 0;
		#endregion

		#region Constructor
		/// <summary>
		/// Permite la Carga de 4 planos solicitados por Gas Natural.
		/// </summary>
		/// <param name="rutaArchivos">Especifica la ruta del archivo a cargar.</param>
		/// <param name="terminadorCampo">Especifica caracter separador de campo.</param>
		public PlanosGNV(string rutaArchivos, string terminadorCampo){
			this._rutaArchivos = rutaArchivos;
			this._terminadorCampo = terminadorCampo;
			//web InterFace (JLarrarte) ensures user uploaded 4 TXT files.
			for (int i = 1; i <= 4; i++){
				this.CargarArchivo(i);
			}
		}
		#endregion

		#region CargarArchivo
		/// <summary>
		/// Carga un Archivo Plano especifico a la DB de la Estacion.
		/// </summary>
		/// <param name="NumArchivo">Numero de Archivo a Cargar, 1.Causales, 2.Creditos_GNV, 3.NormaSuic_GNV, 4.Clientes</param>
		private void CargarArchivo(int NumArchivo) {
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("UploadPlainsGNV");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Route", SqlDbType.VarChar, this._rutaArchivos);
			sql.AddParameter("@FieldTerminator", SqlDbType.VarChar, this._terminadorCampo);
			sql.AddParameter("@File", SqlDbType.Int, NumArchivo);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion
		
	}
}
