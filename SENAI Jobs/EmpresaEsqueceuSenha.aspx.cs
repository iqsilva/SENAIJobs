using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class EmpresaEsqueceuSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAlterarSenha_Click(object sender, EventArgs e)
        {
            Empresa E = new Empresa();
            E.LoginUsuario = TextBoxLogin.Text;
            E.CNPJ = TextBoxCNPJ.Text;
            E.Senha = TextBoxNovaSenha.Text;
            if (TextBoxNovaSenha.Text == TextBoxConfirmaSenha.Text)
            {
                E.EsqueceuSenha();
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
