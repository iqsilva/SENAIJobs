<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="CadastroEmpresa.aspx.cs" Inherits="SENAI_Jobs.CadastroEmpresa" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Cadastro de Empresas
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/CadastroEmpresa.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Cadastro de Empresas</h1>
    <form id="FormCadastroEmpresa" runat="server">
        <p>
        <img id=" SenaiJobs" src="Images/icone_professor.png"/>
        </p>

        <p>
        <asp:Label ID="LabelMensagem" runat="server" />
        </p>

        <p>
         <asp:Label ID="LabelCNPJ" AssociatedControlID="TextBoxCNPJ" Text="CNPJ" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxCNPJ" MaxLength="18" runat="server" />
         <asp:RequiredFieldValidator ID="RFVCNPJ" ControlToValidate="TextBoxCNPJ" ErrorMessage="O campo CNPJ é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
        <asp:Label ID="LabelLogin" AssociatedControlID="TextBoxLogin" Text="Login" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxLogin" MaxLength="25" runat="server" />
        <asp:RequiredFieldValidator ID="RFVLogin" ControlToValidate="TextBoxLogin" ErrorMessage="O campo Login é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p> 

        <p>
        <asp:Label ID="LabelSenha" AssociatedControlID="TextBoxSenha" Text="Senha" runat="server"></asp:Label> 
        <asp:TextBox ID="TextBoxSenha" TextMode="Password" MaxLength="25" runat="server" />
        <asp:RequiredFieldValidator ID="RFVSenha" ControlToValidate="TextBoxSenha" ErrorMessage="O campo Senha é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelRazaoSocial" AssociatedControlID="TextBoxRazaoSocial" Text="Razão Social" runat="server"></asp:Label> 
         <asp:TextBox ID="TextBoxRazaoSocial" MaxLength="25" runat="server" />
         <asp:RequiredFieldValidator ID="RFVRazaoSocial" ControlToValidate="TextBoxRazaoSocial" ErrorMessage="O campo Razão Social é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelNomeFantasia" AssociatedControlID="TextBoxNomeFantasia" Text="Nome Fantasia" runat="server"></asp:Label> 
         <asp:TextBox ID="TextBoxNomeFantasia" MaxLength="25" runat="server" />
         <asp:RequiredFieldValidator ID="RFVNomeFantasia" ControlToValidate="TextBoxNomeFantasia" ErrorMessage="O campo Nome Fantasia é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelEmail" AssociatedControlID="TextBoxEmail" Text="E-mail" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxEmail" MaxLength="50" runat="server" />
         <asp:RequiredFieldValidator ID="RFVEmail" ControlToValidate="TextBoxEmail" ErrorMessage="O campo E-Mail é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelTelefone" AssociatedControlID="TextBoxTelefone" Text="Telefone" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxTelefone" MaxLength="12" runat="server" />
         <asp:RequiredFieldValidator ID="RFVTelefone" ControlToValidate="TextBoxTelefone" ErrorMessage="O campo Telefone é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelCEP" AssociatedControlID="TextBoxCEP" Text="CEP" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxCEP" MaxLength="9" runat="server" />
         <asp:RequiredFieldValidator ID="RFVCEP" ControlToValidate="TextBoxCEP" ErrorMessage="O campo CEP é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
        
        <p>
         <asp:Label ID="LabelEndereco" AssociatedControlID="TextBoxEndereco" Text="Endereço" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxEndereco" MaxLength="70" runat="server" />
         <asp:RequiredFieldValidator ID="RFVEndereco" ControlToValidate="TextBoxEndereco" ErrorMessage="O campo Endereço é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelBairro" AssociatedControlID="TextBoxBairro" Text="Bairro" runat="server"></asp:Label> 
         <asp:TextBox ID="TextBoxBairro" MaxLength="50" runat="server" />
         <asp:RequiredFieldValidator ID="RFVBairro" ControlToValidate="TextBoxBairro" ErrorMessage="O campo Bairro é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelCidade" AssociatedControlID="TextBoxCidade" Text="Cidade" runat="server"></asp:Label> 
         <asp:TextBox ID="TextBoxCidade" MaxLength="25" runat="server" />
         <asp:RequiredFieldValidator ID="RFVCidade" ControlToValidate="TextBoxCidade" ErrorMessage="O campo Cidade é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelEstado" AssociatedControlID="DropDownEstado" Text="Estado" runat="server"></asp:Label> 
        <asp:DropDownList ID="DropDownEstado" Visible="true" AutoPostBack="false" runat="server">
            <asp:ListItem Value="" Text=""></asp:ListItem><asp:ListItem Value="AC" Text="AC"></asp:ListItem><asp:ListItem Value="AL" Text="AL"></asp:ListItem>
            <asp:ListItem Value="AP" Text="AP"></asp:ListItem><asp:ListItem Value="AM" Text="AM"></asp:ListItem><asp:ListItem Value="BA" Text="BA"></asp:ListItem>
            <asp:ListItem Value="CE" Text="CE"></asp:ListItem><asp:ListItem Value="DF" Text="DF"></asp:ListItem><asp:ListItem Value="ES" Text="ES"></asp:ListItem>
            <asp:ListItem Value="GO" Text="GO"></asp:ListItem><asp:ListItem Value="MA" Text="MA"></asp:ListItem><asp:ListItem Value="MT" Text="MT"></asp:ListItem>
            <asp:ListItem Value="MS" Text="MS"></asp:ListItem><asp:ListItem Value="MG" Text="MG"></asp:ListItem><asp:ListItem Value="PA" Text="PA"></asp:ListItem>
            <asp:ListItem Value="PB" Text="PB"></asp:ListItem><asp:ListItem Value="PR" Text="PR"></asp:ListItem><asp:ListItem Value="PB" Text="PB"></asp:ListItem>
            <asp:ListItem Value="PI" Text="PI"></asp:ListItem><asp:ListItem Value="RJ" Text="RJ"></asp:ListItem><asp:ListItem Value="RN" Text="RN"></asp:ListItem>
            <asp:ListItem Value="RS" Text="RS"></asp:ListItem><asp:ListItem Value="RO" Text="RO"></asp:ListItem><asp:ListItem Value="RR" Text="RR"></asp:ListItem>
            <asp:ListItem Value="SC" Text="SC"></asp:ListItem><asp:ListItem Value="SP" Text="SP"></asp:ListItem><asp:ListItem Value="SE" Text="SE"></asp:ListItem>
            <asp:ListItem Value="TO" Text="TO"></asp:ListItem>

            </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RFVEstado" ControlToValidate="DropDownEstado" ErrorMessage="O campo Estado é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
        <asp:Button ID="ButtonCadastrar" Text="Cadastrar"  OnClick="ButtonCadastrar_Click" runat="server" />
        <asp:Button ID="ButtonVolar" Text="Voltar" OnClick="ButtonVolar_Click" CausesValidation="false" runat="server" />   
    </form>
    </div>
</asp:Content>
