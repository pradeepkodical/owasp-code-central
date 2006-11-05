using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Owasp.SiteGenerator.utils
{
    /// <summary>
    /// This class was created to talk with the fat client sitting on port 4000.  
    /// </summary>
    class Communicator
    {
        private TcpClient client = new TcpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageToSend"></param>
        /// <returns></returns>
        public string SendMessage(string messageToSend)
        {
            string response = String.Empty;
            if (!client.Connected)
            {
                client.Connect(System.Net.Dns.GetHostName(), 4000);
            }
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(messageToSend);

            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            // Receive the response
            data = new Byte[1024];

            Int32 bytes = stream.Read(data, 0, data.Length);
            response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            stream.Close(0);
            client.Close();	

            return response;
        }
    }
}
