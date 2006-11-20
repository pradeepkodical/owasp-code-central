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

using System;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Xml;

#endregion

namespace Owasp.DefApp.Rules
{
	/// <summary>
	/// The Handler For Request Validation
	/// </summary>
	public class RequestToValidate
	{
		/// <summary>
		/// 
		/// </summary>
		public HttpRequest HttpRequestToAnalyse;

		/// <summary>
		/// 
		/// </summary>
		public string pageClassName;

		/// <summary>
		/// 
		/// </summary>
		public RequestToValidate()
		{
		}

		private BindingFlags ___requiredBindingFlagsToAccessPrivateMembers()
		{
			BindingFlags objTempBindingFlags = new BindingFlags();
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Public;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.NonPublic;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Instance;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Static;
			return objTempBindingFlags;
		}


		internal bool validateCurrentPage(ArrayList pagesToProcess)
		{
			if (-1 == pagesToProcess.IndexOf(pageClassName))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		internal bool pageHasItemsToValidate()
		{
			if ((HttpRequestToAnalyse.Form.Count > 0) || (HttpRequestToAnalyse.QueryString.Count > 0))
			{
				return true;
			}
			return false;
		}

		internal ArrayList validateAndHandleMaliciousInput(XmlElement objXmlElementWithFormMappings, Hashtable hashtableWithValidator_FormRules)
		{
			ArrayList listOfRulesProcessed = new ArrayList();
			try
			{
				foreach (XmlNode objXmlControls in objXmlElementWithFormMappings)
				{
					if (objXmlControls.ChildNodes.Count > 0) //i.e. there are rules in the Form's Control
					{
						string fieldToAnalyse = objXmlControls.Attributes["ControlId"].InnerText;
						string dataToAnalyse = HttpRequestToAnalyse.Form[fieldToAnalyse];
						string FormsProcessed = "Applying to Field <b>'" + fieldToAnalyse + "'</b> (containing '" + dataToAnalyse + "') :";

						foreach (XmlNode objXmlRules in objXmlControls)
						{
							string validatorRuleName = objXmlRules.Attributes["name"].InnerText;
							string RulesProcessed = " the Rule <b>'" + validatorRuleName + "'</b> which contains the classes: ";
							XmlElement objRuleInformation = (XmlElement) hashtableWithValidator_FormRules[validatorRuleName];
							foreach (XmlNode objXmlRulesClass in objRuleInformation)
							{
								string validatorClassName = objXmlRulesClass.Attributes["name"].InnerText;
								RulesProcessed += " <b>'" + validatorClassName + "</b>";
								switch (validatorClassName)
								{
									case "RequiredFieldValidator":
										{
											if (ValidatorFunctions.RuleClass_RequiredFieldValidator(dataToAnalyse))
											{
												RulesProcessed += htmlGreen(" [OK] , ");
											}
											else
											{
												RulesProcessed += htmlRed(" [FAILED] , ");
											}
											break;
										}
									case "RegExValidator":
										{
											string regularExpersionString = objXmlRulesClass.Attributes["ValidationExpression"].InnerText;
											if (ValidatorFunctions.RuleClass_RegExValidator(dataToAnalyse, regularExpersionString))
											{
												RulesProcessed += htmlGreen(" [OK] , ");
											}
											else
											{
												RulesProcessed += htmlRed(" [FAILED] , ");
											}
											break;
										}

									case "RangeValidator":
										{
											if (ValidatorFunctions.RuleClass_RangeValidator(dataToAnalyse))
											{
												RulesProcessed += htmlOrange(" [Not Implemented yet] , ");
											}
											else
											{
												RulesProcessed += htmlRed(" [FAILED] , ");
											}
											break;
										}
									case "CustomValidator":
										{
											if (ValidatorFunctions.RuleClass_CustomValidator(dataToAnalyse))
											{
												RulesProcessed += htmlOrange("[Not Implemented yet] , ");
											}
											else
											{
												RulesProcessed += htmlRed(" [FAILED] , ");
											}
											break;
										}
									case "ValidationSummary":
										{
											if (ValidatorFunctions.RuleClass_ValidationSummary(dataToAnalyse))
											{
												RulesProcessed += htmlOrange(" [Not Implemented yet] , ");
											}
											else
											{
												RulesProcessed += htmlRed(" [FAILED] , ");
											}
											break;
										}
								}
							}
							// This final rule is Hard coded (i.e. will always be executed (as long as there is 1 rule))
							if (ValidatorFunctions.RuleClass_SQLInjectionDetector(dataToAnalyse))
							{
								// don't show message when no attack is detected
								// RulesProcessed += "SQLInjectionDetector" + htmlGreen(" [OK] , ");	
							}
							else
							{
								HttpRequestToAnalyse.Form[fieldToAnalyse] = HttpRequestToAnalyse.Form[fieldToAnalyse].Replace("'", "''");
								RulesProcessed += "<b>SQLInjectionDetector</b> " + htmlRed(" [FAILED: SQL INJECTION ATTACK DETECTED (and mitigated)] , ");
							}
							listOfRulesProcessed.Add(FormsProcessed + RulesProcessed);
						}
					}
				}
			}
			catch (Exception objEx)
			{
				listOfRulesProcessed.Add(htmlRed("Exception in 'validateAndHandleMaliciousInput' method"));
				listOfRulesProcessed.Add(htmlRed(objEx.GetType().ToString()));
				listOfRulesProcessed.Add(htmlRed(objEx.Message));
				listOfRulesProcessed.Add(htmlRed(objEx.StackTrace));
			}
			return listOfRulesProcessed;
		}

		private String htmlColor(string color, string htmlCodeToApplyFormating)
		{
			return "<font color='" + color + "'>" + htmlCodeToApplyFormating + "</font>";
		}

		private const String HTML_RED = "red";
		private const String HTML_ORANGE = "Orange";
		private const String HTML_GREEN = "Green";

		private string htmlRed(string htmlCodeToApplyFormating)
		{
			return htmlColor(HTML_RED, htmlCodeToApplyFormating);
		}

		private string htmlOrange(string htmlCodeToApplyFormating)
		{
			return htmlColor(HTML_ORANGE, htmlCodeToApplyFormating);
		}

		private string htmlGreen(string htmlCodeToApplyFormating)
		{
			return htmlColor(HTML_GREEN, htmlCodeToApplyFormating);
		}
	}
}