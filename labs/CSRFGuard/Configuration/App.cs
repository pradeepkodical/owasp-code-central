namespace org.owasp.csrfguard
{
	/// <summary>
	/// Basic class used to access config parameters from a single static instance
	/// </summary>
	public class App
	{
		public static CSRFGuardConfiguration Configuration;

		static App()
		{
			Configuration = new CSRFGuardConfiguration("CSRFGuard.config");                
		}
	}
}
