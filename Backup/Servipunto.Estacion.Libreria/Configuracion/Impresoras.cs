using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion{
	/// <summary>
	/// Impresoras.
	/// </summary>
	public class Impresoras : Servipunto.Libreria.Collection{
		
		#region Declarations
		private object _key = null;
		private object _imp_Nom = null;
		private object _num_Pos = null;
		#endregion

		#region Constructor/Destructor
		/// <summary>
		/// Lista de todos las Impresoras configuradas.
		/// </summary>
		public Impresoras(){
			this._key = 0;
			this._imp_Nom = "";
			this._num_Pos = 0;
		}
		/// <summary>
		///  Consulta una impresora en Particular.
		/// </summary>
		/// <param name="imp_Nom">Nombre de la Impresora.</param>
		public Impresoras(string imp_Nom){
			this._key = 1;
			this._imp_Nom = imp_Nom;
			this._num_Pos = 0;
		}
		/// <summary>
		/// Consultar una Impresora en Particular.
		/// </summary>
		/// <param name="num_Pos">Numero del Pos al cual esta asociada la impresora.</param>
		public Impresoras (int num_Pos){
			this._key = 2;
			this._imp_Nom = "";
			this._num_Pos = num_Pos;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador Por Llave
		/// </summary>
		new public Impresora this[string key]{
			get {return (Impresora) base[key];}
		}
		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Impresora this[int index]{
			get {return (Impresora) base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>
		protected override void Load(object sender, EventArgs e) {

			#region Prepare Sql
			
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			
			sql.Append("PrinterQuery");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Key", SqlDbType.Int, this._key);
			sql.AddParameter("@IMP_NOM", SqlDbType.VarChar, this._imp_Nom);
			sql.AddParameter("@Num_Pos", SqlDbType.Int, this._num_Pos);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read()){
				Impresora objImpresora = new Impresora();
				objImpresora.Imp_Nom = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();
				objImpresora.Tipo = dr.IsDBNull(1)?"-":dr.GetString(1).Trim();
				objImpresora.NumeroDePos = dr.IsDBNull(2)?(short)0:dr.GetInt16(2);
				objImpresora.Imp_Abrir_Turno = dr.IsDBNull(3)?false:Convert.ToBoolean(dr.GetByte(3));
				objImpresora.ImprimirTiquetes = dr.IsDBNull(4)?false:Convert.ToBoolean(dr.GetByte(4));
				objImpresora.Imp_Comb = dr.IsDBNull(5)?false:Convert.ToBoolean(dr.GetByte(5));
				objImpresora.Imp_Canas = dr.IsDBNull(6)?false:Convert.ToBoolean(dr.GetByte(6));
				objImpresora.ImprimeEquix = dr.IsDBNull(7)?false:Convert.ToBoolean(dr.GetByte(7));
				objImpresora.ImprimeVentasRptX = dr.IsDBNull(8)?false:Convert.ToBoolean(dr.GetByte(8));
				objImpresora.ImprimeVentasNoImpresasEnCierre = dr.IsDBNull(9)?false:Convert.ToBoolean(dr.GetByte(9));
				objImpresora.ImprimeVehiculosAtendidosRptX = dr.IsDBNull(10)?false:Convert.ToBoolean(dr.GetByte(10));
				objImpresora.ImprimirFormasDePagoRptX = dr.IsDBNull(11)?false:Convert.ToBoolean(dr.GetByte(11));
				objImpresora.ImprimirChequesRptX = dr.IsDBNull(12)?false:Convert.ToBoolean(dr.GetByte(12));
				objImpresora.ImprimirCanastillaRptX = dr.IsDBNull(13)?false:Convert.ToBoolean(dr.GetByte(13));
				objImpresora.ImprimirBolsasTurnoRptX = dr.IsDBNull(14)?false:Convert.ToBoolean(dr.GetByte(14));
				objImpresora.ImprimirCierreDeTurno = dr.IsDBNull(15)?false:Convert.ToBoolean(dr.GetByte(15));
				objImpresora.ImprimeDetalleVentasRptC = dr.IsDBNull(16)?false:Convert.ToBoolean(dr.GetByte(16));
				objImpresora.ImprimeDetalleTanquesRptC = dr.IsDBNull(17)?false:Convert.ToBoolean(dr.GetByte(17));
				objImpresora.ImprimeVehiculosAtendidosRptC = dr.IsDBNull(18)?false:Convert.ToBoolean(dr.GetByte(18));
				objImpresora.ImprimeFormasDePagRptC = dr.IsDBNull(19)?false:Convert.ToBoolean(dr.GetByte(19));
				objImpresora.ImprimeChequesRptC = dr.IsDBNull(20)?false:Convert.ToBoolean(dr.GetByte(20));
				objImpresora.ImprimeCanastillaRptC = dr.IsDBNull(21)?false:Convert.ToBoolean(dr.GetByte(21));
				objImpresora.ImprimeBolsasDeTurnoRptC = dr.IsDBNull(22)?false:Convert.ToBoolean(dr.GetByte(22));
				objImpresora.ImprimeCantidadCopiasEfectivo = dr.IsDBNull(23)?(short)0:dr.GetInt16(23);
				objImpresora.ImprimeCantidadCopiasCanastilla = dr.IsDBNull(24)?(short)0:dr.GetInt16(24);
				objImpresora.ImprimeCantidadCopiasTarDebitoAhorro = dr.IsDBNull(25)?(short)0:dr.GetInt16(25);
				objImpresora.ImprimeCantidadCopiasTarDebitoCorriente = dr.IsDBNull(26)?(short)0:dr.GetInt16(26);
				objImpresora.ImprimeCantidadCopiasTarCredito = dr.IsDBNull(27)?(short)0:dr.GetInt16(27);
				objImpresora.ImprimeCantidadCopiasCheques = dr.IsDBNull(28)?(short)0:dr.GetInt16(28);
				objImpresora.ImprimeCantidadCopiasCreditoDirecto = dr.IsDBNull(29)?(short)0:dr.GetInt16(29);
				objImpresora.ImprimeVentasCreDirectoRptC = dr.IsDBNull(30)?false:Convert.ToBoolean(dr.GetByte(30));
				objImpresora.ImprimeVentasCreDirectoRptX = dr.IsDBNull(31)?false:Convert.ToBoolean(dr.GetByte(31));
				objImpresora.ImprimeLectsMecanicasRptC = dr.IsDBNull(32)?false:Convert.ToBoolean(dr.GetByte(32));
				objImpresora.ImprimeLectsMecanicasRptX = dr.IsDBNull(33)?false:Convert.ToBoolean(dr.GetByte(33));
				objImpresora.ImprimeTiqueteFidelizado = dr.IsDBNull(34)?false:Convert.ToBoolean(dr.GetByte(34));
				objImpresora.ImprimirVentaEnCero = dr.IsDBNull(35)?false:Convert.ToBoolean(dr.GetByte(35));
				objImpresora.ImprimirCupoDisponible = dr.IsDBNull(36)?false:Convert.ToBoolean(dr.GetByte(36));
				objImpresora.ImprimirTiqueteCopia =  dr.IsDBNull(37)?false:dr.GetBoolean(37);				
				objImpresora.Puerto = dr.IsDBNull(38)?"":dr.GetString(38).Trim();
                objImpresora.ImprimirCedulaBonoPremio = dr.IsDBNull(39) ? false : Convert.ToBoolean(dr.GetByte(39));
                objImpresora.Mensajes = dr.IsDBNull(40) ? char.Parse(string.Empty)    : char.Parse(dr.GetString(40));
                objImpresora.ImprimirTiqueteValidacionSuic = dr.IsDBNull(41) ? false : dr.GetBoolean (41) ;
				base.AddItem(objImpresora.NumeroDePos.ToString(), objImpresora);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion

		}
		#endregion

		#region Add
		/// <summary>
		/// Inserta una Impresora en la DB.
		/// </summary>
		/// <param name="objImpresora">Datos de la Impresora</param>
		public static void Adicionar(Impresora objImpresora){
			#region Prepare Sql
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PrinterInsertion");
			sql.ParametersNumber = 43;
			sql.AddParameter("@IMP_NOM", SqlDbType.VarChar, objImpresora.Imp_Nom);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, objImpresora.Tipo);
			sql.AddParameter("@Num_Pos", SqlDbType.Int, objImpresora.NumeroDePos);
			sql.AddParameter("@IMP_ABRIR_TURNO", SqlDbType.Int, objImpresora.Imp_Abrir_Turno);
			sql.AddParameter("@IMP_TIQUETES", SqlDbType.Int, objImpresora.ImprimirTiquetes);
			sql.AddParameter("@IMP_COMB", SqlDbType.Int, objImpresora.Imp_Comb);
			sql.AddParameter("@IMP_CANAS", SqlDbType.Int, objImpresora.Imp_Canas);
			sql.AddParameter("@IMP_EQUIX", SqlDbType.Int, objImpresora.ImprimeEquix);
			sql.AddParameter("@IMP_VENTASX", SqlDbType.Int, objImpresora.ImprimeVentasRptX);
			sql.AddParameter("@IMP_VEN_TANQUESX", SqlDbType.Int, objImpresora.ImprimeVentasNoImpresasEnCierre);
			sql.AddParameter("@IMP_CAR_ATENDIDOSX", SqlDbType.Int, objImpresora.ImprimeVehiculosAtendidosRptX);
			sql.AddParameter("@IMP_F_PAGX", SqlDbType.Int, objImpresora.ImprimirFormasDePagoRptX);
			sql.AddParameter("@IMP_CHEQUESX", SqlDbType.Int, objImpresora.ImprimirChequesRptX);
			sql.AddParameter("@IMP_CANASTX", SqlDbType.Int, objImpresora.ImprimirCanastillaRptX);
			sql.AddParameter("@IMP_BOL_TURX", SqlDbType.Int, objImpresora.ImprimirBolsasTurnoRptX);
			sql.AddParameter("@IMP_CIERRE", SqlDbType.Int, objImpresora.ImprimirCierreDeTurno);
			sql.AddParameter("@IMP_VENTASC", SqlDbType.Int, objImpresora.ImprimeDetalleVentasRptC);
			sql.AddParameter("@IMP_VEN_TANQUESC", SqlDbType.Int, objImpresora.ImprimeDetalleTanquesRptC);
			sql.AddParameter("@IMP_CAR_ATENDIDOSC", SqlDbType.Int, objImpresora.ImprimeVehiculosAtendidosRptC);
			sql.AddParameter("@IMP_F_PAGC", SqlDbType.Int, objImpresora.ImprimeFormasDePagRptC);
			sql.AddParameter("@IMP_CHEQUESC", SqlDbType.Int, objImpresora.ImprimeChequesRptC);
			sql.AddParameter("@IMP_CANASTC", SqlDbType.Int, objImpresora.ImprimeCanastillaRptC);
			sql.AddParameter("@IMP_BOL_TURC", SqlDbType.Int, objImpresora.ImprimeBolsasDeTurnoRptC);
			sql.AddParameter("@NUM_COP_COMB", SqlDbType.Int, objImpresora.ImprimeCantidadCopiasEfectivo);
			sql.AddParameter("@NUM_COP_CANAST", SqlDbType.Int, objImpresora.ImprimeCantidadCopiasCanastilla);
			sql.AddParameter("@NUM_COP_TDEBAHO", SqlDbType.Int, objImpresora.ImprimeCantidadCopiasTarDebitoAhorro);
			sql.AddParameter("@NUM_COP_TDEBCOR", SqlDbType.Int, objImpresora.ImprimeCantidadCopiasTarDebitoCorriente);
			sql.AddParameter("@NUM_COP_TCRE", SqlDbType.Int, objImpresora.ImprimeCantidadCopiasTarCredito);
			sql.AddParameter("@NUM_COP_CHEQ", SqlDbType.Int, objImpresora.ImprimeCantidadCopiasCheques);
			sql.AddParameter("@NUM_COP_CREDIR", SqlDbType.Int, objImpresora.ImprimeCantidadCopiasCreditoDirecto);
			sql.AddParameter("@IMP_VENTAS_CREDC", SqlDbType.Int, objImpresora.ImprimeVentasCreDirectoRptC);
			sql.AddParameter("@IMP_VENTAS_CREDX", SqlDbType.Int, objImpresora.ImprimeVentasCreDirectoRptX);
			sql.AddParameter("@IMP_LEC_MEC", SqlDbType.Int, objImpresora.ImprimeLectsMecanicasRptC);
			sql.AddParameter("@IMP_LEC_MECX", SqlDbType.Int, objImpresora.ImprimeLectsMecanicasRptX);
			sql.AddParameter("@Imp_Tiquete_Fidelizado", SqlDbType.TinyInt, objImpresora.ImprimeTiqueteFidelizado);
			sql.AddParameter("@imprimirVentaEnCero", SqlDbType.TinyInt, objImpresora.ImprimirVentaEnCero);
			sql.AddParameter("@ImprimirCupoDisponible", SqlDbType.TinyInt, objImpresora.ImprimirCupoDisponible);
			sql.AddParameter("@ImprimirTiqueteCopia", SqlDbType.Bit,objImpresora.ImprimirTiqueteCopia);
			sql.AddParameter("@Puerto", SqlDbType.VarChar, objImpresora.Puerto);
            sql.AddParameter("@ImprimirCedulaBonoPremio", SqlDbType.TinyInt, objImpresora.ImprimirCedulaBonoPremio);
            sql.AddParameter("@ImprimirTiqueteValidacionSuic", SqlDbType.Bit, objImpresora.ImprimirTiqueteValidacionSuic);
            //Fecha:        17-03-2011
            //Autor:        Miguel Cantor L.
            //Descripción:  Se crea el parametro @Mensajes con el valor de Mensajes(objImpresora) para registrar el dato en la base de datos.
            //              Se valida que el campo tenga valor.
            //Presentes:    N/A
            if (objImpresora.Mensajes.ToString() != "")
                sql.AddParameter("@Mensajes", SqlDbType.Char, objImpresora.Mensajes);

			#endregion

			#region Execute Sql
			try 
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe la impresora " + objImpresora.Imp_Nom  + " !ERROR BD! ");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}

		#endregion

		#region Delete
		
		/// <summary>
		/// Elimina una impresora especifica de la DB.
		/// </summary>
		/// <param name="imp_Nom">Nombre de la Impresora </param>
		/// <param name="num_Pos">Pos al cula esta asociada la impresora </param>
		public static void Eliminar( int num_Pos) {
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("PrinterDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Num_Pos", SqlDbType.SmallInt, num_Pos);
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

		#region GetItem
		/// <summary>
		/// Metodo para obtener una impresora en particular.
		/// </summary>
		/// <param name="num_Pos">Numero de Pos al que pertenece la impresora a Consultar</param>
		/// <returns>Impresora si existe. Null si no.</returns>
		public static Impresora ObtenerItem(int num_Pos) {
			Impresoras objImpresoras = new Impresoras(num_Pos);
			if (objImpresoras.Count == 1)
				return objImpresoras[0];
			else
				return null;
		}
		#endregion

	}
}