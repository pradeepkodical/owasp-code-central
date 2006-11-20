#region Imported Libraries

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using beretta.Objects;
using beretta.Support;

#endregion

namespace beretta.Modules.PasswordAttack
{
	/// <summary>
	/// Summary description for usernameDataAccess.
	/// </summary>
	public class usernameDataAccess:dataaccess 
	{
		public usernameDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_passwordAttackUsernames_delete", intId.ToString());
		}

		public void add(string strUsername, int intUsernameOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_passwordAttackUsernames_add", strUsername, intUsernameOrder.ToString());
		}

		public void update(int intId, string strUsername, int intUsernameOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_passwordAttackUsernames_update", intId, strUsername, intUsernameOrder.ToString());


		}

		public DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_passwordAttackUsernames_getAll");

		}
	}
}