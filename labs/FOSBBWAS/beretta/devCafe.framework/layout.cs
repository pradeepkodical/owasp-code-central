using System;
using System.Data;


namespace devCafe.framework
{
	/// <summary>
	/// Summary description for layout.
	/// </summary>
	public class layout
	{
		private int mId;
		private string mLayoutName;
		private string mLayoutPath;

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

		public string layoutName
		{
			get
			{
				return mLayoutName;
			}
			set
			{
				mLayoutName=value;
			}
		}

		public string layoutPath
		{
			get
			{
				return mLayoutPath;
			}
			set
			{
				mLayoutPath=value;
			}
		}

		
		public layout()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			layoutDataAccess.add(mLayoutName, mLayoutPath);
		}

		public void update()
		{
			layoutDataAccess.update(mId, mLayoutName, mLayoutPath);
		}

		public void delete()
		{
			layoutDataAccess.delete(mId);
		}

		public void populate()
		{
			
			DataSet objDataSet=new DataSet();

			objDataSet=layoutDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mLayoutName="" + System.Convert.ToString(objDataRow["layoutName"]);
				mLayoutPath="" + System.Convert.ToString(objDataRow["layoutPath"]);
			}

		}

	}
}
