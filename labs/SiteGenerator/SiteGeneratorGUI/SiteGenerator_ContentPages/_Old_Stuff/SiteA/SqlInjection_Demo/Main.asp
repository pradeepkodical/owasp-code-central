<h1>SQL Injection Demo1</h1>

<%	
	if Request.QueryString("user_Name")<>"" Then
		SQL="SELECT * FROM fsb_users where user_name='" + Request.QueryString("user_Name") + "'"
	else
		SQL="SELECT * FROM fsb_users"
	end if
	dim connection,recordset			'declare your variables
	dim SQL,sConnString				'declare SQL statement that will query the database


	sConnString="DRIVER={SQL Server};SERVER=.\SQLEXPRESS;UID=sa;PWD=1q2w3e4r;DATABASE=FoundStone_Bank"
									'create an ADO connection and recordset
	Set connection = Server.CreateObject("ADODB.Connection")
	Set recordset = Server.CreateObject("ADODB.Recordset")

	connection.Open sConnString			'Open the connection to the database
					
	recordset.Open SQL,connection			'Open the recordset object, execute the SQL statement
	If recordset.eof then
	 	response.write "There were no records returned."
	Else	
		Response.write "<b>user_id,user_name,login_id</b><br/>"
		Do While NOT Recordset.Eof   		'i.e. carry on looping through while there are records
			Response.write Recordset("user_id")
			Response.write ","    
			Response.write Recordset("user_name")
			Response.write ","    
			Response.write Recordset("login_id")
			Response.write "<br>"    'include a line break
			Recordset.MoveNext     'move on to the next record
		Loop
	End if

		
	Recordset.Close						'close the connection and recordset objects freeing up resources
	Set Recordset=nothing
	Connection.Close
	Set Connection=nothing
%>