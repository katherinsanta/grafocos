using System;
using System.Collections;
using Servipunto.Estacion.Libreria.IbuttonInterface;
using Servipunto.Estacion.Libreria.Configuracion;

namespace Servipunto.Estacion.Libreria.HardWareDetection
{
	/// <summary>
	/// Descripción breve de DSDetection.
	/// </summary>
	public class DSDetection
	{

		#region Declarations
		private IbuttonAdapter _ds = new IbuttonAdapter(null); 
		#endregion
		
		#region Constructor

		/// <summary>
		/// DSDetection Constructor
		/// </summary>
		public DSDetection(){}


		#endregion

		#region Methods

		/// <summary>
		/// Detects All IdRoms attached to com serial port
		/// </summary>
		/// <param name="com">COMx Port... COM1, COM2 ...</param>
		/// <returns>Collection of All IdRoms attached to com serial port</returns>

		public ArrayList DetectIdRoms(string com){
			string msg = "";
			if (_ds.StartRed(com,TypeAdapter.DS9097U, ref msg ) ) {				
				System.Collections.ArrayList roms = null;
				if (_ds.GetButtonList(ref roms) > 0) {
					_ds.Close();
					return roms;
				}
			}
			_ds.Close();
			return null;
		}


		/// <summary>
		/// Detects All DS9097 and DS2409 attached to com serial port and stores them in Ds_red table
		/// </summary>
		/// <returns></returns>
		private bool DetectDS(string com){
			
			Lector objLector = new Lector();			
			ArrayList ar = this.DetectIdRoms(com);
			String DS9097 = "";

			if(ar != null){
				foreach(String idr in ar){
					if(IbuttonAdapter.Is9097(idr)){
						DS9097 = idr;
					}else if (IbuttonAdapter.Is2409(idr)){
						objLector.IdInterfaz = DS9097.Trim();
						objLector.IdLector = idr;
						objLector.IdPuerto = com;
						objLector.Monitoreo = false;
						objLector.Version = 3;
						Lectores.Adicionar(objLector);
					}					
				}
			}else{
				return false;
			}
			return true;
		}


		/// <summary>
		/// DetectDS: Scans 20 ports and stores DS in Table DS_red
		/// </summary>
		public void DetectDS(){

			try{
				Servipunto.Estacion.Libreria.Configuracion.Lectores.Eliminar(null);
				for(int i = 1; i < 20; i++){
					this.DetectDS("COM" + i);
				}
			}catch (Exception){
				//Could not delete Ds_Red table
			}			
		}

		#endregion

	}
}
