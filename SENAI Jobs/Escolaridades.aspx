<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="Escolaridades.aspx.cs" Inherits="SENAI_Jobs.Escolaridades" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Escolaridades
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/Escolaridade.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">

    <div id="Centro">
        <h1>Escolaridade</h1>
        <form id="FormEscolaridade" method="post" runat="server">

        <p>
                <asp:Label ID="LabelCodigo" AssociatedControlID="DropDownListNivel" Text="Nível" runat="server"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownListNivel" runat="server"></asp:DropDownList>
                <br />
                <asp:Label ID="LabelCurso" AssociatedControlID="TextBoxCursoDoCurriculo" Text="Curso" runat="server"></asp:Label> 
                <br />              
                <asp:TextBox ID="TextBoxCursoDoCurriculo" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCursoDoCurriculo" ControlToValidate="TextBoxCursoDoCurriculo" ErrorMessage="Este campo é obrigatório." runat="server"></asp:RequiredFieldValidator>
                <br />    
                <asp:Label ID="LabelInstituicao" AssociatedControlID="TextBoxInstituicao" Text="Instituição" runat="server"></asp:Label>
                <br />    
                <asp:TextBox ID="TextBoxInstituicao" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVInstituicao" ControlToValidate="TextBoxInstituicao" ErrorMessage="Este campo é obrigatório." runat="server"></asp:RequiredFieldValidator>
                
                
        </p>

          <asp:Button ID="ButtonAvancar" Text="Avançar" onclick="ButtonAvancar_Click" runat="server" />
          <asp:Button ID="ButtonVoltar" Text="Voltar" onclick="ButtonVoltar_Click" CausesValidation="false" runat="server" />
          <asp:Button ID="ButtonCancelar" Text="Cancelar" onclick="ButtonCancelar_Click" CausesValidation="false" runat="server" /> 
        </form>
    </div>
</asp:Content>