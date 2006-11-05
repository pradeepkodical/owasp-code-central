<%@ language="C#" ValidateRequest="false"  debug="true"%>
	
<% @Import Namespace="System.Data" %>
<% @Import Namespace="System.Data.SqlClient" %>

	
	<h1>SQL Injection Demo1</h1>

<%	
string strSqlQuery;
if (null == Request.QueryString["user_id"])
{
    strSqlQuery = "Select * from fsb_users";
    Response.Write("<hr> use querystring value user_id to search for details of a particular users<hr>");
}
else
    strSqlQuery = "Select * from fsb_users where user_id = " + Request.QueryString["user_id"];
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
		
        public static SqlDataReader executeSQLCommand_returnSqldataReader(string sqlQueryToExecute)
		{			
			try
			{			
				createSqlServerConnection();			
				string text1 = sqlQueryToExecute;
				SqlCommand command1 = new SqlCommand(text1, globalSqlServerConnection);			
				globalSqlServerConnection.Open();
				SqlDataReader executeReader_Result = command1.ExecuteReader();			
				return executeReader_Result ;
			}
			catch (Exception ex)
			{
				HttpContext.Current.Response.Write("Error:" + ex.Message);
				HttpContext.Current.Response.End();
				return null;
			}
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

		
		/*	
dim myConnection as New SqlConnection("SERVER=.\SQLEXPRESS;UID=sa;PWD=1q2w3e4r;DATABASE=FoundStone_Bank")

//Const strSQL as String = "SELECT * FROM fsb_users"
    Dim myCommand as New SqlCommand(strSQL, myConnection)
Dim dr As New SqlDataReader()

myConnection.Open()
'opening the connection
myCommand = New SqlCommand("Select * from discounts", myConnection)
'executing the command and assigning it to connection
dr = myCommand.ExecuteReader()
'While dr.Read()
		
Response.Write("<hr>OK")		
'	dim SQL=""
'	dim sConnString=""				'declare SQL statement that will query the database
'	if Request.QueryString("user_Name")<>"" Then
'		SQL="SELECT * FROM fsb_users where user_name='" + Request.QueryString("user_Name") + "'"
'	else
'		SQL="SELECT * FROM fsb_users"
'	end if
'	dim connection,recordset			'declare your variables
'	
'
'
'	sConnString="DRIVER={SQL Server};SERVER=.\SQLEXPRESS;UID=sa;PWD=1q2w3e4r;DATABASE=FoundStone_Bank"
'									'create an ADO connection and recordset
'	connection = Server.CreateObject("ADODB.Connection")
'	recordset = Server.CreateObject("ADODB.Recordset")
'
'	connection.Open(sConnString)			'Open the connection to the database
'					
'	recordset.Open(SQL,connection)			'Open the recordset object, execute the SQL statement
'	If recordset.eof then
'	 	response.write( "There were no records returned.")
'	Else	
'		Response.write ("<b>user_id,user_name,login_id</b><br/>")
'		Do While NOT Recordset.Eof   		'i.e. carry on looping through while there are records
'			Response.write (Recordset("user_id"))
'			Response.write (","    )
'			Response.write (Recordset("user_name"))
'			Response.write (","    )
'			Response.write (Recordset("login_id"))
'			Response.write ("<br>")  'include a line break
'			Recordset.MoveNext     'move on to the next record
'		Loop
'	End if

		
'	Recordset.Close						'close the connection and recordset objects freeing up resources
'	Recordset=nothing
'	Connection.Close
'	Connection=nothing
*/
</script>