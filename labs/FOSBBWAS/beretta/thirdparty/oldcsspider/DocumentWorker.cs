using System;
using System.Net;
using System.IO;
using System.Threading;

namespace Spider
{
	/// <summary>
	/// Perform all of the work of a single thread for the spider.
	/// This involves waiting for a URL to becomve available, download
	/// and then processing the page.
	/// 
	/// This spider is copyright 2003 by Jeff Heaton. However, it is
	/// released under a Limited GNU Public License (LGPL). You may 
	/// use it freely in your own programs. For the latest version visit
	/// http://www.jeffheaton.com.	
	/// 
	/// </summary>
	public class DocumentWorker
	{
		/// <summary>
		/// The base URI that is to be spidered.
		/// </summary>
		private Uri m_uri;

		/// <summary>
		/// The spider that this thread "works for"
		/// </summary>
		private Spider m_spider;

		/// <summary>
		/// The thread that is being used.
		/// </summary>
		private Thread m_thread;

		/// <summary>
		/// The thread number, used to identify this worker.
		/// </summary>
		private int m_number;
		

		/// <summary>
		/// The name for default documents.
		/// </summary>
		public const string IndexFile = "index.html";

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="spider">The spider that owns this worker.</param>
		public DocumentWorker(Spider spider)
		{
			m_spider = spider;
		}

		/// <summary>
		/// This method will take a URI name, such ash /images/blank.gif
		/// and convert it into the name of a file for local storage.
		/// If the directory structure to hold this file does not exist, it
		/// will be created by this method.
		/// </summary>
		/// <param name="uri">The URI of the file about to be stored</param>
		/// <returns></returns>
		private string convertFilename(Uri uri)
		{
			string result = m_spider.OutputPath;
			int index1;
			int index2;			

			// add ending slash if needed
			if( result[result.Length-1]!='\\' )
				result = result+"\\";

			// strip the query if needed

			String path = uri.PathAndQuery;
			int queryIndex = path.IndexOf("?");
			if( queryIndex!=-1 )
				path = path.Substring(0,queryIndex);

			// see if an ending / is missing from a directory only
			
			int lastSlash = path.LastIndexOf('/');
			int lastDot = path.LastIndexOf('.');

			if( path[path.Length-1]!='/' )
			{
				if(lastSlash>lastDot)
					path+="/"+IndexFile;
			}

			// determine actual filename		
			lastSlash = path.LastIndexOf('/');

			string filename = "";
			if(lastSlash!=-1)
			{
				filename=path.Substring(1+lastSlash);
				path = path.Substring(0,1+lastSlash);
				if(filename.Equals("") )
					filename=IndexFile;
			}


			// create the directory structure, if needed
						
			index1 = 1;
			do
			{
				index2 = path.IndexOf('/',index1);
				if(index2!=-1)
				{
					String dirpart = path.Substring(index1,index2-index1);
					result+=dirpart;
					result+="\\";
				
				
					Directory.CreateDirectory(result);

					index1 = index2+1;					
				}
			} while(index2!=-1);			

			// attach name			
			result+=filename;

			return result;
		}

		/// <summary>
		/// Save a binary file to disk.
		/// </summary>
		/// <param name="response">The response used to save the file</param>
		private void SaveBinaryFile(WebResponse response)
		{
			byte []buffer = new byte[1024];

			if( m_spider.OutputPath==null )
				return;

			string filename = convertFilename( response.ResponseUri );
			Stream outStream = File.Create( filename );
			Stream inStream = response.GetResponseStream();	
			
			int l;
			do
			{
				l = inStream.Read(buffer,0,buffer.Length);
				if(l>0)
					outStream.Write(buffer,0,l);
			}
			while(l>0);
			
			outStream.Close();
			inStream.Close();

		}

		/// <summary>
		/// Save a text file.
		/// </summary>
		/// <param name="buffer">The text to save</param>
		private void SaveTextFile(string buffer)
		{
			if( m_spider.OutputPath==null )
				return;

			string filename = convertFilename( m_uri );
			StreamWriter outStream = new StreamWriter( filename );
			outStream.Write(buffer);
			outStream.Close();
		}

		/// <summary>
		/// Download a page
		/// </summary>
		/// <returns>The data downloaded from the page</returns>
		private string GetPage()
		{
			WebResponse response = null;
			Stream stream = null;
			StreamReader
			reader = null;

			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(m_uri);
							
				response = request.GetResponse();
				stream = response.GetResponseStream();	

				if( !response.ContentType.ToLower().StartsWith("text/") )
				{
					SaveBinaryFile(response);
					return null;
				}

				string buffer = "",line;

				reader = new StreamReader(stream);
			
				while( (line = reader.ReadLine())!=null )
				{
					buffer+=line+"\r\n";
				}
			
				SaveTextFile(buffer);
				return buffer;
			}
			catch(WebException e)
			{
				System.Console.WriteLine("Can't download:" + e);
				return null;
			}
			catch(IOException e)
			{
				System.Console.WriteLine("Can't download:" + e);
				return null;
			}
			finally
			{
				if( reader!=null )
					reader.Close();

				if( stream!=null )
					stream.Close();

				if( response!=null )
					response.Close();
			}
		}

		/// <summary>
		/// Process each link encountered. The link will be recorded
		/// for later spidering if it is an http or https docuent, 
		/// has not been visited before(determined by spider class),
		/// and is in the same host as the original base URL.
		/// </summary>
		/// <param name="link">The URL to process</param>
		private void ProcessLink(string link)
		{
			Uri url;

			// fully expand this URL if it was a relative link
			try
			{
				url = new Uri(m_uri,link,false);
			}
			catch(UriFormatException e)
			{
				System.Console.WriteLine( "Invalid URI:" + link );
				return;
			}

			if(!url.Scheme.ToLower().Equals("http") &&
				!url.Scheme.ToLower().Equals("https") )
				return;

			// comment out this line if you would like to spider
			// the whole Internet (yeah right, but it will try)
			if( !url.Host.ToLower().Equals( m_uri.Host.ToLower() ) )
				return;

			//System.Console.WriteLine( "Queue:"+url );
			m_spider.addURI( url );



		}

		/// <summary>
		/// Process a URL
		/// </summary>
		/// <param name="page">the URL to process</param>
		private void ProcessPage(string page)
		{
			ParseHTML parse = new ParseHTML();
			parse.Source = page;

			while(!parse.Eof())
			{
				char ch = parse.Parse();
				if(ch==0)
				{
					Attribute a = parse.GetTag()["HREF"];
					if( a!=null )
						ProcessLink(a.Value);
					
					a = parse.GetTag()["SRC"];
					if( a!=null )
						ProcessLink(a.Value);
				}
			}
		}


		/// <summary>
		/// This method is the main loop for the spider threads.
		/// This method will wait for URL's to become available, 
		/// and then process them. 
		/// </summary>
		public void Process()
		{
			while(!m_spider.Quit )
			{
				m_uri = m_spider.ObtainWork();
				
				m_spider.SpiderDone.WorkerBegin();
				System.Console.WriteLine("Download("+this.Number+"):"+m_uri);			
				string page = GetPage();
				if(page!=null)
					ProcessPage(page);
				m_spider.SpiderDone.WorkerEnd();
			}
		}

		/// <summary>
		/// Start the thread.
		/// </summary>
		public void start()
		{
			ThreadStart ts = new ThreadStart( this.Process );
			m_thread = new Thread(ts);
			m_thread.Start();
		}

		/// <summary>
		/// The thread number. Used only to identify this thread.
		/// </summary>
		public int Number 
		{
			get
			{
				return m_number;
			}

			set
			{
				m_number = value;
			}
		
		}
	}
}
