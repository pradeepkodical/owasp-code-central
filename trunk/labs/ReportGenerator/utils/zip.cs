using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.Windows.Forms;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for zip.
	/// </summary>
	public class zip
	{
		public zip()
		{
		}		

		// this code snippet was based on the code from http://www.eggheadcafe.com/articles/20050821.asp
		public static void zipFolder(string strPathOfFolderToZip, string strTargetZipFileName)
		{

			//			public static void ZipIt( string Path, string outPathAndZipFile, string password)
			//			{  				
			ArrayList ar = utils.files.returnPathToAllFilesInFolder_Recursively(strPathOfFolderToZip);
			//ArrayList ar = GenerateFileList(Path);
			// generate file list
			// find number of chars to remove from orginal file path
			int TrimLength = (Directory.GetParent(strPathOfFolderToZip)).ToString().Length;
			TrimLength += 1; //remove '\'			
			FileStream ostream;
			byte[] obuffer;			
			ZipOutputStream oZipStream = new ZipOutputStream(System.IO.File.Create(strTargetZipFileName));	// create zip stream
			oZipStream.SetLevel(9);	// 9 = maximum compression level
						
			ZipEntry oZipEntry;
			foreach(string Fil in ar) // for each file, generate a zipentry
			{
				oZipEntry = new ZipEntry(Fil.Remove(0,TrimLength));
				oZipStream.PutNextEntry(oZipEntry);
				if( ! Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
				{
					ostream = File.OpenRead(Fil);
					obuffer = new byte[ostream.Length];
					// byte buffer
					ostream.Read(obuffer,0,obuffer.Length);
					oZipStream.Write(obuffer,0,obuffer.Length);
					Console.Write(".");
					ostream.Close();
				}
			}
			oZipStream.Finish();
			oZipStream.Close();
		}

		
		public static void unzipFile(string strPathOfFileToUnzip, string strTargetFolder)
		{
            ZipInputStream zisZipInputStream = new ZipInputStream(System.IO.File.Open(strPathOfFileToUnzip, FileMode.Open));	// create zip stream				
            try
            {
                ZipEntry zeItemToProcess;
                while ((zeItemToProcess = zisZipInputStream.GetNextEntry()) != null)
                {
                    string strFullPath = strTargetFolder + "\\" + zeItemToProcess.Name;
                    string strFullDirPath = Path.GetDirectoryName(strFullPath);

                    if (!Directory.Exists(strFullDirPath))
                        Directory.CreateDirectory(strFullDirPath);
                    if (strFullPath[strFullPath.Length - 1] != '/')     // means that this entrie is not a directory (this needed to be added due to changes in the zip library used)
                    {
                        try
                        {
                            FileStream fsUnzipFile = File.Create(strFullPath);
                            int iSize = 2048;
                            byte[] bData = new byte[2048];
                            while (true)
                            {
                                iSize = zisZipInputStream.Read(bData, 0, bData.Length);
                                if (iSize > 0)
                                    fsUnzipFile.Write(bData, 0, iSize);
                                else
                                    break;
                            }
                            fsUnzipFile.Close();
                        }
                        catch (Exception ex)
                        {
                            if (MessageBox.Show("Error occours while creating file (" + ex.Message + ")" + Environment.NewLine + Environment.NewLine +
                                "Do you want to ignore this file and continue (if the file is thumbs.db this is safe to do)?", "Error Message", MessageBoxButtons.YesNo) == DialogResult.No)
                                return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in unzipFile (strPathOfFileToUnzip = " + strPathOfFileToUnzip + " , strTargetFolder = " + strTargetFolder + "): " + ex.Message + "");
            }
            finally
            {
                zisZipInputStream.Close();
            }
		}

		

		public static byte[] returnZippedbyteArray(string stringToZip)
		{
			MemoryStream memStream = new MemoryStream();
			Stream compressedStream = new GZipOutputStream(memStream);
			byte[] byteArrayToZip = Encoding.UTF8.GetBytes(stringToZip.ToCharArray());
			
			compressedStream.Write(byteArrayToZip ,0,byteArrayToZip.Length);
			compressedStream.Flush();
			compressedStream.Close();
			return memStream.ToArray();
		}

		public static string returnUnZippedString(byte[] zippedByteArrayToUnzip)
		{			
			MemoryStream memStream = new MemoryStream(zippedByteArrayToUnzip);			
			GZipInputStream objGZipInputStream = new GZipInputStream(memStream);
			int totalNumberOfBytesRead = 0;
			StringWriter unZippedData = new StringWriter();
			while (true)
			{
				byte[] tempUncompressedData = new byte[65536];
				int numberOfBytesProcessed = objGZipInputStream.Read(tempUncompressedData,0,65536);								
				if (0 == numberOfBytesProcessed) break;
				unZippedData.Write(Encoding.UTF8.GetChars(tempUncompressedData));
				totalNumberOfBytesRead += numberOfBytesProcessed;				
			}			
			return unZippedData.ToString();						
		}
	}
}
