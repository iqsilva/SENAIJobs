<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="Idiomas.aspx.cs" Inherits="SENAI_Jobs.Idiomas" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Idiomas
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/Idioma.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
     <div id="Centro">
        <h1>Idioma</h1>
        <form id="FormIdioma" method="post" runat="server">

            <p>
                <asp:Label ID="LabelCodigo" AssociatedControlID="CheckBoxListLingua" Text="Língua" runat="server"></asp:Label>
                <br />
                <asp:CheckBoxList ID="CheckBoxListLingua" runat="server"></asp:CheckBoxList>
            </p>

            <asp:Button ID="ButtonAvancar" Text="Avançar" onclick="ButtonAvancar_Click" CausesValidation="false" runat="server" />
            <asp:Button ID="ButtonVoltar" Text="Voltar" onclick="ButtonVoltar_Click" CausesValidation="false" runat="server" />
          <asp:Button ID="ButtonCancelar" Text="Cancelar" onclick="ButtonCancelar_Click" CausesValidation="false" runat="server" />   
             </form>
    </div>
</asp:Content>