using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Usuario"].ToString() == "FIM")
            {
                Response.Redirect("Login.aspx");
            }

            DropDownListAlunos.DataSource = Aluno.ListarAluno(false);
            DropDownListAlunos.DataTextField = "Nome";
            DropDownListAlunos.DataValueField = "Matricula";
            DropDownListAlunos.DataBind();

            DropDownListEmpresas.DataSource = Empresa.ListarEmpresa(false);
            DropDownListEmpresas.DataTextField = "RazaoSocial";
            DropDownListEmpresas.DataValueField = "CNPJ";
            DropDownListEmpresas.DataBind();

            DropDownListExcluirAluno.DataSource = Aluno.ListarAluno();
            DropDownListExcluirAluno.DataTextField = "Nome";
            DropDownListExcluirAluno.DataValueField = "Matricula";
            DropDownListExcluirAluno.DataBind();

            DropDownListExcluirEmpresa.DataSource = Empresa.ListarEmpresa2(false);
            DropDownListExcluirEmpresa.DataTextField = "RazaoSocial";
            DropDownListExcluirEmpresa.DataValueField = "CNPJ";
            DropDownListExcluirEmpresa.DataBind();


        }

        protected void ButtonAtivarAluno_Click(object sender, EventArgs e)
        {
            try
            {
                int Matricula = Convert.ToInt32(DropDownListAlunos.SelectedValue);
                Aluno A = new Aluno(Matricula);
                if (A.Ativar())
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Aluno ativado com sucesso.";

                    DropDownListAlunos.DataSource = Aluno.ListarAluno(false);
                    DropDownListAlunos.DataTextField = "Nome";
                    DropDownListAlunos.DataValueField = "Matricula";
                    DropDownListAlunos.DataBind();
                }
            }
            catch
            {
                if (DropDownListAlunos.SelectedValue.Count() == 0)
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Não há alunos inativos";
                }
            }
        }

        protected void ButtonAtivarEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                String CNPJ = DropDownListEmpresas.SelectedValue;
                Empresa E = new Empresa(CNPJ);
                if (E.Ativar())
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Empresa ativado com sucesso.";

                    DropDownListEmpresas.DataSource = Empresa.ListarEmpresa(false);
                    DropDownListEmpresas.DataTextField = "RazaoSocial";
                    DropDownListEmpresas.DataValueField = "CNPJ";
                    DropDownListEmpresas.DataBind();
                }
            }
            catch
            {
                if (DropDownListEmpresas.SelectedValue.Count() == 0)
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Não há Empresas Inativas";
                }
            }
        }

        protected void ButtonCadastrarNovoAdministrador_Click(object sender, EventArgs e)
        {
            LabelLogin.Visible = true;
            TextBoxLogin.Visible = true;

            LabelSenha.Visible = true;
            TextBoxSenha.Visible = true;
            ButtonConfirmarCadastro.Visible = true;
        }

        protected void ButtonConfirmarCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario U = new Usuario();
                U.Login = TextBoxLogin.Text;
                U.Senha = TextBoxSenha.Text;

                if (U.CadastrarAdministrador(TextBoxLogin.Text, TextBoxSenha.Text))
                    LabelMensagem.Visible = true;
                LabelMensagem.Text = "Administrador cadastrado com sucesso!";
                TextBoxLogin.Text = "";
                TextBoxSenha.Text = "";
            }
            catch (Exception Ex)
            {
                if (Ex.Message.Contains("PK__Usuario"))
                {
                    LabelMensagem.Visible = true;
                    LabelMensagem.Text = "Login já existente.";
                    TextBoxLogin.Text = "";
                    TextBoxSenha.Text = "";
                }
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Logout.aspx");
        }

        protected void ButtonExcluirAluno_Click(object sender, EventArgs e)
        {
            try
            {
                int Matricula = Convert.ToInt32(DropDownListExcluirAluno.SelectedValue);
                Aluno A = new Aluno(Matricula);
                if (A.Excluir())
                {
                    LabelMensagemExcluir.Visible = true;
                    LabelMensagemExcluir.Text = "Aluno excluido com sucesso.";

                    DropDownListExcluirAluno.DataSource = Aluno.ListarAluno();
                    DropDownListExcluirAluno.DataTextField = "Nome";
                    DropDownListExcluirAluno.DataValueField = "Matricula";
                    DropDownListExcluirAluno.DataBind();
                }
            }
            catch
            {
                if (DropDownListExcluirAluno.SelectedValue.Count() == 0)
                {
                    LabelMensagemExcluir.Visible = true;
                    LabelMensagemExcluir.Text = "Não há alunos para excluir.";
                }
                else
                {
                    LabelMensagemErro.Visible = true;
                    LabelMensagemErro.Text = "Erro de exclusão!";
                }
            }

        }

        protected void ButtonExcluirEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                String CNPJ = DropDownListExcluirEmpresa.SelectedValue;
                Empresa E = new Empresa(CNPJ);
                if (E.Excluir())
                {
                    LabelMensagemExcluir.Visible = true;
                    LabelMensagemExcluir.Text = "Empresa excluida com sucesso.";

                    DropDownListExcluirEmpresa.DataSource = Empresa.ListarEmpresa2(false);
                    DropDownListExcluirEmpresa.DataTextField = "RazaoSocial";
                    DropDownListExcluirEmpresa.DataValueField = "CNPJ";
                    DropDownListExcluirEmpresa.DataBind();
                }
            }
            catch
            {
                if (DropDownListExcluirEmpresa.SelectedValue.Count() == 0)
                {
                    LabelMensagemExcluir.Visible = true;
                    LabelMensagemExcluir.Text = "Não há alunos para excluir.";
                }
                else
                {
                    LabelMensagemErro.Visible = true;
                    LabelMensagemErro.Text = "Erro de exclusão!";
                }
            }
        }
    }
}
