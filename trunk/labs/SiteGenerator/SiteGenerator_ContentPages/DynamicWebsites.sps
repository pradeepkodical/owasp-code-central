<?xml version="1.0" encoding="UTF-8"?>
<structure version="4" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<schemasources>
		<namespaces>
			<nspair prefix="ipo" uri="http://www.altova.com/IPO"/>
			<nspair prefix="n1" uri="http://www.xmlspy.com/schemas/orgchart"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="DynamicWebsites.xsd" workingxmlfile="test.xml">
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
							<template match="n1:SiteGenerator">
								<editorproperties elementstodisplay="1"/>
								<properties/>
								<styles/>
								<children>
									<text fixtext="SiteGenerator site:">
										<editorproperties/>
										<properties/>
										<styles font-family="Verdana" font-size="larger"/>
										<children/>
									</text>
									<template match="@name">
										<editorproperties elementstodisplay="1"/>
										<properties/>
										<styles/>
										<children>
											<content>
												<editorproperties/>
												<properties/>
												<styles font-family="Verdana" font-size="larger" font-style="italic" font-weight="bold"/>
												<children/>
												<addvalidations/>
												<format datatype="string"/>
											</content>
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
									<newline>
										<editorproperties/>
										<properties/>
										<styles/>
										<children/>
									</newline>
									<template match="n1:site">
										<editorproperties elementstodisplay="1"/>
										<properties/>
										<styles/>
										<children>
											<content match="n1:rootFolder">
												<editorproperties/>
												<properties/>
												<styles/>
												<children/>
												<addvalidations/>
												<format/>
											</content>
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
					<text fixtext=" ">
						<editorproperties/>
						<properties/>
						<styles/>
						<children/>
					</text>
				</children>
			</globaltemplate>
			<globaltemplate match="n1:SiteGenerator">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:SiteGenerator">
						<editorproperties elementstodisplay="1"/>
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
						<addvalidations/>
						<sort/>
					</template>
				</children>
			</globaltemplate>
			<globaltemplate match="n1:file">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:file">
						<editorproperties editable="1" markupmode="hide" adding="mandatory" autoaddname="1"/>
						<properties/>
						<styles/>
						<children>
							<image>
								<editorproperties/>
								<properties border="0"/>
								<styles font-family="Verdana" font-size="xx-small"/>
								<children/>
								<target>
									<fixtext value="images/file.gif"/>
								</target>
								<imagesource>
									<fixtext value="images/file.gif"/>
								</imagesource>
							</image>
							<template match="@name">
								<editorproperties editable="1" markupmode="hide" adding="mandatory" autoaddname="1"/>
								<properties/>
								<styles/>
								<children>
									<content>
										<editorproperties/>
										<properties/>
										<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
										<children/>
										<addvalidations/>
										<format datatype="string"/>
									</content>
								</children>
								<addvalidations/>
								<sort/>
							</template>
							<text fixtext=" [">
								<editorproperties/>
								<properties/>
								<styles color="gray" font-family="Verdana" font-size="xx-small"/>
								<children/>
							</text>
							<template match="@mappedTo">
								<editorproperties editable="1" markupmode="hide" adding="mandatory" autoaddname="1"/>
								<properties/>
								<styles/>
								<children>
									<content>
										<editorproperties/>
										<properties/>
										<styles color="gray" font-family="Verdana" font-size="xx-small"/>
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
								<styles color="gray" font-family="Verdana" font-size="xx-small"/>
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
			<globaltemplate match="n1:folder">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:folder">
						<editorproperties editable="1" markupmode="hide" adding="mandatory" autoaddname="1"/>
						<properties/>
						<styles/>
						<children>
							<table>
								<editorproperties/>
								<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0"/>
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
														<properties colspan="3" height="0" width="32"/>
														<styles/>
														<children/>
													</tablecell>
													<tablecell>
														<editorproperties/>
														<properties height="0" width="708"/>
														<styles/>
														<children>
															<image>
																<editorproperties/>
																<properties border="0"/>
																<styles font-family="Verdana" font-size="xx-small"/>
																<children/>
																<target>
																	<fixtext value="images/folder.gif"/>
																</target>
																<imagesource>
																	<fixtext value="images/folder.gif"/>
																</imagesource>
															</image>
															<template match="@name">
																<editorproperties editable="1" markupmode="hide" adding="mandatory" autoaddname="1"/>
																<properties/>
																<styles/>
																<children>
																	<content>
																		<editorproperties/>
																		<properties/>
																		<styles color="black" font-family="Verdana" font-size="xx-small" font-weight="bold"/>
																		<children/>
																		<addvalidations/>
																		<format datatype="string"/>
																	</content>
																</children>
																<addvalidations/>
																<sort/>
															</template>
															<table>
																<editorproperties/>
																<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
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
																						<properties height="0" rowspan="2" width="28"/>
																						<styles/>
																						<children/>
																					</tablecell>
																					<tablecell>
																						<editorproperties/>
																						<properties height="2"/>
																						<styles/>
																						<children>
																							<content match="n1:folder">
																								<editorproperties editable="1"/>
																								<properties/>
																								<styles font-family="Verdana" font-size="xx-small"/>
																								<children/>
																								<addvalidations/>
																								<format/>
																							</content>
																							<text fixtext=".">
																								<editorproperties/>
																								<properties/>
																								<styles font-size="1pt"/>
																								<children/>
																							</text>
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
																						<properties height="0"/>
																						<styles/>
																						<children>
																							<content match="n1:file">
																								<editorproperties editable="1"/>
																								<properties/>
																								<styles font-family="Verdana" font-size="xx-small"/>
																								<children/>
																								<addvalidations/>
																								<format/>
																							</content>
																							<text fixtext=".">
																								<editorproperties/>
																								<properties/>
																								<styles font-size="1pt"/>
																								<children/>
																							</text>
																						</children>
																					</tablecell>
																				</children>
																			</tablerow>
																		</children>
																	</tablebody>
																</children>
															</table>
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
			</globaltemplate>
			<globaltemplate match="n1:rootFolder">
				<editorproperties/>
				<properties/>
				<styles/>
				<children>
					<template match="n1:rootFolder">
						<editorproperties elementstodisplay="1"/>
						<properties/>
						<styles/>
						<children>
							<image>
								<editorproperties/>
								<properties border="0"/>
								<styles font-family="Verdana" font-size="xx-small" vertical-align="top" width="26px"/>
								<children/>
								<target>
									<fixtext value="images/folder.gif"/>
								</target>
								<imagesource>
									<fixtext value="images/folder.gif"/>
								</imagesource>
							</image>
							<text fixtext=" ">
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</text>
							<text fixtext="/">
								<editorproperties/>
								<properties/>
								<styles font-family="Verdana" font-weight="bold"/>
								<children/>
							</text>
							<newline>
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
							</newline>
							<content match="n1:folder">
								<editorproperties/>
								<properties/>
								<styles/>
								<children/>
								<addvalidations/>
								<format/>
							</content>
							<table>
								<editorproperties/>
								<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0"/>
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
														<properties colspan="3" height="0" width="32"/>
														<styles/>
														<children/>
													</tablecell>
													<tablecell>
														<editorproperties/>
														<properties height="0" width="461"/>
														<styles/>
														<children>
															<table>
																<editorproperties/>
																<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
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
																						<properties colspan="2" height="0" width="574"/>
																						<styles/>
																						<children>
																							<content match="n1:file">
																								<editorproperties editable="1"/>
																								<properties/>
																								<styles font-family="Verdana" font-size="xx-small"/>
																								<children/>
																								<addvalidations/>
																								<format/>
																							</content>
																						</children>
																					</tablecell>
																				</children>
																			</tablerow>
																		</children>
																	</tablebody>
																</children>
															</table>
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
