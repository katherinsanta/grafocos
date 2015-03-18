using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
    public class ConfiguracionDescuento
    {
        #region declaraciones
        private short _idDescuento;
        private short _tipoDescuento ;
        private decimal _porcDescuento;
        private string _itemsAfectados;
        private string _diasSemana;
        private DateTime _fechaInicio;
        private DateTime _fechaFinal;
        private DateTime _horaInicio;
        private DateTime _horaFinal;
        private bool _todasHoras;
        private int _valor;
        private bool _redondear;
        private DateTime _fechaCreacion;
        private DateTime _fechaModificacon;
        private string _idUsuario;
        private bool _estado;
        private string _estadoStr;
        private string _tipoDes;
        private string _aplica;
        private string _valAplica;

        #endregion

        #region propiedades

        public string ValorAplica
        {
            get { return _valAplica; }
            set { _valAplica = value; }
        }

        public string Aplica
        {
            get { return _aplica; }
            set { _aplica = value; }
        }
        public string TipoDes
        {
            get { return _tipoDes; }
            set { _tipoDes = value; }
        }
        public string EstadoStr
        {
            get { return _estadoStr; }
            set { _estadoStr = value; }
        }
        public int Valor 
        {
            get { return this._valor; }
            set { this._valor=value; }
        }
        public DateTime FechaCreacion
        {
            get { return this._fechaCreacion; }
            set { this._fechaCreacion = value; }
        }
        public DateTime FechaModificacion
        {
            get { return this._fechaModificacon; }
            set { this._fechaModificacon = value; }
        }
        public string IdUsuario
        {
            get { return this._idUsuario; }
            set { this._idUsuario = value; }
        }
        public bool Estado
        {
            get { return this._estado; }
            set { this._estado = value; }
        }
        public bool Redondear
        {
            get { return this._redondear; }
            set { this._redondear = value; }
        }
        public short IdDescuento
        {
            get { return this._idDescuento; }
            set { this._idDescuento = value; }
        }
        public short TipoDescuento
        {
            get { return this._tipoDescuento; }
            set { this._tipoDescuento = value; }
        }
        public decimal PorcDescuento
        {
            get { return _porcDescuento; }
            set { this._porcDescuento = value; }
        }
        public string ItemsAfectados
        {
            get { return _itemsAfectados; }
            set { this._itemsAfectados = value; }
        }
        public string DiasSemana
        {
            get { return _diasSemana; }
            set { this._diasSemana = value; }
        }
        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { this._fechaInicio = value; }
        }
        public DateTime FechaFinal
        {
            get { return _fechaFinal; }
            set { this._fechaFinal = value; }
        }
        public DateTime HoraInicio
        {
            get { return _horaInicio; }
            set { this._horaInicio = value; }
        }
        public DateTime HoraFinal
        {
            get { return _horaFinal; }
            set { this._horaFinal = value; }
        }
        public Boolean TodasHoras
        {
            get { return _todasHoras; }
            set { this._todasHoras = value; }
        }
        #endregion

        #region Modificar
        /// <summary>
        /// Actualización de las propiedades: Descripcion, UnidadMedida, Precio, Precio2, Precio3, Iva, Tipo, Color.
        /// </summary>
        public void Modificar()
        {
            #region Prepare Sql Command

            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("ActualizarConfiguracionDescuento");
            sql.ParametersNumber = 17;
            sql.AddParameter("@idDescuento", SqlDbType.SmallInt, this._idDescuento);
            sql.AddParameter("@TipoDescuento", SqlDbType.SmallInt, this._tipoDescuento);
            sql.AddParameter("@PorcentajeDescuento", SqlDbType.Decimal, this._porcDescuento);
            sql.AddParameter("@FechaInicio", SqlDbType.DateTime, this._fechaInicio);
            sql.AddParameter("@FechaFinal", SqlDbType.DateTime, this._fechaFinal);
            sql.AddParameter("@HoraInicio", SqlDbType.DateTime, this._horaInicio);
            sql.AddParameter("@HoraFinal", SqlDbType.DateTime, this._horaFinal);
            sql.AddParameter("@Items", SqlDbType.VarChar, this._itemsAfectados);
            sql.AddParameter("@DiasSemana", SqlDbType.VarChar, this._diasSemana);
            sql.AddParameter("@TodasHoras", SqlDbType.VarChar, this._todasHoras);
            sql.AddParameter("@Valor", SqlDbType.Int, this._valor);
            sql.AddParameter("@Redondear", SqlDbType.Bit, this._redondear);
            sql.AddParameter("@FechaCreacion", SqlDbType.DateTime, this._fechaCreacion);
            sql.AddParameter("@FechaModificacion", SqlDbType.DateTime, this._fechaModificacon);
            sql.AddParameter("@IdUsuario", SqlDbType.VarChar, this._idUsuario);
            sql.AddParameter("@Estado", SqlDbType.Bit, this._estado);
            sql.AddParameter("@Aplica", SqlDbType.VarChar, this._aplica);

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
