using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class AlunoEsqueceuSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAlterarSenha_Click(object sender, EventArgs e)
        {
            Aluno A = new Aluno();
            A.LoginUsuario = TextBoxLogin.Text;
            A.CPF = TextBoxCPF.Text;
            A.Senha = TextBoxNovaSenha.Text;
            if (TextBoxNovaSenha.Text == TextBoxConfirmaSenha.Text)
            {
                A.EsqueceuSenha();
                LabelMensagem.Visible = true;
                LabelMensagem.Text = "Senha alterada com Sucesso!";
            }
            else
            {
                LabelMensagem.Visible = true;
                LabelMensagem.Text = "Digite sua nova senha igualmente nos dois campos!";
            }
            if (TextBoxNovaSenha.Text == "" && TextBoxConfirmaSenha.Text == "")
            {
                LabelMensagem.Visible = true;
                LabelMensagem.Text = "Preencha os campos de Nova Senha e Confirmar Senha.";
            }
          
            
        }

        protected void VoltarLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}