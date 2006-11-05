<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="DynamicWebsites.xsd" workingxmlfile="test.xml" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="ipo" uri="http://www.altova.com/IPO"/>
	<nspair prefix="xsd" uri="http://www.w3.org/2001/XMLSchema"/>
	<nspair prefix="n1" uri="http://www.xmlspy.com/schemas/orgchart"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<template>
				<match match="n1:SiteGenerator"/>
				<children>
					<text fixtext="SiteGenerator site:">
						<styles font-family="Verdana" font-size="larger"/>
					</text>
					<template>
						<match match="@name"/>
						<children>
							<xpath allchildren="1">
								<styles font-family="Verdana" font-size="larger" font-style="italic" font-weight="bold"/>
							</xpath>
						</children>
					</template>
					<newline/>
					<newline/>
					<template>
						<match match="n1:site"/>
						<children>
							<xpath>
								<match match="n1:rootFolder"/>
							</xpath>
						</children>
					</template>
				</children>
			</template>
			<newline/>
		</children>
	</template>
	<template>
		<match match="n1:SiteGenerator"/>
		<children>
			<xpath allchildren="1"/>
		</children>
	</template>
	<template>
		<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
		<match match="n1:file"/>
		<children>
			<image>
				<styles font-family="Verdana" font-size="xx-small"/>
				<properties border="0"/>
				<imagesource>
					<fixtext value="images/file.gif"/>
				</imagesource>
			</image>
			<template>
				<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
				<match match="@name"/>
				<children>
					<xpath allchildren="1">
						<styles font-family="Verdana" font-size="xx-small" font-weight="bold"/>
					</xpath>
				</children>
			</template>
			<text fixtext=" [">
				<styles color="gray" font-family="Verdana" font-size="xx-small"/>
			</text>
			<template>
				<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
				<match match="@mappedTo"/>
				<children>
					<xpath allchildren="1">
						<styles color="gray" font-family="Verdana" font-size="xx-small"/>
					</xpath>
				</children>
			</template>
			<text fixtext="]">
				<styles color="gray" font-family="Verdana" font-size="xx-small"/>
			</text>
			<newline/>
		</children>
	</template>
	<template>
		<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
		<match match="n1:folder"/>
		<children>
			<table>
				<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0"/>
				<children>
					<tablebody>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties colspan="3" height="0" width="32"/>
									</tablecol>
									<tablecol>
										<properties height="0" width="708"/>
										<children>
											<image>
												<styles font-family="Verdana" font-size="xx-small"/>
												<properties border="0"/>
												<imagesource>
													<fixtext value="images/folder.gif"/>
												</imagesource>
											</image>
											<template>
												<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
												<match match="@name"/>
												<children>
													<xpath allchildren="1">
														<styles color="black" font-family="Verdana" font-size="xx-small" font-weight="bold"/>
													</xpath>
												</children>
											</template>
											<table>
												<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
												<children>
													<tablebody>
														<children>
															<tablerow>
																<children>
																	<tablecol>
																		<properties height="0" rowspan="2" width="28"/>
																	</tablecol>
																	<tablecol>
																		<properties height="2"/>
																		<children>
																			<xpath>
																				<styles font-family="Verdana" font-size="xx-small"/>
																				<editorproperties adding="mandatory" autoaddname="0" editable="1" markupmode="hide"/>
																				<match match="n1:folder"/>
																			</xpath>
																			<text fixtext=".">
																				<styles font-size="1pt"/>
																			</text>
																			<newline/>
																		</children>
																	</tablecol>
																</children>
															</tablerow>
															<tablerow>
																<children>
																	<tablecol>
																		<properties height="0"/>
																		<children>
																			<xpath>
																				<styles font-family="Verdana" font-size="xx-small"/>
																				<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
																				<match match="n1:file"/>
																			</xpath>
																			<text fixtext=".">
																				<styles font-size="1pt"/>
																			</text>
																		</children>
																	</tablecol>
																</children>
															</tablerow>
														</children>
													</tablebody>
												</children>
											</table>
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
		<match match="n1:rootFolder"/>
		<children>
			<image>
				<styles font-family="Verdana" font-size="xx-small" vertical-align="top" width="26px"/>
				<properties border="0"/>
				<imagesource>
					<fixtext value="images/folder.gif"/>
				</imagesource>
			</image>
			<text fixtext=" "/>
			<text fixtext="/">
				<styles font-family="Verdana" font-weight="bold"/>
			</text>
			<newline/>
			<xpath>
				<match match="n1:folder"/>
			</xpath>
			<table>
				<properties border="0" border-collapse="collapse" cellpadding="0" cellspacing="0"/>
				<children>
					<tablebody>
						<children>
							<tablerow>
								<children>
									<tablecol>
										<properties colspan="3" height="0" width="32"/>
									</tablecol>
									<tablecol>
										<properties height="0" width="461"/>
										<children>
											<table>
												<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
												<children>
													<tablebody>
														<children>
															<tablerow>
																<children>
																	<tablecol>
																		<properties colspan="2" height="0" width="574"/>
																		<children>
																			<xpath>
																				<styles font-family="Verdana" font-size="xx-small"/>
																				<editorproperties adding="mandatory" autoaddname="1" editable="1" markupmode="hide"/>
																				<match match="n1:file"/>
																			</xpath>
																		</children>
																	</tablecol>
																</children>
															</tablerow>
														</children>
													</tablebody>
												</children>
											</table>
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
