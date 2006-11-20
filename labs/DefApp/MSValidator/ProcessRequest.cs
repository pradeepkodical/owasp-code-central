#region Licence Information

// The Defence Application For ASP.Net Applications
// Version 0.6
// Copyright (C) 2004 - 2005 Izzet Kerem Kusmezer/Dinis Cruz
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

using System;
using System.Collections;
using System.Web;
using System.Xml;
using Owasp.DefApp.Logging;
using Owasp.DefApp.Rules;
using Owasp.DefApp.Utility;

#endregion

namespace Owasp.DefApp.MSValidator
{
	/// <summary>
	/// Uses The Process Mechanics Introduced By Dinis Cruz
	/// Whole of this module has been implemented by Dinis Cruz! Thx For His Contribution !
	/// </summary>
	public class ProcessRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public static XmlDocument xmlFile_Validator_FormMappings = new XmlDocument();

		/// <summary>
		/// 
		/// </summary>
		public static Hashtable hashtableWithValidator_FormMappings = new Hashtable();

		/// <summary>
		/// 
		/// </summary>
		public static Hashtable hashtableWithValidator_FormRules = new Hashtable();

		/// <summary>
		/// 
		/// </summary>
		public static XmlDocument xmlFile_Validator_Rules = new XmlDocument();

		/// <summary>
		/// 
		/// </summary>
		public static ArrayList pagesToProcess = new ArrayList();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void ProcessRequest_Handler(object sender, EventArgs e)
		{
			HttpApplication currentHttpApplication = (HttpApplication) sender;
			HttpRequest currentHttpRequest = currentHttpApplication.Request;
			LogRequestData objLogRequestData = new LogRequestData();
			RequestToValidate objRequestToValidate = new RequestToValidate();
			objRequestToValidate.HttpRequestToAnalyse = currentHttpRequest;
			objLogRequestData.addEntry("Starting ProcessRequest_Handler Processing Page: " + objRequestToValidate.HttpRequestToAnalyse.Path);
			objRequestToValidate.pageClassName = ReflectionUtils.resolvePageClassName();
			objLogRequestData.addEntry("Page's class identified has: <b>" + objRequestToValidate.pageClassName + "</b>");
			if (objRequestToValidate.validateCurrentPage(pagesToProcess))
			{
				objLogRequestData.addEntry((string) hashtableWithValidator_FormMappings[objRequestToValidate.pageClassName].ToString());
				objLogRequestData.addEntry("Validating Current Page");
				if (objRequestToValidate.pageHasItemsToValidate())
				{
					objLogRequestData.addEntry("Page has Items to Validated");
					if (ReflectionUtils.makeTheRequestFormDataEditable())
					{
						objLogRequestData.addEntry("the private method HttpContext.Current.Request.Form.MakeReadWrite() was successfully invoked");
						ArrayList listOfRulesProcessed = objRequestToValidate.validateAndHandleMaliciousInput((XmlElement) hashtableWithValidator_FormMappings[objRequestToValidate.pageClassName], hashtableWithValidator_FormRules);
						foreach (string item in listOfRulesProcessed)
						{
							objLogRequestData.addEntry(item);
						}
					}
					else
					{
						objLogRequestData.addEntry("ERROR!!: makeTheRequestFormDataEditable failed");
					}
				}
				else
				{
					objLogRequestData.addEntry("Nothing to Validate");
				}
			}
			else
			{
				objLogRequestData.addEntry("Not Validating");
			}
			objLogRequestData.outputMessage();
		}
	}
}