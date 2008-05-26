namespace Org.Owasp.CsrfGuard
{
    /// <summary>
    /// Basic class used to access config parameters from a single static instance
    /// </summary>
    public class App
    {
        public static CSRFGuardConfiguration Configuration = new CSRFGuardConfiguration("CSRFGuard.config");
    }
}