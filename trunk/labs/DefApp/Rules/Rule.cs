#region Imported Libraries
using System;
using System.Collections;
using System.Text;
using System.Xml;
using log4net;
using Owasp.DefApp.Utility;
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
	/// <summary>
	/// The Default Rule Abstract Class
	/// </summary>
	public abstract class Rule:IComparable
	{
		#region Enums Used By The Rule Class

		/// <summary>
		/// Used For Declaring Rules In The Application
		/// </summary>
		public enum RuleTypes
		{
			/// <summary>
			/// None Rule Defined
			/// </summary>
			None = 0,
			/// <summary>
			/// Text Check Rule Defined
			/// </summary>
			Textrule = 1,
			/// <summary>
			/// Regular Expression Check Rule Defined
			/// </summary>
			Regexrule = 2,
			/// <summary>
			/// None Regular Expression Check Rule Defined
			/// </summary>
			NRegexrule = 4,
			/// <summary>
			/// If The Request Matches Given Ip Number
			/// </summary>
			IPRule = 3,
			/// <summary>
			/// If The Request Do Not Matches Given Ip Number
			/// </summary>
			NIPRule = 5,
			/// <summary>
			/// The Rule Is Cookie Manipulation Cookie
			/// </summary>
			CookieRule = 6
		}

		/// <summary>
		/// The Actions Enumarator Which Will Be Done When Rule is true
		/// </summary>
		public enum ActionTypes
		{
			/// <summary>
			/// No Action Will Be Taken
			/// </summary>
			None = 0,
			/// <summary>
			/// The Request Will Be Denied
			/// </summary>
			Deny = 1,
			/// <summary>
			/// The Request Will Be Allowed
			/// </summary>
			Allow = 2,
			/// <summary>
			/// The Request Will Be Logged As Warning
			/// If Warning Threshold Expires The Request Will Be Stopped
			/// </summary>
			Warn = 3,
			/// <summary>
			/// The Request Will Be Cleaned From The Given Input Pattern
			/// </summary>
			Clean = 4
		} ;

		#endregion

		#region Private Variables

		private string name, pattern;

		private int action, type;

		private Hashtable NormalizationList;

		#endregion

		#region Public Methods Of The Rule Class
		
		public int RuleAction()
		{
			return action;
		}
		/*
		public int RuleAction
		{
			return action;
		}
		*/
		public string RuleTypeString()
		{
			return RuleTypes.GetName(typeof(RuleTypes),this.type);
		}
		/// <summary>
		/// Returns The Rule Type As String
		/// </summary>
		/// <returns>Rule Type As String</returns>
		public string RuleString()
		{
			if ((int) ActionTypes.Allow == action)
				return "allow";
			else if ((int) ActionTypes.Deny == action)
				return "deny";
			else if ((int) ActionTypes.Warn == action)
				return "warn";
			else
				return null;
		}

		/// <summary>
		/// Makes The String Representation Of The Object
		/// </summary>
		/// <returns>The String Representation Of The Object</returns>
		public override string ToString()
		{
			return GeneralUtilities.ToString(this);
		}
		/// <summary>
		/// Converts The Given XmlNode into a Rule
		/// </summary>
		/// <param name="node">The XmlNode To Be Converted To Rule</param>
		/// <param name="ary">The Arraylist to be used to add the created rule</param>
		/// <returns></returns>	
		public static Rule XmlToRule(XmlNode node, ArrayList ary)
		{
			IEnumerator enumator = node.Attributes.GetEnumerator();
			if (!GeneralUtilities.CheckString(node.InnerText))
			{
				return null;
			}
			int count = 0;
			string values = "", tip = "", rulename = "", action = "";
			while (enumator.MoveNext())
			{
				XmlAttribute atrb = (XmlAttribute) enumator.Current;
				string atrbb = atrb.Name.ToLower();

				StringBuilder attributebuild = new StringBuilder();
				attributebuild.Append("attribute name:");
				attributebuild.Append(atrbb);
				attributebuild.Append(" value:");
				attributebuild.Append(atrb.Value);

				log.Info(attributebuild.ToString());

				if (atrbb == "name" || atrbb == "action" || atrbb == "type")
				{
					if (!GeneralUtilities.CheckString(atrb.Value))
						break;
				}
				else
				{
					continue;
				}

				if (atrbb == "name")
				{
					rulename = atrb.Value;
					count++;
				}
				else if (atrbb == "action")
				{
					action = atrb.Value;
					count++;
				}
				else if (atrbb == "type")
				{
					tip = atrb.Value;
					count++;
				}

				if (count == 3)
				{
					values = node.InnerText;
					count = 0;
					try
					{
						if ((Enum.Parse(typeof (RuleTypes), tip, true) != null) && (Enum.Parse(typeof (ActionTypes), action, true) != null))
						{
							object[] args = new object[3];

							args[0] = rulename;
							args[1] = values;
							args[2] = Enum.Parse(typeof (ActionTypes), action, true);

							Type tips = System.Type.GetType(typeof (Rule).Namespace + "." + tip);

							object obj = Activator.CreateInstance(tips, args);

							ary.Add(obj);

							return (Rule) obj;
						}
					}
					catch (Exception ex)
					{
						log.Error(ex.Message);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// The Abstract Method which will be implemented by the other classes
		/// </summary>
		/// <param name="values">The Values To Be Checked According To The Rule</param>
		/// <returns>Returns The Result Of The Check</returns>
		public abstract bool Check(string values);

		#endregion

		#region Protected Methods Of The Rule Class

		/// <summary>
		/// The Protected Logger Class For The Abstract Rule Class
		/// </summary>
		protected static ILog log = LogManager.GetLogger(typeof (DefenceMainSettingHandler));

		/// <summary>
		/// The Protected Constructor Of The Abstract Rule Class
		/// </summary>
		/// <param name="name">The Name Of The Rule</param>
		/// <param name="pattern">The Pattern To Be Used By The Rule</param>
		/// <param name="type">The Type Of The Rule according to the Enum</param>
		/// <param name="action">The Type Of The Actions according to the Enum</param>
		protected Rule(string name, string pattern, RuleTypes type, ActionTypes action)
		{
			this.name = name;
			this.pattern = pattern;
			this.type = (int) type;
			this.action = (int) action;
			NormalizationList = new Hashtable();
		}

		#endregion
		
		private RuleList _innerRuleList;

		public RuleList BaseRuleList
		{
			get
			{
				return _innerRuleList;
			}
			set
			{
				_innerRuleList=value;			
			}
		}
		public bool HasRuleList()
		{
			return (_innerRuleList != null);
		}
		
		#region Public Properties Of The Rule Class

		/// <summary>
		/// The Pattern Of The Rule
		/// </summary>
		public string Pattern
		{
			get { return pattern; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return name; }
		}

		/// <summary>
		/// Returns The Type Of The Rule Object
		/// </summary>
		public int Type
		{
			get { return type; }
		}

		#endregion	

		#region IComparable Members
		public string Identification
		{
			get
			{
				return this.name + this.type.ToString() + this.Pattern;
			}
		}
		/// <summary>
		/// Compares Object With The Given Rule
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int CompareTo(object obj)
		{
			if ((obj != null) && (obj is Rule))
			{
				Rule tempRule = obj as Rule;
				if (tempRule.Identification == this.Identification)
					return 0;
				else
					return (tempRule.CompareTo(this) * -1);
			}	
			return -1;
		}

		#endregion
	}
}
