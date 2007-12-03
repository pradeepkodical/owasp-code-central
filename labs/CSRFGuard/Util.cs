using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace org.owasp.csrfguard
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{

		public static void LogSecurityViolation(String message)
		{
			// TODO:  Implement logging.  Ultimately, this should be overrideable by your own logging method
			EventLog log = new EventLog();
			log.Source = "Intercepting Filter Pattern";
			log.WriteEntry(message, EventLogEntryType.Information);
		}

		public static String generateToken(int numBytes)
		{
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] randBytes = new byte[numBytes];

			rng.GetBytes(randBytes);
			return bytesToHexString(randBytes);
		}

		public static String bytesToHexString(byte[] bytes)
		{
			StringBuilder hex = new StringBuilder((bytes.Length/8)*2);

			for (int i = 0; i < bytes.Length; i++)
			{
				hex.Append(String.Format("{0:X2}", bytes[i]));
			}
			return hex.ToString();
		}

		/// <summary>
		/// 
		/// Adapted from http://www.west-wind.com/presentations/configurationclass/configurationclass.asp
		/// 
		/// Sets the value of a field or property via Reflection. This method alws 
		/// for using '.' syntax to specify objects multiple levels down.
		/// 
		/// Util.SetPropertyEx(this,"Invoice.LineItemsCount",10)
		/// 
		/// which would be equivalent of:
		/// 
		/// this.Invoice.LineItemsCount = 10;
		/// </summary>
		/// <param name="Object Parent">
		/// Object to set the property on.
		/// </param>
		/// <param name="String Property">
		/// Property to set. Can be an object hierarchy with . syntax.
		/// </param>
		/// <param name="Object Value">
		/// Value to set the property to
		/// </param>
		public static object SetPropertyEx(object Parent, string Property, object Value)
		{
			Type Type = Parent.GetType();
			MemberInfo Member = null;

			// *** no more .s - we got our final object
			int lnAt = Property.IndexOf(".");
			if (lnAt < 0)
			{
				Member = Type.GetMember(Property, BindingFlags.Public | BindingFlags.NonPublic | 
					BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase)[0];
				if (Member.MemberType == MemberTypes.Property)
				{
					((PropertyInfo) Member).SetValue(Parent, Value, null);
					return null;
				}
				else
				{
					((FieldInfo) Member).SetValue(Parent, Value);
					return null;
				}
			}

			// *** Walk the . syntax
			string Main = Property.Substring(0, lnAt);
			string Subs = Property.Substring(lnAt + 1);
			Member = Type.GetMember(Main, BindingFlags.Public | BindingFlags.NonPublic | 
				BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase)[0];

			object Sub;
			if (Member.MemberType == MemberTypes.Property)
				Sub = ((PropertyInfo) Member).GetValue(Parent, null);
			else
				Sub = ((FieldInfo) Member).GetValue(Parent);

			// *** Recurse until we get the lowest ref
			SetPropertyEx(Sub, Subs, Value);
			return null;
		}


        public static String captureFromStartToStopChar(String str, int start, char startchar, char endchar)
        {
            bool capturingText = false;
            bool gotEnd = false;

            StringBuilder sb = new StringBuilder();

            for (int i = start; i < str.Length; i++)
            {

                // it's stupid that c# switch statements require CONSTANTS.  Blame MS for how ugly this is.
                if (str[i] == startchar)
                {
                    if (capturingText && !gotEnd)
                    {
                        // this is an error.  We got a duplicate startchar before an endchar
                        // TODO:  probably need to throw a parsing exception
                    }
                    else
                    {
                        capturingText = true;
                        sb.Append(str[i]);
                    }
                }
                else if (str[i] == endchar)
                {
                    sb.Append(str[i]);
                    capturingText = false;
                    gotEnd = true;
                    break;  // break out of loop
                }
                else
                {
                    if (capturingText)
                    {
                        // not a start or end character so add it
                        sb.Append(str[i]);
                    }
                }
            }
            // if we ever get here, we did not find an end delimiter so just return what we have
            return sb.ToString();
        }
	}
}