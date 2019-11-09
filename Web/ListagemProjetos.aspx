<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Async="true" CodeBehind="ListagemProjetos.aspx.cs" Inherits="Web.ListagemProjetos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1>Projetos</h1>
            <p class="lead">Cadastro de Projetos da Semana do Industrial</p>
        </div>
        <fieldset>
            <legend>Cadastro</legend>
            <div class="row form-group">
                <div class="col-sm-3">
                    ID
                </div>

                <div class="col-sm-9">
                    <asp:TextBox ID="txtId" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-3">
                    Nome do Projeto
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtNomeProjeto" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-3">
                    Sala
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtSala" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-3">
                    Turma
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtTurma" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-3">
                    Orientadores
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtOrientadores" runat="server"></asp:TextBox>
                </div>
            </div>
        </fieldset>
        <div class="row form-group">
            <div class="col-sm-12">
                <asp:Label ID="lblMensagem" ForeColor="Green" Font-Bold="true" runat="server" Text=""></asp:Label>

            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-3"></div>
            <div class="col-sm-9">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvProjetos" runat="server"
                        DataKeyNames="id" AutoGenerateColumns="false"
                        CssClass="table table-bordered tablecondensed" OnSelectedIndexChanged="gvProjetos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Nome do Projeto" DataField="Nome" />
                            <asp:BoundField HeaderText="Sala" DataField="Sala" />
                            <asp:BoundField HeaderText="Turma" DataField="Turma" />
                            <asp:BoundField HeaderText="Orientadores" DataField="Orientadores" />
                            <asp:CommandField ButtonType="Button" SelectText="Selecionar" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
