<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:n1="vuln_report">
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml"/>
	<xsl:template match="/">
		<Dashboard>
			<Discovered>
				<NoCritical>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport = 'true'])"/>
				</NoCritical>
				<NoHigh>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport = 'true'])"/>
				</NoHigh>
				<NoMedium>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport = 'true'])"/>
				</NoMedium>
				<NoLow>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport = 'true'])"/>
				</NoLow>
				<NoInfo>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Info'][@IncludeInReport = 'true'])"/>
				</NoInfo>
				<NoTotal>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport = 'true'])"/>
				</NoTotal>
			</Discovered>
			<UnResolved>
				<NoCritical>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport = 'true']/n1:Resolution[@Status='Reported'])"/>
				</NoCritical>
				<NoHigh>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport = 'true']/n1:Resolution[@Status='Reported'])"/>
				</NoHigh>
				<NoMedium>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport = 'true']/n1:Resolution[@Status='Reported'])"/>
				</NoMedium>
				<NoLow>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport = 'true']/n1:Resolution[@Status='Reported'])"/>
				</NoLow>
				<NoInfo>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Info'][@IncludeInReport = 'true']/n1:Resolution[@Status='Reported'])"/>
				</NoInfo>
				<NoTotal>
					<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport = 'true']/n1:Resolution[@Status='Reported'])"/>
				</NoTotal>
			</UnResolved>
			<NoIPs>
				<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:IP)"/>
			</NoIPs>
			<NoDNS>
				<xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:DnsName)"/>
			</NoDNS>
		</Dashboard>
	</xsl:template>
</xsl:stylesheet>
