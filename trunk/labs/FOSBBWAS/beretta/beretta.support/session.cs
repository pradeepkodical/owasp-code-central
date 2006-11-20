using System;
using System.Data;

namespace beretta.Objects
{
	/// <summary>
	/// A Session instance is each application scan
	/// </summary>
	public class session
	{
		private int mId;
		private string mSessionName;
		private string mSessionDescription;
		private string mApplicationBaseUrl;
		private int mAuthenticationType;
		private int mUseAutoScan;
		private int mUserAgent;


		private sessionDataAccess objSessionDataAccess=new sessionDataAccess();

		#region Class Accessor Values
		public int id
		{
			get{return mId;}
			set{mId=value;}
		}


		public string sessionName
		{
			get{return mSessionName;}
			set{mSessionName=value;}
		}

		public string sessionDescription
		{
			get{return mSessionDescription;}
			set{mSessionDescription=value;}
		}

		public int authenticationType
		{
			get{return mAuthenticationType;}
			set{mAuthenticationType=value;}
		}

		public string applicationBaseUrl
		{
			get{return mApplicationBaseUrl;}
			set{mApplicationBaseUrl=value;}
		}

		public int useAutoScan
		{
			get{return mUseAutoScan;}
			set{mUseAutoScan=value;}
		}

		public int userAgent
		{
			get{return mUserAgent;}
			set{mUserAgent=value;}
		}

	
		#endregion


		public session()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			mId=sessionDataAccess.add(mSessionName, mSessionDescription, mApplicationBaseUrl, mAuthenticationType, mUseAutoScan, mUserAgent);
		}

		public void update()
		{
			sessionDataAccess.update(mId, mSessionName, mSessionDescription, mApplicationBaseUrl, mAuthenticationType, mUseAutoScan, mUserAgent);

		}

		public void delete()
		{
			sessionDataAccess.delete(mId);
		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=sessionDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mSessionName=System.Convert.ToString(objDataRow["sessionName"]);
				mSessionDescription=System.Convert.ToString(objDataRow["sessionDescription"]);
				mApplicationBaseUrl=System.Convert.ToString(objDataRow["applicationBaseUrl"]);
				mAuthenticationType=System.Convert.ToInt32(objDataRow["authenticationType"]);
                mUseAutoScan=System.Convert.ToInt32(objDataRow["useAutoScan"]);
				mUserAgent=System.Convert.ToInt32(objDataRow["userAgent"]);
			}

		}
	}
}
