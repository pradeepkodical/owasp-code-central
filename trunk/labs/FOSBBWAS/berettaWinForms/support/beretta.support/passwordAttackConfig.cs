#region Imported Libraries

using System;
using System.Data;

#endregion

namespace beretta.Modules.PasswordAttack
{
	/// <summary>
	/// Summary description for passwordAttackConfig.
	/// </summary>
	public class passwordAttackConfig
	{
		protected passwordAttackDataAccess objPasswordAttackDataAccess = new passwordAttackDataAccess();

		private int mId;
		private string mDescription;
		private string mUrl;
		private string mFormSubmission;
		private string mSuccessSignature;
		private string mSignatureOperator;
		private int mSignatureType;
		private string mMatches;
		private int mStatus;

		public int id
		{
			get { return mId; }
			set { mId = value; }
		}

		public string description
		{
			get { return mDescription; }
			set { mDescription = value; }
		}

		public string url
		{
			get { return mUrl; }
			set { mUrl = value; }
		}


		public string formSubmission
		{
			get { return mFormSubmission; }
			set { mFormSubmission = value; }
		}


		public string successSignature
		{
			get { return mSuccessSignature; }
			set { mSuccessSignature = value; }
		}

		public string signatureOperator
		{
			get { return mSignatureOperator; }
			set { mSignatureOperator = value; }
		}

		public int signatureType
		{
			get { return mSignatureType; }
			set { mSignatureType = value; }
		}

		public string matches
		{
			get { return mMatches; }
			set { mMatches = value; }
		}

		public int status
		{
			get { return mStatus; }
			set { mStatus = value; }
		}

		
		public passwordAttackConfig()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			beretta.Modules.PasswordAttack.passwordAttackDataAccess.add(mDescription, mUrl, mFormSubmission, mSuccessSignature, mSignatureOperator, mSignatureType, mMatches, mStatus);
		}

		public void update()
		{
			beretta.Modules.PasswordAttack.passwordAttackDataAccess.update(mId, mDescription, mUrl, mFormSubmission, mSuccessSignature, mSignatureOperator, mSignatureType, mMatches, mStatus);

		}

		public void delete()
		{
			beretta.Modules.PasswordAttack.passwordAttackDataAccess.delete(mId);
		}

		public void populate()
		{
			DataSet objDataSet = new DataSet();
			objDataSet = beretta.Modules.PasswordAttack.passwordAttackDataAccess.getAllById(mId);

			foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId = Convert.ToInt32(objDataRow["id"]);
				mDescription = Convert.ToString(objDataRow["description"]);
				mUrl = Convert.ToString(objDataRow["url"]);
				mFormSubmission = Convert.ToString(objDataRow["formSubmission"]);
				mSuccessSignature = Convert.ToString(objDataRow["successSignature"]);
				mSignatureOperator = Convert.ToString(objDataRow["signatureOperator"]);
				mSignatureType = Convert.ToInt32(objDataRow["signatureType"]);
				mMatches = Convert.ToString(objDataRow["matches"]);
				mStatus = Convert.ToInt32(objDataRow["status"]);


			}

		}
	}
}