using System;
using System.Data;


namespace beretta.Objects
{
	/// <summary>
	/// Payload contains all the submissions to be used in an application scan
	/// </summary>
	public class payload
	{
		private int mId;
		private string mPayloadName;
		private string mPayloadData;
		private string mDescription;
		private int mPayloadOrder;
		private int mType;
		private payloadDataAccess objPayloadDataAccess=new payloadDataAccess();

		#region Class Accessor Values
		public int id
		{
			get{return mId;}
			set{mId=value;}
		}

		public string payloadName
		{
			get{return mPayloadName;}
			set{mPayloadName=value;}
		}

		public string payloadData
		{
			get{return mPayloadData;}
			set{mPayloadData=value;}
		}

		public string description
		{
			get{return mDescription;}
			set{mDescription=value;}
		}

		public int payloadOrder
		{
			get{return mPayloadOrder;}
			set{mPayloadOrder=value;}
		}

		public int type
		{
			get{return mType;}
			set{mType=value;}
		}

		

		#endregion


		public payload()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			mId=payloadDataAccess.add(mPayloadName, mPayloadData, mDescription, mPayloadOrder, mType);
		}

		public void update()
		{
			payloadDataAccess.update(mId, mPayloadName, mPayloadData, mDescription, mPayloadOrder, mType);
	
		}

		public void delete()
		{
			payloadDataAccess.delete(mId);

		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();
			objDataSet=payloadDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mPayloadName=System.Convert.ToString(objDataRow["payloadName"]);
				mPayloadData=System.Convert.ToString(objDataRow["payloadData"]);
				mDescription=System.Convert.ToString(objDataRow["description"]);
				mPayloadOrder=System.Convert.ToInt32(objDataRow["payloadOrder"]);
				mType=System.Convert.ToInt32(objDataRow["type"]);
			}


		}


		

	}
}
