using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Owasp.VulnReport.utils;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for authentic.
	/// </summary>
	public class authentic
	{
        private LocalWindowsHook lwhKeyboardHook;
        private ContainerControl ccCurrentAscxControl = null;
		private AxXMLSPYPLUGINLib.AxAuthentic axCurrentAuthenticObject = null;		

        // TODO: We need to see how and where these are set and then make them not static.
		public static string strPathToSaveClipboardImage = "";
		public static string strPathToUnzipSelectedFinding = "";
        public static bool bLeftShiftDown = false; 
        public static bool bLeftCtrlDown = false;

		public authentic()
		{
        }

        private void dispose(bool disposing)
        {
            if (disposing)
            {
                if ((lwhKeyboardHook != null) && (lwhKeyboardHook.IsInstalled))
                {
                    lwhKeyboardHook.Uninstall();
                }
            }
        }
#region Properties
        public LocalWindowsHook CurrentKeyboardHook
        {
            get
            {
                return lwhKeyboardHook;
            }
        }

        public AxXMLSPYPLUGINLib.AxAuthentic AuthenticObject
        {
            get
            {
                return axCurrentAuthenticObject;
            }
            set
            {
                axCurrentAuthenticObject = value;
            }
        }

        public ContainerControl CurrentControl
        {
            get
            {
                return ccCurrentAscxControl;
            }
            set
            {
                ccCurrentAscxControl = value;
            }
        }
#endregion

        public void unInstallKeyboardHookFromCurrentThread()
		{
            if ((this.lwhKeyboardHook != null) && (this.lwhKeyboardHook.IsInstalled))
            {
                this.lwhKeyboardHook.Uninstall();
                this.lwhKeyboardHook = null;
            }
		}
		public void installKeyboardHookInCurrentThread()
		{
            if (this.lwhKeyboardHook != null)
                this.unInstallKeyboardHookFromCurrentThread();

			this.lwhKeyboardHook = new LocalWindowsHook(utils.LocalWindowsHook.HookType.WH_KEYBOARD);			
			this.lwhKeyboardHook.Install();			
			this.lwhKeyboardHook.HookInvoked += new Owasp.VulnReport.utils.LocalWindowsHook.HookEventHandler(lwKeyboardHook_HookInvoked);											
		}

		private void lwKeyboardHook_HookInvoked(object sender, LocalWindowsHook.HookEventArgs e)
		{            
			if (ccCurrentAscxControl != null && ccCurrentAscxControl.ActiveControl != null)
				if ((int)LocalWindowsHook.HookCode.HC_ACTION == (int)e.HookCode)
				{                    
					long iKeyPressedValue = e.lParam.ToInt32() & ~0x7fffffff;	// I use the last bit (31) to mean KeyPressed (note that if the key is pressed continuiously, then we will have multiple events) http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/keyboardproc.asp
                    switch (e.lParam.ToInt32())
                    { 
                        case 2752513:
                            bLeftShiftDown = true;// Console.WriteLine("bshift down");
                            break;
                        case -1070989311:
                            bLeftShiftDown = false;// Console.WriteLine("bshift up");
                            break;
                        case 1900545:
                            bLeftCtrlDown = true;// Console.WriteLine("bCtrl down");
                            break;
                        case -1071841279:
                            bLeftCtrlDown = false;// Console.WriteLine("bCtrl up");
                            break;                                                        
                    }
                    
					if (iKeyPressedValue == 0)
					{
                      //  Console.WriteLine(axCurrentAuthenticObject.Focused.ToString() + " " + axCurrentAuthenticObject.Focus());
						char cKeyPressed = System.Convert.ToChar(e.wParam.ToInt32());

                        Control ctrControlWithFocus = getControlWithFocus(ccCurrentAscxControl.ActiveControl);
                        if (null != ctrControlWithFocus)
                        {
                            if (ctrControlWithFocus.GetType() == axCurrentAuthenticObject.GetType())
                                processAuthenticKeyboardEvent((AxXMLSPYPLUGINLib.AxAuthentic)ctrControlWithFocus, cKeyPressed, (utils.LocalWindowsHook)sender);                           
                        }
                        /*
                        object objToProcess = ccCurrentAscxControl.ActiveControl;
                        if ("System.Windows.Forms.SplitContainer" == objToProcess.GetType().ToString())
                        {
                            SplitContainer scSplitContainer = (SplitContainer)ccCurrentAscxControl.ActiveControl;
                            foreach (object objControlInPanel in scSplitContainer.Panel2.Controls)
                            {
                                if ("System.Windows.Forms.SplitContainer" == objControlInPanel.GetType().ToString())
                                {
                                    SplitContainer scSplitContainer_Inside = (SplitContainer)objControlInPanel;
                                    foreach (Control ctrControlInPanel2 in scSplitContainer_Inside.Panel2.Controls)
                                    {
                                        if (true == ctrControlInPanel2.ContainsFocus)
                                            Console.WriteLine(string.Format("Contains Focus: Control in {0} : {1} :{2} : {3}", scSplitContainer.Name, scSplitContainer_Inside.Name, ctrControlInPanel2.Name, ctrControlInPanel2.Focused));                                        
                                        if (true == ctrControlInPanel2.Focused)
                                            Console.WriteLine(string.Format("Focused : Control in {0} : {1} :{2} : {3}", scSplitContainer.Name, scSplitContainer_Inside.Name, ctrControlInPanel2.Name, ctrControlInPanel2.Focused));                                        
                                        
                                    }
                                }
                                    
                            }
                        }
                         * */
                        //Console.WriteLine(ccCurrentAscxControl.ActiveControl.GetType());						
					}
				}
		 }

        private Control getControlWithFocus(Control ctrControlToProcess)
        {
            //if (ctrControlToProcess.Focused)
            //    return 
            if (ctrControlToProcess.Controls.Count == 0)        // another way we can find our control (the axAuthentic don't have the Focused flag enabled)
                return ctrControlToProcess;
            foreach (Control ctrControl in ctrControlToProcess.Controls)
            {
                if (true == ctrControl.Focused)
                    return ctrControl;
                else
                    if (true == ctrControl.ContainsFocus)
                    {
                        return getControlWithFocus(ctrControl);
                    }

            }
            return null;
        }

        private void checkForEnterAndInsertNewLine(AxXMLSPYPLUGINLib.AxAuthentic axActiveAuthenticControl,char cKeyPressed)
        {
            if (0x0d == cKeyPressed)			// 0x0d (13) Enter
                utils.authentic.authentic_InsertNewLine(axActiveAuthenticControl);
        }

        private void checkForCtrlVandInsertDataFromClipboard(AxXMLSPYPLUGINLib.AxAuthentic axActiveAuthenticControl,char cKeyPressed, bool bCheckForImages)
        {
            if (0x56 == cKeyPressed)	// 0x56 (86) V 
            {
                if (bLeftCtrlDown) // if the left control key is pressed
                {
                    if (true == bCheckForImages && true == utils.clipboard.isClipboardDataAnBitmap())
                        insertImageFromClipboard();
                    else
                    {
                        insertTextFromClipboard(axActiveAuthenticControl);
                    }
                }                
            }		
        }
        private void insertTextFromClipboard(AxXMLSPYPLUGINLib.AxAuthentic axActiveAuthenticControl)
        {
            string strClipboardString = utils.clipboard.getStringWithClipboardData();
            // encode clipboard content
            System.IO.MemoryStream msClipboardData = new System.IO.MemoryStream();
            // populate msClipboardData with strClipboardString contents
            XmlTextWriter xtwClipboardData = new XmlTextWriter(msClipboardData, null);
            xtwClipboardData.WriteString(strClipboardString);
            xtwClipboardData.Close();
            string strTransformedClipboardString = System.Text.ASCIIEncoding.ASCII.GetString(msClipboardData.ToArray()); // new XmlTextReader(xtwClipboardData).ReadInnerXml();

            // at the moment because I am not able to directly inject the newline element in the middle of this string, I have to add it manual to the selected text (with the user having to Save are reload the page)
            // when doing this transformation we also have to clean the clipboard so that we don't get two pastes
            // we also check to see if the encoding changed anything
            if (strClipboardString.IndexOf(Environment.NewLine) > -1 || strTransformedClipboardString != strClipboardString)
            {
                authentic.setCurrentSelectedText(axActiveAuthenticControl, strTransformedClipboardString);
                utils.clipboard.SetClipboardData("");   // we have to clean it or the Authentic control will paste the content
            }
            else
                utils.clipboard.SetClipboardData(strClipboardString); // under normal circuntances there is no need to clear the clipboard and we can just paste the (normalized) string
        }

		private void insertImageFromClipboard()
		{		
			if (true == clipboard.isClipboardDataAnBitmap())
			{
				string strNewImageName = Path.GetFullPath(Path.Combine(strPathToSaveClipboardImage, 
                                                                       files.returnUniqueFileName(".jpeg")));
				files.createDirectoryIfRequired(strNewImageName);
				if (clipboard.saveClipboardImageAsJpeg(strNewImageName))
                {
                    string strNewImageRelativePath = strNewImageName.Replace(strPathToUnzipSelectedFinding, "");	//make the image path relevative so that it works on multiple computers
                    if (strNewImageRelativePath.Substring(0, 1) == "\\")
                        strNewImageRelativePath = strNewImageRelativePath.Substring(1, strNewImageRelativePath.Length - 1);
                    // 5-feb-07:[Dinis]: 
                    //      I removed these those lines since they where making the copy and paste not work in some ocasions (namely where there was no text selected)
                    //      The error seemed to be related to a lack of refresh when you add a new element progamatically (in this case we were adding some newlines and then the img
                    //authentic.authentic_InsertNewLine(axCurrentAuthenticObject);					// insert new line before image								
                    //authentic.authentic_InsertNewLine(axCurrentAuthenticObject);					// insert new line after image		
                    //authentic.authentic_GotoPreviousTag(axCurrentAuthenticObject); 				    // goto previews tag (i.e. in between the two new lines)
                    authentic.authentic_InsertImage(axCurrentAuthenticObject, strNewImageRelativePath);	// insert image
                    // 5-feb-07:[Dinis]: 
                    //      See above description
                    //authentic.authentic_GotoNextTag(axCurrentAuthenticObject); 					    // Moving the cursor forward to the next tag
                    //authentic.authentic_GotoNextTag(axCurrentAuthenticObject); 									
                }
			}
		}

		private void processAuthenticKeyboardEvent(AxXMLSPYPLUGINLib.AxAuthentic axActiveAuthenticControl, char cKeyPressed, utils.LocalWindowsHook lwhSender)
		{
			try
			{                
				// find out which control is currently selected
				string strCurrentSelectedControl = "";
				if (axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.kind != XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataText)
					strCurrentSelectedControl = axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.Name;
				else
					if (axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.Parent.kind != XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataText)
					strCurrentSelectedControl = axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.Parent.Name;
				else
					strCurrentSelectedControl = "Error in recognizing SPYXMLDataKind";			
				// apply Gui Funcionality
				switch (strCurrentSelectedControl)
				{                    
	                case "value":               // this could be the Target DNS or IP
                        string strParentControl = axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.Parent.Name;
                        if (cKeyPressed == 0x0d)
                        {
                            // 05-Feb-07: [Dinis], This is a hack to make the Enter work with the DnsName and IP elements (which use an attribute for its value and don't work in the new version of the Authentic component)

                            // get the value of the current element which should be either DnsValue or IP
                            string strValueOfCurrentElement = axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.TextValue ;
                            // get the parent.parent object which should be a 'Target' Element
                            XMLSPYPLUGINLib.XMLData xdData = axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.Parent.Parent;
                            if (xdData.Name == "Target")
                            {
                                // Now we are going to create manually either the 'DnsValue' or the 'IP' Element (the name we need is conveiniently in strParentControl)  
                                XMLSPYPLUGINLib.XMLData xdXmlDataElement = axActiveAuthenticControl.CreateChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataElement);
                                xdXmlDataElement.Name = strParentControl;
                                // create the atribute 'value'
                                XMLSPYPLUGINLib.XMLData xdXmlDataAttribute = axActiveAuthenticControl.CreateChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
                                xdXmlDataAttribute.Name = "value";
                                // add addit it to the xdXmlDataElement
                                xdXmlDataElement.AppendChild(xdXmlDataAttribute);
                                // now that we have an 'DnsValue' or 'IP' element ready we need to find the correct location to insert it (note that due to the current xsd you cannot append it at the end)
                                // Get first Child
                                XMLSPYPLUGINLib.XMLData xdChild = xdData.GetFirstChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataElement);
                                // and go though all childs until we find the current one
                                for (int iChildId = 0; iChildId < xdData.CountChildren(); iChildId++)
                                {
                                    // at lack of better choise we will use the 'value' attribute to try to fing the location to insert (the only problem will happen if there is a duplicate 'value' (which would be a mistake in this case))
                                    if (xdChild.Name == strParentControl && getAttributeFromElement(xdChild, "value") == strValueOfCurrentElement)
                                    {
                                        // This will place the new Element before the current one
                                        xdData.InsertChild(xdXmlDataElement);
                                        // xdData.AppendChild(xdXmlDataElement);   /// this one doesn't work since it all puts it at the end
                                        break;
                                    }
                                    // move to the next child (we need to do this so that the InsertChild works as expected
                                    if (iChildId < xdData.CountChildren() - 1)            // don't go to the next child if we are on the last one
                                        xdChild = xdData.GetNextChild();
                                }
                            }
                        }                                             
                        break;
                        
                        switch (strParentControl)
                        {
                            case "DnsName":
                                authentic.authentic_GotoNextTag(axActiveAuthenticControl);
                                authentic.authentic_GotoNextTag(axActiveAuthenticControl);
                                authentic.authentic_GotoNextTag(axActiveAuthenticControl);
                                authentic.authentic_GotoNextTag(axActiveAuthenticControl);

                                ///string strText = 
                                
                                string strParentContol2 = axActiveAuthenticControl.AuthenticView.Selection.FirstXMLData.Name;

                                // bool bResulta = authentic.authentic_InsertElementInCurrentSelectionPos_spyAuthenticInsertBefore(axActiveAuthenticControl, "DnsName");
                                break;
                            case "IP":
                                break;

                        }
                        break;      
					case "level2":
                    case "level3":
                        checkForCtrlVandInsertDataFromClipboard(axActiveAuthenticControl,cKeyPressed, false);
                        checkForEnterAndInsertNewLine(axActiveAuthenticControl,cKeyPressed);

						//if (0x0d == cKeyPressed)			// 0x0d (13) Enter
						//	utils.authentic.authentic_InsertNewLine(axActiveAuthenticControl);					
						break;
					case "AdittionalDetails":
                        checkForCtrlVandInsertDataFromClipboard(axActiveAuthenticControl,cKeyPressed, true);
						if (0x08 == cKeyPressed)			// 0x08 (08) Del 													
							break;
                        checkForEnterAndInsertNewLine(axActiveAuthenticControl, cKeyPressed);
						//if (0x0d == cKeyPressed)			// 0x0d (13) Enter
						//	utils.authentic.authentic_InsertNewLine(axActiveAuthenticControl);					
						break;
				}
			}
			catch  (Exception ex)
			{
                MessageBox.Show(ex.Message);      // this was being thrown during normal ORG usage 
            }
		}       

		public static void loadXmlFileInTargetAuthenticView(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject,string urlToXml,string urlToXsd,string urlToSps)
		{
            try
            {
                if (File.Exists(urlToXml) &&
                    File.Exists(urlToXsd) &&
                    File.Exists(urlToSps))
                {
                    axTargetAuthenticObject.SchemaLoadObject.URL = urlToXsd;
                    axTargetAuthenticObject.DesignDataLoadObject.URL = urlToSps;
                    axTargetAuthenticObject.XMLDataLoadObject.URL = urlToXml;
                    axTargetAuthenticObject.XMLDataSaveUrl = urlToXml;
                    axTargetAuthenticObject.EntryHelpersEnabled = true;
                    axTargetAuthenticObject.AllowDrop = true;
                    axTargetAuthenticObject.StartEditing();
                    axTargetAuthenticObject.Visible = true;
                }
                else
                {
                    axTargetAuthenticObject.Visible = false;
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(string.Format("Error in loadXmlFileInTargetAuthenticView: {0}",ex.Message));
            }
		}

		public static string getCurrentSelectedText(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			return axTargetAuthenticObject.AuthenticView.Selection.Text;
		}

		public static void setCurrentSelectedText(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strTextToSet)
		{
            // We need to handle the case when the text that is being added 
            // has newlines in it.  We want to preserve the user's formatting 
            // when it goes onto the altova control.  
            if (strTextToSet.IndexOf(Environment.NewLine) > -1)
            {
                string strText = strTextToSet;

                while (strText.IndexOf(Environment.NewLine) > -1)
                {
                    int newlinePos = strText.IndexOf(Environment.NewLine);
                    string tmp = strText.Substring(0, newlinePos);

                    // We need to remove the newline as well from the current string
                    strText = strText.Remove(0, newlinePos + Environment.NewLine.Length);
                    setCurrentSelectedText(axTargetAuthenticObject, tmp);
                    authentic.authentic_InsertNewLine(axTargetAuthenticObject);
                }

                // Add the last line 
                if (!strText.Trim().Equals("")) 
                { 
                    setCurrentSelectedText(axTargetAuthenticObject, strText);
                }
            }
            else
            {
                axTargetAuthenticObject.AuthenticView.Selection.Text = strTextToSet;
            }
		}

        public static bool authentic_InsertElementInCurrentSelectionPos_spyAuthenticInsertAt(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strElementToInsert)
		{
			return axTargetAuthenticObject.AuthenticView.Selection.PerformAction(XMLSPYPLUGINLib.SpyAuthenticActions.spyAuthenticInsertAt,strElementToInsert);                        
		}

        public static bool authentic_InsertElementInCurrentSelectionPos_spyAuthenticInsertBefore(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strElementToInsert)
        {            
            return axTargetAuthenticObject.AuthenticView.Selection.PerformAction(XMLSPYPLUGINLib.SpyAuthenticActions.spyAuthenticInsertBefore, strElementToInsert);                       
        }

        /// <summary>
        /// Description: This method is used to add a newline into the specified authentic object
        /// 
        /// History: 
        ///   11/25/2006 - Mike : Fixed a bug where the cursor wasn't going to the added newline
        /// </summary>
        /// <param name="axTargetAuthenticObject"></param>
		public static void authentic_InsertNewLine(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
            XMLSPYPLUGINLib.AuthenticRange ar = axTargetAuthenticObject.AuthenticView.Selection;
			authentic_InsertElementInCurrentSelectionPos_spyAuthenticInsertAt(axTargetAuthenticObject,"newline");
            axTargetAuthenticObject.AuthenticView.Selection = ar;
            axTargetAuthenticObject.AuthenticView.Selection =
                axTargetAuthenticObject.AuthenticView.Selection.GotoNextCursorPosition();
		}		

		// This sets the cursor to the beggining on the next Tag
		public static void authentic_GotoNextTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			if(axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag) != null) {
                axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();   
            }
			axTargetAuthenticObject.SelectionSet(axTargetAuthenticObject.CurrentSelection.Start,0,null,0);
		}

		// This sets the cursor to the begining on the previous Tag
		public static void authentic_GotoPreviousTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			if(axTargetAuthenticObject.AuthenticView.Selection.SelectPrevious(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag) != null) {
                axTargetAuthenticObject.AuthenticView.Selection.SelectPrevious(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();   
            }
			axTargetAuthenticObject.SelectionSet(axTargetAuthenticObject.CurrentSelection.Start,0,null,0);
		}


		public static void authentic_SelectNextTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
            if (axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag) != null)
            {
                axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();
            }
		}

        public static XMLSPYPLUGINLib.AuthenticRangeClass authentic_SelectPreviousTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			try	
			{
                XMLSPYPLUGINLib.AuthenticRangeClass arcSelectedObject = (XMLSPYPLUGINLib.AuthenticRangeClass)axTargetAuthenticObject.AuthenticView.Selection.SelectPrevious(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag);                
                arcSelectedObject.Select();
                return arcSelectedObject;
			} 
			catch {}
            return null;
		}

		public static void authentic_SelectNextWord(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			try	
			{
				axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticWord).Select();
			}
			catch {}
		}

		public static void authentic_SelectPreviousWord(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			try	
			{
				axTargetAuthenticObject.AuthenticView.Selection.SelectPrevious(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticWord).Select();
			}
			catch {}
		}
		public static void authentic_InsertImage(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strPathToImage)
		{
            if ("" != axTargetAuthenticObject.AuthenticView.Selection.Text)         // if there is some text selected, we have to select the next item
            {
                // move this into a method call authentic_ClearCurrentSelection
                axTargetAuthenticObject.AuthenticView.Selection =
                    axTargetAuthenticObject.AuthenticView.Selection.GotoNextCursorPosition();
            }
           // XMLSPYPLUGINLib.AuthenticRange ar = axTargetAuthenticObject.AuthenticView.Selection;
            if (true == authentic_InsertElementInCurrentSelectionPos_spyAuthenticInsertBefore(axTargetAuthenticObject, "img") &&
               (axTargetAuthenticObject.AuthenticView.Selection.FirstXMLData.Name == "src"))
            {
                    axTargetAuthenticObject.AuthenticView.Selection.FirstXMLData.TextValue = strPathToImage;
                    authentic.authentic_GotoNextTag(axTargetAuthenticObject);
                    // this authentic_GotoNextTag is sort of working since it is removing the focus from the img's src tag entry area, but it is not putting the focus after it
                    
            }
            else
            {
                MessageBox.Show("Could not paste image due to a bug in the code. Please select some text and try again");
                //this bit is not working
                //authentic_SelectNextTag(axTargetAuthenticObject); // it now needs to be SelectNextTag due to changes in the 2007 Altova component
                //axTargetAuthenticObject.AuthenticView.Selection.Text = strPathToImage;
            }          
		}

        static XMLSPYPLUGINLib.XMLData findXmlDataRecursively(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strElementToFind)
        {
            XMLSPYPLUGINLib.XMLData xdXmlData = axTargetAuthenticObject.AuthenticView.WholeDocument.FirstXMLData;
            while (xdXmlData.Name != strElementToFind)
            {
                xdXmlData = xdXmlData.Parent;
            }
            return xdXmlData;
        }

        static string getAttributeFromElement(XMLSPYPLUGINLib.XMLData xnDataToSearch, string strAttributeName)
        {             
            if (true == xnDataToSearch.HasChildren)            
                for( int iChildId = 0; iChildId < xnDataToSearch.CountChildren(); iChildId++)
                {
                    XMLSPYPLUGINLib.XMLData xdAttribute = xnDataToSearch.GetChild(iChildId);
                    if (XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr ==  xdAttribute.kind)
                        if (strAttributeName == xdAttribute.Name)
                            return xdAttribute.TextValue;
                }
            return "";
        }
	}
}
