<?xml version="1.0" encoding="UTF-8"?>
<structure version="4" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="vuln_report"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="../xsd/projectXsd.xsd" workingxmlfile="">
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
									<template match="n1:Targets">
										<editorproperties elementstodisplay="1"/>
										<properties/>
										<styles/>
										<children>
											<template match="n1:Target">
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
																				<properties colspan="4"/>
																				<styles/>
																				<children>
																					<template match="n1:Findings">
																						<editorproperties elementstodisplay="1"/>
																						<properties/>
																						<styles/>
																						<children>
																							<template match="n1:Finding">
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
																																<properties colspan="5" width="716"/>
																																<styles/>
																																<children>
																																	<template match="@Vulnerability">
																																		<editorproperties editable="0" markupmode="hide" adding="mandatory" autoaddname="0"/>
																																		<properties/>
																																		<styles/>
																																		<children>
																																			<content>
																																				<editorproperties/>
																																				<properties/>
																																				<styles font-family="Verdana" font-size="medium" font-weight="bold"/>
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
																									<table>
																										<editorproperties/>
																										<properties border="0" cellpadding="2" cellspacing="5" width="100%"/>
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
																																<properties valign="top" width="139"/>
																																<styles/>
																																<children>
																																	<text fixtext="Vulnerability">
																																		<editorproperties/>
																																		<properties/>
																																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																																		<children/>
																																	</text>
																																</children>
																															</tablecell>
																															<tablecell>
																																<editorproperties/>
																																<properties colspan="3"/>
																																<styles background-color="#E4E4E4"/>
																																<children>
																																	<template match="@Vulnerability">
																																		<editorproperties editable="1" markupmode="hide" adding="all" autoaddname="1"/>
																																		<properties/>
																																		<styles/>
																																		<children>
																																			<content>
																																				<editorproperties/>
																																				<properties/>
																																				<styles font-family="Verdana" font-size="x-small"/>
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
																																<properties height="27" valign="top" width="139"/>
																																<styles/>
																																<children>
																																	<text fixtext="Affected Items">
																																		<editorproperties/>
																																		<properties/>
																																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																																		<children/>
																																	</text>
																																</children>
																															</tablecell>
																															<tablecell>
																																<editorproperties/>
																																<properties colspan="3" height="27" valign="top"/>
																																<styles background-color="#E4E4E4"/>
																																<children>
																																	<list>
																																		<editorproperties/>
																																		<properties/>
																																		<styles/>
																																		<children>
																																			<template match="n1:AffectedItems">
																																				<editorproperties editable="1" adding="all" autoaddname="1" elementstodisplay="1"/>
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
																																								<format/>
																																							</content>
																																						</children>
																																					</listrow>
																																				</children>
																																				<addvalidations/>
																																				<sort/>
																																			</template>
																																		</children>
																																	</list>
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
																													<tablerow>
																														<editorproperties/>
																														<properties/>
																														<styles/>
																														<children>
																															<tablecell>
																																<editorproperties/>
																																<properties height="54" valign="top" width="139"/>
																																<styles/>
																																<children>
																																	<text fixtext="Additional Details ">
																																		<editorproperties/>
																																		<properties/>
																																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																																		<children/>
																																	</text>
																																	<newline>
																																		<editorproperties/>
																																		<properties/>
																																		<styles/>
																																		<children/>
																																	</newline>
																																	<text fixtext="(you can paste ">
																																		<editorproperties/>
																																		<properties/>
																																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																																		<children/>
																																	</text>
																																	<newline>
																																		<editorproperties/>
																																		<properties/>
																																		<styles/>
																																		<children/>
																																	</newline>
																																	<text fixtext="images here)">
																																		<editorproperties/>
																																		<properties/>
																																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																																		<children/>
																																	</text>
																																</children>
																															</tablecell>
																															<tablecell>
																																<editorproperties/>
																																<properties colspan="3" height="54" valign="top"/>
																																<styles background-color="#E4E4E4"/>
																																<children>
																																	<template match="n1:AdittionalDetails">
																																		<editorproperties elementstodisplay="1"/>
																																		<properties/>
																																		<styles/>
																																		<children>
																																			<content>
																																				<editorproperties/>
																																				<properties/>
																																				<styles font-family="Verdana" font-size="x-small"/>
																																				<children/>
																																				<addvalidations/>
																																				<format/>
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
			</globaltemplate>
			<globaltemplate match="n1:img">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:img">
						<editorproperties editable="1" markupmode="hide" adding="all" autoaddname="1"/>
						<properties/>
						<styles/>
						<children>
							<newline>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</newline>
							<image>
								<editorproperties/>
								<properties border="0"/>
								<styles/>
								<children/>
								<target>
									<xpath value="resolve-uri(@src, static-base-uri())"/>
								</target>
								<imagesource>
									<xpath value="resolve-uri(@src, static-base-uri())"/>
								</imagesource>
							</image>
							<newline>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</newline>
							<text fixtext="[">
								<editorproperties/>
								<properties/>
								<styles font-family="verdana" font-size="9"/>
								<children/>
							</text>
							<template match="@src">
								<editorproperties editable="1" markupmode="hide" adding="all" autoaddname="1"/>
								<properties/>
								<styles/>
								<children>
									<content>
										<editorproperties/>
										<properties/>
										<styles font-family="verdana" font-size="9"/>
										<children/>
										<addvalidations/>
										<format datatype="string"/>
									</content>
								</children>
								<addvalidations/>
								<sort/>
							</template>
							<text fixtext="]">
								<editorproperties/>
								<properties/>
								<styles font-family="verdana" font-size="9"/>
								<children/>
							</text>
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
