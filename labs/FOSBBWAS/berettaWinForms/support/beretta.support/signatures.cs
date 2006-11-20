using System;
using System.Data;

namespace beretta.Objects
{
	/// <summary>
	/// A Signature is used to determine whether an attack has been successful or not
	/// </summary>
	public class signatures
	{

		private int mId;
		private string mSignatureName;
		private string mSignatureValue;
		private string mSignatureOperator;
		private string mSignatureDescription;
		private string mSignatureMessage;
		private int mSignatureType;
		private int mSignatureOrder;
		private int mSignatureMessageType;

		private signaturesDataAccess objSignaturesDataAccess=new signaturesDataAccess();

		public int id
		{
			get{return mId;}
			set{mId=value;}
		}

		public string signatureName
		{
			get{return mSignatureName;}
			set{mSignatureName=value;}
		}

		public string signatureValue
		{
			get{return mSignatureValue;}
			set{mSignatureValue=value;}
		}

		public string signatureOperator
		{
			get{return mSignatureOperator;}
			set{mSignatureOperator=value;}
		}

		public string signatureDescription
		{
			get{return mSignatureDescription;}
			set{mSignatureDescription=value;}
		}
		public string signatureMessage
		{
			get{return mSignatureMessage;}
			set{mSignatureMessage=value;}
		}

		public int signatureType
		{
			get{return mSignatureType;}
			set{mSignatureType=value;}
		}

		public int signatureOrder
		{
			get{return mSignatureOrder;}
			set{mSignatureOrder=value;}
		}

		public int signatureMessageType
		{
			get{return mSignatureMessageType;}
			set{mSignatureMessageType=value;}
		}


		public signatures()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			signaturesDataAccess.add(mSignatureName, mSignatureValue, mSignatureOperator, mSignatureDescription, mSignatureMessage, mSignatureOrder, mSignatureType, mSignatureMessageType);
		}

		public void update()
		{
			signaturesDataAccess.update(mId, mSignatureName, mSignatureValue, mSignatureOperator, mSignatureDescription, mSignatureMessage, mSignatureOrder, mSignatureType, mSignatureMessageType);

		}

		public void delete()
		{
			signaturesDataAccess.delete(mId);
		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();
			
			objDataSet=signaturesDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
					mId=System.Convert.ToInt32(objDataRow["id"]);
					mSignatureName=System.Convert.ToString(objDataRow["signatureName"]);
					mSignatureValue=System.Convert.ToString(objDataRow["signatureValue"]);
					mSignatureOperator=System.Convert.ToString(objDataRow["signatureOperator"]);
					mSignatureDescription=System.Convert.ToString(objDataRow["signatureDescription"]);
					mSignatureMessage=System.Convert.ToString(objDataRow["signatureMessage"]);
					mSignatureOrder=System.Convert.ToInt32(objDataRow["signatureOrder"]);
					mSignatureType=System.Convert.ToInt32(objDataRow["signatureType"]);
					mSignatureMessageType=System.Convert.ToInt32(objDataRow["signatureMessageType"]);
			}

		}
	}
}
