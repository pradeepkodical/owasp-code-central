<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:xs="http://www.w3.org/2001/XMLSchema"
                xmlns:xdt="http://www.w3.org/2005/xpath-datatypes"
                xmlns:date="http://exslt.org/dates-and-times"
                xmlns:n1="vuln_report"
                xmlns:fo="http://www.w3.org/1999/XSL/Format"
                xmlns:fn="http://www.w3.org/2005/xpath-functions"
                extension-element-prefixes="date">
 
  <xsl:variable name="fo:layout-master-set">
  
    <!-- Master Document Layout -->

    <fo:layout-master-set>
      <fo:simple-page-master margin-left="0.6in" margin-right="0.6in"
                             master-name="First-page" page-height="11in"
                             page-width="8.5in">
        <fo:region-body margin-bottom="0.59in" margin-top="0.0in" />
      </fo:simple-page-master>

      <fo:simple-page-master margin-left="0.6in" margin-right="0.6in"
                             master-name="default-page" page-height="11in"
                             page-width="8.5in">
        <fo:region-body margin-bottom="0.59in" margin-left="0.40in"
                        margin-top="1.45in" />

        <fo:region-before extent="1.22in" />

        <fo:region-after extent="0.24in" />
      </fo:simple-page-master>

      <fo:simple-page-master margin-left="0.3in" margin-right="0.3in"
                             master-name="findings-page" page-height="8.5in"
                             page-width="11in">
        <fo:region-body margin-bottom="0.79in" margin-top="1.05in" />

        <fo:region-before extent="1.05in" />

        <fo:region-after extent="0.24in" />
      </fo:simple-page-master>
    </fo:layout-master-set>

    <!-- /Master Document Layout -->
  </xsl:variable>

  <xsl:output encoding="UTF-8" indent="no" media-type="text/html"
              omit-xml-declaration="no" version="1.0" />

  <xsl:template match="/">
    <fo:root>
      <xsl:copy-of select="$fo:layout-master-set" />

      <!-- Show Cover Page -->

      <fo:page-sequence format="1" initial-page-number="1"
                        master-reference="First-page">
        <fo:flow flow-name="xsl-region-body">
        	<fo:table table-layout="fixed" width="100%">
        		<fo:table-column/>
        			<fo:table-header>
            			<fo:table-row>            			
                			<fo:table-cell padding-bottom="-257mm">
                				<fo:instream-foreign-object>
                					<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width = "700px" height="500px">
                						<svg:text x="295" y="95" transform="rotate(45)" font-family="Times" font-size="42pt" fill="rgb(240,240,240)">CONFIDENTIAL</svg:text>
                					</svg:svg>
                				</fo:instream-foreign-object>
                   			</fo:table-cell>
            			</fo:table-row>
        			</fo:table-header>
        			<fo:table-body>
            			<fo:table-row>
                			<fo:table-cell><xsl:call-template name="DisplayFirstPage" /></fo:table-cell>
            			</fo:table-row>
        			</fo:table-body>
    		</fo:table>
        </fo:flow>
      </fo:page-sequence>

      <!-- Section One Start -->

      <fo:page-sequence format="1" master-reference="default-page">
        <!-- Header -->

        <fo:static-content display-align="after" flow-name="xsl-region-before">
          <fo:block font-family="Times">
            <fo:table border-style="solid" border-width="1pt"
                      space-before="20pt" table-layout="fixed" width="100%">
              <fo:table-column column-width="80pt" />

              <fo:table-column />

              <fo:table-column column-width="80pt" />

              <fo:table-column />

              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell background-color="#E0E0E0"
                                 border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block>Origin: </fo:block>
                  </fo:table-cell>

                  <fo:table-cell border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block><xsl:value-of select="MonthlyStats/ReportTitle"/>
                    </fo:block>
                  </fo:table-cell>

                  <fo:table-cell background-color="#E0E0E0"
                                 border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block>Title: </fo:block>
                  </fo:table-cell>

                  <fo:table-cell border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block>
                      <xsl:value-of select="MonthlyStats/ReportMonth"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
        </fo:static-content>

        <!-- /Header -->

        <!-- Footer -->

        <fo:static-content display-align="after" flow-name="xsl-region-after">
          <fo:block font-family="Times">
            <fo:table margin-left="-45pt" margin-right="0pt"
                      table-layout="fixed" width="100%">
              <fo:table-column />

              <fo:table-column />

              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell border-color="white" border-style="solid"
                                 border-width="0pt" display-align="center"
                                 padding="0pt" text-align="start">
                    <fo:block color="black" font-family="Times"
                    font-size="10pt" margin-left="0pt" space-before="-20pt"
                    text-align="left"><xsl:value-of select="MonthlyStats/OpenIssues/ReportTitle"/>
                    </fo:block>
                  </fo:table-cell>

                  <fo:table-cell border-color="white" border-style="solid"
                                 border-width="0pt" display-align="center"
                                 padding="0pt" text-align="start">
                    <fo:block color="black" font-family="Times"
                    font-size="10pt" space-before="-20pt" text-align="right">
                    Page <fo:page-number /> </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
        </fo:static-content>

        <!-- /Footer -->

        <fo:flow flow-name="xsl-region-body">       
        	<!--
        <fo:block>
			Test 123...
    	</fo:block>
    -->
        	<fo:table  table-layout="fixed"  width="100%">        	
        		<fo:table-column/>
        			<fo:table-header>
            			<fo:table-row>            			
                			<fo:table-cell padding-bottom="-257mm">
                				<fo:instream-foreign-object>
                					<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width = "700px" height="500px">
                						<svg:text x="225" y="45" transform="rotate(45)" font-family="Times" font-size="42pt" fill="rgb(240,240,240)">CONFIDENTIAL</svg:text>
                					</svg:svg>
                				</fo:instream-foreign-object>
                				
                   			</fo:table-cell>
            			</fo:table-row>
        			</fo:table-header>
        			<fo:table-body>
            			<fo:table-row>
                			<fo:table-cell>
						                			
						          <!-- Show Table of Contents -->
						
						          <xsl:call-template name="DisplayTableOfContents">

						          </xsl:call-template>
						
						          <!-- Show Document Information Page -->
						
						          <xsl:call-template name="DisplayDocumentInformation" />
						
						          <fo:block break-before="page" />
						
						          <!-- Show Executive Summary Page -->
						
						          <fo:block font-family="Times">
						          
						          <xsl:call-template name="processLevel1Text" />
						          
						          </fo:block>
						          
						          <fo:block break-before="page" />
						
						          <!-- Show Executive Summary Page -->
						
						          <fo:block font-family="Times">
						          
						          <xsl:call-template name="slaStats"/>
						          
						          </fo:block>
						
						          <!-- /Show Executive Summary Page -->

                			</fo:table-cell>
            			</fo:table-row>
        			</fo:table-body>
    			</fo:table>
        	</fo:flow>
      	</fo:page-sequence>

      <!-- /Section One -->

      <!-- Section Two - Findings -->

      <fo:page-sequence master-reference="findings-page">
        <!-- Show Header -->

        <fo:static-content display-align="after" flow-name="xsl-region-before">
          <fo:block font-family="Times">
            <fo:table border-style="solid" border-width="1pt"
                      space-before="20pt" table-layout="fixed" width="100%">
              <fo:table-column column-width="80pt" />

              <fo:table-column />

              <fo:table-column column-width="80pt" />

              <fo:table-column />

              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell background-color="#E0E0E0"
                                 border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block>Origin: </fo:block>
                  </fo:table-cell>

                  <fo:table-cell border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block><xsl:value-of select="MonthlyStats/ReportTitle"/>
                    </fo:block>
                  </fo:table-cell>

                  <fo:table-cell background-color="#E0E0E0"
                                 border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block>Title: </fo:block>
                  </fo:table-cell>

                  <fo:table-cell border-style="solid" border-width="1pt"
                                 display-align="center" padding="4pt"
                                 text-align="start">
                    <fo:block>
                      <xsl:value-of select="MonthlyStats/ReportMonth"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
        </fo:static-content>

        <!-- /Header -->

        <!-- Show Footer -->

        <fo:static-content display-align="after" flow-name="xsl-region-after">
          <fo:block font-family="Times">
            <fo:table margin-left="-45pt" margin-right="0pt"
                      table-layout="fixed" width="100%">
              <fo:table-column />

              <fo:table-column />

              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell border-color="white" border-style="solid"
                                 border-width="0pt" display-align="center"
                                 padding="0pt" text-align="start">
                    <fo:block color="black" font-family="Times"
                    font-size="10pt" margin-left="0pt" space-before="-20pt"
                    text-align="left"><xsl:value-of select="MonthlyStats/ReportTitle"/>
                    </fo:block>
                  </fo:table-cell>

                  <fo:table-cell border-color="white" border-style="solid"
                                 border-width="0pt" display-align="center"
                                 padding="0pt" text-align="start">
                    <fo:block color="black" font-family="Times"
                    font-size="10pt" space-before="-20pt" text-align="right">
                    Page <fo:page-number /> </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
        </fo:static-content>

        <!-- /Footer -->

        <fo:flow flow-name="xsl-region-body">
        	<fo:table table-layout="fixed"  width="100%">
        		<fo:table-column/>
        			<fo:table-header>
            			<fo:table-row>
                			<fo:table-cell padding-bottom="-257mm">
                				<fo:instream-foreign-object>
                					<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width = "1000px" height="400px">
                						<svg:text x="295" y="-60" transform="rotate(45)" font-family="Times" font-size="42pt" fill="rgb(240,240,240)">CONFIDENTIAL</svg:text>
                					</svg:svg>
                				</fo:instream-foreign-object>
                   			</fo:table-cell>
            			</fo:table-row>
        			</fo:table-header>
        			<fo:table-body>
            			<fo:table-row>
                			<fo:table-cell>

          <fo:block font-family="Times">
            <xsl:attribute name="id">Findings</xsl:attribute>

            <fo:block color="#000000" font-size="16pt" font-weight="bold"> 3.
            Details of Outstanding Critical and High Impact Issues</fo:block>

            <fo:block margin-left="0pt">
              	<fo:instream-foreign-object>
					<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="750" height="2">
						<svg:line x1="0" y1="0" x2="750" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/> 
					</svg:svg>
				</fo:instream-foreign-object>
            </fo:block>
            
            <fo:block color="#000000" font-size="10pt">Details of all critical and high impact issues follow.</fo:block>
            
            <xsl:for-each select="MonthlyStats/Project[CurrentStats/CriticalCount > 0] | MonthlyStats/Project[CurrentStats/HighCount > 0]">

	            <fo:block color="#000000" font-size="11pt" font-weight="bold" space-before="20pt">
	            	<xsl:attribute name="id"><xsl:value-of select="@name" /></xsl:attribute>
	 				3.<!--<xsl:number format="1" level="single" />--><xsl:value-of select="position()" />. <xsl:value-of select="@name" />
	    		</fo:block>
		    		
		    	<xsl:choose>
		    		<xsl:when test="count(OpenIssues/Finding) > 0">
		    		
		    		<xsl:for-each select="OpenIssues">
		                <xsl:call-template name="processTarget">
		                  <xsl:with-param name="targetData">
		                    <xsl:value-of select="." />
		                  </xsl:with-param>                 
		                </xsl:call-template>
		            </xsl:for-each>
	            	
	            	</xsl:when>
	            	<xsl:otherwise>
	            		<fo:block color="#000000" font-size="10pt">No outstanding issues.</fo:block>
	            	</xsl:otherwise>
	            </xsl:choose>
			</xsl:for-each>
			
			
          </fo:block>
          
          <fo:block id="end" />        			


                			</fo:table-cell>
            			</fo:table-row>
        			</fo:table-body>
    			</fo:table>
        	</fo:flow>
      	</fo:page-sequence>

      <!-- /Section Two - Findings -->
    </fo:root>
  </xsl:template>

  <!-- *** Definitions *** -->

  <!-- First Page Definition -->

  <xsl:template name="DisplayFirstPage">
    <fo:block font-family="Times">
      <fo:block space-before="20pt">
        <fo:external-graphic margin-right="290pt">
          <xsl:attribute name="src">url('<xsl:text
          disable-output-escaping="yes">Image Path Goes Here/xsl:text>')</xsl:attribute>
        </fo:external-graphic>
      </fo:block>

	<fo:block space-before="250pt">
		<fo:instream-foreign-object>
			<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="513" height="2">
				<svg:line x1="0" y1="0" x2="513" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/> 
			</svg:svg>
		</fo:instream-foreign-object>
	</fo:block>

      <fo:block font-size="24pt" margin-right="13pt" text-align="right">
        <xsl:value-of select="MonthlyStats/ReportTitle"/>
      </fo:block>

      <fo:block font-size="18pt" margin-right="13pt" text-align="right">
        <xsl:value-of select="MonthlyStats/ReportSubTitle"/> - <xsl:value-of select="MonthlyStats/ReportMonth"/>
      </fo:block>
    </fo:block>
  </xsl:template>

  <!-- /First Page Definition -->

  <!-- Table of Contents Difinition -->

  <xsl:template name="DisplayTableOfContents">
  	<!--<xsl:param name="filteredNodeList" />-->
  	<!--
    <fo:block break-before="page" />
    -->

    <fo:block font-family="Times">
      <fo:block color="#000000" font-size="16pt" font-weight="bold"> Table Of
      Contents </fo:block>

      <fo:block margin-left="0pt">
		<fo:instream-foreign-object>
			<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="468" height="2">
				<svg:line x1="0" y1="0" x2="468" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/> 
			</svg:svg>
		</fo:instream-foreign-object>
      </fo:block>

      <fo:block end-indent="24pt" font-size="14pt" font-weight="bold"
                last-line-end-indent="-24pt" line-height="20pt"
                space-after="20pt" text-align-last="justify">
        <fo:inline keep-with-next.within-line="always"> 0. Document
        Information </fo:inline>

        <fo:inline keep-together.within-line="always">
          <fo:leader keep-with-next.within-line="always"
                     leader-alignment="reference-area" leader-pattern="dots"
                     leader-pattern-width="3pt" />

          <fo:page-number-citation ref-id="DocumentInformation" />
        </fo:inline>

        <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                  last-line-end-indent="-24pt" line-height="14pt"
                  text-align-last="justify">
          <fo:inline keep-with-next.within-line="always"> <fo:leader
          leader-length="30pt" leader-pattern="space" /> 0.1 Review Details
          </fo:inline>

          <fo:inline keep-together.within-line="always">
            <fo:leader keep-with-next.within-line="always"
                       leader-alignment="reference-area" leader-pattern="dots"
                       leader-pattern-width="3pt" />
            <fo:page-number-citation>
              <xsl:attribute name="ref-id">ReviewDetails</xsl:attribute>
            </fo:page-number-citation>
          </fo:inline>
        </fo:block>

        <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                  last-line-end-indent="-24pt" line-height="14pt"
                  text-align-last="justify">
          <fo:inline keep-with-next.within-line="always"> <fo:leader
          leader-length="30pt" leader-pattern="space" /> 0.2 Revision Details
          </fo:inline>

          <fo:inline keep-together.within-line="always">
            <fo:leader keep-with-next.within-line="always"
                       leader-alignment="reference-area" leader-pattern="dots"
                       leader-pattern-width="3pt" />

            <fo:page-number-citation>
              <xsl:attribute name="ref-id">RevisionDetails</xsl:attribute>
            </fo:page-number-citation>
          </fo:inline>
        </fo:block>
      </fo:block>
      
      
      <fo:block end-indent="24pt" font-size="14pt" font-weight="bold"
                last-line-end-indent="-24pt" line-height="20pt"
                space-after="20pt" text-align-last="justify">
        <fo:inline keep-with-next.within-line="always"> 1. Summary of Issues</fo:inline>

        <fo:inline keep-together.within-line="always">
          <fo:leader keep-with-next.within-line="always"
                     leader-alignment="reference-area" leader-pattern="dots"
                     leader-pattern-width="3pt" />

          <fo:page-number-citation ref-id="SummaryOfIssues" />
        </fo:inline>

        <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                  last-line-end-indent="-24pt" line-height="14pt"
                  text-align-last="justify">
          <fo:inline keep-with-next.within-line="always"> <fo:leader
          leader-length="30pt" leader-pattern="space" /> 1.1 All Issues
          </fo:inline>

          <fo:inline keep-together.within-line="always">
            <fo:leader keep-with-next.within-line="always"
                       leader-alignment="reference-area" leader-pattern="dots"
                       leader-pattern-width="3pt" />
            <fo:page-number-citation>
              <xsl:attribute name="ref-id">allIssueSummary</xsl:attribute>
            </fo:page-number-citation>
          </fo:inline>
        </fo:block>
          
         <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                  last-line-end-indent="-24pt" line-height="14pt" 
                  text-align-last="justify">
          <fo:inline keep-with-next.within-line="always"> <fo:leader
          leader-length="30pt" leader-pattern="space" /> 1.2 By Project With Outstanding Critical or High Impact Issues
          </fo:inline>
          
          <fo:inline keep-together.within-line="always">
            <fo:leader keep-with-next.within-line="always"
                       leader-alignment="reference-area" leader-pattern="dots"
                       leader-pattern-width="3pt" />
            <fo:page-number-citation>
              <xsl:attribute name="ref-id">1.2. By Project With Outstanding Critical or High Impact Issues</xsl:attribute>
            </fo:page-number-citation>
          </fo:inline>
        </fo:block>
        
        <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                  last-line-end-indent="-24pt" line-height="14pt" 
                  text-align-last="justify">
          <fo:inline keep-with-next.within-line="always"> <fo:leader
          leader-length="30pt" leader-pattern="space" /> 1.3 All Other Projects
          </fo:inline>
          
          <fo:inline keep-together.within-line="always">
            <fo:leader keep-with-next.within-line="always"
                       leader-alignment="reference-area" leader-pattern="dots"
                       leader-pattern-width="3pt" />
            <fo:page-number-citation>
              <xsl:attribute name="ref-id">1.3. All Other Projects</xsl:attribute>
            </fo:page-number-citation>
          </fo:inline>
        </fo:block>
        
        </fo:block>
        
      <fo:block end-indent="24pt" font-size="14pt" font-weight="bold"
                last-line-end-indent="-24pt" line-height="20pt"
                space-after="20pt" text-align-last="justify">
        <fo:inline keep-with-next.within-line="always"> 2. Function SLA's and KPI's</fo:inline>

        <fo:inline keep-together.within-line="always">
          <fo:leader keep-with-next.within-line="always"
                     leader-alignment="reference-area" leader-pattern="dots"
                     leader-pattern-width="3pt" />

          <fo:page-number-citation ref-id="Function SLA's and KPI's" />
        </fo:inline>

        <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                  last-line-end-indent="-24pt" line-height="14pt"
                  text-align-last="justify">
          <fo:inline keep-with-next.within-line="always"> <fo:leader
          leader-length="30pt" leader-pattern="space" /> 2.1 KPI
          </fo:inline>

          <fo:inline keep-together.within-line="always">
            <fo:leader keep-with-next.within-line="always"
                       leader-alignment="reference-area" leader-pattern="dots"
                       leader-pattern-width="3pt" />
            <fo:page-number-citation>
              <xsl:attribute name="ref-id">KPI</xsl:attribute>
            </fo:page-number-citation>
          </fo:inline>
        </fo:block>
          
         <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                  last-line-end-indent="-24pt" line-height="14pt" 
                  text-align-last="justify">
          <fo:inline keep-with-next.within-line="always"> <fo:leader
          leader-length="30pt" leader-pattern="space" /> 2.2 SLAs
          </fo:inline>
          
          <fo:inline keep-together.within-line="always">
            <fo:leader keep-with-next.within-line="always"
                       leader-alignment="reference-area" leader-pattern="dots"
                       leader-pattern-width="3pt" />
            <fo:page-number-citation>
              <xsl:attribute name="ref-id">SLAs</xsl:attribute>
            </fo:page-number-citation>
          </fo:inline>
        </fo:block>
        
        </fo:block>

        
        
        
      <fo:block end-indent="24pt" font-size="14pt" font-weight="bold"
                last-line-end-indent="-24pt" line-height="20pt"
                space-after="20pt" text-align-last="justify">
        <fo:inline keep-with-next.within-line="always"> 3. Details of Outstanding Critical and High Impact Issues
        </fo:inline>

        <fo:inline keep-together.within-line="always">
          <fo:leader keep-with-next.within-line="always"
                     leader-alignment="reference-area" leader-pattern="dots"
                     leader-pattern-width="3pt" />

          <fo:page-number-citation ref-id="Findings" />
        </fo:inline>

        <xsl:for-each select="MonthlyStats/Project[CurrentStats/CriticalCount > 0] | MonthlyStats/Project[CurrentStats/HighCount > 0]">
            <fo:block end-indent="24pt" font-size="11pt" font-weight="normal"
                      last-line-end-indent="-24pt" line-height="14pt"
                      text-align-last="justify">
              <fo:inline keep-with-next.within-line="always"> <fo:leader
              leader-length="30pt" leader-pattern="space" /> 3.<!--<xsl:number
              format="1." level="single" />--><xsl:value-of select="position()"/> &#160;<xsl:value-of
              select="@name" /> </fo:inline>

              <fo:inline keep-together.within-line="always">
                <fo:leader keep-with-next.within-line="always"
                           leader-alignment="reference-area"
                           leader-pattern="dots" leader-pattern-width="3pt" />

                <fo:page-number-citation>
                  <xsl:attribute name="ref-id">
                    <xsl:value-of select="@name" />
                  </xsl:attribute>
                </fo:page-number-citation>
              </fo:inline>
            </fo:block>
        </xsl:for-each>
      </fo:block>
    </fo:block>
  </xsl:template>

  <!-- /Table of Contents Difinition -->

  <!-- Document Information Page Definition -->

  <xsl:template name="DisplayDocumentInformation">
    <fo:block break-before="page" />

    <fo:block font-family="Times">
      <xsl:attribute name="id">DocumentInformation</xsl:attribute>

      <!-- /Documents Information - Information Block Definition -->

      <fo:block color="#000000" font-size="16pt" font-weight="bold"> 0.
      Document Information </fo:block>

      <fo:block margin-left="0pt">
      	<fo:instream-foreign-object>
			<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="497" height="2">
				<svg:line x1="0" y1="0" x2="497" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/> 
			</svg:svg>
		</fo:instream-foreign-object>
      </fo:block>

      <fo:table border-style="solid" border-width="1pt" space-before="20pt"
                table-layout="fixed" width="100%">
        <fo:table-column column-width="50pt" />

        <fo:table-column column-width="80pt" />

        <fo:table-column column-width="50pt" />

        <fo:table-column />

        <fo:table-column />

        <fo:table-column column-width="120pt" />

        <fo:table-body>
          <fo:table-row>
            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Author:</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block>
                <xsl:value-of select="MonthlyStats/ReportAuthor"/>
              </fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Status:</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block>Published</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Issue Date:</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block><xsl:value-of select="MonthlyStats/ReportDate"/></fo:block>
            </fo:table-cell>
          </fo:table-row>

          <fo:table-row>
            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           number-columns-spanned="2" padding="4pt"
                           text-align="start">
              <fo:block>Confidentiality Rating:</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" number-columns-spanned="2"
                           padding="4pt" text-align="start">
              <fo:block>Confidential</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Section</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block>Issue</fo:block>
            </fo:table-cell>
          </fo:table-row>

          <fo:table-row>
            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           number-columns-spanned="2" padding="4pt"
                           text-align="start">
              <fo:block>Approved By:</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" number-columns-spanned="2"
                           padding="4pt" text-align="start">
              <fo:block>Security Assessment</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Signed:</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block />
            </fo:table-cell>
          </fo:table-row>
        </fo:table-body>
      </fo:table>

      <!-- /Documents Information - Information Block Definition -->

      <!-- Documents Information - Review Details Section Definition -->

      <fo:block color="#000000" font-size="13pt" font-weight="bold"
      space-before="20pt"> <xsl:attribute
      name="id">ReviewDetails</xsl:attribute> 0.1 Review Details </fo:block>

      <fo:table border-style="solid" border-width="1pt" space-before="20pt"
                table-layout="fixed" width="100%">
        <fo:table-column column-width="50pt" />

        <fo:table-column column-width="100pt" />

        <fo:table-column column-width="150pt" />

        <fo:table-column />

        <fo:table-body>
          <fo:table-row>
            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Version</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Reviewed</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Date</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Detail</fo:block>
            </fo:table-cell>
          </fo:table-row>

          <fo:table-row>
            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block>1.0</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block><xsl:value-of select="MonthlyStats/ReportReviewer"/></fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block><xsl:value-of select="MonthlyStats/ReportDate"/></fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block>Version 1.0</fo:block>
            </fo:table-cell>
          </fo:table-row>
        </fo:table-body>
      </fo:table>

      <!-- /Documents Information - Review Details Section Definition -->

      <!-- Documents Information - Revision History Section Definition -->

      <fo:block color="#000000" font-size="13pt" font-weight="bold"
      space-before="20pt"> <xsl:attribute
      name="id">RevisionDetails</xsl:attribute> 0.2 Revision History
      </fo:block>

      <fo:table border-style="solid" border-width="1pt" space-before="20pt"
                table-layout="fixed" width="100%">
        <fo:table-column column-width="50pt" />

        <fo:table-column column-width="100pt" />

        <fo:table-column column-width="150pt" />

        <fo:table-column />

        <fo:table-body>
          <fo:table-row>
            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Version</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Author</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Date</fo:block>
            </fo:table-cell>

            <fo:table-cell background-color="#E0E0E0" border-style="solid"
                           border-width="1pt" display-align="center"
                           padding="4pt" text-align="start">
              <fo:block>Detail</fo:block>
            </fo:table-cell>
          </fo:table-row>

          <fo:table-row>
            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block>1.0</fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block><xsl:value-of select="MonthlyStats/ReportAuthor"/></fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block><xsl:value-of select="MonthlyStats/ReportDate"/></fo:block>
            </fo:table-cell>

            <fo:table-cell border-style="solid" border-width="1pt"
                           display-align="center" padding="4pt"
                           text-align="start">
              <fo:block>Version 1.0</fo:block>
            </fo:table-cell>
          </fo:table-row>
        </fo:table-body>
      </fo:table>

      <!-- /Documents Information - Revision History Section Definition -->

    </fo:block>
  </xsl:template>

  <!-- /Documents Information - Related Documents Section Definition -->

  <!-- Document Information Page Definition -->

  <!-- Bold Style Definition -->

  <xsl:template match="b">
    <fo:inline font-weight="bold">
      <xsl:apply-templates />
    </fo:inline>
  </xsl:template>

  <!-- /Bold Style Definition -->

  <!-- Newline Style Definition -->

  <xsl:template match="newline">
    <fo:block>
      <fo:leader leader-pattern="space" />
    </fo:block>
  </xsl:template>

  <!-- /Newline Style Definition -->

  <!-- List Style Definition -->

  <xsl:template match="ul">
    <fo:block>
      <fo:list-block>
        <xsl:apply-templates />
      </fo:list-block>
    </fo:block>
  </xsl:template>

  <xsl:template match="li">
    <fo:list-item>
      <fo:list-item-label end-indent="label-end()" margin-left="10pt">
        <fo:block> - </fo:block>
      </fo:list-item-label>

      <fo:list-item-body start-indent="body-start()">
        <fo:block>
          <xsl:apply-templates />
        </fo:block>
      </fo:list-item-body>
    </fo:list-item>
  </xsl:template>

  <!-- /List Style Definition -->

  <!-- Issue Summary Style Definition -->
  <xsl:template name="processLevel1Text">

    <fo:block color="#000000" font-size="16pt" font-weight="bold">
      <xsl:attribute name="id">SummaryOfIssues</xsl:attribute>

      <xsl:number format="1." level="single" />Summary Of Issues
    </fo:block>

    <fo:block margin-left="0pt">
		<fo:instream-foreign-object>
			<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="497" height="2">
				<svg:line x1="0" y1="0" x2="497" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/> 
			</svg:svg>
		</fo:instream-foreign-object>
    </fo:block>

<xsl:call-template name="allLocSummary"/>

<xsl:call-template name="locSummary">
 <xsl:with-param name="title">1.2. By Project With Outstanding Critical or High Impact Issues</xsl:with-param>
 <xsl:with-param name="filteredList"><xsl:value-of select="MonthlyStats/Project[CurrentStats/CriticalCount > 0] | MonthlyStats/Project[CurrentStats/HighCount > 0]"/></xsl:with-param>
</xsl:call-template>

<xsl:call-template name="locSummary">
 <xsl:with-param name="title">1.3. All Other Projects</xsl:with-param>
 <xsl:with-param name="filteredList"><xsl:value-of select="MonthlyStats/Project[CurrentStats/CriticalCount = 0][CurrentStats/HighCount = 0]"/></xsl:with-param>
</xsl:call-template>

    <fo:block color="#111111" font-size="10pt" margin-right="-20pt"
              space-after="20pt">
    </fo:block>
  </xsl:template>

	<!-- /Issue Summary Style Definition -->

  <!-- Target Style Definition -->

  <xsl:template name="processTarget">
    <xsl:param name="targetData" />
    <!--<xsl:param name="RecommendationsDatabase" />-->
    <xsl:param name="ItemNumber" />

    <!-- Name -->

    <fo:block color="#111111" font-size="10pt" margin-right="-20pt"
              space-after="20pt" space-before="10pt">
      <fo:table border-color="black" border-style="solid" border-width="2px"
                padding="0pt" space-after.optimum="2pt"
                space-before.optimum="1pt" table-layout="fixed" width="100%">
        <fo:table-column column-width="40pt" />

        <fo:table-column column-width="70pt" />

        <fo:table-column column-width="50pt" />

        <fo:table-column column-width="60pt" />

        <fo:table-column column-width="225pt" />

        <fo:table-column />

        <fo:table-body>
          <xsl:call-template name="printTopOfFindingsTable" />

          <xsl:for-each select="$targetData/Finding">
            <xsl:call-template name="processFinding">
              <xsl:with-param name="findingData">
                <xsl:value-of select="." />
              </xsl:with-param>
            </xsl:call-template>
          </xsl:for-each>
        </fo:table-body>
      </fo:table>
    </fo:block>
  </xsl:template>

  <!-- /Target Style Definition -->

  <!-- Finding Style Definition -->

  <xsl:template name="processFinding">
    <xsl:param name="findingData" />

      <fo:table-row padding="2pt">
        <fo:table-cell border-style="solid" padding="2pt">
          <fo:block color="#111111" font-size="8pt" margin-right="2pt"
          wrap-option="wrap"><xsl:apply-templates
          select="$findingData/@Issue-id" /></fo:block>
        </fo:table-cell>
        
        <fo:table-cell border-style="solid" padding="2pt">
          <fo:block color="#111111" font-size="8pt" margin-right="2pt"
                    wrap-option="wrap">
            <xsl:apply-templates select="$findingData/Resolution/@DateOpened" />
          </fo:block>
        </fo:table-cell>
        
        <fo:table-cell border-style="solid" padding="2pt">
          <fo:block color="#111111" font-size="8pt" margin-right="2pt"
                    wrap-option="wrap">
            <xsl:apply-templates select="$findingData/@Impact" />
          </fo:block>
        </fo:table-cell>

        <fo:table-cell border-style="solid" padding="2pt">
          <fo:block color="#111111" font-size="8pt" margin-right="2pt"
                    wrap-option="wrap">
            <xsl:apply-templates select="$findingData/@Probability" />
          </fo:block>
        </fo:table-cell>

        <fo:table-cell border-style="solid" padding="2pt">
          <fo:block color="#111111" font-size="8pt" margin-right="2pt"
                    wrap-option="wrap">
            <xsl:value-of select="$findingData/@Vulnerability" />
          </fo:block>
        </fo:table-cell>

        <fo:table-cell border-style="solid" padding="2pt">
          <fo:block color="#111111" font-size="8pt" margin-right="2pt"
                    wrap-option="wrap">
            <xsl:value-of select="$findingData/AuditTrailItem"/>

          </fo:block>
        </fo:table-cell>

      </fo:table-row>
    <!--</xsl:if>-->
  </xsl:template>

  <!-- Findings - Findings Table Top Row Style Definition -->

  <xsl:template name="printTopOfFindingsTable">
    <fo:table-row background-color="#003399" color="#FFFFFF" text-align="left">
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Issue ID</fo:block>
      </fo:table-cell>

      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Date Reported</fo:block>
      </fo:table-cell>

      <fo:table-cell border-style="solid" padding="2pt">
        <fo:block font-size="10pt" font-weight="bold">Impact</fo:block>
      </fo:table-cell>

      <fo:table-cell border-style="solid" padding="2pt">
        <fo:block font-size="10pt" font-weight="bold">Probability</fo:block>
      </fo:table-cell>

      <fo:table-cell border-style="solid" padding="2pt">
        <fo:block font-size="10pt" font-weight="bold">Finding</fo:block>
      </fo:table-cell>

      <fo:table-cell border-style="solid" padding="2pt">
        <fo:block font-size="10pt" font-weight="bold">Additional Details</fo:block>
      </fo:table-cell>
    </fo:table-row>
  </xsl:template>
  
  <!-- Findings - Findings Table Top Row Style Definition -->
  
  
  
  <xsl:template name="allLocSummary">

<fo:block color="#000000" font-size="11pt" font-weight="bold"
    space-before="20pt"> <xsl:attribute name="id">allIssueSummary</xsl:attribute>
1.1. All Locations
    </fo:block>
<fo:block>
<fo:table border-color="black" border-style="solid" border-width="1px"
                padding="0" space-after.optimum="2pt" 
                space-before.optimum="2pt" table-layout="fixed" width="100%">
                
        <fo:table-column  />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />

        <fo:table-body>
        
	<fo:table-row text-align="left">
	  <fo:table-cell padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"></fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Critical</fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">High</fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Medium</fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Low</fo:block>
      </fo:table-cell>
	</fo:table-row>	
	<fo:table-row text-align="left">
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Region</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
	</fo:table-row>
	
<xsl:call-template name="locSumLine">
	<xsl:with-param name="lineDetails" select="/MonthlyStats/ProjectByRegion/Region[@name='EU']" />
	<xsl:with-param name="region">Europe</xsl:with-param>
</xsl:call-template>
<xsl:call-template name="locSumLine">
	<xsl:with-param name="lineDetails" select="/MonthlyStats/ProjectByRegion/Region[@name='ASIA']" />
	<xsl:with-param name="region">Asia</xsl:with-param>
</xsl:call-template>
<xsl:call-template name="locSumLine">
	<xsl:with-param name="lineDetails" select="/MonthlyStats/ProjectByRegion/Region[@name='NA']" />
	<xsl:with-param name="region">North America</xsl:with-param>
</xsl:call-template>
<xsl:call-template name="locSumLine">
	<xsl:with-param name="lineDetails" select="/MonthlyStats/ProjectByRegion/Region[@name='LA']" />
	<xsl:with-param name="region">Latin America</xsl:with-param>
</xsl:call-template>
<xsl:call-template name="locSumLine">
	<xsl:with-param name="lineDetails" select="/MonthlyStats/ProjectByRegion/Region[@name='NL']" />
	<xsl:with-param name="region">Netherlands</xsl:with-param>
</xsl:call-template>
<xsl:call-template name="locSumLine">
	<xsl:with-param name="lineDetails" select="/MonthlyStats/ProjectByRegion/Region[@name='ALL']" />
	<xsl:with-param name="region">All Regions</xsl:with-param>
</xsl:call-template>
	
	
		</fo:table-body>
	</fo:table>
	    </fo:block>
  </xsl:template>
  
	<xsl:template name="locSumLine">
	<xsl:param name="lineDetails"/>
	<xsl:param name="region"/>
	<fo:table-row text-align="left">
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="$region"/></fo:block>
      </fo:table-cell>
      
      <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Closed/CriticalCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Closed/CriticalCount &gt; 0"><xsl:value-of select="$lineDetails/Closed/CriticalCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Reported/CriticalCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Reported/CriticalCount &gt; 0"><xsl:value-of select="$lineDetails/Reported/CriticalCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
      
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Closed/HighCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Closed/HighCount &gt; 0"><xsl:value-of select="$lineDetails/Closed/HighCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Reported/HighCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Reported/HighCount &gt; 0"><xsl:value-of select="$lineDetails/Reported/HighCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
      
      <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Closed/MediumCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Closed/MediumCount &gt; 0"><xsl:value-of select="$lineDetails/Closed/MediumCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Reported/MediumCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Reported/MediumCount &gt; 0"><xsl:value-of select="$lineDetails/Reported/MediumCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>

	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Closed/LowCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Closed/LowCount &gt; 0"><xsl:value-of select="$lineDetails/Closed/LowCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/Reported/LowCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/Reported/LowCount &gt; 0"><xsl:value-of select="$lineDetails/Reported/LowCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>

	</fo:table-row>

</xsl:template>
<!--
   <fo:table border-color="black" border-style="solid" border-width="1px"
                padding="0" space-after.optimum="2pt" 
                space-before.optimum="2pt" table-layout="fixed" width="160pt">
        <fo:table-column column-width="120pt" />
        <fo:table-column column-width="40pt" />
        <fo:table-column column-width="40pt" />

        <fo:table-body>
        
	<fo:table-row text-align="left">
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"></fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Current</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Original</fo:block>
      </fo:table-cell>
	</fo:table-row>
	<fo:table-row text-align="left">
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Critical Impact Issues</fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects/CriticalCount"/></fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects_Reported/CriticalCount"/></fo:block>
      </fo:table-cell>
	</fo:table-row>
	<fo:table-row text-align="left">
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">High Impact Issues</fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects/HighCount"/></fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects_Reported/HighCount"/></fo:block>
      </fo:table-cell>
	</fo:table-row>
	<fo:table-row text-align="left">
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Medium Impact Issues</fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects/MediumCount"/></fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects_Reported/MediumCount"/></fo:block>
      </fo:table-cell>
	</fo:table-row>
	<fo:table-row text-align="left">
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Low Impact Issues</fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects/LowCount"/></fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/AllProjects_Reported/LowCount"/></fo:block>
      </fo:table-cell>
	</fo:table-row>
        </fo:table-body>
      </fo:table>-->



  <xsl:template name="locSummaryHeader">	
	<fo:table-row text-align="left">
	  <fo:table-cell number-columns-spanned="3" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"></fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Critical</fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">High</fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Medium</fo:block>
      </fo:table-cell>
      <fo:table-cell number-columns-spanned="2" background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Low</fo:block>
      </fo:table-cell>
	</fo:table-row>	
	<fo:table-row text-align="left">
	  <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Date</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Region</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Project</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">Cur.</fo:block>
      </fo:table-cell>
      <fo:table-cell background-color="#003399" color="#FFFFFF" border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold">Orig.</fo:block>
      </fo:table-cell>
	</fo:table-row>
</xsl:template>	
	
<xsl:template name="locSummary">
<xsl:param name="title"/>
<xsl:param name="filteredList"/>

<fo:block color="#000000" font-size="11pt" font-weight="bold" space-before="20pt"> <xsl:attribute name="id"><xsl:value-of select="$title"/></xsl:attribute>
	<xsl:value-of select="$title"/>
    </fo:block>

	<fo:block>
	<fo:table border-color="black" border-style="solid" border-width="1px"
                padding="0" space-after.optimum="2pt" 
                space-before.optimum="2pt" table-layout="fixed" width="100%">
        <fo:table-column column-width="60pt" />
        <fo:table-column column-width="40pt" />
        <fo:table-column />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />
        <fo:table-column column-width="30pt" />

        <fo:table-body>

	<xsl:call-template name="locSummaryHeader"/>

	<xsl:for-each select="$filteredList">
	<xsl:sort select="@dateCompleted" order="descending"/>
	
	<xsl:call-template name="locSummaryLine">
		<xsl:with-param name="lineDetails">
			<xsl:value-of select="."/>
		</xsl:with-param>
	</xsl:call-template>
	
	</xsl:for-each>
	
	        </fo:table-body>
      </fo:table>
    </fo:block>
	
</xsl:template>
	
<xsl:template name="locSummaryLine">
<xsl:param name="lineDetails" />
	<fo:table-row text-align="left">
	  <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="$lineDetails/@dateCompleted"/></fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="$lineDetails/@region"/></fo:block>
      </fo:table-cell>
      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="$lineDetails/@name"/></fo:block>
      </fo:table-cell>
      
      <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/CurrentStats/CriticalCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/CurrentStats/CriticalCount &gt; 0"><xsl:value-of select="$lineDetails/CurrentStats/CriticalCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/OriginalStats/CriticalCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/OriginalStats/CriticalCount &gt; 0"><xsl:value-of select="$lineDetails/OriginalStats/CriticalCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
      
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/CurrentStats/HighCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/CurrentStats/HighCount &gt; 0"><xsl:value-of select="$lineDetails/CurrentStats/HighCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/OriginalStats/HighCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/OriginalStats/HighCount &gt; 0"><xsl:value-of select="$lineDetails/OriginalStats/HighCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
      
      <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/CurrentStats/MediumCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/CurrentStats/MediumCount &gt; 0"><xsl:value-of select="$lineDetails/CurrentStats/MediumCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/OriginalStats/MediumCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/OriginalStats/MediumCount &gt; 0"><xsl:value-of select="$lineDetails/OriginalStats/MediumCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>

	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" border-left-width="3px">
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/CurrentStats/LowCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/CurrentStats/LowCount &gt; 0"><xsl:value-of select="$lineDetails/CurrentStats/LowCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>
	 <fo:table-cell border-style="solid" padding="2pt" text-align="center" >
        <fo:block font-size="10pt" font-weight="bold">
			<xsl:if test="$lineDetails/OriginalStats/LowCount = 0">-</xsl:if>
			<xsl:if test="$lineDetails/OriginalStats/LowCount &gt; 0"><xsl:value-of select="$lineDetails/OriginalStats/LowCount"/></xsl:if>
		</fo:block>
      </fo:table-cell>

	</fo:table-row>
  </xsl:template>

 
<xsl:template name="slaStats">

	<fo:block color="#000000" font-size="16pt" font-weight="bold"
    	space-before="20pt"><xsl:attribute name="id">Function SLA's and KPI's</xsl:attribute>2.0 Function SLA's and KPI's</fo:block>

    <fo:block margin-left="0pt">
      	<fo:instream-foreign-object>
			<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="750" height="2">
				<svg:line x1="0" y1="0" x2="468" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/> 
			</svg:svg>
		</fo:instream-foreign-object>
    </fo:block>
    
    <fo:block color="#000000" font-size="10pt"
    	space-before="20pt">Report from 1st January 2006 to current</fo:block>
	<fo:block color="#000000" font-size="11pt" font-weight="bold"
    	space-before="20pt"><xsl:attribute name="id">KPI</xsl:attribute>2.1 KPI</fo:block>
	
	<fo:block>
	   <fo:table border-color="black" border-style="solid" border-width="1px" padding="0" space-after.optimum="2pt" space-before.optimum="2pt" table-layout="fixed">
	        <fo:table-column column-width="410pt" />
	        <fo:table-column column-width="70pt" />
	
	        <fo:table-body>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" background-color="#003399" color="#FFFFFF" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">KPI</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" background-color="#003399" color="#FFFFFF" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">%</fo:block>
		      </fo:table-cell>
			</fo:table-row>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt" font-weight="bold">Percentage of Critical and High issues managed or resolved</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/KPI/ManagedOrResolved/Percentage"/>%(<xsl:value-of select="MonthlyStats/KPI/ManagedOrResolved/ItemsAffected"/> of <xsl:value-of select="MonthlyStats/KPI/ManagedOrResolved/ItemsTotal"/>)</fo:block>
		      </fo:table-cell>
			</fo:table-row>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt" font-weight="bold">Percentage of Open Critical and High issues temporarily managed</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" >
		        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/KPI/TemporarilyManaged/Percentage"/>%(<xsl:value-of select="MonthlyStats/KPI/TemporarilyManaged/ItemsAffected"/> of <xsl:value-of select="MonthlyStats/KPI/ManagedOrResolved/ItemsTotal"/>)</fo:block>
		      </fo:table-cell>
			</fo:table-row>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt" font-weight="bold">Number of IPoP tests completed</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" >
		        <fo:block font-size="10pt" font-weight="bold"><xsl:value-of select="MonthlyStats/KPI/NumberIpops"/></fo:block>
		      </fo:table-cell>
			</fo:table-row>
			</fo:table-body>
		</fo:table>
	</fo:block>
	
	<fo:block color="#000000" font-size="11pt" font-weight="bold"
    	space-before="20pt"><xsl:attribute name="id">SLAs</xsl:attribute>2.2 SLAs</fo:block>
	
	<fo:block>
	   <fo:table border-color="black" border-style="solid" border-width="1px" padding="0" space-after.optimum="2pt" space-before.optimum="2pt" table-layout="fixed">
	        <fo:table-column column-width="200pt"/>
	        <fo:table-column column-width="70pt"/>
	        <fo:table-column column-width="70pt"/>
	        <fo:table-column column-width="70pt"/>
	        <fo:table-column column-width="70pt"/>
	
	        <fo:table-body>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" background-color="#003399" color="#FFFFFF" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">SLA Description</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" background-color="#003399" color="#FFFFFF" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">SLA Days</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" background-color="#003399" color="#FFFFFF" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">Total # Items</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" background-color="#003399" color="#FFFFFF" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">Items In SLA</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" background-color="#003399" color="#FFFFFF" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">Items Outside SLA</fo:block>
		      </fo:table-cell>
			</fo:table-row>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt" font-weight="bold">Request for Security Assessment</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">5</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/Request/ItemsTotal" /></fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/Request/InSLA"/> (<xsl:value-of select="substring(MonthlyStats/KPI/Request/InSLA div MonthlyStats/KPI/Request/ItemsTotal * 100,0,5)"/>%)</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/Request/OutSLA"/> (<xsl:value-of select="substring(MonthlyStats/KPI/Request/OutSLA div MonthlyStats/KPI/Request/ItemsTotal * 100,0,5)"/>%)</fo:block>
		      </fo:table-cell>
			</fo:table-row>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt" font-weight="bold">Issue of Report</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">10</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/Report/ItemsTotal" /></fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/Report/InSLA"/> (<xsl:value-of select="substring(MonthlyStats/KPI/Report/InSLA div MonthlyStats/KPI/Report/ItemsTotal * 100,0,5)"/>%)</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/Report/OutSLA"/> (<xsl:value-of select="substring(MonthlyStats/KPI/Report/OutSLA div MonthlyStats/KPI/Report/ItemsTotal * 100,0,5)"/>%)</fo:block>
		      </fo:table-cell>
			</fo:table-row>
			<fo:table-row text-align="left">
			  <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt" font-weight="bold">Retest of issues managed</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt">
		        <fo:block font-size="10pt" font-weight="bold">4</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/IssueRetest/ItemsTotal" /></fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/IssueRetest/InSLA"/> (<xsl:value-of select="substring(MonthlyStats/KPI/IssueRetest/InSLA div MonthlyStats/KPI/IssueRetest/ItemsTotal * 100,0,5)"/>%)</fo:block>
		      </fo:table-cell>
		      <fo:table-cell border-style="solid" padding="2pt" text-align="left">
		        <fo:block font-size="10pt"><xsl:value-of select="MonthlyStats/KPI/IssueRetest/OutSLA"/> (<xsl:value-of select="substring(MonthlyStats/KPI/IssueRetest/OutSLA div MonthlyStats/KPI/IssueRetest/ItemsTotal * 100,0,5)"/>%)</fo:block>
		      </fo:table-cell>
			</fo:table-row>
			</fo:table-body>
		</fo:table>
	</fo:block>

</xsl:template>
 
 
</xsl:stylesheet>
