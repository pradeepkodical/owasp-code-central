#region Licence Information

// The Defence Application For ASP.Net Applications
// Version 0.6
// Copyright (C) 2004 - 2005 Izzet Kerem Kusmezer / Dinis Cruz
// Email: keremkusmezer@yazilimguvenligi.com / dinis@ddplus.net
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

#endregion

#region Imported Libraries

using System.Text.RegularExpressions;
using Owasp.DefApp.Utility;

#endregion

namespace Owasp.DefApp.Rules
{
	/// <summary>
	/// Summary description for executeValidatorRuleClass.
	/// </summary>
	public class ValidatorFunctions
	{
		private ValidatorFunctions()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataToAnalyse"></param>
		/// <returns></returns>
		public static bool RuleClass_RequiredFieldValidator(string dataToAnalyse)
		{
			if (!GeneralUtilities.IsNull(dataToAnalyse))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataToAnalyse"></param>
		/// <param name="RegExToApply"></param>
		/// <returns></returns>
		public static bool RuleClass_RegExValidator(string dataToAnalyse, string RegExToApply)
		{
			if (!GeneralUtilities.IsNull(dataToAnalyse))
			{
				Regex objRegEx = new Regex(RegExToApply, RegexOptions.IgnoreCase);
				if (objRegEx.Match(dataToAnalyse).Success)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataToAnalyse"></param>
		/// <returns></returns>
		public static bool RuleClass_RangeValidator(string dataToAnalyse)
		{
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataToAnalyse"></param>
		/// <returns></returns>
		public static bool RuleClass_CustomValidator(string dataToAnalyse)
		{
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataToAnalyse"></param>
		/// <returns></returns>
		public static bool RuleClass_ValidationSummary(string dataToAnalyse)
		{
			return true;
		}

		/// <summary>
		/// Automaticaly Detects SqlInjection Attempts
		/// </summary>
		/// <param name="dataToAnalyse"></param>
		/// <returns></returns>
		public static bool RuleClass_SQLInjectionDetector(string dataToAnalyse)
		{
			if (!GeneralUtilities.IsNull(dataToAnalyse))
			{
				if (-1 < dataToAnalyse.IndexOf("'"))
						return false;
			}
			return true;
		}
	}
}