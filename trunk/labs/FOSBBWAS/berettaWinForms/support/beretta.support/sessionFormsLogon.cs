using System;
using System.Data;

namespace beretta.Objects
{
	/// <summary>
	/// HTML form logon class
	/// </summary>
	public class sessionFormsLogon
	{
		private int mId;
		private int mSessionId;
		private string mLoginPageUrl;
		private string mUsername;
		private string mPassword;
		private string mUsernameFieldName;
		private string mPasswordFieldName;
		private string mSubmitButtonFieldName;
		private string mTotalFormSubmission;

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

		public string username
		{
			get{return mUsername;}
			set{mUsername=value;}
		}

		public string password
		{
			get{return mPassword;}
			set{mPassword=value;}
		}

		
		public string usernameFieldName
		{
			get{return mUsernameFieldName;}
			set{mUsernameFieldName=value;}
		}

		public string passwordFieldName
		{
			get{return mPasswordFieldName;}
			set{mPasswordFieldName=value;}
		}

		public string submitButtonFieldName
		{
			get{return mSubmitButtonFieldName;}
			set{mSubmitButtonFieldName=value;}
		}

		public string totalFormSubmission
		{
			get{return mTotalFormSubmission;}
			set{mTotalFormSubmission=value;}
		}

	

		public sessionFormsLogon()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			sessionFormsLogonDataAccess.deleteBySessionId(mSessionId);
			sessionFormsLogonDataAccess.add(mSessionId, mLoginPageUrl, mUsername, mPassword, mUsernameFieldName, mPasswordFieldName, mSubmitButtonFieldName);

		}

		public void deleteBySessionId()
		{
			sessionFormsLogonDataAccess.deleteBySessionId(mSessionId);

		}

		public void populateBySessionId()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=sessionFormsLogonDataAccess.getDetailBySessionId(mSessionId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{

				mId=System.Convert.ToInt32(objDataRow["id"]);
				mSessionId=System.Convert.ToInt32(objDataRow["sessionId"]);
				mLoginPageUrl=System.Convert.ToString(objDataRow["loginPageUrl"]);
				mUsername=System.Convert.ToString(objDataRow["username"]);
				mPassword=System.Convert.ToString(objDataRow["password"]);
				mUsernameFieldName=System.Convert.ToString(objDataRow["usernameFieldName"]);
				mPasswordFieldName=System.Convert.ToString(objDataRow["passwordFieldName"]);
				mSubmitButtonFieldName=System.Convert.ToString(objDataRow["submitButtonFieldName"]);

				generateTotalFormSubmission();
			}

		}

		public void generateTotalFormSubmission()
		{

			string strTmp="%%VIEWSTATE" + "&" + mUsernameFieldName + "=" + mUsername + "&" + mPasswordFieldName + "=" + mPassword + "&" + mSubmitButtonFieldName + "=a";

			mTotalFormSubmission=strTmp;

		}
	}
}
