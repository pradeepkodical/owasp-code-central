using System;
using System.Data;

namespace beretta.Objects
{
	/// <summary>
	/// List of URLS to scan
	/// </summary>
	public class urls
	{

		private int mId;
		private int mSessionId;
		private string mUrl;
		private string mDescription;
		private int mSessionOrder;

		private urlsDataAccess objUrlsDataAccess=new urlsDataAccess();

		#region Class Accessor Values
		public int id
		{
			get{return mId;}
			set{mId=value;}
		}

		public int sessionId
		{
			get{return mSessionId;}
			set{mSessionId=value;}
		}

		public string url
		{
			get{return mUrl;}
			set{mUrl=value;}
		}

		public string description
		{
			get{return mDescription;}
			set{mDescription=value;}
		}

		public int sessionOrder
		{
			get{return mSessionOrder;}
			set{mSessionOrder=value;}
		}
		#endregion

		public urls()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			mId=urlsDataAccess.add(mSessionId, mUrl, mDescription, mSessionOrder);
		}

		public void update()
		{
			urlsDataAccess.update(mId, mSessionId, mUrl, mDescription, mSessionOrder);
		}

		public void delete()
		{
			urlsDataAccess.delete(mId);

		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=urlsDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mSessionId=System.Convert.ToInt32(objDataRow["sessionId"]);
				mUrl=System.Convert.ToString(objDataRow["url"]);
				mDescription=System.Convert.ToString(objDataRow["description"]);
				mSessionOrder=System.Convert.ToInt32(objDataRow["sessionOrder"]);

		
			}


	}
	}
}
