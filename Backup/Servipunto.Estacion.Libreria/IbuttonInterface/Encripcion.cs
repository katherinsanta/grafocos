using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections;


namespace Servipunto.Estacion.Libreria.IbuttonInterface
{

	#region Encripcion class
	/// <summary>
	/// Summary description for Encripcion.
	/// </summary>
	public class Encripcion {
		#region Methods

			/// <summary>
			/// Retorna la cadena encriptada en hexadecimal
			/// </summary>
			/// <param name="datos"></param>
			/// <param name="llave"></param>
			/// <returns></returns>
			public static string Encryptar(string datos, string llave) {
				string KEY = "", IV="";
				GenerarKEYIV(llave,ref KEY, ref IV);
				return Encryptar(datos,KEY,IV);
			}

	
			/// <summary>
			/// Convierte de String a Hexa
			/// </summary>
			/// <param name="dato"></param>
			/// <returns></returns>
			public static string StringToHexa(string dato) {
				dato = dato.Trim();
				if (dato == null || dato.Length == 0)
					return "";
				string hexaString="";
				foreach (char c in dato) {
					hexaString +=  byteToHexa(c);
				}
				return hexaString.Substring(0,hexaString.Length-1);
			}

			private struct CHexMap {
				public char chr;
				public int value;

				public CHexMap(char c, int v) {
					chr = c;
					value = v;
				}

			};

			/// <summary>
			/// Convierte un caracter a su representacion en dos bytes hexadecimales
			/// </summary>
			/// <param name="c"></param>
			/// <returns></returns>
			public static string byteToHexa(char c) {
				return byteToHexa((byte)c);
			}


			/// <summary>
			/// Convierte un caracter a su representacion en dos bytes hexadecimales
			/// </summary>
			/// <param name="c"></param>
			/// <returns></returns>
			public static string byteToHexa(byte c) {
				CHexMap[] hexBase = new CHexMap[16] {new CHexMap('0',0),
														new CHexMap('1',1),
														new CHexMap('2',2),
														new CHexMap('3',2),
														new CHexMap('4',3),
														new CHexMap('5',4),
														new CHexMap('6',5),
														new CHexMap('7',6),
														new CHexMap('8',7),
														new CHexMap('9',8),
														new CHexMap('A',9),
														new CHexMap('B',10),
														new CHexMap('C',11),
														new CHexMap('D',12),
														new CHexMap('E',13),
														new CHexMap('F',14)};
				int b =0; 
				string p1="", p2="";
				b = (byte) c;
				b = b % 16;
				p2 = hexBase[b].chr.ToString();
				b = (byte) c;
				b >>=4;
				p1 = hexBase[b].chr.ToString();
				return p1 + p2;
			}


			/// <summary>
			/// Convierte todos los caracteres de una cadena en la que cada dos caracteres respresentan
			/// un numero haxadecimal a su caracter ASCII corespondiente ej:
			/// 414C5A => ALZ
			/// </summary>
			/// <param name="dato"></param>
			/// <returns></returns>
			public static string HexaToString(string dato) {
				string result="";
				if (dato == null || dato.Trim().Length == 0)
					return "";
				dato = dato.Trim();
				int i=0;
				for( i=0;i < dato.Length ;i+=2) {
					result += ((char)HexToDec(dato.Substring(i ,2))).ToString();
				}
				return result;
			}


			/// <summary>
			/// Retorna el numero correspondiente en decimal de una cadena que representa 
			/// un numero en hexadecimal Ej: FF -> 255
			/// </summary>
			/// <param name="ch"></param>
			/// <returns></returns>
			public static int HexToDec(string ch) {
			
				int c = ch[0];
				int b =0;
				if ((c - 65) < 0)
					c -= 48;
				else
					c -= 55;
				b = c;
				b <<= 4;
				c = ch[1];
				if ((c - 65) < 0)  //HACE EL CALCULO BASE 10
					c -= 48;
				else			   //HACE EL CALCULO BASE 16   (CHR 65 = A)
					c -= 55;
				b += c;

				return b;
			}


			/// <summary>
			/// Desencripta la info recibida
			/// </summary>
			/// <param name="datos"></param>
			/// <param name="llave"></param>
			/// <returns></returns>
			public static string Decryptar(string datos, string llave) {
				string KEY = "", IV="";
				string result ="";
				try {
					GenerarKEYIV(llave,ref KEY, ref IV);
					result = Decryptar(datos,KEY,IV);
				}
				catch {
					result = "";
				}
				return result;
			}
			/// <summary>
			/// Encripta la informacion recibida
			/// </summary>
			/// <param name="datos">Dato a Encriptar</param>
			/// <param name="KEY"></param>
			/// <param name="IV"></param>
			/// <returns></returns>
			public static string Encryptar(string datos, string KEY, string IV) {
				byte[] key = new byte[KEY.Length];
				byte[] iv = new byte[IV.Length];
				byte[] data = new byte[datos.Length];

				int i=0;
				foreach (char c in KEY)
					key[i++] = (byte) c;
				i=0;
				foreach (char c in IV)
					iv[i++] = (byte) c;
				i=0;
				foreach (char c in datos)
					data[i++] = (byte) c;

				MemoryStream writer = new MemoryStream();
				writer.SetLength(0);

				DESCryptoServiceProvider crypto = new DESCryptoServiceProvider();
				crypto.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

				CryptoStream encStream = new CryptoStream(writer, crypto.CreateEncryptor(key, iv), CryptoStreamMode.Write);

				encStream.Write(data,0, data.Length);
				encStream.FlushFinalBlock();

				byte[] b = new byte[writer.Length];
				writer.Position = 0;
				writer.Read( b, 0, (int)writer.Length );

				encStream.Close();
				writer.Close();

				string result ="" ;
				i=0;
				foreach (char c in b)
					result += byteToHexa(c);
			
				return result;
			}

			/// <summary>
			/// Genera una Llave y un Vector de inicializacion
			/// </summary>
			/// <param name="password"></param>
			/// <param name="KEY"></param>
			/// <param name="IV"></param>
			/// <returns></returns>
			public static void GenerarKEYIV(string password, ref  string  KEY,ref string IV ) {
				IV = password;
				while ( IV.Length < 8 ) IV += password;
				IV = IV.Substring(0,8);

				ArrayList a = new ArrayList();

				foreach ( char c in password.ToCharArray() ) {
					a.Add(c);
				}

				a.Reverse();
				String output = new String((char[])a.ToArray(typeof(char)));

				KEY = output;
				while ( KEY.Length < 8 ) KEY += output;
				KEY = KEY.Substring(0,8);
			}
		
			/// <summary>
			/// Desencripta la cadena encriptada
			/// </summary>
			/// <param name="datos"></param>
			/// <param name="KEY"></param>
			/// <param name="IV"></param>
			/// <returns></returns>
			public static string  Decryptar(string datos, string KEY, string IV) {

				byte[] key = new byte[KEY.Length];
				byte[] iv = new byte[IV.Length];
				byte[] data = new byte[datos.Length];

				int i=0;
				foreach (char c in KEY)
					key[i++] = (byte) c;
				i=0;
				foreach (char c in IV)
					iv[i++] = (byte) c;
				i=0;
				foreach (char c in datos)
					data[i++] = (byte) c;

				MemoryStream writer = new MemoryStream();
				writer.SetLength(0);

				DESCryptoServiceProvider crypto = new DESCryptoServiceProvider();
				crypto.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

				CryptoStream encStream = new CryptoStream(writer, crypto.CreateDecryptor(key, iv), CryptoStreamMode.Write);

				encStream.Write(data,0, data.Length);
				encStream.FlushFinalBlock();

				writer.Position = 0; 
				byte[] b=new byte[writer.Length];
				writer.Read(b,0,b.Length);
				string result ="" ;
				i=0;
				foreach (byte c in b)
					result += (char)c;
				return result;
			}

			#endregion
	}
	#endregion

}
