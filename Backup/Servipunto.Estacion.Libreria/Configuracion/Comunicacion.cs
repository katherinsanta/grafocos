using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Descripción breve de Comunicacion.
	/// </summary>
	public class Comunicacion
	{

		#region Declarations
		private string _dispositivo, _puerto, _tipo_Trans, _modo_Trans, _path_Arch_Envio, _path_Arch_Proce ;
		private string _path_Cliserv, _path_Generador, _servidor_Ip, _cliente_socket_servidor_Es, _cliente_Path_Arch_Ftp;
		private string _cliente_Usuario_FTP, _cliente_Password_FTP, _cliente_Dir_Virtual_FTP, _cliente_Inicio_ES;
		private string _estado, _cliente_Ip_Servidor_Ftp, _cliente_IP_Servidor_Es;
		private bool _gasonet;
		private int _id, _periodo_Envio, _periodo_Recep, _cliente_TimeOut_ES, _cliente_InActiveTimeOut_ES, _cliente_Port_Ftp;
		private Int16 _intervaloSincronizacion;
		#endregion

		#region Constructor

		/// <summary>
		/// Comunicacion
		/// </summary>
		public Comunicacion() {	}
		#endregion

		#region Public Properties

		/// <summary>
		/// Id Comunicaciones Siempre 1.
		/// </summary>
		public int IdComunicaciones {
			get {return this._id; }
			set {this._id = value;}
		}
		/// <summary>
		/// Dispositivo/Medio de Comunicacion:
		/// Linea Telefonica, Avantel, CDPD, Linea dedicada, Fibra Optica, VSat.
		/// </summary>
		public string Dispositivo {
			get{ return this._dispositivo; }
			set{ this._dispositivo = value;}
		}


		/// <summary>
		/// Puerto al cual esta conectado el dispositivo de comunicacion (Opcional)
		/// </summary>
		public string Puerto {
			get { return this._puerto; }
			set { this._puerto = value;}
		}


		/// <summary>
		/// Tipo de Transmision:
		/// Linea, Lote, Tarjeta, Total.
		/// </summary>
		public string TipoTransmision {
			get { return this._tipo_Trans; }
			set { this._tipo_Trans = value;}
		}


		/// <summary>
		/// Modo Inicio Transmision de Ventas
		/// Manual, Automatico
		/// </summary>
		public string ModoTransmision {
			get { return this._modo_Trans; }
			set { this._modo_Trans = value;}
		}


		/// <summary>
		/// Especifica la ruta de la carpeta Envios
		/// Default:  C:\Servipunto\Administ\Envios
		/// </summary>
		public string RutaEnvios{
			get { return this._path_Arch_Envio; }
			set { this._path_Arch_Envio = value;}
		}


		/// <summary>
		/// Especifica la ruta de la carpeta Procesados
		/// Default:  C:\Servipunto\Administ\Procesados
		/// </summary>
		public string RutaProcesados{
			get { return this._path_Arch_Proce; }
			set { this._path_Arch_Proce = value;}
		}


		/// <summary>
		/// Ruta del Ejecutable de cliser.EXE ó OnLine.EXE
		/// Tipo Lote:  C:\Servipunto\Administ\Sqlcliser32.EXE 
		/// Tipo Linea: C:\Servipunto\Administ\OnLineSql.exe 
		/// </summary>
		public string RutaCliserv_Online {
			get { return this._path_Cliserv; }
			set { this._path_Cliserv = value;}
		}


		/// <summary>
		/// Ruta del Ejecutable de Generador
		/// Tipo Lote: C:\Servipunto\Administ\GenerSql.exe.
		/// </summary>
		public string RutaGenerador {
			get { return this._path_Generador; }
			set { this._path_Generador = value;}
		}


		/// <summary>
		/// Direccion IP del servidor OnLine
		/// </summary>
		public string OnLineServerIP {
			get { return this._servidor_Ip; }
			set { this._servidor_Ip = value;}
		}


		/// <summary>
		/// Socket de escucha del servidor Online
		/// Default: 3000
		/// </summary>
		public string OnLineServerSocket {
			get { return this._cliente_socket_servidor_Es; }
			set { this._cliente_socket_servidor_Es = value;}
		}

		/// <summary>
		/// Ruta del ejecutable de FTP
		/// Default: C:\Servipunto\Administ\SqlFtp.exe
		/// </summary>
		public string RutaFTP {
			get { return this._cliente_Path_Arch_Ftp; }
			set { this._cliente_Path_Arch_Ftp = value;} 
		}

		/// <summary>
		/// Direccion IP servidor Gasonet
		/// Default: 200.31.80.58
		/// </summary>
		public string IpServidorGasonet {
			get { return this._cliente_IP_Servidor_Es;}
			set { this._cliente_IP_Servidor_Es = value;} 
		}


		/// <summary>
		/// Nombre de usuario del FTP
		/// Default: anonymous
		/// </summary>
		public string FtpUserName {
			get { return this._cliente_Usuario_FTP; }
			set { this._cliente_Usuario_FTP = value;}
		}


		/// <summary>
		/// Paswwd usuario FTP
		/// Default: anonymous@mail.com
		/// </summary>
		public string FtpUserPasswd {
			get { return this._cliente_Password_FTP; }
			set { this._cliente_Password_FTP = value;}
		}


		/// <summary>
		/// Directorio virtual del FTP
		/// Default: PUB
		/// </summary>
		public string FtpVirtualDirectory {
			get { return this._cliente_Dir_Virtual_FTP; }
			set { this._cliente_Dir_Virtual_FTP = value;}
		}


		/// <summary>
		/// Modo de inicio programa transmisor de ventas
		/// Ventas ó Manual.
		/// </summary>
		public string ModoInicioTransmisor {
			get { return this._cliente_Inicio_ES; }
			set { this._cliente_Inicio_ES = value;}
		}


		/// <summary>
		/// Estado:
		/// Activo ó Inactivo
		/// </summary>
		public string EstadoComunicaciones {
			get { return this._estado; }
			set { this._estado = value;}
		}


		/// <summary>
		/// Direccion Ip Servidor FTP
		/// </summary>
		public string FtpServerIp {
			get { return this._cliente_Ip_Servidor_Ftp; }
			set { this._cliente_Ip_Servidor_Ftp = value;}
		}


		/// <summary>
		/// Especifica si se realiza transmision tipo Gasonet.
		/// </summary>
		public bool IsGasonet {
			get { return this._gasonet; }
			set { this._gasonet = value;}
		}


		/// <summary>
		/// Especifa cada cuantos minutos se debe autoejcutar el generador
		/// Default: 30
		/// </summary>
		public int PeriodoAutoEnvio {
			get { return this._periodo_Envio; }
			set { this._periodo_Envio = value;}
		}


		/// <summary>
		/// Especifa cada cuantos minutos se recibiran datos.
		/// Default: 45
		/// </summary>
		public int PeriodoAutoReception {
			get { return this._periodo_Recep; }
			set { this._periodo_Recep = value;}
		}


		/// <summary>
		/// TimeOut
		/// Default: 1200
		/// </summary>
		public int OnlineTimeOut {
			get { return this._cliente_TimeOut_ES; }
			set { this._cliente_TimeOut_ES = value;}
		}

		/// <summary>
		/// TimeOut de Inactividad
		/// Default: 9000
		/// </summary>
		public int InActiveTimeOut {
			get { return this._cliente_InActiveTimeOut_ES; }
			set { this._cliente_InActiveTimeOut_ES = value;}
		}


		/// <summary>
		/// Puerto FTP
		/// Default: 21
		/// </summary>
		public int FtpPort {
			get { return this._cliente_Port_Ftp; }
			set { this._cliente_Port_Ftp = value;}
		}

		/// <summary>
		/// Intervalo en que sera sincronizado el sistema con el centro de computo
		/// </summary>
		public Int16 IntervaloSincronizacion 
		{
			get { return this._intervaloSincronizacion; }
			set { this._intervaloSincronizacion = value;}
		}


		
		#endregion

		#region Modify
		/// <summary>
		/// Permite modificar Comunicaciones
		/// </summary>
		public void Modificar (){

			#region Prepare SqlStatement
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ComunicationsInsertion");
			sql.ParametersNumber = 25;
			sql.AddParameter("@Dispositivo", SqlDbType.VarChar, this._dispositivo);
			sql.AddParameter("@Puerto", SqlDbType.VarChar, this._puerto);
			sql.AddParameter("@Tipo_Trans", SqlDbType.VarChar, this._tipo_Trans);
			sql.AddParameter("@Modo_Trans", SqlDbType.VarChar, this._modo_Trans);
			sql.AddParameter("@Periodo_Envio", SqlDbType.Int, this._periodo_Envio * 6000);
			sql.AddParameter("@Periodo_Recep", SqlDbType.Int, this._periodo_Recep * 6000);
			sql.AddParameter("@Path_Arch_Envio", SqlDbType.VarChar, this._path_Arch_Envio);
			sql.AddParameter("@Path_Arch_Proce", SqlDbType.VarChar, this._path_Arch_Proce);
			sql.AddParameter("@Path_Cliserv", SqlDbType.VarChar, this._path_Cliserv);
			sql.AddParameter("@Path_Generador", SqlDbType.VarChar, this._path_Generador);
			sql.AddParameter("@Servidor_Ip", SqlDbType.VarChar, this._servidor_Ip);
			sql.AddParameter("@Cliente_socket_servidor_Es", SqlDbType.VarChar, this._cliente_socket_servidor_Es);
			sql.AddParameter("@Cliente_TimeOut_ES", SqlDbType.Int, this._cliente_TimeOut_ES);
			sql.AddParameter("@Cliente_InActiveTimeOut_ES", SqlDbType.Int, this._cliente_InActiveTimeOut_ES);
			sql.AddParameter("@Cliente_Path_Arch_Ftp", SqlDbType.VarChar, this._cliente_Path_Arch_Ftp);
			sql.AddParameter("@Cliente_Usuario_FTP", SqlDbType.VarChar, this._cliente_Usuario_FTP);
			sql.AddParameter("@Cliente_Password_FTP", SqlDbType.VarChar, this._cliente_Password_FTP);
			sql.AddParameter("@Cliente_Dir_Virtual_FTP", SqlDbType.VarChar, this._cliente_Dir_Virtual_FTP);
			sql.AddParameter("@Cliente_Port_Ftp", SqlDbType.Int, this._cliente_Port_Ftp);
			sql.AddParameter("@Cliente_Inicio_ES", SqlDbType.VarChar, this._cliente_Inicio_ES);
			sql.AddParameter("@Estado", SqlDbType.VarChar, this._estado);
			sql.AddParameter("@Gasonet", SqlDbType.Bit, this._gasonet);
			sql.AddParameter("@Cliente_Ip_Servidor_Ftp", SqlDbType.VarChar, this._cliente_Ip_Servidor_Ftp);
			sql.AddParameter("@Cliente_IP_Servidor_ES", SqlDbType.VarChar, this._cliente_IP_Servidor_Es);
			sql.AddParameter("@IntervaloSincronizacion", SqlDbType.SmallInt, this._intervaloSincronizacion);
			#endregion

			#region Execute SqlStatement
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
