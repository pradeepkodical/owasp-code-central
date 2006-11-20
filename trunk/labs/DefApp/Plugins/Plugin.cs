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
using System.Reflection;
using log4net;
using Owasp.DefApp.Rules;
using Owasp.DefApp.Utility;

#endregion

namespace Owasp.DefApp.Plugins
{
	#region Plugin Interface Declaration

	/// <summary>
	/// Declares The Plugin Interface That Should Be Implemented By The Plugins
	/// </summary>
	public abstract class DefAppPlugin
	{
		/// <summary>
		/// The Given Name Of The Plugin
		/// </summary>
		/// <returns>The Plugin Name</returns>
		public abstract string PluginName();

		/// <summary>
		/// The Given Name Of The Filters
		/// </summary>
		/// <returns></returns>
		public abstract ArrayList DefinedFilters();

		/// <summary>
		/// Whole Rule Objects Implemented By The Plugin Object
		/// </summary>
		/// <returns>Whole Rule Objects</returns>
		public abstract ArrayList DefinedRules();

		/// <summary>
		/// Returns The Given Rule Named Rule Object
		/// </summary>
		/// <param name="rulename">Rule Name To Be Used</param>
		/// <returns>The Found Rule Object</returns>
		public abstract Rule GetRuleByName(string rulename);

		//public abstract Filter GetFilterByName(string filtername);

		private static readonly ILog log = LogManager.GetLogger(typeof (DefAppPlugin));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AssemblyName"></param>
		/// <param name="maxCount"></param>
		/// <param name="ary"></param>
		/// <returns></returns>
		public static ArrayList XmlToPlugin(string AssemblyName, int maxCount, ArrayList ary)
		{
			ArrayList plugIns = null;
			if (ary == null)
				new ArrayList();
			else
				plugIns = ary;
			Assembly assembly = Assembly.LoadFile(AssemblyName);
			Type[] types = null;
			int Count = 0;
			try
			{
				types = assembly.GetTypes();
			}
			catch (Exception ex)
			{
			}
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].IsClass && types[i].IsPublic && types[i].IsSubclassOf(typeof (DefAppPlugin)))
				{
					DefAppPlugin.log.Info(types[i].Namespace + "." + types[i].Name);
					Object obj = Activator.CreateInstance(types[i], null);
					if (!GeneralUtilities.IsNull(obj))
					{
						plugIns.Add(obj);
						Count++;
					}
					if (Count >= maxCount)
						return plugIns;
				}
			}
			return plugIns;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AssemblyName"></param>
		/// <returns></returns>
		public static DefAppPlugin XmlToPlugin(string AssemblyName)
		{
			Assembly assembly = Assembly.LoadFile(AssemblyName);
			Type[] types = null;
			try
			{
				types = assembly.GetTypes();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].IsClass && types[i].IsPublic && types[i].IsSubclassOf(typeof (DefAppPlugin)))
				{
					DefAppPlugin.log.Info(types[i].Namespace + "." + types[i].Name);
					Object obj = Activator.CreateInstance(types[i], null);
					if (!GeneralUtilities.IsNull(obj))
					{
						return (DefAppPlugin) obj;
					}
				}
			}
			return null;
		}
	}

	#endregion
}