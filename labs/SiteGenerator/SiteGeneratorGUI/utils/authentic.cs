using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Owasp.SiteGenerator.utils
{
    /// <summary>
    /// Summary description for authentic.
    /// </summary>
    public class authentic
    {
        public authentic()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void loadXmlFileInTargetAuthenticView(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string urlToXml, string urlToXsd, string urlToSps)
        {
            try
            {
                if (File.Exists(urlToXsd) &&
                   File.Exists(urlToXml) &&
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
            catch (Exception e)
            {
                axTargetAuthenticObject.Visible = false;
                MessageBox.Show("Error in loadXmlFileInTargetAuthenticView: " + e.Message);
            }
        }

        public static string getCurrentSelectedText(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
        {
            return axTargetAuthenticObject.AuthenticView.Selection.Text;
        }

        public static void authentic_InsertElementInCurrentSelectionPos(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strElementToInsert)
        {
            axTargetAuthenticObject.AuthenticView.Selection.PerformAction(XMLSPYPLUGINLib.SpyAuthenticActions.spyAuthenticInsertAt, strElementToInsert);
        }

        public static void authentic_InsertNewLine(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
        {
            authentic_InsertElementInCurrentSelectionPos(axTargetAuthenticObject, "newline");
            axTargetAuthenticObject.SelectionSet(axTargetAuthenticObject.CurrentSelection.Start, 0, null, 0);
        }

        // This sets the cursor to the beggining on the next Tag
        public static void authentic_GotoNextTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
        {
            axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();
            axTargetAuthenticObject.SelectionSet(axTargetAuthenticObject.CurrentSelection.Start, 0, null, 0);
        }

        // This sets the cursor to the beggining on the previous Tag
        public static void authentic_GotoPreviousTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
        {
            try
            {
                axTargetAuthenticObject.AuthenticView.Selection.SelectPrevious(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();
                axTargetAuthenticObject.SelectionSet(axTargetAuthenticObject.CurrentSelection.Start, 0, null, 0);
            }
            catch { }
        }


        public static void authentic_SelectNextTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
        {
            try
            {
                axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();
            }
            catch { }
        }

        public static void authentic_SelectPreviousTag(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
        {
            try
            {
                axTargetAuthenticObject.AuthenticView.Selection.SelectPrevious(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticTag).Select();
            }
            catch { }
        }

        public static void authentic_SelectNextWord(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject)
        {
            try
            {
                axTargetAuthenticObject.AuthenticView.Selection.SelectNext(XMLSPYPLUGINLib.SPYAuthenticElementKind.spyAuthenticWord).Select();
            }
            catch { }
        }

        public static void authentic_InsertImage(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject, string strPathToImage)
        {
            authentic_InsertElementInCurrentSelectionPos(axTargetAuthenticObject, "img");
            authentic_SelectPreviousTag(axTargetAuthenticObject);
            axTargetAuthenticObject.AuthenticView.Selection.Text = strPathToImage;
        }

    }
}
