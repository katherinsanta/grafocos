using System;
using SerialPorts;

namespace Servipunto.Estacion.Libreria.HardWareDetection
{
	/// <summary>
	/// Descripción breve de ScanPorts.
	/// </summary>
	public class SerialPortsDetection{
		
		#region Declarations
		//CdrvLibNet Port = new CdrvLibNet();
		private WithEvents	Func = new WithEvents();
		#endregion
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public SerialPortsDetection(){}
		#endregion

		#region Methods
		/// <summary>
		/// Scans for Port
		/// </summary>
		/// <param name="NumPort">Port number to scan</param>
		/// <returns>true if exist, false other case.</returns>
		public bool Scan(int NumPort){
			string s;
			SerialPort p = new SerialPort(this.Func);
			s = "COM" + NumPort.ToString() + ":";
			return p.Available(s);
		}

		#endregion

	}
}
