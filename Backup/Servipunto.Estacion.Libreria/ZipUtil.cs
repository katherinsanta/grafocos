//------------------------------------------------------------------------------
// ZipUtil                                                           
// utilidad para comprimir/descomprimir ficheros zips
// usando SharpZipLib.dll
//
//------------------------------------------------------------------------------
using System;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.IO;


namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Descripción breve de ZipUtil.
	/// </summary>
	public class ZipUtil
	{
		public void Comprimir(string directorio, string filtro, string zipFic, bool crearAuto)
		{
			// comprimir los ficheros del directorio indicado
			// y guardarlo en el zip
			// en filtro se indicará el filtro a usar para seleccionar los ficheros del directorio
			// si directorio es una cadena vacía, filtro será el fichero a comprimir (sólo ese)
			// si crearAuto = True, zipfile será el directorio en el que se guardará
			// y se generará automáticamente el nombre con la fecha y hora actual
			//
			string[] fileNames = new string[1];
			if(directorio == "")
			{
				fileNames[0] = filtro;
			}
			else
			{
				fileNames = Directory.GetFiles(directorio, filtro);
			}
			// llamar a la versión sobrecargada que recibe un array
			Comprimir(fileNames, zipFic, crearAuto);
			//
		}  
		//
		public void Comprimir(string[] fileNames, string zipFic, bool crearAuto)
		{
			// comprimir los ficheros del array en el zip indicado
			// si crearAuto = True, zipfile será el directorio en el que se guardará
			// y se generará automáticamente el nombre con la fecha y hora actual
			Crc32 objCrc32 = new  Crc32();
			ZipOutputStream strmZipOutputStream;
			//
			if( zipFic == "" )
			{
				zipFic = ".";
				crearAuto = true;
			}
			if( crearAuto )
			{
				// si hay que crear el nombre del fichero
				// éste será el path indicado y la fecha actual
				zipFic += @"\ZIP" + DateTime.Now.ToString("yyMMddHHmmss") + ".zip";
			}
			strmZipOutputStream = new ZipOutputStream(File.Create(zipFic));
			// Compression Level: 0-9
			// 0: no(Compression)
			// 9: maximum compression
			strmZipOutputStream.SetLevel(6);
			//
			foreach(string strFile in fileNames)
			{
				FileStream strmFile = File.OpenRead(strFile);
				byte[] abyBuffer = new byte[(Convert.ToInt32(strmFile.Length))];
				//
				strmFile.Read(abyBuffer, 0, abyBuffer.Length);
				//
				//              //-------------------------------------------------------------
				//              // para guardar sin el primer path
				//              string sFile = strFile;
				//              int i = sFile.IndexOf(@"\");
				//              if( i > -1)
				//              {
				//                  sFile = sFile.Substring(i + 1).TrimStart();
				//              }
				//              //-------------------------------------------------------------
				//              //
				//              //-------------------------------------------------------------
				//              // para guardar sólo el nombre del fichero
				//              // esto sólo se debe hacer si no se procesan directorios
				//              // que puedan contener nombres repetidos
				string sFile = Path.GetFileName(strFile);
				ZipEntry theEntry = new ZipEntry(sFile);
				//              //-------------------------------------------------------------
				//
				// se guarda con el path completo
				//ZipEntry theEntry  = new ZipEntry(strFile);
				//
				// guardar la fecha y hora de la última modificación
				FileInfo fi = new FileInfo(strFile);
				theEntry.DateTime = fi.LastWriteTime;
				//theEntry.DateTime = DateTime.Now;
				//
				theEntry.Size = strmFile.Length;
				strmFile.Close();
				objCrc32.Reset();
				objCrc32.Update(abyBuffer);
				theEntry.Crc = objCrc32.Value;
				strmZipOutputStream.PutNextEntry(theEntry);
				strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length);
			}
			strmZipOutputStream.Finish();
			strmZipOutputStream.Close();
		}  
		//
		public void Descomprimir(string directorio, string zipFic, bool eliminar, bool renombrar)
		{
			// descomprimir el contenido de zipFic en el directorio indicado.
			// si zipFic no tiene la extensión .zip, se entenderá que es un directorio y
			// se procesará el primer fichero .zip de ese directorio.
			// si eliminar es True se eliminará ese fichero zip después de descomprimirlo.
			// si renombrar es True se añadirá al final .descomprimido
			string Directorio = directorio;
			if( !zipFic.ToLower().EndsWith(".zip") )
			{
				zipFic = Directory.GetFiles(zipFic, "*.zip")[0];
			}
			// si no se ha indicado el directorio, usar el actual
			if( directorio == "" ) directorio = ".";
			//
			ZipInputStream z = new  ZipInputStream(File.OpenRead(zipFic));
			ZipEntry theEntry;
			//
			do
			{
				theEntry = z.GetNextEntry();
				if( !(theEntry == null) )
				{
					string fileName ;
					if (theEntry.IsDirectory)
					{
						//Directory.CreateDirectory(directorio + @"\" + Path.GetFileNameWithoutExtension(zipFic));
						theEntry = z.GetNextEntry();
						//Directorio = directorio + @"\" + Path.GetFileNameWithoutExtension(zipFic);
					}
					fileName = directorio + @"\" + Path.GetFileName(theEntry.Name);
					//
					// dará error si no existe el path
					FileStream streamWriter;
					try
					{
						streamWriter = File.Create(fileName);
					}
					catch (DirectoryNotFoundException ex)
					{
						Directory.CreateDirectory(Path.GetDirectoryName(fileName));
						streamWriter = File.Create(fileName);
						throw new Exception(ex.Message);
					}
					//
					int size = 2048;
					byte[] data = new byte[2048];
					do
					{
						size = z.Read(data, 0, data.Length);
						if( (size > 0) )
						{
							streamWriter.Write(data, 0, size);
						}
						else
						{
							break;
						}
					}while(true);
					streamWriter.Close();
				}
				else
				{
					break;
				}
			}while(true);
			z.Close();
			//
			// cuando se hayan extraído los ficheros, renombrarlo
			if( renombrar )
			{
				File.Copy(zipFic, zipFic + ".descomprimido");
			}
			if( eliminar )
			{
				File.Delete(zipFic);
			}

		}  
		//
		public ZipEntry[] Contenido(string zipFic)
		{
			// devuelve el contenido del zip indicado
			ZipInputStream strmZipInputStream = new ZipInputStream(File.OpenRead(zipFic));
			ZipEntry objEntry;
			ZipEntry[] files = new ZipEntry[1];
			int n  = -1;
			//
			while ((objEntry = strmZipInputStream.GetNextEntry()) != null)
			{
				n = n + 1;
				// hacer una copia de files
				// para añadir el nuevo elemento
				// ¡con lo fácil que es usar ReDim Preserve!
				if(n > 0)
				{
					ZipEntry[] files2 = new ZipEntry[n + 1];
					Array.Copy(files, files2, n);
					files2[n] = objEntry;
					files = new ZipEntry[n + 1];
					Array.Copy(files2, files, n + 1);
					files2 = null;
				}
				else
				{
					files[0] = objEntry;
				}
			}
			strmZipInputStream.Close();
			//
			return files;
		}  
	}
}
