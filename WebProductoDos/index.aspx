<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebProductoDos.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="js/main.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>
     <header>
        <nav class="navbar navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand"><strong>Carniceria</strong></a>
            </div>
        </nav>
    </header>
<body>
    <form id="form1" runat="server">
          <div class="container mt-4 mb-4">
            <div class="row">
                <div class="col">
                </div>
                <div class="col-6 bg-dark p-3" >
                    <nav aria-label="Bienvenido">
                        <ul class="pagination pagination-small mt-3 justify-content-center">
                            <li class="page-item active"><a class="page-link" href="index.aspx">Clientes</a></li>
                            <li class="page-item "><a class="page-link" href="registro-carnicero.aspx">Carniceros</a></l>
                        </ul>
                    </nav>
                 <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Registrate para ordenar</label>                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Nombre</label>
                    <asp:TextBox class="input"  ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Apellido Paterno</label>
                    <asp:TextBox ID="txtApp" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Apellido Materno</label>
                    <asp:TextBox ID="txtApm" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Telefono</label>
                    <asp:TextBox ID="txtTel" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Correo</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox> 
                </div>
                <div class="mb-3">
                    <asp:Button ID="Button1" class="btn btn-primary w-100" runat="server" Text="Registrar" OnClick="Button1_Click" />
                </div>
                </div>
                <div class="col">
                </div>
            </div>
        </div>

                <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    </form>
</body>
</html>
