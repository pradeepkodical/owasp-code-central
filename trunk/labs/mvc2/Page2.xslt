<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <xsl:apply-templates select="Model1"/>
  </xsl:template>
  
  <xsl:template match="Model1">
    <div style="font-weight: bold;">Page 2</div>
    <table>
      <tr>
        <td>X</td>
        <td>*</td>
        <td>Y</td>
        <td>= ?</td>
      </tr>
      <tr>
        <td><xsl:value-of select="X"/></td>
        <td>*</td>
        <td><xsl:value-of select="Y"/></td>
        <td>= <xsl:value-of select="Product"/></td>
      </tr>
    </table>
  </xsl:template>

</xsl:stylesheet>

  