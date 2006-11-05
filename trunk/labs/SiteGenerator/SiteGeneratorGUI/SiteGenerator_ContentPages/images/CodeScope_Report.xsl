<?xml version="1.0" encoding="UTF-8"?> 
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    
<xsl:template match="Report">

<html>
<head>
	<title>Code Scope Report</title>
	<link rel="stylesheet" type="text/css" href="images/style.css"/>
	
</head>
<body>
<br/>
<table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="100%">
   <tr>
     <td>
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	
		<tr>
			<td colspan="3" valign="top" background="images/topBanner_slice.gif" height="8">				
			</td>
		</tr>
		<tr>
			<td valign="top" width="50" background="images/leftBanner.png">
			</td>
			<td valign="top">
				<table border="0" width="100%">
					<tr>			
						<td valign="middle" align="center" width="80%">
							<b><font size="5">Foundstone CodeScope Report</font></b>
						</td>
					</tr>
					<tr valign="top">
						<td colspan="2">
							<div id="xsltProcessedReport">
							
							





	<br/>

	<table align="center" width="70%" border="1" style="border-collapse: collapse" bordercolor="DarkBlue">
	  <tr>
	     <td>
		<table width="90%" align="center">
      		   <tr>		     
			<td width="70"> <b>Date:</b>
			</td>
			<td> <script> 
					dCurrentDate = new Date();
					document.write('' + (dCurrentDate .getMonth() + 1) +"/"+dCurrentDate .getDate()+ "/"+dCurrentDate .getYear())
				</script>
			</td>
			<td width="80"> <b>Time:</b>
			</td>
			<td> <script> 
					dCurrentDate = new Date();
					document.write('' + (dCurrentDate .getHours() + 1) +"h "+dCurrentDate .getMinutes()+ "m "+dCurrentDate .getSeconds() + "s")
				</script>
			</td>
		   </tr>     
      		<tr>	
			<td colspan="4"><b>Number of Files: <xsl:value-of select="count(/Report/CodeScopeReport/Files/ArrayOfTargetFileInfo/TargetFileInfo)" /> </b>
			</td>
			</tr>
			<tr>	
			<td colspan="4"><b>Number of Files Processed: <xsl:value-of select="count(/Report/CodeScopeReport/Files/ArrayOfTargetFileInfo/TargetFileInfo[bTargetFileProcessed='true'])"/>"  </b>(<xsl:value-of select="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0'])"/> results)
			</td>
		   </tr>
      		   <tr>	
			<td colspan="4">
				<ul>		
					<xsl:if test="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Critical'])>0">							
						<li><font color="red"><b>Critical: <xsl:value-of select="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Critical'])" /></b></font></li>
					</xsl:if>
					<xsl:if test="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='High'])>0">							
						<li><font color="red"><b>High: <xsl:value-of select="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='High'])" /></b></font></li>
					</xsl:if>
					<xsl:if test="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Medium'])>0">													
						<li><font color="orange"><b>Medium: <xsl:value-of select="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Medium'])" /></b></font></li>
					</xsl:if>
					<xsl:if test="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Low'])>0">							
						<li><font color="green"><b>Low: <xsl:value-of select="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Low'])" /></b></font></li>
					</xsl:if>
					<xsl:if test="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Info'])>0">													
						<li><font color="black"><b>Info: <xsl:value-of select="count(/Report/CodeScopeReport/Results/Results/_alResults/anyType[intValue!='0' and rrRating='Info'])" /></b></font></li>				
					</xsl:if>							
				</ul>
				
			</td>
		   </tr>

   		</table>
 	    </td>
	  </tr>
	</table>
	<br/>
	<br/>	
	<table align="center" width="90%" border="1" style="border-collapse: collapse" bordercolor="DarkBlue">
	  <tr><td><b>Results</b></td></tr>
	  <tr>
	     <td>	
	 		<table width="100%" align="center">      		   
	 		  <tr bgcolor="black">
	 			<td width="10%"><font color="white"><b>Rating</b></font></td>	 			
	 			<td width="40%"><font color="white"><b>Description</b></font></td>
	 			<td width="10%"><font color="white"><b>Value</b></font></td>	 			
	 			<td width="40%"><font color="white"><b>Comment</b></font></td>
	 		  </tr>	 		
	 		  <xsl:for-each select="/Report/CodeScopeReport/Results/Results/_alResults/anyType[rrRating='Critical']">						 							
	 			<xsl:if test="intValue!='0'">	 		  
	 				<tr>
	 					<td><font color="Red"><b><xsl:value-of select="rrRating" /></b></font></td>		 			
	 					<td><xsl:value-of select="strDescription" /></td>
	 					<td><xsl:value-of select="intValue" /></td>			 			
	 					<td><xsl:value-of select="strComment" /></td>
	 				</tr>	 
	 			  </xsl:if>				
			  </xsl:for-each>		
	 		  <xsl:for-each select="/Report/CodeScopeReport/Results/Results/_alResults/anyType[rrRating='High']">						 							
	 			<xsl:if test="intValue!='0'">	 		  
	 				<tr>
	 					<td><font color="Red"><b><xsl:value-of select="rrRating" /></b></font></td>		 			
	 					<td><xsl:value-of select="strDescription" /></td>
	 					<td><xsl:value-of select="intValue" /></td>			 			
	 					<td><xsl:value-of select="strComment" /></td>
	 				</tr>	 
	 			  </xsl:if>				
			  </xsl:for-each>		
			  <xsl:for-each select="/Report/CodeScopeReport/Results/Results/_alResults/anyType[rrRating='Medium']">						 							
	 			<xsl:if test="intValue!='0'">	 		  
	 				<tr>
	 					<td><font color="Orange"><b><xsl:value-of select="rrRating" /></b></font></td>		 			
	 					<td><xsl:value-of select="strDescription" /></td>
	 					<td><xsl:value-of select="intValue" /></td>			 			
	 					<td><xsl:value-of select="strComment" /></td>
	 				</tr>	 
	 			  </xsl:if>				
			  </xsl:for-each>	
	 		  <xsl:for-each select="/Report/CodeScopeReport/Results/Results/_alResults/anyType[rrRating='Low']">						 							
	 			<xsl:if test="intValue!='0'">	 		  
	 				<tr>
	 					<td><font color="Green"><b><xsl:value-of select="rrRating" /></b></font></td>		 			
	 					<td><xsl:value-of select="strDescription" /></td>
	 					<td><xsl:value-of select="intValue" /></td>
			 			
	 					<td><xsl:value-of select="strComment" /></td>
	 				</tr>	 
	 			  </xsl:if>				
			  </xsl:for-each>	
	 		  <xsl:for-each select="/Report/CodeScopeReport/Results/Results/_alResults/anyType[rrRating='Info']">						 							
	 			<xsl:if test="intValue!='0'">	 		  
	 				<tr>
	 					<td><font color="Black"><b><xsl:value-of select="rrRating" /></b></font></td>		 			
	 					<td><xsl:value-of select="strDescription" /></td>
	 					<td><xsl:value-of select="intValue" /></td>
			 			
	 					<td><xsl:value-of select="strComment" /></td>
	 				</tr>	 
	 			  </xsl:if>				
			  </xsl:for-each>				  			  		    				
			</table>	
 	    </td>
	  </tr>
	</table>	
	
	<br/>
	<table align="center" width="90%" border="1" style="border-collapse: collapse" bordercolor="DarkBlue">
	  <tr><td><b>Files Analyzed</b></td></tr>
	  <tr>
	     <td>	
	 		<table width="100%" align="center">      		   
	 		  <tr bgcolor="black">
	 			<td width="10%"><font color="white"><b>Name</b></font></td>	 			
	 			<td width="40%"><font color="white"><b>FullName</b></font></td>
	 			<td width="10%"><font color="white"><b>Size</b></font></td>	 			
	 			<td width="40%"><font color="white"><b>Processed?</b></font></td>
	 		  </tr>	 		
	 		  <xsl:for-each select="/Report/CodeScopeReport/Files/ArrayOfTargetFileInfo/TargetFileInfo">						 								 					  	 				
	 			<tr>
					<td><xsl:value-of select="strName" /></td>		 			
					<td><xsl:value-of select="strFullName" /></td>
					<td><xsl:value-of select="iFileSize" /></td>	
					<xsl:if test="bTargetFileProcessed='true'">			 			
						<td align="center"><xsl:value-of select="bTargetFileProcessed" /></td>
					</xsl:if>
					<xsl:if test="bTargetFileProcessed='false'">
						<td align="center"><font color="red"><xsl:value-of select="bTargetFileProcessed" /></font></td>
					</xsl:if>
				</tr>	 	 		
			  </xsl:for-each>		
		</table>	
 	    </td>
	  </tr>
	</table>							
							</div>	
						</td>	
					</tr>
				</table>
			</td>
			<td valign="top" width="50" background="images/leftBanner.png">
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