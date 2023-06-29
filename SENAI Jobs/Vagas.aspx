<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="Vagas.aspx.cs" Inherits="SENAI_Jobs.Vagas" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Vagas
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/VagasEmpresa.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Vagas Cadastradas</h1>
        
        <form id="FormVagasEmpresa" method="post" runat="server">

            <asp:Button ID="ButtonCadastrar" Text="Cadastrar" onclick="ButtonCadastrar_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonAlterar" Text="Alterar" onclick="ButtonAlterar_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonExcluir" Text="Excluir" onclick="ButtonExcluir_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonVoltar" Text="Voltar" onclick="ButtonVoltar_Click" CausesValidation="false" runat="server" />

        </form>
     </div>
</asp:Content>
