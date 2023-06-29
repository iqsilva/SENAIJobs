<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="VagasAlunos.aspx.cs" Inherits="SENAI_Jobs.VagasAlunos" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Vagas 
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/VagasEmpresa.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Vagas Cadastradas pelas Empresas</h1>

        <form id="FormVagasEmpresa" method="post" runat="server">

            <asp:DataGrid id="ListaVagas" GridLines="Both" CellPadding="3" CellSpacing="0" OnItemCommand="ListaVagas_ItemCommand" runat="server">
                <HeaderStyle BackColor="MediumTurquoise" />

                <Columns>
                    <asp:ButtonColumn HeaderText="Detalhes" ButtonType="PushButton" Text="Enviar Currículo" CommandName="EnviarCurriculo"></asp:ButtonColumn>
                </Columns>

            </asp:DataGrid> 
            <p>
                <asp:Button ID="ButtonVoltar" Text="Voltar" onclick="ButtonVoltar_Click" CausesValidation="false" runat="server" />
            </p>
            <p>
            <asp:Label ID="LabelMensagem" Text="" runat="server" Enabled="false" ></asp:Label>
            </p>
        </form>
    </div>
</asp:Content>
