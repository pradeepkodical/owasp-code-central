using System;
using System.Text;
using System.Web;

namespace org.owasp.csrfguard.Actions
{
    /// <summary>
    /// Very simple interface for dynamic CSRF handler plugins specified in configuration and loaded at runtime
    /// </summary>
    interface ICSRFHandler
    {
        /// <summary>
        /// Init the object.
        /// </summary>
        /// <param name="response">The HttpResponse object required to override the ASP.Net application from responding.</param>
        void Initialize(object sender);

        /// <summary>
        /// Once the object is set up, take the appropriate action.
        /// </summary>
        void TakeAction();
    }
}
