/* Author: Alex Mackey
 * Date: 26/06/2005
 * Version: 1.0
 * Purpose: list group object
 */

using System;
using System.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for listGroup.
	/// </summary>
	public class listGroup
	{
		private int mId;
		private string mListGroupName;

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


		public string listGroupName
		{
			get
			{
				return mListGroupName;
			}
			set
			{
				mListGroupName=value;
			}
		}


		public listGroup()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			listGroupDataAccess.add(mListGroupName);
		}

		public void update()
		{
			listGroupDataAccess.update(mId, mListGroupName);
		}

		public void delete()
		{
			listGroupDataAccess.delete(mId);
		}

		public void populate()
		{
			
			DataSet objDataSet=new DataSet();

			objDataSet=listGroupDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mListGroupName=System.Convert.ToString(objDataRow["listGroupName"]);

			}
	
		}
	}
}
