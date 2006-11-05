<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ipo="http://www.altova.com/IPO" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:n1="http://www.xmlspy.com/schemas/orgchart" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
    <xsl:output version="1.0" encoding="UTF-8" indent="no" omit-xml-declaration="no" media-type="text/html" />
    <xsl:template match="/">
        <html>
            <head>
                <title />
            </head>
            <body>
                <br />
                <xsl:for-each select="n1:SiteGenerator">
                    <xsl:for-each select="n1:site">
                        <xsl:apply-templates select="n1:folder" />
                    </xsl:for-each>
                </xsl:for-each>
                <br />
            </body>
        </html>
    </xsl:template>
    <xsl:template match="n1:folder">
        <br />Folder Name:&#160;&#160; <br />
        <table border="1" width="100%">
            <tbody>
                <tr>
                    <td width="91">Folder Name:</td>
                    <td style="background-color:#F0F0F0; ">
                        <xsl:for-each select="@name">
                            <xsl:value-of select="." />
                        </xsl:for-each>
                    </td>
                    <td>mapped to:</td>
                    <td style="background-color:#F0F0F0; ">
                        <xsl:for-each select="@defaultPage">
                            <xsl:value-of select="." />
                        </xsl:for-each>
                    </td>
                </tr>
                <tr>
                    <td width="91">SubFolders</td>
                    <td colspan="3">
                        <xsl:apply-templates select="n1:folder" />
                    </td>
                </tr>
                <tr>
                    <td width="91">Files in Folder:</td>
                    <td colspan="3" />
                </tr>
            </tbody>
        </table>
        <br />
    </xsl:template>
</xsl:stylesheet>
