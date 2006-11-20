using System;
using System.Collections;
using System.Net;
using System.IO;
using System.Threading;

namespace Spider
{
	/// <summary>
	/// The main class for the spider. This spider can be used with the 
	/// SpiderForm form that has been provided. The spider is completely 
	/// selfcontained. If you would like to use the spider with your own
	/// application just remove the references to m_spiderForm from this file.
	/// 
	/// The files needed for the spider are:
	/// 
	/// Attribute.cs - Used by the HTML parser
	/// AttributeList.cs - Used by the HTML parser
	/// DocumentWorker - Used to "thread" the spider
	/// Done.cs - Allows the spider to know when it is done
	/// Parse.cs - Used by the HTML parser
	/// ParseHTML.cs - The HTML parser
	/// Spider.cs - This file
	/// SpiderForm.cs - Demo of how to use the spider
	/// 
	/// This spider is copyright 2003 by Jeff Heaton. However, it is
	/// released under a Limited GNU Public License (LGPL). You may 
	/// use it freely in your own programs. For the latest version visit
	/// http://www.jeffheaton.com.
	///
	/// </summary>
	public class Spider
	{
		/// <summary>
		/// The URL's that have already been processed.
		/// </summary>
		private Hashtable m_already;

		/// <summary>
		/// URL's that are waiting to be processed.
		/// </summary>
		private Queue m_workload;

		/// <summary>
		/// The first URL to spider. All other URL's must have the
		/// same hostname as this URL. 
		/// </summary>
		private Uri m_base;

		/// <summary>
		/// The directory to save the spider output to.
		/// </summary>
		private string m_outputPath;

		/// <summary>
		/// The form that the spider will report its 
		/// progress to.
		/// </summary>
		private SpiderForm m_spiderForm;

		/// <summary>
		/// How many URL's has the spider processed.
		/// </summary>
		private int m_urlCount = 0;

		/// <summary>
		/// When did the spider start working
		/// </summary>
		private long m_startTime = 0;

		/// <summary>
		/// Used to keep track of when the spider might be done.
		/// </summary>
		private Done m_done = new Done();		

		/// <summary>
		/// Used to tell the spider to quit.
		/// </summary>
		private bool m_quit;

		/// <summary>
		/// The status for each URL that was processed.
		/// </summary>
		enum Status { STATUS_FAILED, STATUS_SUCCESS, STATUS_QUEUED };


		/// <summary>
		/// The constructor
		/// </summary>
		public Spider()
		{
			reset();
		}

		/// <summary>
		/// Call to reset from a previous run of the spider
		/// </summary>
		public void reset()
		{
			m_already = new Hashtable();
			m_workload = new Queue();
			m_quit = false;
		}

		/// <summary>
		/// Add the specified URL to the list of URI's to spider.
		/// This is usually only used by the spider, itself, as
		/// new URL's are found.
		/// </summary>
		/// <param name="uri">The URI to add</param>
		public void addURI(Uri uri)
		{
			Monitor.Enter(this);
			if( !m_already.Contains(uri) )
			{
				m_already.Add(uri,Status.STATUS_QUEUED);
				m_workload.Enqueue(uri);
			}
			Monitor.Pulse(this);
			Monitor.Exit(this);
		}

		/// <summary>
		/// The URI that is to be spidered
		/// </summary>
		public Uri BaseURI 
		{
			get
			{
				return m_base;
			}

			set
			{
				m_base = value;
			}
		}

		/// <summary>
		/// The local directory to save the spidered files to
		/// </summary>
		public string OutputPath
		{
			get
			{
				return m_outputPath;
			}

			set
			{
				m_outputPath = value;
			}
		}

		/// <summary>
		/// The object that the spider reports its
		/// results to.
		/// </summary>
		public SpiderForm ReportTo
		{
			get
			{
				return m_spiderForm;
			}

			set
			{
				m_spiderForm = value;
			}
		}

		/// <summary>
		/// Set to true to request the spider to quit.
		/// </summary>
		public bool Quit
		{
			get
			{
				return m_quit;
			}

			set
			{
				m_quit = value;
			}
		}

		/// <summary>
		/// Used to determine if the spider is done, 
		/// this object is usually only used internally
		/// by the spider.
		/// </summary>
		public Done SpiderDone
		{
			get
			{
				return m_done;
			}

		}

		/// <summary>
		/// Called by the worker threads to obtain a URL to
		/// to process.
		/// </summary>
		/// <returns>The next URL to process.</returns>
		public Uri ObtainWork()
		{
			Monitor.Enter(this);
			while(m_workload.Count<1)
			{
				Monitor.Wait(this);
			}


			Uri next = (Uri)m_workload.Dequeue();
			if(m_spiderForm!=null)
			{
				m_spiderForm.SetLastURL(next.ToString());
				m_spiderForm.SetProcessedCount(""+(m_urlCount++));
				long etime = (System.DateTime.Now.Ticks-m_startTime)/10000000L;
				long urls = (etime==0)?0:m_urlCount/etime;
				m_spiderForm.SetElapsedTime( etime/60 + " minutes (" + urls +" urls/sec)" );
			}

			Monitor.Exit(this);
			return next;
		}

		/// <summary>
		/// Start the spider.
		/// </summary>
		/// <param name="baseURI">The base URI to spider</param>
		/// <param name="threads">The number of threads to use</param>
		public void Start(Uri baseURI,int threads)
		{
			// init the spider
			m_quit = false;

			m_base = baseURI;
			addURI(m_base);
			m_startTime = System.DateTime.Now.Ticks;;
			m_done.Reset();
		
			// startup the threads

			for(int i=1;i<threads;i++)
			{				
				DocumentWorker worker = new DocumentWorker(this);
				worker.Number = i;
				worker.start();
			}

			// now wait to be done

			m_done.WaitBegin();
			m_done.WaitDone();			
		}
	}
}
