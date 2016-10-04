<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>

<!DOCTYPE html>

<html lang="es-es">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 536px">
            <asp:GridView OnRowCommand="grdUsuarios_RowCommand" ID="grdUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="codUsuario" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField CommandName="editUsuario" Text="Editar" ControlStyle-CssClass="btn btn-info">
                        <ControlStyle CssClass="btn btn-info" />
                    </asp:ButtonField>
                    <asp:ButtonField CommandName="borrarUsuario" Text="Borrar" ControlStyle-CssClass="btn btn-danger">
                        <ControlStyle CssClass="btn btn-danger" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="codUsuario" Visible="False" />
                </Columns>
            </asp:GridView>

        </div>
    </form>

</body>
</html>
