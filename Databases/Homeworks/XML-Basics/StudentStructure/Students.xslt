<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:st="urn:students"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt" 
                exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

  <xsl:template match="st:students">
    <html>
      <body>
        <h2>Students</h2>
        <table border="2">
          <tr bgcolor="#9acd32">
            <th>Name</th>
            <th>Sex</th>
            <th>Birth date</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty number</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="st:student">
            <tr>
              <td>
                <xsl:value-of select="st:name"/>
              </td>
              <td>
                <xsl:value-of select="st:sex"/>
              </td>
              <td>
                <xsl:value-of select="st:birth_date"/>
              </td>
              <td>
                <xsl:value-of select="st:phone"/>
              </td>
              <td>
                <xsl:value-of select="st:email"/>
              </td>
              <td>
                <xsl:value-of select="st:course"/>
              </td>
              <td>
                <xsl:value-of select="st:specialty"/>
              </td>
              <td>
                <xsl:value-of select="st:faculty_number"/>
              </td>
              <td>
                <table border="1">
                    <tr bgcolor="#aaaaaa">
                      <td>Name</td>
                      <td>Tutor</td>
                      <td>Score</td>
                    </tr>
                  <xsl:for-each select="st:exams/st:exam">
                    <tr>
                      <td>
                        <xsl:value-of select="st:name"/>
                      </td>
                      <td>
                        <xsl:value-of select="st:tutor"/>
                      </td>
                      <td>
                        <xsl:value-of select="st:score"/> 
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
