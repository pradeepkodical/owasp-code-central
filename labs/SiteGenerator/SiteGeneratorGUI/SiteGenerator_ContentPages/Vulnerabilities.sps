<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="Vulnerabilities.xsd" workingxmlfile="" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="ipo" uri="http://www.altova.com/IPO"/>
	<nspair prefix="xsd" uri="http://www.w3.org/2001/XMLSchema"/>
	<nspair prefix="n1" uri="http://www.xmlspy.com/schemas/orgchart"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<template>
				<match match="n1:SiteGenerator_Vulnerabilites"/>
				<children>
					<text fixtext="SiteGenerator Vulnerabilities (in this page)">
						<styles font-family="Arial" font-size="large" font-weight="bold"/>
					</text>
					<newline/>
					<newline/>
					<table>
						<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0"/>
						<children>
							<tablebody>
								<children>
									<tablerow>
										<children>
											<tablecol>
												<properties width="108"/>
												<children>
													<text fixtext="page comment">
														<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
													</text>
													<text fixtext=":">
														<styles font-family="Arial" font-size="smaller"/>
													</text>
												</children>
											</tablecol>
											<tablecol>
												<properties bgcolor="#D2D8E6" width="462"/>
												<children>
													<template>
														<match match="n1:pageComment"/>
														<children>
															<xpath allchildren="1">
																<styles font-family="Arial" font-size="smaller"/>
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
					<template>
						<match match="n1:vulnerability"/>
						<children>
							<newline/>
							<table>
								<properties border="0"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecol>
														<properties height="22" width="77"/>
														<children>
															<text fixtext="Category:">
																<styles font-family="Arial" font-size="small" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#D2D8E6"/>
														<properties colspan="2" height="22" width="313"/>
														<children>
															<template>
																<match match="@category"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="small" font-weight="bold"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties height="22" width="56"/>
														<children>
															<text fixtext="Type:">
																<styles font-family="Arial" font-size="small" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#D2D8E6"/>
														<properties height="22" width="220"/>
														<children>
															<template>
																<match match="@type"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="small" font-weight="bold"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties height="22" width="56"/>
														<children>
															<text fixtext="Mode:">
																<styles font-family="Arial" font-size="small" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#D2D8E6"/>
														<properties height="22" width="205"/>
														<children>
															<template>
																<match match="@mode"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="small" font-weight="bold"/>
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
														<properties width="77"/>
														<children>
															<text fixtext="Comment">
																<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#D2D8E6"/>
														<properties colspan="6" width="204"/>
													</tablecol>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecol>
														<properties width="77"/>
														<children>
															<text fixtext="Dread">
																<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<properties colspan="6"/>
														<children>
															<template>
																<match match="n1:dread"/>
																<children>
																	<table>
																		<properties border="1" border-collapse="collapse" cellpadding="0" cellspacing="0" width="100%"/>
																		<children>
																			<tablebody>
																				<children>
																					<tablerow>
																						<children>
																							<tablecol>
																								<children>
																									<text fixtext="D:">
																										<styles font-family="Arial" font-size="smaller"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<template>
																										<match match="@damage"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Arial" font-size="smaller"/>
																											</xpath>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<text fixtext="R">
																										<styles font-family="Arial" font-size="smaller"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<template>
																										<match match="@reproducibility"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Arial" font-size="smaller"/>
																											</xpath>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<text fixtext="E">
																										<styles font-family="Arial" font-size="smaller"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<template>
																										<match match="@exploitability"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Arial" font-size="smaller"/>
																											</xpath>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<text fixtext="A">
																										<styles font-family="Arial" font-size="smaller"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<template>
																										<match match="@affectedUsers"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Arial" font-size="smaller"/>
																											</xpath>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<children>
																									<text fixtext="D">
																										<styles font-family="Arial" font-size="smaller"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<properties width="123"/>
																								<children>
																									<template>
																										<match match="@discoverability"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Arial" font-size="smaller"/>
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
													</tablecol>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecol>
														<properties width="77"/>
														<children>
															<text fixtext="Risk">
																<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#D2D8E6"/>
														<properties width="125"/>
														<children>
															<template>
																<match match="n1:risk"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="smaller"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties width="45"/>
													</tablecol>
													<tablecol>
														<properties width="56"/>
													</tablecol>
													<tablecol/>
													<tablecol>
														<properties width="56"/>
													</tablecol>
													<tablecol/>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecol>
														<properties width="77"/>
														<children>
															<text fixtext="Exploit description">
																<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#D2D8E6"/>
														<properties colspan="6"/>
														<children>
															<template>
																<match match="n1:exploitDescription"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="smaller"/>
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
														<properties width="77"/>
														<children>
															<text fixtext="Remediation:">
																<styles font-family="Arial" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#D2D8E6"/>
														<properties colspan="6"/>
														<children>
															<template>
																<match match="n1:remediation"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="smaller"/>
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
					<newline/>
				</children>
			</template>
			<newline/>
			<newline/>
		</children>
	</template>
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
