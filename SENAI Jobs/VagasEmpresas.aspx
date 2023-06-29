<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="VagasEmpresas.aspx.cs" Inherits="SENAI_Jobs.Vagas" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Vagas Cadastradas
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

        <p>
        <asp:Label ID="LabelCNPJ" AssociatedControlID="TextBoxCNPJ" Text="CNPJ da Empresa" Visible="false" runat="server"></asp:Label> 
        <asp:TextBox ID="TextBoxCNPJ" Visible="false" MaxLength="18" runat="server" />
        <asp:RequiredFieldValidator ID="RFVCNPJ" ControlToValidate="TextBoxCNPJ" ErrorMessage="O campo CNPJ é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
                <asp:Label ID="LabelCodigo" AssociatedControlID="DropDownListNivel" Text="Nível de Escolaridade" Visible="false" runat="server"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownListNivel" Visible="false" runat="server"></asp:DropDownList>
        </p>

        <p>
         <asp:Label ID="LabelDescricao" AssociatedControlID="TextBoxDescricao" Text="Descrição da Vaga" Visible="false" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxDescricao" Visible="false" runat="server" />
         <asp:RequiredFieldValidator ID="RFVDescricao" ControlToValidate="TextBoxDescricao" ErrorMessage="O campo Descrição é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelSalario" AssociatedControlID="TextBoxSalario" Text="Salário" Visible="false" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxSalario" Visible="false" MaxLength="9" runat="server" />
         <asp:RequiredFieldValidator ID="RFVSalario" ControlToValidate="TextBoxSalario" ErrorMessage="O campo Salário é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Button ID="ButtonFinalizarCadastro" Text="Finalizar Cadastro" onclick="ButtonFinalizarCadastro_Click" Visible="false" runat="server" />
         <br />
         <br />
         <asp:Label ID="LabelFinalizarCadastro" Text="" Visible="false" runat="server"></asp:Label>
        </p>
           
        <p>
          <asp:Label ID="LabelMensagem" Text="" Visible="false" runat="server"></asp:Label>
        </p>

        <p>
            <asp:DataGrid id="ListaVagas" GridLines="Both" CellPadding="3" CellSpacing="0" OnItemCommand="ListaVagas_ItemCommand" runat="server">
                <HeaderStyle BackColor="YellowGreen" />

                <Columns>
                    <asp:ButtonColumn HeaderText="Candidatos" ButtonType="PushButton" Text="Ver Candidatos" CommandName="VerCandidatos"></asp:ButtonColumn>
                </Columns>

            </asp:DataGrid>
        </p>
        </form>
     </div>
</asp:Content>
