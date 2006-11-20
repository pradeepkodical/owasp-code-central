#region Imported Libraries
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web.Security;
using log4net;
using Owasp.DefApp.SettingProcessor;

#endregion

#region Licence Information

// The General Tools For Asp.Net Applications
// Version 0.6
// Copyright (C) 2004 - 2005 Izzet Kerem Kusmezer
// Email: keremkusmezer@yazilimguvenligi.com
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

#endregion

namespace Owasp.DefApp.Utils.StreamFilters
{
	/// <summary>
	/// Used To Manipulate The ViewState
	/// </summary>
	internal class MemoryFilter : Stream
	{
		#region Private Variables & Methods
			private static readonly ILog log = LogManager.GetLogger(typeof (MemoryFilter));	
			private System.IO.Stream moStream;
			private NameValueCollection hashTable;		
			private MemoryFilter():base(){}
			private long mlPosition;
			private long mlLength;
			private ViewStateStatus.Method method;
		#endregion

		#region Public Methods
						
		public MemoryFilter(Stream stream,ViewStateStatus viewStateStatus):this(stream,viewStateStatus.ViewStateStorage)
		{
			this.method = viewStateStatus.GetActiveMethod();	
		}
		/// <summary>
		/// The Main Constructor Of The Filter
		/// </summary>
		/// <param name="stream">The Stream To Be Used By The Filter</param>
		/// <param name="table">The Changed ViewStates Storage</param>
		public MemoryFilter(Stream stream,NameValueCollection table)
		{
			this.moStream = stream;
			hashTable = table;
		}
			public override long Seek(long offset, System.IO.SeekOrigin direction)
		{
			return moStream.Seek(offset, direction);
		}

			public override void Close()
		{
			moStream.Close();
		}

			public override void Flush()
		{
			moStream.Flush();
		}

			public override void SetLength(long value)
		{
			mlLength = value;
		}

			public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

			public override bool CanRead
		{
			get
			{ 
				return false;
			}
		}

			public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

			public override bool CanWrite
		{
			get
			{
				return true;
			}
		}
			public override long Length
		{
			get
			{
				return mlLength;
			}
		}

			public override long Position
		{
			get
			{
				return mlPosition;
			}
			set
			{
				mlPosition = value;
			}
		}
 
			/// <summary>
			/// Overrides The Method To Rewrite The ViewState With The Other Type ViewState
			/// </summary>
			/// <param name="buffer"></param>
			/// <param name="offset"></param>
			/// <param name="count"></param>
			public override void Write(byte[] buffer, int offset, int count)
		{
			System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();

			System.Text.StringBuilder strBuild = new System.Text.StringBuilder(utf8.GetString(buffer));
			
			string strViewState = strBuild.ToString();
			
			#region Replaces The Viewstate with the guid
			
			int start = strViewState.IndexOf("<input type=\"hidden\" name=\"__VIEWSTATE\"");
			
			int end = 0;
			
			if (start > -1)
				end = strViewState.IndexOf("/>",start);

			if (start > -1 && end > -1)
			{
				string viewstate = strViewState.Substring(start,end-start);			
				viewstate = viewstate.Replace("<input type=\"hidden\" name=\"__VIEWSTATE\"","");
				viewstate = viewstate.Replace("/>","").Replace("value=\"","").Replace("\"","").Trim();									
				string newviewstate = this.encryptViewState(viewstate);				
				strViewState = strViewState.Replace(viewstate,newviewstate);										
				
				try{
					hashTable.Add(newviewstate,viewstate);			
				}
				catch{					
				}

			}
			
			byte[] data = UTF8Encoding.UTF8.GetBytes (strViewState);				
			
			moStream.Write (data, 0, data.Length);            

			#endregion

			log.Info(strViewState);			

		}
		private string encryptViewState(string viewState)
		{
			if (this.method == ViewStateStatus.Method.GUID)
			{
				return System.Guid.NewGuid().ToString();	
			}
			else if (this.method == ViewStateStatus.Method.MD5)
			{
				return FormsAuthentication.HashPasswordForStoringInConfigFile(viewState,"md5");
			}
			else if (this.method == ViewStateStatus.Method.SHA1)
			{
				return FormsAuthentication.HashPasswordForStoringInConfigFile(viewState,"sha1");
			}
			else
			{
				return viewState;
			}
		}
		public override void WriteByte(byte value)
		{
			log.Info(value);
			moStream.WriteByte(value);
			moStream.Flush();
		}

		public void WriteTo(Stream stream)
		{
		}
		#endregion
	}
}