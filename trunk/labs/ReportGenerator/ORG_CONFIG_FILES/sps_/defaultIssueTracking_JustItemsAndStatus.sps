<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="projectXsd.xsd" workingxmlfile="U:\_consolidatedReports\Australia.xml" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="xs" uri="http://www.w3.org/2001/XMLSchema"/>
	<nspair prefix="n1" uri="vuln_report"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<newline/>
			<text fixtext="ISSUE TRACKING (Just Items and Status)">
				<styles font-family="Verdana" font-size="larger" font-weight="bold"/>
			</text>
			<newline/>
			<newline/>
			<template>
				<match match="n1:Project"/>
				<children>
					<table dynamic="1">
						<properties border="0" width="100%"/>
						<children>
							<tablebody>
								<children>
									<tablerow>
										<children>
											<tablecol>
												<children>
													<table>
														<properties border="0" width="100%"/>
														<children>
															<tablebody>
																<children>
																	<tablerow>
																		<children>
																			<tablecol>
																				<styles background-color="black" color="white"/>
																				<properties width="60"/>
																				<children>
																					<text fixtext="Issue-id">
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																					</text>
																				</children>
																			</tablecol>
																			<tablecol>
																				<styles background-color="black" color="white"/>
																				<children>
																					<text fixtext="Vulnerability">
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																					</text>
																				</children>
																			</tablecol>
																			<tablecol>
																				<styles background-color="black" color="white"/>
																				<properties width="55"/>
																				<children>
																					<text fixtext="InRep">
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																					</text>
																				</children>
																			</tablecol>
																			<tablecol>
																				<styles background-color="black" color="white"/>
																				<properties width="50"/>
																				<children>
																					<text fixtext="Imp.">
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																					</text>
																				</children>
																			</tablecol>
																			<tablecol>
																				<styles background-color="black" color="white"/>
																				<properties width="50"/>
																				<children>
																					<text fixtext="Prob.">
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																					</text>
																				</children>
																			</tablecol>
																			<tablecol>
																				<styles background-color="black" color="white"/>
																				<properties width="150"/>
																				<children>
																					<text fixtext="Resolution-&gt;Status">
																						<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																					</text>
																				</children>
																			</tablecol>
																		</children>
																	</tablerow>
																</children>
															</tablebody>
														</children>
													</table>
													<template>
														<match match="n1:Targets"/>
														<children>
															<template>
																<match match="n1:Target"/>
																<children>
																	<template>
																		<match match="n1:Findings"/>
																		<children>
																			<choice>
																				<children>
																					<choiceoption>
																						<testexpression>
																							<xpath value="count(n1:Finding/@IncludeInReport) &gt;-1"/>
																						</testexpression>
																						<children>
																							<template>
																								<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
																								<match match="n1:Finding"/>
																								<children>
																									<table dynamic="1">
																										<properties border="0" width="100%"/>
																										<children>
																											<tablebody>
																												<children>
																													<tablerow>
																														<properties valign="top"/>
																														<children>
																															<tablecol>
																																<properties width="60"/>
																																<children>
																																	<template>
																																		<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
																																		<match match="@Issue-id"/>
																																		<children>
																																			<xpath allchildren="1">
																																				<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
																																			</xpath>
																																		</children>
																																	</template>
																																</children>
																															</tablecol>
																															<tablecol>
																																<children>
																																	<template>
																																		<match match="@Vulnerability"/>
																																		<children>
																																			<xpath allchildren="1">
																																				<styles font-family="Verdana" font-size="xx-small"/>
																																			</xpath>
																																		</children>
																																	</template>
																																</children>
																															</tablecol>
																															<tablecol>
																																<properties align="center" width="50"/>
																																<children>
																																	<template>
																																		<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
																																		<match match="@IncludeInReport"/>
																																		<children>
																																			<checkbox ownvalue="1">
																																				<styles font-family="Verdana" font-size="xx-small"/>
																																				<properties type="checkbox"/>
																																			</checkbox>
																																		</children>
																																	</template>
																																</children>
																															</tablecol>
																															<tablecol>
																																<properties align="center" width="50"/>
																																<children>
																																	<template>
																																		<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
																																		<match match="@Impact"/>
																																		<children>
																																			<xpath allchildren="1">
																																				<styles font-family="Verdana" font-size="xx-small"/>
																																			</xpath>
																																		</children>
																																	</template>
																																</children>
																															</tablecol>
																															<tablecol>
																																<properties align="center" width="50"/>
																																<children>
																																	<template>
																																		<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
																																		<match match="@Probability"/>
																																		<children>
																																			<xpath allchildren="1">
																																				<styles font-family="Verdana" font-size="xx-small"/>
																																			</xpath>
																																		</children>
																																	</template>
																																</children>
																															</tablecol>
																															<tablecol>
																																<properties valign="top" width="150"/>
																																<children>
																																	<template>
																																		<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
																																		<match match="n1:Resolution"/>
																																		<children>
																																			<table>
																																				<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0" width="100%"/>
																																				<children>
																																					<tablebody>
																																						<children>
																																							<tablerow>
																																								<children>
																																									<tablecol>
																																										<properties align="center" width="150"/>
																																										<children>
																																											<template>
																																												<editorproperties adding="mandatory" autoaddname="0" editable="0" markupmode="hide"/>
																																												<match match="@Status"/>
																																												<children>
																																													<xpath allchildren="1">
																																														<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
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
																												</children>
																											</tablebody>
																										</children>
																									</table>
																								</children>
																							</template>
																						</children>
																					</choiceoption>
																				</children>
																			</choice>
																		</children>
																	</template>
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
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:AuditTrailItem"/>
		<children>
			<table>
				<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0" width="100%"/>
				<children>
					<tablebody>
						<children>
							<tablerow>
								<properties valign="top"/>
								<children>
									<tablecol>
										<properties valign="center"/>
										<children>
											<text fixtext="Name">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
											<text fixtext=":">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties valign="center"/>
										<children>
											<template>
												<match match="n1:ItemName"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties valign="center"/>
										<children>
											<text fixtext="Date:">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties valign="center" width="120"/>
										<children>
											<template>
												<match match="n1:CreationDate"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
													</xpath>
													<text fixtext="   "/>
													<datepicker ownvalue="1" datatype="date"/>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties valign="center"/>
										<children>
											<text fixtext="By:">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties valign="center"/>
										<children>
											<template>
												<match match="n1:CreatedBy"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties valign="center"/>
										<children>
											<text fixtext="AssignedTo:">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties valign="center"/>
										<children>
											<template>
												<match match="n1:AssignedTo"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties valign="center"/>
										<children>
											<text fixtext="Status:">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties valign="center"/>
										<children>
											<template>
												<match match="@Status"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
								</children>
							</tablerow>
							<tablerow>
								<properties valign="top"/>
								<children>
									<tablecol>
										<properties valign="center"/>
										<children>
											<text fixtext="Details:">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties colspan="9" valign="center"/>
										<children>
											<template>
												<match match="n1:MoreDetails"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
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
	<template>
		<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
		<match match="n1:SpecialTag"/>
		<children>
			<table>
				<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0"/>
				<children>
					<tablebody>
						<children>
							<tablerow>
								<properties valign="top"/>
								<children>
									<tablecol>
										<properties width="21"/>
									</tablecol>
									<tablecol>
										<properties width="70"/>
										<children>
											<text fixtext="Tag Name:">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties width="99"/>
										<children>
											<template>
												<match match="n1:TagName"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties width="43"/>
										<children>
											<text fixtext="Value:">
												<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="F0F0F0"/>
										<properties width="100"/>
										<children>
											<template>
												<match match="n1:TagValue"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
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
	<template>
		<match match="n1:TaskItem"/>
		<children>
			<xpath allchildren="1"/>
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
