#region Imported Libraries

using System;
using System.Configuration;
using System.Data;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

#endregion

namespace beretta.Support
{
	/// <summary>
	/// The Abstract DataAccess Class
	/// </summary>
	public abstract class dataaccess
	{
		private static string strConn;

		public dataaccess()
		{
			strConn = ConfigurationSettings.AppSettings["databaseConnection"];
		}

		protected static string strConnection
		{
			get { return strConn; }
		}


	



		/// <summary>
		/// Returns The Result Of The select count(*) from statements(More Effective Then The DataSet Version)
		/// </summary>
		/// <param name="strconn">The Connection String To Be Used</param>
		/// <param name="storedProcedure">The Stored Procedure To Be Called</param>
		/// <returns>The Count result</returns>		
		public static int getCount(string strconn, string storedProcedure)
		{
			int intCount = 0;
			Object obj = SqlHelper.ExecuteScalar(strconn, CommandType.StoredProcedure, storedProcedure);
			try
			{
				intCount = Convert.ToInt32(obj.ToString());
			}
			catch
			{
			}
			return intCount;
		}

		#region CSVToDataTable Conversion Methods

		/// <summary>
		/// Create DataTable Using The Given CSV Stream And Char Separator
		/// </summary>
		/// <param name="CSVin">The CSV Stream To Be Converted</param>
		/// <param name="separator">The Separator To Be Used</param>
		/// <returns>The Mapped DataTable</returns>
		public static DataTable mapCSVToDataTable(char separator, string fileName)
		{
			string csv = File.OpenText(fileName).ReadToEnd();
			return mapCSVToDataTable(csv, separator);
		}

		/// <summary>
		/// Create DataTable Using The Given CSV Stream And Char Separator
		/// </summary>
		/// <param name="CSVin">The CSV Stream To Be Converted</param>
		/// <param name="separator">The Separator To Be Used</param>
		/// <returns>The Mapped DataTable</returns>
		public static DataTable mapCSVToDataTable(Stream CSVin, char separator)
		{
			StreamReader read = new StreamReader(CSVin);
			return mapCSVToDataTable(read.ReadToEnd(), separator);
		}

		/// <summary>
		/// Create DataTable Using The Given CSV String And Char Separator
		/// </summary>
		/// <param name="CSV">The CSV String To Be Converted</param>
		/// <param name="separator">The Separator To Be Used</param>
		/// <returns>The Mapped DataTable</returns>
		public static DataTable mapCSVToDataTable(string CSV, char separator)
		{
			DataTable resultTable = new DataTable();
			StringReader str = new StringReader(CSV);
			string start;
			int x = 0, initialLength = 0;
			char[] sep = {separator};
			while ((start = str.ReadLine()) != null)
			{
				string[] columns = start.Split(sep);
				if (x == 0)
				{
					initialLength = columns.Length;
					for (int i = 0; i < columns.Length; i++)
					{
						resultTable.Columns.Add("Col" + i);
					}
					++x;
				}
				else
				{
					try
					{
						resultTable.Rows.Add(columns);
					}
					catch
					{
					}
				}
			}
			return resultTable;
		}

		#endregion	
	}
}