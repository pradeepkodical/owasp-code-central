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
	public class passwordDataAccess:dataaccess
	{

		public passwordDataAccess()
		{
		}

		public void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_passwordAttackPasswords_delete", intId.ToString());

		}

		public void add(string strUsername, int intUsernameOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_passwordAttackPasswords_add", strUsername, intUsernameOrder.ToString());
		}

		public void update(int intId, string strPassword, int intUsernameOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_passwordAttackPasswords_update", intId.ToString(), strPassword, intUsernameOrder.ToString());

		}

		public DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_passwordAttackPasswords_getAll");


		}
	}
}