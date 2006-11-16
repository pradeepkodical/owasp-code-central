<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:n1="vuln_report">
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml" />
	<xsl:template name="reportSummary">
		<xsl:param name="filteredList"/>	
		<AllProjects_Reported>
			<CriticalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
			<HighCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
			<MediumCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
			<LowCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
			<TotalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
		</AllProjects_Reported>
		<AllProjects>
			<CriticalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
			<HighCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
			<MediumCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
			<LowCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
			<TotalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
		</AllProjects>
	</xsl:template>
	
	<xsl:template name="projectSummary">
		<xsl:param name="filteredList"/>
		<xsl:element name="Project">
			<xsl:attribute name="name"><xsl:value-of select="$filteredList/n1:Metadata/n1:project_name"/></xsl:attribute>
			<xsl:attribute name="dateCompleted"><xsl:value-of select="$filteredList/n1:Metadata/n1:dates/n1:actual_end_date"/></xsl:attribute>
			<OriginalStats>
				<CriticalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true'])" /></CriticalCount>
				<HighCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true'])" /></HighCount>
				<MediumCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true'])" /></MediumCount>
				<LowCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true'])" /></LowCount>
				<TotalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true'])" /></TotalCount>
			</OriginalStats>
			<CurrentStats>
				<CriticalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
				<HighCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
				<MediumCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
				<LowCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
				<TotalCount><xsl:value-of select="count($filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
			</CurrentStats>
			<ResolvedIssues>
				<xsl:for-each select="$filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status='Closed']">
				<xsl:sort select="translate(../@Impact, 'MI', 'IZ')"/>
				<xsl:sort select="translate(../@Probability, 'MI', 'IZ')"/>
					<xsl:element name="Finding">
						<xsl:attribute name="Vulnerability"><xsl:value-of select="../@Vulnerability" /></xsl:attribute>
						<xsl:attribute name="Issue-id"><xsl:value-of select="../@Issue-id" /></xsl:attribute>
						<xsl:attribute name="Impact"><xsl:value-of select="../@Impact" /></xsl:attribute>
						<xsl:attribute name="Probability"><xsl:value-of select="../@Probability" /></xsl:attribute>
						<xsl:element name="Resolution">
							<xsl:attribute name="DateOpened"><xsl:value-of select="@OpenDate" /></xsl:attribute>
							<xsl:attribute name="Status"><xsl:value-of select="@Status" /></xsl:attribute>
						</xsl:element>
					</xsl:element>
				</xsl:for-each>
			</ResolvedIssues>
			<OpenIssues___>
				<xsl:for-each select="$filteredList/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed']">
				<xsl:sort select="translate(../@Impact, 'MI', 'IZ')"/>
				<xsl:sort select="translate(../@Probability, 'MI', 'IZ')"/>
					<xsl:element name="Finding_____">
						<xsl:attribute name="Vulnerability"><xsl:value-of select="../@Vulnerability" /></xsl:attribute>
						<xsl:attribute name="Issue-id"><xsl:value-of select="../@Issue-id" /></xsl:attribute>
						<xsl:attribute name="Impact"><xsl:value-of select="../@Impact" /></xsl:attribute>
						<xsl:attribute name="Probability"><xsl:value-of select="../@Probability" /></xsl:attribute>
						<xsl:element name="Resolution_">
							<xsl:attribute name="DateOpened"><xsl:value-of select="@OpenDate" /></xsl:attribute>
							<xsl:attribute name="Status"><xsl:value-of select="@Status" /></xsl:attribute>
						</xsl:element>
						<xsl:element name="ID_DnsName_">
								<xsl:attribute name="IP"><xsl:value-of select="n1:IP" /></xsl:attribute>
								<xsl:attribute name="DnsName"><xsl:value-of select="n1:DnsName" /></xsl:attribute>	
								<xsl:attribute name="IP"><xsl:value-of select="IP" /></xsl:attribute>
								<xsl:attribute name="DnsName"><xsl:value-of select="DnsName" /></xsl:attribute>	
						</xsl:element>
						<xsl:element name="AuditTrailItem"><xsl:value-of select="n1:AuditTrailItem/n1:MoreDetails" /></xsl:element>
					</xsl:element>
				</xsl:for-each>
			</OpenIssues>
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>
