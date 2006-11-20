#region Licence Information

// The General Tools For Asp.Net Applications
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
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Xml;
using log4net;

#endregion

namespace Owasp.DefApp.Utility
{
	/// <summary>
	/// General Used Functions
	/// </summary>
	public sealed class GeneralUtilities
	{
		/// <summary>
		/// The Private Constructor To Prevent Initialization
		/// </summary>
		private GeneralUtilities()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static String makeNormalLog(HttpRequest request)
		{
			StringBuilder builder = new StringBuilder();

			return builder.ToString();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static String makeHTMLLog(HttpRequest request)
		{
			return "";
		}

		private static readonly ILog logger = LogManager.GetLogger(typeof (GeneralUtilities));

		/// <summary>
		/// Check if the given object is Null or Not Checking With The Parameters
		/// </summary>
		/// <param name="obj">The Object To Be Tested</param>
		/// <returns></returns>
		public static bool IsNull(Object obj)
		{
			if (obj != null)
			{
				if (obj is string)
				{
					if (((string) obj) == "")
						return true;
				}
				return false;
			}
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <returns></returns>
		public static bool CheckNode(XmlNode Node)
		{
			return ((Node != null && Node.ChildNodes != null) ? true : false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static bool CheckString(string values)
		{
			return ((values != null && values.Trim().Length > 0) ? true : false);
		}

		/// <summary>
		/// Used To Create A String For The Objects Properties
		/// </summary>
		/// <param name="Obj"></param>
		public static string ToString(Object Obj)
		{
			StringBuilder toStringResult = new StringBuilder();
			MethodInfo[] methods =
				Obj.GetType().GetMethods();
			for (int i = 0; i < methods.Length; i++)
			{
				if (methods[i].ReturnType.ToString() != "System.Void" && methods[i].Name != "ToString")
				{
					if (methods[i].GetParameters() == null || methods[i].GetParameters().Length == 0)
					{
						toStringResult.Append(Obj.GetType().Name);
						toStringResult.Append("-->");
						toStringResult.Append(methods[i].Name);
						toStringResult.Append("-->");
						toStringResult.Append(methods[i].Invoke(Obj, null));
						toStringResult.Append("\r\n");
					}
				}
			}
			FieldInfo[] inform = Obj.GetType().GetFields();
			for (int i = 0; i < inform.Length; i++)
			{
				toStringResult.Append(Obj.GetType().Name);
				toStringResult.Append("-->");
				toStringResult.Append(inform[i].Name);
				toStringResult.Append("-->");
				toStringResult.Append(inform[i].GetValue(Obj));
				toStringResult.Append("\r\n");
			}
			return toStringResult.ToString();
		}

	}

	/// <summary>
	/// Utilities Used In The Reflection
	/// </summary>
	public sealed class ReflectionUtils
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof (GeneralUtilities));

		private ReflectionUtils()
		{
		}

		
		/// <summary>
		/// Returns The NameSpace Of The Given Object
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static String DetectNamespace(Object obj)
		{
			return obj.GetType().Namespace;
		}


		/// <summary>
		/// Converts The Properties Into a String Representation
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static String MakePropertyStringArray(Object obj)
		{
			PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			StringBuilder builders = new StringBuilder();
			for (int i = 0; i < properties.Length; i++)
			{
				MethodInfo methodsInfo = properties[i].GetGetMethod();
				if (methodsInfo.GetParameters().Length == 0)
				{
					builders.Append(properties[i].GetGetMethod().Name.Replace("get_", ""));
					builders.Append("------>");
					builders.Append(properties[i].GetValue(obj, null));
					builders.Append("\r\n");
				}
			}
			logger.Debug(builders.ToString());
			return builders.ToString();
		}
		

		/// <summary>
		/// Makes The Given Object Writeable
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		public static bool makeObjectEditable(object Obj)
		{
			try
			{
				logger.Info("Begin With Making Writeable Of The Request.Form");
				object objectToReflect = Obj;
				string stringObjectType = "MakeReadWrite";
				MethodInfo objTempMethodType = objectToReflect.GetType().GetMethod(
					stringObjectType, BindingFlags.Public | BindingFlags.NonPublic |
					BindingFlags.Instance, null, CallingConventions.Any, new Type[0] {}, null);
				object invokeResult = objTempMethodType.Invoke(
					objectToReflect, BindingFlags.Public | BindingFlags.NonPublic |
					BindingFlags.Instance | BindingFlags.InvokeMethod, null, new object[0] {}, null);
				logger.Info("The Request.Form has been made writeable");
				return true;
			}
			catch (Exception ex)
			{
				logger.Error("The Request.Form making writeable process has been failed", ex);
				return false;
			}
		}
		
		
		/// <summary>
		/// Makes The QueryString Collection Editable
		/// </summary>
		/// <returns></returns>
		public static bool makeTheQueryStringDataEditable()
		{
			return makeObjectEditable(HttpContext.Current.Request.QueryString);
		}
		

		/// <summary>
		/// Makes The Request Collection Editable
		/// </summary>
		/// <returns></returns>
		public static bool makeTheRequestFormDataEditable()
		{
			return makeObjectEditable(HttpContext.Current.Request.Form);
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool makeTheHeadersEditable()
		{
			return makeObjectEditable(HttpContext.Current.Request.Headers);
		}


		/// <summary>
		/// Gets The MemberInformation Of The Objects
		/// </summary>
		/// <returns></returns>
		public static MemberInfo[] GetMemberInformation()
		{
			Assembly sysAssm = Assembly.LoadFrom("System.dll");
			// Create a Type array and retrieve all the types
			// supported in the assembly.
			Type[] sysTypes = sysAssm.GetTypes();
			logger.Info(("There are " + sysTypes.Length + " types in this assembly."));
			// Examine each type in the Type array.
			MemberInfo[] memArray = null;
			foreach (Type sysType in sysTypes)
			{
				// Create a member array for a type and get
				// all of the members found in the type.
				memArray = sysType.GetMembers();
				// Examine each member and display the
				// information in a message box.
				/*
					for (int i=0; i < memArray.Length; i++)
					{
					
						MessageBox.Show ("Member " +
						memArray[i].Name +
						" has a type of " +
						memArray[i].MemberType.ToString() +
						".");
					}
					*/
			}
			return memArray;
		}


		/// <summary>
		/// Does The Reflection
		/// </summary>
		/// <returns></returns>
		public static bool DoReflection()
		{
			Assembly myAssm = Assembly.LoadFrom("HelloWorld.exe");
			Type asmType = myAssm.GetType("HelloWorld.MainForm");
			Type[] asmTypes = myAssm.GetTypes();
			MemberInfo[] typeMembers = asmType.GetMembers();
			return false;
		}


		/// <summary>
		/// Detects If Com Objects can be created
		/// </summary>
		/// <returns></returns>
		public static bool IsComAllowed()
		{
			Thread.CurrentThread.ApartmentState = ApartmentState.STA;
			object objWSH = null;
			try
			{
				objWSH = HttpContext.Current.Server.CreateObject("WSCRIPT.SHELL");
			}
			catch (SecurityException sec)
			{
				logger.Info("Security Level not sufficiend", sec);
				return false;
			}
			catch
			{
			}
			objWSH = null;
			return true;
		}

		
		/// <summary>
		/// Returns The ClassName Of The Executing Page Object
		/// </summary>
		/// <returns></returns>
		public static string resolvePageClassName()
		{
			string resolvedPageClassName = "";
			try
			{
			string localPathToFile = HttpContext.Current.Request.PhysicalPath;
			StreamReader objStreamReader = new StreamReader(localPathToFile);
			string fileContents = objStreamReader.ReadToEnd();
				string ASPNETpageDirective = fileContents.Substring(fileContents.IndexOf("<%@ Page"), fileContents.IndexOf("%>"));
				int InheritsPosition = ASPNETpageDirective.IndexOf("Inherits");
				if (-1 < InheritsPosition)
				{
					int firstQuotePos = ASPNETpageDirective.IndexOf("\"", ASPNETpageDirective.IndexOf("Inherits"));
					int secondQuotePos = ASPNETpageDirective.IndexOf("\"", firstQuotePos + 1);
					string completePageClassName = ASPNETpageDirective.Substring(firstQuotePos + 1, secondQuotePos - firstQuotePos - 1);
					resolvedPageClassName = completePageClassName.Substring(completePageClassName.LastIndexOf(".") + 1, completePageClassName.Length - completePageClassName.LastIndexOf(".") - 1);
				}
			}
			catch
			{
			}
			return resolvedPageClassName;
		}

	}

	/// <summary>
	/// 
	/// </summary>
	public sealed class HttpAccess
	{
		private HttpAccess()
		{
		}
	}

	/// <summary>
	/// Includes Methods For The Resource File Access and Control
	/// </summary>
	public sealed class ResourceUtilities
	{
		private string _resourceName;

		public ResourceUtilities(string ResourceName)
		{
			this._resourceName = ResourceName;
			ResourceReader reader = new ResourceReader("../Resources/defappresources.resx");
		}
		public static string ReadResource(string ResourceName,string key)
		{
			ResourceReader reader = new ResourceReader(ResourceName);
			System.Collections.IDictionaryEnumerator dictEnum =
			reader.GetEnumerator();
			while(dictEnum.MoveNext())
			{
				if ((string)dictEnum.Key == key)
					return (string)dictEnum.Value;
			}
			return "";
		}
		private ResourceUtilities()
		{
			ResourceManager rm = ResourceManager.CreateFileBasedResourceManager("ApplicationResources","/Resources",null);
		}
	}

	public sealed class HTMLFormatting
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static string getStatusPage()
		{
			string[] resourceNames =
				Assembly.GetExecutingAssembly().GetManifestResourceNames();
			for (int i=0;i<resourceNames.Length;i++)
			{
				if (resourceNames[i].IndexOf("DefAppStatus") > 0)
				{					
					StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceNames[i]));
					return reader.ReadToEnd();
				}
			}			
			return "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Ex"></param>
		/// <returns></returns>
		public static string getHtmlError(Exception Ex)
		{
			// Heading Template
			const string heading = "<TABLE BORDER=\"0\" WIDTH=\"100%\" CELLPADDING=\"1\" CELLSPACING=\"0\"><TR><TD bgcolor=\"black\" COLSPAN=\"2\"><FONT face=\"Arial\" color=\"white\"><B> <!--HEADER--></B></FONT></TD></TR></TABLE>";
			// Error Message Header
			string html = "<FONT face=\"Arial\" size=\"5\" color=\"red\">Error - " + Ex.Message + "</FONT><BR><BR>";
			/*// User Information
			html += "<BR><BR>" + heading.Replace("<!--HEADER-->", "User Information");
			NameValueCollection UserInfo = new NameValueCollection();
			UserInfo.Add("UserName", cleanHTML(Ex.Message));
			html += CollectionToHtmlTable(UserInfo);*/
			// Populate Error Information Collection
			NameValueCollection error_info = new NameValueCollection();
			error_info.Add("Message", cleanHTML(Ex.Message));
			error_info.Add("Source", cleanHTML(Ex.Source));
			error_info.Add("TargetSite", cleanHTML(Ex.TargetSite.ToString()));
			error_info.Add("StackTrace", cleanHTML(Ex.StackTrace));
			error_info.Add("All", cleanHTML(Ex.ToString()));
			// Error Information
			html += heading.Replace("<!--HEADER-->", "Error Information");
			html += CollectionToHtmlTable(error_info);
			// QueryString Collection
			html += "<BR><BR>" + heading.Replace("<!--HEADER-->", "QueryString Collection");
			html += CollectionToHtmlTable(HttpContext.Current.Request.QueryString);
			// Form Collection
			html += "<BR><BR>" + heading.Replace("<!--HEADER-->", "Form Collection");
			html += CollectionToHtmlTable(HttpContext.Current.Request.Form);
			// Cookies Collection
			html += "<BR><BR>" + heading.Replace("<!--HEADER-->", "Cookies Collection");
			html += CollectionToHtmlTable(HttpContext.Current.Request.Cookies);
			// Server Variables
			html += "<BR><BR>" + heading.Replace("<!--HEADER-->", "Server Variables");
			html += CollectionToHtmlTable(HttpContext.Current.Request.ServerVariables);
			return html;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		private static string CollectionToHtmlTable(NameValueCollection collection)
		{
			// <TD>...</TD> Template
			const string TD = "<TD><FONT face=\"Arial\" size=\"2\"><!--VALUE--></FONT></TD>";
			// Table Header
			string html = "\n<TABLE width=\"100%\">\n"
				+ " <TR bgcolor=\"#C0C0C0\">" + TD.Replace("<!--VALUE-->", " <B>Name</B>")
				+ " " + TD.Replace("<!--VALUE-->", " <B>Value</B>") + "</TR>\n";
			// No Body? -> N/A
			if (collection.Count == 0)
			{
				collection = new NameValueCollection();
				collection.Add("N/A", "");
			}
			// Table Body
			for (int i = 0; i < collection.Count; i++)
			{
				html += "<TR valign=\"top\" bgcolor=\"" + ((i%2 == 0) ? "white" : "#EEEEEE") + "\">"
					+ TD.Replace("<!--VALUE-->", collection.Keys[i]) + "\n"
					+ TD.Replace("<!--VALUE-->", collection[i]) + "</TR>\n";
			}
			// Table Footer
			return html + "</TABLE>";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		private static string CollectionToHtmlTable(HttpCookieCollection collection)
		{
			// Overload for HttpCookieCollection collection.
			// Converts HttpCookieCollection to NameValueCollection
			NameValueCollection NVC = new NameValueCollection();
			foreach (string item in collection) NVC.Add(item, collection[item].Value);
			return CollectionToHtmlTable(NVC);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		private static string CollectionToHtmlTable(HttpSessionState collection)
		{
			// Overload for HttpSessionState collection.
			// Converts HttpSessionState to NameValueCollection
			NameValueCollection NVC = new NameValueCollection();
			foreach (string item in collection) NVC.Add(item, collection[item].ToString());
			return CollectionToHtmlTable(NVC);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Html"></param>
		/// <returns></returns>
		private static string cleanHTML(string Html)
		{
			// Cleans the string for HTML friendly display
			return (Html.Length == 0) ? "" : Html.Replace("<", "<").Replace("\r\n", "<BR>").Replace("&", "&amp;").Replace(" ", " ");
		}
	}
}