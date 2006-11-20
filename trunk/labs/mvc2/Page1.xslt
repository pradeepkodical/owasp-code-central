<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <xsl:apply-templates select="Model1"/>
  </xsl:template>
  
  <xsl:template match="Model1">
    <div style="font-weight: bold;">Page 1</div>
    <table>
      <tr>
        <td>X:</td>
        <td><xsl:value-of select="X"/></td>
      </tr>
      <tr>
        <td>Y:</td>
        <td><xsl:value-of select="Y"/></td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>

  