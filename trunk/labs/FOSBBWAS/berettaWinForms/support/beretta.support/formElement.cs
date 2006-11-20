using System;
using System.Text;
using System.Text.RegularExpressions;

namespace beretta.support
{
	/// <summary>
	/// Summary description for formElement.
	/// </summary>
	public class formElement
	{
		private string mName;
		private string mType;
		private string mValue;

		public string name
		{
			get{return mName;}
			set{mName=value;}
		}

		public string type
		{
			get{return mType;}
			set{mType=value;}
		}

		public string value
		{
			get{return mValue;}
			set{mValue=value;}
		}

		public formElement()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
