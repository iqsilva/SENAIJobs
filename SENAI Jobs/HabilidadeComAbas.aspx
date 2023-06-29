<%@ Page Title="" Language="C#" MasterPageFile="~/SENAIJobs.Master" AutoEventWireup="true" CodeBehind="HabilidadeComAbas.aspx.cs" Inherits="SENAI_Jobs.HabilidadeComAbas" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="Title" runat="server">
    Habilidades
</asp:Content>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
    <link href="/Style/HabilidadeComAbas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="Body" runat="server">
    <form id="FormHabilidadeComAbas" method="post" runat="server">
        <h1>Habilidades</h1>
    <div class="TabControl">
        <script type="text/javascript">  $(document).ready(function(){
     $("#content div:nth-child(1)").show();
     $(".abas li:first div").addClass("selected");
     $(".aba").click(function(){
         $(".aba").removeClass("selected");
         $(this).addClass("selected");
         var indice = $(this).parent().index();
         indice++;
         $("#content div").hide();
         $("#content div:nth-child("+indice+")").show();
     });
     
     $(".aba").hover(
         function(){$(this).addClass("ativa")},
     function(){$(this).removeClass("ativa")}
     );
 });
        </script>

        <div id="header">
            <ul class="abas">
                <li>
                    <div class="aba"><span>Informática</span> </div>
                </li>
                <li>
                    <div class="aba"><span>Instrumentação</span> </div>
                </li>
                <li>
                    <div class="aba"><span>Alimentos</span> </div>
                </li>
            </ul>
        </div>
        <div id="content">
            <div class="conteudo">
                <p>
                <asp:CheckBoxList ID="CheckBoxListHabilidadeInformatica" runat="server"></asp:CheckBoxList>
                </p>

                <asp:Button ID="ButtonAvancarInformatica" Text="Avançar" onclick="ButtonAvancarInformatica_Click" CausesValidation="false" runat="server"  />
                <asp:Button ID="ButtonCancelarInformatica" Text="Cancelar" onclick="ButtonCancelarInformatica_Click" CausesValidation="false" runat="server"  />

            </div>
            <div class="conteudo">
                <p>
                <asp:CheckBoxList ID="CheckBoxListHabilidadeInstrumentacao" runat="server"></asp:CheckBoxList>
                </p>

                <asp:Button ID="ButtonAvancarInstrumentacao" Text="Avançar" onclick="ButtonAvancarInstrumentacao_Click" CausesValidation="false" runat="server"  />
                <asp:Button ID="ButtonCancelarInstrumentacao" Text="Cancelar" onclick="ButtonCancelarInstrumentacao_Click" CausesValidation="false" runat="server"  /></div>
            <div class="conteudo">
                <p>
                <asp:CheckBoxList ID="CheckBoxListHabilidadeAlimentos" runat="server"></asp:CheckBoxList>
                </p>

                <asp:Button ID="ButtonAvancarAlimentos" Text="Avançar" onclick="ButtonAvancarAlimentos_Click" CausesValidation="false" runat="server"  />
                <asp:Button ID="ButtonCancelarAlimentos" Text="Cancelar" onclick="ButtonCancelarAlimentos_Click" CausesValidation="false" runat="server"  /></div>
            </div>
        </div>
    </form>
</asp:Content>
