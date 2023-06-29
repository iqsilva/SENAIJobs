<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="EmpresaVerCurriculo.aspx.cs" Inherits="SENAI_Jobs.EmpresaVerCurriculo" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Currículos de Interessados
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/EmpresaVerCurriculo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <div id="Centro">
        <h1>Currículos de Interessados na Vaga</h1>
        <form id="FormEmpresaVerCurriculo" method="post" runat="server">
            <p>
                <asp:Label ID="LabelEmpresaVerCurriculo" AssociatedControlID="DropDownListEmpresaVerCurriculo" Text="Candidatos Interessados"  runat="server"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownListEmpresaVerCurriculo" AutoPostBack="true" OnSelectedIndexChanged="DropDownListEmpresaVerCurriculo_SelectedIndexChanged" runat="server">
                <asp:ListItem Value="" Text=""></asp:ListItem>
            </asp:DropDownList>
            </p>
            
            <p>
            <asp:Label ID="LabelDados" Text="Dados Pessoais" Visible="false" runat="server"></asp:Label>
            </p>

            <p>
            <asp:Label ID="LabelNomeC" Text="Nome:" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelNome" Visible="false" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelEnderecoC" Text="Endereço:" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelEndereco" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelT5" Text="-" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelBairro" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelT6" Text="-" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelCidade" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelT7" Text="-" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelEstado" Visible="false" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelDataC" Text="Data de Nascimento:" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelDataNascimento" Visible="false" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelContatoC" Text="Contato:" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelTelefone" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelT8" Text="-" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelEmail" Visible="false" runat="server"></asp:Label>
            
            </p>

            <p>
            <asp:Label ID="LabelCursoC" Text="Curso do SENAI:" Visible="false" runat="server"></asp:Label>
            <asp:Label ID="LabelCurso" Visible="false" runat="server"></asp:Label>
            </p>

            <p>
                <asp:Label ID="LabelNivelC" Text="Escolaridade:" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelNivel" Visible="false" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LabelCursoEscolaridadeC" Text="Curso da Escolaridade:" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelCursoEscolaridade" Visible="false" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LabelInstituicaoC" Text="Instituição:" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelInstituicao" Visible="false" runat="server"></asp:Label>
                 </p>

            <p>
            <asp:Label ID="LabelExperienciasC" Text="Experiências Profissionais" Visible="false" runat="server"></asp:Label>
            </p>

            <p>
                <asp:Label ID="LabelNomeEmpresa" Visible="false" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LabelAnosExperiencia" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelT1" Text="/" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelCargo" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelT2" Text="/" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelDescExp" Visible="false" runat="server"></asp:Label>
            </p>

            <p>
                <asp:Label ID="LabelHabilidadesC" Text="Habilidades" Visible="false" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="LabelDescricao" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="LabelLingua" Visible="false" runat="server"></asp:Label>
            </p>
            <asp:Button ID="ButtonVoltar" text="Voltar" OnClick="ButtonVoltar_Click" runat="server" />

        </form>
    </div>
</asp:Content>
