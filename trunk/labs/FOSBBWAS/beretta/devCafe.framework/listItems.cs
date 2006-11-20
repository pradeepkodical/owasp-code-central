/* Author: Alex Mackey
 * Date: 26/06/2005
 * Version: 1.0
 * Purpose: list item object
 */

using System;
using System.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for listItems.
	/// </summary>
	public class frameworkListItems
	{
		private int mId;
		private string mListItemName;
		private int mListItemOrder;
		private int mIsDefault;
		private int mGroupId;


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

		public string listItemName
		{
			get
			{
				return mListItemName;
			}
			set
			{
				mListItemName=value;
			}
		}

		public int listItemOrder
		{
			get
			{
				return mListItemOrder;
			}
			set
			{
				mListItemOrder=value;
			}
		}

		public int isDefault
		{
			get
			{
				return mIsDefault;
			}
			set
			{
				mIsDefault=value;
			}
		}

		public int groupId
		{
			get
			{
				return mGroupId;
			}
			set
			{
				mGroupId=value;
			}
		}

		
		public frameworkListItems()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			listItemsDataAccess.add(mListItemName, mListItemOrder, mIsDefault, mGroupId);
		}


		public void update()
		{
			listItemsDataAccess.update(mId, mListItemName, mListItemOrder, mIsDefault, mGroupId);
		}

		public void delete()
		{
			listItemsDataAccess.delete(mId);
		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=listItemsDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mListItemName=System.Convert.ToString(objDataRow["listItemName"]);
				mListItemOrder=System.Convert.ToInt32(objDataRow["listItemOrder"]);
				mIsDefault=System.Convert.ToInt32(objDataRow["isDefault"]);
				mGroupId=System.Convert.ToInt32(objDataRow["groupId"]);
			}

		}


	}
}
