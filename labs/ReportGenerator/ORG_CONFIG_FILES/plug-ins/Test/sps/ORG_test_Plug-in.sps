<?xml version="1.0" encoding="UTF-8"?>
<structure version="3" schemafile="C:\_ABN\ORG - Owasp Report Generator\V-Drive\Application (exe)\v0.83\VulnReport_Files\plug-ins\Test\xsd\ORG_Test_Plug-in.xsd" workingxmlfile="" templatexmlfile="" xsltversion="2" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8">
	<nspair prefix="xs" uri="http://www.w3.org/2001/XMLSchema"/>
	<template>
		<match overwrittenxslmatch="/"/>
		<children>
			<text fixtext="ORG TEST Plug-in (for ABN AMRO)">
				<styles font-family="Arial" font-weight="bold"/>
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
										<properties width="141"/>
										<children>
											<text fixtext="Title:">
												<styles font-family="Arial" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="f0f0f0"/>
										<children>
											<template>
												<match match="ORG_Test_PlugIn"/>
												<children>
													<template>
														<match match="@Report_Title"/>
														<children>
															<xpath allchildren="1">
																<styles font-family="Arial" font-size="x-small"/>
															</xpath>
														</children>
													</template>
												</children>
											</template>
										</children>
									</tablecol>
								</children>
							</tablerow>
							<tablerow>
								<children>
									<tablecol>
										<properties width="141"/>
										<children>
											<text fixtext="Path to Xml File with Consolidated data: ">
												<styles font-family="Arial" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="f0f0f0"/>
										<children>
											<template>
												<match match="ORG_Test_PlugIn"/>
												<children>
													<template>
														<match match="PathToXmlFileWithData"/>
														<children>
															<xpath allchildren="1">
																<styles font-family="Arial" font-size="x-small"/>
															</xpath>
														</children>
													</template>
												</children>
											</template>
										</children>
									</tablecol>
								</children>
							</tablerow>
							<tablerow>
								<children>
									<tablecol>
										<properties width="141"/>
										<children>
											<text fixtext="Path to template Powerpoint file:">
												<styles font-family="Arial" font-size="x-small" font-weight="bold"/>
											</text>
										</children>
									</tablecol>
									<tablecol>
										<styles background-color="f0f0f0"/>
										<children>
											<template>
												<match match="ORG_Test_PlugIn"/>
												<children>
													<template>
														<match match="PathToTemplatePowerpointFile"/>
														<children>
															<xpath allchildren="1">
																<styles font-family="Arial" font-size="x-small"/>
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
			<text fixtext=" ">
				<styles font-family="Arial"/>
			</text>
			<newline/>
			<newline/>
			<template>
				<match match="ORG_Test_PlugIn"/>
				<children>
					<template>
						<match match="RISO_Report_Page"/>
						<children>
							<table dynamic="1">
								<properties border="0" width="100%"/>
								<children>
									<tableheader>
										<children>
											<tablerow>
												<children>
													<tablecol>
														<properties align="center" width="305"/>
														<children>
															<text fixtext="PathToRISOXsltFile">
																<styles font-family="Arial" font-size="x-small" font-weight="bold"/>
															</text>
														</children>
													</tablecol>
													<tablecol>
														<properties align="center"/>
														<children>
															<text fixtext="Comment">
																<styles font-family="Arial" font-size="x-small" font-weight="bold"/>
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
														<styles background-color="f0f0f0"/>
														<properties width="305"/>
														<children>
															<template>
																<match match="PathToRISOXsltFile"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="x-small"/>
																	</xpath>
																</children>
															</template>
														</children>
													</tablecol>
													<tablecol>
														<styles background-color="f0f0f0"/>
														<children>
															<template>
																<match match="Comment"/>
																<children>
																	<xpath allchildren="1">
																		<styles font-family="Arial" font-size="x-small"/>
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
			<newline/>
			<newline/>
		</children>
	</template>
	<pagelayout>
		<properties pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="1" paperheight="11in" papermarginbottom="0.79in" papermarginleft="0.6in" papermarginright="0.6in" papermargintop="0.79in" paperwidth="8.5in"/>
	</pagelayout>
</structure>
