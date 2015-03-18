using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Cara.
	/// </summary>
	public class Cara
	{
		#region Sección de Declaraciones
		private short _idCara;
		private short _idIsla;
		private short _idSurtidor;
		private short _idControlador;
		private string _estado;	//A ctivo, I nactivo, B loquear ventas
		private string _modo;	//A utomático, P self service, S istema, C Self/Sistema

		private short _idPos;
		
		private Mangueras _mangueras;
		private Controlador _controlador;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Cara()
		{
		}

		/// <summary>
		/// Destructor de la clase
		/// </summary>
		~Cara()
		{
			this._mangueras = null;
			this._controlador = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Cara
		/// </summary>
		public short IdCara
		{
			get { return this._idCara; }
			set { this._idCara = value; }
		}

		/// <summary>
		/// Id Isla
		/// </summary>
		public short IdIsla
		{
			get { return this._idIsla; }
			set { this._idIsla = value; }
		}

		/// <summary>
		/// Id Surtidor
		/// </summary>
		public short IdSurtidor
		{
			get { return this._idSurtidor; }
			set { this._idSurtidor = value; }
		}

		/// <summary>
		/// Id Controlador
		/// </summary>
		public short IdControlador
		{
			get { return this._idControlador; }
			set { this._idControlador = value; }
		}

		/// <summary>
		/// Estado
		/// </summary>
		public string Estado
		{
			get { return this._estado; }
			set { this._estado = value; }
		}

		/// <summary>
		/// Modo
		/// </summary>
		public string Modo
		{
			get { return this._modo; }
			set { this._modo = value; }
		}

		/// <summary>
		/// Descripción del Estado
		/// </summary>
		public string DescripcionEstado
		{
			get
			{
				switch (this._estado)
				{
					case "A":
						return "Activo";
					case "I":
						return "Inactivo";
					case "B":
						return "Ventas Bloqueadas";
					default:
						return "(sin definir)";
				}
			}
		}

		/// <summary>
		/// Descripción del Modo
		/// </summary>
		public string DescripcionModo
		{
			get
			{
				switch (this._modo)
				{
					case "A":
						return "Automático";
					case "P":
						return "Self Service";
					case "S":
						return "Sistema";
					case "C":
						return "Self S/Sistema";
					default:
						return "(sin definir)";
				}
			}
		}

		/// <summary>
		/// Id Pos (Pos configurado para la isla a la cual pertenece la cara).
		/// </summary>
		public short IdPos
		{
			get { return this._idPos; }
			set { this._idPos = value; }
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: IdControlador, Estado, Modo
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarCara");
			sql.ParametersNumber = 4;
			sql.AddParameter("@IdCara", SqlDbType.SmallInt, this._idCara);
			if (this._idControlador == 0)
				sql.AddParameter("@IdControlador", SqlDbType.SmallInt, null);
			else
				sql.AddParameter("@IdControlador", SqlDbType.SmallInt, this._idControlador);
			sql.AddParameter("@Estado", SqlDbType.VarChar, this._estado);
			sql.AddParameter("@Modo", SqlDbType.VarChar, this._modo);
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

		#region Referencia a objecto Controlador
		/// <summary>
		/// Referencia al objeto Controlador asociado a la cara.
		/// </summary>
		public Controlador Controlador
		{
			get
			{
				if (this._controlador == null)
					this._controlador = Controladores.ObtenerItem(this._idControlador);

				return this._controlador;
			}
		}
		#endregion

		#region Mangueras
		/// <summary>
		/// Mangueras configuradas para esta cara.
		/// </summary>
		public object Mangueras
		{
			get
			{
//				if (this._mangueras == null)
//					this._mangueras = new object();

				return this._mangueras;
			}
		}
		#endregion
	}
}