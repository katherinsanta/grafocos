using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// POS
	/// </summary>
	public class POS {

		#region Sección de Declaraciones
		private short _idPos;
		private short _idIsla;
		private short _idCapturador;
        private bool _manejaPolyDisplay;
        private string _protocoloPolyDisplay;
        private string _puertoPolyDisplay;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public POS()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Pos. Representa la Llave Primaria de la tabla POS
		/// </summary>
		public short IdPos
		{
			get { return this._idPos; }
			set { this._idPos = value; }
		}

		/// <summary>
		/// Id Isla. Representa la Isla a la cual esta asociado el Pos
		/// </summary>
		public short IdIsla
		{
			get { return this._idIsla; }
			set { this._idIsla = value; }
		}

		/// <summary>
		/// Id Capturador. Representa el Capturador asociado al Pos
		/// </summary>
		public short IdCapturador
		{
			get { return this._idCapturador; }
			set { this._idCapturador = value; }
        }

        /// <summary>
        /// Id Capturador. Representa el Capturador asociado al Pos
        /// </summary>
        public bool ManejaPolyDisplay
        {
            get { return this._manejaPolyDisplay; }
            set { this._manejaPolyDisplay = value; }
        }

         /// <summary>
        /// Id Capturador. Representa el Capturador asociado al Pos
        /// </summary>
        public string ProtocoloPolyDisplay
        {
            get { return this._protocoloPolyDisplay; }
            set { this._protocoloPolyDisplay = value; }
        }

        /// <summary>
        /// Puerto PolyDisplay. Representa el puerto polydisplay asociado al Pos
        /// </summary>
        public string PuertoPolyDisplay
        {
            get { return this._puertoPolyDisplay; }
            set { this._puertoPolyDisplay = value; }
        }              

        #endregion

        #region Modificar
        /// <summary>
		/// Actualización de las propiedades: IdPos
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarPos");
			sql.ParametersNumber = 6;
			sql.AddParameter("@Num_Pos", SqlDbType.Int, this._idPos);
			sql.AddParameter("@Cod_Isl", SqlDbType.Int, this._idIsla);
			sql.AddParameter("@Num_Cap", SqlDbType.Int, this._idCapturador);
            sql.AddParameter("@ManejaPolyDisplay", SqlDbType.TinyInt, this._manejaPolyDisplay);
            sql.AddParameter("@ProtocoloPolyDisplay", SqlDbType.VarChar, this._protocoloPolyDisplay);
            sql.AddParameter("@PuertoPolyDisplay", SqlDbType.VarChar, this._puertoPolyDisplay);
			
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