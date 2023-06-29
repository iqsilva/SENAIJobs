<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="EmpresaEsqueceuSenha.aspx.cs" Inherits="SENAI_Jobs.EmpresaEsqueceuSenha" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Redefinição de Senha
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Redefinição de Senha</h1>
        <form id="FormLogin" method="post" runat="server">
            <p>
        <asp:Label ID="LabelLogin" Text="Login" AssociatedControlID="TextBoxLogin" runat="server"  ></asp:Label>
        <asp:TextBox ID="TextBoxLogin" runat="server" ></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="LabelCNPJ" Text="CNPJ"  AssociatedControlID="TextBoxCNPJ" runat="server"></asp:Label>
            <asp:TextBox ID="TextBoxCNPJ" MaxLength="18" runat="server" ></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="LabelNovaSenha" Text="Nova Senha"  AssociatedControlID="TextBoxNovaSenha" runat="server"></asp:Label>
            <asp:TextBox ID="TextBoxNovaSenha" TextMode="Password" MaxLength="25" runat="server" ></asp:TextBox>
            </p>
            <asp:Label ID="LabelConfirmaSenha" Text="Confirmar Senha"  AssociatedControlID="TextBoxConfirmaSenha" runat="server"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmaSenha" TextMode="Password" MaxLength="25" runat="server" ></asp:TextBox>
            <p>
                <asp:Button ID="ButtonAlterarSenha" Text="Alterar" OnClick="ButtonAlterarSenha_Click" runat="server" />
                <asp:Button ID="VoltarLogin" Text="Voltar" OnClick="VoltarLogin_Click"  runat="server" />
            </p>
            <p>
                <asp:Label ID="LabelMensagem" Text="" runat="server"></asp:Label>
            </p>
        </form>
    </div>
</asp:Content>
