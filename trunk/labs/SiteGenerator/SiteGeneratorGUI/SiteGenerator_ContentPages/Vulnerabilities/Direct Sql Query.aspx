<%@   Language="c#" %>

<%@Import Namespace="System.Xml" %>
<%@Import Namespace="System.Data.SqlClient" %> 
<%@Import Namespace="System.Data" %> 


<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator Direct SQL Query</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body alink="#00">
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>
        Direct SQL Query</h3>
    <hr />
    <form id="Form1" runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="800">
            <tr bgcolor="#d2dae4">
                <td colspan="2">
                    <b>Direct SQL Query</b></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 405px">
                    <asp:DropDownList ID="ddlSampleQueries" runat="server" Width="360px" AutoPostBack="True" OnSelectedIndexChanged="ddlSampleQueries_Click">
                    <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="Select * from FoundStone_Bank..fsb_accounts">Select * from FoundStone_Bank..fsb_accounts</asp:ListItem>
                        <asp:ListItem Value="Select * from FoundStone_Bank..fsb_fund_transfers">Select * from FoundStone_Bank..fsb_fund_transfers</asp:ListItem>
                        <asp:ListItem Value="Select * from FoundStone_Bank..fsb_loan_rates">Select * from FoundStone_Bank..fsb_loan_rates</asp:ListItem>
                        <asp:ListItem Value="Select * from FoundStone_Bank..fsb_messages">Select * from FoundStone_Bank..fsb_messages</asp:ListItem>
                        <asp:ListItem Value="Select * from FoundStone_Bank..fsb_transactions">Select * from FoundStone_Bank..fsb_transactions</asp:ListItem>
                        <asp:ListItem Value="Select * from FoundStone_Bank..fsb_users">Select * from FoundStone_Bank..fsb_users</asp:ListItem>
                        <asp:ListItem Value="Select * from FoundStone_Bank..sysObjects">Select * from FoundStone_Bank..sysObjects</asp:ListItem>
                        <asp:ListItem Value="Select * from master..SysDatabases">Select * from master..SysDatabases</asp:ListItem>
                        <asp:ListItem Value="Select * from master..SysObjects">Select * from master..SysObjects</asp:ListItem>
                        <asp:ListItem Value="exec master..xp_cmdshell &quot;dir c:\&quot;">exec master..xp_cmdshell &quot;dir c:\&quot;</asp:ListItem>
                        <asp:ListItem Value="exec master..xp_cmdshell &quot;dir c:\hacmeBank_v2&quot;">exec master..xp_cmdshell &quot;dir c:\hacmeBank_v2&quot;</asp:ListItem>
                        <asp:ListItem Value="exec master..xp_cmdshell &quot;Net Users&quot;">exec master..xp_cmdshell &quot;Net Users&quot;</asp:ListItem>
                        <asp:ListItem Value="exec master..xp_cmdshell &quot;Net&nbsp;Localgroup&nbsp;Administrators&quot;">exec master..xp_cmdshell &quot;Net Localgroup Administrators&quot;</asp:ListItem>
                        <asp:ListItem Value="exec master..xp_cmdshell &quot;net&nbsp;User&nbsp;NewUser Password$&nbsp;/add&quot;">exec master..xp_cmdshell &quot;net User NewUser Password$ /add&quot;</asp:ListItem>
                        <asp:ListItem Value="exec master..xp_cmdshell &quot;Net&nbsp;Localgroup&nbsp;Administrators&nbsp;NewUser&nbsp;/Add&quot;">exec master..xp_cmdshell &quot;Net Localgroup Administrators NewUser /Add&quot;</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSqlQueryToExecute" runat="server" Width="360px" Height="75px"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btExecuteQuery" runat="server" Text="Execute Query" Height="96px"
                        Width="99px" OnClick="btExecuteQuery_Click"></asp:Button>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DataGrid ID="dgQueryResult" Width="800px" runat="server" AutoGenerateColumns="False"
                        Height="60px" GridLines="Horizontal" ForeColor="Black" BackColor="Beige" AlternatingItemStyle-BackColor="Gainsboro"
                        HeaderStyle-BackColor="#C0C0C0" HeaderStyle-Font-Bold="True">
                        <Columns>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script runat=server>
    
    public static SqlConnection globalSqlServerConnection;
    private static string strSqlConnectionString = @"SERVER=.\SQLEXPRESS;UID=sa;PWD=1q2w3e4r;DATABASE=FoundStone_Bank";

    public static void createSqlServerConnection()
    {
        try
        {
            globalSqlServerConnection.Close();
        }
        catch { }
        globalSqlServerConnection = new SqlConnection(strSqlConnectionString);
    }

    private void ddlSampleQueries_Click(object sender, System.EventArgs e)
    {
        txtSqlQueryToExecute.Text = ddlSampleQueries.Text;
        //btExecuteQuery_Click(null, null); 
         
    } 
	private void btExecuteQuery_Click(object sender, System.EventArgs e)
		{
            lblErrorMessage.Text = "";
			populateDataGridWithSqlQueryResults();
		}		

		private void ddlSampleQueries_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//txtSqlQueryToExecute.Text = Server.HtmlDecode(ddlSampleQueries.SelectedItem.Text).Replace("&#160;","_").Replace("&quot;;","\"__");			
			txtSqlQueryToExecute.Text = ddlSampleQueries.SelectedItem.Text;
		}

		private void populateDataGridWithSqlQueryResults()
		{
			try
			{
				string sqlQueryToexecute = Server.HtmlDecode(txtSqlQueryToExecute.Text);
                ArrayList sqlQueryResults = executeSqlQuery(sqlQueryToexecute);                
                
				if (sqlQueryResults.Count >0)
				{
					//Create DataGrid Table Headers                    
					DataTable dataTableWithSqlQueryResults = new DataTable();
                    for (int i = 0; i < sqlQueryResults.Count; i++ )
                    {
                        if (i == 0)
                        {
                            ArrayList alColumns = (ArrayList)sqlQueryResults[0];
                            for (int j = 0; j < alColumns.Count; j++)
                            {
                                BoundColumn dynamicDataGridColumn = new BoundColumn();
                                dynamicDataGridColumn.DataField = j.ToString();
                                dynamicDataGridColumn.HeaderText = (string)alColumns[j];
                                dgQueryResult.Columns.Add(dynamicDataGridColumn);
                                dataTableWithSqlQueryResults.Columns.Add(j.ToString());
                            }
                        }
                        else
                        {
                             ArrayList alData = (ArrayList)sqlQueryResults[i];
                             object[] rowData = new object[alData.Count];
                             for (int j = 0; j < alData.Count - 1; j++)
                                 rowData[j] = Server.HtmlEncode((string)alData[j].ToString());
                             dataTableWithSqlQueryResults.Rows.Add(rowData); 
                        }  
                        // object[] rowData = new object[alResults.Count+1];
                        //for (int i = 0; i < alResults.Count-1; i++)
                        //{
                        //   rowData[i] = Server.HtmlEncode((string)alResults[i]);
                        //}
                        //dataTableWithSqlQueryResults.Rows.Add(alResults);
                        //Response.Write("<hr>");
                    }
                    /*                    
                                        for (int i=0; i < sqlQueryResults[0].ChildNodes.Count;i++)
                                        {
                                            XmlNode resultItem = sqlQueryResults[0].ChildNodes[i];				
                                            BoundColumn dynamicDataGridColumn = new BoundColumn();				
                                            dynamicDataGridColumn.DataField = i.ToString();
                                            dynamicDataGridColumn.HeaderText = resultItem.InnerText;
                                            dgQueryResult.Columns.Add(dynamicDataGridColumn);
                                            dataTableWithSqlQueryResults.Columns.Add(i.ToString());
                                        }
                                        if (sqlQueryResults.Length>1)
                                        {
                                            //Populate DataGrid Table 
                                            for (int j=1; j<sqlQueryResults.Length;j++)
                                            {
                                                //DataRow dynamicDataRow = dataTableWithSqlQueryResults.NewRow();
                                                object[] rowData = new object[sqlQueryResults[j].ChildNodes.Count];
                                                for (int i=0; i < sqlQueryResults[j].ChildNodes.Count;i++)
                                                {
                                                    XmlNode resultItem = sqlQueryResults[j].ChildNodes[i];					
                                                    rowData[i] = Server.HtmlEncode(resultItem.InnerText);					
                                                }
                                                dataTableWithSqlQueryResults.Rows.Add(rowData);
                                            }
                                        }
                     * */
                    dgQueryResult.DataSource = dataTableWithSqlQueryResults;
 
					dgQueryResult.DataBind();			
				}
			}
			catch (Exception Ex)
			{
				lblErrorMessage.Text = Ex.Message;
			}
		}

    public static ArrayList executeSqlQuery(string sqlQueryToExecute)
    {
        return returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows_andResultingSchema(sqlQueryToExecute);
    }
     
    public static SqlDataReader executeSQLCommand_returnSqldataReader(string sqlQueryToExecute)
    {
        createSqlServerConnection();
        //SqlConnection Global.globalSqlServerConnection = new SqlConnection(ConfigurationSettings.AppSettings.Get("FoundStone_Connection"));
        string text1 = sqlQueryToExecute;
        SqlCommand command1 = new SqlCommand(text1, globalSqlServerConnection);
        globalSqlServerConnection.Open();
        SqlDataReader executeReader_Result = command1.ExecuteReader();
        return executeReader_Result;
    }

    public static ArrayList returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows_andResultingSchema(string sqlQuery)
    {
        ArrayList QueryResults = new ArrayList();
        SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);
        ArrayList rowFieldsSchemaResults = new ArrayList();
        for (int i = 0; i < reader1.FieldCount; i++)
        {
            rowFieldsSchemaResults.Add(reader1.GetName(i));
        }
        QueryResults.Add(rowFieldsSchemaResults);
        while (reader1.Read())
        {
            ArrayList rowFieldsResults = new ArrayList();
            for (int i = 0; i < reader1.FieldCount; i++)
            {
                if ("System.DBNull" == reader1[i].GetType().FullName)
                {
                    rowFieldsResults.Add("[:NULL:]");
                }
                else
                {
                    rowFieldsResults.Add(reader1[i]);
                }
            }
            QueryResults.Add(rowFieldsResults);
        }
        return QueryResults;
    }  
       
</script>
