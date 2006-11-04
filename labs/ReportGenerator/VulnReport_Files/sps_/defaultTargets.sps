<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="..\xsd\projectXsd.xsd" workingxmlfile="" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="xs" uri="http://www.w3.org/2001/XMLSchema"/>
	<nspair prefix="n1" uri="vuln_report"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<template>
				<match match="n1:Project"/>
				<children>
					<template>
						<match match="n1:Targets"/>
						<children>
							<template>
								<match match="n1:Target"/>
								<children>
									<table>
										<properties border="0" width="100%"/>
										<children>
											<tablebody>
												<children>
													<tablerow>
														<children>
															<tablecol>
																<properties valign="top" width="62"/>
																<children>
																	<text fixtext="name:">
																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																	</text>
																</children>
															</tablecol>
															<tablecol>
																<styles background-color="#E4E4E4"/>
																<properties width="237"/>
																<children>
																	<template>
																		<match match="@name"/>
																		<children>
																			<xpath allchildren="1">
																				<styles font-family="Verdana" font-size="smaller"/>
																			</xpath>
																		</children>
																	</template>
																</children>
															</tablecol>
															<tablecol>
																<properties width="96"/>
																<children>
																	<text fixtext="Type">
																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																	</text>
																</children>
															</tablecol>
															<tablecol>
																<styles background-color="#E4E4E4"/>
																<children>
																	<template>
																		<match match="@type"/>
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
																<properties valign="top" width="62"/>
																<children>
																	<text fixtext="IP(s):">
																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																	</text>
																</children>
															</tablecol>
															<tablecol>
																<styles background-color="#E4E4E4"/>
																<properties valign="top" width="237"/>
																<children>
																	<template>
																		<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
																		<match match="n1:IP"/>
																		<children>
																			<list>
																				<styles margin-bottom="0" margin-top="0"/>
																				<properties start="1" type="disc"/>
																				<children>
																					<listrow>
																						<children>
																							<template>
																								<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
																								<match match="@value"/>
																								<children>
																									<xpath allchildren="1">
																										<styles font-family="Verdana" font-size="smaller"/>
																									</xpath>
																								</children>
																							</template>
																						</children>
																					</listrow>
																				</children>
																			</list>
																		</children>
																	</template>
																	<newline/>
																</children>
															</tablecol>
															<tablecol>
																<properties valign="top" width="96"/>
																<children>
																	<text fixtext="DnsName(s)">
																		<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																	</text>
																</children>
															</tablecol>
															<tablecol>
																<styles background-color="#E4E4E4"/>
																<properties valign="top"/>
																<children>
																	<template>
																		<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
																		<match match="n1:DnsName"/>
																		<children>
																			<list>
																				<styles margin-bottom="0" margin-top="0"/>
																				<properties start="1" type="disc"/>
																				<children>
																					<listrow>
																						<children>
																							<template>
																								<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
																								<match match="@value"/>
																								<children>
																									<xpath allchildren="1">
																										<styles font-family="Verdana" font-size="smaller"/>
																									</xpath>
																								</children>
																							</template>
																						</children>
																					</listrow>
																				</children>
																			</list>
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
				</children>
			</template>
			<newline/>
		</children>
	</template>
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
