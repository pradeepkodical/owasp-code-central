using System;
using System.Net;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Security.Policy;
using System.IO;
using System.Windows.Forms;

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

        public class xsdVerification
        {
            private UserProfile upCurrentUser = UserProfile.GetUserProfile();
            private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

            string strXmlValidationResult = "";
            bool bNoVerificationErrors = false;

            public xsdVerification(string strPathToFileToValidate, string strSchemaToUse)
            {
                this.verifyXmlFile(strPathToFileToValidate, strSchemaToUse);
                // note the results are in this strXmlValidationResult
            }                                    

            public xsdVerification(string strPathToFileToValidate, string strSchemaToUse, Label lbLabelToSet, bool bShowMessageBox)
            {
                if (true == bShowMessageBox)
                    verifyFileAndPopulateLabelAndShowMessage(strPathToFileToValidate,strSchemaToUse, lbLabelToSet);
                else
                    verifyFileAndPopulateLabel(strPathToFileToValidate,strSchemaToUse, lbLabelToSet);
            }

            public void verifyXmlFile(string strPathToFileToValidate,string strSchemaToUse)
            {
                XmlTextReader xtrFileToValidate = new XmlTextReader(strPathToFileToValidate);
                XmlReaderSettings xrs = new XmlReaderSettings();
                xrs.Schemas.Add("vuln_report", strSchemaToUse);
                xrs.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(xvrValidator_ValidationEventHandler);
                xrs.ValidationType = ValidationType.Schema;                
                
                XmlReader xrValidator = XmlReader.Create(strPathToFileToValidate, xrs);

                bNoVerificationErrors = true;
                try
                {
                    while (xrValidator.Read()) { }
                }
                catch (Exception ex)
                {
                    bNoVerificationErrors = false;
                    strXmlValidationResult += "* " + ex.Message + Environment.NewLine + Environment.NewLine;
                }
                xrValidator.Close();                
            }

            private void xvrValidator_ValidationEventHandler(Object sender, ValidationEventArgs args)
            {
                bNoVerificationErrors = false;
                strXmlValidationResult += "* " + args.Message + Environment.NewLine + Environment.NewLine;
            }

            private void copyXSDToDirectory(string strTargetDirectory, string cbPathXsdtoUseOnExport)
            {
                string strPathToXsdFile = Path.Combine(obpPaths.XsdFilePath, cbPathXsdtoUseOnExport);
                string strPathToDestinationXsdFile = Path.Combine(strTargetDirectory, Path.GetFileName(strPathToXsdFile));
                File.Copy(strPathToXsdFile, strPathToDestinationXsdFile, true);
            }

            public string StrXmlValidationResult
            {
                get
                {
                    return strXmlValidationResult;
                }
            }

            public void setLabelBasedOnResult(Label lbLabelToSet)
            {
                if (true == bNoVerificationErrors)                
                    lbLabelToSet.Visible = false;                
                else
                    lbLabelToSet.Visible = true;
            }

            public void showMessageBoxWithVerificationResult()
            {
                if (false == bNoVerificationErrors)
                    MessageBox.Show("Validation errors:" + Environment.NewLine + Environment.NewLine + this.strXmlValidationResult, "Xml fails XSD Validation - Please fix these errors since this will break the reports");
            }

            public void verifyFileAndPopulateLabel(string strPathToFileToValidate, string strSchemaToUse, Label lbLabelToSet)
            {
                this.verifyXmlFile(strPathToFileToValidate, strSchemaToUse);
                this.setLabelBasedOnResult(lbLabelToSet);
            }

            public void verifyFileAndPopulateLabelAndShowMessage(string strPathToFileToValidate, string strSchemaToUse, Label lbLabelToSet)
            {
                this.verifyXmlFile(strPathToFileToValidate, strSchemaToUse);
                this.setLabelBasedOnResult(lbLabelToSet);
                this.showMessageBoxWithVerificationResult();
            }
        }        
	}
}
