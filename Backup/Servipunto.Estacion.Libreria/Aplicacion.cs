using System;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Control general de la aplicaci�n, expone m�todos y propiedades de uso global en la aplicaci�n.
	/// </summary>
	public class Aplicacion
	{
		#region Secci�n de Declaraciones
		private static Servipunto.Libreria.Connection _conexion;
		private static Servipunto.Libreria.Registry _registry;
		
		private static Servipunto.Libreria.LogFile _log;
		#endregion

		#region Constructor/Destructor
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public Aplicacion()
		{
		}

		/// <summary>
		/// Destructor de la clase
		/// </summary>
		~Aplicacion()
		{
			_conexion = null;
			_registry = null;
			_log = null;
		}
		#endregion

		#region Referencia a Conexi�n de Base de Datos
		/// <summary>
		/// Referencia a la conexi�n a la base de datos del sistema.
		/// </summary>
		public static Servipunto.Libreria.Connection Conexion
		{
			get
			{
				if (_conexion == null)
				{
					string server;
					string database;
					string user;
					string password;

					server = Registry.Read("server");
					database = Registry.Read("database");
					user = Registry.Read("user");
					password = Registry.Read("password");

					_conexion = new Servipunto.Libreria.Connection(server, database, user, password);
				}
				return _conexion;
			}
            set
            {
                _conexion = value;
            }
		}
		#endregion

		#region Referencia a Registry
		/// <summary>
		/// Referencia al registro de windows para leer y almacenar valores en el registry.
		/// </summary>
		public static Servipunto.Libreria.Registry Registry
		{
			get
			{
				if (_registry == null)
				{
					_registry = new Servipunto.Libreria.Registry(Microsoft.Win32.Registry.LocalMachine, @"Software\Servipunto\Estacion\BD");
				}
				return _registry;
			}
		}
		#endregion

		#region M�todo de Autenticaci�n
		/// <summary>
		/// M�todo utilizado para verificar la autenticidad del usuario que desea ingresar al sistema.
		/// </summary>
		/// <param name="idUsuario">C�digo del Usuario</param>
		/// <param name="contrasena">Password del Usuario</param>
		/// <returns>Instancia del usuario al cual pertenecen las credenciales enviadas.  Retorna Null si no es un usuario valido.</returns>
		public static Usuario Autenticacion(string idUsuario, string contrasena)
		{
			Usuario objUsuario;
			try
			{
				objUsuario = Usuarios.Obtener(idUsuario);
				if (objUsuario != null)
				{
					if (objUsuario.Contrasena == Servipunto.Libreria.Cryptography.Encrypt(contrasena))
					{
						if (objUsuario.Estado == EstadoUsuario.Activo)
							return objUsuario;
						else
							throw new Exception("La cuenta de usuario asociada al n�mero de identificaci�n " + idUsuario + " no esta activa!");
					}
					else
						return null;
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				objUsuario = null;
			}
		}
		#endregion

		#region Refresh
		/// <summary>
		/// Actualiza la referencia al objeto conexi�n...
		/// </summary>
		public static void Refresh()
		{
			_conexion = null;
			_log = null;
		}
		#endregion

		#region M�todo IsNumeric
		/// <summary>
		/// Funci�n que determina si una cadena de texto es n�merica o no.
		/// </summary>
		/// <param name="text">Cadena de texto a evaluar</param>
		/// <returns>True si es num�rico, False si no es num�rico</returns>
		public static bool IsNumeric(string text)
		{
			if (text.Length == 0)
				return false;
			else
			{
				System.Text.RegularExpressions.Regex objExpression = new System.Text.RegularExpressions.Regex("[0-9]");
				if (objExpression.IsMatch(text))
					return true;
				else
					return false;
			}
		}
		#endregion

		#region Log de Aplicaci�n
		/// <summary>
		/// Acceso a log de aplicaci�n.
		/// </summary>
		public static Servipunto.Libreria.LogFile Log
		{
			get 
			{
				if (_log == null)
					_log = new Servipunto.Libreria.LogFile();

				return _log;
			}
			set { _log = value; }
		}
		#endregion

	}
}