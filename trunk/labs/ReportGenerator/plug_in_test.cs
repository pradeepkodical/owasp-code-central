using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using Owasp.VulnReport.utils;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
			
public class ORG_PowerPoint_Plug_in_______
{
	public class dashboardData
	{
		public string strRegion;
		public string strStatus;
		public string strTotal_Critical;
		public string strTotal_High;
		public string strTotal_Medium;
		public string strTotal_Low;
		public string strOpen_Critical;
		public string strOpen_High;
		public string strOpen_Medium;
		public string strOpen_Low;
		public string strComment;
	}

	static string strPathToTemplatePowerpointFile;
	static string strPathToXmlFileWithData;
	static XmlNodeList xnlRISO_Report_Pages;
			    
	static bool getDataFromXmlFile(string strXmlFileToProcess)
	{
		try
		{
			XmlDocument xdPlugInXmlFile = new XmlDocument();
			xdPlugInXmlFile.Load(strXmlFileToProcess);
			strPathToTemplatePowerpointFile = Path.Combine(Environment.CurrentDirectory,xdPlugInXmlFile.GetElementsByTagName("PathToTemplatePowerpointFile")[0].InnerText);
			strPathToXmlFileWithData = xdPlugInXmlFile.GetElementsByTagName("PathToXmlFileWithData")[0].InnerText;
			xnlRISO_Report_Pages = xdPlugInXmlFile.GetElementsByTagName("RISO_Report_Page");						
			return true;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error in getDataFromXmlFile: "+ ex.Message);
			return false;
		}
					
	}
			    
	static void processXSLTs()
	{
		foreach(XmlNode xnRISOReport in xnlRISO_Report_Pages)
		{
			string strPathToRISOXsltFile = xnRISOReport["PathToRISOXsltFile"].InnerXml;
			string strComment = xnRISOReport["Comment"].InnerXml;
			string strXmlTransformedFile = Path.GetTempFileName();
			string strXsltResult = xml.returnXmlXslTransformation(strPathToXmlFileWithData,strPathToRISOXsltFile,strXmlTransformedFile);
			if ("" != strXsltResult)
				MessageBox.Show(strXsltResult);
			else
				MessageBox.Show(files.GetFileContents(strXmlTransformedFile));
		}
		//	
	}
};
			
public class powerpoint2___________
{
    Microsoft.Office.Interop.PowerPoint.Application objApp;
    Microsoft.Office.Interop.PowerPoint.Presentations objPresSet;
    Microsoft.Office.Interop.PowerPoint._Presentation objPres;
    Microsoft.Office.Interop.PowerPoint.Slides objSlides;
    Microsoft.Office.Interop.PowerPoint._Slide objSlide;
	ORG_PowerPoint_Plug_in_______.dashboardData ddDashboardData;
		
	string strTemplate = @"";
	
	public powerpoint2___________()
	{
		CreateAndShowPresentation();
	}
		
	public powerpoint2___________(string strTemplate, ORG_PowerPoint_Plug_in_______.dashboardData ddDashboardData )
	{
		if (strTemplate!= "")
			this.strTemplate = strTemplate;			
		this.ddDashboardData = ddDashboardData;		
		CreateAndShowPresentation();
	}
		
	private void createSlideFromTemplate()
	{			
					
		//Create a new presentation based on a template.
        objApp = new Microsoft.Office.Interop.PowerPoint.Application();
		objApp.Visible = MsoTriState.msoTrue;
		objPresSet = objApp.Presentations;
		objPres = objPresSet.Open(strTemplate, 
			MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
		objSlides = objPres.Slides;
	}
		
	private void insertSlide(ORG_PowerPoint_Plug_in_______.dashboardData ddDashBoardDataToProcess)
	{
        Microsoft.Office.Interop.PowerPoint.SlideRange psrSlideRange = objSlides[1].Duplicate();
		objSlide = psrSlideRange[1];			

		objSlide.Shapes[2].Table.Rows[2].Cells[2].Shape.TextFrame.TextRange.Text = ddDashboardData.strTotal_Critical;
		objSlide.Shapes[2].Table.Rows[3].Cells[2].Shape.TextFrame.TextRange.Text = ddDashboardData.strTotal_High;
		objSlide.Shapes[2].Table.Rows[4].Cells[2].Shape.TextFrame.TextRange.Text = ddDashboardData.strTotal_Medium;
		objSlide.Shapes[2].Table.Rows[5].Cells[2].Shape.TextFrame.TextRange.Text = ddDashboardData.strTotal_Low	;	
			
		objSlide.Shapes[2].Table.Rows[2].Cells[3].Shape.TextFrame.TextRange.Text = ddDashboardData.strOpen_Critical;
		objSlide.Shapes[2].Table.Rows[3].Cells[3].Shape.TextFrame.TextRange.Text = ddDashboardData.strOpen_High;
		objSlide.Shapes[2].Table.Rows[4].Cells[3].Shape.TextFrame.TextRange.Text = ddDashboardData.strOpen_Medium;
		objSlide.Shapes[2].Table.Rows[5].Cells[3].Shape.TextFrame.TextRange.Text = ddDashboardData.strOpen_Low	;	


		objSlide.Shapes[5].TextFrame.TextRange.Text = ddDashboardData.strStatus; // Status and Trend
		objSlide.Shapes[6].TextFrame.TextRange.Text = ddDashboardData.strRegion; // Business Unit
		objSlide.Shapes[7].TextFrame.TextRange.Text = "?";		// Arrows  (don't handle these ones for now)
	}
					
	public void CreateAndShowPresentation()
	{			
		createSlideFromTemplate();		
		insertSlide(ddDashboardData);
		objSlides[1].Delete(); // Delete the first Slide which is the template																											   
	}		
}