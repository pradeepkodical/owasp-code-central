using System;
using System.Data;

namespace beretta.Objects
{
	/// <summary>
	/// Class used to log application scan on. Raw logon allows the user to configure a raw html form submission to log the application on.
	/// </summary>
	public class sessionRawLogon
	{
		private int mId;
		private int mSessionId;
		private string mLoginPageUrl;
		private string mRawSubmission;

		#region Class Accessor Values

		public int id
		{
			get{return mId;}
			set{mId=value;}
		}

		public int sessionId
		{
			get{return mSessionId;}
			set{mSessionId=value;}
		}

		public string loginPageUrl
		{
			get{return mLoginPageUrl;}
			set{mLoginPageUrl=value;}
		}

		public string rawSubmission
		{
			get{return mRawSubmission;}
			set{mRawSubmission=value;}
		}

		#endregion

		public sessionRawLogon()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{

			sessionRawLogonDataAccess.add(mSessionId, mLoginPageUrl, mRawSubmission);

		}

		public void deleteBySessionId()
		{
			sessionRawLogonDataAccess.deleteBySessionId(mSessionId);
		}

		public void populateBySessionId()
		{

			DataSet objDataSet=new DataSet();
			objDataSet=sessionRawLogonDataAccess.getDetailBySessionId(mSessionId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mSessionId=System.Convert.ToInt32(objDataRow["sessionId"]);
				mLoginPageUrl=System.Convert.ToString(objDataRow["loginPageUrl"]);
				mRawSubmission=System.Convert.ToString(objDataRow["rawSubmission"]);

			}
		}
	}
}
