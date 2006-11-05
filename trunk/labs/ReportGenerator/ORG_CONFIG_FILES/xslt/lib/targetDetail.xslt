<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:n1="vuln_report" xmlns:fn="http://www.w3.org/2005/xpath-functions" >
    <xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes" media-type="text/html" />
    <xsl:template match="/">  
     
        <html>
            <head>
            </head>
            <body>				
				<xsl:for-each select="n1:Project/n1:Targets/n1:Target">                					
					<font face="Arial" size="-1">
					<table width="100%">
						<tr>
							<td width="80"><b>Name:</b></td>
							<td bgcolor="#F0F0F0"><xsl:value-of select="@name" /></td>
							<td width="80"><b>Type:</b></td>
							<td bgcolor="#F0F0F0"><xsl:value-of select="@type" /></td>
						</tr>
						<tr>
							<td><b>IP(s):</b></td>
							<td bgcolor="#F0F0F0">
								<xsl:for-each select="n1:IP">
									<xsl:value-of select="@value" />
								</xsl:for-each>					
							</td>
							<td><b>DNS(s):</b></td>
							<td bgcolor="#F0F0F0">
								<xsl:for-each select="n1:DnsName">
									<xsl:value-of select="@value" />
								</xsl:for-each>					
							</td>
						</tr>
					</table>	                                
					<font size="1pt">(note this data is not editable in this window)</font>
					</font>
                </xsl:for-each>       
                    
                
		</body>
	</html>
</xsl:template>

</xsl:stylesheet>