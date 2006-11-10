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
                            bLeftShiftDown = true; Console.WriteLine("bshift down"); break;
                        case -1070989311:
                            bLeftShiftDown = false; Console.WriteLine("bshift up"); break;
                        case 1900545:
                            bLeftCtrlDown = true; Console.WriteLine("bCtrl down"); break;
                        case -1071841279:
                            bLeftCtrlDown = false; Console.WriteLine("bCtrl up"); break;                                                        
                    }
                    
					if (iKeyPressedValue == 0)
					{
						char cKeyPressed = System.Convert.ToChar(e.wParam.ToInt32());										
						if (ccCurrentAscxControl.ActiveControl.GetType() == axCurrentAuthenticObject.GetType())
							processAuthenticKeyboardEvent((AxXMLSPYPLUGINLib.AxAuthentic)ccCurrentAscxControl.ActiveControl, cKeyPressed , (utils.LocalWindowsHook)sender);
					}
				}
		 }
		
		private void insertImageFromClipboard()
		{		
			if (clipboard.isClipboardDataAnBitmap())
			{
				string strNewImageName = Path.GetFullPath(Path.Combine(strPathToSaveClipboardImage, 
                                                                       files.returnUniqueFileName(".jpeg")));
				files.createDirectoryIfRequired(strNewImageName);
				if (clipboard.saveClipboardImageAsJpeg(strNewImageName))		
				{
					string strNewImageRelativePath = strNewImageName.Replace(strPathToUnzipSelectedFinding,"");	//make the image path relevative so that it works on multiple computers
					if (strNewImageRelativePath.Substring(0,1) == "\\") 
						strNewImageRelativePath = strNewImageRelativePath.Substring(1,strNewImageRelativePath.Length-1);
					authentic.authentic_InsertNewLine(axCurrentAuthenticObject);					// insert new line before image								
					authentic.authentic_InsertNewLine(axCurrentAuthenticObject);					// insert new line after image		
					authentic.authentic_GotoPreviousTag(axCurrentAuthenticObject); 				// goto previews tag (i.e. in between the two new lines)
					authentic.authentic_InsertImage(axCurrentAuthenticObject, strNewImageRelativePath);	// insert image
					authentic.authentic_GotoNextTag(axCurrentAuthenticObject); 					// Moving the cursor forward to the next tag
					authentic.authentic_GotoNextTag(axCurrentAuthenticObject); 									
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
					case "level2":
						if (0x0d == cKeyPressed)			// 0x0d (13) Enter
							utils.authentic.authentic_InsertNewLine(axActiveAuthenticControl);					
						break;
					case "AdittionalDetails":
						if (0x56 == cKeyPressed)	// 0x56 (86) V 
						{
                            if(bLeftCtrlDown) // if the left control key is pressed
							{							
								if (utils.clipboard.isClipboardDataAnBitmap())
									insertImageFromClipboard();
								else
								{									
									string strClipboardString = utils.clipboard.getStringWithClipboardData();											
									// encode clipboard content
									System.IO.MemoryStream msClipboardData = new System.IO.MemoryStream();
									XmlTextWriter xtwClipboardData = new XmlTextWriter(msClipboardData,null);									
									xtwClipboardData.WriteString(strClipboardString);									
									xtwClipboardData.Close();									
									string strTransformedClipboardString =  System.Text.ASCIIEncoding.ASCII.GetString(msClipboardData.ToArray()); // new XmlTextReader(xtwClipboardData).ReadInnerXml();

									// at the moment because I am not able to directly inject the newline element in the middle of this string, I have to add it manual to the selected text (with the user having to Save are reload the page)
									// when doing this transformation we also have to clean the clipboard so that we don't get two pastes
									// we also check to see if the encoding changed anything
									if (strClipboardString.IndexOf(Environment.NewLine)>-1 || strTransformedClipboardString != strClipboardString)
									{										
										strTransformedClipboardString  = strTransformedClipboardString.Replace(Environment.NewLine,"<newline/>");
										utils.authentic.setCurrentSelectedText(axActiveAuthenticControl,strTransformedClipboardString);
										utils.clipboard.SetClipboardData("");
									}
									else
										utils.clipboard.SetClipboardData(strClipboardString); // under normal circuntances there is no need to clear the clipboard and we can just paste the (normalized) string
								}
							}
							break;
						}					
						if (0x08 == cKeyPressed)			// 0x08 (08) Del 													
							break;					
						if (0x0d == cKeyPressed)			// 0x0d (13) Enter
							utils.authentic.authentic_InsertNewLine(axActiveAuthenticControl);					
						break;
				}
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message);
            }
		}

		public static void loadXmlFileInTargetAuthenticView(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject,string urlToXml,string urlToXsd,string urlToSps)
		{
            if (File.Exists(urlToXml) &&
                File.Exists(urlToXsd) &&
                File.Exists(urlToSps))
            {
                // We load the xml file into a xml document because altova keeps the 
                // handle open for the xml file causing problems when we try and do other file
                // manipulations.
                XmlDocument xdTmp = new XmlDocument();
                xdTmp.Load(urlToXml);

                axTargetAuthenticObject.SchemaLoadObject.URL = urlToXsd;
                axTargetAuthenticObject.DesignDataLoadObject.URL = urlToSps;
                axTargetAuthenticObject.XMLDataLoadObject.String = xdTmp.InnerXml;
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

		public static string getCurrentSelectedText(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			return axTargetAuthenticObject.AuthenticView.Selection.Text;
		}

		public static void setCurrentSelectedText(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strTextToSet)
		{
			axTargetAuthenticObject.AuthenticView.Selection.Text = strTextToSet;
		}

		public static void authentic_InsertElementInCurrentSelectionPos(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject,string strElementToInsert)
		{
			axTargetAuthenticObject.AuthenticView.Selection.PerformAction(XMLSPYPLUGINLib.SpyAuthenticActions.spyAuthenticInsertAt,strElementToInsert);
		}

		public static void authentic_InsertNewLine(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{			
			authentic_InsertElementInCurrentSelectionPos(axTargetAuthenticObject,"newline");			
            // BUG: This is not really working in the new Authentic version since the control lose focus
            axTargetAuthenticObject.SelectionSet(axTargetAuthenticObject.CurrentSelection.End,0,null,0);                                    
            //axTargetAuthenticObject.Focus

		}		

		// This sets the cursor to the beggining on the next Tag
		public static void authentic_GotoNextTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
		{
			if(axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag) != null) {
                axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();   
            }
			axTargetAuthenticObject.SelectionSet(axTargetAuthenticObject.CurrentSelection.Start,0,null,0);
		}

		// This sets the cursor to the beggining on the previous Tag
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
			authentic_InsertElementInCurrentSelectionPos(axTargetAuthenticObject,"img");
            authentic_GotoNextTag(axTargetAuthenticObject);
            //authentic_SelectNextTag(axTargetAuthenticObject);       // it now needs to be SelectNextTag due to changes in the 2007 Altova component
            axTargetAuthenticObject.AuthenticView.Selection.Text = strPathToImage; 
            // BUG: there is a problem with the automatic display of images in the 'Additional details' window which is the fact that the new 2007 control doesn't seem to accept relative paths (where the precious one did)            
		}

	}
}
