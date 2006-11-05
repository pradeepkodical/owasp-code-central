using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml;
using  System.Collections;

namespace Owasp.SiteGenerator
{
    class smdtHelperClasses
    {
        delegate void updateTextBoxCallback(string strText, TextBox tbToUse);
        delegate void updateListViewCallback(ListView lvToUse, ListViewItem lvItemToAdd);        
        
        public static void continuouslyReceiveMessagesAndProcessThem(IntPtr smdtToUse)
        {
            string strPathToCurrentSite = Path.GetFullPath(GlobalVariables.strSiteGenerator_PathToStaticPages + "//" + GlobalVariables.strSiteGenerator_PathToDemoSite);
            StringBuilder sbReceivedMessage= new StringBuilder(GlobalVariables.MAX_SIZE_OF_ANSWER_DATA);            
            /*while (true)
            {                
                if (1 == SharedMemoryForDotNet.smdt_UnReadMessages(smdtToUse))
                {
                    int iAnswerPosition = SharedMemoryForDotNet.smdt_getNextMessageToProcess(smdtToUse, sbReceivedMessage);
                    string strReceivedMessage = sbReceivedMessage.ToString();                    
                    if (1 == SharedMemoryForDotNet.smdt_CheckIfCurrentMessageShouldHaveAnAnswer(smdtToUse, iAnswerPosition))
                    {
                        StringBuilder strQuestion = new StringBuilder();
                        StringBuilder strAnswer = new StringBuilder();
                        bool bMatch = false;
                        string[] StrSplitedReceivedMessage = strReceivedMessage.Split(new string[] { ",-," }, StringSplitOptions.RemoveEmptyEntries);
                        if (StrSplitedReceivedMessage.Length > 1)
                        {
                            strQuestion =  new StringBuilder(StrSplitedReceivedMessage[1]);
                            strAnswer = strQuestion;         // by default make the answer = to question                            
                            if (null != GlobalVariables.htCachedResults[strQuestion.ToString()])
                            {
                                strAnswer = new StringBuilder((string)GlobalVariables.htCachedResults[strQuestion.ToString()]);
                                processReceivedMessage("FileTransformation (Cached),-," + StrSplitedReceivedMessage[0] + ",-,9999,-," + StrSplitedReceivedMessage[1].ToString() + ",-," + strAnswer);
                            }
                            else
                            {
                                switch (StrSplitedReceivedMessage[0])
                                {
                                    // HttpReceiveHttpRequest
                                    case "[SG_HttpHandler]":
                                        {                                            
                                            strAnswer = new StringBuilder(SiteGenerator_Transformers.resolveNameAndFolder(strQuestion.ToString(), ref bMatch));
                                            if (bMatch)           // we had a replacement
                                            {
                                                if (strAnswer.ToString()[0] =='/')
                                                    strAnswer = new StringBuilder(GlobalVariables.strSiteGenerator_PathToContentPages + strAnswer.ToString());
                                                else
                                                    strAnswer = new StringBuilder(Path.Combine(GlobalVariables.strSiteGenerator_PathToContentPages, strAnswer.ToString()));
                                            }
                                            break;
                                        }
                                    case "HttpReceiveHttpRequest":
                                        {
                                            string strPathToAnalyze = StrSplitedReceivedMessage[1];
                                            if (StrSplitedReceivedMessage[1].IndexOf(".aspx") > -1)          // only make this replacement for aspx files
                                            {
                                                if (strPathToAnalyze.IndexOf('?') > -1)
                                                {
                                                    string[] strSplitedPathToAnalyze = strPathToAnalyze.Split('?');
                                                    if (strSplitedPathToAnalyze.Length > 2)
                                                        MessageBox.Show("More than 1 ? in request");
                                                    string strRequest = strSplitedPathToAnalyze[0];
                                                    string strQueryString = strSplitedPathToAnalyze[1];
                                                    strAnswer = new StringBuilder(SiteGenerator_Transformers.resolveNameAndFolder(strRequest,ref bMatch));
                                                    strAnswer.Append("?" + strQueryString);
                                                }
                                                else
                                                    strAnswer = new StringBuilder(SiteGenerator_Transformers.resolveNameAndFolder(strPathToAnalyze,ref bMatch));
                                            }
                                            else
                                            {
                                                XmlNode xnSelectedDirectory = null;
                                                if (strPathToAnalyze.IndexOf("_Navigation_Html_") > -1)
                                                {
                                                    strPathToAnalyze = strPathToAnalyze.Replace("_Navigation_Html_", "");
                                                    if (SiteGenerator_Transformers.isPathAFolder(strPathToAnalyze, ref xnSelectedDirectory))
                                                        if (null != xnSelectedDirectory)
                                                            strAnswer = new StringBuilder(SiteGenerator_Transformers.generateNavigation_html(strPathToAnalyze, xnSelectedDirectory, false, false));
                                                    break;
                                                }
                                                if (strPathToAnalyze.IndexOf("_Navigation_Flash_") > -1)
                                                {
                                                    strPathToAnalyze = strPathToAnalyze.Replace("_Navigation_Flash_", "");
                                                    if (SiteGenerator_Transformers.isPathAFolder(strPathToAnalyze, ref xnSelectedDirectory))
                                                        if (null != xnSelectedDirectory)
                                                            strAnswer = new StringBuilder(SiteGenerator_Transformers.generateNavigation_flash(strPathToAnalyze, xnSelectedDirectory));
                                                    break;
                                                }
                                                if (strPathToAnalyze.IndexOf('.') > -1)                    // don't continue if we are talking about files
                                                {
                                                    strAnswer = new StringBuilder(StrSplitedReceivedMessage[1]);
                                                    break;
                                                }
                                                if (SiteGenerator_Transformers.isPathAFolder(strPathToAnalyze, ref xnSelectedDirectory))            // check if this is a folder
                                                {

                                                    if (null != xnSelectedDirectory)
                                                    {
                                                        if (null != xnSelectedDirectory.Attributes.GetNamedItem("defaultPage"))               // check if there is a default page asigned
                                                        {
                                                            string strDefaultPage = xnSelectedDirectory.Attributes.GetNamedItem("defaultPage").Value;
                                                            strAnswer = new StringBuilder(strDefaultPage);
                                                            break;
                                                        }
                                                        strAnswer = new StringBuilder(SiteGenerator_Transformers.generateNavigation_html(strPathToAnalyze, xnSelectedDirectory, true, true));
                                                    }
                                                    //  generate folder info
                                                }
                                                else
                                                    strAnswer = new StringBuilder(StrSplitedReceivedMessage[1]);
                                            }
                                            break;
                                        }
                                    case "CreateFileW":
                                    case "GetFullPathNameW":
                                        {
                                            if (StrSplitedReceivedMessage[1].IndexOf(GlobalVariables.strSiteGenerator_PathToW3wpRoot) > -1)
                                            {
                                                string strVirtualPathToProcess = StrSplitedReceivedMessage[1].Replace(GlobalVariables.strSiteGenerator_PathToW3wpRoot, "");
                                                strVirtualPathToProcess = strVirtualPathToProcess.Replace("\\\\?\\", "");
                                                strAnswer = new StringBuilder(SiteGenerator_Transformers.resolveNameAndFolder(strVirtualPathToProcess,ref bMatch));  // add querystring detection
                                                if (strVirtualPathToProcess != strAnswer.ToString())
                                                    processReceivedMessage("FileTransformation,-,....,-,0000,-," + StrSplitedReceivedMessage[1].ToString() + ",-," + strAnswer);
                                                if (strAnswer.ToString().IndexOf("~/") > -1)           // "~/" means 'use the virtual path
                                                {
                                                    strAnswer = new StringBuilder(Path.GetFullPath(Path.Combine(strPathToCurrentSite, strAnswer.ToString().Replace("~/", ""))));
                                                }
                                                else
                                                {
                                                    strAnswer = new StringBuilder(Path.GetFullPath(GlobalVariables.strSiteGenerator_PathToW3wpRoot + strAnswer.ToString()));
                                                }
                                                break;
                                            }                                           
                                            else
                                            {
                                                strAnswer = new StringBuilder(StrSplitedReceivedMessage[1]);
                                            }
                                            break;
                                        }
                                }

                                if (strAnswer != strQuestion)      // store the result in HashTable
                                {
                                    if (null == GlobalVariables.htCachedResults[strQuestion.ToString()])
                                    {
                                        GlobalVariables.htCachedResults.Add(strQuestion.ToString(), strAnswer.ToString());
                                        processReceivedMessage("FileTransformation,-," + StrSplitedReceivedMessage[0] + ",-,9999,-," + StrSplitedReceivedMessage[1].ToString() + ",-," + strAnswer);
                                    }
                                    else
                                        MessageBox.Show("null != GlobalVariables.htCachedResults.Add(strQuestion.ToString(), which means that this key was already in the HashTable");
                                }
                            }
                        }
                        else
                        {                            
                            processReceivedMessage(strReceivedMessage);                            
                        }
                        SharedMemoryForDotNet.smdt_sendAnswerUsingEvent(smdtToUse, strAnswer, iAnswerPosition);
                    }
                    else 
                    {
                        processReceivedMessage(strReceivedMessage);
                    }
                }
                else
                {
                    if (0 == SharedMemoryForDotNet.smdt_waitForEvent_NewMessage(smdtToUse))
                    {
                        // (this fires evert MAX_WAIT_FOR_AN_NEWMESSAGES ms) 
                    }
                }
            }    */  
        }

        public static void processReceivedMessage(string strMessageToProcess)
        {            
            if (false == GlobalVariables.bUpdateGUIWithReceivedMessages)
                return;
            populateDebugEnvironment(strMessageToProcess);
            string[] StrSplitedMessageToProcess = strMessageToProcess.Split(new string[] { ",-," }, StringSplitOptions.RemoveEmptyEntries);
            if (StrSplitedMessageToProcess.Length > 1)
            {
                switch (StrSplitedMessageToProcess[0])
                {
                    case "FileTransformation":
                    case "FileTransformation (Cached)":
                        {
                            updateListView(GlobalVariables.ascx_FileTransformations_lvFileTransformations, new ListViewItem(StrSplitedMessageToProcess));
                            break;
                        }
                        // HttpApi Hooks
                    case "HttpReceiveHttpRequest":
                        {
                            // add httpApiHook menu
                            break;
                        }
                        // Network
                    default:
                        {
                            populateDebugEnvironment("Unrecognized method:" + StrSplitedMessageToProcess[0] + " in " + Environment.NewLine + Environment.NewLine + strMessageToProcess);
                            break;
                        }
                }
            }
            
        }

        public static void populateDebugEnvironment(string strMessageToProcess)
        {
            updateTextBox(strMessageToProcess,GlobalVariables.ascx_Admin_txtDebugAllReceivedMessages);                            
        }

        private static void updateTextBox(string strText, TextBox tbToUse)
        {
            if (tbToUse.InvokeRequired)
            {
                updateTextBoxCallback utbCallback = new updateTextBoxCallback(updateTextBox);
                tbToUse.Invoke(utbCallback, new object[] { strText, tbToUse });
            }
            else
            {
                tbToUse.Text = strText + Environment.NewLine + tbToUse.Text;
            }
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
                lvToUse.Items.Insert(0,lvItemToAdd);
            }
        }
    }
}
