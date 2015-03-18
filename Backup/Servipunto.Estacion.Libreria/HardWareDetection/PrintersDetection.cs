using System;
using System.Drawing.Printing;


namespace Servipunto.Estacion.Libreria.HardWareDetection
{
	/// <summary>
	/// Descripción breve de PrintersDetection.
	/// </summary>
	public class PrintersDetection
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public PrintersDetection()	{}

		#endregion

		#region Methods
		/// <summary>
		/// Retorna el nombre de la impresora
		/// </summary>
		/// <returns>Collecion con el nombre de todas las impresoras locales </returns>
		public System.Drawing.Printing.PrinterSettings.StringCollection PrintersNames (){
			return PrinterSettings.InstalledPrinters;
		}

		
		/// <summary>
		/// Retorna la cantidad de impresoras locales instaladas en la maquina
		/// </summary>
		/// <returns>Cantidad de impresoras locales instaladas</returns>
		public int PrintersCount(){
			return PrinterSettings.InstalledPrinters.Count;
		}

	
		/// <summary>
		/// Retorna el indice de la impresora en la colleccion de impresoras instaladas en la maquina
		/// </summary>
		/// <param name="PrinterName">Nombre de la impresora a buscar</param>
		/// <returns></returns>
		public int PrinterIndex(string PrinterName){
			for(int i = 0 ; i < PrinterSettings.InstalledPrinters.Count; i++){
				if (PrinterName.CompareTo(PrinterSettings.InstalledPrinters[i]) == 0){
					return i;
				}
			}
			return -1; //If not exist
		}
		#endregion
	}
}
