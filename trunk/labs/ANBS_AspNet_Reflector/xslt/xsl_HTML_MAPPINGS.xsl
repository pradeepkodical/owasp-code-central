<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

   <xsl:template match="br">
   		<br/>	    		    	
   </xsl:template>
   <xsl:template match="p">
   		<p>	
    		<xsl:apply-templates />
    	</p>
   </xsl:template>
	
   <xsl:template match="b">
   		<b>
   			<xsl:apply-templates />
   		</b>    	
   </xsl:template>
   
      
   <xsl:template match="i">
   		<i>
   			<xsl:apply-templates />
   		</i>    	
   </xsl:template>
   
   <xsl:template match="ul">
   		<ul>
   			<xsl:apply-templates />
   		</ul>    	
   </xsl:template>
   
   <xsl:template match="li">
   		<li>
   			<xsl:apply-templates />
   		</li>    	
   </xsl:template>
   
   <xsl:template match="a">
   		<a>
   		   <xsl:attribute  name = "href" >
   		   		<xsl:value-of select="@href" />
   		   </xsl:attribute>
   		    	<xsl:value-of select="." />
   		</a>
   </xsl:template>
   
   <xsl:template match="table">
   		<table  border="5" cellpadding="20"  cellspacing="0" style="aborder-collapse: collapse;border-color;#111111;">
   			<xsl:attribute  name = "width"><xsl:value-of select="@width" /></xsl:attribute>
   			<xsl:apply-templates />
   		</table>    	
   </xsl:template>
   
   <xsl:template match="tr">
   		<tr>
   			<xsl:apply-templates />
   		</tr>    	
   </xsl:template>
   
   <xsl:template match="td">
   		<td valign="top">
   		       <xsl:attribute  name = "bgcolor"><xsl:value-of select="@bgcolor" /></xsl:attribute>
   		       <xsl:attribute  name = "align"><xsl:value-of select="@align" /></xsl:attribute>
   			<xsl:apply-templates />
   		</td>    	
   </xsl:template>	
   
   <xsl:template match="font">
   		<font>
   		                 <xsl:attribute  name = "color"><xsl:value-of select="@color" /></xsl:attribute>
   			<xsl:apply-templates />
   		</font>    	
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

