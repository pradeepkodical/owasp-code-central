<?xml version="1.0" encoding="UTF-8"?>
<structure version="4" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="vuln_report"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="../xsd/projectXsd.xsd">
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
							<template match="n1:Project">
								<editorproperties elementstodisplay="1"/>
								<properties/>
								<styles/>
								<children>
									<template match="n1:ExecutiveSummary">
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
												<properties border="0" width="100%"/>
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
																		<properties width="122"/>
																		<styles/>
																		<children>
																			<text fixtext="Document Title">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties/>
																		<styles background-color="#E4E4E4"/>
																		<children>
																			<template match="n1:title">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Verdana" font-size="smaller"/>
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
																		<properties width="122"/>
																		<styles/>
																		<children>
																			<text fixtext="Document Subtitle">
																				<editorproperties/>
																				<properties/>
																				<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																				<children/>
																			</text>
																		</children>
																	</tablecell>
																	<tablecell>
																		<editorproperties/>
																		<properties/>
																		<styles background-color="#E4E4E4"/>
																		<children>
																			<template match="n1:subtitle">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<content>
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Verdana" font-size="smaller"/>
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
											<newline>
												<editorproperties/>
												<properties/>
												<styles/>
												<children/>
											</newline>
											<table>
												<editorproperties/>
												<properties border="0" width="100%"/>
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
																			<template match="n1:level1">
																				<editorproperties elementstodisplay="1"/>
																				<properties/>
																				<styles/>
																				<children>
																					<table>
																						<editorproperties/>
																						<properties border="0" width="100%"/>
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
																												<styles background-color="#E4E4E4"/>
																												<children>
																													<template match="@name">
																														<editorproperties elementstodisplay="1"/>
																														<properties/>
																														<styles/>
																														<children>
																															<content>
																																<editorproperties/>
																																<properties/>
																																<styles font-family="Verdana" font-size="larger" font-weight="bold"/>
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
																					<template match="n1:level2">
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
																								<properties border="0" width="100%"/>
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
																														<styles background-color="#E4E4E4"/>
																														<children>
																															<template match="@name">
																																<editorproperties elementstodisplay="1"/>
																																<properties/>
																																<styles/>
																																<children>
																																	<content>
																																		<editorproperties/>
																																		<properties/>
																																		<styles font-family="Verdana" font-size="small" font-weight="bold"/>
																																		<children/>
																																		<addvalidations/>
																																		<format datatype="string"/>
																																	</content>
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
																															<content>
																																<editorproperties/>
																																<properties/>
																																<styles font-family="Verdana" font-size="smaller"/>
																																<children/>
																																<addvalidations/>
																																<format/>
																															</content>
																															<newline>
																																<editorproperties/>
																																<properties/>
																																<styles/>
																																<children/>
																															</newline>
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
			<globaltemplate match="n1:ExecutiveSummary">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:ExecutiveSummary">
						<editorproperties elementstodisplay="1"/>
						<properties/>
						<styles/>
						<children>
							<content>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
								<addvalidations/>
								<format/>
							</content>
						</children>
						<addvalidations/>
						<sort/>
					</template>
				</children>
			</globaltemplate>
			<globaltemplate match="n1:b">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:b">
						<editorproperties elementstodisplay="1"/>
						<properties/>
						<styles/>
						<children>
							<content>
								<editorproperties/>
								<properties/>
								<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
								<children/>
								<addvalidations/>
								<format datatype="anyType"/>
							</content>
						</children>
						<addvalidations/>
						<sort/>
					</template>
				</children>
			</globaltemplate>
			<globaltemplate match="n1:level3">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:level3">
						<editorproperties elementstodisplay="1"/>
						<properties/>
						<styles/>
						<children>
							<table>
								<editorproperties/>
								<properties border="0" cellpadding="10" cellspacing="0" width="100%"/>
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
															<table>
																<editorproperties/>
																<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
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
																						<styles background-color="#F0F0F0"/>
																						<children>
																							<template match="@name">
																								<editorproperties elementstodisplay="1"/>
																								<properties/>
																								<styles/>
																								<children>
																									<content>
																										<editorproperties/>
																										<properties/>
																										<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
																										<children/>
																										<addvalidations/>
																										<format datatype="string"/>
																									</content>
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
																							<content>
																								<editorproperties/>
																								<properties/>
																								<styles font-family="Verdana" font-size="xx-small"/>
																								<children/>
																								<addvalidations/>
																								<format/>
																							</content>
																							<newline>
																								<editorproperties/>
																								<properties/>
																								<styles/>
																								<children/>
																							</newline>
																						</children>
																					</tablecell>
																				</children>
																			</tablerow>
																		</children>
																	</tablebody>
																</children>
															</table>
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
			</globaltemplate>
			<globaltemplate match="n1:newline">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:newline">
						<editorproperties elementstodisplay="1"/>
						<properties/>
						<styles/>
						<children>
							<content>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
								<addvalidations/>
								<format datatype="anyType"/>
							</content>
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
			<globaltemplate match="n1:rating">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:rating">
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
							<newline>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</newline>
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
														<properties width="207"/>
														<styles background-color="#E4E4E4"/>
														<children>
															<template match="n1:ratingValue">
																<editorproperties elementstodisplay="1"/>
																<properties/>
																<styles/>
																<children>
																	<content>
																		<editorproperties/>
																		<properties/>
																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
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
														<properties width="437"/>
														<styles background-color="#E4E4E4"/>
														<children>
															<template match="n1:ratingComment">
																<editorproperties elementstodisplay="1"/>
																<properties/>
																<styles/>
																<children>
																	<content>
																		<editorproperties/>
																		<properties/>
																		<styles font-family="Verdana" font-size="smaller"/>
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
			<globaltemplate match="n1:table_with_3_columns">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:table_with_3_columns">
						<editorproperties elementstodisplay="1"/>
						<properties/>
						<styles/>
						<children>
							<text fixtext="asdasd">
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</text>
						</children>
						<addvalidations/>
						<sort/>
					</template>
				</children>
			</globaltemplate>
			<globaltemplate match="n1:ul">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:ul">
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
							<list>
								<editorproperties/>
								<properties/>
								<styles/>
								<children>
									<template match="n1:li">
										<editorproperties elementstodisplay="1"/>
										<properties/>
										<styles/>
										<children>
											<listrow>
												<editorproperties/>
												<properties/>
												<styles/>
												<children>
													<content>
														<editorproperties/>
														<properties/>
														<styles/>
														<children/>
														<addvalidations/>
														<format datatype="string"/>
													</content>
												</children>
											</listrow>
										</children>
										<addvalidations/>
										<sort/>
									</template>
								</children>
							</list>
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
