using System;

namespace beretta.Objects
{
	/// <summary>
	/// Summary description for berettaResult.
	/// </summary>
	public class berettaSubmission
	{
		private string mFormSubmission;
		private string mUrl;

		public string url
		{
			get{return mUrl;}
			set{mUrl=value;}
		}
	
		public string formSubmission
		{
			get{return mFormSubmission;}
			set{mFormSubmission=value;}
		}


		public berettaSubmission()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
