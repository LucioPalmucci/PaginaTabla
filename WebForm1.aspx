<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="style.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div runat="server" class="text-center">
                <h1 runat="server" class="w-100">Peliculas Famosas</h1>
                <asp:button onclick="mostrarTabla" class="btn btn-primary" runat="server" Text="Mostrar"></asp:button><br />
                <div runat="server" class="justify-content-center d-flex text-start" Visible="false" id="contTabla">
                    <asp:Literal ID="Tabla" runat="server"/>
                </div>
            </div>
            <br />
            <div class="d-flex justify-content-center">
                <div runat="server" class="text-start me-5 w-25">
                    <h3 runat="server">Agregar Pelicula:</h3>
                    <div runat="server" class="fs-6 w-75" >
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Nombre de la pelicula" />
                        <asp:TextBox ID="txtDirector" runat="server" CssClass="form-control" placeholder="Director de la pelicula" />
                        <asp:TextBox ID="txtAño" runat="server" CssClass="form-control" placeholder="Año de la pelicula" />
                        <asp:TextBox ID="txtGenero" runat="server" CssClass="form-control" placeholder="Genero de la pelicula" />
                        <asp:TextBox ID="txtCalificacion" runat="server" CssClass="form-control" placeholder="Calificación de la pelicula" /><br />
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                    </div>
                </div>
                <div runat="server" class="text-start w-25">
                    <h3 runat="server">Buscar Pelicula:</h3>
                     <div>
                         <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control w-75" placeholder="Buscar pelicula" />
                         <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                         <div runat="server" class="w-75 fs-6 " visible="false" id="contenedor">
                            <asp:TextBox ID="ediTitulo" runat="server" CssClass="form-control" placeholder="Nombre de la pelicula" />
                            <asp:TextBox ID="ediDirector" runat="server" CssClass="form-control" placeholder="Director de la pelicula" />
                            <asp:TextBox ID="ediAño" runat="server" CssClass="form-control" placeholder="Año de la pelicula" />
                            <asp:TextBox ID="ediGenero" runat="server" CssClass="form-control" placeholder="Genero de la pelicula" />
                            <asp:TextBox ID="ediCalificacion" runat="server" CssClass="form-control" placeholder="Calificación de la pelicula" /><br />
                            <asp:Button ID="btnEditar" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
                         </div>
                     </div>
                </div>
            </div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered w-75 fs-7 m-2" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" ReadOnly="false"  />
                        <asp:BoundField DataField="Director" HeaderText="Director" />
                        <asp:BoundField DataField="Anio" HeaderText="Año" />
                        <asp:BoundField DataField="Genero" HeaderText="Genero" />
                        <asp:BoundField DataField="Calificacion" HeaderText="Calificacion" />
                        <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                        <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
