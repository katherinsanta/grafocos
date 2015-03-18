using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
    /// <summary>
    /// Pagos de una venta
    /// </summary>
    public class Auditoria
    {
        #region Secci�n de Declaraciones
        private int consecutivo;
        private string placa;
        private string cod_Cli;
        private int IdformaPago;
        private decimal total;
        #endregion

        #region Constructor y Destructor
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Auditoria()
        {
        }
        #endregion

        #region Propiedades P�blicas

        /// <summary>
        /// Consecutivo de la venta.
        /// </summary>
        public int Consecutivo
        {
            get { return this.consecutivo; }
            set { this.consecutivo = value; }
        }
        /// <summary>
        /// placa de un cliente
        /// </summary>
        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        /// <summary>
        /// C�digo del cliente.
        /// </summary>
        public string Cod_Cli
        {
            get { return cod_Cli; }
            set { cod_Cli = value; }
        }
        /// <summary>
        /// C�digo de la forma de pago
        /// </summary>
        public int FormaDepago
        {
            get { return IdformaPago; }
            set { IdformaPago = value; }
        }
        /// <summary>
        /// Total de la venta.
        /// </summary>
        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }
        public void Modificar() { }
        #endregion
    }
}
