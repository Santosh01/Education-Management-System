<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	
	<xsl:template match="/">
		<html>
			<body>				
				<table   width="100%">
					<xsl:for-each select="data/Table">						
						<tr>
							<xsl:variable name="FriendID" select="NameId"/>
              <td style="width:100%" align="left"  onclick="return Edit('{ $FriendID }');">
                <xsl:value-of select="Name" />
              </td>
            </tr>
          </xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>