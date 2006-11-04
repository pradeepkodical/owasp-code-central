<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml" />
	
	<xsl:template match="/">		
		<Findings xmlns="vuln_report" xmlns:n1="vuln_report"  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="vuln_report GVADataFeedXsd_v0.5.xsd" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >			
		 <xsl:for-each select="//n1:Project/n1:Targets/n1:Target/n1:Findings/n1:Finding[@IncludeInReport='true']">			
			<Finding>
					<xsl:attribute name = "Layer"><xsl:value-of select="@Layer"/></xsl:attribute>
					<xsl:attribute name = "Category"><xsl:value-of select="@Category"/></xsl:attribute>					
					<xsl:attribute name = "Vulnerability"><xsl:value-of select="@Vulnerability"/></xsl:attribute>
					<xsl:attribute name = "Impact"><xsl:value-of select="@Impact"/></xsl:attribute>
					<xsl:attribute name = "Probability"><xsl:value-of select="@Probability"/></xsl:attribute>
					<xsl:attribute name = "Tsa-id"><xsl:value-of select="@Tsa-id"/></xsl:attribute>
					<xsl:attribute name = "Owner"><xsl:value-of select="@Owner"/></xsl:attribute>
					<Metadata>						
						<project_number><xsl:value-of select="../../../../n1:Metadata/n1:project_number"/></project_number>						
						<project_name><xsl:value-of select="../../../../n1:Metadata/n1:project_name"/></project_name>						
						<xsl:if test= "count(../../../../n1:Metadata/n1:contacts/n1:project_owner) > 0">						
							<contacts>
								<xsl:copy-of select="../../../../n1:Metadata/n1:contacts/n1:project_owner"/>
							</contacts>
						</xsl:if>
						<xsl:if test= "count(../../../../n1:Metadata/n1:dates) > 0">
							<dates>
								<start_date><xsl:value-of select="../../../../n1:Metadata/n1:dates/n1:start_date"/></start_date>
								<actual_end_date><xsl:value-of select="../../../../n1:Metadata/n1:dates/n1:actual_end_date"/></actual_end_date>
							</dates>
						</xsl:if>
						<Region><xsl:value-of select="../../../../n1:Metadata/n1:Region"/></Region>
						<SubRegion><xsl:value-of select="../../../../n1:Metadata/n1:SubRegion"/></SubRegion>
						<TestType><xsl:value-of select="../../../../n1:Metadata/n1:TestType"/></TestType>
					</Metadata>
					<xsl:copy-of select="n1:Comments"/>
					<xsl:copy-of select="n1:AffectedItems"/>					
					<xsl:copy-of select="n1:Recommendation"/>	
					<xsl:copy-of select="n1:Resolution"/>
					<Target>
						<xsl:attribute name = "name"><xsl:value-of select="../../@name"/></xsl:attribute>
						<xsl:attribute name = "type"><xsl:value-of select="../../@type"/></xsl:attribute>											
						<xsl:copy-of select="../../n1:IP"/>
						<xsl:copy-of select="../../n1:DnsName"/>
					</Target>
					<!--
					<Recommendation>
						<Comment><xsl:value-of select="n1:Recommendation/n1:Comment"/></Comment>					
						<xsl:for-each select="n1:Recommendation/n1:linkToRecommendationDatabase">
							<linkToRecommendationDatabase><xsl:value-of select="."/></linkToRecommendationDatabase>
					</xsl:for-each>						
					</Recommendation>					
-->
				</Finding>
		</xsl:for-each>
		</Findings>
	</xsl:template>
</xsl:stylesheet>
