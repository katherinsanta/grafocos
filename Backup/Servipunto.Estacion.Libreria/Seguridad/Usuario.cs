using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Cuenta de Usuario
	/// </summary>
	public class Usuario
	{
		#region Sección de Declaraciones
		private string _idUsuario;
		private byte _idRol;
		private string _nombre;
		private EstadoUsuario _estado;
		private string _contrasena = string.Empty;
		private string _cod_Emp;
		private string _rol;


		private Permisos _permisos;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Usuario()
		{
		}

		/// <summary>
		/// Destructor de la Clase
		/// </summary>
		~Usuario()
		{
			this._permisos = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código del Usuario
		/// </summary>
		public string IdUsuario
		{
			get { return this._idUsuario; }
			set { this._idUsuario = value; }
		}

		/// <summary>
		/// Código del Rol al cual pertenece el Usuario
		/// </summary>
		public byte IdRol
		{
			get { return this._idRol; }
			set { this._idRol = value; }
		}

		/// <summary>
		/// Nombre Descriptivo
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		/// <summary>
		/// Estado Actual del Usuario
		/// </summary>
		public EstadoUsuario Estado
		{
			get { return this._estado; }
			set { this._estado = value; }
		}

		/// <summary>
		/// Contraseña
		/// </summary>
		public string Contrasena
		{
			get { return this._contrasena; }
			set { this._contrasena = value; }
		}

		/// <summary>
		/// Nombre del Rol
		/// </summary>
		public string Rol
		{
			get { return this._rol; }
			set { this._rol = value; }
		}		

		/// <summary>
		/// Codigo del empleado con quien tiene relacion
		/// </summary>
		public string CodigoEmpleado
		{
			get { return this._cod_Emp; }
			set { this._cod_Emp = value; }
		}
		#endregion

		#region Método Modificar
		/// <summary>
		/// Actualización de las propiedades: IdRol, Nombre, Estado
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarUsuario");
			sql.ParametersNumber = 5;
			sql.AddParameter("@IdUsuario", SqlDbType.VarChar, this._idUsuario);
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
			sql.AddParameter("@Usuario", SqlDbType.VarChar, this._nombre);
			sql.AddParameter("@Estado", SqlDbType.Bit, this._estado == EstadoUsuario.Activo?1:0);
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, this._cod_Emp);
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

		#region Referencia a Permisos
		/// <summary>
		/// Referencia a los permisos a los cuales tiene derecho el Usuario.
		/// </summary>
		public Permisos Permisos
		{
			get
			{
				if (this._permisos == null)
					this._permisos = new Permisos(this._idRol);

				return this._permisos;
			}
		}
		#endregion

		#region Método CambiarContrasena
		/// <summary>
		/// Cambio de contraseña
		/// </summary>
		/// <param name="nuevaContrasena">Nueva Contraseña</param>
		public void CambiarContrasena(string nuevaContrasena)
		{
			nuevaContrasena = Servipunto.Libreria.Cryptography.Encrypt(nuevaContrasena);

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder  sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("CambiarContrasenaUsuario");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdUsuario", SqlDbType.VarChar, this._idUsuario);
			sql.AddParameter("@Contrasena", SqlDbType.VarChar, nuevaContrasena);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				this._contrasena = nuevaContrasena;
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

		#region Método InicializarContrasena
		/// <summary>
		/// Inicialización de la contraseña del Usuario (4 últimos digitos del documento de identificación)
		/// </summary>
		public void InicializarContrasena()
		{
			string nuevaContrasena;
			if (this._idUsuario.Length > 4)
				nuevaContrasena = this._idUsuario.Substring(this._idUsuario.Length - 4,  4);
			else
				nuevaContrasena = this._idUsuario;

			this.CambiarContrasena(nuevaContrasena);
		}
		#endregion
	}
}