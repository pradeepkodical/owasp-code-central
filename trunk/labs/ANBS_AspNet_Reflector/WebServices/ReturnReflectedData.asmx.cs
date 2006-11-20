/*

Copyright (c) 2004 Free Software Foundation
developed under the custody of the
Open Web Application Security Project
(http://www.owasp.org)
 
This file is part of the OWASP ANBS (Asp.Net Baseline Security) and the OWASP Asp.Net Reflector.

This Tool is free software; you can redistribute it and/or modify it 
under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.
  
This Tool is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Lesser General Public License for more details.
 
The valid license text for this file can be retrieved from the gnu website
(http://www.gnu.org/copyleft/lesser.html)
 
If you are not able to view the LICENSE that way, which should
always be possible within a valid and working Portal release,
please write to the Free Software Foundation, Inc.,
59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
to get a copy of the GNU General Public License or to report a
possible license violation.
 
Author: Dinis Cruz 
dinis@ddplus.net
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using System.Xml;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
 

//using System.Drawing;
//using System.Web.SessionState;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.HtmlControls;

using System.Reflection;

namespace ANBS_AspNet_Reflector
{
	/// <summary>
	/// Summary description for ReturnReflectedData.
	/// </summary>http://192.168.1.254/Fav/ANBS_AspNet_Reflector/
	/// 
	public class reflectedData
	{
			

			public string processedPath;
			public string typeOfReflectedData;
			public string groupTypeOfReflectedData;			

			public string methodInvoked;
			public string methodInvokeResult;

			public ArrayList arrayReflectedData;
	}

	public class FieldData
	{
			public string fieldName;
			public string fieldValue;
	}


	public class ReturnReflectedData : System.Web.Services.WebService
	{
		public ReturnReflectedData()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}
				

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[DllImport("advapi32.dll")] public static extern int RevertToSelf();			

		private BindingFlags ___getCurrentSelectedBindingFlags()
		{
			BindingFlags objTempBindingFlags = new BindingFlags();
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Public;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.NonPublic;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Instance;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Static;
//			objTempBindingFlags = objTempBindingFlags | BindingFlags.DeclaredOnly;
			//objTempBindingFlags = objTempBindingFlags | BindingFlags.FlattenHierarchy;			
			return objTempBindingFlags;
		}

		private string ___createDynamicNavigationList(string unformatedObjectPath)
		{
			string formatedObjectPath = "";
			string pathOfCurrentItem = ""; 
			string[] arrayPathObjects = unformatedObjectPath.Split(';');
			for (int pathItem=0 ; pathItem < arrayPathObjects.Length; pathItem++)
			{
				
				string[] arraySplitedPath =  arrayPathObjects[pathItem].Split(':');
				if (pathItem+1 == arrayPathObjects.Length) 
				{
					formatedObjectPath += arraySplitedPath[0]; 
				}
				else
				{
					pathOfCurrentItem +=  arrayPathObjects[pathItem] + ";";
					string correctedPathOfCurrentItem = pathOfCurrentItem.Substring(0,pathOfCurrentItem.LastIndexOf(":"));
					formatedObjectPath += @"<A href=""javascript: document.all.item('CurrentPath').innerHTML=''; loadAndDynamicallyDisplayDynamicDataUsingDirectPath('"+correctedPathOfCurrentItem+@"');"">" + arraySplitedPath[0] + "</a>   :    ";
				}
			}
			return formatedObjectPath;
		}

		[WebMethod]
		public reflectedData ___ReturnReflectedData_WebService(string stringObjectToReflect)
		{			

			RevertToSelf();

			reflectedData objReflectedData = new reflectedData();
			string stringObjectType = "";
			string stringObjectCategoryOriginal = "";
			string stringObjectCategoryToGet = "";
			
			object objectToReflect = this;						

			if (stringObjectToReflect == "")
			{
				stringObjectToReflect = "this::Properties;" + 
					"Context:Property:Properties;"+
					"Request:Property:Properties";															
			}

			string[] arrayObjectsToReflect = stringObjectToReflect.Split(';');
			for (int intObjectDepth=0 ; intObjectDepth < arrayObjectsToReflect.Length; intObjectDepth++)
			{
				string[] arraySplitObject =  arrayObjectsToReflect[intObjectDepth].Split(':');
				stringObjectType = arraySplitObject[0];
				stringObjectCategoryOriginal = arraySplitObject[1];
				stringObjectCategoryToGet = arraySplitObject[2];
				if (stringObjectType != "this")
				{						
						switch (stringObjectCategoryOriginal )
						{
							case "Members": { break;	}
							case "Property": {
															PropertyInfo objTempType = objectToReflect.GetType().GetProperty(stringObjectType,___getCurrentSelectedBindingFlags() |  BindingFlags.GetProperty); 
															object reflectedObject = objTempType.GetValue(objectToReflect,___getCurrentSelectedBindingFlags()  |  BindingFlags.GetProperty,null,null,null);								
															objectToReflect = reflectedObject;
															break;	}
							case "Method": { 																														
															MethodInfo objTempType = objectToReflect.GetType().GetMethod(stringObjectType,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,null,CallingConventions.Any,new Type[0] {},null); 
															
															object invokeResult = objTempType.Invoke(objectToReflect,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,null,new object[0] {} ,null);								
															objReflectedData.methodInvoked = stringObjectType;
															objReflectedData.methodInvokeResult = invokeResult.ToString();					
																	
								
															return objReflectedData;
					
															break;	}
							case "Field": { 															
															FieldInfo objTempType = objectToReflect.GetType().GetField(stringObjectType,___getCurrentSelectedBindingFlags() |  BindingFlags.GetField); 
															//object reflectedObject = objTempType.GetValue(this.Context);												
															object reflectedObject = objTempType.GetValue(objectToReflect);								
															objectToReflect = reflectedObject;
				
														/* this data is something that I also need to capture since this is information about the this TYPE of object and not of the LIVE object (which contains REAL data)
															object objTempType = objectToReflect.GetType().GetField(stringObjectType,___getCurrentSelectedBindingFlags() |  BindingFlags.GetField); 
															objectToReflect = objTempType;
													*/		
															break;	}
						}																	
				}

			}
			
			
			//			objReflectedData.arrayReflectedData = new ArrayList();

			switch (stringObjectCategoryToGet)					
			{
				case "Members": { objReflectedData =  ___getReflectedMembers_internal(objectToReflect);	break;}
				case "Properties": { objReflectedData =  ___getReflectedProperties_internal(objectToReflect );	break;}
				case "PropertiesWithValues": { objReflectedData =  ___getReflectedPropertiesAndItsValues_internal(objectToReflect );	break;}
				case "Methods": { objReflectedData = ___getReflectedMethods_internal(objectToReflect ); break;}
				case "Fields": { objReflectedData =  ___getReflectedFields_internal(objectToReflect);	break;}
			}
																	
			//objReflectedData.arrayReflectedData.Add("test");

			objReflectedData.processedPath = ___createDynamicNavigationList(stringObjectToReflect);
			return objReflectedData;
		
		}

		public reflectedData ___getReflectedMembers_internal(object objectToReflect)
		{			
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();
			objReflectedData.groupTypeOfReflectedData = "Members";
			objReflectedData.typeOfReflectedData = "Member";
			objReflectedData.arrayReflectedData = new ArrayList();			
			MemberInfo[] objMembersInfo =  objType.GetMembers(___getCurrentSelectedBindingFlags());
			foreach (MemberInfo objMemberInfo in objMembersInfo)
			{
				objReflectedData.arrayReflectedData.Add(objMemberInfo.Name.ToString() + " : " + objMemberInfo.ToString());										
			}
			return objReflectedData;
		}

		private reflectedData ___getReflectedProperties_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();			
			objReflectedData.groupTypeOfReflectedData = "Properties";
			objReflectedData.typeOfReflectedData = "Property";
			objReflectedData.arrayReflectedData = new ArrayList();				
			PropertyInfo[] objPropertiesInfo =  objType.GetProperties(___getCurrentSelectedBindingFlags());
			foreach (PropertyInfo objPropertyInfo in objPropertiesInfo)
			{
				try
				{
					object reflectedObject = objPropertyInfo.GetValue(objectToReflect,___getCurrentSelectedBindingFlags() | BindingFlags.GetProperty,null,null,null);
					
					if (reflectedObject != null)
					{
						objReflectedData.arrayReflectedData.Add(objPropertyInfo.Name.ToString()); //  + "  [" +reflectedObject.ToString() +"]");  // + "  : " + objPropertyInfo.ToString());;						
					}
				}
				catch (Exception objException)
				{
//					objReflectedData.arrayReflectedData.Add("[ERROR '" + objException.Message+ "' RESOLVING :" + objPropertyInfo.Name.ToString()); 
				}
			}
			return objReflectedData;
		}

		public reflectedData ___getReflectedMethods_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();
			objReflectedData.groupTypeOfReflectedData = "Methods";
			objReflectedData.typeOfReflectedData = "Method";
			objReflectedData.arrayReflectedData = new ArrayList();			
			MethodInfo[] objMethodsInfo =  objType.GetMethods(___getCurrentSelectedBindingFlags() | BindingFlags.DeclaredOnly);
			foreach (MethodInfo objMethodInfo in objMethodsInfo)
			{
				string methodName =  objMethodInfo.Name.ToString();
				ParameterInfo[] objParametersInfo = objMethodInfo.GetParameters();
				string methodParameterInformation = "(";
				foreach (ParameterInfo objParameterInfo in objParametersInfo)
				{
					methodParameterInformation += objParameterInfo.ParameterType + " " + objParameterInfo.Name;
					if ((objParameterInfo.Position + 1) < objParametersInfo.Length)
					{
							methodParameterInformation += ",";
					}						
				}
				methodParameterInformation +=")";				
				string completeMethodNameWithHtmlMarkup;
				if (objParametersInfo.Length>0)
				{
					completeMethodNameWithHtmlMarkup = "<b>" +methodName + "</b>" + methodParameterInformation;
				}
				else
				{
					completeMethodNameWithHtmlMarkup = @"<a href=""Javascript:invokeMethod(':Methods;','"+methodName + @"','Method','invokeMethod','methodInvokeResult');""><b>" + objMethodInfo.Name.ToString()+ "</b>" + methodParameterInformation;					
				}
				objReflectedData.arrayReflectedData.Add(completeMethodNameWithHtmlMarkup);
			}
			return objReflectedData;
		}

		public reflectedData ___getReflectedFields_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();
			objReflectedData.groupTypeOfReflectedData = "Fields";
			objReflectedData.typeOfReflectedData = "Field";

			objReflectedData.arrayReflectedData = new ArrayList();				
			FieldInfo[] objFieldsInfo =  objType.GetFields(___getCurrentSelectedBindingFlags());
			foreach (FieldInfo objFieldrInfo in objFieldsInfo)
			{				
				object reflectedObject = objFieldrInfo.GetValue(objectToReflect);
				if (reflectedObject != null)
				{
					FieldData objFieldData = new FieldData();
					objFieldData.fieldName = objFieldrInfo.Name.ToString();
					objFieldData.fieldValue = reflectedObject.ToString();

					objReflectedData.arrayReflectedData.Add(@"<name><td class=""td_verySmall_font""><b>"+ objFieldData.fieldName  +@"</b></td></name><value><td class=""td_verySmall_font""><i>"  + objFieldData.fieldValue+"</i></td></value>");						
				}				
			}
			return objReflectedData;
		}

		private reflectedData ___getReflectedPropertiesAndItsValues_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();			
			objReflectedData.groupTypeOfReflectedData = "Properties";
			objReflectedData.typeOfReflectedData = "Property";
			objReflectedData.arrayReflectedData = new ArrayList();				
			PropertyInfo[] objPropertiesInfo =  objType.GetProperties(___getCurrentSelectedBindingFlags());
			foreach (PropertyInfo objPropertyInfo in objPropertiesInfo)
			{
				try
				{
					object reflectedObject = objPropertyInfo.GetValue(objectToReflect,___getCurrentSelectedBindingFlags() | BindingFlags.GetProperty,null,null,null);
					
					if (reflectedObject != null)
					{
						objReflectedData.arrayReflectedData.Add(@"<name><td class=""td_verySmall_font""><b>" + objPropertyInfo.Name.ToString()+ @"</b></td></name><value><td class=""td_verySmall_font""><i>"  +reflectedObject.ToString() +"</i></td></value>");
					}
				}
				catch (Exception objException)
				{
					//					objReflectedData.arrayReflectedData.Add("[ERROR '" + objException.Message+ "' RESOLVING :" + objPropertyInfo.Name.ToString()); 
				}
			}
			return objReflectedData;
		}
	}
}
