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

using System.Collections;
using System.Runtime.InteropServices;
using log4net.Appender;
using log4net.Layout;
using log4net.spi;

#endregion

namespace Owasp.DefApp.Appenders
{
	/// <summary>
	/// Summary description for HttpAppender.
	/// </summary>
	[ComVisible(false)]
	public class HttpAppender : AppenderSkeleton
	{
		private static ArrayList ary = ArrayList.Synchronized(new ArrayList());

		/// <summary>
		/// The Default Constructor For The HttpAppender Class
		/// </summary>
		public HttpAppender() : base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="arrays"></param>
		public HttpAppender(ArrayList arrays) : base()
		{
			ary = ArrayList.Synchronized(arrays);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="layout"></param>
		/// <param name="arrays"></param>
		public HttpAppender(ILayout layout, ArrayList arrays)
		{
			Layout = layout;
			ary = ArrayList.Synchronized(arrays);
		}

		/// <summary>
		/// 
		/// </summary>
		public ArrayList Results
		{
			get { return ary; }
		}

		/// <summary>
		/// This appender requires a to be set.
		/// </summary>
		/// <value><c>true</c></value>
		protected override bool RequiresLayout
		{
			get { return true; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="loggingEvent"></param>
		protected override void Append(LoggingEvent loggingEvent)
		{
			string values = RenderLoggingEvent(loggingEvent);
			ary.Add(values);
		}
	}
}