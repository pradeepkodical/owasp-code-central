using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DefAppTestWeb
{
	public sealed class GeneralMethods
	{
		private GeneralMethods()
		{
		}
		
		public static SqlDataAdapter MakeInsertable(SqlDataAdapter ad)
		{			
			return null;
		}
		public static bool UpdateUser(string userName,string password,string newPassword)
		{
			SqlConnection cn = null;
			SqlTransaction transAct = null;
			try
			{
				cn = new SqlConnection(ConfigurationSettings.AppSettings["cn"]);
				cn.Open();
				SqlCommand sqlCmd = new SqlCommand();
				transAct = cn.BeginTransaction();
				sqlCmd.Connection = cn;
				sqlCmd.Transaction = transAct;
				sqlCmd.CommandText = "spUtis_Login";
				sqlCmd.CommandType = CommandType.StoredProcedure;
				sqlCmd.Parameters.Add("@UserName","0001010005");
				sqlCmd.Parameters.Add("@Password","je4B6LQNVEb0p4zUL8a6MQ==");
				object results = sqlCmd.ExecuteScalar();
				if (userName =="josef")
					throw new Exception("test");
				sqlCmd.CommandType = CommandType.Text;
				sqlCmd.CommandText = "update tGuvKullanici set KullaniciAdi = @UserName where KullaniciAdi=@Password and Sifre=@Password";
				sqlCmd.Parameters.Clear();
				sqlCmd.Parameters.Add("@UserName","0001010005");
				sqlCmd.Parameters.Add("@Password","je4B6LQNVEb0p4zUL8a6MQ==");
				sqlCmd.ExecuteNonQuery();
				transAct.Commit();
			}
			catch(Exception ex)
			{
				if (transAct!=null)
				{
					transAct.Rollback();
				}
			}
			finally
			{
				cn.Close();
			}
			return true;
		}
		public static DataTable LogonUser(string userName,string password)
		{
			SqlConnection cn = null;
			try
			{
				cn = new SqlConnection(ConfigurationSettings.AppSettings["cn"]);
				cn.Open();
				userName = userName.Replace("'","''");
				password = password.Replace("'","''");
				SqlDataAdapter da = new SqlDataAdapter("SELECT KullaniciAdi, Sifre, KullaniciId, Adi_SoyAdi, Unvan, Email, Aciklama, DilId, CreDate, ModDate, IsOnay, IsAktif, ModUser, CreUser FROM tGuvKullanici where KullaniciAdi='"+ userName + "' and Sifre='"+ password + "'",cn);
				System.Data.DataSet ds = new DataSet();
				da.Fill(ds);
				SqlCommandBuilder builder = new SqlCommandBuilder(da);
				builder.RefreshSchema();
				return ds.Tables[0];
			}
			catch(Exception ex)
			{
				return new DataTable();
			}
			finally
			{
				if (cn!=null)
				{
					if (cn.State != ConnectionState.Closed)
						cn.Close();
				}
			}
		}
	}
}