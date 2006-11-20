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

#region Imported Libraries

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using Owasp.DefApp.Appenders;
using Owasp.DefApp.Convertors;
using Owasp.DefApp.Exceptions;
using Owasp.DefApp.Logging;
using Owasp.DefApp.Plugins;
using Owasp.DefApp.Rules;
using Owasp.DefApp.SettingProcessor;
using Owasp.DefApp.Utility;
using Owasp.DefApp.Utils.StreamFilters;

#endregion

namespace Owasp.DefApp
{

	#region The Applications SectionHandlers

	/// <summary>
	/// Includes The Methods To Handle The Configuration Sections and
	/// Create The Necessary Rule and Configuration Objects
	/// </summary>
	public class DefenceMainSettingHandler : IConfigurationSectionHandler
	{
		/// <summary>
		/// Static ArrayList Which Holds The Reference To The MemoryLogs
		/// </summary>
		public static readonly ArrayList MemoryLogs = new ArrayList();

		private static MemoryAppender Append = new MemoryAppender();
		private static readonly ILog log = LogManager.GetLogger(typeof (DefenceMainSettingHandler));
		private static PatternLayout pat = new PatternLayout("%r [%t] %-5p %c - %m%n");

		/// <summary>
		/// The Default Constructor For The Class
		/// </summary>
		public DefenceMainSettingHandler()
		{
		}

		#region Old Version Parser for < v0.3	

		/// <summary>
		/// Old Version General Parser for Version v0.3
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="configContext"></param>
		/// <param name="section"></param>
		/// <returns></returns>
		[Obsolete("This method is obsolete.Please use Create instead", false)]
		public object OldCreate(object parent, object configContext, XmlNode section)
		{
			log.Info("Beginning with the parsing of the web.config");
			//Read The Debug and Activity Attributes Before Creating The
			//Configuration Storage Object
			XmlElement activation = section["Activation"];
			log.Info("Reading The Main Attributes");
			string debug = activation.Attributes["Debug"].Value;
			if (XmlConvert.ToBoolean(debug))
				BasicConfigurator.Configure(new TraceAppender(pat));
			string active = activation.Attributes["Active"].Value;
			string keywordcheck = activation.Attributes["KeywordCheck"].Value;
			string regexcheck = activation.Attributes["RegExCheck"].Value;
			string cookies = section["Handlers"].ChildNodes[0].Attributes["Action"].Value;
			string formfields = section["Handlers"].ChildNodes[1].Attributes["Action"].Value;
			string querystring = section["Handlers"].ChildNodes[2].Attributes["Action"].Value;
			log.Info("Finished successfully Mapping The Main Attributes");
			//DefenceMainSettings settings = new DefenceMainSettings();
			ViewStateStatus viewStateHiding = new ViewStateStatus(true,ViewStateStatus.Method.GUID);
			DefenceMainSettings settings = new DefenceMainSettings(viewStateHiding);
			ArrayList ary = settings.DenyList;
			if (keywordcheck == "true")
			{
				if (section["KeywordList"] != null && section["KeywordList"].ChildNodes != null)
				{
					for (int i = 0; i < section["KeywordList"].ChildNodes.Count; i++)
					{
						string patterns = section["KeywordList"].ChildNodes[i].InnerText;
						if (GeneralUtilities.CheckString(patterns))
						{
							try
							{
								string names = section["KeywordList"].ChildNodes[i].Attributes["name"].Value;
								ary.Add(new Textrule(names, patterns, Rule.ActionTypes.Deny));
							}
							catch (Exception ex)
							{
								log.Error("Error in keywordlist configuration parsing", ex);
							}
						}
					}
				}
			}
			if (regexcheck == "true")
			{
				for (int x = 0; x < section["RegExDeny"].ChildNodes.Count; x++)
				{
					string patterns = section["RegExDeny"].ChildNodes[x].InnerText;
					if (GeneralUtilities.CheckString(patterns))
					{
						try
						{
							ary.Add(new Regexrule(section["RegExDeny"].ChildNodes[x].Attributes["name"].Value, patterns, Rule.ActionTypes.Deny));
						}
						catch (Exception ex)
						{
							log.Error("Error in regex configuration parsing", ex);
						}
					}
				}
			}
			settings.HandleCookies = int.Parse(cookies);
			settings.HandleForms = int.Parse(formfields);
			settings.HandleQueries = int.Parse(querystring);
			//Disabled Prior To Release v0.3
			//settings.IsSqlInjectionBlock = (sqlinjection == "true"?true:false);
			settings.IsDebug = XmlConvert.ToBoolean(debug);
			settings.IsActive = XmlConvert.ToBoolean(active);
			log.Info("Finished Parsing of The Web.Config");
			return settings;
		}

		#endregion

		#region New Version Parser for > v0.3

		/// <summary>
		/// Used By The Configuration Parser To Parser The Config Section
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="configContext"></param>
		/// <param name="section"></param>
		/// <returns></returns>
		public object Create(object parent, object configContext, XmlNode section)
		{
			log.Info("Beginning with the parsing of the web.config");

			#region XmlElement Creation Section

				XmlElement activation = section["Activation"];
				XmlElement FoundStone = section["FoundStoneModule"];
				XmlElement Plugin = section["Plugins"];
				XmlElement ViewStateHiding = section["ViewStateHiding"];

			#endregion

			log.Info("Reading The Main Attributes");

			#region Debug Handling Section

			//BasicConfigurator.Configure(new FileAppender(pat, "c:\\defapplog.log", true));
			bool debug = XmlConvert.ToBoolean(activation.Attributes["Debug"].Value);
			if ((debug))
			{
				string debugFile = activation.Attributes["DebugFile"].Value;
				if (debugFile != null && debugFile.Length > 0)
				{
					try
					{
						BasicConfigurator.Configure(new FileAppender(pat, debugFile, true));
					}
					catch
					{
					}
				}
				//Configures The MemoryAppender						
				BasicConfigurator.Configure(new HttpAppender(pat, MemoryLogs));
				//Configures The Trace Appender
				BasicConfigurator.Configure(new TraceAppender(pat));
			}

			#endregion

			#region General Settings And Handling Orders

			string active = activation.Attributes["Active"].Value;
			//string keywordcheck = activation.Attributes["KeywordCheck"].Value;
			//string regexcheck = activation.Attributes["RegExCheck"].Value;
			string cookies = "";
			string formfields = "";
			string querystring = "";
			string headers = "";
			for (int ixy=0;ixy<section["Handlers"].ChildNodes.Count;ixy++)
			{
				string Name = section["Handlers"].ChildNodes[ixy].Name;
				switch(Name)
				{
					case "HandleCookies":
							cookies = section["Handlers"].ChildNodes[ixy].Attributes["Action"].Value;
									break;
					case "HandleFormFields":
							formfields = section["Handlers"].ChildNodes[ixy].Attributes["Action"].Value;
									break;
					case "HandleQueryString":
							querystring = section["Handlers"].ChildNodes[ixy].Attributes["Action"].Value;
									break;
					case "HandleHeaders":
							headers = section["Handlers"].ChildNodes[ixy].Attributes["Action"].Value;
									break;
					default:
							break;
				}
			}																   
			DefenceMainSettings settings = new DefenceMainSettings();
			
			if (!GeneralUtilities.IsNull(ViewStateHiding))
			{
				if (ViewStateHiding.Attributes.Count == 2)
				{
					if (!GeneralUtilities.IsNull(ViewStateHiding.Attributes["Active"]))
					{
						bool tmpActivation =
						XmlConvert.ToBoolean(ViewStateHiding.Attributes["Active"].Value);
						string tmpMethod = ViewStateHiding.Attributes["Method"].Value;
						ViewStateStatus viewStateHiding = null;
						switch(tmpMethod)
						{
							case "MD5":
								viewStateHiding = new ViewStateStatus(tmpActivation,ViewStateStatus.Method.MD5);
								break;
							case "GUID":
								viewStateHiding = new ViewStateStatus(tmpActivation,ViewStateStatus.Method.SHA1);
								break;
							case "SHA1":
								viewStateHiding = new ViewStateStatus(tmpActivation,ViewStateStatus.Method.GUID);
								break;
							default:
								viewStateHiding = new ViewStateStatus(tmpActivation,ViewStateStatus.Method.NONE);
								break;
						}						
						settings = new DefenceMainSettings(viewStateHiding);
					}
				}
			}

			settings.HandleCookies = int.Parse(cookies);
			settings.HandleForms = int.Parse(formfields);
			settings.HandleQueries = int.Parse(querystring);
			settings.HandleHeaders = int.Parse(headers);
			settings.IsDebug = debug;
			settings.IsActive = XmlConvert.ToBoolean(active);


			//settings
			#endregion

			#region Handle FoundStone Settings

			//log.Debug(AppDomain.CurrentDomain.BaseDirectory + "/bin/" + "DefAppPluginTest.dll");
			//ArrayList lists =
			//Plugins.DefAppPlugin.XmlToPlugin(AppDomain.CurrentDomain.BaseDirectory + "/bin/" + "DefAppPluginTest.dll",10);
			//log.Debug(defApp.PluginName());

			log.Info("Begin Parsing Dinis Attributes");
			if (!GeneralUtilities.IsNull(FoundStone) && !GeneralUtilities.IsNull(FoundStone.Attributes["Active"]))
			{
				string dinisActive = FoundStone.Attributes["Active"].Value;
				settings.IsFoundStoneActive = XmlConvert.ToBoolean(dinisActive);
				if (!GeneralUtilities.IsNull(FoundStone.Attributes["ValidatorFormMappings"]))
					settings.FS_HttpModule_Validator_FormMappings = FoundStone.Attributes["ValidatorFormMappings"].Value;
				if (!GeneralUtilities.IsNull(FoundStone.Attributes["ValidatorRules"]))
					settings.FS_HttpModule_Validator_Rules = FoundStone.Attributes["ValidatorRules"].Value;
				if (!GeneralUtilities.IsNull(FoundStone.Attributes["XMLRulesDatabase"]))
					settings.FS_HttpModule_XMLRulesDatabase = FoundStone.Attributes["XMLRulesDatabase"].Value;
				if (!GeneralUtilities.IsNull(FoundStone.Attributes["FSPageOutput"]))
					settings.FSPageOutput = XmlConvert.ToBoolean(FoundStone.Attributes["FSPageOutput"].Value);
			}
			log.Info("End Parsing Dinis Attributes");

			#endregion

			#region Plugin Handling Section

			if (GeneralUtilities.CheckNode(Plugin))
			{
				ArrayList pluginArray = settings.PluginList;
				IEnumerator pluginEnum = Plugin.ChildNodes.GetEnumerator();
				while (pluginEnum.MoveNext())
				{
					XmlNode Pluginen = (XmlNode) pluginEnum.Current;
					if (!GeneralUtilities.IsNull(Pluginen.Attributes["assembly"].Value))
					{
						string paths = AppDomain.CurrentDomain.BaseDirectory + "/bin/" + Pluginen.Attributes["assembly"].Value;
						log.Info(paths);
						DefAppPlugin.XmlToPlugin(paths, 999, pluginArray);
					}
				}
			}

			#endregion

			log.Info("Finished successfully Mapping The Main Attributes");

			#region Rule Processing Section

			ArrayList ary = settings.DenyList;
			XmlNode Rulenode = section["RuleList"];
			if (GeneralUtilities.CheckNode(Rulenode))
			{
				IEnumerator enums = Rulenode.ChildNodes.GetEnumerator();
				while (enums.MoveNext())
				{
					XmlNode Rules = (XmlNode) enums.Current;
					Rule.XmlToRule(Rules, ary);
				}
			}

			#endregion

			log.Info("Finished Parsing of The Web.Config");

			return settings;

		}

		#endregion
	}

	/// <summary>
	/// Used For The Custom NameValueSectionHandler 
	/// Will be implemented later
	/// </summary>
	[ComVisible(false)]
	public class Defapp : NameValueSectionHandler
	{
	}

	/// <summary>
	/// Used For The Custom SingleTagSectionHandler
	/// Will be implemented later
	/// </summary>
	[ComVisible(false)]
	public class DefSingle : SingleTagSectionHandler
	{
	}

	#endregion

	#region The Main Filtering Class Definition

	/// <summary>
	/// Holds Whole The Filtering and Action Objects. The Main Body of The Program
	/// </summary>
	public class DefenceMainSettings
	{
		#region Private Variables		
		
		private ViewStateStatus viewStateStatus;
		private const string DEFAULT_PAGE = "defapp.aspx";
		private const string DEFAULT_REPORT_PAGE = "defappreport.aspx";
		private const string VIEW_STATE_TEXT = "__VIEWSTATE";
		private static readonly ILog log = LogManager.GetLogger(typeof (DefenceMainSettingHandler));
		private Hashtable hash = new Hashtable();
		private ArrayList blocklist = new ArrayList();
		private ArrayList pluginlist = new ArrayList();
		private ArrayList ipblock = new ArrayList();
		private ArrayList loggers = new ArrayList();
		private int handleform;
		private int handlequeries;
		private int handlecookie;

		public int HandleHeaders
		{
			get { return handleheaders; }
			set { handleheaders = value; }
		}

		private int handleheaders;
		private bool Debug;
		private bool Active;
		private bool FoundStoneFilterActive;

		private bool FS_Page_Output;

		public string FS_HttpModule_XMLRulesDatabase;

		public string FS_HttpModule_Validator_FormMappings;

		public string FS_HttpModule_Validator_Rules;

		#endregion

		#region Private Methods
		
		public string WriteRuleList()
		{			
			Table tablo1 = new Table();
			tablo1.BorderWidth = System.Web.UI.WebControls.Unit.Parse("1");
			TableRow row2 = new TableRow();				
			IEnumerator blocks = blocklist.GetEnumerator();
			Table tablo = new Table();
			tablo.BorderWidth = System.Web.UI.WebControls.Unit.Parse("1");
			int ix = 0;
			while(blocks.MoveNext())
			{
				if (ix == 0)
				{
					TableRow row1 = new TableRow();												
					row1.BorderWidth = System.Web.UI.WebControls.Unit.Parse("1");
					TableCell[] cell1 = {new TableCell(),new TableCell(),new TableCell(),new TableCell()};										
					cell1[0].Text = "Rule Name";
					cell1[1].Text = "Rule Type";
					cell1[2].Text = "Rules Pattern";
					cell1[3].Text = "Rule Action";
					ix++;
					for(int i=0;i<4;i++)
					{				
						cell1[i].BorderWidth = System.Web.UI.WebControls.Unit.Parse("1");
						row1.Cells.Add(cell1[i]);
					}
					tablo.Rows.Add(row1);
				}
				Rule rules = (Rule)blocks.Current;
				TableRow row = new TableRow();												
				row.BorderWidth = System.Web.UI.WebControls.Unit.Parse("1");
				TableCell[] cell = {new TableCell(),new TableCell(),new TableCell(),new TableCell()};					
				cell[0].Text = rules.Name;
				cell[1].Text = rules.RuleTypeString();				
				cell[2].Text = System.Web.HttpUtility.HtmlEncode(rules.Pattern);
				cell[3].Text = System.Web.HttpUtility.HtmlEncode(rules.RuleString());

				for(int i=0;i<4;i++)
				{				
					cell[i].BorderWidth = System.Web.UI.WebControls.Unit.Parse("1");
					row.Cells.Add(cell[i]);
					}
				tablo.Rows.Add(row);
			}
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter);
			tablo.RenderControl(textWriter);
			textWriter.Flush();
			return stringWriter.GetStringBuilder().ToString();
		}
		
		/// <summary>
		/// Search the value in the denylist and reports the deny status
		/// </summary>
		/// <param name="values">The Value To Be Checked</param>
		/// <param name="lasterror">The Last Occured Error</param>
		/// <returns>True or False according to the situation</returns>
		private bool CheckValue(string values, ref string lasterror,out Rule problemRule)
		{
			problemRule = null;
			if (values == null)
				return true;
			values = values.Trim();			
			if (values.Length != 0)
			{
				if (blocklist != null)
				{
					for (int i = 0; i < blocklist.Count; i++)
					{
						Rule txtrule = blocklist[i] as Rule;
						if (txtrule.Check(values))
						{
							problemRule = txtrule;
							lasterror = txtrule.Name;
							log.Info("Validation Failure has been found invalidation of rule:" + txtrule.Name + " with pattern " + txtrule.Pattern + " with type " + txtrule.RuleString());
							return false;
						}
					}
				}
			}
			return true;
		}

		#endregion

		#region Public Methods		

		/// <summary>
		/// Sets The Regular Expression Engine
		/// </summary>
		public bool IsRegEXEnabled;

		private static DefenceMainSettings _innerDefenceMainSetting;
		public static DefenceMainSettings GetDefenceInstance()
		{
			return _innerDefenceMainSetting;
		}
		public DefenceMainSettings()
		{
			FS_Page_Output = true;
			_innerDefenceMainSetting = this;
		}
		public DefenceMainSettings(ViewStateStatus viewStateStatus):this()
		{
			log.Info("Initializing The DefenceMainSetting Object");
			this.viewStateStatus = viewStateStatus;			
		}
		public bool FSPageOutput
		{
			get { return LogRequestData.LogScreenOutput; }
			set { LogRequestData.LogScreenOutput = value; }
		}
		/// <summary>
		/// Gets and Sets The DenyList Attribute
		/// </summary>
		public ArrayList DenyList
		{
			get { return blocklist; }
		}				
		/// <summary>
		/// Gets and Sets The PluginList Attribute
		/// </summary>		
		public ArrayList PluginList
		{
			get { return pluginlist; }
		}
		
		private string DoLogTable()
		{
			Table tablo = new Table();
			ArrayList ary = DefenceMainSettingHandler.MemoryLogs;
			for (int i = 0; i < ary.Count; i++)
			{
				TableRow row = new TableRow();
				TableCell cell = new TableCell();
				cell.Text = (string) ary[i];
				row.Cells.Add(cell);
				tablo.Rows.Add(row);
			}
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter);
			tablo.RenderControl(textWriter);
			textWriter.Flush();
			return stringWriter.GetStringBuilder().ToString();
		}
		/// <summary>
		/// Handles The Content Section Before The Output is send to the client
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ContentHandlingSection(object sender,EventArgs e)
		{
			HttpApplication httpApplication = (HttpApplication) sender;
			HttpContext httpContext = HttpContext.Current;		
 		}
		/// <summary>
		/// Handles The Header Section Before The Output is send to the client
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void HeaderHandlingSection(object sender,EventArgs e)
		{
			
		}
		private MemoryFilter memoryFilter;

		public void application_ReleaseRequestState(object sender, EventArgs e)
		{
			HttpContext httpContext = HttpContext.Current;
			HttpResponse response = httpContext.Response;		
			if (viewStateStatus != null 
				&& viewStateStatus.Active == true)
			{
				memoryFilter = new MemoryFilter(response.Filter,viewStateStatus);			
				response.Filter = memoryFilter;
			}
		}

		private NameValueCollection nameTable = new NameValueCollection();
		
		/// <summary>
		/// The Custom MainHandlingSection, which will be used to handle The PreRequests
		/// </summary>
		/// <param name="sender">The HttpApplication</param>
		/// <param name="e">The Sended Event Arguments</param>
		public void MainHandlingSection(object sender, EventArgs e)
		{						
			HttpApplication httpApplication = (HttpApplication) sender;
			
			HttpContext httpContext = HttpContext.Current;
			
			HttpResponse response = httpContext.Response;	

			HttpRequest request = httpContext.Request;

			int _errorcount = 0;
								
			#region Show and Log The Post Body			
			
			if (httpContext.Request.RequestType == "POST")
			{
				if (this.viewStateStatus != null && this.viewStateStatus.Active == true)
				{
					log.Debug("Processing View State Putting It Back");
						ReflectionUtils.makeTheRequestFormDataEditable();	
						string viewState = httpContext.Request.Form[VIEW_STATE_TEXT];
						viewState = this.viewStateStatus.ViewStateStorage.Get(viewState);
						if (viewState != null)
						{
							httpContext.Request.Form[VIEW_STATE_TEXT] = 
								this.viewStateStatus.ViewStateStorage.Get(viewState);						
						}
					log.Debug("End Of View State Process");
				}
				Stream httpStream = httpContext.Request.InputStream;
				StreamReader reader = new StreamReader(httpStream);
				String rawRequest = reader.ReadToEnd();
				log.Debug("The Raw Request To The Application");
				log.Debug("------------------------------------------------------------------------------");
				log.Debug(rawRequest);
				log.Debug("------------------------------------------------------------------------------");
			}

			#endregion

			if (request.Url.ToString().IndexOf(DefenceMainSettings.DEFAULT_PAGE) > 0)
			{
				response.Write(DoLogTable());
				response.End();
			}
			else if (request.Url.ToString().IndexOf(DefenceMainSettings.DEFAULT_REPORT_PAGE) > 0)
			{
				response.Write(HTMLFormatting.getStatusPage());
				response.End();
			}			
			else
			{
				if (log.IsDebugEnabled)
				{
					ReflectionUtils.MakePropertyStringArray(httpApplication.Request);
					log.Debug(request.ContentEncoding.EncodingName);
					log.Debug(request.ContentEncoding.WebName);
					log.Debug(request.ContentEncoding.WindowsCodePage);
				}

				//Checks The Application Encoding For The Non Utf-8 Requests To Fix The Asp.Net Filtering Bug

				bool DoUpperCheck = (request.ContentEncoding.WebName == "utf-8" ? false : true);

				string lasterror = "";

				#region Ip Block Processor				

				if (ipblock == null)
				{
					ipblock = new ArrayList();
					IEnumerator enumerator = blocklist.GetEnumerator();
					while (enumerator.MoveNext())
					{
						if (enumerator.Current is IPRule)
						{
							ipblock.Add(enumerator.Current);
						}
					}
					enumerator = ipblock.GetEnumerator();
					while (enumerator.MoveNext())
					{
						blocklist.Remove(enumerator.Current);
					}
				}
				//Gets The Ip Of The Current Request
				string ClientIP = httpContext.Request.UserHostAddress;

				#endregion

				bool status = false;

				#region The Form Parameter Processor

				if (HandleForms == 1 && (httpContext.Request.RequestType.Equals("POST")))
				{
					log.Info("Begin With The Form Handling");

					for (int formx = 0; formx < httpContext.Request.Form.Count; formx++)
					{
						log.Info("Checking Form Object " + httpContext.Request.Form.GetKey(formx) + "-->" + httpContext.Request.Form[formx]);
						string formPart = OutputConvertors.ClearHalfFullWidth(httpContext.Request.Form[formx], DoUpperCheck);
						Rule oldRule = null;
						if (!CheckValue(formPart,ref lasterror,out oldRule))
						{
							if (oldRule.RuleAction() == (int)Rule.ActionTypes.Warn)
							{
								log.Warn("Invalid Objects has been found according to rule " + lasterror);
							}
							else if (oldRule.RuleAction() == (int)Rule.ActionTypes.Deny)
							{
								log.Error("Invalid Objects has been found according to rule " + lasterror);
								_errorcount++;
								httpContext.AddError(new ValidationException("Invalid Objects has been found according to rule " + lasterror));
							}
							else if (oldRule.RuleAction() == (int)Rule.ActionTypes.Allow)
							{
								log.Info("Invalid Objects has been found according to rule " + lasterror);
								//_errorcount++;
							}
						}
					}
					log.Info("End Of The Form Handling");
				}

				#endregion

				#region The QueryString Processor

				if (HandleQueries == 1 && !(status))
				{
					log.Info("Begin With The Querystring Handling");

					for (int queryx = 0; queryx < httpContext.Request.QueryString.Count; queryx++)
					{											
						string queryPart = OutputConvertors.ClearHalfFullWidth(httpContext.Request.QueryString[queryx], DoUpperCheck);
						Rule oldRule = null;
						if (!CheckValue(queryPart, ref lasterror,out oldRule))
						{							
							if (oldRule.RuleAction() == (int)Rule.ActionTypes.Warn)
							{
								log.Warn("Invalid Objects has been found according to rule " + lasterror);
							}
							else if (oldRule.RuleAction() == (int)Rule.ActionTypes.Deny)
							{
								log.Error("Invalid Objects has been found according to rule " + lasterror);
								_errorcount++;
								httpContext.AddError(new ValidationException("Invalid Objects has been found according to rule " + lasterror));
							}
							else if (oldRule.RuleAction() == (int)Rule.ActionTypes.Allow)
							{
								log.Info("Invalid Objects has been found according to rule " + lasterror);						
							}
						}
					}
					log.Info("End With The Querystring Handling");
				}

				#endregion

				#region The Cookie Processor

				if (HandleCookies == 1 && !(status))
				{
					log.Info("Begin With The Cookie Handling");
					IEnumerator enums = httpContext.Request.Cookies.Keys.GetEnumerator();
					while (enums.MoveNext())
					{
						string key = (string) enums.Current;
						HttpCookie cook = httpContext.Request.Cookies[key];
						log.Info("The Cookie Object To Be Check :" + cook.Name + "--->" + cook.Value);
						string cookiePart = OutputConvertors.ClearHalfFullWidth(cook.Value, DoUpperCheck);
						Rule oldRule = null;
						if (!CheckValue(cookiePart, ref lasterror,out oldRule))
						{
							if (oldRule.RuleAction() == (int)Rule.ActionTypes.Warn)
							{
								log.Warn("Invalid Objects has been found according to rule " + lasterror);
							}
							else if (oldRule.RuleAction() == (int)Rule.ActionTypes.Deny)
							{
								log.Error("Invalid Objects has been found according to rule " + lasterror);
								_errorcount++;
								httpContext.AddError(new ValidationException("Invalid Objects has been found according to rule " + lasterror));
							}
							else if (oldRule.RuleAction() == (int)Rule.ActionTypes.Allow)
							{
								log.Info("Invalid Objects has been found according to rule " + lasterror);						
							}
						}
					}
					log.Info("End With The Cookie Handling");
				}

				#endregion
				
				if (_errorcount>0)
					httpApplication.Response.AddHeader("X-DefAppInformation", "Invalid Object Has Been Found");
				else
					httpApplication.Response.AddHeader("X-DefAppInformation", "Clean Request");
			}
		}

		/// <summary>
		/// The Custom ErrorHandler, which will be used to handle The PreRequests
		/// </summary>
		/// <param name="sender">The HttpApplication</param>
		/// <param name="e">The Sended Event Arguments</param>	
		public void ErrorHandlingSection(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication) sender;
			HttpContext ctx = HttpContext.Current;
			Exception ex = app.Server.GetLastError();			
			string ErrorFormat = Utility.HTMLFormatting.getHtmlError(ex);
			log.Error(ErrorFormat);
			app.Server.ClearError();
			ctx.Response.ClearContent();
			ctx.Response.Write(ErrorFormat);
			ctx.Response.Flush();
			ctx.Response.End();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void EndHandlingSection(object sender,EventArgs e)
		{
			HttpContext ctx = HttpContext.Current;
			
			Convertors.OutputConvertors.ConvertCookiesToHttpOnly(ctx.Response.Cookies);
		}

		/// <summary>
		/// The HandleEnumerator Type
		/// </summary>
		public enum HandleEnumerator
		{
			/// <summary>
			/// The Default None For Enumerators
			/// </summary>
			None = 0,
			/// <summary>
			/// Enables The Setting Without Debugging
			/// </summary>
			True = 1,
			/// <summary>
			/// Disables The Setting
			/// </summary>
			False = 2,
			/// <summary>
			/// Used To Mention Debugging
			/// </summary>
			Debug = 3
		} ;

		/// <summary>
		/// Set The FoundStone Module Activation Status
		/// </summary>
		public bool IsFoundStoneActive
		{
			get { return FoundStoneFilterActive; }
			set { FoundStoneFilterActive = value; }
		}

		/// <summary>
		/// Gives If The Application Is In Debug Mode or Not
		/// </summary>
		public bool IsDebug
		{
			get { return Debug; }
			set { Debug = value; }
		}

		/// <summary>
		/// Gets or Sets The Activation Of The DefApp
		/// </summary>
		public bool IsActive
		{
			get { return ((blocklist.Count > 0) && Active); }
			set { Active = value; }
		}

		/// <summary>
		/// Sets and gets the HandleForms Parameters
		/// </summary>
		public int HandleForms
		{
			get { return handleform; }
			set { handleform = value; }
		}

		/// <summary>
		/// Sets and gets the HandleQueries Parameters
		/// </summary>
		public int HandleQueries
		{
			get { return handlequeries; }
			set { handlequeries = value; }
		}

		/// <summary>
		/// Sets and gets the HandleCookies Parameters
		/// </summary>
		public int HandleCookies
		{
			get { return handlecookie; }
			set { handlecookie = value; }
		}

		/// <summary>
		/// Override For The Default To string Function
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return GeneralUtilities.ToString(this);
		}

		#endregion
	}

	#endregion
}