<?xml version = "1.0"?>
<xsl:stylesheet version = "1.0"
	xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html"/>

<!--
    beretta.xsl   version 0.1   25may05

    XSL stylesheet to convert Beretta / FOSBBWAS xml output into an HTML report.
    This XSL file by Chuck Willis (chuck at securityfoundry dot com)

    Information on the Beretta project can be found at http://www.zfish.co.uk/beretta/

    This file (like the rest of Beretta) is licensed under the Lesser Gnu Public License
    (LGPL) available at http://www.gnu.org/copyleft/lesser.html
-->

<xsl:template match = "report">
<html>
<head>
	<title>
	Beretta Output for Session
	<xsl:value-of select = "header/sessionName"/>
	</title>
<style type="text/css">
      	<xsl:comment>
 TR.title { BACKGROUND-COLOR: lightblue; }
 TR.subtitle { BACKGROUND-COLOR: grey; }
td { border: 1px solid; padding: 4px; }
table { border-collapse: collapse; width: 100% }
body {font-family:arial}
h1  {font-family:arial;font-size:16}
	</xsl:comment>
    </style>
	</head>
<body>
<xsl:apply-templates select="header"/>
<xsl:apply-templates select="body/urlsScanned"/>
<xsl:apply-templates select="body/scanItems" mode="sortByUrl"/>
<xsl:apply-templates select="body/scanItems" mode="sortByPayload"/>

</body>
</html>
</xsl:template>

<xsl:template match = "header">
	<h1> Scan Details</h1>
	<table><tbody>
	
<tr><td>Session Name:</td>
<td><xsl:value-of select = "sessionName"/></td></tr>
<tr><td>Session Description:</td>
<td><xsl:value-of select = "sessionDescription"/></td></tr>

<tr><td>Application:</td>
<td><xsl:value-of select = "application"/></td></tr>
<tr><td>Version:</td>
<td><xsl:value-of select = "version"/></td></tr>
<tr><td>Session ID:</td>
<td><xsl:value-of select = "sessionId"/></td></tr>
<tr><td>Date:</td>
<td><xsl:value-of select = "date"/></td></tr>
<tr><td>Authentication Type:</td>
<td><xsl:value-of select = "authenticationType"/></td></tr>


</tbody>
</table>
</xsl:template>

<xsl:template match = "urlsScanned">
	
	<h1> Urls Scanned
	</h1>
<table><tbody><tr class="title">
<td>URL</td><td>Number of Findings</td></tr>
 <xsl:for-each select="url">
<xsl:sort select="."/>
<xsl:variable name="currenturl" select="."/>
	<tr><td>
<xsl:if test="count(../../scanItems/item[url=$currenturl][not(excludefromreport = 'y')]) &gt; 0">
	<a href="#{generate-id(key('urlkey', string($currenturl)))}">
	<xsl:value-of select = "."/>
	</a>
</xsl:if>
<xsl:if test="count(../../scanItems/item[url=$currenturl][not(excludefromreport = 'y')]) = 0">
	<xsl:value-of select = "."/>
	</xsl:if>

	</td><td>
<xsl:value-of select="count(../../scanItems/item[url=$currenturl][not(excludefromreport = 'y')])" /></td>

</tr>

</xsl:for-each>
</tbody></table>
</xsl:template>

<xsl:key name="item-by-url" match="item" use="url" />


<xsl:template match = "scanItems" mode="sortByUrl">	
	<h1> Scan Results (sorted by URL)
	</h1>	
<xsl:for-each select="item[not(./excludefromreport='y')][count(. | key('item-by-url', url)[1]) = 1]">
		<xsl:sort select="url" />

		URL: <xsl:value-of select = "url"/>
<a name="{generate-id(key('urlkey', string(url)))}"></a>
<br/><br/>
<table><tbody><tr class="title">
<td>Payload</td><td>Signature</td><td>Signature Message</td><td>Field Name</td><td>Severity</td><td>Form Submission</td></tr>
		<xsl:for-each select="key('item-by-url', url)[not(./excludefromreport='y')]">
			<xsl:sort select="payload" />

<tr>
<td>
<a href="#{generate-id(key('payloadkey', string(payload)))}">
<xsl:value-of select = "payload"/>
</a>
</td>
<td><xsl:value-of select = "signature"/></td>
<td><xsl:value-of select = "signatureMessage"/></td>
<td><xsl:value-of select = "fieldName"/></td>
<td><xsl:value-of select = "signatureMessageType"/></td>
<td><xsl:value-of select = "logFormSubmission"/></td>


</tr>
</xsl:for-each>
</tbody>
</table><br/><hr/><br/></xsl:for-each>
</xsl:template>

<xsl:key name="urlkey" match="url" use="."/>
<xsl:key name="payloadkey" match="payload" use="."/>

<xsl:key name="item-by-payload" match="item" use="payload" />

<xsl:template match = "scanItems" mode="sortByPayload">
	<h1> Scan Results (sorted by payload)
	</h1>	
<xsl:for-each select="item[not(./excludefromreport='y')][count(. | key('item-by-payload', payload)[1]) = 1]">
		<xsl:sort select="payload" />
		Payload: <xsl:value-of select = "payload"/>
<a name="{generate-id(key('payloadkey', string(payload)))}"></a>
<br/><br/>
<table><tbody><tr class="title">
<td>URL</td><td>Signature</td><td>Signature Message</td><td>Field Name</td><td>Severity</td><td>Form Submission</td></tr>
		<xsl:for-each select="key('item-by-payload', payload)[not(./excludefromreport='y')]">
			<xsl:sort select="url" />
<xsl:variable name="currenturl" select="url"/>
<tr><td>
<a href="#{generate-id(key('urlkey', string(url)))}"><xsl:value-of select = "url"/></a> 
</td>
<td><xsl:value-of select = "signature"/></td>
<td><xsl:value-of select = "signatureMessage"/></td>
<td><xsl:value-of select = "fieldName"/></td>
<td><xsl:value-of select = "signatureMessageType"/></td>
<td><xsl:value-of select = "logFormSubmission"/></td>
</tr>
</xsl:for-each>
</tbody>
</table><br/><hr/><br/></xsl:for-each>
	<br/>	
</xsl:template>


<!--

<xsl:template name="parsePath">
  <xsl:param name="path" />
  <xsl:param name="element" select="/report" />
  <xsl:variable name="step">
    <xsl:choose>
      <xsl:when test="contains($path, '/')">
        <xsl:value-of select="substring-before($path, '/')" />
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$path" />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:variable>


  <xsl:variable name="elementName"
    select="substring-before($step, '|')" />
  <xsl:variable name="title"
    select="substring-after($step, '|')" />


  <xsl:variable name="newElement"
    select="$element/*[name() = $elementName][@title = $title]" />


  <xsl:choose>
    <xsl:when test="contains($path, '/')">
      <xsl:call-template name="parsePath">
        <xsl:with-param name="path"
          select="substring-after($path, '/')" />
        <xsl:with-param name="element" select="$newElement" />
      </xsl:call-template>
    </xsl:when>
    <xsl:otherwise>
      <xsl:value-of select="generate-id($newElement)" />
    </xsl:otherwise>
  </xsl:choose>
</xsl:template> -->



  <!--These are some alternative formating options, not used for now -->
<xsl:template match = "scanItems" mode="sortByUrlSeparateTables">
	
	<h1> Scanitems Output (sorted by URL)
	</h1>
	<p>
	
 <xsl:for-each select="item">
<xsl:sort select="url"/>
	<table><tbody>
<tr><td>URL:</td>
<td><xsl:value-of select = "url"/></td></tr>
<tr><td>Payload:</td>
<td><xsl:value-of select = "payload"/></td></tr>
<tr><td>Signature:</td>
<td><xsl:value-of select = "signature"/></td></tr>
<tr><td>Signature Message:</td>
<td><xsl:value-of select = "signatureMessage"/></td></tr>
<tr><td>Severity:</td>
<td><xsl:value-of select = "signatureMessageType"/></td></tr>

</tbody>
</table>
	<br/>
</xsl:for-each>


	</p>
</xsl:template>

<xsl:template match = "scanItems" mode="sortByPayloadSeparateTables">
	
	<h1> Scanitems Output (sorted by Payload)
	</h1>
	<p>
	
 <xsl:for-each select="item">
<xsl:sort select="payload"/>
	<table><tbody>
<tr><td>URL:</td>
<td><xsl:value-of select = "url"/></td></tr>
<tr><td>Payload:</td>
<td><xsl:value-of select = "payload"/></td></tr>
<tr><td>Signature:</td>
<td><xsl:value-of select = "signature"/></td></tr>
<tr><td>Signature Message:</td>
<td><xsl:value-of select = "signatureMessage"/></td></tr>
<tr><td>Severity:</td>
<td><xsl:value-of select = "signatureMessageType"/></td></tr>

</tbody>
</table>


	<br/>
	
	
</xsl:for-each>

	</p>
</xsl:template>




<xsl:template match = "formSubmissions">
	
	<h1> Form Submissions 
	</h1>
	<p>
	
 <xsl:for-each select="item">

	<table><tbody>
<tr><td>URL:</td>
<td><xsl:value-of select = "submissionUrl"/></td></tr>
<tr><td>Submission:</td>
<td><xsl:value-of select = "submissionData"/></td></tr>
</tbody>
</table>


	<br/>
	
	
</xsl:for-each>

	</p>
</xsl:template>

</xsl:stylesheet>
