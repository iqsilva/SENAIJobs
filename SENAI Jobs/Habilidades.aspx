<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="Habilidades.aspx.cs" Inherits="SENAI_Jobs.Habilidades" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Habilidade
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/Habilidade.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Habilidade</h1>
        <form id="FormHabilidade" method="post" runat="server">
            <p>
                <asp:Label ID="LabelCodigo" AssociatedControlID="CheckBoxListHabilidade" Text="Habilidade" runat="server"></asp:Label>
                <br />
                <asp:CheckBoxList ID="CheckBoxListHabilidade" runat="server"></asp:CheckBoxList>
            </p>

            <asp:Button ID="ButtonAvancar" Text="Avançar" onclick="ButtonAvancar_Click" CausesValidation="false" runat="server"  />
            <asp:Button ID="ButtonCancelar" Text="Cancelar" onclick="ButtonCancelar_Click" CausesValidation="false" runat="server"  />   
        </form>
    </div>
</asp:Content>
