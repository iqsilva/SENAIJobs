using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class Alunos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);

            TextBoxMatricula.Text = A.Matricula.ToString();
            TextBoxLogin.Text = A.LoginUsuario;
            TextBoxCPF.Text = A.CPF ;
            TextBoxNome.Text = A.Nome;
           TextBoxEmail.Text = A.Email;
           TextBoxTelefone.Text =  A.Telefone;

            if ( A.Genero == "F")
            {
                RadioButtonFeminino.Checked = true;
            
            }else{
                RadioButtonMasculino.Checked = true;
            }

            TextBoxCurso.Text = A.Curso;
            TextBoxEndereco.Text = A.Endereco;
           TextBoxBairro.Text = A.Bairro;
           TextBoxCidade.Text = A.Cidade;
           DropDownEstado.SelectedValue = A.Estado;
           TextBoxDataNascimento.Text = A.DataNascimento.ToString("dd/MM/yyyy");
           

        }

        protected void ButtonPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }

        protected void ButtonHabilidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("/HabilidadeComAbas.aspx");
        }

        protected void ButtonIdioma_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Idiomas.aspx");
        }

        protected void ButtonEscolaridade_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Escolaridades.aspx");
        }

        protected void ButtonExperienciaProfissional_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ExperienciasProfissionais.aspx");
        }
        protected void ButtonVagas_Click(object sender, EventArgs e)
        {
            Response.Redirect("/VagasAlunos.aspx");
        }
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Logout.aspx");
        }
        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            ButtonAlterar.Visible = false;
            ButtonSalvar.Visible = true;
            TextBoxNome.Enabled = true;
            TextBoxEmail.Enabled = true;
            TextBoxTelefone.Enabled = true;
            RadioButtonFeminino.Enabled = true;
            RadioButtonMasculino.Enabled = true;
            TextBoxCurso.Enabled = true; 
            TextBoxEndereco.Enabled = true;
            TextBoxBairro.Enabled = true;
            TextBoxCidade.Enabled = true;
            DropDownEstado.Enabled = true;
           TextBoxDataNascimento.Enabled = true;
        }
        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno A = new Aluno();
                A.Matricula = int.Parse(TextBoxMatricula.Text);
                A.LoginUsuario = TextBoxLogin.Text;
                A.CPF = TextBoxCPF.Text;
                A.Nome = TextBoxNome.Text;
                A.Email = TextBoxEmail.Text;
                A.Telefone = TextBoxTelefone.Text;
                if (RadioButtonFeminino.Checked)
                    A.Genero = "F";
                else
                    A.Genero = "M";
                A.Curso = TextBoxCurso.Text;
                A.Endereco = TextBoxEndereco.Text;
                A.Bairro = TextBoxBairro.Text;
                A.Cidade = TextBoxCidade.Text;
                A.Estado = DropDownEstado.SelectedValue;
                A.DataNascimento = DateTime.Parse(TextBoxDataNascimento.Text.ToString());
                A.Alterar();

                LabelMensagemaluno.Visible = true;
                LabelMensagemaluno.Text = "Dados Alterados com Sucesso!";

                ButtonAlterar.Visible = true;
                TextBoxNome.Enabled = false;
                TextBoxEmail.Enabled = false;
                TextBoxTelefone.Enabled = false;
                TextBoxCurso.Enabled = false;
                TextBoxEndereco.Enabled = false;
                TextBoxBairro.Enabled = false;
                TextBoxCidade.Enabled = false;
                DropDownEstado.Enabled = false;
                TextBoxDataNascimento.Enabled = false;
                ButtonSalvar.Visible = false;
            }
            catch (Exception)
            {
                LabelMensagemaluno.Visible = true;
                LabelMensagemaluno.Text = "Erro!";
            }
        }
    }
}