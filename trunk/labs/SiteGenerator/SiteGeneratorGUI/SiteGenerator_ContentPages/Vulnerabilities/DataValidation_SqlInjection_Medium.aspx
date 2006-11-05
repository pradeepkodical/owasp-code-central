<%@ language="C#" ValidateRequest="false"  debug="true"%>
	
<% @Import Namespace="System.Data" %>
<% @Import Namespace="System.Data.SqlClient" %>

<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - DataValidation : SQL Injection : Medium</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body>
<!--#include virtual="\SiteGenerator_Banner.html" -->
	
	<h3>DataValidation : SQL Injection : Medium</h3>
	<hr />

<!-- End_Default_Vulnerability_HTML_code (put vulnerability code after this)-->
<%	
string strSqlQuery;
if (null == Request.QueryString["user_id"])
{
    strSqlQuery = "Select * from fsb_users";
    Response.Write("<b>note: </b>use querystring value user_id to search for details of a particular users<hr>");
}
else
    strSqlQuery = "Select * from fsb_users where user_id = " + Request.QueryString["user_id"];
    try
    {  
        ArrayList alResults = returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows(strSqlQuery);
       Response.Write("#" + alResults.Count.ToString() + " results fetched<br><br>");
        if (alResults.Count>0)
        {
            foreach(ArrayList alResult in alResults)
            {
                Response.Write("<li>");
                foreach(object sResult in alResult)
                    Response.Write(sResult.ToString() + " , " );
                Response.Write("</li>"); 
            }   
        } 
    } 
    catch (Exception ex)
    {
        Response.Write(ex.Message);
       closeSqlServerConnection() ;
        Response.End();
    }  
    closeSqlServerConnection();


%>
<script runat=server>

    public static SqlConnection globalSqlServerConnection;
    private static string strSqlConnectionString = @"SERVER=.\SQLEXPRESS;UID=sa;PWD=1q2w3e4r;DATABASE=FoundStone_Bank";

		public static void createSqlServerConnection()
		{
			try
			{
				globalSqlServerConnection.Close();
			}
			catch {}
			globalSqlServerConnection = new SqlConnection(strSqlConnectionString);
		}
		
		public static void closeSqlServerConnection()
		{
			try
			{
				globalSqlServerConnection.Close();
			}
			catch {}			
		}
		
        public static SqlDataReader executeSQLCommand_returnSqldataReader(string sqlQueryToExecute)
		{						
			createSqlServerConnection();			
			string text1 = sqlQueryToExecute;
			SqlCommand command1 = new SqlCommand(text1, globalSqlServerConnection);			
			globalSqlServerConnection.Open();
			SqlDataReader executeReader_Result = command1.ExecuteReader();			
			return executeReader_Result ;
		}

        public static ArrayList returnArrayListFromSQLQuery_containing_FirstFieldFromAllRows(string sqlQuery)
		{
			ArrayList QueryResults = new ArrayList();
			SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);
			while (reader1.Read())
			{
				QueryResults.Add(reader1[0].ToString());					
			}			
			return QueryResults;		
		}
		
	    public static ArrayList returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows(string sqlQuery)
		{
			ArrayList QueryResults = new ArrayList();
			SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);
			while (reader1.Read())
			{
				ArrayList RowFieldsResults = new ArrayList();
				for (int i=0; i< reader1.FieldCount;i++)
				{
					if ("System.DBNull" == reader1[i].GetType().FullName)					
						RowFieldsResults.Add("[:NULL:]");					
					else					
						RowFieldsResults.Add(reader1[i]);					
				}			
				QueryResults.Add(RowFieldsResults);					
			}						
			return QueryResults;		
		}			
</script>

</body>
</html>