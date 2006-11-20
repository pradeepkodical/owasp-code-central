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
using System.Configuration;
using System.Web;
using System.Xml;
using log4net;
using Owasp.DefApp.MSValidator;
using Owasp.DefApp.Utility;
using Owasp.DefApp.Utils.StreamFilters;

#endregion

namespace Owasp.DefApp
{
	#region The Main Application HttpModule To Be Used To Declare DefApp To The Web Application

	/// <summary>
	/// The Main Application HttpModule To Be Used To Declare DefApp To The Web Application
	/// </summary>
	public class DefenceModules : IHttpModule
	{
		private string FS_HttpModule_XMLRulesDatabase;
		private string FS_HttpModule_Validator_FormMappings;
		private string FS_HttpModule_Validator_Rules;

		private DefenceMainSettings main;

		private static readonly ILog log = LogManager.GetLogger(typeof (DefenceModules));

		/// <summary>
		/// The Default Constructor Of The DefenceModule
		/// </summary>
		public DefenceModules()
		{
		}

		/// <summary>
		/// Used To Initialize The DefApp reading the values from the web.config sections
		/// </summary>
		/// <param name="application">The HttpApplication which initializes the module</param>
		public void Init(HttpApplication application)
		{
			try
			{
				parseConfigurations();
				loadXmlValidatorRules(main);
				if (main.IsActive)
				{
					log.Info("BeginRequest Handler For The Application added.");
					//Checks The Begin Request Event For Attacks										
					application.BeginRequest += new EventHandler(main.MainHandlingSection);
					//The Output Responses and Modifications Are Handled Here
					application.PreSendRequestHeaders += new EventHandler(application_PreSendRequestHeaders);
					application.ReleaseRequestState += new EventHandler(main.application_ReleaseRequestState);
					application.EndRequest += new EventHandler(main.ContentHandlingSection);
					//The End Of The Request Is Controlled Here
					if (main.IsFoundStoneActive)
					{
						log.Info("BeginRequest Handler For Dinis Filters added.");
						application.BeginRequest += (new EventHandler(ProcessRequest.ProcessRequest_Handler));
					}
					//log.Info("ErrorHandler For The Application added.");
					//The Error Handler Is Added Here
					//application.Error += new EventHandler(main.ErrorHandlingSection);
				}
				else
				{
					log.Info("No Handlers For The Application has been created.");
					log.Info("Disposing The DefAppModule");
					this.Dispose();
				}
			}
			catch (Exception ex)
			{
				log.Error("Error has occurred while starting DefApp. Please Check Your Settings. DefApp Disabled.", ex);
				this.Dispose();
			}
		}

		/// <summary>
		/// Parses The Configurations From The Web.Config File
		/// </summary>
		private void parseConfigurations()
		{
			main = (DefenceMainSettings) ConfigurationSettings.GetConfig("AppSec/AppGenerals");
			log.Info("Mapping Of The Configuration Files Has Been Finished");
			ReflectionUtils.IsComAllowed();
		}

		/// <summary>
		/// Disposes The Main Application
		/// </summary>
		public void Dispose()
		{
			main = null;
			GC.Collect();
		}

		#region Private Configuration Processors For The Foundstone Module

		private void loadXmlValidatorRules(DefenceMainSettings main)
		{
			if (main.IsFoundStoneActive)
			{
				FS_HttpModule_XMLRulesDatabase = main.FS_HttpModule_XMLRulesDatabase;
				FS_HttpModule_Validator_FormMappings = main.FS_HttpModule_Validator_FormMappings;
				FS_HttpModule_Validator_Rules = main.FS_HttpModule_Validator_Rules;
				string resolvedAddressOf_Validator_FormMappings = AppDomain.CurrentDomain.BaseDirectory + "/" + FS_HttpModule_XMLRulesDatabase + "/" + FS_HttpModule_Validator_FormMappings;
				string resolvedAddressOf_Validator_Rules = AppDomain.CurrentDomain.BaseDirectory + "/" + FS_HttpModule_XMLRulesDatabase + "/" + FS_HttpModule_Validator_Rules;

				ProcessRequest.xmlFile_Validator_FormMappings.Load(resolvedAddressOf_Validator_FormMappings);
				ProcessRequest.xmlFile_Validator_Rules.Load(resolvedAddressOf_Validator_Rules);

				loadPagesToProcessList();
				convertValidatorFormMappingsXML_into_Hashtable();
				convertValidatorRulesMappingsXML_into_Hashtable();
			}
		}

		private void loadPagesToProcessList()
		{
			foreach (XmlNode objXmlNode in ProcessRequest.xmlFile_Validator_FormMappings.DocumentElement.ChildNodes[0].ChildNodes)
			{
				string pageFormName = objXmlNode.Attributes["FormName"].InnerText;
				ProcessRequest.pagesToProcess.Add(pageFormName);
			}
		}

		private void convertValidatorFormMappingsXML_into_Hashtable()
		{
			foreach (XmlNode objXmlNode in ProcessRequest.xmlFile_Validator_FormMappings.DocumentElement.ChildNodes[0].ChildNodes)
			{
				string pageFormName = objXmlNode.Attributes["FormName"].InnerText;
				ProcessRequest.hashtableWithValidator_FormMappings.Add(pageFormName, objXmlNode);
			}
		}

		private void convertValidatorRulesMappingsXML_into_Hashtable()
		{
			foreach (XmlNode objXmlNode in ProcessRequest.xmlFile_Validator_Rules.DocumentElement.ChildNodes)
			{
				string ruleName = objXmlNode.Attributes["name"].InnerText;
				ProcessRequest.hashtableWithValidator_FormRules.Add(ruleName, objXmlNode);
			}
		}

		#endregion

		private void application_PreSendRequestHeaders(object sender, EventArgs e)
		{

		}
		
	}

	#endregion
}