/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: Common Encryption Functions
 */

using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace devCafe.framework
{
	/// <summary>
	/// Summary description for encryption.
	/// </summary>
	public class encryption
	{
		public encryption()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Triple DES Descrypt
		/// </summary>
		/// <param name="input">String to decrypt</param>
		/// <param name="key">Encryption Key</param>
		/// <returns></returns>
		public static string Decrypt(string input, string key) 
		{
			TripleDESCryptoServiceProvider crp =new TripleDESCryptoServiceProvider();
			System.Text.UnicodeEncoding uEncode = new UnicodeEncoding();
			System.Text.ASCIIEncoding aEncode =new ASCIIEncoding();

			Byte[] bytCipherText = System.Convert.FromBase64String(input);
			MemoryStream stmPlainText =new MemoryStream();
			MemoryStream stmCipherText = new MemoryStream(bytCipherText);

			Byte[] slt= {0x12};

			PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, slt);
			Byte[] bytDerivedKey = pdb.GetBytes(24);
			crp.Key = bytDerivedKey;

			crp.IV = pdb.GetBytes(8);
			CryptoStream csDecrypted = new CryptoStream(stmCipherText, crp.CreateDecryptor(), CryptoStreamMode.Read);

			StreamWriter sw = new StreamWriter(stmPlainText);
			StreamReader sr = new StreamReader(csDecrypted);
			sw.Write(sr.ReadToEnd());

			sw.Flush();

			crp.Clear();

			return uEncode.GetString(stmPlainText.ToArray());
		}

		/// <summary>
		/// Triple DES Byte Decrypt
		/// </summary>
		/// <param name="input">Input Bytes</param>
		/// <param name="key">Encryption Key</param>
		/// <returns></returns>
		public static byte[] DecryptBytes(Byte[] input, string key) 
		{
			TripleDESCryptoServiceProvider crp =new TripleDESCryptoServiceProvider();
			System.Text.UnicodeEncoding uEncode = new UnicodeEncoding();
			System.Text.ASCIIEncoding aEncode =new ASCIIEncoding();

			Byte[] bytCipherText = input;
			MemoryStream stmPlainText =new MemoryStream();
			MemoryStream stmCipherText = new MemoryStream(bytCipherText);

			Byte[] slt= {0x12};

			PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, slt);
			Byte[] bytDerivedKey = pdb.GetBytes(24);
			crp.Key = bytDerivedKey;

			crp.IV = pdb.GetBytes(8);
			CryptoStream csDecrypted = new CryptoStream(stmCipherText, crp.CreateDecryptor(), CryptoStreamMode.Read);

			StreamWriter sw = new StreamWriter(stmPlainText);
			StreamReader sr = new StreamReader(csDecrypted);
			sw.Write(sr.ReadToEnd());

			sw.Flush();

			crp.Clear();

			return (stmPlainText.ToArray());
		}

		/// <summary>
		/// Triple DES decrypt
		/// </summary>
		/// <param name="input">String to Encrypt</param>
		/// <param name="key">Encryption Key</param>
		/// <returns></returns>
		public static string Encrypt(string input, string key)
		{
			TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
			System.Text.UnicodeEncoding uEncode = new System.Text.UnicodeEncoding();
			System.Text.ASCIIEncoding aEncode = new System.Text.ASCIIEncoding();

			Byte[] bytPlainText= uEncode.GetBytes(input);
			MemoryStream stmCipherText= new MemoryStream();

			Byte[] slt= {0x12};
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, slt);
			Byte[] bytDerivedKey= pdb.GetBytes(24);
			crp.Key = bytDerivedKey;
			crp.IV = pdb.GetBytes(8);
			CryptoStream csEncrypted = new CryptoStream(stmCipherText, crp.CreateEncryptor(), CryptoStreamMode.Write);

			csEncrypted.Write(bytPlainText, 0, bytPlainText.Length);
			csEncrypted.FlushFinalBlock();

			return System.Convert.ToBase64String(stmCipherText.ToArray());
		}


		/// <summary>
		/// Triple DES Encrypt Bytes
		/// </summary>
		/// <param name="input">Bytes to input</param>
		/// <param name="key">Encryption Key</param>
		/// <returns></returns>
		public static byte[] EncryptBytes(byte[] input, string key)
		{
			TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
			System.Text.UnicodeEncoding uEncode = new System.Text.UnicodeEncoding();
			System.Text.ASCIIEncoding aEncode = new System.Text.ASCIIEncoding();

			Byte[] bytPlainText= input;
			MemoryStream stmCipherText= new MemoryStream();

			Byte[] slt= {0x12};
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, slt);
			Byte[] bytDerivedKey= pdb.GetBytes(24);
			crp.Key = bytDerivedKey;
			crp.IV = pdb.GetBytes(8);
			CryptoStream csEncrypted = new CryptoStream(stmCipherText, crp.CreateEncryptor(), CryptoStreamMode.Write);

			csEncrypted.Write(bytPlainText, 0, bytPlainText.Length);
			csEncrypted.FlushFinalBlock();

			return stmCipherText.ToArray();
		}

		public static string hashMD5(string strPlain) 
		{
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			MD5 md5 = new MD5CryptoServiceProvider();
			string strHex = "";
			
			HashValue = md5.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) 
			{
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		}

		public static string hashMD5Bytes(Byte[] byteArray) 
		{
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = byteArray;
			MD5 md5 = new MD5CryptoServiceProvider();
			string strHex = "";
			
			HashValue = md5.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) 
			{
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		}


		public static string hashSHA1(string strPlain) 
		{
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA1Managed SHhash = new SHA1Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) 
			{
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} 
		
		public static string hashSHA256(string strPlain) 
		{
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA256Managed SHhash = new SHA256Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) 
			{
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} 
		
		public static string hashSHA384(string strPlain) 
		{
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA384Managed SHhash = new SHA384Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) 
			{
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} 
		
		public static string hashSHA512(string strPlain) 
		{
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA512Managed SHhash = new SHA512Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) 
			{
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} 

	}
}
