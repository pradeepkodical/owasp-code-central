using System;
using System.Net;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Security.Policy;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for xml.
	/// </summary>
	public class xml
	{
		public xml()
		{
		}
		public static string returnXmlXslTransformation(string sXmlPath, string sXslPath, string sTargetFilePath)
		{     
			XmlTextReader xtrXslFile = new XmlTextReader(sXslPath);
			XPathDocument myXPathDoc = null;
			XslCompiledTransform myXslTrans= null;
			XmlTextWriter myWriter= null;
			try
			{
				//load the Xml doc				
				myXslTrans = new XslCompiledTransform() ;            

				//load the Xsl into a  XmlTextReader and into the XslTransform				
				myXslTrans.Load(xtrXslFile);

                // Create the XsltArgumentList.
                XsltArgumentList argList = new XsltArgumentList();
                argList.AddParam("date", "", DateTime.Now.ToString());
        
				//create the output stream
				myWriter = new XmlTextWriter(sTargetFilePath, null);            
				myWriter.WriteProcessingInstruction("xml","version=\"1.0\" encoding=\"UTF-8\"");

				//do the actual transform of Xml	
                myXslTrans.Transform(new XPathDocument(sXmlPath), argList, myWriter);        				
				myWriter.Close() ;				
			}
			catch(Exception ex)
			{
				// clean up
				if (null != myXPathDoc)
					myXPathDoc = null;
				if (null != myXslTrans)
					myXslTrans = null;
				if (null != myWriter)
					myWriter.Close();
				if (null !=xtrXslFile)
					xtrXslFile.Close();
				return ex.ToString();
			
			}        
			xtrXslFile.Close();
			return "";
		}
	}
}
