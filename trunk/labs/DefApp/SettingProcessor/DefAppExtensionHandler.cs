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

using System.Web;
using System.Web.SessionState;

#endregion

namespace Owasp.DefApp
{
	#region HttpHandler For The DefApp Application

	internal class DefenceHandlers : IRequiresSessionState, IHttpHandler
	{
		#region IHttpHandler Members

		public void ProcessRequest(HttpContext context)
		{
		}

		public bool IsReusable
		{
			get { return false; }
		}

		#endregion
	}

	#endregion
}