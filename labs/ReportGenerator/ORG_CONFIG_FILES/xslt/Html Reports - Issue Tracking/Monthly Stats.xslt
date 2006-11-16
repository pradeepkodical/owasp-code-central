<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:n1="vuln_report" xmlns:fn="http://www.w3.org/2005/xpath-functions" >
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes" media-type="text/html" />
	<xsl:template match="/">
		<html>
			<head>
				<title>Monthly Security Assessment Report</title>
				<link rel="stylesheet" type="text/css" href="U:\_AuthenticAndFopFiles\styles.css" />
			</head>
			<body>
				<h1>Monthly Security Assessment Report</h1>
				<h2>Summary of Outstanding Issues (all locations)</h2>
				<table border="1">					
					<tr>
						<th>Security Assessment Results, </th>
						<th>Risks Identified</th>
						<th>Open Risks</th>
					</tr>
					<tr>
						<th>Critical Impact Issues</th>
						<td><xsl:value-of select="MonthlyStats/AllProjects_Reported/CriticalCount"/></td>
						<td><xsl:value-of select="MonthlyStats/AllProjects/CriticalCount"/></td>
					</tr>
					<tr>
						<th>High Impact Issues</th>
						<td><xsl:value-of select="MonthlyStats/AllProjects_Reported/HighCount"/></td>
						<td><xsl:value-of select="MonthlyStats/AllProjects/HighCount"/></td>
					</tr>
					<tr>
						<th>Medium Impact Issues</th>
						<td><xsl:value-of select="MonthlyStats/AllProjects_Reported/MediumCount"/></td>
						<td><xsl:value-of select="MonthlyStats/AllProjects/MediumCount"/></td>
					</tr>
					<tr>
						<th>Low Impact Issues</th>
						<td><xsl:value-of select="MonthlyStats/AllProjects_Reported/LowCount"/></td>
						<td><xsl:value-of select="MonthlyStats/AllProjects/LowCount"/></td>
					</tr>
				</table>
				<h2>Location Summary</h2>
				<xsl:for-each select="MonthlyStats/Project">
					<h3><xsl:value-of select="@name"/></h3>
					<h4>Summary of Issues</h4>
					<table border="1">
						<tr>
							<th colspan="4">Original Issue Count</th>
							<th colspan="4">Current Issue Count</th>
						</tr>
						<tr>
							<th>Critical</th>
							<th>High</th>
							<th>Medium</th>
							<th>Low</th>
							<th>Critical</th>
							<th>High</th>
							<th>Medium</th>
							<th>Low</th>
						</tr>
						<tr>
							<td><xsl:value-of select="OriginalStats/CriticalCount"/></td>
							<td><xsl:value-of select="OriginalStats/HighCount"/></td>
							<td><xsl:value-of select="OriginalStats/MediumCount"/></td>
							<td><xsl:value-of select="OriginalStats/LowCount"/></td>
							<td><xsl:value-of select="CurrentStats/CriticalCount"/></td>
							<td><xsl:value-of select="CurrentStats/HighCount"/></td>
							<td><xsl:value-of select="CurrentStats/MediumCount"/></td>
							<td><xsl:value-of select="CurrentStats/LowCount"/></td>
						</tr>
					</table>
					<h4>Details of Outstanding Issues</h4>
					<table>
						<tr>
							<th>Issue-ID</th>
							<th>Date Reported</th>
							<th>Impact</th>
							<th>Probability</th>
							<th>Name</th>
							<th>Additional Details</th>
						</tr>
						<xsl:for-each select="OpenIssues/Finding">
							<tr>
								<td><xsl:value-of select="@Issue-id"/></td>
								<td><xsl:value-of select="Resolution/@DateOpened"/></td>
								<td><xsl:value-of select="@Impact"/></td>
								<td><xsl:value-of select="@Probability"/></td>
								<td><xsl:value-of select="@Vulnerability"/></td>
								<td><xsl:value-of select="AuditTrailItem"/></td>
							</tr>
						</xsl:for-each>
					</table>
					<hr/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
