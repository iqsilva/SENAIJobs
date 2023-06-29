<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="ExperienciasProfissionais.aspx.cs" Inherits="SENAI_Jobs.ExperienciasProfissionais" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Experiência Profissional
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/ExperienciaProfissional.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
     <div id="Centro">
        <h1>Experiência Profissional</h1>
        <form id="FormExperienciaProfissional" method="post" runat="server">
        
            <table id="TableExperiencias" runat="server">
                <caption>Experiências Profissionais já cadastradas</caption>
            
                <thead>
                    <tr>
                        <th>Matrícula</th>
                        <th>Nome da Empresa</th>
                        <th>Anos de Experiência</th>
                        <th>Cargo</th>
                        <th>Descrição</th>
                    </tr>
                </thead>

            </table>

        <p>
            <asp:Label ID="LabelMatriculaAluno" AssociatedControlID="TextBoxMatriculaAluno" Text="Matrícula do Aluno" runat="server"></asp:Label>
          <asp:TextBox ID="TextBoxMatriculaAluno" runat="server" />
          <asp:RequiredFieldValidator ID="RFVMatriculaAluno" ControlToValidate="TextBoxMatriculaAluno" ErrorMessage="O campo Matrícula do Aluno é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
          <asp:Label ID="LabelNomeEmpresa" AssociatedControlID="TextBoxNomeEmpresa" Text="Nome da Empresa" runat="server"></asp:Label>
          <asp:TextBox ID="TextBoxNomeEmpresa" MaxLength="20" runat="server" />
          <asp:RequiredFieldValidator ID="RFVNomeEmpresa" ControlToValidate="TextBoxNomeEmpresa" ErrorMessage="O campo Nome da Empresa é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelAnosExperiencia" AssociatedControlID="TextBoxAnosExperiencia" Text="Anos de Experiência" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxAnosExperiencia" MaxLength="10" runat="server" />
         <asp:RequiredFieldValidator ID="RFVAnosExperiencia" ControlToValidate="TextBoxAnosExperiencia" ErrorMessage="O campo Anos de Experiência é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
        
        <p>
         <asp:Label ID="LabelCargo" AssociatedControlID="TextBoxCargo" Text="Cargo" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxCargo" MaxLength="50" runat="server" />
         <asp:RequiredFieldValidator ID="RFVCargo" ControlToValidate="TextBoxCargo" ErrorMessage="O campo Cargo é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelDescricao" AssociatedControlID="TextBoxDescricao" Text="Descrição" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxDescricao" MaxLength="50" runat="server" />
         <asp:RequiredFieldValidator ID="RFVDescricao" ControlToValidate="TextBoxDescricao" ErrorMessage="O campo Descrição é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>
             <asp:Label ID="LabelMensagem" Visible="false" runat="server"></asp:Label>

          <asp:Button ID="ButtonAdicionar" Text="Adicionar" OnClick="ButtonAdicionar_Click" runat="server" />
          <asp:Button ID="ButtonExcluir" Text="Excluir" OnClick="ButtonExcluir_Click" CausesValidation="false" runat="server" />
          <asp:Button ID="ButtonNaoTenho" Text="Não Tenho" OnClick="ButtonNaoTenho_Click" CausesValidation="false" runat="server" />
          <asp:Button ID="ButtonFinalizar" Text="Finalizar" onclick="ButtonFinalizar_Click" CausesValidation="false" runat="server" />
          <asp:Button ID="ButtonVoltar" Text="Voltar" onclick="ButtonVoltar_Click" CausesValidation="false" runat="server" />
          <asp:Button ID="ButtonCancelar" Text="Cancelar" onclick="ButtonCancelar_Click" CausesValidation="false" runat="server" />
             
        </form>
    </div>
</asp:Content>