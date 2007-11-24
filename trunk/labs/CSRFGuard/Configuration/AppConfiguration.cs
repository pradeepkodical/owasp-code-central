using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Web;
using System.Xml;

namespace org.owasp.csrfguard
{
	/// <summary>
	/// Summary description for AppConfiguration.
	/// 
	/// Adapted from a version found at:  http://www.west-wind.com/presentations/configurationclass/configurationclass.asp, November 17, 2007
	/// </summary>
	public abstract class AppConfiguration
	{
		#region Fields
		/// <summary>
		/// Internally held value that holds the Section to read and write from
		/// </summary>
		private string _ConfigSectionName = "appSettings";	// default value that can be overridden
		#endregion
		
		public AppConfiguration(string configFilename)
		{
			ReadKeysFromConfig(configFilename);
		}

		protected AppConfiguration()
		{
			throw new NotImplementedException();
		}

		#region Methods
		public void ReadKeysFromConfig(string configFilename)
		{
			MemberInfo[] Fields = GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
			XmlDocument xmlDoc = new XmlDocument();

			// TODO:  try/catch for permissions or missing file probs
			if (configFilename.IndexOf('\\') < 0)
			{
				// fix up bare filename to point to the directory where the assembly lives
				configFilename = string.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", "")), configFilename);	
			}
			xmlDoc.Load(configFilename);

			foreach (MemberInfo Member in Fields)
			{
				// loop variables
				string TypeName = null;
				FieldInfo Field = null;
				PropertyInfo Property = null;
				String Fieldname = null;
				String Value = null;

				if (Member.MemberType == MemberTypes.Field)
					Field = (FieldInfo) Member;
				else if (Member.MemberType == MemberTypes.Property)
					Property = (PropertyInfo) Member;
				else
					continue;	// skip over other Types in this class

				// Process the Field or Property
				if (Field != null)
					TypeName = Field.FieldType.Name.ToLower();
				else
					TypeName = Property.PropertyType.Name.ToLower();

				Fieldname = Member.Name;
				if (null == (Value = GetNamedValueFromXml(xmlDoc, Fieldname, _ConfigSectionName)))
				{
					continue;	// skip missing config items; TODO:  collect a message list of missing config properties
				}

				Fieldname = Fieldname.ToLower();

				// set the values for the Fields/Properties in the subclass, using reflection
				if (TypeName == "string")
					Util.SetPropertyEx(this, Fieldname, Value);
				else if (TypeName.StartsWith("int"))
					Util.SetPropertyEx(this, Fieldname, Convert.ToInt32(Value));
				else if (TypeName == "boolean")
					if (Value.ToLower() == "true")
						Util.SetPropertyEx(this, Fieldname, true);
					else
						Util.SetPropertyEx(this, Fieldname, false);
				else if (TypeName == "datetime")
					Util.SetPropertyEx(this, Fieldname, Convert.ToDateTime(Value));
				else if (TypeName == "decimal")
					Util.SetPropertyEx(this, Fieldname, Convert.ToDecimal(Value));
				else if (TypeName == "byte")
					Util.SetPropertyEx(this, Fieldname, Convert.ToByte(Value));
				else if (TypeName == "float")
					Util.SetPropertyEx(this, Fieldname, Convert.ToDouble(Value));
				else if (TypeName == "double")
					Util.SetPropertyEx(this, Fieldname, Convert.ToDouble(Value));
				else if (TypeName == "arraylist")	// pipe-separated.  Maybe could allow for changing the delimeter...
				{
					ArrayList al = new ArrayList();   
					al.AddRange(Value.Split(new Char[]{'|'}));
					Util.SetPropertyEx(this, Fieldname, al);
				}
				else if (Field != null && Field.FieldType.IsEnum)
					Util.SetPropertyEx(this, Fieldname, Enum.Parse(Field.FieldType, Value));
				else if (Property != null && Property.PropertyType.IsEnum)
					Util.SetPropertyEx(this, Fieldname, Enum.Parse(Property.PropertyType, Value));
				else
				{
					// for debugging -- dump out unimplemented types that need to be coded above.
					HttpContext.Current.Response.Write("Unknown type:  " + TypeName);
				}
			}
		}

		/// <summary>
		/// Adapted from http://www.west-wind.com/presentations/configurationclass/configurationclass.asp, November 17, 2007
		/// </summary>
		/// <param name="xmlDoc"></param>
		/// <param name="Key"></param>
		/// <param name="ConfigSection"></param>
		/// <returns></returns>
		private string GetNamedValueFromXml(XmlDocument xmlDoc, string Key, string ConfigSection)
		{
			XmlNode Node = xmlDoc.SelectSingleNode(@"/configuration/" + ConfigSection + @"/add[@key='" + Key + "']");
			if (Node == null)
				return null;

			return Node.Attributes["value"].Value;
		}
		#endregion
	}
}