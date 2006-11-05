<%@ Page Language="C#" Debug="true" %>
<% @Import Namespace="System.Net.Sockets" %>
<% @Import Namespace="System.Net" %>

<hr>
<% my.test(); %>
<hr>

<script runat="server">
    class my
    {
		public static void test()
		{
			try
			{
				TcpClient client = new TcpClient("localhost", 4000);
				Byte[] data = System.Text.Encoding.ASCII.GetBytes("This is a message from Asp.Net II");
				
				NetworkStream stream = client.GetStream();
				stream.Write(data, 0, data.Length);
				
				// Receive the response
				data = new Byte[256];
				
				String responseData = String.Empty;
				
				Int32 bytes = stream.Read(data, 0, data.Length);
				responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
				HttpContext.Current.Response.Write(responseData);
				
				stream.Close();
				client.Close();	
			} 
			catch (System.Net.Sockets.SocketException socketEx) 
			{
				HttpContext.Current.Response.Write("Issue connecting to server: " + socketEx.Message);
			}
		}
    }
</script>