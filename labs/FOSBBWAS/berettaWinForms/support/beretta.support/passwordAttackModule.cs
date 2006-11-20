using System;
using beretta.Modules.PasswordAttack;
using System.Text.RegularExpressions;


namespace beretta.Modules.PasswordAttack
{
	/// <summary>
	/// Summary description for passwordAttack.
	/// </summary>
	public class passwordAttackModule
	{
		public string strUsername="";
		public string strPassword="";
		public string strFormSubmission="";
		public int intSignatureType=0;
		public string strSignatureOperator="";
		public string strSignature="";
		public string strUrl="";

		public int intId=0;
		private bool bolMatchFound=false;
		protected beretta.Objects.formSubmitter objFormSubmitter=new beretta.Objects.formSubmitter();
	

		
		public passwordAttackModule()
		{
			
		}

		public bool start()
		{

		

			string strTmpFormSubmission="" + strFormSubmission;
			string strTmpReturn="";

			strTmpFormSubmission=strTmpFormSubmission.Replace("%%username%%", strUsername);
			strTmpFormSubmission=strTmpFormSubmission.Replace("%%password%%", strPassword);	

			strTmpReturn="" + objFormSubmitter.submitData(strTmpFormSubmission, strUrl, true, "POST", "");


			if (checkIfMatchFound(strTmpReturn, strUsername, strPassword)==true)
			{
				bolMatchFound=true;
			}
			else
			{
				bolMatchFound=false;
			}

			return bolMatchFound;

		
		}


		private bool checkIfMatchFound(string strReturn, string strUsername, string strPassword)
		{

			string strTmp="";
			
			bool bolMatch=false;
				
			//String Match
			if (intSignatureType==0)
			{
				if (strSignatureOperator=="=")
				{
					if (strReturn.IndexOf(strSignature)>=0)
					{
						bolMatch=true;
					}
				}
				else
				{
					if (strReturn.IndexOf(strSignature)==-1)
					{
						bolMatch=true;
					}
				}
			}

			if(intSignatureType==1)
			{

				Regex objRegex = new Regex(strSignature, RegexOptions.IgnoreCase);

				MatchCollection matches = objRegex.Matches(strReturn);

				if (matches.Count > 0)
				{
					if (strSignatureOperator=="=")
					{
						bolMatch=true;
					}
					else
					{
						bolMatch=false;
					}
					
				}
				else
				{
					if (strSignatureOperator=="=")
					{
						bolMatch=false;
					}
					else
					{
						bolMatch=true;
					}
				}

				objRegex = null;
				matches = null;

			}

			if (bolMatch==true)
			{
				
				passwordAttackDataAccess.updateMatches(intId, strUsername + " " + strPassword + ",");
				return true;
			}
			else
			{
				return false;
			}


		}
	}
}
