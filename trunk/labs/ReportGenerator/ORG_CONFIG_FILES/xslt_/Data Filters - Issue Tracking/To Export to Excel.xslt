<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml" />
	<xsl:template match="/">
		<MonthlyStats xmlns:n1="vuln_report">
			<ReportTitle>Issue Remediation</ReportTitle>
			<ReportSubTitle>CIO Global Report</ReportSubTitle>
			<ReportMonth>2006-03</ReportMonth>
			<ReportDate>7 April 2006</ReportDate>
			<ReportAuthor>Security Assessment</ReportAuthor>
			<ReportReviewer>John Doe</ReportReviewer>
         	<ReportVersion>1.0</ReportVersion>
			<xsl:variable name="CriticalAndHighIssues" select="/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'] | /n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High']"/>
			<xsl:variable name="CriticalAndHighIssues_Closed" select="$CriticalAndHighIssues[n1:Resolution/@Status='Closed']"/>	
			<xsl:variable name="CriticalAndHighIssues_ReportedAndTempManaged" select="$CriticalAndHighIssues[n1:Resolution/@Status='Reported'] | $CriticalAndHighIssues[n1:Resolution/@Status='Temp. Managed']"/>	
			<xsl:variable name="CriticalAndHighIssues_TempManaged" select="$CriticalAndHighIssues[n1:Resolution/@Status='Temp. Managed']"/>					
			<xsl:variable name="ReTestSla" select="/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding/n1:Resolution//n1:ReTestSla[substring(@ReceivedDate, 1, 4) =  '2006']"/>
			<xsl:for-each select="//n1:Project">
				<xsl:sort select="n1:Metadata/n1:project_number"/>
				<xsl:element name="Project">
					<xsl:attribute name="name"><xsl:value-of select="n1:Metadata/n1:project_name"/></xsl:attribute>
					<xsl:attribute name="dateCompleted"><xsl:value-of select="n1:Metadata/n1:dates/n1:actual_end_date"/></xsl:attribute>
					<OriginalStats>
						<CriticalCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true'])" /></TotalCount>
					</OriginalStats>
					<CurrentStats>
						<CriticalCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
					</CurrentStats>
					<OpenIssues>
						<xsl:for-each select="n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed']">
						<!-- hack to make the word medium sort higher than the word low-->
							<xsl:sort select="translate(../@Impact, 'MI', 'IZ')"/>
							<xsl:sort select="translate(../@Probability, 'MI', 'IZ')"/>
							
							<xsl:call-template name="displayFinding"/>
												
						</xsl:for-each>
					</OpenIssues>
				</xsl:element>
			</xsl:for-each>
		</MonthlyStats>
	</xsl:template>
	
	<xsl:template name="displayFinding" xmlns:n1="vuln_report">
		
		<!-- hack to make the word medium sort higher than the word low-->				
		<xsl:element name="Finding">
			<xsl:element name="Vulnerability"><xsl:value-of select="../@Vulnerability" /></xsl:element>
			<xsl:element name="Issue-id"><xsl:value-of select="../@Issue-id" /></xsl:element>
			<xsl:element name="Impact"><xsl:value-of select="../@Impact" /></xsl:element>
			<xsl:element name="Probability"><xsl:value-of select="../@Probability" /></xsl:element>
			<xsl:element name="IP"><xsl:value-of select="../n1:IP" /></xsl:element>
			<xsl:element name="DnsName"><xsl:value-of select="../n1:DnsName" /></xsl:element>								
			<xsl:element name="AdditionalDetails"><xsl:value-of select="../n1:AdditionalDetails" /></xsl:element>
			<xsl:element name="Comments"><xsl:value-of select="../n1:Comments" /></xsl:element>						
<!--			
			<xsl:element name="Resolution">
				<xsl:attribute name="DateOpened"><xsl:value-of select="@OpenDate" /></xsl:attribute>
				<xsl:attribute name="Status"><xsl:value-of select="@Status" /></xsl:attribute>
			</xsl:element>
-->
		</xsl:element>			
	</xsl:template>	
</xsl:stylesheet>
