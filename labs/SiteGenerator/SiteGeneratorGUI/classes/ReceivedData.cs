using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace Owasp.SiteGenerator
{
    /// <summary>
    /// This class is a wrapper for the data we will receive from 
    /// web clients trying to communicate back to Site Generator.
    /// </summary>
    class ReceivedData
    {
        private byte[] receivedData;
        private NetworkStream netStream;

        public byte[] Data
        {
            get
            {
                return receivedData;
            }
            set
            {
                receivedData = value;
            }
        }

        public NetworkStream ConnectionStream
        {
            get
            {
                return netStream;
            }
            set
            {
                netStream = value;
            }
        }
    }
}
