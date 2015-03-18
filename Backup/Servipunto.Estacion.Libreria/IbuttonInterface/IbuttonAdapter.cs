using System;
using System.Runtime.InteropServices;
//using HardTech.Components.HardLibrary;
using System.Collections;

namespace Servipunto.Estacion.Libreria.IbuttonInterface
{
	#region Enums
	/// <summary>
	/// Enum: Open/Close Switch
	/// </summary>
	public enum MainSwicthState {
		/// <summary>
		/// Switch Close circuit.
		/// </summary>
		Close = 0xA5,
		/// <summary>
		/// Switch Open Circuit
		/// </summary>
		Open=0xCC}


	/// <summary>
	/// Enum: DS Type Adapters
	/// </summary>
	public enum TypeAdapter :short {
		/// <summary>
		/// DS9097E
		/// </summary>
		DS9097E=1,
		/// <summary>
		/// Parallel
		/// </summary>
		Parallel=2,
		/// <summary>
		/// DS9097U
		/// </summary>
		DS9097U=5,
		/// <summary>
		/// USB
		/// </summary>
		USB=6
	}
	
	#endregion

	#region IbuttonAdapter Class
	/// <summary>
	/// Interface with DS
	/// </summary>
	public class IbuttonAdapter : IDisposable {

		#region TMEX Functions
	
		/// <summary>
		/// TMExtendedStartSession
		/// </summary>
		/// <param name="portNum"></param>
		/// <param name="portType"></param>
		/// <param name="sessionOptions"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]                
		public static extern int TMExtendedStartSession(int portNum, int portType, int[] sessionOptions);
      
		/// <summary>
		/// TMStartSession
		/// </summary>
		/// <param name="i1"></param>
		/// <returns></returns>
	
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern int TMStartSession(int i1);
      
		/// <summary>
		/// TMValidSession
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMValidSession(int sessionHandle);
      
		/// <summary>
		/// TMEndSession
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMEndSession(int sessionHandle);
      
		/// <summary>
			/// TMFirst TMEX - Network
			/// </summary>
			/// <param name="sessionHandle"></param>
			/// <param name="stateBuffer"></param>
			/// <returns></returns> 
			[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMFirst(int sessionHandle, byte[] stateBuffer);
      
		/// <summary>
		/// TMNext
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="stateBuffer"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMNext(int sessionHandle, byte[] stateBuffer);
      
		/// <summary>
		/// TMAccess
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="stateBuffer"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMAccess(int sessionHandle, byte[] stateBuffer);
      
		/// <summary>
			/// TMStrongAccess
			/// </summary>
			/// <param name="sessionHandle"></param>
			/// <param name="stateBuffer"></param>
			/// <returns></returns>
			[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMStrongAccess(int sessionHandle, byte[] stateBuffer);
      
		/// <summary>
		/// TMStrongAlarmAccess
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="stateBuffer"></param>
		/// <returns></returns>
			[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMStrongAlarmAccess(int sessionHandle, byte[] stateBuffer);
      
		/// <summary>
		/// TMOverAccess
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="stateBuffer"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMOverAccess(int sessionHandle, byte[] stateBuffer);
      
		/// <summary>
		/// TMRom
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="stateBuffer"></param>
		/// <param name="ROM"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMRom(int sessionHandle, byte[] stateBuffer, short[] ROM);
      
		/// <summary>
		/// TMSearch
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="stateBuffer"></param>
		/// <param name="doResetFlag"></param>
		/// <param name="skipResetOnSearchFlag"></param>
		/// <param name="searchCommand"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMSearch(int sessionHandle, byte[] stateBuffer, short doResetFlag, short skipResetOnSearchFlag, short searchCommand);

		/// <summary>
		/// TMReadPacket
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="stateBuffer"></param>
		/// <param name="startPage"></param>
		/// <param name="readBuffer"></param>
		/// <param name="maxRead"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMReadPacket(int sessionHandle, byte[] stateBuffer, short startPage, byte[] readBuffer, short maxRead);
		
		#region Others
		/*public static native short TMFirstAlarm(long, void *);
		public static native short TMNextAlarm(long, void *);
		public static native short TMFamilySearchSetup(long, void *, short);
		public static native short TMSkipFamily(long, void *);
		public static native short TMAutoOverDrive(long, void *, short);*/
		#endregion
		
		/// <summary>
		/// TMBlockIO  TMEX - transport
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="dataBlock"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]			
		public static extern short TMBlockIO(int sessionHandle, byte[] dataBlock, short len);
      
		/// <summary>
		/// TMSetup   TMEX - Hardware Specific
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMSetup(int sessionHandle);

		/// <summary>
		/// TMTouchReset
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMTouchReset(int sessionHandle);
      
		/// <summary>
		/// TMTouchByte
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="byteValue"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMTouchByte(int sessionHandle, short byteValue);
      
		/// <summary>
		/// TMTouchBit
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="bitValue"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMTouchBit(int sessionHandle, short bitValue);
      
		/// <summary>
		/// TMProgramPulse
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMProgramPulse(int sessionHandle);
      
		/// <summary>
		/// TMClose
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMClose(int sessionHandle);
      
		/// <summary>
		/// TMOneWireCom
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="command"></param>
		/// <param name="argument"></param>
		/// <returns></returns>
	
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMOneWireCom(int sessionHandle, short command, short argument);
      
		/// <summary>
		/// TMOneWireLevel
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="command"></param>
		/// <param name="argument"></param>
		/// <param name="changeCondition"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMOneWireLevel(int sessionHandle, short command, short argument, short changeCondition);
      
		/// <summary>
		/// TMGetTypeVersion
		/// </summary>
		/// <param name="portType"></param>
		/// <param name="sbuff"></param>
		/// <returns></returns>	
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMGetTypeVersion(int portType, System.Text.StringBuilder sbuff);
      
		/// <summary>
		/// Get_Version
		/// </summary>
		/// <param name="sbuff"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short Get_Version(System.Text.StringBuilder sbuff);
      
		/// <summary>
		/// TMBlockStream
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="dataBlock"></param>
		/// <param name="len"></param>
		/// <returns></returns>
			[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMBlockStream(int sessionHandle, byte[] dataBlock, short len);
      
		/// <summary>
		/// TMGetAdapterSpec
		/// </summary>
		/// <param name="sessionHandle"></param>
		/// <param name="adapterSpec"></param>
		/// <returns></returns>	
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMGetAdapterSpec(int sessionHandle, byte[] adapterSpec); /*byte[319]*/
     	
		/// <summary>
		/// TMReadDefaultPort
		/// </summary>
		/// <param name="portTypeRef"></param>
		/// <param name="portNumRef"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMReadDefaultPort(short portTypeRef, short portNumRef);

		/// <summary>
		/// TMBlockStream
		/// </summary>
		/// <param name="portTypeRef"></param>
		/// <param name="portNumRef"></param>
		/// <returns></returns>
		[DllImport("IBFS32.dll"/*, CharSet=CharSet.Auto*/)]
		public static extern short TMBlockStream(short portTypeRef, short portNumRef);

		#endregion
	
		#region Members

		private int _hSess = 0;
		byte [] _stateBuffer = new byte[15360];
		private ArrayList _idLectores;

		#endregion

		#region Constructor

		/// <summary>
		/// Class Constructor
		/// </summary>
		/// <param name="idLectores"></param>
		public IbuttonAdapter( ArrayList idLectores) {
				this._idLectores = idLectores;
		}
		#endregion
	
		#region DsRed Start
		
		/// <summary>
		/// StartRed
		/// </summary>
		/// <param name="portNum"></param>
		/// <param name="portType"></param>
		/// <param name="msg"></param>
		/// <returns></returns>		
		public bool StartRed(string portNum, TypeAdapter portType, ref string msg) {
			short port = System.Convert.ToInt16( portNum.Substring((3)));
			return Iniciar( port, (short)portType, ref msg);
		}


		/// <summary>
		/// Iniciar
		/// </summary>
		/// <param name="portNum"></param>
		/// <param name="portType"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		private bool Iniciar(short portNum, short portType,ref string msg ) {
			bool status = false;
			short result = 0;
		
			try {
				if (_hSess == 0 ) {
					_hSess = TMExtendedStartSession(portNum, portType, null);
					if (_hSess > 0) {
						result = TMSetup(_hSess);
						switch( result ) {
							case 1:
								if (TMOneWireCom(_hSess, 0,2) >= 0){
									status = true;
								}else{
									msg = "Puerto: " + portNum.ToString() +  " Error Setteando OverDrive"; 
								}
								break;
							case 0:
								msg = "Puerto: " + portNum.ToString() +  " Setup Falló"; 
								break;
							case 2:
								msg = "Puerto: " + portNum.ToString() +  " Corto en Microlan"; 
								break;
							case  3:
								msg = "Puerto: " + portNum.ToString() +  " Microlan no Existe"; 
								break;
							case 4:
								msg = "Puerto: " + portNum.ToString() +  " Setup No soportado"; 
								break;
							case -200:
								msg = "Puerto: " + portNum.ToString() +  " Session Inválida"; 
								break;
						}
					}
				}else if (_hSess == 0) {
					msg = "Puerto: " + portNum.ToString() +  " No Disponible"; 
				}else if (_hSess < 0) {
					msg = "Puerto: " + portNum.ToString() +  " No Abre Session"; 
				}
			}catch(Exception ex) {
				msg = ex.Message;
				status =  false;
			}
			return (status);
		}
		#endregion

		#region End DS Session
		/// <summary>
		/// EndSession
		/// </summary>
		private void EndSession() {
			if (_hSess > 0) {
				TMEndSession(_hSess);
				_hSess=0;
			}
		}
		#endregion

		#region Methods

		/// <summary>
		/// SelectDevice
		/// </summary>
		/// <param name="romCode"></param>
		/// <returns></returns>
	
		private bool SelectDevice(String romCode) {
			short[] ROM = new short[9];	// leave room for 32 bit value
			for (int i=7; i>=0; i--) {
				short hex = (short)  Encripcion.HexToDec(romCode.Substring(i*2,2));
				ROM[7-i] = hex;
			}
			TMRom(_hSess, _stateBuffer, ROM);
			int n=TMAccess(_hSess, _stateBuffer);
			return n==1;
		}

		
		/// <summary>
		/// SelectDeviceStrong
		/// </summary>
		/// <param name="romCode"></param>
		/// <returns></returns>
		private bool SelectDeviceStrong(String romCode) {
			short[] ROM = new short[9]; // leave room for 32 bit value
			for (int i=7; i>=0; i--) {
				short hex = (short)  Encripcion.HexToDec(romCode.Substring(i*2,2));
				ROM[7-i] = hex;
			}
			TMRom(_hSess, _stateBuffer, ROM);
			int n=TMStrongAccess(_hSess, _stateBuffer);
			return n==1;
		}


		/// <summary>
		/// SetStateMainSwitch
		/// </summary>
		private bool SetStateMainSwitch(String romCode, MainSwicthState state) {
			short[]  ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};		// leave room for 32 bit value
			short n =0;
			for (int i=7; i>=0; i--) {
				short hex = (short)  Encripcion.HexToDec(romCode.Substring(i*2,2));
				ROM[7-i] = hex;
			}
			short ret = TMRom(_hSess, _stateBuffer, ROM);
			if(ret == 1) {
				ret = TMStrongAccess(_hSess, _stateBuffer);
				if (ret == 1) {
					n = TMTouchByte(_hSess, (short)state );
				}
			}
			return (n>=1);
		}


		/// <summary>
		/// ReadPage
		/// </summary>
		/// <param name="page"></param>
		/// <param name="data"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		bool ReadPage(int page, byte[] data, int len) {
			if (len > 32) return false;
			TMAccess(_hSess, _stateBuffer);
			TMTouchByte(_hSess, 0xF0);
			TMTouchByte(_hSess, (short)((page*32)&0xFF));
			TMTouchByte(_hSess, (short)((page*32)>>8));
			for (int i=0; i<len; i++) {
				data[i]= (byte)TMTouchByte(_hSess,(short) 0xFF);
			}
			return true;
		}


		/// <summary>
		/// WritePage
		/// </summary>
		/// <param name="page"></param>
		/// <param name="data"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		public bool WritePage(int page, byte[] data, int len) {		
			TMAccess(_hSess, _stateBuffer);
			TMTouchByte(_hSess, 0x0F);
			TMTouchByte(_hSess, (short)((page*32)&0xFF));
			TMTouchByte(_hSess, (short)((page*32)>>8));
			TMBlockStream(_hSess, data, (short)len);

			TMAccess(_hSess, _stateBuffer);
			TMTouchByte(_hSess, 0xAA);
			byte[] auth = new byte [3];
			for (int i=0; i<3; i++) {
				auth[i]=(byte)TMTouchByte(_hSess, 0xFF);
			}
			TMAccess(_hSess, _stateBuffer);
			TMTouchByte(_hSess, 0x55);
			for (int i=0; i<3; i++) {
				TMTouchByte(_hSess, auth[i]);
			}
			return true;
		}
	

		/// <summary>
		/// GetButtonList
		/// </summary>
		/// <param name="codes"></param>
		/// <returns></returns>
	
		public int GetButtonList(ref ArrayList codes) {
			short ret=TMFirst(_hSess, _stateBuffer);
			codes = new ArrayList();
			while ( (ret==1) && (codes.Count<32) ) {
				// if MSB of ROM[0] != 0, then write, else read
				short[] ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
				TMRom(_hSess, _stateBuffer, ROM);

				// convert the ROM code into a string
				String romCode="";
				for (int i=7; i>=0; i--)
					romCode+=ROM[i].ToString("X2");;

				codes.Add(romCode);
				ret=TMNext(_hSess, _stateBuffer);
			}
			if (codes.Count > 0  ) {
				_idLectores = new ArrayList();
				foreach ( string id in codes)
					if (id.Substring(14,2) == "1F")
						_idLectores.Add(id); 
			}
			return codes.Count;
		}


		/// <summary>
		/// ReadIButton
		/// </summary>
		/// <param name="IDRom"></param>
		/// <param name="datos"></param>
		/// <returns></returns>
		public bool ReadIButton(string IDRom, Result datos) {
			
			short[] ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
			for (int i=7; i>=0; i--) {
				short hex = (short)  Encripcion.HexToDec(IDRom.Substring(i*2,2));
				ROM[7-i] = hex;
			}
			OpenAllMainSwitch(); //ABRE TODOS LOS SWITCHES
			
			bool state=SetStateMainSwitch(IDRom,MainSwicthState.Close); //CIERRA CIRCUITO DEL SWITCH A LEER
			if (state) {
				short ret = TMRom(_hSess, _stateBuffer, ROM);
				if ( ret==1 ) {
					ret=TMFirst(_hSess, _stateBuffer);
					if( ret==1 ) {
						ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
						ret = TMRom(_hSess, _stateBuffer, ROM);
						if (ret == 1) {
							//ret = TMStrongAccess(_hSess, _stateBuffer); //4.ACCESSO AL BOTON Y SELECCIONADO
							byte[] info = new byte [118];
							//if (ret==1) //5.LECTURA DEL BOTON
							//{
							char [] buf = new char[32];
							for(int i=0;i<32;i++)
								buf[i]='0';
							ret = TMReadPacket(_hSess,_stateBuffer,0,info,118);
							info[117]=0;
							datos.SetMensaje("");
							datos.SetData(info);
							string idRomButton="";
							for (int i=7;i>=0;i--)
								idRomButton += ROM[i].ToString("X2");
							datos.SetROM(idRomButton);
							//ABRE TODOS LOS SWITECH
							SetStateMainSwitch(IDRom,MainSwicthState.Open);
							state = true;
							//}
							//else
							//state = false;
						}
					}else{
						state =  false;
					}
				}else{
					state =  false;
				}
			}else{
				state = false;
			}
			return state;
		}


		/// <summary>
		/// ReadIButtonPages
		/// </summary>
		/// <param name="idRomLector"></param>
		/// <param name="datos"></param>
		/// <returns></returns>
		public bool ReadIButtonPages(string idRomLector, Result datos ) {
			byte [] infoButton = new byte[256];
			short[] ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
			
			for (int i=7; i>=0; i--) {
				short hex = (short)  Encripcion.HexToDec(idRomLector.Substring(i*2,2));
				ROM[7-i] = hex;							
			}
			OpenAllMainSwitch(); //ABRE TODOS LOS SWITECH
			bool state=SetStateMainSwitch(idRomLector,MainSwicthState.Close);//CIERRA CIRCUITO DEL SWITCH A LEER
			if (state) {
				short ret = TMRom(_hSess, _stateBuffer, ROM);
				if ( ret==1 ) {
					ret=TMFirst(_hSess, _stateBuffer);
					if( ret==1 ) {
						ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
						ret = TMRom(_hSess, _stateBuffer, ROM);
						if (ret == 1 && ROM[0] != 0x09 ) {
							string idRomButton="";
							for (int i=7;i>=0;i--)
								idRomButton += ROM[i].ToString("X2");

							//ret = TMStrongAccess(_hSess, _stateBuffer); //4.ACCESSO AL BOTON Y SELECCIONADO
							for (int i=0; i < (128 / 32) ; i++ ) { //4paginas
								byte[] data = new byte[32] ;
								ReadPage(i, data, 32);
								data.CopyTo(infoButton,i * 32);
							}
							datos.SetData(infoButton);
							datos.SetROM(idRomButton) ; 
							//datos.SetROM(idRomLector);
							//ABRE TODOS LOS SWITECH
							SetStateMainSwitch(idRomLector,MainSwicthState.Open);
							state = true;
							//}
							//else
							//state = false;
						}else{
							state = false;
						}
					}else{
						state =  false;
					}
				}else{
					state =  false;
				}
			}else{
				state = false;
			}
			return state;
		}
	

		/// <summary>
		/// WriteButtonPages
		/// </summary>
		/// <param name="idRomLector"></param>
		/// <param name="datos"></param>
		/// <returns></returns>
		public bool WriteButtonPages(string idRomLector, string datos) {

			short[] ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
			byte[] datosWrite = new byte[32] ; 
			for (int i=7; i>=0; i--) {
				short hex = (short)  Encripcion.HexToDec(idRomLector.Substring(i*2,2));
				ROM[7-i] = hex;
			}
			OpenAllMainSwitch(); //ABRE TODOS LOS SWITECH
			
			bool state=SetStateMainSwitch(idRomLector,MainSwicthState.Close);//CIERRA CIRCUITO DEL SWITCH A LEER
			if (state) {
				short ret = TMRom(_hSess, _stateBuffer, ROM);
				if ( ret==1 ) {
					ret=TMFirst(_hSess, _stateBuffer);
					if( ret==1 ) {
						ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
						ret = TMRom(_hSess, _stateBuffer, ROM);
						if (ret == 1) {
							int npag = 0 ;
							int nbytes = 0 ;
							char[] arraycar = new char[128] ;
							arraycar = datos.ToCharArray() ; 
							//ret = TMStrongAccess(_hSess, _stateBuffer); //4.ACCESSO AL BOTON Y SELECCIONADO
						
							for (int i=0; i < datos.Length  ; i++ ) { //4paginas
								datosWrite[nbytes++] = (byte)arraycar[i] ;		
								if ( nbytes >= 32) {
									WritePage(npag, datosWrite, 32);
									npag ++ ;
									nbytes = 0 ;
								}								
							
							}
							if (nbytes > 0)
								WritePage(npag, datosWrite, nbytes);

							//ABRE TODOS LOS SWITECH
							SetStateMainSwitch(idRomLector,MainSwicthState.Open);
							state = true;
							//}
							//else
							//state = false;
						}
					}else{
						state =  false;
					}
				}else{
					state =  false;
				}
			}else{
				state = false;
			}
			return state;
		}
				

		/// <summary>
		/// GetFamily
		/// </summary>
		/// <param name="IDRom"></param>
		/// <returns></returns>
		public static String GetFamily(String IDRom) {
			String family = null;
			if (IDRom.Length > 2)
				family = IDRom.Substring(IDRom.Length -2, 2);
			return family;
		}

		/// <summary>
		/// Is9097: Verifies if device is DS9097
		/// </summary>
		/// <param name="IdRom">IdRom to Verify</param>
		/// <returns>true/false</returns>
		public static bool Is9097(String IdRom){
			if ("09".CompareTo(GetFamily(IdRom)) == 0){
				return true;
			}
			return false;
		}

		/// <summary>
		/// Is2409: Verifies if device is 2409
		/// </summary>
		/// <param name="IdRom">IdRom to Verify</param>
		/// <returns>true/false</returns>
		public static bool Is2409(String IdRom){
			if ("1F".CompareTo(GetFamily(IdRom)) == 0){
				return true;
			}
			return false;
		}

		
		/// <summary>
		/// OpenAllMainSwitch
		/// </summary>
		public void OpenAllMainSwitch() {
			foreach (string idLector in _idLectores)
				SetStateMainSwitch(idLector,MainSwicthState.Open);
		}


		/// <summary>
		/// OpenMainSwitch: Abre todos los switches de la red para confirmar que no queden botones pegados
		/// </summary>
		public void OpenMainSwitch(string idRomLector) {
			short[] ROM = new short[8] {0, 0, 0, 0, 0, 0, 0, 0};
			for (int i=7; i>=0; i--) {
				short hex = (short)  Encripcion.HexToDec(idRomLector.Substring(i*2,2));
				ROM[7-i] = hex;
			}
			TMRom(_hSess, _stateBuffer, ROM);
			if (GetFamily(idRomLector) == "1F") {
				SetStateMainSwitch(idRomLector,MainSwicthState.Open);
			}
		}
		

		/// <summary>
		/// DeviceExist: VERIFICA SI EXISTE UN IDROM EN LA RED
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeviceExist(String id) {
			short ret=TMFirst(_hSess, _stateBuffer);
			while ( (ret==1)  ) {
				// if MSB of ROM[0] != 0, then write, else read
				short[] ROM = new short [8] {0, 0, 0, 0, 0, 0, 0, 0};
				TMRom(_hSess, _stateBuffer, ROM);

				byte  s  ;
				String romCode="";
				for (int i=7; i>=0; i--) {
					s = (byte)ROM[i];
					romCode+=s.ToString("X2");
				}
				if (id == romCode)
					return true;

				ret=TMNext(_hSess, _stateBuffer);
			}
			return false;
		}


		/// <summary>
		/// Close
		/// </summary>
		/// <returns></returns>
		public bool Close() {
			EndSession();	
			return true;
		}

		
		#endregion
		
		#region IDisposable Members
		/// <summary>
		/// Dispose
		/// </summary>
		public void Dispose() {
			EndSession();
		}

		#endregion
	}

	#endregion

	#region Result Class

	/// <summary>
	/// Result Class
	/// </summary>
	public class Result {
		
		#region Declarations
		private byte[] data;
		private String  mensaje;
		private String  ROM;
		#endregion

		#region constructors
		/// <summary>
		/// Constructor
		/// </summary>
		public Result() {}
        
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data"></param>
		/// <param name="mensaje"></param>
		/// <param name="ROM"></param>
		public Result(byte [] data, String mensaje, String ROM) {
			this.ROM = ROM;
			this.data = data;
			this.mensaje = mensaje;
		}

		
		#endregion

		#region Methods
		/// <summary>
		/// GetMensaje
		/// </summary>
		/// <returns></returns>
		public String GetMensaje() {
			return mensaje;
		}

	
		/// <summary>
		/// GetROM
		/// </summary>
		/// <returns></returns>
		public String GetROM() {
			return ROM;
		}


		/// <summary>
		/// SetROM
		/// </summary>
		/// <param name="ROM"></param>
		public void SetROM(String ROM) {
			this.ROM = ROM;
		}


		/// <summary>
		/// GetData
		/// </summary>
		/// <returns></returns>
		public byte[] GetData() {
			return data;
		}


		/// <summary>
		/// SetMensaje
		/// </summary>
		/// <param name="mensaje"></param>
		public void SetMensaje(String mensaje) {
			this.mensaje = mensaje;
		}


		/// <summary>
		/// SetData
		/// </summary>
		/// <param name="data"></param>
		public void SetData(byte[] data) {
			this.data = data;
		}		
	

		#endregion
	}
	#endregion
}
