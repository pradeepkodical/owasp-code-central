using System;

namespace beretta.Support
{
	/// <summary>
	/// Scissors is used to cut up long strings
	/// </summary>
	public class scissors
	{
		public scissors()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		/// <summary>
		/// Finds a string between 2 points
		/// </summary>
		/// <param name="strMessage">Input String</param>
		/// <param name="strStart">Start string to search for</param>
		/// <param name="strEnd">End string to search for</param>
		/// <returns></returns>
		public static string snip(string strMessage, string strStart, string strEnd)
		{
			try
			{

				int intStart=0;
				int intEnd=0;
				int intLength=0;		

				intStart=strMessage.IndexOf(strStart, 0) + strStart.Length;

				if (strMessage.IndexOf(strStart, intStart) > 0)
				{

					throw new Exception("%%Error Start string is not unique in input. Please enter additional information to identify cut.");
				}


				intEnd=strMessage.IndexOf(strEnd, intStart +1);


				intLength=intEnd-intStart;            
				return strMessage.Substring(intStart, intLength);
			}
			catch (Exception ex)
			{
				return "%%Error " + ex.Message + " message=" + strMessage + " start=" + strStart +  " end=" + strEnd + "******";
			}

		}


	/// <summary>
	/// Finds a string between 2 points
	/// </summary>
	/// <param name="strMessage">Input String</param>
	/// <param name="strStart">Start of string to search for</param>
	/// <param name="strEnd">End of string to search for</param>
	/// <param name="intFindRound">Occurence of find to use</param>
	/// <returns></returns>
		public static string snipWithRound(string strMessage, string strStart, string strEnd, int intFindRound)
		{
			try
			{

				int intStart=0;
				int intEnd=0;
				int intLength=0;		
				int intX=0;


				while (intX != intFindRound)
				{

					intStart=strMessage.IndexOf(strStart, intStart) + strStart.Length;

					intX++;
				}

				intEnd=strMessage.IndexOf(strEnd, intStart +1);


				intLength=intEnd-intStart;            
				return strMessage.Substring(intStart, intLength);
			}
			catch (Exception ex)
			{
				return "%%Error " + ex.Message + " message=" + strMessage + " start=" + strStart +  " end=" + strEnd + "******";

			}

		}

	/// <summary>
	/// Finds a string between 2 points
	/// </summary>
	/// <param name="strMessage">Input String</param>
	/// <param name="strStart">Start of string to search for</param>
	/// <param name="strEnd">End of string to search for</param>
	/// <returns></returns>
		public static string snipIncStart(string strMessage, string strStart, string strEnd)
		{

			try
			{
				int intStart=0;
				int intEnd=0;
				int intLength=0;		

				intStart=strMessage.IndexOf(strStart, 0) + strStart.Length;
				intStart=intStart - strStart.Length;

				if (strMessage.IndexOf(strStart, intStart + strStart.Length) > 0)
				{

					throw new Exception("%%Error Start string is not unique in input. Please enter additional information to identify cut.");
				}


				intEnd=strMessage.IndexOf(strEnd, intStart +1);


				intLength=intEnd-intStart;            
				return strMessage.Substring(intStart, intLength);
			}
			catch (Exception ex)
			{
				return "%%Error " + ex.Message + " message=" + strMessage + " start=" + strStart +  " end=" + strEnd + "******";
			}


		}

		/// <summary>
		/// Counts number of occurences of an inputted string
		/// </summary>
		/// <param name="strInput">Input string</param>
		/// <param name="strSearch">String to search for</param>
		/// <returns></returns>
		public static int countOccurence(string strInput, string strSearch)
		{
			int intX=0;
			int intPos=0;


			try
			{
				while(intPos != -1)
				{
					intPos=strInput.IndexOf(strSearch, intPos+1);	

					if (intPos != -1)
					{
						intX++;
					}
				}

			}
			catch
			{
				return intX;
			}

			return intX;

		}

	}
}
