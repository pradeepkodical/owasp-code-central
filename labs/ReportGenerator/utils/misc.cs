using System;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for utils.
	/// </summary>
	public class misc
	{
		public misc()
		{
		}

		public static string getGUID()
		{
			return System.Guid.NewGuid().ToString();
		}
	}
}
