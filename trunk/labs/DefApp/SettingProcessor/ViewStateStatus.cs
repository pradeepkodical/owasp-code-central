using System.Collections.Specialized;

namespace Owasp.DefApp.SettingProcessor
{
	/// <summary>
	/// Holds The Values For The ViewState Encoding
	/// </summary>
	public class ViewStateStatus
	{
		/// <summary>
		/// Holds The Viewstate Replacements Inside
		/// </summary>
		private NameValueCollection NVCollection;
		
		public enum Method			
		{
			MD5 = 0,
			SHA1 = 1,
			GUID = 2,
			NONE = 3
		} ;
		
		private bool active;
		
		private Method method;

		public Method GetActiveMethod()
		{
			return method;
		}

		public ViewStateStatus(bool active,Method method)
		{
			this.method = method;
			this.active = active;
			NVCollection = new NameValueCollection();
		}

		public NameValueCollection ViewStateStorage
		{
			get { return NVCollection; }
		}

		public bool Active
		{
			get { return active; }
		}
	}
}