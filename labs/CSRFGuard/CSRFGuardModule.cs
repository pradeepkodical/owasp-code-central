using System;
using System.Web;
using System.Web.SessionState;
using org.owasp.csrfguard.ResponseFilters;

namespace org.owasp.csrfguard
{
	public class CSRFGuardModule : IHttpModule, IRequiresSessionState
	{
		private CSRFGuard _guard;
		private String _CSRFSessionTokenValue; // this is not accessible in later stages so is saved for access later
		private String _CSRFSessionTokenName;
		
		public String ModuleName
		{
			get { return "CSRFGuardModule"; }
		}

		public void Init(HttpApplication httpApp)
		{
			httpApp.AcquireRequestState += new EventHandler(handleRequest);
			httpApp.ReleaseRequestState += new EventHandler(filterHTMLResponse);
		}
		
		// when the request comes in, decide whether it needs to be handled and then how
		void handleRequest(object sender, EventArgs args)
		{
			_guard = new CSRFGuard(sender);
			
			_CSRFSessionTokenValue = _guard.CsrfSessionTokenValue;
			_CSRFSessionTokenName = _guard.CsrfSessionTokenName;
			
			// this should ignore requests by extension so it won't flag image or CSS requests -- basically, anything that could not be used for CSRF
			// The object does this checking when instantiated so we just need to ask the object what to do...
			if (!_guard.SkipDetect)
			{
				if (_guard.AttackDetected)
				{
					handleCSRFAttempt(_guard.Response);
				}
			}
		}
		
		// move this to a utility function
		void filterHTMLResponse(object sender, EventArgs args)		
		{
			HttpResponse response = HttpContext.Current.Response;
			
			// [response.Filter] "Gets or sets a wrapping filter object used to modify the HTTP entity body before transmission"
			// i.e. we can nicely pass all of the HTML through a filter to rewrite it on the way out!
			
			try
			{
				if(response.ContentType.StartsWith("text/html"))
				{
					response.Filter = new RegExFilter(response.Filter, _CSRFSessionTokenName, _CSRFSessionTokenValue);
				}
			}
			catch (Exception e)
			{
				// do something
			}
		}
		
		/**
		 * Handle a detected CSRF attepmpt.  This will use the configuration for what to do next (e.g. redirect, kill session, log, etc.)
		 **/
		void handleCSRFAttempt(HttpResponse response)
		{
			// TODO
			// redirect to an error URL
			// kill session
			// write an error to the screen and kill the request.  Probably not a good strategy but useful for testing
			response.Write("Missing token:  CSRF detected!");
			response.End();
		}

		public void Dispose()
		{}
		}		
}