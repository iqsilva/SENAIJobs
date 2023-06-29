using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs 
{
    public partial class Login : System.Web.UI.Page 
        {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario U = (Usuario)Session["Usuario"];

                if (U.Administrador == true)
                    Response.Redirect("Administrador.aspx");
                else if (U.Aluno != null)
                    Response.Redirect("Alunos.aspx");
                else
                    Response.Redirect("Empresas.aspx");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (Usuario.Autenticar(TextBoxNome.Text, TextBoxSenha.Text) == true)
            {
                Usuario U = new Usuario(TextBoxNome.Text, TextBoxSenha.Text);
                Session["Usuario"] = U;

                if (U.Administrador == true)
                    Response.Redirect("Administrador.aspx");
                else
                {
                    if (U.Aluno != null && U.Aluno.Ativo == true)
                    {
                        Response.Redirect("Alunos.aspx");
                    }
                    else
                    {
                        if (U.Empresa != null && U.Empresa.Ativo == true)
                        {
                            Response.Redirect("Empresas.aspx");
                        }
                        else
                        {
                            Session["Usuario"] = null;
                            LabelMensagem.Text = "Usuário não ativo.";
                        }
                    }
                }
            }
            else
                LabelMensagem.Text = "Login e/ou senha inválidos.";
        }

        protected void LinkButtonCadastrar_Click(object sender, EventArgs e)
        {
            DropDownTipo.Visible = true;
        }

        protected void DropDownTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownTipo.SelectedValue)
            {
                case "Aluno":
                    Response.Redirect("CadastroAluno.aspx");
                    break;

                case "Empresa":
                    Response.Redirect("CadastroEmpresa.aspx");
                    break;
            }
        }

        protected void LinkButtonSenha_Click(object sender, EventArgs e)
        {
            DropDownTipo2.Visible = true;
                      
        }

        protected void DropDownTipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownTipo2.SelectedValue)
            {
                case "Aluno":
                    Response.Redirect("AlunoEsqueceuSenha.aspx");
                    break;

                case "Empresa":
                    Response.Redirect("EmpresaEsqueceuSenha.aspx");
                    break;
            }

        }


    }
}
