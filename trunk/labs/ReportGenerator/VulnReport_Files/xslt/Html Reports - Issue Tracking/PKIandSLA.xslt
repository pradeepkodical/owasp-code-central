<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:n1="vuln_report" xmlns:fn="http://www.w3.org/2005/xpath-functions" >
    <xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="yes" media-type="text/html" />
    <xsl:template match="/">  
        <html>
            <head>
					<link rel="stylesheet" type="text/css" href="U:\_AuthenticAndFopFiles\styles.css" />
            </head>
            <body>
				<h1>TSA Function SLA's and KPI's</h1>
				<p>Report from 1st January 2006 to current</p>
				<h2>KPI</h2>
				<table width="100%">
					<tr>
						<th>KPI</th>
						<th>%</th>
					</tr>
					<tr>
						<td>Percentage of Critical and High issues managed or resolved</td>
						<td>
							<b>
								<xsl:value-of select="PKIandSLA/PKI/ManagedOrResolved/Percentage"/>%
							</b>							
							   (<xsl:value-of select="PKIandSLA/PKI/ManagedOrResolved/ItemsAffected"/> of <xsl:value-of select="PKIandSLA/PKI/ManagedOrResolved/ItemsTotal"/>)
						</td>
					</tr>									
					
					<tr>
						<td>Percentage of Open Critical and High issues temporarily managed</td>
						<td>
							<b>
								<xsl:value-of select="PKIandSLA/PKI/TemporarilyManaged/Percentage"/>%
							</b>							
							   (<xsl:value-of select="PKIandSLA/PKI/TemporarilyManaged/ItemsAffected"/> of <xsl:value-of select="PKIandSLA/PKI/ManagedOrResolved/ItemsTotal"/>)
						</td>						
					</tr>		
					<tr>
						<td>Number of IPoP tests completed</td>						
						<td><b><xsl:value-of select="PKIandSLA/PKI/IssueRetest/ItemsTotal" /></b></td>
					</tr>
					
				</table>
				<h2>SLAs</h2>
				
				<xsl:variable name="ReTestSla" select="n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding/n1:Resolution//n1:ReTestSla"/>		
				<table width="100%">
					<tr>
						<th>SLA Description</th>						
						<th>SLA Days</th>						
						<th>Total # Items</th>						
						<th>Items In SLA</th>						
						<th>Items Outside SLA</th>						
					</tr>	
					<tr>
						<td>Request for TSA</td>						
						<td>5</td>						
						<td><xsl:value-of select="PKIandSLA/PKI/TSARequest/ItemsTotal" /> (100%)</td>						
						
						<td class="InSLA"><xsl:value-of select="PKIandSLA/PKI/TSARequest/InSLA"/> (<xsl:value-of select="substring(PKIandSLA/PKI/TSARequest/InSLA div PKIandSLA/PKI/TSARequest/ItemsTotal * 100,0,5)"/>%)</td>
						<td class="OutsideSLA"><xsl:value-of select="PKIandSLA/PKI/TSARequest/OutSLA"/> (<xsl:value-of select="substring(PKIandSLA/PKI/TSARequest/OutSLA div PKIandSLA/PKI/TSARequest/ItemsTotal * 100,0,5)"/>%)</td>						
					</tr>	
					<tr>
						<td>Issue of TSA Report</td>						
						<td>10</td>						
						<td><xsl:value-of select="PKIandSLA/PKI/TSAReport/ItemsTotal" /> (100%)</td>						
						
						<td class="InSLA"><xsl:value-of select="PKIandSLA/PKI/TSAReport/InSLA"/> (<xsl:value-of select="substring(PKIandSLA/PKI/TSAReport/InSLA div PKIandSLA/PKI/TSAReport/ItemsTotal * 100,0,5)"/>%)</td>
						<td class="OutsideSLA"><xsl:value-of select="PKIandSLA/PKI/TSAReport/OutSLA"/> (<xsl:value-of select="substring(PKIandSLA/PKI/TSAReport/OutSLA div PKIandSLA/PKI/TSAReport/ItemsTotal * 100,0,5)"/>%)</td>						
					</tr>		
					<tr>
						<td>Retest of issues managed</td>						
						<td>4</td>						
						<td><xsl:value-of select="PKIandSLA/PKI/IssueRetest/ItemsTotal" /> (100%)</td>						
						
						<td class="InSLA"><xsl:value-of select="PKIandSLA/PKI/IssueRetest/InSLA"/> (<xsl:value-of select="substring(PKIandSLA/PKI/IssueRetest/InSLA div PKIandSLA/PKI/IssueRetest/ItemsTotal * 100,0,5)"/>%)</td>
						<td class="OutsideSLA"><xsl:value-of select="PKIandSLA/PKI/IssueRetest/OutSLA"/> (<xsl:value-of select="substring(PKIandSLA/PKI/IssueRetest/OutSLA div PKIandSLA/PKI/IssueRetest/ItemsTotal * 100,0,5)"/>%)</td>						
					</tr>
				</table>
				
				<h2>Project Statistics</h2>
				<p>A list of unresolved security issues by project follows</p>
				<table width="100%">
					<tr>
						<th colspan="3">Project</th>
						<th colspan="4">Impact</th>
					</tr>
					<tr>
						<th>No.</th>
						<th>Name</th>
						<th>Date Reported</th>
						<th>Critical</th>
						<th>High</th>
						<th>Medium</th>
						<th>Low</th>
					</tr>
					<xsl:for-each select="PKIandSLA/Projects/Project">
						<tr>
							<td><xsl:value-of select="Number"/></td>
							<td><xsl:value-of select="Name"/></td>
							<td><xsl:value-of select="ReportDate"/></td>
							<td><xsl:value-of select="CriticalCount"/></td>
							<td><xsl:value-of select="HighCount"/></td>
							<td><xsl:value-of select="MediumCount"/></td>
							<td><xsl:value-of select="LowCount"/></td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
