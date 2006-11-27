<?xml version="1.0" encoding="UTF-8"?>
<structure version="4" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="vuln_report"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="C:\Projects\owasp\Application (exe)\v0.86\ORG_CONFIG_FILES\xsd\projectXsd.xsd">
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
																				<properties valign="top" width="62"/>
																				<styles/>
																				<children>
																					<text fixtext="name:">
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																						<children/>
																					</text>
																				</children>
																			</tablecell>
																			<tablecell>
																				<editorproperties/>
																				<properties width="237"/>
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
																			<tablecell>
																				<editorproperties/>
																				<properties width="96"/>
																				<styles/>
																				<children>
																					<text fixtext="Type">
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
																					<template match="@type">
																						<editorproperties elementstodisplay="1"/>
																						<properties/>
																						<styles/>
																						<children>
																							<combobox>
																								<editorproperties/>
																								<properties/>
																								<styles font-family="Verdana" font-size="smaller"/>
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
																								<addvalidations/>
																								<selectoption description="Workstation" value="Workstation"/>
																								<selectoption description="Server" value="Server"/>
																								<selectoption description="Website" value="Website"/>
																								<selectoption description="Stand-alone Device" value="Stand-alone Device"/>
																							</combobox>
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
																				<properties valign="top" width="62"/>
																				<styles/>
																				<children>
																					<text fixtext="IP(s):">
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																						<children/>
																					</text>
																				</children>
																			</tablecell>
																			<tablecell>
																				<editorproperties/>
																				<properties valign="top" width="237"/>
																				<styles background-color="#E4E4E4"/>
																				<children>
																					<list>
																						<editorproperties/>
																						<properties/>
																						<styles/>
																						<children>
																							<template match="n1:IP">
																								<editorproperties elementstodisplay="1"/>
																								<properties/>
																								<styles/>
																								<children>
																									<listrow>
																										<editorproperties/>
																										<properties/>
																										<styles/>
																										<children>
																											<template match="@value">
																												<editorproperties elementstodisplay="1"/>
																												<properties/>
																												<styles/>
																												<children>
																													<content restofcontents="1">
																														<editorproperties/>
																														<properties/>
																														<styles/>
																														<children/>
																														<addvalidations/>
																														<format datatype="anySimpleType"/>
																													</content>
																												</children>
																												<addvalidations/>
																												<sort/>
																											</template>
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
																				</children>
																			</tablecell>
																			<tablecell>
																				<editorproperties/>
																				<properties valign="top" width="96"/>
																				<styles/>
																				<children>
																					<text fixtext="DnsName(s)">
																						<editorproperties/>
																						<properties/>
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																						<children/>
																					</text>
																				</children>
																			</tablecell>
																			<tablecell>
																				<editorproperties/>
																				<properties valign="top"/>
																				<styles background-color="#E4E4E4"/>
																				<children>
																					<list>
																						<editorproperties/>
																						<properties/>
																						<styles/>
																						<children>
																							<template match="n1:DnsName">
																								<editorproperties elementstodisplay="1"/>
																								<properties/>
																								<styles/>
																								<children>
																									<listrow>
																										<editorproperties/>
																										<properties/>
																										<styles/>
																										<children>
																											<template match="@value">
																												<editorproperties elementstodisplay="1"/>
																												<properties/>
																												<styles/>
																												<children>
																													<content restofcontents="1">
																														<editorproperties/>
																														<properties/>
																														<styles/>
																														<children/>
																														<addvalidations/>
																														<format datatype="anySimpleType"/>
																													</content>
																												</children>
																												<addvalidations/>
																												<sort/>
																											</template>
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
		</children>
	</parts>
	<pagelayout>
		<editorproperties/>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
		<styles/>
		<children/>
	</pagelayout>
</structure>
