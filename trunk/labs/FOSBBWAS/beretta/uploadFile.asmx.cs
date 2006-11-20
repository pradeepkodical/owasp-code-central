using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using Microsoft.Web.Services2;
using Microsoft.Web.Services2.Dime;
using System.IO;
using sourceControl.support;

namespace sourceControl
{
	/// <summary>
	/// Summary description for uploadFile.
	/// </summary>
	public class uploadFile : System.Web.Services.WebService
	{
		protected user objUser=new user();
		protected int intUserId=0;
		protected string strCurrentPath="";

		public uploadFile()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		

		[WebMethod]
		public string getAllFileStatus(string strUsername, string strPassword, string strProjectName)
		{
			bool bolDoesFileExistAlready=false;
			string strNewFileName="";
			string strTmpXmlLine="";
			string strXmlDoc="";
			string strPath="";

			DataSet objDataSet=new DataSet();

			if (login(strUsername, strPassword, strProjectName)==false)
			{
				return "FAILEDLOGIN";
			}

			objDataSet=fileDataAccess.getAllForStatus(0);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{

				strPath="" + objDataRow["path"].ToString().Replace(objUser.serverDir, objUser.clientDir); 

				strTmpXmlLine = strTmpXmlLine + "<fileLine>";
				strTmpXmlLine = strTmpXmlLine + "<id>" + objDataRow["id"].ToString() + "</id>";
				strTmpXmlLine = strTmpXmlLine + "<path>" + strPath + "</path>";
				strTmpXmlLine = strTmpXmlLine + "<status>" + objDataRow["status"].ToString() + "</status>";
				strTmpXmlLine = strTmpXmlLine + "<userId>" + objDataRow["userId"].ToString() + "</userId>";
				strTmpXmlLine = strTmpXmlLine + "</fileLine>";

				strXmlDoc=strXmlDoc + strTmpXmlLine;
				strTmpXmlLine="";
			}

			return "<files>" + strXmlDoc + "</files>";

		}

	

		/// <summary>
		/// Uploads a file
		/// </summary>
		/// <param name="filename">Name of file uploaded</param>
		/// <param name="strDirectory">Directory to save to</param>
		/// <param name="strUsername">username</param>
		/// <param name="strPassword">Password</param>
		/// <returns></returns>
		[WebMethod]
		public string upload(string filename, string strDirectory, string strUsername, string strPassword, string strProjectName, string strUploadType)
		{

			bool bolDoesFileExistAlready=false;
			string strNewFileName="";
			string strTmp="";
			string strExtension="";

			int intDirId=0;
			int intFileId=0;
			
			if (login(strUsername, strPassword, strProjectName)==false)
			{
				return "FAILEDLOGIN";
			}

			strCurrentPath=strDirectory.Replace(objUser.clientDir, objUser.serverDir);
			
			System.IO.DirectoryInfo objDirInfo=new DirectoryInfo(strCurrentPath);

			if (objDirInfo.Exists==false)
			{
				objDirInfo.Create();
				systemEventsDataAccess.add(3, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
				
				//TODO Does dir exist?
				//Take path off end and search for ID

				try
				{
					System.IO.DirectoryInfo objParentDirInfo=new DirectoryInfo(objDirInfo.Parent.FullName);
					intDirId=fileDataAccess.files_getDirId(objParentDirInfo.FullName);
				}
				catch
				{
				}

				intDirId=fileDataAccess.add(intDirId, objUser.projectId, strCurrentPath, "", "0", 0, objUser.id, 0, 0, 0, 0, "");
			
			}
			else
			{
				intDirId=fileDataAccess.files_getDirId(strCurrentPath);
			}
			
			strCurrentPath=strCurrentPath + "\\" + filename;
			
					
			
			System.IO.FileInfo objFileInfo=new FileInfo(strCurrentPath);
			
			try
			{
				if (File.Exists(strCurrentPath)==true)
				{

					try
					{
						strNewFileName="" + System.Guid.NewGuid()  + objFileInfo.Extension;
						File.Copy(strCurrentPath, objUser.serverDir + "\\archive\\" + strNewFileName);
						fileDataAccess.fileHistory_insert(objUser.projectId, strCurrentPath, "" + objUser.serverDir + "archive\\" +  strNewFileName, objUser.id);
					}
					catch(System.Exception ex)
					{
						 strTmp="" + ex.Message;
					}

					File.Delete(strCurrentPath);
					bolDoesFileExistAlready=true;
				}
				else
				{
					bolDoesFileExistAlready=false;
				}

				
				
			}
			catch(System.Exception ex)
			{
			}

			FileStream fs = File.Create(strCurrentPath);

			Int32 fileLength= System.Convert.ToInt32(RequestSoapContext.Current.Attachments[0].Stream.Length);
			Byte[] buffer=new byte[fileLength];
			
			RequestSoapContext.Current.Attachments[0].Stream.Read(buffer, 0, fileLength);
			fs.Write(buffer, 0, fileLength);
			fs.Close();

			if(strUploadType=="CHECKIN")
			{
				if (bolDoesFileExistAlready==true)
				{
					//Is the file checked out to this user
					if (fileDataAccess.isFileCheckedOutToCurrentUser(strCurrentPath, 0, objUser.id)==true)
					{
						fileDataAccess.updateStatus(strCurrentPath, 0, 0, objUser.id);

						systemEventsDataAccess.add(4, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
		
					}
					else
					{
						systemEventsDataAccess.add(9, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
		
						throw new Exception("File is not checked out to current user");
					}
				}
				else
				{
					//This is the newly created file
					intFileId=fileDataAccess.add(intDirId, objUser.projectId, strCurrentPath, objFileInfo.Extension.Replace(".", ""), fs.Length.ToString(), 0, objUser.id, 1, 0, 0, 0, ""); 
				}
				

			}

			return "SUCCESS";
		}



		[WebMethod]
		public string undoCheckOut(string filename, string strDirectory, string strUsername, string strPassword, string strProjectName, string strUploadType)
		{

			if (login(strUsername, strPassword, strProjectName)==false)
			{
				return "FAILEDLOGIN";
			}

			strCurrentPath=strDirectory.Replace(objUser.clientDir, objUser.serverDir);
			strCurrentPath=strCurrentPath + "\\" + filename;

			//Is the file checked out to this user
			if (fileDataAccess.isFileCheckedOutToCurrentUser(strCurrentPath, 0, objUser.id)==true)
			{
				fileDataAccess.updateStatus(strCurrentPath, 0, 0, objUser.id);

				systemEventsDataAccess.add(6, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
		
			}
			else
			{
				systemEventsDataAccess.add(9, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
		
				throw new Exception("File is not checked out to current user");
			}
					

			return "SUCCESS";

			
		}

		/// <summary>
		/// Downloads a file
		/// </summary>
		/// <param name="strFullPath">Path of file to download</param>
		/// <param name="strUsername">Username</param>
		/// <param name="strPassword">Password</param>
		/// <returns></returns>
		[WebMethod]
		public string download(string strFullPath, string strUsername, string strPassword, string strProjectName, string strDownloadType)
		{
			if (login(strUsername, strPassword, strProjectName)==false)
			{
				return "FAILEDLOGIN";
			}

			strCurrentPath=strFullPath.Replace(objUser.clientDir, objUser.serverDir);
		
			System.IO.FileStream fleReader = new FileStream(strCurrentPath, FileMode.Open, FileAccess.Read);
        
			StreamReader stmReader = new StreamReader(fleReader);
			System.Text.StringBuilder lstChars = new System.Text.StringBuilder();

			int iChar = stmReader.Read();
			lstChars.Append(Convert.ToChar(iChar));

			while(stmReader.Peek() >= 0)
			{
				iChar = stmReader.Read();
				lstChars.Append(Convert.ToChar(iChar));	
			}

			stmReader.Close();

			if (strDownloadType=="GETLATEST")
			{
				systemEventsDataAccess.add(7, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
		
			}
			else if (strDownloadType=="CHECKOUT")
			{
				if (fileDataAccess.getFileStatus(strCurrentPath, 0)==0)
				{
					fileDataAccess.updateStatus(strCurrentPath, 1, 0, objUser.id);
					systemEventsDataAccess.add(5, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
		
				}
				else
				{
					systemEventsDataAccess.add(8, strCurrentPath, objUser.id, HttpContext.Current.Request.UserHostAddress);
		
					throw new Exception("File is checked out to another user");
				}
			}


			return lstChars.ToString();
		}


		/// <summary>
		/// Returns all files in directory set by strFullPath
		/// </summary>
		/// <param name="strFullPath">Current Level to return all child files</param>
		/// <param name="strUsername">Username</param>
		/// <param name="strPassword">Password</param>
		/// <returns></returns>
		[WebMethod]
		public string getAllFilesInDir(string strFullPath, string strUsername, string strPassword, string strProjectName)
		{
			if (login(strUsername, strPassword, strProjectName)==false)
			{
				return "FAILEDLOGIN";
			}

			string strTmp="";

			strCurrentPath=strFullPath.Replace(objUser.clientDir, objUser.serverDir) + "\\";
		
			System.IO.DirectoryInfo objDirInfo=new DirectoryInfo(strCurrentPath);


			foreach(System.IO.FileInfo objTmpFileInfo in objDirInfo.GetFiles())
			{

				strTmp=strTmp + objTmpFileInfo.FullName.Replace(objUser.serverDir, objUser.clientDir) + "#";

			}

			return strTmp;
		}

		
		/// <summary>
		/// For testing web service connection
		/// </summary>
		/// <returns></returns>
		[WebMethod]	
		public string ping()
		{
			return "SUCCESS";

		}
		
/// <summary>
/// For testing settings
/// </summary>
/// <param name="strUsername"></param>
/// <param name="strPassword"></param>
/// <param name="strProjectName"></param>
/// <returns></returns>
		[WebMethod]	
		public string testSettings(string strUsername, string strPassword, string strProjectName)
		{

			try
			{
				if (login(strUsername, strPassword, strProjectName)==false)
				{
					return "FAILEDLOGIN";
				}

				return "SUCCESS";
			}
			catch(System.Exception ex)
			{
				return "Login incorrect " + ex.Message;
			}

		}
		
		
		/// <summary>
		/// Gets a list of directories at current level set by strFullPath
		/// </summary>
		/// <param name="strFullPath">Current Level to return child directories</param>
		/// <param name="strUsername">Username</param>
		/// <param name="strPassword">Password</param>
		/// <returns></returns>
		[WebMethod]	
		public string getAllInnerDirs(string strFullPath, string strUsername, string strPassword, string strProjectName)
		{
			if (login(strUsername, strPassword, strProjectName)==false)
			{
				return "FAILEDLOGIN";
			}

			string strTmp="";

			strCurrentPath=strFullPath.Replace(objUser.clientDir, objUser.serverDir) + "\\";
		
			System.IO.DirectoryInfo objDirInfo=new DirectoryInfo(strCurrentPath);


			foreach(System.IO.DirectoryInfo objChildDirInfo in objDirInfo.GetDirectories())
			{
				if(objChildDirInfo.Name!="archive")
				{
					strTmp=strTmp + objChildDirInfo.FullName.Replace(objUser.serverDir,objUser.clientDir)  + "#";
				}
			}

			return strTmp;

		}

	
		private bool login(string strUsername, string strPassword, string strProjectName)
		{
			intUserId=security.login(strUsername, strPassword);
			
			if (intUserId==0)
			{
				systemEventsDataAccess.add(1, strUsername, objUser.id, HttpContext.Current.Request.UserHostAddress);
				return false;
			}
			else
			{
				objUser.id=intUserId;
				objUser.projectShortName="" + strProjectName;
				objUser.populate();

				return true;
			}

		}

		
	}
}
