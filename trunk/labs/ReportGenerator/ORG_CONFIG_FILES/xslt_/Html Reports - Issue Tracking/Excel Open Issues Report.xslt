<?xml version="1.0" encoding="UTF-8"?>
<?mso-application progid="Excel.Sheet"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:n1="vuln_report">
	<xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" method="xml"/>
	<xsl:template match="/">
		<?mso-application progid="Excel.Sheet"?>			
		<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" xmlns:html="http://www.w3.org/TR/REC-html40">
			<ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
				<WindowHeight>10485</WindowHeight>
				<WindowWidth>15915</WindowWidth>
				<WindowTopX>720</WindowTopX>
				<WindowTopY>270</WindowTopY>
				<ProtectStructure>False</ProtectStructure>
				<ProtectWindows>False</ProtectWindows>
			</ExcelWorkbook>
			<Styles>
				<Style ss:ID="Default" ss:Name="Normal">
					<Alignment ss:Vertical="Bottom"/>
					<Borders/>
					<Font/>
					<Interior/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s21">
					<Font x:Family="Swiss" ss:Bold="1"/>
				</Style>
				<Style ss:ID="s23">
					<Font x:Family="Swiss" ss:Size="18" ss:Bold="1"/>
				</Style>
			</Styles>
		 <Worksheet ss:Name="Sheet1">
		  <Table x:FullColumns="1" x:FullRows="1">
		   <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="58.5"/>
		   <Column ss:AutoFitWidth="0" ss:Width="55.5"/>
		   <Column ss:AutoFitWidth="0" ss:Width="57"/>
		   <Column ss:AutoFitWidth="0" ss:Width="109.5"/>
		   <Column ss:AutoFitWidth="0" ss:Width="84"/>
		   <Column ss:AutoFitWidth="0" ss:Width="117"/>
		   <Column ss:AutoFitWidth="0" ss:Width="154.5"/>
		   <Column ss:AutoFitWidth="0" ss:Width="236.25"/>
		   <Row ss:Height="23.25">
		    <Cell ss:StyleID="s23"><Data ss:Type="String">Open Issues for <xsl:value-of select ="MonthlyStats/Project/@name"/> - Draft Report</Data></Cell>
		   </Row>
		   <Row ss:Height="14">
		    <Cell ss:StyleID="s21"><Data ss:Type="String">Project completed on: <xsl:value-of select ="MonthlyStats/Project/@dateCompleted"/></Data></Cell>
		   </Row>
		   
		   <Row ss:Index="5" >
		    <Cell ss:StyleID="s21"><Data ss:Type="String">Original Stats</Data></Cell>
		   </Row>		   
		   <Row ss:Index="7" ss:StyleID="s21">
		    <Cell ss:Index="2"><Data ss:Type="String">Critical</Data></Cell>
		    <Cell><Data ss:Type="String">High</Data></Cell>
		    <Cell><Data ss:Type="String">Medium</Data></Cell>
		    <Cell><Data ss:Type="String">Low</Data></Cell>
		    <Cell><Data ss:Type="String">Total</Data></Cell>
		   </Row>
 		   <Row ss:Index="8" ss:StyleID="Default">
		    <Cell ss:Index="2"><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/OriginalStats/CriticalCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/OriginalStats/HighCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/OriginalStats/MediumCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/OriginalStats/LowCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/OriginalStats/TotalCount"/></Data></Cell>
		   </Row> 
		   <Row ss:Index="12" >
		    <Cell ss:StyleID="s21"><Data ss:Type="String">Current Stats</Data></Cell>
		   </Row>		   
		   <Row ss:Index="14" ss:StyleID="s21">
		    <Cell ss:Index="2"><Data ss:Type="String">Critical</Data></Cell>
		    <Cell><Data ss:Type="String">High</Data></Cell>
		    <Cell><Data ss:Type="String">Medium</Data></Cell>
		    <Cell><Data ss:Type="String">Low</Data></Cell>
		    <Cell><Data ss:Type="String">Total</Data></Cell>
		   </Row>
		   <Row ss:Index="15" ss:StyleID="Default">
		    <Cell ss:Index="2"><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/CurrentStats/CriticalCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/CurrentStats/HighCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/CurrentStats/MediumCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/CurrentStats/LowCount"/></Data></Cell>
		    <Cell><Data ss:Type="Number"><xsl:value-of select ="MonthlyStats/Project/CurrentStats/TotalCount"/></Data></Cell>
		   </Row> 
		   
		   <Row ss:Index="20" >
		    <Cell ss:StyleID="s21"><Data ss:Type="String">Details of Open TSA-IDs</Data></Cell>
		   </Row>		   
		   <Row ss:Index="22" ss:StyleID="s21">
		    <Cell ss:Index="2"><Data ss:Type="String">Tsa-id</Data></Cell>
		    <Cell><Data ss:Type="String">Impact</Data></Cell>
		    <Cell><Data ss:Type="String">Probability</Data></Cell>
		    <Cell><Data ss:Type="String">Vulnerability</Data></Cell>
		    <Cell><Data ss:Type="String">IP</Data></Cell>
		    <Cell><Data ss:Type="String">DnsName</Data></Cell>
		    <Cell><Data ss:Type="String">AdditionalDetails</Data></Cell>
		    <Cell><Data ss:Type="String">Comments</Data></Cell>
		   </Row>		   			   
		   <xsl:for-each select="MonthlyStats/Project/OpenIssues/Finding">
			   <Row>
			    <Cell ss:Index="2"><Data ss:Type="String"><xsl:value-of select="Tsa-id"/></Data></Cell>
			    <Cell><Data ss:Type="String"><xsl:value-of select="Impact"/></Data></Cell>
			    <Cell><Data ss:Type="String"><xsl:value-of select="Probability"/></Data></Cell>
			    <Cell><Data ss:Type="String"><xsl:value-of select="Vulnerability"/></Data></Cell>
			    <Cell><Data ss:Type="String"><xsl:value-of select="IP"/></Data></Cell>
			    <Cell><Data ss:Type="String"><xsl:value-of select="DnsName"/></Data></Cell>
			    <Cell><Data ss:Type="String"><xsl:value-of select="AdditionalDetails"/></Data></Cell>
			    <Cell><Data ss:Type="String"><xsl:value-of select="Comments"/></Data></Cell>
			   </Row>
		   </xsl:for-each>	
		  </Table>
		  <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
		   <Print>
		    <ValidPrinterInfo/>
		    <PaperSizeIndex>9</PaperSizeIndex>
		    <HorizontalResolution>300</HorizontalResolution>
		    <VerticalResolution>300</VerticalResolution>
		   </Print>
		   <Selected/>
		   <Panes>
		    <Pane>
		     <Number>3</Number>
		     <ActiveRow>11</ActiveRow>
		     <ActiveCol>1</ActiveCol>
		    </Pane>
		   </Panes>
		   <ProtectObjects>False</ProtectObjects>
		   <ProtectScenarios>False</ProtectScenarios>
		  </WorksheetOptions>
		 </Worksheet>
		 <Worksheet ss:Name="Sheet2">
		  <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
		   <ProtectObjects>False</ProtectObjects>
		   <ProtectScenarios>False</ProtectScenarios>
		  </WorksheetOptions>
		 </Worksheet>
		 <Worksheet ss:Name="Sheet3">
		  <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
		   <ProtectObjects>False</ProtectObjects>
		   <ProtectScenarios>False</ProtectScenarios>
		  </WorksheetOptions>
		 </Worksheet>
		</Workbook>
</xsl:template>
</xsl:stylesheet>
