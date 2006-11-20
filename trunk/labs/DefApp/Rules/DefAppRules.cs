#region Imported Libraries
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using Owasp.DefApp.Convertors;
using Owasp.DefApp.SettingProcessor;
#endregion

#region Licence Information

// The Defence Application For ASP.Net Applications
// Version 0.6
// Copyright (C) 2004 - 2005 Izzet Kerem Kusmezer
// Email: keremkusmezer@yazilimguvenligi.com
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

namespace Owasp.DefApp.Rules
{
	#region The Application Rule Class Declarations
	public class CookieCryptorList
	{
		private Hashtable cookieStorage;
	}

	//Added For Compatibility With The Mod Security
	public class RuleList
	{
		/// <summary>
		/// 
		/// </summary>
		public enum
			Conditions
		{
			/// <summary>
			/// 
			/// </summary>
			AND = 0,
			/// <summary>
			/// 
			/// </summary>
			OR = 1
		} ;

		private string stageType;
		private string action;
		private Conditions condition;
		private string normalization;
		private ArrayList Rules;
		private ArrayList RuleLists;

		/// <summary>
		/// Empties The RuleList
		/// </summary>
		public void ClearRuleList()
		{
			Rules.Clear();
		}		
		/// <summary>
		/// Returns The Condition Of The Rules List
		/// </summary>
		public Conditions Condition
		{
			get { return condition; }
			set { this.condition = value; }
		}	
		/// <summary>
		/// Default Constructor For The RuleList
		/// </summary>
		public RuleList(RuleList.Conditions myCondition)
		{
			Rules = new ArrayList();
			//Added For Sync In MultiThread Enviroments
			Rules = ArrayList.Synchronized(Rules);
			RuleLists = ArrayList.Synchronized(RuleLists);
			condition = myCondition;
		}
		public bool AddRuleList(RuleList ruleList)
		{
			RuleLists.Add(ruleList);
			return true;
		}
		/// <summary>
		/// Adds The Given Rule Object To The RuleSet
		/// </summary>
		/// <param name="rule"></param>
		/// <returns></returns>
		public bool AddRule(Rule rule)
		{
			Rules.Add(rule);
			rule.BaseRuleList = this;
			return true;
		}
		
		/// <summary>
		/// Removes The Given Rule Object From RuleSet
		/// </summary>
		/// <param name="rule">The Rule Object To Be Removed</param>
		/// <returns></returns>
		public bool RemoveRule(Rule rule)
		{
			rule.BaseRuleList = null;
			Rules.Remove(rule);
			Rules.TrimToSize();
			return true;
		}

		/// <summary>
		/// Removes The Given Rule using RuleName From The List
		/// </summary>
		/// <param name="RuleName"></param>
		/// <returns></returns>
		public bool RemoveRule(string RuleName)
		{			
			return true;
		}

		/// <summary>
		/// Checks The Object For The Whole Rule Collection
		/// </summary>
		/// <param name="requestToCheck"></param>
		/// <returns></returns>
		public bool CheckRule(String requestToCheck)
		{
			bool result = true;
			if (RuleLists.Count > 0)
			{				
				foreach(RuleList tempRuleList in RuleLists)
				{
					result = tempRuleList.CheckRule(requestToCheck);
					if (Conditions.OR == this.condition)
					{
						if(result)
							return true;
					}
				}
			}			
			Rule[] rules = GetAllRules();
			for (int i = 0; i < rules.Length; i++)
			{
				bool RuleCheck = rules[i].Check(requestToCheck) && result;
				if (Conditions.AND == this.condition)
				{
					if (!RuleCheck)
						return false;
				}
				else if (Conditions.OR == this.condition)
				{
					if (RuleCheck)
						return true;
				}
			}
			return result;
		}

		/// <summary>
		/// Returns Whole Defined Rules Of The Set
		/// </summary>
		/// <returns></returns>
		public Rule[] GetAllRules()
		{
			return (Rule[]) Rules.ToArray(typeof (Rule));
		}
	}

	/// <summary>
	/// Makes The Given Cookies That Match The Given Pattern HttpOnly
	/// </summary>
	public class CookieRule:Regexrule
	{
		private ViewStateStatus.Method encryptionMethod;
		
		private Hashtable storage;
	
		public CookieRule(string name,string pattern,ViewStateStatus.Method encryptionMethod,Hashtable storage):base(name,pattern,ActionTypes.Clean)
		{
			this.encryptionMethod = encryptionMethod;	
			this.storage = storage;
		}
		
		public bool CheckCookie(HttpCookie cookie)
		{
			if (base.Check(cookie.Name))
			{
				HttpCookie tempCookie = 
					OutputConvertors.DuplicateCookie(cookie);
				string cookieName = "";
				switch(encryptionMethod)
				{
					case (ViewStateStatus.Method.MD5):
					{
						cookieName = 
							FormsAuthentication.HashPasswordForStoringInConfigFile(cookie.Name, "md5");
							break;
					}
					case (ViewStateStatus.Method.SHA1): 
					{
						cookieName = 
							FormsAuthentication.HashPasswordForStoringInConfigFile(cookie.Name, "sha1");
							break;
					}
					case (ViewStateStatus.Method.GUID):
					{
						cookieName = Guid.NewGuid().ToString();
							break;
					}
					case (ViewStateStatus.Method.NONE):
					{
						cookieName = cookieName;
							break;
					}
				}									
					cookie.Values.Clear();
					cookie.Name = cookieName;
					cookie.Value = "";
					storage.Add(cookieName,tempCookie);
					return true;				
			}
			return false;
		}

		public override bool Check(string values)
		{
			throw new NotImplementedException();
		}
	}

	#region The Default Implemented Rules Of The DefApp

	/// <summary>
	/// Checks The Given Text in Whole Scopes
	/// </summary>
	public class Textrule : Rule
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="pattern"></param>
		/// <param name="action"></param>
		public Textrule(string name, string pattern, ActionTypes action) : base(name, pattern, RuleTypes.Textrule, action)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public override bool Check(string values)
		{
			values = values.ToLower();
			string patternStringFinal = this.Pattern.ToLower();
			return ((values.IndexOf(patternStringFinal) > -1 || values.Equals(patternStringFinal)) ? true : false);
		}
	}

	/// <summary>
	/// Gets The Reserve Of The Given IpRule
	/// </summary>
	public sealed class NIPRule : IPRule
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="pattern"></param>
		/// <param name="action"></param>
		public NIPRule(string name, string pattern, ActionTypes action) : base(name, pattern, action)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public override bool Check(string values)
		{
			return false;
		}
	}

	/// <summary>
	/// Ip Address Checking Rule which supports wild cat characters
	/// </summary>
	public class IPRule : Rule
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="pattern"></param>
		/// <param name="action"></param>
		public IPRule(string name, string pattern, ActionTypes action) : base(name, pattern, RuleTypes.IPRule, action)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public override bool Check(string values)
		{
			return false;
		}
	}

	/// <summary>
	/// The Regular Expression Rule
	/// </summary>
	public class Regexrule : Rule
	{
		#region Private Variables

		private Regex reg;

		#endregion

		#region Public Methods

		/// <summary>
		/// The Default Constructor To Be Used By The Reg Engine
		/// </summary>
		/// <param name="name"></param>
		/// <param name="pattern"></param>
		/// <param name="action"></param>
		public Regexrule(string name, string pattern, ActionTypes action) : base(name, pattern, RuleTypes.Regexrule, action)
		{
			try
			{
				// Added To Improve The Overall Performance For Concurent Calls
				// It is no more case sensitive 
				log.Info("Trying To Parse The Regular Expression:" + pattern);
				reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
				log.Info("Parsing Of The Pattern " + pattern + " Successfully");
			}
			catch (Exception ex)
			{
				log.Fatal("Unable To Parse The Following Expression:" + pattern, ex);
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public override bool Check(string values)
		{
			return (reg.IsMatch(values) ? true : false);
		}

		#endregion
	}

	/// <summary>
	/// Gives Out The Negative Of The Given Regular Expression
	/// </summary>
	public sealed class NRegexrule : Regexrule
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="pattern"></param>
		/// <param name="action"></param>
		public NRegexrule(string name, string pattern, ActionTypes action) : base(name, pattern, action)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public override bool Check(string values)
		{
			return (!base.Check(values));
		}
	}

	#endregion

	#endregion
}