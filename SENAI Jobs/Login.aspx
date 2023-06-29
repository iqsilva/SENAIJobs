<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SENAI_Jobs.Login" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Login
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/Login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Login</h1>

        <form id="FormLogin" method="post" runat="server">
            <img id=" SenaiJobs" src="Images/SenaiJobs.jpg" height="100" width="175" />
            <p>
                <asp:Label ID="LabelMensagem" runat="server" /></p>

            <p>
                <asp:Label ID="LabelNome" AssociatedControlID="TextBoxNome" Text="Usuário" runat="server"></asp:Label>
                <asp:TextBox ID="TextBoxNome" MaxLength="25" runat="server" />
                <asp:RequiredFieldValidator ID="RFVNome" ControlToValidate="TextBoxNome" ErrorMessage="O campo Login é obrigatório." runat="server"></asp:RequiredFieldValidator>
            </p>

            <p>
                <asp:Label ID="LabelSenha" AssociatedControlID="TextBoxSenha" Text="Senha" runat="server"></asp:Label>
                <asp:TextBox ID="TextBoxSenha" TextMode="Password" MaxLength="25" runat="server" />
                <asp:RequiredFieldValidator ID="RFVSenha" ControlToValidate="TextBoxSenha" ErrorMessage="O campo Senha é obrigatório." runat="server"></asp:RequiredFieldValidator>
            </p>

            <asp:Button ID="ButtonLogin" Text="Login" OnClick="ButtonLogin_Click" runat="server" />

            <asp:LinkButton ID="LinkButtonCadastrar" Text="Cadastrar" CausesValidation="false" OnClick="LinkButtonCadastrar_Click" runat="server" />

            <asp:DropDownList ID="DropDownTipo" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownTipo_SelectedIndexChanged" runat="server">
                <asp:ListItem Value="" Text=""></asp:ListItem>
                <asp:ListItem Value="Aluno" Text="Aluno"></asp:ListItem>
                <asp:ListItem Value="Empresa" Text="Empresa"></asp:ListItem>
            </asp:DropDownList>
            <p>
                <asp:LinkButton ID="LinkButtonSenha" Text="Esqueceu a senha?" CausesValidation="false" OnClick="LinkButtonSenha_Click" runat="server" />
                <asp:DropDownList ID="DropDownTipo2" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownTipo2_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="" Text=""></asp:ListItem>
                    <asp:ListItem Value="Aluno" Text="Aluno"></asp:ListItem>
                    <asp:ListItem Value="Empresa" Text="Empresa"></asp:ListItem>

                </asp:DropDownList>
            </p>
            
        </form>
    </div>
</asp:Content>
