using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class Vagas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario U = (Usuario)Session["Usuario"];
            Empresa E = new Empresa(U);
            Escolaridade Esc = new Escolaridade();

            if (!IsPostBack)
            {
                ListaVagas.DataSource = Vaga.Listar(E.CNPJ);
                ListaVagas.DataBind();
            }

            
            DropDownListNivel.DataSource = Escolaridade.Listar();
            DropDownListNivel.DataTextField = "Nivel";
            DropDownListNivel.DataValueField = "Codigo";
            DropDownListNivel.DataBind();

            int N = E.ContadordeVaga();
            if (N >= 3)
            {
                ButtonCadastrar.Visible = false;
                LabelMensagem.Visible = true;
                LabelMensagem.Text = "Limite de vagas excedido";
            }

            TextBoxCNPJ.Enabled = false;
            TextBoxCNPJ.Text = E.CNPJ;
        }

        protected void ListaVagas_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "VerCandidatos":
                    try
                    {
                        Usuario U = (Usuario)Session["Usuario"];
                        int Codigo = Convert.ToInt32(e.Item.Cells[1].Text);
                        Curriculo C = new Curriculo();
                        Response.Redirect("/EmpresaVerCurriculo.aspx?codigo=" + Codigo);
                      
                    }
                    catch (Exception)
                    {
                      
                    }
                    break;
            }
          
        }

        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            Empresa E = new Empresa();
            LabelCNPJ.Visible = true;
            TextBoxCNPJ.Visible = true;
            LabelCodigo.Visible = true;
            DropDownListNivel.Visible = true;
            LabelDescricao.Visible = true;
            TextBoxDescricao.Visible = true;
            LabelSalario.Visible = true;
            TextBoxSalario.Visible = true;
            LabelFinalizarCadastro.Visible = true;
            ButtonFinalizarCadastro.Visible = true;


        }

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AlterarVaga.aspx");
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ExcluirVaga.aspx");
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Empresas.aspx");
        }

        protected void ButtonFinalizarCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                Vaga V = new Vaga();
                Escolaridade Esc = new Escolaridade();
                Empresa E = new Empresa();
                E.CNPJ = TextBoxCNPJ.Text;
                Esc.Codigo = Convert.ToInt32(DropDownListNivel.Text);
                V.Descricao = TextBoxDescricao.Text;
                V.Salario = TextBoxSalario.Text;
                Vaga.Cadastrar(E.CNPJ, Esc.Codigo, V.Descricao, V.Salario);
                LabelFinalizarCadastro.Text = "Vaga cadastrada com sucesso!";
                ListaVagas.DataSource = Vaga.Listar(E.CNPJ);
                ListaVagas.DataBind();
               
            }
            catch (Exception)
            {
                LabelFinalizarCadastro.Text = "Erro";
                throw;
            }

        }
    }
}