using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class Empresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            Usuario U = (Usuario)Session["Usuario"];
            Empresa E = new Empresa(U);

            TextBoxCNPJ.Text = E.CNPJ;
            TextBoxLoginUsuario.Text = E.LoginUsuario;
            TextBoxRazaoSocial.Text = E.RazaoSocial;
            TextBoxNomeFantasia.Text = E.NomeFantasia;
            TextBoxEmail.Text = E.Email;
            TextBoxTelefone.Text = E.Telefone;
            TextBoxCEP.Text = E.CEP;
            TextBoxEndereco.Text = E.Endereco;
            TextBoxBairro.Text = E.Bairro;
            TextBoxCidade.Text = E.Cidade;
            DropDownEstado.Text = E.Estado;
            
        }

        protected void ButtonPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Empresas.aspx");
        }

        protected void ButtonVagas_Click(object sender, EventArgs e)
        {
            Response.Redirect("/VagasEmpresas.aspx");
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Logout.aspx");
        }

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            ButtonAlterar.Visible = false;
            ButtonSalvar.Visible = true;
            TextBoxRazaoSocial.Enabled = true;
            TextBoxNomeFantasia.Enabled = true;
            TextBoxEmail.Enabled = true;
            TextBoxTelefone.Enabled = true;
            TextBoxCEP.Enabled = true;
            TextBoxEndereco.Enabled = true;
            TextBoxBairro.Enabled = true;
            TextBoxCidade.Enabled = true;
            DropDownEstado.Enabled = true;
        }

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Empresa E = new Empresa();
                E.CNPJ = TextBoxCNPJ.Text;
                E.LoginUsuario = TextBoxLoginUsuario.Text;
                E.RazaoSocial = TextBoxRazaoSocial.Text;
                E.NomeFantasia = TextBoxNomeFantasia.Text;
                E.Email = TextBoxEmail.Text;
                E.Telefone = TextBoxTelefone.Text;
                E.CEP = TextBoxCEP.Text;
                E.Endereco = TextBoxEndereco.Text;
                E.Bairro = TextBoxBairro.Text;
                E.Cidade = TextBoxCidade.Text;
                E.Estado = DropDownEstado.SelectedValue;
                E.Alterar();
                
                LabelMensagemm.Visible = true;
                LabelMensagemm.Text = "Dados Alterados com Sucesso!";

                TextBoxRazaoSocial.Enabled = false;
                TextBoxNomeFantasia.Enabled = false;
                TextBoxEmail.Enabled = false;
                TextBoxTelefone.Enabled = false;
                TextBoxCEP.Enabled = false;
                TextBoxEndereco.Enabled = false;
                TextBoxBairro.Enabled = false;
                TextBoxCidade.Enabled = false;
                DropDownEstado.Enabled = false;
                ButtonSalvar.Visible = false;
                ButtonAlterar.Visible = true;

                

            }
            catch (Exception)
            {
                LabelMensagemm.Visible = true;
                LabelMensagemm.Text = "Erro!";
            }

        }
    }
}