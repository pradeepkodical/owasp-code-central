<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:n1="vuln_report">
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml" />
	<xsl:include href="..\lib\SharedRISOReportGuts.xslt"/>
	<xsl:template match="/">
		<!--<xsl:variable name="query" select="/n1:ConsolidatedProjects/n1:Project[n1:Metadata/n1:project_name = 'GVA Infrastructure'] | 
											/n1:ConsolidatedProjects/n1:Project[n1:Metadata/n1:project_name = 'IPoP - New York'] | 
											/n1:ConsolidatedProjects/n1:Project[n1:Metadata/n1:project_name = 'GVA VIP'] | 
											/n1:ConsolidatedProjects/n1:Project[n1:Metadata/n1:project_name = 'IPoP - Chicago'] |
											/n1:ConsolidatedProjects/n1:Project[n1:Metadata/n1:project_name = 'CISO eRoom Environment TSA']" />-->
		<xsl:variable name="query" select="/n1:ConsolidatedProjects/n1:Project[n1:Metadata/n1:Region = 'NA'][n1:Metadata/n1:TestType != 'ISA']"/>
		<MonthlyStats>
			<ReportTitle>TSA Remediation</ReportTitle>
			<ReportSubTitle>RISO Report</ReportSubTitle>
			<ReportRegion>North America</ReportRegion>
			<ReportMonth>2006-05</ReportMonth>
			<ReportDate>8 June 2006</ReportDate>
			<ReportAuthor>TSA</ReportAuthor>
			<ReportReviewer>Robert B Mann</ReportReviewer>
         	<ReportVersion>1.0</ReportVersion>
			<xsl:call-template name="reportSummary">
				<xsl:with-param name="filteredList" select="$query" />
			</xsl:call-template>
			
			<xsl:for-each select="$query">
				<xsl:sort select="n1:Metadata/n1:project_number"/>
				<xsl:call-template name="projectSummary">
					<xsl:with-param name="filteredList" select="." />
				</xsl:call-template>
			</xsl:for-each>
			
		</MonthlyStats>
	</xsl:template>
</xsl:stylesheet>
