using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Prepagos
{
    /// <summary>
    /// Clase para manejo de creacion de prepago
    /// </summary>
    public class CreacionPrepago
    {
        #region Secci�n de Declaraciones
        int _numeroInicialPrepagoCreado;
        int _numeroFinalPrepagoCreado;
        DateTime _fecha;
        string _idUsuario;
        decimal _denominacion;
        decimal _totalDenominacion;
        int _cantidadPrepagosCreados;
        int _idCreaci�n;


        private bool _existe;
        #endregion

        #region Constructor y Destructor
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public CreacionPrepago()
        {
        }
        #endregion

        #region Propiedades P�blicas
        /// <summary>
        /// Numero Inicial
        /// </summary>
        public int NumeroInicialCreacion
        {
            get { return this._numeroInicialPrepagoCreado; }
            set { this._numeroInicialPrepagoCreado = value; }
        }

        /// <summary>
        /// Numero Final de creacion
        /// </summary>
        public int NumeroFinalCreacion
        {
            get { return this._numeroFinalPrepagoCreado; }
            set { this._numeroFinalPrepagoCreado = value; }
        }

        /// <summary>
        /// C�digo de la Opci�n
        /// </summary>
        public DateTime Fecha
        {
            get { return this._fecha; }
            set { this._fecha = value; }
        }

        /// <summary>
        /// C�digo de la Acci�n
        /// </summary>
        public string IdUsuario
        {
            get { return this._idUsuario; }
            set { this._idUsuario = value; }
        }

        /// <summary>
        /// Denominacion
        /// </summary>
        public decimal Denominacion
        {
            get { return this._denominacion; }
            set { this._denominacion = value; }
        }

        /// <summary>
        /// Total Denominaciom
        /// </summary>
        public decimal TotalDenominacion
        {
            get { return this._totalDenominacion; }
            set { this._totalDenominacion = value; }
        }

        /// <summary>
        /// Cantida de tiquetes
        /// </summary>
        public int CantidadPrepagosCreados
        {
            get { return this._cantidadPrepagosCreados; }
            set { this._cantidadPrepagosCreados = value; }

        }
        public int IdCreacion
        {
            get { return this._idCreaci�n;}
            set { this._idCreaci�n = value;}
                
        }

        #endregion

        #region Modify
        /// <summary>
        /// Permite Modificar Tanques
        /// </summary>
        public void Modificar()
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ModificarRangoCreacionPrepagos");
            sql.ParametersNumber = 6;
            sql.AddParameter("@IdInventario", SqlDbType.Int, this._idCreaci�n);
            sql.AddParameter("@NumeroInicialPrepagoCreado", SqlDbType.Int, this._numeroInicialPrepagoCreado);
            sql.AddParameter("@NumeroFinalPrepagoCreado", SqlDbType.Int, this._numeroFinalPrepagoCreado);            
            sql.AddParameter("@Denominacion", SqlDbType.Decimal, this._denominacion);
            sql.AddParameter("@TotalDenominacion", SqlDbType.Decimal, this._totalDenominacion);
            sql.AddParameter("@CantidadPrepagosCreados", SqlDbType.Int, this._cantidadPrepagosCreados);           

            #endregion

            #region Execute Sql command
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
