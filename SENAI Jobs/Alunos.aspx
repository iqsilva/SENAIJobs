<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="Alunos.aspx.cs" Inherits="SENAI_Jobs.Alunos" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Alunos
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/Aluno.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">

     <div id="Centro">
        <h1>Perfil do Aluno</h1>
        
        <form id="FormAluno" method="post" runat="server">
            <asp:Button ID="ButtonPerfil" Text="Perfil" onclick="ButtonPerfil_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonHabilidades" Text="Habilidades" onclick="ButtonHabilidades_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonIdioma" Text="Idioma" onclick="ButtonIdioma_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonEscolaridade" Text="Escolaridade" onclick="ButtonEscolaridade_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonExperienciaProfissional" Text="Experiência Profissional" onclick="ButtonExperienciaProfissional_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonVagas" Text="Vagas" onclick="ButtonVagas_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonLogout" Text="Logout" onclick="ButtonLogout_Click" CausesValidation="false" runat="server" />
        <p>
         <asp:Label ID="LabelMatricula" AssociatedControlID="TextBoxMatricula" Text="Matrícula" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxMatricula" Enabled="false" runat="server" />
         <asp:RequiredFieldValidator ID="RFVMatricula" ControlToValidate="TextBoxMatricula" ErrorMessage="O campo Matricula é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
          <asp:Label ID="LabelLogin" AssociatedControlID="TextBoxLogin" Text="Login" runat="server"></asp:Label>
          <asp:TextBox ID="TextBoxLogin" Enabled="false" MaxLength="25" runat="server" />
          <asp:RequiredFieldValidator ID="RFVLogin" ControlToValidate="TextBoxLogin" ErrorMessage="O campo Login é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
          <asp:Label ID="LabelCPF" AssociatedControlID="TextBoxCPF" Text="CPF" runat="server"></asp:Label>   
          <asp:TextBox ID="TextBoxCPF" Enabled="false" MaxLength="14" runat="server" />
          <asp:RequiredFieldValidator ID="RFVCPF" ControlToValidate="TextBoxCPF" ErrorMessage="O campo CPF é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
        
        <p>
          <asp:Label ID="LabelNome" AssociatedControlID="TextBoxNome" Text="Nome" runat="server"></asp:Label> 
          <asp:TextBox ID="TextBoxNome" Enabled="false" MaxLength="50" runat="server" />
          <asp:RequiredFieldValidator ID="RFVNome" ControlToValidate="TextBoxNome" ErrorMessage="O campo Nome é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelEmail" AssociatedControlID="TextBoxEmail" Text="E-mail" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxEmail" Enabled="false" MaxLength="50" runat="server" />
         <asp:RequiredFieldValidator ID="RFVEmail" ControlToValidate="TextBoxEmail" ErrorMessage="O campo E-mail é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelTelefone" AssociatedControlID="TextBoxTelefone" Text="Telefone" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxTelefone" Enabled="false" MaxLength="12" runat="server" />
         <asp:RequiredFieldValidator ID="RFVTelefone" ControlToValidate="TextBoxTelefone" ErrorMessage="O campo Telefone é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
        
        <p>
            <asp:Label ID="LabelGenero" AssociatedControlID="RadioButtonMasculino" Text="Gênero" runat="server"></asp:Label>
            <span id="SpanGenero">
                <asp:Label ID="LabelMasculino" AssociatedControlID="RadioButtonMasculino" Text="Masculino" runat="server"></asp:Label>
                <asp:RadioButton ID="RadioButtonMasculino" GroupName="Genero" Enabled="false" runat="server" />
         
                <asp:Label ID="LabelFeminino" AssociatedControlID="RadioButtonFeminino" Text="Feminino" runat="server"></asp:Label>
                <asp:RadioButton ID="RadioButtonFeminino" GroupName="Genero" Enabled="false" runat="server" />
            </span>
        </p>
        
        <p>
         <asp:Label ID="LabelCurso" AssociatedControlID="TextBoxCurso" Text="Curso" runat="server"></asp:Label> 
         <asp:TextBox ID="TextBoxCurso" Enabled="false" MaxLength="25" runat="server" />
         <asp:RequiredFieldValidator ID="RFVCurso" ControlToValidate="TextBoxCurso" ErrorMessage="O campo Curso é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
         
        <p>
         <asp:Label ID="LabelEndereco" AssociatedControlID="TextBoxEndereco" Text="Endereço" runat="server"></asp:Label> 
         <asp:TextBox ID="TextBoxEndereco" Enabled="false" MaxLength="70" runat="server" />
         <asp:RequiredFieldValidator ID="RFVEndereco" ControlToValidate="TextBoxEndereco" ErrorMessage="O campo Endereço é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelBairro" AssociatedControlID="TextBoxBairro" Text="Bairro" runat="server"></asp:Label>    
         <asp:TextBox ID="TextBoxBairro" Enabled="false" MaxLength="50" runat="server" />
         <asp:RequiredFieldValidator ID="RFVBairro" ControlToValidate="TextBoxBairro" ErrorMessage="O campo Bairro é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
        
        <p>
         <asp:Label ID="LabelCidade" AssociatedControlID="TextBoxCidade" Text="Cidade" runat="server"></asp:Label>  
         <asp:TextBox ID="TextBoxCidade" Enabled="false" MaxLength="25" runat="server" />
         <asp:RequiredFieldValidator ID="RFVCidade" ControlToValidate="TextBoxCidade" ErrorMessage="O campo Cidade é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
        
        <p>
         <asp:Label ID="LabelEstado" AssociatedControlID="DropDownEstado" Text="Estado" runat="server"></asp:Label> 
        <asp:DropDownList ID="DropDownEstado" Visible="true" AutoPostBack="false" Enabled="false" runat="server">
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
        
        <p>
         <asp:Label ID="LabelDataNascimento" AssociatedControlID="TextBoxDataNascimento" Text="Data de Nascimento" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxDataNascimento" MaxLength="10" Enabled="false" runat="server" />
         <asp:RequiredFieldValidator ID="RFVDataNascimento" ControlToValidate="TextBoxDataNascimento" ErrorMessage="O campo Data de Nascimento é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
          
         <asp:Button ID="ButtonAlterar" Text="Alterar" onclick="ButtonAlterar_Click" CausesValidation="false" runat="server" /> 
         <asp:Button ID="ButtonSalvar" Text="Salvar" onclick="ButtonSalvar_Click" Visible="false" runat="server" />
       <p>
           <asp:Label ID="LabelMensagemaluno" visible="false" runat="server"></asp:Label>
       </p>
             </form>
      </div>

</asp:Content>
