<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="../xsd/projectXsd.xsd" workingxmlfile="" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
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
																<properties colspan="4"/>
																<children>
																	<template>
																		<match match="n1:Findings"/>
																		<children>
																			<template>
																				<match match="n1:Finding"/>
																				<children>
																					<table>
																						<properties border="0" width="100%"/>
																						<children>
																							<tablebody>
																								<children>
																									<tablerow>
																										<children>
																											<tablecol>
																												<properties colspan="5" width="716"/>
																												<children>
																													<template>
																														<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
																														<match match="@Vulnerability"/>
																														<children>
																															<xpath allchildren="1">
																																<styles font-family="Verdana" font-size="medium" font-weight="bold"/>
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
																					<table>
																						<properties border="0" cellpadding="2" cellspacing="5" width="100%"/>
																						<children>
																							<tablebody>
																								<children>
																									<tablerow>
																										<children>
																											<tablecol>
																												<properties valign="top" width="139"/>
																												<children>
																													<text fixtext="Vulnerability">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<properties colspan="3"/>
																												<children>
																													<template>
																														<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
																														<match match="@Vulnerability"/>
																														<children>
																															<xpath allchildren="1">
																																<styles font-family="Verdana" font-size="x-small"/>
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
																												<properties height="27" valign="top" width="139"/>
																												<children>
																													<text fixtext="Affected Items">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<properties colspan="3" height="27" valign="top"/>
																												<children>
																													<template>
																														<match match="n1:AffectedItems"/>
																														<children>
																															<list>
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
																												</children>
																											</tablecol>
																										</children>
																									</tablerow>
																									<tablerow>
																										<children>
																											<tablecol>
																												<properties height="54" valign="top" width="139"/>
																												<children>
																													<text fixtext="Additional Details ">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																													<newline/>
																													<text fixtext="(you can paste ">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																													<newline/>
																													<text fixtext="images here)">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<properties colspan="3" height="54" valign="top"/>
																												<children>
																													<template>
																														<match match="n1:AdittionalDetails"/>
																														<children>
																															<xpath allchildren="1">
																																<styles font-family="Verdana" font-size="x-small"/>
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
																				</children>
																			</template>
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
	<template>
		<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
		<match match="n1:img"/>
		<children>
			<newline/>
			<image>
				<properties border="0"/>
				<target>
					<xpath value="resolve-uri(@src, static-base-uri())"/>
				</target>
				<imagesource>
					<xpath value="resolve-uri(@src, static-base-uri())"/>
				</imagesource>
			</image>
			<newline/>
			<text fixtext="[">
				<styles font-family="verdana" font-size="9"/>
			</text>
			<template>
				<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
				<match match="@src"/>
				<children>
					<xpath allchildren="1">
						<styles font-family="verdana" font-size="9"/>
					</xpath>
				</children>
			</template>
			<text fixtext="]">
				<styles font-family="verdana" font-size="9"/>
			</text>
			<newline/>
		</children>
	</template>
	<template>
		<editorproperties adding="mandatory" autoaddname="1" editable="0" markupmode="hide"/>
		<match match="n1:newline"/>
		<children>
			<xpath allchildren="1"/>
			<newline/>
		</children>
	</template>
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
