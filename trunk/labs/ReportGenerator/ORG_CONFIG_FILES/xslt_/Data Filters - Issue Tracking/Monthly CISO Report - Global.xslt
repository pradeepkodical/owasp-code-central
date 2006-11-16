<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml" />
	<xsl:template match="/">
		<MonthlyStats xmlns:n1="vuln_report">
			<ReportTitle>Issue Remediation</ReportTitle>
			<ReportSubTitle>CISO Global Report</ReportSubTitle>
			<ReportMonth>2006-05</ReportMonth>
			<ReportDate>8 June 2006</ReportDate>
			<ReportAuthor>Issue</ReportAuthor>
			<ReportReviewer>Robert B Mann</ReportReviewer>
         	<ReportVersion>1.0</ReportVersion>
			<xsl:variable name="CriticalAndHighIssues" select="/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'] | /n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High']"/>
			<xsl:variable name="CriticalAndHighIssues_Closed" select="$CriticalAndHighIssues[n1:Resolution/@Status='Closed']"/>	
			<xsl:variable name="CriticalAndHighIssues_ReportedAndTempManaged" select="$CriticalAndHighIssues[n1:Resolution/@Status='Reported'] | $CriticalAndHighIssues[n1:Resolution/@Status='Temp. Managed']"/>	
			<xsl:variable name="CriticalAndHighIssues_TempManaged" select="$CriticalAndHighIssues[n1:Resolution/@Status='Temp. Managed']"/>					
			<xsl:variable name="ReTestSla" select="/n1:ConsolidatedProjects/n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding/n1:Resolution//n1:ReTestSla[substring(@ReceivedDate, 1, 4) =  '2006']"/>
			<KPI>
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
				<Request>
					<InSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenReqAndAck &lt;= 5])"/></InSLA>
					<OutSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenReqAndAck &gt; 5])"/></OutSLA>
					<ItemsTotal><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates/n1:daysBetweenReqAndAck)"/></ItemsTotal>
				</Request>
				<Report>
					<InSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenEndAndDelivery &lt;= 10])"/></InSLA>
					<OutSLA><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates[n1:daysBetweenEndAndDelivery &gt; 10])"/></OutSLA>
					<ItemsTotal><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006']/n1:Metadata/n1:dates/n1:daysBetweenEndAndDelivery)"/></ItemsTotal>
				</Report>
				<NumberIpops><xsl:value-of select="count(/n1:ConsolidatedProjects/n1:Project[substring(n1:Metadata/n1:dates/n1:start_date, 1, 4) =  '2006'][contains(n1:Metadata/n1:project_name, 'IPoP')])"/></NumberIpops>
			</KPI>
			
			
			<AllProjects_Reported>
				<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
				<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
				<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
				<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
				<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
			</AllProjects_Reported>
			<AllProjects>
				<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
				<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
				<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
				<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
				<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:TestType != 'ISA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
			</AllProjects>
			<ProjectByRegion>
				<Region name="EU">
					<Reported>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
					</Reported>
					<Closed>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
					</Closed>
				</Region>
				<Region name="NL">
					<Reported>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
					</Reported>
					<Closed>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NL']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
					</Closed>
				</Region>
				<Region name="ASIA">
					<Reported>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
					</Reported>
					<Closed>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='ASIA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
					</Closed>
				</Region>
				<Region name="NA">
					<Reported>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
					</Reported>
					<Closed>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='NA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
					</Closed>
				</Region>
				<Region name="LA">
					<Reported>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
					</Reported>
					<Closed>
						<CriticalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='LA']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
					</Closed>
				</Region>
				<Region name="ALL">
					<Reported>
						<CriticalCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Not Reported'])" /></TotalCount>
					</Reported>
					<Closed>
						<CriticalCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Critical'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></CriticalCount>
						<HighCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='High'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></HighCount>
						<MediumCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Medium'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></MediumCount>
						<LowCount><xsl:value-of select="count(//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@Impact='Low'][@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></LowCount>
						<TotalCount><xsl:value-of select="count(//n1:Project[n1:Metadata/n1:Region='EU']/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']/n1:Resolution[@Status!='Closed'])" /></TotalCount>
					</Closed>
				</Region>
			</ProjectByRegion>
			<xsl:for-each select="//n1:Project">
				<xsl:sort select="n1:Metadata/n1:project_number"/>
				<xsl:element name="Project">
					<xsl:attribute name="name"><xsl:value-of select="n1:Metadata/n1:project_name"/></xsl:attribute>
					<xsl:attribute name="region"><xsl:value-of select="n1:Metadata/n1:Region"/></xsl:attribute>
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
					<ResolvedIssues>
						<xsl:for-each select="n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true'][@Impact = 'Critical' or @Impact = 'High']/n1:Resolution[@Status='Closed']">
						<!-- hack to make the word medium sort higher than the word low-->
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
					<OpenIssues>
						<xsl:for-each select="n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true'][@Impact = 'Critical' or @Impact = 'High']/n1:Resolution[@Status!='Closed']">
						<!-- hack to make the word medium sort higher than the word low-->
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
								<xsl:element name="AuditTrailItem"><xsl:value-of select="n1:AuditTrailItem/n1:MoreDetails" /></xsl:element>
							</xsl:element>
						</xsl:for-each>
					</OpenIssues>
				</xsl:element>
			</xsl:for-each>
		</MonthlyStats>
	</xsl:template>
</xsl:stylesheet>
