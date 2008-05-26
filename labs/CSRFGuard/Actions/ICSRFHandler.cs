namespace Org.Owasp.CsrfGuard.Actions
{
    /// <summary>
    /// Very simple interface for dynamic CSRF handler plugins specified in configuration and loaded at runtime
    /// </summary>
    internal interface ICSRFHandler
    {
        /// <summary>
        /// Init the object.
        /// </summary>
        /// <param name="sender">The HttpResponse object required to override the ASP.Net application from responding.</param>
        void Initialize(object sender);

        /// <summary>
        /// Once the object is set up, take the appropriate action.
        /// </summary>
        void TakeAction();
    }
}