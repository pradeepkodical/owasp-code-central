<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="V:\1. Application (i.e. run VulnReport from the network)\v0.75\VulnReport_Files\xsd\projectXsd.xsd" workingxmlfile="" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="xs" uri="http://www.w3.org/2001/XMLSchema"/>
	<nspair prefix="n1" uri="vuln_report"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<template>
				<match match="n1:Project"/>
				<children>
					<text fixtext="Project Details (Metadata)">
						<styles font-family="Verdana" font-size="medium" font-weight="bold"/>
					</text>
					<newline/>
					<template>
						<match match="n1:Metadata"/>
						<children>
							<newline/>
							<table>
								<properties border="0" width="100%"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecol>
														<properties width="130"/>
														<children>
															<text fixtext="Proj. ID">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<children>
															<template>
																<match match="n1:project_number"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Verdana" font-size="smaller"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties align="center"/>
														<children>
															<text fixtext="Project Name:">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<children>
															<template>
																<match match="n1:project_name"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Verdana" font-size="smaller"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties width="146"/>
														<children>
															<text fixtext="Next Finding ID:">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<children>
															<template>
																<match match="@next_ID_Number"/>
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
														<properties height="46" valign="top" width="130"/>
														<children>
															<text fixtext="Description">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<properties colspan="5" height="46" valign="top"/>
														<children>
															<template>
																<match match="n1:project_description"/>
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
														<properties height="19" valign="top" width="130"/>
														<children>
															<text fixtext="Region:">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<properties height="19"/>
														<children>
															<template>
																<match match="n1:Region"/>
																<children>
																	<select ownvalue="1">
																		<properties size="0"/>
																		<selectoption description="Global" value="Global"/>
																		<selectoption description="EU" value="EU"/>
																		<selectoption description="LA" value="LA"/>
																		<selectoption description="NL" value="NL"/>
																		<selectoption description="NA" value="NA"/>
																		<selectoption description="ASIA" value="ASIA"/>
																	</select>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties height="19" valign="top" width="130"/>
														<children>
															<text fixtext="Test Type:">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<properties height="19"/>
														<children>
															<template>
																<match match="n1:TestType"/>
																<children>
																	<select ownvalue="1">
																		<properties size="0"/>
																		<selectoption description="Blackbox" value="Blackbox"/>
																		<selectoption description="Greybox" value="Greybox"/>
																		<selectoption description="Whitebox" value="Whitebox"/>
																		<selectoption description="Pen-test" value="Pen-test"/>
																		<selectoption description="Threat Model Review" value="Threat Model Review"/>
																	</select>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<properties height="19"/>
													</tablecol>
													<tablecol>
														<properties height="19"/>
													</tablecol>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecol>
														<properties valign="top" width="130"/>
														<children>
															<text fixtext="Dates">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<properties colspan="5"/>
														<children>
															<newline/>
															<template>
																<match match="n1:dates"/>
																<children>
																	<table>
																		<properties border="0" width="100%"/>
																		<children>
																			<tablebody>
																				<children>
																					<tablerow>
																						<children>
																							<tablecol>
																								<properties height="23" width="145"/>
																								<children>
																									<text fixtext="Request received:">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<properties height="23"/>
																								<children>
																									<template>
																										<match match="n1:request_received"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="smaller"/>
																											</xpath>
																											<datepicker ownvalue="1" datatype="date"/>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<properties height="23" width="174"/>
																								<children>
																									<text fixtext="Request acknowledged:">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<properties height="23"/>
																								<children>
																									<template>
																										<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
																										<match match="n1:request_acknowledged"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="smaller"/>
																											</xpath>
																											<datepicker ownvalue="1" datatype="date"/>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<properties height="23" width="44"/>
																								<children>
																									<text fixtext="Days:">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<properties height="23"/>
																								<children>
																									<template>
																										<match match="n1:daysBetweenReqAndAck"/>
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
																								<properties height="23" width="145"/>
																								<children>
																									<text fixtext="Start date:">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<properties height="23"/>
																								<children>
																									<template>
																										<match match="n1:start_date"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="smaller"/>
																											</xpath>
																											<datepicker ownvalue="1" datatype="date"/>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<properties width="174"/>
																								<children>
																									<text fixtext="Due date:">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																									<text fixtext=" ">
																										<styles font-family="Verdana" font-size="smaller"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<children>
																									<template>
																										<match match="n1:due_date"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="smaller"/>
																											</xpath>
																											<datepicker ownvalue="1" datatype="date"/>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<properties height="23" width="44"/>
																								<children>
																									<text fixtext="Days:">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<children>
																									<template>
																										<match match="n1:daysProjectDuration"/>
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
																								<properties height="23" width="145"/>
																								<children>
																									<text fixtext="Actual end date">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<children>
																									<template>
																										<match match="n1:actual_end_date"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="smaller"/>
																											</xpath>
																											<datepicker ownvalue="1" datatype="date"/>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<properties height="23" width="174"/>
																								<children>
																									<text fixtext="Report delivery date">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<children>
																									<template>
																										<match match="n1:report_delivery_date"/>
																										<children>
																											<xpath allchildren="1">
																												<styles font-family="Verdana" font-size="smaller"/>
																											</xpath>
																											<datepicker ownvalue="1" datatype="date"/>
																										</children>
																									</template>
																								</children>
																							</tablecol>
																							<tablecol>
																								<properties height="23" width="7"/>
																								<children>
																									<text fixtext="Days:">
																										<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																									</text>
																								</children>
																							</tablecol>
																							<tablecol>
																								<styles background-color="#E4E4E4"/>
																								<children>
																									<template>
																										<match match="n1:daysBetweenEndAndDelivery"/>
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
																				</children>
																			</tablebody>
																		</children>
																	</table>
																</children>
															</template>
															<newline/>
															<newline/>
														</children>
													</tablecol>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecol>
														<properties valign="top" width="130"/>
														<children>
															<text fixtext="Contacts">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<properties colspan="5"/>
														<children>
															<template>
																<match match="n1:contacts"/>
																<children>
																	<template>
																		<match match="n1:primary_contact"/>
																		<children>
																			<text fixtext="Primary Contact(s): ">
																				<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																			</text>
																			<xpath allchildren="1">
																				<styles font-family="Verdana" font-size="smaller"/>
																			</xpath>
																		</children>
																	</template>
																	<newline/>
																	<template>
																		<match match="n1:secondary_contact"/>
																		<children>
																			<text fixtext="Secundary Contact(s): ">
																				<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																			</text>
																			<xpath allchildren="1">
																				<styles font-family="Verdana" font-size="smaller"/>
																			</xpath>
																		</children>
																	</template>
																	<newline/>
																	<template>
																		<match match="n1:project_owner"/>
																		<children>
																			<text fixtext="Project Owner: ">
																				<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																			</text>
																			<xpath allchildren="1">
																				<styles font-family="Verdana" font-size="smaller"/>
																			</xpath>
																		</children>
																	</template>
																	<newline/>
																	<template>
																		<match match="n1:report_author"/>
																		<children>
																			<text fixtext="Report Author: ">
																				<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																			</text>
																			<xpath allchildren="1">
																				<styles font-family="Verdana" font-size="smaller"/>
																			</xpath>
																		</children>
																	</template>
																	<newline/>
																	<template>
																		<match match="n1:report_reviewer"/>
																		<children>
																			<text fixtext="Report Reviewer: ">
																				<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
																			</text>
																			<xpath allchildren="1">
																				<styles font-family="Verdana" font-size="smaller"/>
																			</xpath>
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
							<newline/>
							<xpath>
								<match match="n1:DocumentInformation"/>
							</xpath>
							<newline/>
							<newline/>
							<template>
								<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
								<match match="n1:DocumentInformation"/>
								<children>
									<newline/>
									<newline/>
									<newline/>
									<newline/>
								</children>
							</template>
							<newline/>
							<newline/>
						</children>
					</template>
					<newline/>
					<template>
						<match match="n1:Targets"/>
						<children>
							<newline/>
							<table>
								<properties border="0" width="100%"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecol>
														<properties height="1" valign="top" width="130"/>
														<children>
															<text fixtext="Target Subnets:">
																<styles font-family="Verdana" font-size="smaller" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="#E4E4E4"/>
														<properties height="1" valign="top"/>
														<children>
															<template>
																<match match="n1:TargetSubnets"/>
																<children>
																	<template>
																		<match match="n1:SubNet"/>
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
						</children>
					</template>
					<newline/>
				</children>
			</template>
			<newline/>
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:AuditTrailItem"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:Contact"/>
		<children>
			<newline/>
			<table>
				<properties border="0" width="100%"/>
				<children>
					<tablebody>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties height="23" width="18"/>
									</tablecol>
									<tablecol>
										<properties height="23" width="130"/>
										<children>
											<text fixtext="Given Name:">
												<styles font-family="Verdana" font-size="smaller"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties height="23" width="315"/>
										<children>
											<template>
												<match match="@givenNames"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="smaller"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties height="23" width="130"/>
										<children>
											<text fixtext="Surname:">
												<styles font-family="Verdana" font-size="smaller"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties height="23" width="315"/>
										<children>
											<template>
												<match match="@surname"/>
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
										<properties height="6" width="18"/>
									</tablecol>
									<tablecol>
										<properties height="6" width="130"/>
										<children>
											<text fixtext="Telephone:">
												<styles font-family="Verdana" font-size="smaller"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties height="6" width="315"/>
										<children>
											<template>
												<match match="@telephone"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="smaller"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties height="6" width="130"/>
										<children>
											<text fixtext="Mobile:">
												<styles font-family="Verdana" font-size="smaller"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties height="6" width="315"/>
										<children>
											<template>
												<match match="@mobile"/>
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
										<properties height="15" width="18"/>
									</tablecol>
									<tablecol>
										<properties height="15" width="130"/>
										<children>
											<text fixtext="Email:">
												<styles font-family="Verdana" font-size="smaller"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties height="15" width="315"/>
										<children>
											<template>
												<match match="@email"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="smaller"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<properties height="15" width="130"/>
										<children>
											<text fixtext="PGP Public Key:">
												<styles font-family="Verdana" font-size="smaller"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties height="15" width="315"/>
										<children>
											<template>
												<match match="@pgpPublicKey"/>
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
						</children>
					</tablebody>
				</children>
			</table>
			<text fixtext=" ">
				<styles font-family="Verdana" font-size="smaller"/>
			</text>
		</children>
	</template>
	<template>
		<match match="n1:DocumentInformation"/>
		<children>
			<newline/>
			<text fixtext="Document Information:">
				<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
			</text>
			<newline/>
			<table>
				<properties border="1" cellpadding="2" cellspacing="0" width="100%"/>
				<children>
					<tablebody>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<children>
											<text fixtext="Author:">
												<styles font-family="Verdana" font-size="x-small"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<children>
											<template>
												<match match="@Author"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<text fixtext="Status:">
												<styles font-family="Verdana" font-size="x-small"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<children>
											<template>
												<match match="@Status"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<text fixtext="Issue Date:">
												<styles font-family="Verdana" font-size="x-small"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<children>
											<template>
												<match match="@IssueDate"/>
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
										<properties colspan="2"/>
										<children>
											<text fixtext="Confidenciality Rating:">
												<styles font-family="Verdana" font-size="x-small"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties colspan="2"/>
										<children>
											<template>
												<match match="@ConfidencialityRating"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<text fixtext="Section:">
												<styles font-family="Verdana" font-size="x-small"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<children>
											<template>
												<match match="@Section"/>
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
										<properties colspan="2"/>
										<children>
											<text fixtext="Approved By:">
												<styles font-family="Verdana" font-size="x-small"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<properties colspan="2"/>
										<children>
											<template>
												<match match="@ApprovedBy"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<text fixtext="Signed:">
												<styles font-family="Verdana" font-size="x-small"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="#E4E4E4"/>
										<children>
											<template>
												<match match="@SignedBy"/>
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
			<newline/>
			<template>
				<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
				<match match="n1:ReviewDetails"/>
				<children>
					<xpath>
						<match match="n1:ReviewDetail"/>
					</xpath>
				</children>
			</template>
			<newline/>
			<template>
				<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
				<match match="n1:ReviewHistories"/>
				<children>
					<xpath>
						<match match="n1:ReviewHistory"/>
					</xpath>
				</children>
			</template>
			<newline/>
			<template>
				<editorproperties adding="all" autoaddname="1" editable="1" markupmode="hide"/>
				<match match="n1:RelatedDocuments"/>
				<children>
					<xpath>
						<match match="n1:RelatedDocument"/>
					</xpath>
				</children>
			</template>
			<newline/>
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:ExecutiveSummary"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:Metadata"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:Project"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:ReTestSla"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:Recommendation"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<match match="n1:RelatedDocument"/>
		<children>
			<text fixtext="Related Documents:">
				<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
			</text>
			<table dynamic="1">
				<properties border="1" cellpadding="2" cellspacing="0"/>
				<children>
					<tableheader>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Version">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Author">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Date">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Detail">
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
										<children>
											<template>
												<match match="@version"/>
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
												<match match="@Author"/>
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
												<match match="@Date"/>
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
												<match match="@Detail"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
											<newline/>
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
		<match match="n1:RelatedDocuments_"/>
		<children>
			<newline/>
			<text fixtext="Related Documents:">
				<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
			</text>
			<table dynamic="1">
				<properties border="1" cellpadding="2" cellspacing="0"/>
				<children>
					<tableheader>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Version">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Author">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Date">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Detail">
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
										<children>
											<template>
												<match match="@version"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<template>
												<match match="@Author"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<template>
												<match match="@Date"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<template>
												<match match="@Detail"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
											<newline/>
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
		<match match="n1:ReviewDetail"/>
		<children>
			<text fixtext="Review Details:">
				<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
			</text>
			<table dynamic="1">
				<properties border="1" cellpadding="2" cellspacing="0"/>
				<children>
					<tableheader>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Version">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Reviewer">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Date">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Detail">
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
										<children>
											<template>
												<match match="@version"/>
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
												<match match="@Reviewer"/>
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
												<match match="@Date"/>
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
												<match match="@Detail"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
											<newline/>
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
		<match match="n1:ReviewHistory"/>
		<children>
			<text fixtext="Review History:">
				<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
			</text>
			<table dynamic="1">
				<properties border="1" cellpadding="2" cellspacing="0"/>
				<children>
					<tableheader>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Version">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Author">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Date">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Detail">
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
										<children>
											<template>
												<match match="@version"/>
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
												<match match="@Author"/>
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
												<match match="@Date"/>
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
												<match match="@Detail"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
											<newline/>
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
		<match match="n1:ReviewHistory_"/>
		<children>
			<newline/>
			<text fixtext="Review History:">
				<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
			</text>
			<table dynamic="1">
				<properties border="1" cellpadding="2" cellspacing="0"/>
				<children>
					<tableheader>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Version">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Author">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Date">
												<styles font-family="Verdana" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<properties align="center"/>
										<children>
											<text fixtext="Detail">
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
										<children>
											<template>
												<match match="@version"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<template>
												<match match="@Author"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<template>
												<match match="@Date"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
										</children>
									</tablecol>
									<tablecol>
										<children>
											<template>
												<match match="@Detail"/>
												<children>
													<xpath allchildren="1">
														<styles font-family="Verdana" font-size="x-small"/>
													</xpath>
												</children>
											</template>
											<newline/>
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
		<match match="n1:Targets"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
