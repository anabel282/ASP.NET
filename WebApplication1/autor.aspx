<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="autor.aspx.cs" Inherits="WebApplication1.Autor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous" />
    <script src="http://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager" />
        <div>
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/index.aspx" Text="Pagina principal" Value="Pagina principal"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" Text="Crear Autor" ID="btnCrearAutor" OnClick="btnCrearAutor_Click" />
                    <asp:GridView ID="grdv_autores" DataKeyNames="codAutor" OnRowCommand="grdv_autores_RowCommand" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" Visible="true" />
                            <asp:BoundField DataField="codAutor" HeaderText="codAutor" Visible="false" />
                            <asp:ButtonField CommandName="editarAutor" Text="Editar" ControlStyle-CssClass="btn btn-info">
                                <ControlStyle CssClass="btn btn-info" />
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="borrarAutor" Text="Borrar" ControlStyle-CssClass="btn btn-danger">
                                <ControlStyle CssClass="btn btn-danger" />
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="editModalLabel">Formulario</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label runat="server" ID="lblIdAutor" Visible="true" Text="">Nombre:</asp:Label>
                            <asp:TextBox runat="server" ID="txtNombreAutor" Text=""></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnGuardarAutor" OnClick="btnGuardarAutor_Click" CssClass="btn btn-success" Text="Guardar" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="borrarModal" tabindex="-1" role="dialog" aria-labelledby="borrarModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="borrarModalLabel">Borrar</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label runat="server" ID="lblMensaje" Text="¿Esta seguro de que desea borrarlo?"></asp:Label>
                            <asp:TextBox runat="server" ID="txtIdAutor" Enabled="false" Visible="false"></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            <asp:Button runat="server" ID="btnBorrar" OnClick="btnBorrar_Click" Text="Borrar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
