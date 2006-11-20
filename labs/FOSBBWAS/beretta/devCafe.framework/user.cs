/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: user object 
 */

using System;
using System.Data;

using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for user.
	/// </summary>
	public class user
	{
		private int mId;
		private string mUsername;
		private string mPassword;
		private string mEmail;
		private string mFirstName;
		private string mLastName;
		private string mOrganisation;
		private int mType;
		private int mIsActive;
		private int mProjectId;
		private string mProjectShortName;
		private string mClientDir;
		private string mServerDir;
		public string mUserRoles;

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

		public string username
		{
			get
			{
				return mUsername;
			}
			set
			{
				mUsername=value;
			}
		}

		public string password
		{
			get
			{
				return mPassword;
			}
			set
			{
				mPassword=value;
			}
		}

		public string email
		{
			get
			{
				return mEmail;
			}
			set
			{
				mEmail=value;
			}
		}


		public string firstName
		{
			get
			{
				return mFirstName;
			}
			set
			{
				mFirstName=value;
			}
		}

		public string lastName
		{
			get
			{
				return mLastName;
			}
			set
			{
				mLastName=value;
			}
		}

		public string organisation
		{
			get
			{
				return mOrganisation;
			}
			set
			{
				mOrganisation=value;
			}
		}

		public int type
		{
			get
			{
				return mType;
			}
			set
			{
				mType=value;
			}
		}

		public int isActive
		{
			get
			{
				return mIsActive;
			}
			set
			{
				mIsActive=value;
			}
		}

		public int projectId
		{
			get
			{
				return mProjectId;
			}
			set
			{
				mProjectId=value;
			}
		}


		public string projectShortName
		{
			get
			{
				return mProjectShortName;
			}
			set
			{
				mProjectShortName=value;
			}
		}


		public string clientDir
		{
			get
			{
				return mClientDir;
			}
			set
			{
				mClientDir=value;
			}
		}

		public string serverDir
		{
			get
			{
				return mServerDir;
			}
			set
			{
				mServerDir=value;
			}
		}

		public string userRoles
		{
			get
			{
				return mUserRoles;
			}
			set
			{
				mUserRoles=value;
			}
		}

		
		public user()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public void add()
		{
			
			mId=userDataAccess.add(mUsername, mEmail, mFirstName, mLastName, mOrganisation, mType, mIsActive);
		}

		public void update()
		{
			userDataAccess.update(mId, mUsername, mEmail, mFirstName, mLastName, mOrganisation, mType, mIsActive);
		}


		/// <summary>
		/// Saves the new password. Call generate password before doing this.
		/// </summary>
		public void updatePassword()
		{
			userDataAccess.updatePassword(mId, mPassword);
		}



		/// <summary>
		/// Generates a hash of plain text
		/// </summary>
		public void generatePassword()
		{

			string strTmp="" + mPassword;

			strTmp="" + encryption.hashMD5(strTmp + settings.get("entropyValue"));
			
			mPassword=strTmp;
			
			

		}

		public void delete()
		{
			userDataAccess.delete(mId);
		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();
			DataSet objProjectDataSet=new DataSet();

			objDataSet=userDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mUsername="" + System.Convert.ToString(objDataRow["username"]);
				mPassword="" + System.Convert.ToString(objDataRow["password"]);
				mEmail="" + System.Convert.ToString(objDataRow["email"]);
				mFirstName="" + System.Convert.ToString(objDataRow["firstname"]);
				mLastName="" + System.Convert.ToString(objDataRow["lastname"]);
				mOrganisation="" + System.Convert.ToString(objDataRow["organisation"]);
				mType=System.Convert.ToInt32(objDataRow["type"]);
				mIsActive=System.Convert.ToInt32(objDataRow["isActive"]);
				
			}


			if (mId!=0 && mProjectShortName !="" && mProjectShortName != null)
			{
				//populate project
				objProjectDataSet=userDataAccess.userProjects_getForLogin(mProjectShortName, mId);

				foreach(DataRow objDataRow in objProjectDataSet.Tables[0].Rows)
				{
					mProjectId=System.Convert.ToInt32(objDataRow["projectId"]);
					mClientDir="" + System.Convert.ToString(objDataRow["clientDir"]);
					mServerDir="" + System.Convert.ToString(objDataRow["serverDir"]);
				}

			}

			DataSet objRoles=new DataSet();
			objRoles=rolesDataAccess.getAllForUser(mId);

			foreach(DataRow objDataRow in objRoles.Tables[0].Rows)
			{
				mUserRoles=mUserRoles + objDataRow["roleName"] + ";";
			}

			


		}

		
		

	}
}
