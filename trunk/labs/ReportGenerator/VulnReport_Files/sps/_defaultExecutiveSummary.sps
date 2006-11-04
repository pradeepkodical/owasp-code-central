<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="C:\_ABN\Owasp - VulnReport\V-Drive\Application (exe)\v0.75\VulnReport_Files\xsd\projectXsd.xsd" workingxmlfile="C:\_ABN\Owasp - VulnReport\U-Drive\AAAA_dinis Test\AAAA_dinis Test.xml" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="xs" uri="http://www.w3.org/2001/XMLSchema"/>
	<nspair prefix="n1" uri="vuln_report"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<template>
				<match match="n1:Project"/>
				<children>
					<template>
						<match match="n1:ExecutiveSummary"/>
						<children>
							<newline/>
							<table>
								<properties border="0" width="100%"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecol>
														<properties width="122"/>
														<children>
															<text fixtext="Document Title">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<children>
															<template>
																<match match="n1:title"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Verdana" font-size="smaller"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecol>
														<properties width="122"/>
														<children>
															<text fixtext="Document Subtitle">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<children>
															<template>
																<match match="n1:subtitle"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Verdana" font-size="smaller"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
												</children>
											</tablerow>
										</children>
									</tablebody>
								</children>
							</table>
							<newline/>
							<table>
								<properties border="0" width="100%"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecol>
														<children>
															<template>
																<match match="n1:level1"/>
																<children>
																	<table>
																		<properties border="0" width="100%"/>
																		<children>
																			<tablebody>
																				<children>
																					<tablerow>
																						<children>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<children>
																									<template>
																										<match match="@name"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="larger" font-weight="bold"/>
																											</xpath>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																						</children>
																					</tablerow>
																				</children>
																			</tablebody>
																		</children>
																	</table>
																	<template>
																		<match match="n1:level2"/>
																		<children>
																			<newline/>
																			<table>
																				<properties border="0" width="100%"/>
																				<children>
																					<tablebody>
																						<children>
																							<tablerow>
																								<children>
																									<tablecol>
																										<styles background-color="#E4E4E4"/>
																										<children>
																											<template>
																												<match match="@name"/>
																												<children>
																													<xpath allchildren="1">
																														<styles font-family="Verdana" font-size="small" font-weight="bold"/>
																													</xpath>
																												</children>
																											</template>
																											<newline/>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="smaller"/>
																											</xpath>
																											<newline/>
																										</children>
																									</tablecol>
																								</children>
																							</tablerow>
																						</children>
																					</tablebody>
																				</children>
																			</table>
																		</children>
																	</template>
																	<newline/>
																</children>
															</template>
														</children>
													</tablecol>
												</children>
											</tablerow>
										</children>
									</tablebody>
								</children>
							</table>
						</children>
					</template>
				</children>
			</template>
			<newline/>
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:ExecutiveSummary"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:newline"/>
		<children>
			<xpath allchildren="1"/>
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:rating"/>
		<children>
			<newline/>
			<newline/>
			<table>
				<properties border="1" border-collapse="collapse" cellpadding="0" cellspacing="0" width="100%"/>
				<children>
					<tablebody>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties width="207"/>
										<children>
											<template>
												<match match="n1:ratingValue"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties width="437"/>
										<children>
											<template>
												<match match="n1:ratingComment"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="smaller"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
								</children>
							</tablerow>
						</children>
					</tablebody>
				</children>
			</table>
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:ul"/>
		<children>
			<newline/>
			<template>
				<match match="n1:li"/>
				<children>
					<list dynamic="1">
						<styles margin-bottom="0" margin-top="0"/>
						<properties start="1" type="disc"/>
						<children>
							<listrow>
								<children>
									<xpath allchildren="1">
										<styles font-family="Verdana" font-size="x-small"/>
									</xpath>
								</children>
							</listrow>
						</children>
					</list>
				</children>
			</template>
			<newline/>
		</children>
	</template>
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
