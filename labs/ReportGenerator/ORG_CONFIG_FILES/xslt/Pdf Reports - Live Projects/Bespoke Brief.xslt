<?xml version="1.0" encoding="UTF-8"?>
<!-- edited with XMLSpy v2006 sp2 U (http://www.altova.com) by Marc Bown (private) -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:date="http://exslt.org/dates-and-times" xmlns:n1="vuln_report" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:fn="http://www.w3.org/2005/xpath-functions" extension-element-prefixes="date">
	<xsl:variable name="fo:layout-master-set">
		<!-- Master Document Layout -->
		<fo:layout-master-set>
			<fo:simple-page-master margin-left="0.6in" margin-right="0.6in" master-name="First-page" page-height="11in" page-width="8.5in">
				<fo:region-body margin-bottom="0.59in" margin-top="0.0in"/>
			</fo:simple-page-master>
			<fo:simple-page-master margin-left="0.6in" margin-right="0.6in" master-name="default-page" page-height="11in" page-width="8.5in">
				<fo:region-body margin-bottom="0.59in" margin-left="0.40in" margin-top="1.45in"/>
				<fo:region-before extent="1.22in"/>
				<fo:region-after extent="0.24in"/>
			</fo:simple-page-master>
			<fo:simple-page-master margin-left="0.3in" margin-right="0.3in" master-name="findings-page" page-height="8.5in" page-width="11in">
				<fo:region-body margin-bottom="0.79in" margin-top="1.05in"/>
				<fo:region-before extent="1.05in"/>
				<fo:region-after extent="0.24in"/>
			</fo:simple-page-master>
		</fo:layout-master-set>
		<!-- /Master Document Layout -->
	</xsl:variable>
	<xsl:output encoding="UTF-8" indent="no" media-type="text/html" omit-xml-declaration="no" version="1.0"/>
	<xsl:template match="/">
		<fo:root>
			<xsl:copy-of select="$fo:layout-master-set"/>
			<!-- Show Cover Page -->
			<fo:page-sequence format="1" initial-page-number="1" master-reference="First-page">
				<fo:flow flow-name="xsl-region-body">
					<fo:table table-layout="fixed" width="100%">
						<fo:table-column/>
						<fo:table-header>
							<fo:table-row>
								<fo:table-cell padding-bottom="-257mm">
								</fo:table-cell>
							</fo:table-row>
						</fo:table-header>
						<fo:table-body>
							<fo:table-row>
								<fo:table-cell>
									<xsl:call-template name="DisplayFirstPage"/>
								</fo:table-cell>
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
						<fo:table border-style="solid" border-width="1pt" space-before="20pt" table-layout="fixed" width="100%">
							<fo:table-column column-width="80pt"/>
							<fo:table-column/>
							<fo:table-column column-width="80pt"/>
							<fo:table-column/>
							<fo:table-body>
								<fo:table-row>
									<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>Origin: </fo:block>
									</fo:table-cell>
									<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>TSA</fo:block>
									</fo:table-cell>
									<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>Title: </fo:block>
									</fo:table-cell>
									<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>
											<xsl:value-of select="/n1:Project/n1:Metadata/n1:project_name"/> TSA Brief
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
						<fo:table margin-left="-45pt" margin-right="0pt" table-layout="fixed" width="100%">
							<fo:table-column/>
							<fo:table-column/>
							<fo:table-body>
								<fo:table-row>
									<fo:table-cell border-color="white" border-style="solid" border-width="0pt" display-align="center" padding="0pt" text-align="start">
										<fo:block color="black" font-family="Times" font-size="10pt" margin-left="0pt" space-before="-20pt" text-align="left"> Technical Security Assessment Brief
                    </fo:block>
									</fo:table-cell>
									<fo:table-cell border-color="white" border-style="solid" border-width="0pt" display-align="center" padding="0pt" text-align="start">
										<fo:block color="black" font-family="Times" font-size="10pt" space-before="-20pt" text-align="right">
                    Page <fo:page-number/>
										</fo:block>
									</fo:table-cell>
								</fo:table-row>
							</fo:table-body>
						</fo:table>
					</fo:block>
				</fo:static-content>
				<!-- /Footer -->
				<fo:flow flow-name="xsl-region-body">
					<fo:table table-layout="fixed" width="100%">
						<fo:table-column/>
						<fo:table-header>
							<fo:table-row>
								<fo:table-cell padding-bottom="-257mm">
								</fo:table-cell>
							</fo:table-row>
						</fo:table-header>
						<fo:table-body>
							<fo:table-row>
								<fo:table-cell>
									<!-- Show Table of Contents -->
									<xsl:call-template name="DisplayTableOfContents"/>
									<!-- Show Document Information Page -->
									<xsl:call-template name="DisplayDocumentInformation"/>
									<fo:block break-before="page"/>
									<!-- Show ProForma Page -->
									<xsl:call-template name="proFormaPage"/>
								</fo:table-cell>
							</fo:table-row>
						</fo:table-body>
					</fo:table>
				</fo:flow>
			</fo:page-sequence>
			<!-- /Section One -->
			<!-- Section Two -->
			<fo:page-sequence master-reference="findings-page">
				<!-- Header -->
				<fo:static-content display-align="after" flow-name="xsl-region-before">
					<fo:block font-family="Times">
						<fo:table border-style="solid" border-width="1pt" space-before="20pt" table-layout="fixed" width="100%">
							<fo:table-column column-width="80pt"/>
							<fo:table-column/>
							<fo:table-column column-width="80pt"/>
							<fo:table-column/>
							<fo:table-body>
								<fo:table-row>
									<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>Origin: </fo:block>
									</fo:table-cell>
									<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>TSA</fo:block>
									</fo:table-cell>
									<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>Title: </fo:block>
									</fo:table-cell>
									<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
										<fo:block>
											<xsl:value-of select="/n1:Project/n1:Metadata/n1:project_name"/> TSA Brief
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
						<fo:table margin-left="-45pt" margin-right="0pt" table-layout="fixed" width="100%">
							<fo:table-column/>
							<fo:table-column/>
							<fo:table-body>
								<fo:table-row>
									<fo:table-cell border-color="white" border-style="solid" border-width="0pt" display-align="center" padding="0pt" text-align="start">
										<fo:block color="black" font-family="Times" font-size="10pt" margin-left="0pt" space-before="-20pt" text-align="left"> Technical Security Assessment Brief</fo:block>
									</fo:table-cell>
									<fo:table-cell border-color="white" border-style="solid" border-width="0pt" display-align="center" padding="0pt" text-align="start">
										<fo:block color="black" font-family="Times" font-size="10pt" space-before="-20pt" text-align="right">Page <fo:page-number/>
										</fo:block>
									</fo:table-cell>
								</fo:table-row>
							</fo:table-body>
						</fo:table>
					</fo:block>
				</fo:static-content>
				<!-- /Footer -->
				<fo:flow flow-name="xsl-region-body">
					<fo:table table-layout="fixed" width="100%">
						<fo:table-column/>
						<fo:table-header>
							<fo:table-row>
								<fo:table-cell padding-bottom="-257mm">
								</fo:table-cell>
							</fo:table-row>
						</fo:table-header>
						<fo:table-body>
							<fo:table-row>
								<fo:table-cell>
									<xsl:call-template name="agreedScope"/>
									<xsl:call-template name="TSABrief"/>
								</fo:table-cell>
							</fo:table-row>
						</fo:table-body>
					</fo:table>
				</fo:flow>
			</fo:page-sequence>
			<!-- /Section Two -->
		</fo:root>
	</xsl:template>
	<!-- *** Definitions *** -->
	<!-- First Page Definition -->
	<xsl:template name="DisplayFirstPage">
		<fo:block font-family="Times">
			<fo:block space-before="20pt">
				<fo:external-graphic margin-right="290pt">
					<xsl:attribute name="src">url('<xsl:text disable-output-escaping="yes">Image Path Goes Here</xsl:text>')</xsl:attribute>
				</fo:external-graphic>
			</fo:block>
			<fo:block space-before="250pt">
				<fo:instream-foreign-object>
					<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="513" height="2">
						<svg:line x1="0" y1="0" x2="513" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/>
					</svg:svg>
				</fo:instream-foreign-object>
			</fo:block>
			<fo:block font-size="24pt" margin-right="13pt" text-align="right">Technical Security Assessment Brief</fo:block>
			<fo:block font-size="18pt" margin-right="13pt" text-align="right">
				<xsl:value-of select="/n1:Project/n1:Metadata/n1:project_name"/>
			</fo:block>
		</fo:block>
	</xsl:template>
	<!-- /First Page Definition -->
	<!-- Table of Contents Difinition -->
	<xsl:template name="DisplayTableOfContents">
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
			<fo:block end-indent="24pt" font-size="14pt" font-weight="bold" last-line-end-indent="-24pt" line-height="20pt" space-after="20pt" text-align-last="justify">
				<fo:inline keep-with-next.within-line="always"> 0. Document
        Information </fo:inline>
				<fo:inline keep-together.within-line="always">
					<fo:leader keep-with-next.within-line="always" leader-alignment="reference-area" leader-pattern="dots" leader-pattern-width="3pt"/>
					<fo:page-number-citation ref-id="DocumentInformation"/>
				</fo:inline>
				<fo:block end-indent="24pt" font-size="11pt" font-weight="normal" last-line-end-indent="-24pt" line-height="14pt" text-align-last="justify">
					<fo:inline keep-with-next.within-line="always">
						<fo:leader leader-length="30pt" leader-pattern="space"/> 0.1 Review Details
          </fo:inline>
					<fo:inline keep-together.within-line="always">
						<fo:leader keep-with-next.within-line="always" leader-alignment="reference-area" leader-pattern="dots" leader-pattern-width="3pt"/>
						<fo:page-number-citation>
							<xsl:attribute name="ref-id">ReviewDetails</xsl:attribute>
						</fo:page-number-citation>
					</fo:inline>
				</fo:block>
				<fo:block end-indent="24pt" font-size="11pt" font-weight="normal" last-line-end-indent="-24pt" line-height="14pt" text-align-last="justify">
					<fo:inline keep-with-next.within-line="always">
						<fo:leader leader-length="30pt" leader-pattern="space"/> 0.2 Revision Details
          </fo:inline>
					<fo:inline keep-together.within-line="always">
						<fo:leader keep-with-next.within-line="always" leader-alignment="reference-area" leader-pattern="dots" leader-pattern-width="3pt"/>
						<fo:page-number-citation>
							<xsl:attribute name="ref-id">RevisionDetails</xsl:attribute>
						</fo:page-number-citation>
					</fo:inline>
				</fo:block>
				<fo:block end-indent="24pt" font-size="11pt" font-weight="normal" last-line-end-indent="-24pt" line-height="14pt" text-align-last="justify">
					<fo:inline keep-with-next.within-line="always">
						<fo:leader leader-length="30pt" leader-pattern="space"/> 0.3 Related Documents
          </fo:inline>
					<fo:inline keep-together.within-line="always">
						<fo:leader keep-with-next.within-line="always" leader-alignment="reference-area" leader-pattern="dots" leader-pattern-width="3pt"/>
						<fo:page-number-citation>
							<xsl:attribute name="ref-id">RelatedDocuments</xsl:attribute>
						</fo:page-number-citation>
					</fo:inline>
				</fo:block>
			</fo:block>
			<fo:block end-indent="24pt" font-size="14pt" font-weight="bold" last-line-end-indent="-24pt" line-height="20pt" space-after="20pt" text-align-last="justify">
				<fo:inline keep-with-next.within-line="always"> 1. TSA Request Pro Forma</fo:inline>
				<fo:inline keep-together.within-line="always">
					<fo:leader keep-with-next.within-line="always" leader-alignment="reference-area" leader-pattern="dots" leader-pattern-width="3pt"/>
					<fo:page-number-citation ref-id="proFormaPage"/>
				</fo:inline>
			</fo:block>
			<fo:block end-indent="24pt" font-size="14pt" font-weight="bold" last-line-end-indent="-24pt" line-height="20pt" space-after="20pt" text-align-last="justify">
				<fo:inline keep-with-next.within-line="always"> 2. Agreed Project Scope
        </fo:inline>
				<fo:inline keep-together.within-line="always">
					<fo:leader keep-with-next.within-line="always" leader-alignment="reference-area" leader-pattern="dots" leader-pattern-width="3pt"/>
					<fo:page-number-citation ref-id="agreedProjectScope"/>
				</fo:inline>
			</fo:block>
			<fo:block end-indent="24pt" font-size="14pt" font-weight="bold" last-line-end-indent="-24pt" line-height="20pt" space-after="20pt" text-align-last="justify">
				<fo:inline keep-with-next.within-line="always"> 3. TSA Brief
        </fo:inline>
				<fo:inline keep-together.within-line="always">
					<fo:leader keep-with-next.within-line="always" leader-alignment="reference-area" leader-pattern="dots" leader-pattern-width="3pt"/>
					<fo:page-number-citation ref-id="projectBrief"/>
				</fo:inline>
			</fo:block>
		</fo:block>
	</xsl:template>
	<!-- /Table of Contents Difinition -->
	<!-- Document Information Page Definition -->
	<xsl:template name="DisplayDocumentInformation">
		<fo:block break-before="page"/>
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
			<fo:table border-style="solid" border-width="1pt" space-before="20pt" table-layout="fixed" width="100%">
				<fo:table-column column-width="50pt"/>
				<fo:table-column column-width="80pt"/>
				<fo:table-column column-width="50pt"/>
				<fo:table-column/>
				<fo:table-column/>
				<fo:table-column column-width="120pt"/>
				<fo:table-body>
					<fo:table-row>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Author:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:DocumentInformation/@Author"/>
							</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Status:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:DocumentInformation/@Status"/>
							</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Issue Date:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:DocumentInformation/@IssueDate"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<fo:table-row>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" number-columns-spanned="2" padding="4pt" text-align="start">
							<fo:block>Confidentiality Rating:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" border-width="1pt" display-align="center" number-columns-spanned="2" padding="4pt" text-align="start">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:DocumentInformation/@ConfidencialityRating"/>
							</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Section</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:DocumentInformation/@Section"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<fo:table-row>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" number-columns-spanned="2" padding="4pt" text-align="start">
							<fo:block>Approved By:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" border-width="1pt" display-align="center" number-columns-spanned="2" padding="4pt" text-align="start">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:DocumentInformation/@ApprovedBy"/>
							</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Signed:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block/>
						</fo:table-cell>
					</fo:table-row>
				</fo:table-body>
			</fo:table>
			<!-- /Documents Information - Information Block Definition -->
			<!-- Documents Information - Review Details Section Definition -->
			<fo:block color="#000000" font-size="13pt" font-weight="bold" space-before="20pt">
				<xsl:attribute name="id">ReviewDetails</xsl:attribute> 0.1 Review Details </fo:block>
			<fo:table border-style="solid" border-width="1pt" space-before="20pt" table-layout="fixed" width="100%">
				<fo:table-column column-width="50pt"/>
				<fo:table-column column-width="100pt"/>
				<fo:table-column column-width="150pt"/>
				<fo:table-column/>
				<fo:table-body>
					<fo:table-row>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Version</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Reviewed</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Date</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Detail</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<xsl:for-each select="/n1:Project/n1:Metadata/n1:DocumentInformation/n1:ReviewDetails/n1:ReviewDetail">
						<fo:table-row>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@version"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Reviewer"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Date"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Detail"/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
					</xsl:for-each>
				</fo:table-body>
			</fo:table>
			<!-- /Documents Information - Review Details Section Definition -->
			<!-- Documents Information - Revision History Section Definition -->
			<fo:block color="#000000" font-size="13pt" font-weight="bold" space-before="20pt">
				<xsl:attribute name="id">RevisionDetails</xsl:attribute> 0.2 Revision History
      </fo:block>
			<fo:table border-style="solid" border-width="1pt" space-before="20pt" table-layout="fixed" width="100%">
				<fo:table-column column-width="50pt"/>
				<fo:table-column column-width="100pt"/>
				<fo:table-column column-width="150pt"/>
				<fo:table-column/>
				<fo:table-body>
					<fo:table-row>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Version</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Author</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Date</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Detail</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<xsl:for-each select="/n1:Project/n1:Metadata/n1:DocumentInformation/n1:ReviewHistories/n1:ReviewHistory">
						<fo:table-row>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@version"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Author"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Date"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Detail"/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
					</xsl:for-each>
				</fo:table-body>
			</fo:table>
			<!-- /Documents Information - Revision History Section Definition -->
			<!-- Documents Information - Related Documents Section Definition -->
			<fo:block color="#000000" font-size="13pt" font-weight="bold" space-before="20pt">
				<xsl:attribute name="id">RelatedDocuments</xsl:attribute> 0.3 Related documents
      </fo:block>
			<fo:table border-style="solid" border-width="1pt" space-before="20pt" table-layout="fixed" width="100%">
				<fo:table-column column-width="50pt"/>
				<fo:table-column column-width="100pt"/>
				<fo:table-column column-width="150pt"/>
				<fo:table-column/>
				<fo:table-body>
					<fo:table-row>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Version</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Author</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Date</fo:block>
						</fo:table-cell>
						<fo:table-cell background-color="#E0E0E0" border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
							<fo:block>Detail</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<xsl:for-each select="/n1:Project/n1:Metadata/n1:DocumentInformation/n1:RelatedDocuments/n1:RelatedDocument">
						<fo:table-row>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@version"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Author"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Date"/>
								</fo:block>
							</fo:table-cell>
							<fo:table-cell border-style="solid" border-width="1pt" display-align="center" padding="4pt" text-align="start">
								<fo:block>
									<xsl:value-of select="@Detail"/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
					</xsl:for-each>
				</fo:table-body>
			</fo:table>
		</fo:block>
	</xsl:template>
	<!-- /Documents Information - Related Documents Section Definition -->
	<!-- Document Information Page Definition -->
	<!-- Bold Style Definition -->
	<xsl:template match="b">
		<fo:inline font-weight="bold">
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
	<!-- /Bold Style Definition -->
	<!-- Newline Style Definition -->
	<xsl:template match="n1:newline">
		<fo:block>
			<fo:leader leader-pattern="space"/>
		</fo:block>
	</xsl:template>
	<!-- /Newline Style Definition -->
	<!-- List Style Definition -->
	<xsl:template match="n1:ul">
		<fo:block>
			<fo:list-block>
				<xsl:apply-templates/>
			</fo:list-block>
		</fo:block>
	</xsl:template>
	<xsl:template match="n1:li">
		<fo:list-item>
			<fo:list-item-label end-indent="label-end()" margin-left="10pt">
				<fo:block> - </fo:block>
			</fo:list-item-label>
			<fo:list-item-body start-indent="body-start()">
				<fo:block>
					<xsl:apply-templates/>
				</fo:block>
			</fo:list-item-body>
		</fo:list-item>
	</xsl:template>
	<!-- /List Style Definition -->
	<!-- TSA Brief Style Definition-->
	<xsl:template name="proFormaPage">
		<fo:block color="#000000" font-size="16pt" font-weight="bold" font-family="Times">
			<xsl:attribute name="id">proFormaPage</xsl:attribute>
			1. TSA Request Pro Forma
		</fo:block>
		<fo:block margin-left="0pt">
			<fo:instream-foreign-object>
				<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="497" height="2">
					<svg:line x1="0" y1="0" x2="497" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/>
				</svg:svg>
			</fo:instream-foreign-object>
		</fo:block>
		<fo:block font-family="Times">
			<fo:table border-color="black" border-style="solid" border-width="1px" padding="0" space-after.optimum="2pt" space-before.optimum="2pt" table-layout="fixed" width="100%">
				<fo:table-column column-width="120pt"/>
				<fo:table-column/>
				<fo:table-column/>
				<fo:table-column/>
				<fo:table-body>
					<!-- project number -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">TSA project number:</fo:block>
						</fo:table-cell>
						<fo:table-cell number-columns-spanned="3" border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:project_number"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- project name -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Project Name:</fo:block>
						</fo:table-cell>
						<fo:table-cell number-columns-spanned="3" border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:project_name"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- target description -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Project description:</fo:block>
						</fo:table-cell>
						<fo:table-cell number-columns-spanned="3" border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:project_description"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- target status -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Status of target:</fo:block>
						</fo:table-cell>
						<fo:table-cell number-columns-spanned="3" border-style="solid" padding="2pt" border-width="1px">
							<fo:block>Test systems will be in a UAT environment</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- requestor -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Requestor:</fo:block>
						</fo:table-cell>
						<fo:table-cell number-columns-spanned="3" border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:project_owner/n1:Contact/@givenNames"/>&#160;<xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:project_owner/n1:Contact/@surname"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- source IP -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">TSA source IP:</fo:block>
						</fo:table-cell>
						<fo:table-cell number-columns-spanned="3" border-style="solid" padding="2pt" border-width="1px">
							<fo:block>194.203.201.168</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- scheduled hours -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Testing timeframe:</fo:block>
						</fo:table-cell>
						<fo:table-cell number-columns-spanned="3" border-style="solid" padding="2pt" border-width="1px">
							<fo:block>0800 - 1700 GMT</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- scheduled dates -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Projected start date:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:choose>
									<xsl:when test="substring(/n1:Project/n1:Metadata/n1:dates/n1:start_date, 0, 5) >= '2005'">
										<xsl:value-of select="/n1:Project/n1:Metadata/n1:dates/n1:start_date"/>
									</xsl:when>
									<xsl:otherwise>
									TBC
								</xsl:otherwise>
								</xsl:choose>
							</fo:block>
						</fo:table-cell>
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Projected end date:</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:choose>
									<xsl:when test="substring(/n1:Project/n1:Metadata/n1:dates/n1:due_date, 0, 5) >= '2005'">
										<xsl:value-of select="/n1:Project/n1:Metadata/n1:dates/n1:due_date"/>
									</xsl:when>
									<xsl:otherwise>
									TBC
								</xsl:otherwise>
								</xsl:choose>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					<!-- contacts -->
					<fo:table-row text-align="left">
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Primary contact (with after hours contact details):</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:choose>
									<xsl:when test="count(/n1:Project/n1:Metadata/n1:contacts/n1:primary_contact) > 0">
										<xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:primary_contact/n1:Contact/@givenNames"/>&#160;<xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:primary_contact/n1:Contact/@surname"/>
										<fo:block>
											Mobile: <xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:primary_contact/n1:Contact/@mobile"/>
										</fo:block>
										<fo:block>
											Tel: <xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:primary_contact/n1:Contact/@telephone"/>
										</fo:block>
									</xsl:when>
									<xsl:otherwise>
									TBC
								</xsl:otherwise>
								</xsl:choose>
							</fo:block>
						</fo:table-cell>
						<fo:table-cell padding="2pt" text-align="left" background-color="#E0E0E0" border-style="solid" border-width="1px">
							<fo:block font-weight="bold">Secondary contact (with after hours contact details):</fo:block>
						</fo:table-cell>
						<fo:table-cell border-style="solid" padding="2pt" border-width="1px">
							<fo:block>
								<xsl:choose>
									<xsl:when test="count(/n1:Project/n1:Metadata/n1:contacts/n1:secondary_contact) > 0">
										<xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:secondary_contact/n1:Contact/@givenNames"/>&#160;<xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:secondary_contact/n1:Contact/@surname"/>
										<fo:block>
											Mobile: <xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:secondary_contact/n1:Contact/@mobile"/>
										</fo:block>
										<fo:block>
											Tel: <xsl:value-of select="/n1:Project/n1:Metadata/n1:contacts/n1:secondary_contact/n1:Contact/@telephone"/>
										</fo:block>
									</xsl:when>
									<xsl:otherwise>
								TBC
								</xsl:otherwise>
								</xsl:choose>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
				</fo:table-body>
			</fo:table>
		</fo:block>
	</xsl:template>
	<xsl:template name="agreedScope">
		<fo:block font-family="Times">
			<xsl:attribute name="id">agreedProjectScope</xsl:attribute>
			<fo:block color="#000000" font-size="16pt" font-weight="bold"> 2. Agreed Project Scope</fo:block>
			<fo:block margin-left="0pt">
				<fo:instream-foreign-object>
					<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="750" height="2">
						<svg:line x1="0" y1="0" x2="750" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/>
					</svg:svg>
				</fo:instream-foreign-object>
			</fo:block>
			<fo:block>As defined in the GSS PenTesting Process (based on the “ABN AMRO - Common Technical Security Assessment Process v2.0.pdf” standard), the following defines the project’s scope. The following list is the resources made available to the TSA team.</fo:block>
			<fo:block space-before="20pt">
				<fo:external-graphic>
					<xsl:attribute name="src">url('<xsl:text disable-output-escaping="yes">U:\_images\FullTSAAgreedScope.jpg</xsl:text>')</xsl:attribute>
				</fo:external-graphic>
			</fo:block>
		</fo:block>
	</xsl:template>
	<xsl:template name="TSABrief">
		<fo:block break-before="page"/>
		<fo:block font-family="Times">
			<xsl:attribute name="id">projectBrief</xsl:attribute>
			<fo:block color="#000000" font-size="16pt" font-weight="bold"> 3. TSA Brief</fo:block>
			<fo:block margin-left="0pt">
				<fo:instream-foreign-object>
					<svg:svg xmlns:svg="http://www.w3.org/2000/svg" width="750" height="2">
						<svg:line x1="0" y1="0" x2="750" y2="0" style="stroke:rgb(00,00,00);stroke-width:2"/>
					</svg:svg>
				</fo:instream-foreign-object>
			</fo:block>
			<fo:block>As defined in Section 2 of this document, the TSA brief is the following:</fo:block>
			<fo:list-block provisional-distance-between-starts=".43in" provisional-label-separation=".1in">
				<fo:list-item space-before="15pt">
					<fo:list-item-label end-indent="label-end()" text-align="end">
						<fo:block>1)</fo:block>
					</fo:list-item-label>
					<fo:list-item-body start-indent="body-start()">
						<fo:block>
							Perform the following tests during normal business hours (GMT) during the period of
							
							<xsl:choose>
								<xsl:when test="substring(/n1:Project/n1:Metadata/n1:dates/n1:start_date, 0, 5) >= '2005'">
									<xsl:value-of select="/n1:Project/n1:Metadata/n1:dates/n1:start_date"/>
								</xsl:when>
								<xsl:otherwise>
									TBC
								</xsl:otherwise>
							</xsl:choose>
							to 
							<xsl:choose>
								<xsl:when test="substring(/n1:Project/n1:Metadata/n1:dates/n1:due_date, 0, 5) >= '2005'">
									<xsl:value-of select="/n1:Project/n1:Metadata/n1:dates/n1:due_date"/>.
								</xsl:when>
								<xsl:otherwise>
									TBC.
								</xsl:otherwise>
							</xsl:choose>
						</fo:block>
						<fo:block space-before="10pt">
							<fo:external-graphic>
								<xsl:attribute name="src">url('<xsl:text disable-output-escaping="yes">U:\_images\FullTSABrief.jpg</xsl:text>')</xsl:attribute>
							</fo:external-graphic>
						</fo:block>
					</fo:list-item-body>
				</fo:list-item>
				<fo:list-item space-before="15pt">
					<fo:list-item-label end-indent="label-end()" text-align="end">
						<fo:block>2)</fo:block>
					</fo:list-item-label>
					<fo:list-item-body start-indent="body-start()">
						<fo:block>In the scenario where access to a key resource (e.g. ‘administrative access to a server’) via a successful exploitation of vulnerability, is obtained, within the time-constraints allocated, perform the security tests planned for that type of test.</fo:block>
					</fo:list-item-body>
				</fo:list-item>
				<fo:list-item space-before="10pt">
					<fo:list-item-label end-indent="label-end()" text-align="end">
						<fo:block>3)</fo:block>
					</fo:list-item-label>
					<fo:list-item-body start-indent="body-start()">
						<fo:block>The Target networks are:</fo:block>
						<fo:list-block provisional-distance-between-starts=".43in" provisional-label-separation=".1in">
							<xsl:for-each select="/n1:Project/n1:Targets/n1:TargetSubnets/n1:SubNet">
								<fo:list-item space-before="10pt">
									<fo:list-item-label end-indent="label-end()" text-align="end">
										<fo:block><xsl:value-of select="position()"/>)</fo:block>
									</fo:list-item-label>
									<fo:list-item-body start-indent="body-start()">
										<fo:block>
											<xsl:value-of select="."/>
										</fo:block>
									</fo:list-item-body>
								</fo:list-item>
							</xsl:for-each>
						</fo:list-block>
					</fo:list-item-body>
				</fo:list-item>
			</fo:list-block>
		</fo:block>
	</xsl:template>
</xsl:stylesheet>
