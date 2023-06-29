<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="ExcluirExperiencia.aspx.cs" Inherits="SENAI_Jobs.ExcluirExperiencia" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Excluir Experiência Profissional
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/ExcluirExperiencia.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Excluir Experiência Profissional</h1>
        <form id="FormExcluirExperiencia" method="post" runat="server">
            <p>
                <asp:Label ID="LabelExperiencia" AssociatedControlID="DropDownListExperiencia" Text="Selecionar Experiencia" runat="server"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownListExperiencia"  AutoPostBack="true" OnSelectedIndexChanged="DropDownListExperiencia_SelectedIndexChanged" runat="server"></asp:DropDownList>
        </p>

        <p>
          <asp:Label ID="LabelMatriculaAluno" AssociatedControlID="TextBoxMatriculaAluno" Text="Matrícula do Aluno" runat="server"></asp:Label>
          <asp:TextBox ID="TextBoxMatriculaAluno"  runat="server" />
        </p>
        <br />
        <p>
          <asp:Label ID="LabelNomeEmpresa" AssociatedControlID="TextBoxNomeEmpresa" Text="Nome da Empresa" runat="server"></asp:Label>
          <asp:TextBox ID="TextBoxNomeEmpresa" MaxLength="20" runat="server" />
        </p>
        <br />
        <p>
         <asp:Label ID="LabelAnosExperiencia" AssociatedControlID="TextBoxAnosExperiencia" Text="Anos de Experiência" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxAnosExperiencia" MaxLength="10" runat="server" />
        </p>
        <br />
        <p>
         <asp:Label ID="LabelCargo" AssociatedControlID="TextBoxCargo" Text="Cargo" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxCargo" MaxLength="50" runat="server" />
        </p>
        <br />
        <p>
         <asp:Label ID="LabelDescricao" AssociatedControlID="TextBoxDescricao" Text="Descrição" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxDescricao" MaxLength="50" runat="server" />
        </p>
        <br />
        <p>
        <asp:Button ID="ButtonExcluir" Text="Excluir" onclick="ButtonExcluir_Click" CausesValidation="false" runat="server" />
        <asp:Button ID="ButtonVoltar" Text="Voltar" onclick="ButtonVoltar_Click" CausesValidation="false" runat="server" />
        </p>

         <p>
         <asp:Label ID="LabelMensagemExcluir" visible="false" runat="server"></asp:Label>
         </p>

        </form>
    </div>
</asp:Content>
