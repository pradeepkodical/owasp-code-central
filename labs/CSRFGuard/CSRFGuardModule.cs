using System;
using System.Web;
using System.Web.SessionState;
using org.owasp.csrfguard.ResponseFilters;
using org.owasp.csrfguard.Actions;
using System.Diagnostics;

namespace org.owasp.csrfguard
{
	public class CSRFGuardModule : IHttpModule, IRequiresSessionState
	{
		private CSRFGuard _guard;
        private Token _session;
		
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
            _session = new Token(_guard.CsrfSessionTokenName, _guard.CsrfSessionTokenValue);  // this is not accessible in later stages so is saved for access later
			
			// this should ignore requests by extension so it won't flag image or CSS requests -- basically, anything that could not be used for CSRF
			// The object does this checking when instantiated so we just need to ask the object what to do...
			if (!_guard.SkipDetect)
			{
				if (_guard.AttackDetected)
				{
					handleCSRFAttempt(sender);
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
					response.Filter = new RegExFilter(response.Filter, _session.Name, _session.Value);
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

        // TODO:  move this cruft into the CSRFguard.  It should be doing the protection there.
		void handleCSRFAttempt(object sender)
		{
            HttpApplication _httpApp;
            HttpContext _context;
            HttpResponse _response;

            _httpApp = (HttpApplication)sender;
            _context = _httpApp.Context;
            _response = _httpApp.Context.Response;
            // instantiate the dynamic classes specified in the config file, or the default.  Then tell it to take action.
            foreach (string hclass in App.Configuration.CSRFHandlers)
            {
                EventLog log = new EventLog();
                log.Source = "Application";
                log.WriteEntry("Executing Action " + hclass, EventLogEntryType.Error);
                try
                {
                    Type type = Type.GetType(hclass, true);
                    ICSRFHandler handler = Activator.CreateInstance(type) as ICSRFHandler;
                    handler.Initialize(sender);
                    handler.TakeAction();
                }
                catch (TypeLoadException e)
                {
                    log.WriteEntry("Got exception " + e.Message, EventLogEntryType.Error);
                }
            }
            _response.End();
		}

		public void Dispose()
		{}
	}		
}