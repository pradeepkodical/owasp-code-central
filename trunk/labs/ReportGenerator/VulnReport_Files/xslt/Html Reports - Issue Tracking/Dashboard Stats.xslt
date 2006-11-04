<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:n1="vuln_report" xmlns:fn="http://www.w3.org/2005/xpath-functions" >
    <xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes" media-type="text/html" />
    <xsl:template match="/">  
        <html>
            <head>
					<link rel="stylesheet" type="text/css" href="U:\_AuthenticAndFopFiles\styles.css" />
            </head>
            <body>
				<h1>TSA Function Dashboard</h1>
				<h2>Issues Identified / Hosts Tested</h2>
				<table width="100%">
					<tr>
						<th>TSA</th>
						<th>Total</th>
					</tr>
					<tr>
						<td>Critical</td>
						<td><xsl:value-of select="/Dashboard/Discovered/NoCritical"/></td>
					</tr>
					<tr>
						<td>High</td>
						<td><xsl:value-of select="/Dashboard/Discovered/NoHigh"/></td>
					</tr>
					<tr>
						<td>Medium</td>
						<td><xsl:value-of select="/Dashboard/Discovered/NoMedium"/></td>
					</tr>
					<tr>
						<td>Low</td>
						<td><xsl:value-of select="/Dashboard/Discovered/NoLow"/></td>
					</tr>
					<tr>
						<td>Info Only</td>
						<td><xsl:value-of select="/Dashboard/Discovered/NoInfo"/></td>
					</tr>
					<tr>
						<td><b>Total</b></td>
						<td><b><xsl:value-of select="/Dashboard/Discovered/NoTotal"/></b></td>
					</tr>
					<tr>
						<td>Hosts (by IP)</td>
						<td><xsl:value-of select="/Dashboard/NoIPs"/></td>
					</tr>
					<tr>
						<td>Hosts (by DNS Name) </td>
						<td><xsl:value-of select="/Dashboard/NoDNS"/></td>
					</tr>
				</table>
				<h2>Issues Still Unresolved</h2>
				<table width="100%">
					<tr>
						<th>TSA</th>
						<th>Total</th>
					</tr>
					<tr>
						<td>Critical</td>
						<td><xsl:value-of select="/Dashboard/UnResolved/NoCritical"/></td>
					</tr>
					<tr>
						<td>High</td>
						<td><xsl:value-of select="/Dashboard/UnResolved/NoHigh"/></td>
					</tr>
					<tr>
						<td>Medium</td>
						<td><xsl:value-of select="/Dashboard/UnResolved/NoMedium"/></td>
					</tr>
					<tr>
						<td>Low</td>
						<td><xsl:value-of select="/Dashboard/UnResolved/NoLow"/></td>
					</tr>
					<tr>
						<td>Info Only</td>
						<td><xsl:value-of select="/Dashboard/UnResolved/NoInfo"/></td>
					</tr>
					<tr>
						<td><b>Total</b></td>
						<td><b><xsl:value-of select="/Dashboard/UnResolved/NoTotal"/></b></td>
					</tr>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
