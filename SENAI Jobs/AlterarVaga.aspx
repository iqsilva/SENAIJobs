<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="AlterarVaga.aspx.cs" Inherits="SENAI_Jobs.AlterarVaga" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Alterar Vagas
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/VagasEmpresa.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
      <h1>Alterar vagas Cadastradas</h1>
        
        <form id="FormVagasEmpresa" method="post" runat="server">
        <p>
            <asp:Label ID="LabelSelecionar" AssociatedControlID="DropDownListSelecionar" Text="Selecione a Vaga" runat="server"></asp:Label>
            <br />
            <asp:DropDownList id="DropDownListSelecionar" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSelecionar_SelectedIndexChanged" runat="server">
            <asp:ListItem Value="" Text=""></asp:ListItem>
            </asp:DropDownList>
        </p>
            
        <p>
         <asp:Label ID="LabelCNPJ" AssociatedControlID="TextBoxCNPJ" Text="CNPJ da Empresa" Visible="true" runat="server"></asp:Label> 
         <asp:TextBox ID="TextBoxCNPJ" MaxLength="18" Enabled="false" runat="server" />
         <asp:RequiredFieldValidator ID="RFVCNPJ" ControlToValidate="TextBoxCNPJ" ErrorMessage="O campo CNPJ é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelCodigo" AssociatedControlID="DropDownListNivel" Text="Nível de Escolaridade" runat="server"></asp:Label>
         <br />
         <asp:DropDownList ID="DropDownListNivel" runat="server"></asp:DropDownList>
        </p>

        <p>
         <asp:Label ID="LabelDescricao" AssociatedControlID="TextBoxDescricao" Text="Descrição da Vaga" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxDescricao" runat="server" />
         <asp:RequiredFieldValidator ID="RFVDescricao" ControlToValidate="TextBoxDescricao" ErrorMessage="O campo Descrição é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Label ID="LabelSalario" AssociatedControlID="TextBoxSalario" Text="Salário" runat="server"></asp:Label>
         <asp:TextBox ID="TextBoxSalario" MaxLength="9" runat="server" />
         <asp:RequiredFieldValidator ID="RFVSalario" ControlToValidate="TextBoxSalario" ErrorMessage="O campo Salário é obrigatório." runat="server"></asp:RequiredFieldValidator>
        </p>

        <p>
         <asp:Button ID="ButtonAlterar" Text="Alterar" onclick="ButtonAlterar_Click" CausesValidation="false" runat="server" />
         <asp:Button ID="ButtonSalvar" Text="Salvar" onclick="ButtonSalvar_Click" Visible="false" runat="server" />
         <asp:Button ID="ButtonVoltar" Text="Voltar" onclick="ButtonVoltar_Click" CausesValidation="false" runat="server" />
         <br />
         <br />
         <asp:Label ID="LabelFinalizarAlteracao" Text="" Visible ="false" runat="server"></asp:Label>
        </p>
          
        </form>
        </div>
</asp:Content>
