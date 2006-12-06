<?xml version="1.0" encoding="UTF-8"?>
<structure version="4" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<schemasources>
		<namespaces>
			<nspair prefix="ipo" uri="http://www.altova.com/IPO"/>
			<nspair prefix="n1" uri="http://www.xmlspy.com/schemas/orgchart"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="Vulnerabilities.xsd">
				<xmltablesupport/>
				<textstateicons/>
			</xsdschemasource>
		</schemasources>
	</schemasources>
	<parameters/>
	<scripts>
		<javascript name="javascript"/>
	</scripts>
	<globalstyles/>
	<parts>
		<editorproperties/>
		<properties/>
		<styles/>
		<children>
			<globaltemplate match="/">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="$XML">
						<editorproperties elementstodisplay="1"/>
						<properties/>
						<styles/>
						<children>
							<template match="n1:SiteGenerator_Vulnerabilites">
								<editorproperties elementstodisplay="1"/>
								<properties/>
								<styles/>
								<children>
									<text fixtext="SiteGenerator Vulnerabilities (in this page)">
										<editorproperties/>
										<properties/>
										<styles font-family="Arial" font-size="large" font-weight="bold"/>
										<children/>
									</text>
									<newline>
										<editorproperties/>
										<properties/>
										<styles/>
										<children/>
									</newline>
									<newline>
										<editorproperties/>
										<properties/>
										<styles/>
										<children/>
									</newline>
									<table>
										<editorproperties/>
										<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0"/>
										<styles/>
										<children>
											<tablebody>
												<editorproperties/>
												<properties/>
												<styles/>
												<children>
													<tablerow>
														<editorproperties/>
														<properties/>
														<styles/>
														<children>
															<tablecell>
																<editorproperties/>
																<properties width="108"/>
																<styles/>
																<children>
																	<text fixtext="page comment">
																		<editorproperties/>
																		<properties/>
																		<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
																		<children/>
																	</text>
																	<text fixtext=":">
																		<editorproperties/>
																		<properties/>
																		<styles font-family="Arial" font-size="smaller"/>
																		<children/>
																	</text>
																</children>
															</tablecell>
															<tablecell>
																<editorproperties/>
																<properties bgcolor="#D2D8E6" width="462"/>
																<styles/>
																<children>
																	<template match="n1:pageComment">
																		<editorproperties elementstodisplay="1"/>
																		<properties/>
																		<styles/>
																		<children>
																			<content>
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="smaller"/>
																				<children/>
																				<addvalidations/>
																				<format datatype="anyType"/>
																			</content>
																		</children>
																		<addvalidations/>
																		<sort/>
																	</template>
																</children>
															</tablecell>
														</children>
													</tablerow>
												</children>
											</tablebody>
										</children>
									</table>
									<newline>
										<editorproperties/>
										<properties/>
										<styles/>
										<children/>
									</newline>
									<template match="n1:vulnerability">
										<editorproperties elementstodisplay="1"/>
										<properties/>
										<styles/>
										<children>
											<newline>
												<editorproperties/>
												<properties/>
												<styles/>
												<children/>
											</newline>
											<table>
												<editorproperties/>
												<properties border="0"/>
												<styles/>
												<children>
													<tablebody>
														<editorproperties/>
														<properties/>
														<styles/>
														<children>
															<tablerow>
																<editorproperties/>
																<properties/>
																<styles/>
																<children>
																	<tablecell>
																		<editorproperties/>
																		<properties height="22" width="77"/>
																		<styles/>
																		<children>
																			<text fixtext="Category:">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="small" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties colspan="2" height="22" width="313"/>
																		<styles background-color="#D2D8E6"/>
																		<children>
																			<template match="@category">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Arial" font-size="small" font-weight="bold"/>
																						<children/>
																						<addvalidations/>
																						<format datatype="string"/>
																					</content>
																				</children>
																				<addvalidations/>
																				<sort/>
																			</template>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties height="22" width="56"/>
																		<styles/>
																		<children>
																			<text fixtext="Type:">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="small" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties height="22" width="220"/>
																		<styles background-color="#D2D8E6"/>
																		<children>
																			<template match="@type">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Arial" font-size="small" font-weight="bold"/>
																						<children/>
																						<addvalidations/>
																						<format datatype="string"/>
																					</content>
																				</children>
																				<addvalidations/>
																				<sort/>
																			</template>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties height="22" width="56"/>
																		<styles/>
																		<children>
																			<text fixtext="Mode:">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="small" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties height="22" width="205"/>
																		<styles background-color="#D2D8E6"/>
																		<children>
																			<template match="@mode">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Arial" font-size="small" font-weight="bold"/>
																						<children/>
																						<addvalidations/>
																						<format datatype="string"/>
																					</content>
																				</children>
																				<addvalidations/>
																				<sort/>
																			</template>
																		</children>
																	</tablecell>
																</children>
															</tablerow>
															<tablerow>
																<editorproperties/>
																<properties/>
																<styles/>
																<children>
																	<tablecell>
																		<editorproperties/>
																		<properties width="77"/>
																		<styles/>
																		<children>
																			<text fixtext="Comment">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties colspan="6" width="204"/>
																		<styles background-color="#D2D8E6"/>
																		<children/>
																	</tablecell>
																</children>
															</tablerow>
															<tablerow>
																<editorproperties/>
																<properties/>
																<styles/>
																<children>
																	<tablecell>
																		<editorproperties/>
																		<properties width="77"/>
																		<styles/>
																		<children>
																			<text fixtext="Dread">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties colspan="6"/>
																		<styles/>
																		<children>
																			<template match="n1:dread">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<table>
																						<editorproperties/>
																						<properties border="1" border-collapse="collapse" cellpadding="0" cellspacing="0" width="100%"/>
																						<styles/>
																						<children>
																							<tablebody>
																								<editorproperties/>
																								<properties/>
																								<styles/>
																								<children>
																									<tablerow>
																										<editorproperties/>
																										<properties/>
																										<styles/>
																										<children>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<text fixtext="D:">
																														<editorproperties/>
																														<properties/>
																														<styles font-family="Arial" font-size="smaller"/>
																														<children/>
																													</text>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<template match="@damage">
																														<editorproperties elementstodisplay="1"/>
																														<properties/>
																														<styles/>
																														<children>
																															<content>
																																<editorproperties/>
																																<properties/>
																																<styles font-family="Arial" font-size="smaller"/>
																																<children/>
																																<addvalidations/>
																																<format datatype="string"/>
																															</content>
																														</children>
																														<addvalidations/>
																														<sort/>
																													</template>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<text fixtext="R">
																														<editorproperties/>
																														<properties/>
																														<styles font-family="Arial" font-size="smaller"/>
																														<children/>
																													</text>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<template match="@reproducibility">
																														<editorproperties elementstodisplay="1"/>
																														<properties/>
																														<styles/>
																														<children>
																															<content>
																																<editorproperties/>
																																<properties/>
																																<styles font-family="Arial" font-size="smaller"/>
																																<children/>
																																<addvalidations/>
																																<format datatype="string"/>
																															</content>
																														</children>
																														<addvalidations/>
																														<sort/>
																													</template>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<text fixtext="E">
																														<editorproperties/>
																														<properties/>
																														<styles font-family="Arial" font-size="smaller"/>
																														<children/>
																													</text>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<template match="@exploitability">
																														<editorproperties elementstodisplay="1"/>
																														<properties/>
																														<styles/>
																														<children>
																															<content>
																																<editorproperties/>
																																<properties/>
																																<styles font-family="Arial" font-size="smaller"/>
																																<children/>
																																<addvalidations/>
																																<format datatype="string"/>
																															</content>
																														</children>
																														<addvalidations/>
																														<sort/>
																													</template>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<text fixtext="A">
																														<editorproperties/>
																														<properties/>
																														<styles font-family="Arial" font-size="smaller"/>
																														<children/>
																													</text>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<template match="@affectedUsers">
																														<editorproperties elementstodisplay="1"/>
																														<properties/>
																														<styles/>
																														<children>
																															<content>
																																<editorproperties/>
																																<properties/>
																																<styles font-family="Arial" font-size="smaller"/>
																																<children/>
																																<addvalidations/>
																																<format datatype="string"/>
																															</content>
																														</children>
																														<addvalidations/>
																														<sort/>
																													</template>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties/>
																												<styles/>
																												<children>
																													<text fixtext="D">
																														<editorproperties/>
																														<properties/>
																														<styles font-family="Arial" font-size="smaller"/>
																														<children/>
																													</text>
																												</children>
																											</tablecell>
																											<tablecell>
																												<editorproperties/>
																												<properties width="123"/>
																												<styles/>
																												<children>
																													<template match="@discoverability">
																														<editorproperties elementstodisplay="1"/>
																														<properties/>
																														<styles/>
																														<children>
																															<content>
																																<editorproperties/>
																																<properties/>
																																<styles font-family="Arial" font-size="smaller"/>
																																<children/>
																																<addvalidations/>
																																<format datatype="string"/>
																															</content>
																														</children>
																														<addvalidations/>
																														<sort/>
																													</template>
																												</children>
																											</tablecell>
																										</children>
																									</tablerow>
																								</children>
																							</tablebody>
																						</children>
																					</table>
																				</children>
																				<addvalidations/>
																				<sort/>
																			</template>
																		</children>
																	</tablecell>
																</children>
															</tablerow>
															<tablerow>
																<editorproperties/>
																<properties/>
																<styles/>
																<children>
																	<tablecell>
																		<editorproperties/>
																		<properties width="77"/>
																		<styles/>
																		<children>
																			<text fixtext="Risk">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties width="125"/>
																		<styles background-color="#D2D8E6"/>
																		<children>
																			<template match="n1:risk">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Arial" font-size="smaller"/>
																						<children/>
																						<addvalidations/>
																						<format datatype="anyType"/>
																					</content>
																				</children>
																				<addvalidations/>
																				<sort/>
																			</template>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties width="45"/>
																		<styles/>
																		<children/>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties width="56"/>
																		<styles/>
																		<children/>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties/>
																		<styles/>
																		<children/>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties width="56"/>
																		<styles/>
																		<children/>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties/>
																		<styles/>
																		<children/>
																	</tablecell>
																</children>
															</tablerow>
															<tablerow>
																<editorproperties/>
																<properties/>
																<styles/>
																<children>
																	<tablecell>
																		<editorproperties/>
																		<properties width="77"/>
																		<styles/>
																		<children>
																			<text fixtext="Exploit description">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties colspan="6"/>
																		<styles background-color="#D2D8E6"/>
																		<children>
																			<template match="n1:exploitDescription">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Arial" font-size="smaller"/>
																						<children/>
																						<addvalidations/>
																						<format datatype="anyType"/>
																					</content>
																				</children>
																				<addvalidations/>
																				<sort/>
																			</template>
																		</children>
																	</tablecell>
																</children>
															</tablerow>
															<tablerow>
																<editorproperties/>
																<properties/>
																<styles/>
																<children>
																	<tablecell>
																		<editorproperties/>
																		<properties width="77"/>
																		<styles/>
																		<children>
																			<text fixtext="Remediation:">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties colspan="6"/>
																		<styles background-color="#D2D8E6"/>
																		<children>
																			<template match="n1:remediation">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Arial" font-size="smaller"/>
																						<children/>
																						<addvalidations/>
																						<format datatype="anyType"/>
																					</content>
																				</children>
																				<addvalidations/>
																				<sort/>
																			</template>
																		</children>
																	</tablecell>
																</children>
															</tablerow>
														</children>
													</tablebody>
												</children>
											</table>
										</children>
										<addvalidations/>
										<sort/>
									</template>
									<newline>
										<editorproperties/>
										<properties/>
										<styles/>
										<children/>
									</newline>
								</children>
								<addvalidations/>
								<sort/>
							</template>
							<newline>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</newline>
							<newline>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</newline>
						</children>
						<addvalidations/>
						<sort/>
					</template>
				</children>
			</globaltemplate>
		</children>
	</parts>
	<pagelayout>
		<editorproperties/>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
		<styles/>
		<children/>
	</pagelayout>
</structure>
