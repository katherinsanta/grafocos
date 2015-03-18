using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion {
	
	/// <summary>
	/// Comunicaciones.
	/// </summary>
	public class Comunicaciones: Servipunto.Libreria.Collection {

		#region Declarations
        private object _id_Comu_Red = 1;		
		#endregion
		
		#region Constructor
		/// <summary>
		/// Comunicaciones
		/// </summary>
		public Comunicaciones() {}
		#endregion 

		#region Indexer
		/// <summary>
		/// Indexa por llave
		/// </summary>
		new public Comunicacion this [string key] {
			get { return (Comunicacion)base[key]; }
		}
		/// <summary>
		/// Indexa por Indice 
		/// </summary>
		new public Comunicacion this [int index] {
			get { return (Comunicacion)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e) {		
			
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ComunicationsQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Id", SqlDbType.Int, this._id_Comu_Red);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()) {
				Comunicacion objComunicacion = new Comunicacion();
				try {
					objComunicacion.IdComunicaciones = 1;
					objComunicacion.Dispositivo = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();ParamNumber++;
					objComunicacion.Puerto = dr.IsDBNull(1)?"(Sin Definir)":dr.GetString(1).Trim();ParamNumber++;
					objComunicacion.TipoTransmision = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();ParamNumber++;
					objComunicacion.ModoTransmision = dr.IsDBNull(3)?"(Sin Definir)":dr.GetString(3).Trim();ParamNumber++;
					objComunicacion.PeriodoAutoEnvio = dr.IsDBNull(4)?(int)0:(dr.GetInt32(4) / 6000);ParamNumber++;
					objComunicacion.PeriodoAutoReception = dr.IsDBNull(5)?(int)0:(dr.GetInt32(5) / 6000);ParamNumber++;
					objComunicacion.RutaEnvios = dr.IsDBNull(6)?"(Sin Definir)":dr.GetString(6).Trim();ParamNumber++;
					objComunicacion.RutaProcesados = dr.IsDBNull(7)?"(Sin Definir)":dr.GetString(7).Trim();ParamNumber++;
					objComunicacion.RutaCliserv_Online = dr.IsDBNull(8)?"(Sin Definir)":dr.GetString(8).Trim();ParamNumber++;
					objComunicacion.RutaGenerador = dr.IsDBNull(9)?"(Sin Definir)":dr.GetString(9).Trim();ParamNumber++;
					objComunicacion.OnLineServerIP = dr.IsDBNull(10)?"(Sin Definir)":dr.GetString(10).Trim();ParamNumber++;
					objComunicacion.OnLineServerSocket = dr.IsDBNull(11)?"(Sin Definir)":dr.GetString(11).Trim();ParamNumber++;
					objComunicacion.OnlineTimeOut = dr.IsDBNull(12)?(int)0:dr.GetInt32(12);ParamNumber++;
					objComunicacion.InActiveTimeOut = dr.IsDBNull(13)?(int)0:dr.GetInt32(13);ParamNumber++;
					objComunicacion.RutaFTP = dr.IsDBNull(14)?"(Sin Definir)":dr.GetString(14).Trim();ParamNumber++;
					objComunicacion.FtpUserName = dr.IsDBNull(15)?"(Sin Definir)":dr.GetString(15).Trim();ParamNumber++;
					objComunicacion.FtpUserPasswd = dr.IsDBNull(16)?"(Sin Definir)":dr.GetString(16).Trim();ParamNumber++;
					objComunicacion.FtpVirtualDirectory = dr.IsDBNull(17)?"(Sin Definir)":dr.GetString(17).Trim();ParamNumber++;
					objComunicacion.FtpPort = dr.IsDBNull(18)?(int)0:dr.GetInt32(18);ParamNumber++;
					objComunicacion.ModoInicioTransmisor = dr.IsDBNull(19)?"(Sin Definir)":dr.GetString(19).Trim();ParamNumber++;
					objComunicacion.EstadoComunicaciones = dr.IsDBNull(20)?"(Sin Definir)":dr.GetString(20).Trim();ParamNumber++;
					objComunicacion.IsGasonet = dr.IsDBNull(21)?false:(dr.GetSqlByte(21) == 1?true:false); ParamNumber++;
					objComunicacion.FtpServerIp = dr.IsDBNull(22)?"(Sin Definir)":dr.GetString(22).Trim();ParamNumber++;
					objComunicacion.IpServidorGasonet = dr.IsDBNull(23)?"200.31.80.58":dr.GetString(23).Trim();ParamNumber++;
					objComunicacion.IntervaloSincronizacion = dr.IsDBNull(24)?(Int16)0:(dr.GetInt16(24));ParamNumber++;

				}
				catch 
				{
					throw new Exception("(Configuracion.Comunicaciones.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString() );
				}

				try{
					base.AddItem(objComunicacion.IdComunicaciones.ToString(), objComunicacion);
				}catch {
					throw new Exception("(Configuracion.Comunicaciones.Load) Error al agregar registro objeto objComunicacion !!" );
				}
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Permite Configurar Comunicaciones.
		/// </summary>
		/// <param name="objComunicacion">Objeto con la Informacion</param>
		public static void Adicionar (Comunicacion objComunicacion){

			#region Prepare Sql

			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ComunicationsInsertion");
			sql.ParametersNumber = 25;
			int ParamNumber = 0;
			try{
				sql.AddParameter("@Dispositivo", SqlDbType.VarChar, objComunicacion.Dispositivo);ParamNumber++;
				sql.AddParameter("@Puerto", SqlDbType.VarChar, objComunicacion.Puerto);ParamNumber++;
				sql.AddParameter("@Tipo_Trans", SqlDbType.VarChar, objComunicacion.TipoTransmision);ParamNumber++;
				sql.AddParameter("@Modo_Trans", SqlDbType.VarChar, objComunicacion.ModoTransmision);ParamNumber++;
				sql.AddParameter("@Periodo_Envio", SqlDbType.Int, objComunicacion.PeriodoAutoEnvio * 6000);ParamNumber++;
				sql.AddParameter("@Periodo_Recep", SqlDbType.Int, objComunicacion.PeriodoAutoReception * 6000);ParamNumber++;
				sql.AddParameter("@Path_Arch_Envio", SqlDbType.VarChar, objComunicacion.RutaEnvios.Trim());ParamNumber++;
				sql.AddParameter("@Path_Arch_Proce", SqlDbType.VarChar, objComunicacion.RutaProcesados.Trim());ParamNumber++;
				sql.AddParameter("@Path_Cliserv", SqlDbType.VarChar, objComunicacion.RutaCliserv_Online.Trim());ParamNumber++;
				sql.AddParameter("@Path_Generador", SqlDbType.VarChar, objComunicacion.RutaGenerador.Trim());ParamNumber++;
				sql.AddParameter("@Servidor_Ip", SqlDbType.VarChar, objComunicacion.OnLineServerIP );ParamNumber++;
				sql.AddParameter("@Cliente_socket_servidor_Es", SqlDbType.VarChar, objComunicacion.OnLineServerSocket.Trim());ParamNumber++;
				sql.AddParameter("@Cliente_TimeOut_ES", SqlDbType.Int, objComunicacion.OnlineTimeOut);ParamNumber++;
				sql.AddParameter("@Cliente_InActiveTimeOut_ES", SqlDbType.Int, objComunicacion.InActiveTimeOut);ParamNumber++;
				sql.AddParameter("@Cliente_Path_Arch_Ftp", SqlDbType.VarChar, objComunicacion.RutaFTP.Trim());ParamNumber++;
				sql.AddParameter("@Cliente_Usuario_FTP", SqlDbType.VarChar, objComunicacion.FtpUserName.Trim());ParamNumber++;
				sql.AddParameter("@Cliente_Password_FTP", SqlDbType.VarChar, objComunicacion.FtpUserPasswd.Trim());ParamNumber++;
				sql.AddParameter("@Cliente_Dir_Virtual_FTP", SqlDbType.VarChar, objComunicacion.FtpVirtualDirectory.Trim());ParamNumber++;
				sql.AddParameter("@Cliente_Port_Ftp", SqlDbType.Int, objComunicacion.FtpPort);ParamNumber++;
				sql.AddParameter("@Cliente_Inicio_ES", SqlDbType.VarChar, objComunicacion.ModoInicioTransmisor.Trim());ParamNumber++;
				sql.AddParameter("@Estado", SqlDbType.VarChar, objComunicacion.EstadoComunicaciones.Trim());ParamNumber++;
				sql.AddParameter("@Gasonet", SqlDbType.Bit, objComunicacion.IsGasonet);ParamNumber++;
				sql.AddParameter("@Cliente_Ip_Servidor_Ftp", SqlDbType.VarChar, objComunicacion.FtpServerIp.Trim());ParamNumber++;
				sql.AddParameter("@Cliente_IP_Servidor_ES", SqlDbType.VarChar, objComunicacion.IpServidorGasonet); ParamNumber++;
				sql.AddParameter("@IntervaloSincronizacion", SqlDbType.SmallInt, objComunicacion.IntervaloSincronizacion);

			}
			catch
			{
				throw new Exception("(Configuracion.Comunicaciones.Adicionar) Error al asignar Tipo de Datos, Parametro #: " + ParamNumber.ToString() );
			}			
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Eds ya Posse Comunicaciones " + " !ERROR BD! ");
				else
					throw new Exception(e.Message + e.StackTrace  + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion

		}
		#endregion

		#region GetItem
		/// <summary>
		/// Metodo para obtener comunicaciones de la EDS.
		/// </summary>
		/// <returns>Informacion de comunicaciones.</returns>
		public static Comunicacion ObtenerItem() {
			Comunicaciones objComunicaciones = new Comunicaciones();
			if (objComunicaciones.Count == 1)
				return objComunicaciones[0];
			else
				return null;
		}

		#endregion

		#region envio de archivos por FTP
		/// <summary>
		/// Envio de archivos hacia un servidor FTP. 
		/// Retorna una cadena vacia cuando todo es satisfatorio,
		/// Retorna una cadena de error cuando ocurra algun problema.
		/// </summary>	
		/// <param name="servidorFTP">Direccion del servidor FTP</param>
		/// <param name="usuario">nombre de sesion usuario</param>
		/// <param name="contraseña">contraseña de usuario</param>
		/// <param name="puerto">puerto de comunicacion</param>
		/// <param name="archivoLocal">Ruta y nombre del archivo a enviar</param>
		/// <param name="archivoRemoto">Nombre que se asignara al archivo en el servidor FTP, si es "" se asignara automaticamente</param>
		/// <param name="directorioRemoto">Directorio remoto en el servidor FTP donde se colocara el archivo</param>
		/// <param name="implisitSSL">Fija si utiliza una conexion segura SSL en modo Impicit</param>
		/// <param name="modoPasivo">True: El usuario envia el puerto de conexion, False: El servidor asigna el puerto de conexion</param>
			

		public string EnviarAFTP(string servidorFTP, 
								string usuario, 
								string contraseña, 
								int puerto,
								string archivoLocal,
								string archivoRemoto,
								string directorioRemoto,
								bool implisitSSL,
								bool modoPasivo
								)
		{
			#region declaraciones
			Chilkat.Ftp2 ftp = new Chilkat.Ftp2();
			bool success;
			string [] arreglo;
			#endregion

			#region proceso de subir el archivo al FTP
			//  Any string unlocks the component for the 1st 30-days.
			success = ftp.UnlockComponent("USERVIPFTP_6o53Ueaf7L8y");
			if (success != true) 
				return "Error en Desbloqueo de componete Chilkat " + ftp.LastErrorText;

			//  You may use this account for testing.
			//  This account allows for directory listings and files
			//  to be downloaded.  However, file uploads are not allowed.
			ftp.Hostname = servidorFTP.Trim();
			ftp.Username = usuario.Trim();
			ftp.Password = contraseña.Trim();
			ftp.Port = puerto;
			// modo pasivo
			if(modoPasivo)
			{
				ftp.Passive = true;
				ftp.PassiveUseHostAddr = true;
			}

			if(implisitSSL)
			{
				//  We don't want AUTH SSL:
				ftp.AuthTls = false;
				//  We want Implicit SSL:
				ftp.Ssl = true;
			}

			//  Connect and login to the FTP server.
			success = ftp.Connect();
			if (success != true) 
				return "error al establecer la conexión: " + ftp.LastErrorText;							

			// Change to the remote directory where the file will be uploaded.
			if(directorioRemoto.Trim().Length == 0)
				directorioRemoto = "/";


			success = ftp.ChangeRemoteDir("/");
			if (success != true) 
				return "error al ingresar al directorio remoto '" + directorioRemoto + "': " + ftp.LastErrorText;			
			
			//crea el nombre del archivo por default si no fue pasado por parametro
			if(archivoRemoto.Trim().Length == 0)
			{
				arreglo = archivoLocal.Split("\\".ToCharArray());
				if(arreglo.Length>0)
					archivoRemoto = arreglo[arreglo.Length-1];
			}

			// Upload a file.
			success = ftp.PutFile(archivoLocal,archivoRemoto);
			if (success != true) 
				return "error al copiar el archivo local '" + archivoLocal + "', remoto '" + archivoRemoto + "' :" + ftp.LastErrorText;			
		
			ftp.Disconnect();
			return "";
			#endregion
		}
		#endregion	

	}
}
