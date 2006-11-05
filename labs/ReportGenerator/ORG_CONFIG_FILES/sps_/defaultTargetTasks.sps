<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="C:\_ABN\Owasp - VulnReport\V-Drive\Application (exe)\v0.75\VulnReport_Files\xsd\projectXsd.xsd" workingxmlfile="" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
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
									<text fixtext="Target Details:">
										<styles font-family="Verdana" font-size="medium" font-weight="bold"/>
									</text>
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
																						<styles background-color="#E4E4E4"/>
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
							<newline/>
							<newline/>
							<text fixtext="Target Tasks:">
								<styles font-family="Verdana" font-size="medium" font-weight="bold"/>
							</text>
							<newline/>
							<xpath>
								<match match="n1:TaskItem"/>
							</xpath>
							<newline/>
						</children>
					</template>
				</children>
			</template>
		</children>
	</template>
	<template>
		<match match="n1:AuditTrailItem"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:ReviewHistory"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:SpecialTag"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:Targets"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:TaskItem"/>
		<children>
			<table dynamic="1">
				<properties border="1" cellpadding="2" cellspacing="0" width="100%"/>
				<children>
					<tableheader>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties align="center" colspan="2"/>
										<children>
											<text fixtext="Task Name">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Created By">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Assigned To">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Completed Date">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="More Details">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Status">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
								</children>
							</tablerow>
						</children>
					</tableheader>
					<tablebody>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties colspan="2"/>
										<children>
											<template>
												<match match="n1:TaskName"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="xx-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
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
										<styles background-color="#E4E4E4"/>
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
										<styles background-color="#E4E4E4"/>
										<children>
											<template>
												<match match="n1:CompletedDate"/>
												<children>
													<xpath allchildren="1"/>
													<datepicker ownvalue="1" datatype="date"/>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
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
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<children>
											<template>
												<match match="n1:Status"/>
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
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
