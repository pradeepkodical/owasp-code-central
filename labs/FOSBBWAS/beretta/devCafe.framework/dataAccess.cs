/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: data access base class
 */
 

using System;
using System.Configuration;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for dataAccess.
	/// </summary>
	public abstract class dataAccess
	{
		protected static string mStrConn="" + settings.connectionString;

		public dataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
