<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="C:\_ABN\Owasp - VulnReport\V-Drive\Application (exe)\v0.70\VulnReport_Files\xsd\projectXsd.xsd" workingxmlfile="" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
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
																												<properties width="716"/>
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
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<properties width="79"/>
																												<children>
																													<text fixtext="Owner:">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<properties width="79"/>
																												<children>
																													<template>
																														<match match="@Owner"/>
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
																												<properties width="79"/>
																												<children>
																													<text fixtext="TSA-ID:">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<properties width="80"/>
																												<children>
																													<template>
																														<match match="@Tsa-id"/>
																														<children>
																															<xpath allchildren="1">
																																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
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
																												<properties rowspan="2" valign="top" width="139"/>
																												<children>
																													<text fixtext="Layer">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<properties background-color="Red" valign="top"/>
																												<children>
																													<template>
																														<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="large"/>
																														<match match="@Layer"/>
																														<children>
																															<select ownvalue="1">
																																<styles font-family="Verdana" font-size="smaller"/>
																																<properties size="0"/>
																																<selectoption description="Application" value="Application"/>
																																<selectoption description="Service" value="Service"/>
																																<selectoption description="Operating System" value="Operating System"/>
																																<selectoption description="Network" value="Network"/>
																																<selectoption description="Hardware" value="Hardware"/>
																															</select>
																														</children>
																													</template>
																													<newline/>
																												</children>
																											</tablecol>
																											<tablecol>
																												<properties rowspan="2" valign="top"/>
																												<children>
																													<text fixtext="Category">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<children>
																													<template>
																														<match match="@Category"/>
																														<children>
																															<select ownvalue="1">
																																<styles font-family="Verdana" font-size="smaller"/>
																																<properties size="0"/>
																																<selectoption description="Input and Data Validation" value="Input and Data Validation"/>
																																<selectoption description="Authentication" value="Authentication"/>
																																<selectoption description="Authorization" value="Authorization"/>
																																<selectoption description="Parameter Manipulation" value="Parameter Manipulation"/>
																																<selectoption description="Exception Management" value="Exception Management"/>
																																<selectoption description="Sensitive Data" value="Sensitive Data"/>
																																<selectoption description="Access Control" value="Access Control"/>
																															</select>
																														</children>
																													</template>
																													<newline/>
																												</children>
																											</tablecol>
																										</children>
																									</tablerow>
																									<tablerow>
																										<children>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<properties background-color="Red" valign="top"/>
																												<children>
																													<template>
																														<match match="@Layer"/>
																														<children>
																															<xpath allchildren="1">
																																<styles font-family="Verdana" font-size="x-small"/>
																															</xpath>
																														</children>
																													</template>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<children>
																													<template>
																														<match match="@Category"/>
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
																												<properties valign="top" width="139"/>
																												<children>
																													<text fixtext="Impact">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<children>
																													<template>
																														<match match="@Impact"/>
																														<children>
																															<select ownvalue="1">
																																<styles font-family="Verdana"/>
																																<properties size="0"/>
																																<selectoption description="Critical" value="Critical"/>
																																<selectoption description="High" value="High"/>
																																<selectoption description="Medium" value="Medium"/>
																																<selectoption description="Low" value="Low"/>
																																<selectoption description="Info" value="Info"/>
																															</select>
																														</children>
																													</template>
																												</children>
																											</tablecol>
																											<tablecol>
																												<children>
																													<text fixtext="Probability">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<children>
																													<template>
																														<match match="@Probability"/>
																														<children>
																															<select ownvalue="1">
																																<styles font-family="Verdana"/>
																																<properties size="0"/>
																																<selectoption description="Critical" value="Critical"/>
																																<selectoption description="High" value="High"/>
																																<selectoption description="Medium" value="Medium"/>
																																<selectoption description="Low" value="Low"/>
																																<selectoption description="Info" value="Info"/>
																															</select>
																														</children>
																													</template>
																												</children>
																											</tablecol>
																										</children>
																									</tablerow>
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
																												<properties height="47" valign="top" width="139"/>
																												<children>
																													<text fixtext="Comments:">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<properties colspan="3" height="47" valign="top"/>
																												<children>
																													<template>
																														<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
																														<match match="n1:Comments"/>
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
																												<properties height="54" valign="top" width="139"/>
																												<children>
																													<text fixtext="Recomendations:">
																														<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																													</text>
																												</children>
																											</tablecol>
																											<tablecol>
																												<styles background-color="#E4E4E4"/>
																												<properties colspan="3" height="54" valign="top"/>
																												<children>
																													<template>
																														<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
																														<match match="n1:Recommendation"/>
																														<children>
																															<template>
																																<match match="n1:linkToRecommendationDatabase"/>
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
																													</template>
																													<newline/>
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
																									<tablerow>
																										<children>
																											<tablecol>
																												<properties height="18" valign="top" width="139"/>
																											</tablecol>
																											<tablecol>
																												<properties colspan="3" height="18" valign="top"/>
																												<children>
																													<template>
																														<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
																														<match match="@IncludeInReport"/>
																														<children>
																															<checkbox ownvalue="1">
																																<styles font-family="Verdana" font-size="x-small" width="20px"/>
																																<properties type="checkbox"/>
																															</checkbox>
																															<text fixtext=" Include In Report">
																																<styles font-family="Verdana" font-size="x-small"/>
																															</text>
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
																					<newline/>
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
				<imagesource>
					<xpath value="@src"/>
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
