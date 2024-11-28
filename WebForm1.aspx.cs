using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransformXmlToHtml();
            generateTable();
            if (Request.QueryString["eliminar"] != null && !IsPostBack)
            {
                string titulo = Request.QueryString["eliminar"];
                eliminarPelicula(titulo);
            }
            if (Request.QueryString["vista"] != null && !IsPostBack)
            {
                string titulo = Request.QueryString["vista"];
                vistaPelicula(titulo);
            }
            if (!IsPostBack)
            {
                contTabla.Visible = true;
            }
        }

        public void mostrarTabla(object sender, EventArgs e)
        {
            if (contTabla.Visible == true) contTabla.Visible = false;
            else contTabla.Visible = true;
        }

        private void TransformXmlToHtml()
        {
            string xmlPath = Server.MapPath("~/App_Data/peliculas.xml");
            string xsltPath = Server.MapPath("~/App_Data/tabla.xslt");

            //Las 2 variables para cada archivo
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltPath);

            using (StringWriter sw = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sw))
            {
                // Aplica la transformación
                xslt.Transform(xmlDoc, writer);

                // Muestra el resultado en el String
                Tabla.Text = sw.ToString();
            }
            generateTable();
        }
        public void btnAgregar_Click(object sender, EventArgs e)
        {
            string xmlPath = Server.MapPath("~/App_Data/peliculas.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            XmlNode peliculas = xmlDoc.SelectSingleNode("/Peliculas");
            XmlNode pelicula = xmlDoc.CreateElement("Pelicula");
            XmlNode titulo = xmlDoc.CreateElement("Titulo");
            XmlNode director = xmlDoc.CreateElement("Director");
            XmlNode genero = xmlDoc.CreateElement("Genero");
            XmlNode año = xmlDoc.CreateElement("Anio");
            XmlNode calificacion = xmlDoc.CreateElement("Calificacion");
            XmlNode borrar = xmlDoc.CreateElement("Borrar");
            XmlNode marcar = xmlDoc.CreateElement("Marcar");
            XmlNode vista = xmlDoc.CreateElement("Estado");

            titulo.InnerText = txtTitulo.Text.Trim();
            director.InnerText = txtDirector.Text.Trim();
            año.InnerText = txtAño.Text.Trim();
            genero.InnerText = txtGenero.Text.Trim();
            calificacion.InnerText = txtCalificacion.Text.Trim();
            borrar.InnerText = "🗑️";
            marcar.InnerText = "👁️";
            vista.InnerText = "No vista";

            pelicula.AppendChild(titulo);
            pelicula.AppendChild(director);
            pelicula.AppendChild(año);
            pelicula.AppendChild(genero);
            pelicula.AppendChild(calificacion);
            pelicula.AppendChild(vista);
            peliculas.AppendChild(pelicula);

            xmlDoc.Save(xmlPath);
            TransformXmlToHtml();
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            string xmlPath = Server.MapPath("~/App_Data/peliculas.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNodeList peliculas = xmlDoc.SelectNodes("/Peliculas/Pelicula");
            foreach (XmlNode pelicula in peliculas)
            {
                if (pelicula["Titulo"].InnerText == txtBuscar.Text.Trim())
                {
                    contenedor.Visible = true;
                    ediTitulo.Text = pelicula["Titulo"].InnerText;
                    ediDirector.Text = pelicula["Director"].InnerText;
                    ediAño.Text = pelicula["Anio"].InnerText;
                    ediGenero.Text = pelicula["Genero"].InnerText;
                    ediCalificacion.Text = pelicula["Calificacion"].InnerText;
                }
            }
        }

        public void btnEditar_Click(object sender, EventArgs e)
        {
            string xmlPath = Server.MapPath("~/App_Data/peliculas.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNodeList peliculas = xmlDoc.SelectNodes("/Peliculas/Pelicula");
            foreach (XmlNode pelicula in peliculas)
            {
                if (pelicula["Titulo"].InnerText == txtBuscar.Text.Trim())
                {
                    pelicula["Titulo"].InnerText = ediTitulo.Text.Trim();
                    pelicula["Director"].InnerText = ediDirector.Text.Trim();
                    pelicula["Anio"].InnerText = ediAño.Text.Trim();
                    pelicula["Genero"].InnerText = ediGenero.Text.Trim();
                    pelicula["Calificacion"].InnerText = ediCalificacion.Text.Trim();
                }
            }
            xmlDoc.Save(xmlPath);
            TransformXmlToHtml();
        }
        public void eliminarPelicula(string titulo)
        {
            string xmlPath = Server.MapPath("~/App_Data/peliculas.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            XmlNode pelicula = xmlDoc.SelectSingleNode($"/Peliculas/Pelicula[Titulo='{titulo}']");
            pelicula.ParentNode.RemoveChild(pelicula);
            xmlDoc.Save(xmlPath);
            TransformXmlToHtml();
        }
        private void vistaPelicula(string titulo)
        {
            string xmlPath = Server.MapPath("~/App_Data/peliculas.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            XmlNode pelicula = xmlDoc.SelectSingleNode($"/Peliculas/Pelicula[Titulo='{titulo}']");
            if(pelicula["Estado"].InnerText == "Vista") pelicula["Estado"].InnerText = "No vista";
            else pelicula["Estado"].InnerText = "Vista";

            xmlDoc.Save(xmlPath);
           TransformXmlToHtml();

        }

        public void generateTable()
        {
            string xmlPath = Server.MapPath("~/App_Data/peliculas.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(xmlPath);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            generateTable();
        }
    }
}