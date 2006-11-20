/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: module object
 */

using System;
using System.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for module.
	/// </summary>
	public class module
	{
		private int mId;
		private string mSrc;
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

		public string src
		{
			get
			{
				return mSrc;
			}
			set
			{
				mSrc=value;
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


        public module()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			moduleDataAccess.add(mSrc, mDescription);
		}

		public void update()
		{
			moduleDataAccess.update(mId, mSrc, mDescription);
		}

		public void delete()
		{
			moduleDataAccess.delete(mId);
		}

		public void populate()
		{

			DataSet objDataSet=new DataSet();

			objDataSet=moduleDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mSrc=System.Convert.ToString(objDataRow["src"]);
				mDescription=System.Convert.ToString(objDataRow["description"]);
			}
		}
	}
}
