using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion {
	/// <summary>
	/// Impresora.
	/// </summary>
	public class Impresora {
		
		#region Declarations
		private string _imp_Nom, _tipo; 
		private short _num_Pos, _num_Cop_Comb, _num_Cop_Canast, _num_Cop_TDebAho, _num_Cop_TCre, _num_Cop_Cheq, _num_Cop_CreDir, _num_Cop_TDebCor; 
		private bool  _imp_Abrir_Turno, _imp_Tiquetes, _imp_Comb, _imp_Canas, _imp_Equix, _imp_VentasX ;
		private bool _imp_Ven_TanquesX, _imp_Car_AtendidosX, _imp_F_PagX, _imp_ChequesX, _imp_CanastX, _imp_Bol_TurX;
		private bool _imp_Cierre, _imp_VentasC, _imp_Vent_TanquesC, _imp_Car_AtendidosC, _imp_F_PagC, _imp_ChequesC;
		private bool _imp_CanastC, _imp_Bol_TurC;
		private bool _imp_Ventas_CredC, _imp_Ventas_CredX, _imp_Lec_Mec, _imp_Lec_MecX;
		private bool _imp_Tiquete_Fidelizado;
		private bool _imprimirVentaEnCero;
		private bool _imprimirCupoDisponible; 
		private bool _imprimirTiqueteCopia = true;
		private string _puerto;
        private bool _imprimirCedulaBonoPremio;
        private bool _ImprimirTiqueteValidacionSuic;

        //Fecha:        17-03-2011
        //Autor:        Miguel Cantor L.
        //Descripción:  Se añade la variable _mensajes para crear integridad con tabla IMPRESOR en la base de datos
        //Presentes:    N/A
        private char _mensajes;
		#endregion

		#region Constructor/Destructor
		/// <summary>
		/// Impresora Class Constructor
		/// </summary>
		public Impresora(){}
		#endregion

		#region Public_Properties
		/// <summary>
		/// Imp_Nom. Representa el Nombre de la Impresora.
		/// </summary>
		public string Imp_Nom{
			get{ return this._imp_Nom;  }
			set{ this._imp_Nom = value; }
		}
		/// <summary>
		/// Tipo. Representa el tipo de impresora. Matriz de Punto, Termica, etc...
		/// </summary>
		public string Tipo{
			get{ return this._tipo;  }
			set{ this._tipo = value; }
		}
		/// <summary>
		/// NumeroDePos. Representa el Pos al cual esta asociada la impresora.
		/// </summary>
		public short NumeroDePos{
			get{ return this._num_Pos;  }
			set{ this._num_Pos = value; }
		}
		/// <summary>
		/// Imp_Abrir_Turno. 1.Imprime Apertura de Turno.  0.No Imprime Apertura de Turno.
		/// </summary>
		public bool Imp_Abrir_Turno{
			get{ return this._imp_Abrir_Turno;  }
			set{ this._imp_Abrir_Turno = value; }
		}

		/// <summary>
		/// ImprimirTiquetes. 1.Imprime Tiquetes Venta a Venta.  0.No 
		/// </summary>
		public bool ImprimirTiquetes{
			get{ return this._imp_Tiquetes;  }
			set{ this._imp_Tiquetes = value; }
		}

		/// <summary>
		/// Imp_Comb. 1.Imprime Tiquetes Efectivo.  0.No; Fue reemplazada por Num_Cop_Comb
		/// </summary>
		public bool Imp_Comb{
			get{ return this._imp_Comb;  }
			set{ this._imp_Comb = value; }
		}

		/// <summary>
		/// Imp_Canas. 1.Imprime Tiquetes Canastilla.  0.No; Fue reemplazada por Num_Cop_Canast
		/// </summary>
		public bool Imp_Canas{
			get{ return this._imp_Canas;  }
			set{ this._imp_Canas = value; }
		}

		/// <summary>
		/// ImprimeEquix. 1.Imprime Rpt X.  0.No
		/// </summary>
		public bool ImprimeEquix{
			get{ return this._imp_Equix;  }
			set{ this._imp_Equix = value; }
		}

		/// <summary>
		/// ImprimeVentasRptX. 1.Imprime Detalle ventas en Rpt X.  0.No
		/// </summary>
		public bool ImprimeVentasRptX{
			get{ return this._imp_VentasX;  }
			set{ this._imp_VentasX = value; }
		}

		/// <summary>
		/// ImprimeVentasNoImpresasEnCierre. 1.Imprime Ventas no Impresas en Cierre (Bolivia).  0.No
		/// </summary>
		public bool ImprimeVentasNoImpresasEnCierre{
			get{ return this._imp_Ven_TanquesX;  }
			set{ this._imp_Ven_TanquesX = value; }
		}
		
		/// <summary>
		/// ImprimeVehiculosAtendidosRptX. 1.Imprime cantidad de vehiculos atendidos en Rpt X  0.No
		/// </summary>
		public bool ImprimeVehiculosAtendidosRptX{
			get{ return this._imp_Car_AtendidosX;  }
			set{ this._imp_Car_AtendidosX = value; }
		}
		
		/// <summary>
		/// ImprimirFormasDePagoRptX. 1.Imprime formas de pago en Rpt X  0.No
		/// </summary>
		public bool ImprimirFormasDePagoRptX{
			get{ return this._imp_F_PagX;  }
			set{ this._imp_F_PagX = value; }
		}
		
		/// <summary>
		/// ImprimirChequesRptX. 1.Imprime Cheques en Rpt X.  0.No
		/// </summary>
		public bool ImprimirChequesRptX{
			get{ return this._imp_ChequesX;  }
			set{ this._imp_ChequesX = value; }
		}
		
		/// <summary>
		/// ImprimirCanastillaRptX. 1.Imprime Canastilla en Rpt X.  0.No
		/// </summary>
		public bool ImprimirCanastillaRptX{
			get{ return this._imp_CanastX;  }
			set{ this._imp_CanastX = value; }
		}
		
		/// <summary>
		/// ImprimirBolsasTurnoRptX. 1.Imprime Bolsas de turno en Rpt X.  0.No
		/// </summary>
		public bool ImprimirBolsasTurnoRptX{
			get{ return this._imp_Bol_TurX;  }
			set{ this._imp_Bol_TurX = value; }
		}
		/// <summary>
		/// ImprimirCierreDeTurno. 1.Imprime Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimirCierreDeTurno{
			get{ return this._imp_Cierre;  }
			set{ this._imp_Cierre = value; }
		}

		/// <summary>
		/// ImprimeDetalleVentasRptC: 1.Imprime Detalle de Ventas en Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimeDetalleVentasRptC{
			get{ return this._imp_VentasC;  }
			set{ this._imp_VentasC = value; }
		}
		/// <summary>
		/// ImprimeDetalleTanquesRptC: 1.Imprime Detalle de tanques en Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimeDetalleTanquesRptC{
			get{ return this._imp_Vent_TanquesC;  }
			set{ this._imp_Vent_TanquesC = value; }
		}

		/// <summary>
		/// ImprimeDetalleTanquesRptC: 1.Imprime cantidad vehiculos antendidos en Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimeVehiculosAtendidosRptC{
			get{ return this._imp_Car_AtendidosC;  }
			set{ this._imp_Car_AtendidosC = value; }
		}

		/// <summary>
		/// ImprimeFormasDePagRptC: 1.Imprime formas de pago en Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimeFormasDePagRptC{
			get{ return this._imp_F_PagC;  }
			set{ this._imp_F_PagC = value; }
		}
		/// <summary>
		/// ImprimeChequesRptC: 1.Imprime Cheques en Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimeChequesRptC{
			get{ return this._imp_ChequesC;  }
			set{ this._imp_ChequesC = value; }
		}

		/// <summary>
		/// ImprimeCanastillaRptC: 1.Imprime Canastilla en Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimeCanastillaRptC{
			get{ return this._imp_CanastC;  }
			set{ this._imp_CanastC = value; }
		}

		/// <summary>
		/// ImprimeBolsasDeTurnoRptC: 1.Imprime Bolsas de Turno en Rpt Cierre de Turno.  0.No
		/// </summary>
		public bool ImprimeBolsasDeTurnoRptC{
			get{ return this._imp_Bol_TurC;  }
			set{ this._imp_Bol_TurC = value; }
		}

		/// <summary>
		/// ImprimeCantidadCopiasEfectivo: Permite especificar la cantidad de copias de ventas en efectivo.
		/// </summary>
		public short ImprimeCantidadCopiasEfectivo{
			get{ return this._num_Cop_Comb;  }
			set{ this._num_Cop_Comb = value; }
		}
		/// <summary>
		/// ImprimeCantidadCopiasCanastilla: Permite especificar la cantidad de copias de canastilla.
		/// </summary>
		public short ImprimeCantidadCopiasCanastilla{
			get{ return this._num_Cop_Canast;  }
			set{ this._num_Cop_Canast = value; }
		}

		/// <summary>
		/// ImprimeCantidadCopiasTarDebitoAhorro: Permite especificar la cantidad de copias de Tarjeta Debito Ahorros.
		/// </summary>
		public short ImprimeCantidadCopiasTarDebitoAhorro{
			get{ return this._num_Cop_TDebAho;  }
			set{ this._num_Cop_TDebAho = value; }
		}

		/// <summary>
		/// ImprimeCantidadCopiasTarDebitoCorriente: Permite especificar la cantidad de copias de Tarjeta Debito Corriente.
		/// </summary>
		public short ImprimeCantidadCopiasTarDebitoCorriente{
			get{ return this._num_Cop_TDebCor;  }
			set{ this._num_Cop_TDebCor = value; }
		}

		/// <summary>
		/// ImprimeCantidadCopiasTarCredito: Permite especificar la cantidad de copias de Tarjeta de Credito.
		/// </summary>
		public short ImprimeCantidadCopiasTarCredito{
			get{ return this._num_Cop_TCre;  }
			set{ this._num_Cop_TCre = value; }
		}

		/// <summary>
		/// ImprimeCantidadCopiasCheques: Permite especificar la cantidad de copias de Cheques.
		/// </summary>
		public short ImprimeCantidadCopiasCheques{
			get{ return this._num_Cop_Cheq;  }
			set{ this._num_Cop_Cheq = value; }
		}
		/// <summary>
		/// ImprimeCantidadCopiasCreditoDirecto: Permite especificar la cantidad de copias de Credito Directo.
		/// </summary>
		public short ImprimeCantidadCopiasCreditoDirecto{
			get{ return this._num_Cop_CreDir;  }
			set{ this._num_Cop_CreDir = value; }
		}
		/// <summary>
		/// ImprimeVentasCreDirectoRptC: 1.Imprime Detalle ventas Credito Directo en Rpt Cierre de Turno  0.No
		/// </summary>
		public bool ImprimeVentasCreDirectoRptC{
			get{ return this._imp_Ventas_CredC;  }
			set{ this._imp_Ventas_CredC = value; }
		}
		/// <summary>
		/// ImprimeVentasCreDirectoRptX: 1.Imprime Detalle ventas Credito Directo en Rpt X  0.No
		/// </summary>
		public bool ImprimeVentasCreDirectoRptX{
			get{ return this._imp_Ventas_CredX;  }
			set{ this._imp_Ventas_CredX = value; }
		}

		/// <summary>
		/// ImprimeLectsMecanicasRptC: 1.Imprime LEcturas Mecanicas en Rpt Cierre  0.No
		/// </summary>
		public bool ImprimeLectsMecanicasRptC{
			get{ return this._imp_Lec_Mec;  }
			set{ this._imp_Lec_Mec = value; }
		}
		/// <summary>
		/// ImprimeLectsMecanicasRptX: 1.Imprime LEcturas Mecanicas en Rpt X  0.No
		/// </summary>
		public bool ImprimeLectsMecanicasRptX{
			get{ return this._imp_Lec_MecX;  }
			set{ this._imp_Lec_MecX = value; }
		}

		/// <summary>
		/// Configura si imprime o no tiquetes de fidelizado
		/// </summary>
		public bool ImprimeTiqueteFidelizado
		{
			get{ return this._imp_Tiquete_Fidelizado;  }
			set{ this._imp_Tiquete_Fidelizado = value; }
		}

		/// <summary>
		/// Configura si imprime o no ventas en cero
		/// </summary>
		public bool ImprimirVentaEnCero
		{
			get{ return this._imprimirVentaEnCero;  }
			set{ this._imprimirVentaEnCero = value; }
		}

		/// <summary>
		/// Define si imprime el cupo disponible de un cliente con cupo
		/// </summary>
		public bool ImprimirCupoDisponible 
		{
			get{ return this._imprimirCupoDisponible ;  }
			set{ this._imprimirCupoDisponible  = value; }
		}

		/// <summary>
		/// Define si imprime tiquetes como copia
		/// </summary>
		public bool ImprimirTiqueteCopia 
		{
			get { return this._imprimirTiqueteCopia;}
			set { this._imprimirTiqueteCopia = value;}
		}		
		
		/// <summary>
		/// Define el puerto de impresion
		/// </summary>
		public string Puerto
		{
			get { return this._puerto;}
			set { this._puerto = value;}
		}

        /// <summary>
        /// Define si se imprime la cedula el el tiquete de bono premio
        /// </summary>
        public bool ImprimirCedulaBonoPremio
        {
            get { return this._imprimirCedulaBonoPremio; }
            set { this._imprimirCedulaBonoPremio = value; }

        }

        //Fecha:        17-03-2011
        //Autor:        Miguel Cantor L.
        //Descripción:  Se crea la propiedad Mensajes para establecer o traer el valor de _mensajes
        //Presentes:    N/A
        /// <summary>
        /// SOLO APLICA PARA DATAFONO: Define o trae el tipo de presentacion para los mensajes
        /// </summary>
        public char Mensajes
        {
            get { return this._mensajes; }
            set { this._mensajes = value; }

        }
		#endregion

        /// <summary>
        /// Imprimir Tiquete de validacion Suic
        /// Fecha:26-11-2011
        /// Rodrigo Figueroa        
        /// </summary>
       
        public bool ImprimirTiqueteValidacionSuic
        {
            get { return this._ImprimirTiqueteValidacionSuic; }
            set { this._ImprimirTiqueteValidacionSuic = value; }

        }

		#region Modify
		/// <summary>
		/// Actualizar propiedades de la Impresora
		/// </summary>
		public void Modificar()
		{
		
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PrinterModification");
			sql.ParametersNumber = 43;
			sql.AddParameter("@IMP_NOM", SqlDbType.VarChar, this._imp_Nom);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, this._tipo);
			sql.AddParameter("@Num_Pos", SqlDbType.Int, this._num_Pos);
			sql.AddParameter("@IMP_ABRIR_TURNO", SqlDbType.Int, this._imp_Abrir_Turno);
			sql.AddParameter("@IMP_TIQUETES", SqlDbType.Int, this._imp_Tiquetes);
			sql.AddParameter("@IMP_COMB", SqlDbType.Int, this._imp_Comb);
			sql.AddParameter("@IMP_CANAS", SqlDbType.Int, this._imp_Canas);
			sql.AddParameter("@IMP_EQUIX", SqlDbType.Int, this._imp_Equix);
			sql.AddParameter("@IMP_VENTASX", SqlDbType.Int, this._imp_VentasX);
			sql.AddParameter("@IMP_VEN_TANQUESX", SqlDbType.Int, this._imp_Ven_TanquesX);
			sql.AddParameter("@IMP_CAR_ATENDIDOSX", SqlDbType.Int, this._imp_Car_AtendidosX);
			sql.AddParameter("@IMP_F_PAGX", SqlDbType.Int, this._imp_F_PagX);
			sql.AddParameter("@IMP_CHEQUESX", SqlDbType.Int, this._imp_ChequesX);
			sql.AddParameter("@IMP_CANASTX", SqlDbType.Int, this._imp_CanastX);
			sql.AddParameter("@IMP_BOL_TURX", SqlDbType.Int, this._imp_Bol_TurX);
			sql.AddParameter("@IMP_CIERRE", SqlDbType.Int, this._imp_Cierre);
			sql.AddParameter("@IMP_VENTASC", SqlDbType.Int, this._imp_VentasC);
			sql.AddParameter("@IMP_VEN_TANQUESC", SqlDbType.Int, this._imp_Vent_TanquesC);
			sql.AddParameter("@IMP_CAR_ATENDIDOSC", SqlDbType.Int, this._imp_Car_AtendidosC);
			sql.AddParameter("@IMP_F_PAGC", SqlDbType.Int, this._imp_F_PagC);
			sql.AddParameter("@IMP_CHEQUESC", SqlDbType.Int, this._imp_ChequesC);
			sql.AddParameter("@IMP_CANASTC", SqlDbType.Int, this._imp_CanastC);
			sql.AddParameter("@IMP_BOL_TURC", SqlDbType.Int, this._imp_Bol_TurC);
			sql.AddParameter("@NUM_COP_COMB", SqlDbType.Int, this._num_Cop_Comb);
			sql.AddParameter("@NUM_COP_CANAST", SqlDbType.Int, this._num_Cop_Canast);
			sql.AddParameter("@NUM_COP_TDEBAHO", SqlDbType.Int, this._num_Cop_TDebAho);
			sql.AddParameter("@NUM_COP_TDEBCOR", SqlDbType.Int, this._num_Cop_TDebCor);
			sql.AddParameter("@NUM_COP_TCRE", SqlDbType.Int, this._num_Cop_TCre);
			sql.AddParameter("@NUM_COP_CHEQ", SqlDbType.Int, this._num_Cop_Cheq);
			sql.AddParameter("@NUM_COP_CREDIR", SqlDbType.Int, this._num_Cop_CreDir);
			sql.AddParameter("@IMP_VENTAS_CREDC", SqlDbType.Int, this._imp_Ventas_CredC);
			sql.AddParameter("@IMP_VENTAS_CREDX", SqlDbType.Int, this._imp_Ventas_CredX);
			sql.AddParameter("@IMP_LEC_MEC", SqlDbType.Int, this._imp_Lec_Mec);
			sql.AddParameter("@IMP_LEC_MECX", SqlDbType.Int, this._imp_Lec_MecX);
			sql.AddParameter("@Imp_Tiquete_Fidelizado", SqlDbType.Int, this._imp_Tiquete_Fidelizado);
			sql.AddParameter("@imprimirVentaEnCero", SqlDbType.Int, this._imprimirVentaEnCero);
			sql.AddParameter("@ImprimirCupoDisponible", SqlDbType.TinyInt, this._imprimirCupoDisponible);
			sql.AddParameter("@ImprimirTiqueteCopia", SqlDbType.Bit, this._imprimirTiqueteCopia);
			sql.AddParameter("@Puerto", SqlDbType.VarChar, this._puerto);
            sql.AddParameter("@ImprimirCedulaBonoPremio", SqlDbType.TinyInt, this._imprimirCedulaBonoPremio);
            //Fecha:        17-03-2011
            //Autor:        Miguel Cantor L.
            //Descripción:  Se crea el parametro @Mensajes con el valor de _mensajes para registrar el dato en la base de datos.
            //              Se valida que el campo tenga valor.
            //Presentes:    N/A
            if(_mensajes.ToString()!="")
                sql.AddParameter("@Mensajes", SqlDbType.Char, this._mensajes);

            sql.AddParameter("@ImprimirTiqueteValidacionSuic", SqlDbType.TinyInt, this._ImprimirTiqueteValidacionSuic);

			#endregion

			#region Execute Sql Command
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}catch(SqlException exx){
				throw new Exception(exx.Message + " !ERROR BD! ");
			}finally{
				sql = null;
			}
			#endregion

		}
		#endregion
	}
}
