using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SENAI_Jobs
{
    public partial class CadastroAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonCadastrar_Click(object sender, EventArgs e)
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
                A.DataNascimento = DateTime.Parse(TextBoxDataNascimento.Text);
                A.Ativo = false;

                if (A.Cadastrar(TextBoxLogin.Text, TextBoxSenha.Text))
                    LabelMensagem.Text = "Aluno cadastrado com sucesso! Sua conta ficará inativa até a validação do administrador.";
            }
            catch (Exception Ex)
            {
                    if (Ex.Message.Contains("PK__Aluno"))
                    {
                        LabelMensagem.Text = "Matrícula já existente.";
                        TextBoxMatricula.Text = "";
                    }
                    else if (Ex.Message.Contains("PK__Usuario"))
                    {
                        LabelMensagem.Text = "Login já existente.";
                        TextBoxLogin.Text = "";
                    }
            }
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}