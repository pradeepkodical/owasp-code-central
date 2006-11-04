<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="recommendationsXsd.xsd" workingxmlfile="C:\_ABN\VulnReport\Xml_Database\_recommendationsDatabase\recommendationsDatabase.xml" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="xs" uri="http://www.w3.org/2001/XMLSchema"/>
	<nspair prefix="n1" uri="vuln_report"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<text fixtext="Recommendation&apos;s Database">
				<styles font-family="Verdana" font-weight="bold"/>
			</text>
			<newline/>
			<template>
				<styles font-family="Verdana" font-weight="bold"/>
				<match match="n1:Recommendations"/>
				<children>
					<newline/>
					<template>
						<match match="n1:Recommendation"/>
						<children>
							<template>
								<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
								<match match="n1:Id"/>
								<children>
									<xpath allchildren="1">
										<styles font-family="Verdana" font-size="small"/>
									</xpath>
								</children>
							</template>
							<text fixtext=" : ">
								<styles font-family="Verdana" font-size="small"/>
							</text>
							<template>
								<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
								<match match="n1:Name"/>
								<children>
									<xpath allchildren="1">
										<styles font-family="Verdana" font-size="small"/>
									</xpath>
								</children>
							</template>
							<newline/>
							<newline/>
							<table>
								<properties border="0" width="100%"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecol>
														<properties width="18"/>
													</tablecol>
													<tablecol>
														<styles border-top-color="black" border-top-style="dotted" border-width="thin"/>
														<properties width="92"/>
														<children>
															<text fixtext="Id: ">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4" border-top-color="black" border-top-style="dotted" border-width="thin"/>
														<properties width="289"/>
														<children>
															<template>
																<match match="n1:Id"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Verdana" font-size="smaller"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<styles border-top-color="black" border-top-style="dotted" border-width="thin"/>
														<properties width="150"/>
														<children>
															<text fixtext="Name:">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4" border-top-color="black" border-top-style="dotted" border-width="thin"/>
														<children>
															<template>
																<match match="n1:Name"/>
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
														<properties width="18"/>
													</tablecol>
													<tablecol>
														<properties width="150"/>
														<children>
															<text fixtext="Layer(s)">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<properties width="289"/>
														<children>
															<template>
																<match match="n1:Layer"/>
																<children>
																	<list>
																		<styles margin-bottom="0" margin-top="0"/>
																		<properties start="1" type="disc"/>
																		<children>
																			<listrow>
																				<children>
																					<xpath allchildren="1">
																						<styles font-family="Verdana" font-size="smaller"/>
																					</xpath>
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
														<properties width="150"/>
														<children>
															<text fixtext="Category(ies)">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<properties width="289"/>
														<children>
															<template>
																<match match="n1:Category"/>
																<children>
																	<list>
																		<styles margin-bottom="0" margin-top="0"/>
																		<properties start="1" type="disc"/>
																		<children>
																			<listrow>
																				<styles background-color="#E4E4E4"/>
																				<children>
																					<xpath allchildren="1">
																						<styles font-family="Verdana" font-size="smaller"/>
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
														<properties valign="top" width="18"/>
													</tablecol>
													<tablecol>
														<properties valign="top" width="92"/>
														<children>
															<text fixtext="Short-term recommendations">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<properties valign="top" width="289"/>
														<children>
															<template>
																<match match="n1:ShortTermRecommendation"/>
																<children>
																	<select ownvalue="1">
																		<properties size="0"/>
																		<selectoption description="Validate with RegEx" value="Validate with RegEx"/>
																		<selectoption description="Implement SSL/TLS" value="Implement SSL/TLS"/>
																		<selectoption description="Bounds Checking" value="Bounds Checking"/>
																		<selectoption description="Implement proper Crypto" value="Implement proper Crypto"/>
																	</select>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties valign="top" width="150"/>
														<children>
															<text fixtext="Long-term recommendations">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<properties valign="top"/>
														<children>
															<template>
																<match match="n1:LongTermRecommendation"/>
																<children>
																	<select ownvalue="1">
																		<properties size="0"/>
																		<selectoption description="Validate with RegEx" value="Validate with RegEx"/>
																		<selectoption description="Implement SSL/TLS" value="Implement SSL/TLS"/>
																		<selectoption description="Update to Newest Version" value="Update to Newest Version"/>
																		<selectoption description="Rewrite Architecture" value="Rewrite Architecture"/>
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
														<properties valign="top" width="18"/>
													</tablecol>
													<tablecol>
														<styles border-bottom-color="black" border-bottom-style="dotted" border-width="thin"/>
														<properties valign="top" width="92"/>
														<children>
															<text fixtext="Reference links">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4" border-bottom-color="black" border-bottom-style="dotted" border-width="thin"/>
														<properties colspan="3" width="289"/>
														<children>
															<template>
																<match match="n1:ReferenceLinks"/>
																<children>
																	<list>
																		<styles margin-bottom="0" margin-top="0"/>
																		<properties start="1" type="disc"/>
																		<children>
																			<listrow>
																				<styles background-color="#E4E4E4"/>
																				<children>
																					<xpath allchildren="1">
																						<styles font-family="Verdana" font-size="smaller"/>
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
										</children>
									</tablebody>
								</children>
							</table>
							<newline/>
							<newline/>
						</children>
					</template>
					<newline/>
				</children>
			</template>
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:newline"/>
		<children>
			<newline/>
			<xpath allchildren="1"/>
			<newline/>
		</children>
	</template>
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
