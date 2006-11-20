<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:import href = "xsl_HTML_MAPPINGS.xsl" />

<xsl:template match="default">

	<html>
	<head>	
		<title><xsl:value-of select="head.title" /></title>
  	  	<style>
  			body { font-family: Arial; font-size: 14pt } 
  			a { text-decoration: none}
  			i { font-family: verdana}
  			td { font-family: Arial; font-size: 10pt } 
  			.td_small_font { font-family: Arial; font-size: 10pt }
  			.td_verySmall_font { font-family: Arial; font-size: 8pt }
  			.td_LHS_Menu { font-family: Arial; font-size: 12pt; font-weight: bold; color: white; text-decoration: none}
  			.title { font-family: Arial; font-size: 18pt; font-weight: bold;} 
  			.smallItalic { font-family: verdana; font-size: 08pt; font-weight: normal;}   			  			  			  			
  	  	</style> 
  	
 	  	<script language="Javascript">				
			
			webServiceAddress = "../WebServices/ReturnReflectedData.asmx/___ReturnReflectedData_WebService?stringObjectToReflect=";												
							
			function HideShow(divToHide,divToProcess,mode)
			{	
				if 	(document.all.item(divToHide).innerHTML!='')
				{
					document.all.item(document.all.item(divToHide).innerHTML).style.visibility = "hidden"
				}
				document.all.item(divToHide).innerHTML=divToProcess;								
				document.all.item(divToProcess).style.visibility = mode; 
			}
			
			function loadXMLtransformInDiv(xmlFile, xslFile, targetDiv)
			{
				
				xmlObject = new ActiveXObject("Microsoft.XMLDOM")
				xmlObject.async = false;
				xmlObject.load(xmlFile);				
				xslObject = new ActiveXObject("Microsoft.XMLDOM")
				xslObject.async = false;
				xslObject.load(xslFile);				
				
				//alert(xmlObject.transformNode(xslObject));
				document.all.item(targetDiv).innerHTML = xmlObject.transformNode(xslObject);
				
			}

			function PopulateTableWithReflectedData(webServiceAddress,whatToReturn,xsltToUse)
			{
				//alert(webServiceAddress+whatToReturn)				
				divName = "divWithDynamicListOf"+whatToReturn;				
				//document.all.item(divName).innerHTML = webServiceAddress+whatToReturn;
				loadXMLtransformInDiv(webServiceAddress+whatToReturn,xsltToUse,"divWithDynamicListOf"+whatToReturn);
			}
			
			function loadAndDynamicallyDisplayDynamicDataUsingDirectPath(DirectPath)
			{
				newPath = DirectPath;
				semiProcessedDirectPath = DirectPath +":";
				retrieveDataFromWebServicesAndPopulateWebPage(semiProcessedDirectPath ,newPath)		
			}
			
			function loadAndDynamicallyDisplayDynamicData(CurrentType,valueToLoad,currentTypeOfValueToLoad)
			{			
				
				populatedFieldsWithDataToGet = "" + document.all.item("CurrentPath").innerHTML + CurrentType +valueToLoad+":"+currentTypeOfValueToLoad+":";				
				
				newPath = document.all.item("CurrentPath").innerHTML + CurrentType + valueToLoad+":"+currentTypeOfValueToLoad; 	
											   				
				retrieveDataFromWebServicesAndPopulateWebPage(populatedFieldsWithDataToGet,newPath)		
			}

			function retrieveDataFromWebServicesAndPopulateWebPage(populatedFieldsWithDataToGet,newPath)
			{

				webServiceAddressWithQueryString  = webServiceAddress  +  populatedFieldsWithDataToGet ;				
				
				document.all.item("CurrentPath").innerHTML = newPath; //document.all.item("CurrentPath").innerHTML + CurrentType + valueToLoad+":"+currentTypeOfValueToLoad; 								   								
				PopulateTableWithReflectedData(webServiceAddressWithQueryString,"Properties","../xslt/TableWithList.xslt");												
				PopulateTableWithReflectedData(webServiceAddressWithQueryString,"Methods","../xslt/methodsTable.xslt");
				PopulateTableWithReflectedData(webServiceAddressWithQueryString,"Fields","../xslt/fieldsTable.xslt");				
				PopulateTableWithReflectedData(webServiceAddressWithQueryString,"PropertiesWithValues","../xslt/propertiesWithValuesTable.xslt");
				
				document.all.item("ProcessedPath").innerHTML = document.all.item("newProcessedPath")(0).innerHTML;

			}			
	
			function invokeMethod(CurrentType,valueToLoad,currentTypeOfValueToLoad)						
			{
				populatedFieldsWithDataToGet = "" + document.all.item("CurrentPath").innerHTML + CurrentType +valueToLoad+":"+currentTypeOfValueToLoad+":";				
								
				webServiceAddressWithQueryString  = webServiceAddress  +  populatedFieldsWithDataToGet ;							
				loadXMLtransformInDiv(webServiceAddressWithQueryString  ,"../xslt/invokeMethodResult.xslt","InvokeMethodResult");												
				
			}

			function loadDefaultData()
			{							
				loadAndDynamicallyDisplayDynamicDataUsingDirectPath("this:");								
			}


	  	</script>
	</head>
	 <body font="Arial"  style="background-color:#666666;" onLoad="loadDefaultData()">         
            <table width="950" align="center" style="border:4 ;border-color: #000000; border-style: solid;" cellspacing="2" bgcolor="White">
               <tr>
                  <td>
                  	<IMG SRC="../images/owasp_logo.png"/>
                  </td>
                  <td width="850">
                     <p>
						<font class="title">
							<xsl:apply-templates select="page_title"/><font color="red"><xsl:apply-templates select="version"/></font>
						</font>
					 </p>
	             </td>
               </tr>
            </table> 
            
	        <table width="950" align="center" style="border:4 ;border-color: #000000; border-style: solid;" cellspacing="2" bgcolor="White">
				<tr>
					<td colspan="3" width="100%"> <h3> <div id="ProcessedPath"/></h3>
					<div id="CurrentPath" style="visibility:hidden"/>					
					</td>
				</tr>
				<tr>
					 <td align="center" valign="top" bgcolor="#00000" class="td_LHS_Menu"><b>Properties</b></td>
					 <td align="center" valign="top" bgcolor="#00000" class="td_LHS_Menu"><b>Methods</b></td>
					 <td align="center" valign="top" bgcolor="#00000" class="td_LHS_Menu"> <b>Fields</b>	</td>
				</tr>
               <tr>
                  <td align="center" valign="top" >
                  	<div id="divWithDynamicListOfProperties"/>           	
                  </td>
                  <td  align="center" valign="top">				
                  		<div id="divWithDynamicListOfMethods"/>  
                  </td>                  
                  <td  align="center" valign="top" width="400">                     
                  	<div id="divWithDynamicListOfFields"/>       
                  </td>
               </tr>
               <tr>
					<td colspan="3">
					<hr></hr>
					    <table border="0" width="100%" cellspacing="0"> 
                     	<tr>
                     		<td valign="top">
                     			<b> Properties' Values (Debug Information)</b>
                     			<br/>
                     			<br/>
                     			<div id="divWithDynamicListOfPropertiesWithValues"/> 
                     		</td>
                     	</tr>
                     </table>
	             </td>
               </tr>
            </table>  
	  
	  	</body>
	</html>
	
  	</xsl:template>
  	
</xsl:stylesheet>

  <!--

 Copyright (c) 2004 Free Software Foundation
 developed under the custody of the
 Open Web Application Security Project
 (http://www.owasp.org)
 
 This file is part of the OWASP ANBS (Asp.Net Baseline Security) and the OWASP Asp.Net Reflector.

 This Tool is free software; you can redistribute it and/or modify it 
 under the terms of the GNU Lesser General Public License as published by
 the Free Software Foundation; either version 2 of the License, or
 (at your option) any later version.
  
 This Tool is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 See the GNU Lesser General Public License for more details.
 
 The valid license text for this file can be retrieved from the gnu website
 (http://www.gnu.org/copyleft/lesser.html)
 
 If you are not able to view the LICENSE that way, which should
 always be possible within a valid and working Portal release,
 please write to the Free Software Foundation, Inc.,
 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 to get a copy of the GNU General Public License or to report a
 possible license violation.
 
 Author: Dinis Cruz 
			  dinis@ddplus.net
  -->
