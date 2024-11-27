<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="html" indent="yes"/>
    <xsl:param name="page" select="1" />
    <xsl:param name="pageSize" select="6"/>
    <xsl:template match="/">
        <html>
            <head>
                <link rel="stylesheet" type="text/css" href="/style.css" />
                <script type="text/javascript">
                    function eliminarPelicula(id) {
                        window.location.href = 'WebForm1.aspx?eliminar=' + id;
                    }
					function vistaPelicula(id) {
                        window.location.href = 'WebForm1.aspx?vista=' + id;
                    }
                </script>
            </head>
            <body>
                <table runat="server" id="tabla">
                    <tr>
                        <th>Titulo</th>
                        <th>Director</th>
                        <th>Año</th>
                        <th>Genero</th>
                        <th>Calificación</th>
                        <th>Eliminar</th>
						<th>Marcar</th>
						<th>Estado</th>
                    </tr>
                    <xsl:for-each select="Peliculas/Pelicula">
                        <tr>
                            <td><xsl:value-of select="Titulo"/></td>
                            <td><xsl:value-of select="Director"/></td>
                            <td><xsl:value-of select="Anio"/></td>
                            <td><xsl:value-of select="Genero"/></td>
                            <td><xsl:value-of select="Calificacion"/></td>
                            <td><button type="button" onclick="eliminarPelicula('{Titulo}')">🗑️</button></td>
							<td><button type="button" onclick="vistaPelicula('{Titulo}')">👁️</button></td>
							<td><xsl:value-of select="Estado"/></td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
