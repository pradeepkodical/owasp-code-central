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

using System.Text;
using System.Web;
using log4net;

#endregion

namespace Owasp.DefApp.Logging
{
	/// <summary>
	/// Does The Logging For The Foundstone Validation Module
	/// </summary>
	public class LogRequestData
	{
		private StringBuilder messageToDisplay;

		/// <summary>
		/// Sets The ScreenOutput Control
		/// </summary>
		public static bool LogScreenOutput = true;

		private static readonly ILog logger = LogManager.GetLogger(typeof (LogRequestData));

		/// <summary>
		/// 
		/// </summary>
		public LogRequestData()
		{
			messageToDisplay = new StringBuilder();
			messageToDisplay.Append("<hr>");
			messageToDisplay.Append("<font face='Arial'><b><font size='2'>Foundstone HttpModule Asp.Net (using SiteValidator's XML Rules)</Font></b><br>");
			messageToDisplay.Append("<font size='1'>");
			logger.Debug(messageToDisplay.ToString());
		}

		/// <summary>
		/// Add The Entry To The Application Log
		/// </summary>
		/// <param name="entryToAdd">The Entry To Be Added</param>
		public void addEntry(string entryToAdd)
		{
			messageToDisplay.Append("<br> - ");
			messageToDisplay.Append(entryToAdd);
			logger.Debug(messageToDisplay.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		public void outputMessage()
		{
			messageToDisplay.Append("</font>");
			messageToDisplay.Append("</font>");
			messageToDisplay.Append("<hr>");
			if (LogScreenOutput)
			{
				HttpContext.Current.Response.Write(messageToDisplay.ToString());
			}
			logger.Debug(messageToDisplay.ToString());
		}
	}
}