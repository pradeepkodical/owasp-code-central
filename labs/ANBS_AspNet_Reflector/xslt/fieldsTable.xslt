<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
				xmlns:data="http://tempuri.org/">

	
  
	<xsl:template match="data:reflectedData">	
	<xsl:apply-templates select="data:arrayReflectedData"/></xsl:template>
	
	<xsl:template match="data:arrayReflectedData">	
		  <table width="100%" style="border:1 ;border-color: #000000; border-style: solid;background-color:#FFFFFF" cellspacing="0" bgcolor="White">
		  	    <tr>
					<td bgcolor="#C0C0C0" class="td_LHS_Menu" width="200">Field Name</td>
					<td bgcolor="#C0C0C0" class="td_LHS_Menu">Field Value</td>
				</tr>
			<xsl:apply-templates select="data:anyType"/>
		</table>
					
	</xsl:template>

	<xsl:template match="data:anyType">
		<tr>						
				 <xsl:value-of select="." disable-output-escaping="yes"/>				 			
		</tr>				
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
 
 Author:	Dinis Cruz 
				dinis@ddplus.net
-->