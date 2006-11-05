using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;

namespace Owasp.SiteGenerator
{
    /// <summary>
    /// This class is used to listen for communication from the web servers and then 
    /// process it for use in the SiteGenerator fat client.
    /// </summary>
    class Listener
    {
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        private delegate void SetTextCallback(string text);
        private delegate void updateListViewCallback(ListView lvToUse, ListViewItem lvItemToAdd);        

        private TcpListener iisListener = null;
        private ArrayList alConnections = new ArrayList();
        private TextBox tbMessageObject = null; // This will allow us to display information to the GUI
        private UserControl ucCallingObject = null;
        private ListView lvFileTransformationLog = null;

#region "Public Methods"
        public TextBox TextBoxForCommunication
        {
            set 
            {
                tbMessageObject = value;
            }
        }

        public UserControl ControlForCallingBackTo
        {
            set
            {
                ucCallingObject = value;
            }
        }

        public ListView ListViewForFileTransformations
        {
            set
            {
                lvFileTransformationLog = value;
            }
        }

        /// <summary>
        /// This allows us to start listening for connections from the website.
        /// </summary>
        public void AcceptConnections()
        {
            if (iisListener == null)
            {
                iisListener = new TcpListener(IPAddress.Any, 4000);
            }
            iisListener.Start();
            iisListener.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);
        }

        /// <summary>
        /// This method closes out all the client connections
        /// </summary>
        public void CloseConnections()
        {
            for (int i = 0; i < alConnections.Count; i++)
            {
                ((TcpClient)alConnections[i]).Close();
                alConnections[i] = null;
            }
        }
#endregion

        /// <summary>
        /// This handles setting up reading from the web client.  It will also 
        /// add the new connection to the container so we can make sure 
        /// the connections are all closed at the end.  
        /// </summary>
        /// <param name="asyn">The result from a new connection being initiated</param>
        private void OnClientConnect(IAsyncResult asyn)
        {
            TcpClient webClient = iisListener.EndAcceptTcpClient(asyn);

            int iNewConnectionIdx = alConnections.Add(webClient);
            HandleReceivedData((TcpClient)alConnections[iNewConnectionIdx]);

            // Setup the listener again...
            iisListener.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);
        }

        /// <summary>
        /// This method handles setting up the reading of the data sent by the client.
        /// </summary>
        /// <param name="tcClient">The TcpClient that is talking with us</param>
        private void HandleReceivedData(TcpClient tcClient)
        {
            NetworkStream netStream = tcClient.GetStream();

            if (netStream.CanRead)
            {
                byte[] receivedBytes = new byte[tcClient.ReceiveBufferSize];
                ReceivedData rd = new ReceivedData();
                rd.Data = receivedBytes;
                rd.ConnectionStream = netStream;
                netStream.BeginRead(receivedBytes,
                                     0,
                                     receivedBytes.Length,
                                     new AsyncCallback(OnDataReceived),
                                     rd);
            }
        }

        /// <summary>
        /// This is the callback method for receiving data from web clients.  
        /// 
        /// The method will return what was sent back to the caller. 
        /// 
        /// Precondition: The AsyncState is holding a ReceivedData class
        /// </summary>
        /// <param name="asyn">The result from the initial call</param>
        private void OnDataReceived(IAsyncResult asyn)
        {
            ReceivedData dataFromWeb = (ReceivedData)asyn.AsyncState;

            // Grab the data from the stream 
            string receivedData = Encoding.UTF8.GetString(dataFromWeb.Data);

            // End the read which will close the thread...
            dataFromWeb.ConnectionStream.EndRead(asyn);

            // Remove all null padding
            receivedData = receivedData.TrimEnd('\0');

            string response = ParseReceivedData(receivedData);
            response = (response.Length == 0) ? receivedData : response;

            // Push what the client just sent back to them so they have it.
            if (dataFromWeb.ConnectionStream.CanWrite)
            {
                byte[] dataToSend = Encoding.UTF8.GetBytes(response);
                dataFromWeb.ConnectionStream.Write(dataToSend, 0, dataToSend.Length);
            }
            dataFromWeb.ConnectionStream.Close();
        }

        /// <summary>
        /// This method is used so that we can update the debug windows from
        /// the threads that are created as we are handling the client responses via
        /// asynchronous calls so the main program can continue on...
        /// 
        /// Precondition: The form and the textbox properties have been set
        /// </summary>
        /// <param name="text">The data we want to put in the text object</param>
        private void UpdateDebugControl(string text)
        {
            if ((tbMessageObject != null) &&
               (ucCallingObject != null))
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.tbMessageObject.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(UpdateDebugControl);
                    this.ucCallingObject.Invoke(d, new object[] { text });

                }
                else
                {
                    this.tbMessageObject.AppendText(text);
                    this.tbMessageObject.AppendText(Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// This method is used for handling the incoming data and deciding what needs
        /// to be done with it.  
        /// </summary>
        /// <param name="receivedData"></param>
        private string ParseReceivedData(String receivedData)
        {
            // TODO: Refactor this ParseReceivedData method
            string response = "";
            string strPathToCurrentSite = Path.GetFullPath(@ConfigurationManager.AppSettings["StaticPagePath"] + "//");
            string[] dataSplitIntoSegments = receivedData.Split(new string[] { ",-," }, StringSplitOptions.RemoveEmptyEntries);
            XmlNode xnSelectedDirectory = null;

            if ((dataSplitIntoSegments.Length > 1) && DoesRequestNeedAnAnswer(dataSplitIntoSegments[0]))
            {
                bool bMatch = false;
                string strQuestion =  dataSplitIntoSegments[1];
                string CapitializedQuestionType = dataSplitIntoSegments[0].ToUpper();
                string strPathToAnalyze = dataSplitIntoSegments[1];
                response = strQuestion; // by default make the answer = to question   
                
                if(CapitializedQuestionType == "[SG_HTTPHANDLER]") 
                {
                    response = SiteGenerator_Transformers.resolveNameAndFolder(strQuestion, ref bMatch);
                    if (SiteGenerator_Transformers.isPathAFolder(strPathToAnalyze, ref xnSelectedDirectory))
                    {

                        if ((null != xnSelectedDirectory) && 
                           (null != xnSelectedDirectory.Attributes.GetNamedItem("defaultPage"))) 
                        {
                            response = xnSelectedDirectory.Attributes.GetNamedItem("defaultPage").Value;

                            // If the document has no beginning slash we need to add that so the document
                            // can be found.
                            if (response[0] != '/')
                                response = "/" + response;

                            // We see if the page specified actually needs to be parsed again to the true
                            // file location.
                            string tmpPage = SiteGenerator_Transformers.resolveNameAndFolder(response, ref bMatch);
                            if (tmpPage != response)
                                response = tmpPage;
                            bMatch = true;
                        }
                    }

                    if (bMatch)           // we had a replacement
                    {
                        if (response.ToString()[0] == '/')
                            response = ConfigurationManager.AppSettings["ContentPagesRoot"] + response.ToString();
                        else
                            response = Path.Combine(ConfigurationManager.AppSettings["ContentPagesRoot"], response.ToString());
                    }

                } 
                else if(CapitializedQuestionType == "HTTPRECEIVEHTTPREQUEST") 
                {
                    if (dataSplitIntoSegments[1].IndexOf(".aspx") > -1)          // only make this replacement for aspx files
                    {
                        if (strPathToAnalyze.IndexOf('?') > -1)
                        {
                            string[] strSplitedPathToAnalyze = strPathToAnalyze.Split('?');
                            if (strSplitedPathToAnalyze.Length > 2)
                                MessageBox.Show("More than 1 ? in request");
                            string strRequest = strSplitedPathToAnalyze[0];
                            string strQueryString = strSplitedPathToAnalyze[1];
                            response = SiteGenerator_Transformers.resolveNameAndFolder(strRequest, ref bMatch);
                            response += "?" + strQueryString;
                        }
                        else
                            response = SiteGenerator_Transformers.resolveNameAndFolder(strPathToAnalyze, ref bMatch);
                    }
                    else
                    {
                        xnSelectedDirectory = null;

                        if (strPathToAnalyze.IndexOf("_Navigation_Html_") > -1)
                        {
                            strPathToAnalyze = strPathToAnalyze.Replace("_Navigation_Html_", "");
                            if (SiteGenerator_Transformers.isPathAFolder(strPathToAnalyze, ref xnSelectedDirectory))
                                if (null != xnSelectedDirectory)
                                    response = SiteGenerator_Transformers.generateNavigation_html(strPathToAnalyze, xnSelectedDirectory, false, false);
                        }
                        if (strPathToAnalyze.IndexOf("_Navigation_Flash_") > -1)
                        {
                            strPathToAnalyze = strPathToAnalyze.Replace("_Navigation_Flash_", "");
                            if (SiteGenerator_Transformers.isPathAFolder(strPathToAnalyze, ref xnSelectedDirectory))
                                if (null != xnSelectedDirectory)
                                    response = SiteGenerator_Transformers.generateNavigation_flash(strPathToAnalyze, xnSelectedDirectory);
                        }
                        if (strPathToAnalyze.IndexOf('.') > -1)                    // don't continue if we are talking about files
                        {
                            response = dataSplitIntoSegments [1];
                        }
                        if (SiteGenerator_Transformers.isPathAFolder(strPathToAnalyze, ref xnSelectedDirectory))            // check if this is a folder
                        {

                            if (null != xnSelectedDirectory)
                            {
                                if (null != xnSelectedDirectory.Attributes.GetNamedItem("defaultPage"))               // check if there is a default page asigned
                                {
                                    string strDefaultPage = xnSelectedDirectory.Attributes.GetNamedItem("defaultPage").Value;
                                    response = strDefaultPage;
                                }
                                response = SiteGenerator_Transformers.generateNavigation_html(strPathToAnalyze, xnSelectedDirectory, true, true);
                            }
                            //  generate folder info
                        }
                        else
                            response = dataSplitIntoSegments[1];
                    }
                }
                else if ((CapitializedQuestionType == "CREATEFILEW") ||
                   (CapitializedQuestionType == "GETFULLPATHNAMEW"))
                {
                    if (dataSplitIntoSegments[1].IndexOf(ConfigurationManager.AppSettings["w3Root"]) > -1)
                    {
                        string strVirtualPathToProcess = dataSplitIntoSegments[1].Replace(ConfigurationManager.AppSettings["w3Root"], "");
                        strVirtualPathToProcess = strVirtualPathToProcess.Replace("\\\\?\\", "");
                        response = SiteGenerator_Transformers.resolveNameAndFolder(strVirtualPathToProcess, ref bMatch);  // add querystring detection
                        if (strVirtualPathToProcess != response)
                            DisplayInformationToGUI("FileTransformation,-,....,-,0000,-," + dataSplitIntoSegments[1].ToString() + ",-," + response);
                        if (response.IndexOf("~/") > -1)           // "~/" means 'use the virtual path
                        {
                            response = Path.GetFullPath(Path.Combine(strPathToCurrentSite, response.Replace("~/", "")));
                        }
                        else
                        {
                            response = Path.GetFullPath(ConfigurationManager.AppSettings["w3Root"] + response);
                        }
                    }
                    else
                    {
                        response = dataSplitIntoSegments[1];
                    }
                }

                DisplayInformationToGUI(dataSplitIntoSegments[0] + ",-," + dataSplitIntoSegments[1].ToString() + ",-," + response);
            }
            else 
            {
                DisplayInformationToGUI(dataSplitIntoSegments.ToString());
            }

            return response;
        }

        /// <summary>
        /// This method is used to update the debug information that can be viewed by the clients.
        /// </summary>
        /// <param name="InformationToDisplay"></param>
        private void DisplayInformationToGUI(string InformationToDisplay)
        {
            string[] StrSplitedMessageToProcess = InformationToDisplay.Split(new string[] { ",-," }, StringSplitOptions.RemoveEmptyEntries);
            if (StrSplitedMessageToProcess.Length > 1)
            {
                switch (StrSplitedMessageToProcess[0])
                {
                    case "FileTransformation":
                    case "[SG_HttpHandler]":
                    case "FileTransformation (Cached)":
                        {
                            if (lvFileTransformationLog != null)
                            {
                                updateListView(lvFileTransformationLog, new ListViewItem(StrSplitedMessageToProcess));
                                UpdateDebugControl("Method: " + StrSplitedMessageToProcess[0] + " in " +
                                                   Environment.NewLine + Environment.NewLine +
                                                   InformationToDisplay);
                            }
                            break;
                        }
                    // HttpApi Hooks
                    case "HttpReceiveHttpRequest":
                        {
                            break; // add httpApiHook menu
                        }
                    // Network
                    default:
                        {
                            UpdateDebugControl("Unrecognized method:" + StrSplitedMessageToProcess[0] + 
                                               " in " + 
                                               Environment.NewLine + 
                                               Environment.NewLine + 
                                               InformationToDisplay);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// This checks to see if the request sent from the website should have an answer to its request.
        /// </summary>
        /// <param name="requestType">The request type usually the very first 
        /// part of the request</param>
        /// <returns>True if we need to answer back</returns>
        private bool DoesRequestNeedAnAnswer(string requestType)
        {
            bool requestNeedAnswer = false;
            requestType = requestType.ToUpper();

            if ((requestType == "[SG_HTTPHANDLER]") ||
               (requestType == "HttpReceiveHttpRequest".ToUpper()) ||
               (requestType == "CreateFileW".ToUpper()) ||
               (requestType == "GetFullPathNameW".ToUpper()))
            {
                requestNeedAnswer = true;
            }

            return requestNeedAnswer;
        }

        private static void updateListView(ListView lvToUse, ListViewItem lvItemToAdd)
        {
            if (lvToUse.InvokeRequired)
            {
                updateListViewCallback ulvCallback = new updateListViewCallback(updateListView);
                lvToUse.Invoke(ulvCallback, new object[] { lvToUse, lvItemToAdd });
            }
            else
            {
                lvToUse.Items.Insert(0, lvItemToAdd);
            }
        }
    }
}
