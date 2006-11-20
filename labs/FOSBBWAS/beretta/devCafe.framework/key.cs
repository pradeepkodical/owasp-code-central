/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: config object
 */
 

using System;
using System.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for config.
	/// </summary>
	public class key
	{
		private int mId;
		private string mKeyName;
		private string mKeyValue;
		private string mDescription;

		public int id
		{
			get
			{
				return mId;
			}
			set
			{
				mId=value;
			}
		}


		public string keyName
		{
			get
			{
				return mKeyName;
			}
			set
			{
				mKeyName=value;
			}
		}


		public string keyValue
		{
			get
			{
				return mKeyValue;
			}
			set
			{
				mKeyValue=value;
			}
		}


		public string description
		{
			get
			{
				return mDescription;
			}
			set
			{
				mDescription=value;
			}
		}


		public key()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			keyDataAccess.add(mKeyName, mKeyValue, mDescription);
		}

		public void update()
		{
			keyDataAccess.update(mId, mKeyName, mKeyValue, mDescription);
		}

		public void delete()
		{	
			keyDataAccess.delete(mId);
		}


		public void populate()
		{

			DataSet objDataSet=new DataSet();
			objDataSet=keyDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mKeyName=System.Convert.ToString(objDataRow["keyName"]);
				mKeyValue=System.Convert.ToString(objDataRow["keyValue"]);
				mDescription=System.Convert.ToString(objDataRow["description"]);

			}



		}
	}
}
