 <%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="SENAI_Jobs.Administrador" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Administrador
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
     <link href="/Style/Administrador.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Sessão Administrativa</h1>
    <form id="FormADM" method="post" runat="server">

        <p>        
            <asp:Button ID="ButtonCadastrarNovoAdministrador" Text="Cadastrar novo Administrador" OnClick="ButtonCadastrarNovoAdministrador_Click" CausesValidation="false" runat="server"></asp:Button>
            <asp:Button ID="ButtonLogout" Text="Logout" OnClick="ButtonLogout_Click" CausesValidation="false" runat="server"></asp:Button>
        </p>
        
        <p>
            <asp:Label ID="LabelLogin" AssociatedControlID="TextBoxLogin" Text="Login" Visible="false" runat="server"></asp:Label>
            <asp:TextBox ID="TextBoxLogin" Visible="false" MaxLength="25" runat="server" />
            <asp:RequiredFieldValidator ID="RFVLogin" ControlToValidate="TextBoxLogin" ErrorMessage="Campo obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
            <asp:Label ID="LabelSenha" AssociatedControlID="TextBoxSenha" Text="Senha" visible="false" runat="server"></asp:Label>
            <asp:TextBox ID="TextBoxSenha" Visible="false" TextMode="Password" MaxLength="25" runat="server" />
            <asp:RequiredFieldValidator ID="RFVSenha" ControlToValidate="TextBoxSenha" ErrorMessage="Campo obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
            <asp:Label ID="LabelMensagem" Visible="false" runat="server"></asp:Label>
        </p>

        <p>
            <asp:Button ID="ButtonConfirmarCadastro" Text="Confirmar Cadastro" Visible="false" OnClick="ButtonConfirmarCadastro_Click" runat="server"></asp:Button>
        </p>

        <p>
        <asp:Label ID="LabelAtivarUsuarios" Text="Ativação de Usuários" runat="server"></asp:Label>
        </p>

        <p>
        <asp:DropDownList ID="DropDownListAlunos" runat="server"><asp:ListItem Value="" Text=""></asp:ListItem></asp:DropDownList>
        <asp:Button ID="ButtonAtivarAluno" Text="Ativar Aluno" OnClick="ButtonAtivarAluno_Click" CausesValidation="false" runat="server"  />
        <asp:DropDownList ID="DropDownListEmpresas" runat="server"><asp:ListItem Value="" Text=""></asp:ListItem></asp:DropDownList>
        <asp:Button ID="ButtonAtivarEmpresa" text="Ativar Empresa" OnClick="ButtonAtivarEmpresa_Click" CausesValidation="false" runat="server"> </asp:Button>   
        </p>

        <p>
          <asp:Label ID="LabelMessage" Visible ="false" Text=""  runat="server"></asp:Label>
        </p>

        <p>
        <asp:Label ID="LabelExclusaoDeAlunos" Text="Exclusão de Usuários" runat="server"></asp:Label>
        </p>

        <p>
        <asp:DropDownList ID="DropDownListExcluirAluno" runat="server"><asp:ListItem Value="" Text=""></asp:ListItem></asp:DropDownList>
        <asp:Button ID="ButtonExcluirAluno" Text="Excluir Aluno" onclick="ButtonExcluirAluno_Click" CausesValidation="false" runat="server"  />
        </p>
        <p>
        <asp:DropDownList ID="DropDownListExcluirEmpresa" runat="server"><asp:ListItem Value="" Text=""></asp:ListItem></asp:DropDownList>
        <asp:Button ID="ButtonExcluirEmpresa" text="Excluir Empresa" onclick="ButtonExcluirEmpresa_Click" CausesValidation="false" runat="server"> </asp:Button>   
        </p>

        <p>
          <asp:Label ID="LabelMensagemExcluir" Visible="false"  runat="server"></asp:Label>
        </p>
        <asp:Label ID="LabelMensagemErro" Visible ="false"  runat="server"></asp:Label>

    </form>
        </div>
</asp:Content>
