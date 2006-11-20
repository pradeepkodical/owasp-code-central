using System;

namespace beretta.Objects
{
	/// <summary>
	/// Summary description for berettaResult.
	/// </summary>
	public class berettaResult
	{
		private bool mIsMatch=false;
		private int mPayloadId=0;
		private int mSignatureId=0;
		private string mPayloadName="";
		private string mSignatureName="";
		private string mSignatureType="";
		private string mPayloadPriortiy;
		private string mSignatureMessage;
		private string mSignatureMessageType;
		private string mFieldName;
		private string mFormSubmission;

		private string mUrl;

		public bool isMatch
		{
			get{return mIsMatch;}
			set{mIsMatch=value;}
		}


		public int payloadId
		{
			get{return mPayloadId;}
			set{mPayloadId=value;}
		}

		public int signatureId
		{
			get{return mSignatureId;}
			set{mSignatureId=value;}
		}

		public string payloadName
		{
			get{return mPayloadName;}
			set{mPayloadName=value;}
		}

		public string signatureName
		{
			get{return mSignatureName;}
			set{mSignatureName=value;}
		}

		public string signatureType
		{
			get{return mSignatureType;}
			set{mSignatureType=value;}
		}

		public string signatureMessageType
		{
			get{return mSignatureMessageType;}
			set{mSignatureMessageType=value;}
		}

		public string payloadPriortiy
		{
			get{return mPayloadPriortiy;}
			set{mPayloadPriortiy=value;}
		}

		public string url
		{
			get{return mUrl;}
			set{mUrl=value;}
		}
		public string signatureMessage
		{
			get{return mSignatureMessage;}
			set{mSignatureMessage=value;}
		}
		public string fieldName
		{
			get{return mFieldName;}
			set{mFieldName=value;}
		}
		public string formSubmission
		{
			get{return mFormSubmission;}
			set{mFormSubmission=value;}
		}

		

		

		public berettaResult()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
