<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
    <xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml" />
    <xsl:template match="/">         
        <PKIandSLA xmlns:n1="vuln_report">
         			
			<xsl:variable name="CriticalAndHighIssues" select="/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'] | /n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High']"/>
			<xsl:variable name="CriticalAndHighIssues_Closed" select="$CriticalAndHighIssues[n1:Resolution/@Status='Closed']"/>	
			<xsl:variable name="CriticalAndHighIssues_ReportedAndTempManaged" select="$CriticalAndHighIssues[n1:Resolution/@Status='Reported'] | $CriticalAndHighIssues[n1:Resolution/@Status='Temp. Managed']"/>	
			<xsl:variable name="CriticalAndHighIssues_TempManaged" select="$CriticalAndHighIssues[n1:Resolution/@Status='Temp. Managed']"/>					
			<xsl:variable name="ReTestSla" select="/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding/n1:Resolution//n1:ReTestSla[substring(@ReceivedDate, 1, 4) =  '2006']"/>
			<PKI>
				<ManagedOrResolved>
					<Percentage><xsl:value-of select="substring((count($CriticalAndHighIssues_Closed) div count($CriticalAndHighIssues)) * 100,0,5)"/></Percentage>
					<ItemsAffected><xsl:value-of select="count($CriticalAndHighIssues_Closed)"/></ItemsAffected>
					<ItemsTotal><xsl:value-of select="count($CriticalAndHighIssues)"/></ItemsTotal>									
				</ManagedOrResolved>
				<TemporarilyManaged>
					<xsl:if test="count($CriticalAndHighIssues_ReportedAndTempManaged) > 0">
						<Percentage><xsl:value-of select="substring((count($CriticalAndHighIssues_TempManaged) div count($CriticalAndHighIssues_ReportedAndTempManaged)) * 100,0,5)"/></Percentage>
					</xsl:if>
					<xsl:if test="count($CriticalAndHighIssues_ReportedAndTempManaged) = 0">
						<Percentage>0</Percentage>
					</xsl:if>
					<ItemsAffected><xsl:value-of select="count($CriticalAndHighIssues_TempManaged)"/></ItemsAffected>
					<ItemsTotal><xsl:value-of select="count($CriticalAndHighIssues_ReportedAndTempManaged)"/></ItemsTotal>									
				</TemporarilyManaged>
				<IssueRetest>
					<InSLA><xsl:value-of select="count($ReTestSla[@Days &lt;= 4])"/></InSLA>
					<OutSLA><xsl:value-of select="count($ReTestSla[@Days &gt; 4])"/></OutSLA>
					<ItemsTotal><xsl:value-of select="count($ReTestSla[@Days])"/></ItemsTotal>
				</IssueRetest>
				<TSARequest>
					<InSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenReqAndAck &lt;= 5])"/></InSLA>
					<OutSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenReqAndAck &gt; 5])"/></OutSLA>
					<ItemsTotal><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates/n1:daysBetweenReqAndAck)"/></ItemsTotal>
				</TSARequest>
				<TSAReport>
					<InSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenEndAndDelivery &lt;= 10])"/></InSLA>
					<OutSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenEndAndDelivery &gt; 10])"/></OutSLA>
					<ItemsTotal><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates/n1:daysBetweenEndAndDelivery)"/></ItemsTotal>
				</TSAReport>
				<NumberIpops><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006'][contains(n1:Metadata/n1:project_name, 'IPoP')])"/></NumberIpops>
			</PKI>
			<Projects>
				<xsl:for-each select="/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']">
					<xsl:sort select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" order="descending"/>
					<xsl:sort select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" order="descending"/>
					<xsl:sort select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" order="descending"/>
					<xsl:sort select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" order="descending"/>
					<Project>
						<Number><xsl:value-of select="n1:Metadata/n1:project_number"/></Number>
						<Name><xsl:value-of select="n1:Metadata/n1:project_name"/></Name>
						<ReportDate><xsl:value-of select="n1:Metadata/n1:dates/n1:report_delivery_date"/></ReportDate>
						<CriticalCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])"/></CriticalCount>
						<HighCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])"/></HighCount>
						<MediumCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])"/></MediumCount>
						<LowCount><xsl:value-of select="count(n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])"/></LowCount>
					</Project>
				</xsl:for-each>
			</Projects>
			<Junk><xsl:value-of select="$CriticalAndHighIssues"/>
			</Junk>
		</PKIandSLA>
	</xsl:template>
</xsl:stylesheet>
