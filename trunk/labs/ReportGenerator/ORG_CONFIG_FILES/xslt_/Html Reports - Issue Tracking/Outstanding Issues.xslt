<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:n1="vuln_report" xmlns:fn="http://www.w3.org/2005/xpath-functions" >
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes" media-type="text/html" />
	<xsl:template match="/">
		<html>
			<head>
				<title>Outstanding TSA Issues</title>
				<link rel="stylesheet" type="text/css" href="U:\_AuthenticAndFopFiles\styles.css" />
			</head>
			<body>
				<h1>Outstanding TSA Issues</h1>
				<h2>Summary</h2>
				<table>
					<tr>
						<th>Critical Impact Issues</th>
						<td><xsl:value-of select="Outstanding/CriticalCount"/></td>
					</tr>
					<tr>
						<th>High Impact Issues</th>
						<td><xsl:value-of select="Outstanding/HighCount"/></td>
					</tr>
					<tr>
						<th>Medium Impact Issues</th>
						<td><xsl:value-of select="Outstanding/MediumCount"/></td>
					</tr>
					<tr>
						<th>Low Impact Issues</th>
						<td><xsl:value-of select="Outstanding/LowCount"/></td>
					</tr>
				</table>
				<h2>Details</h2>
				<table>
					<tr>
						<th>TSA-ID</th>
						<th>Date Reported</th>
						<th>Status</th>
						<th>Name</th>
						<th>Impact</th>
						<th>Probability</th>
					</tr>
					<xsl:for-each select="/Outstanding/Findings/Finding">
					<tr>
						<td><xsl:value-of select="@Tsa-id"/></td>
						<td><xsl:value-of select="Resolution/@DateOpened"/></td>
						<td><xsl:value-of select="Resolution/@Status"/></td>
						<td><xsl:value-of select="@Vulnerability"/></td>
						<td><xsl:value-of select="@Impact"/></td>
						<td><xsl:value-of select="@Probability"/></td>
					</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
