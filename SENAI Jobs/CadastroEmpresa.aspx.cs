using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class CadastroEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Empresa E = new Empresa();
                E.CNPJ = TextBoxCNPJ.Text;
                E.LoginUsuario = TextBoxLogin.Text;
                E.RazaoSocial = TextBoxRazaoSocial.Text;
                E.NomeFantasia = TextBoxNomeFantasia.Text;
                E.Email = TextBoxEmail.Text;
                E.Telefone = TextBoxTelefone.Text;
                E.CEP = TextBoxCEP.Text;
                E.Endereco = TextBoxEndereco.Text;
                E.Bairro = TextBoxBairro.Text;
                E.Cidade = TextBoxCidade.Text;
                E.Estado = DropDownEstado.SelectedValue;
                E.Ativo = false;
               


                if (E.Cadastrar(TextBoxLogin.Text, TextBoxSenha.Text))
                    LabelMensagem.Text = "Empresa cadastrada com sucesso! Sua conta ficará inativa até a validação do administrador.";
            }
            catch (Exception Ex)
            {
                if (Ex.Message.Contains("PK__Empresa"))
                {
                    LabelMensagem.Text = "CNPJ já existente.";
                    TextBoxCNPJ.Text = "";
                }
                else if (Ex.Message.Contains("PK__Usuario"))
                {
                    LabelMensagem.Text = "Login já existente.";
                    TextBoxLogin.Text = "";
                }
                    if (Ex.Message.Contains("PK__Usuario"))
                    {
                        LabelMensagem.Text = "Login já existente.";
                        TextBoxLogin.Text = "";
                        if (Ex.Message.Contains("PK__Empresa"))
                        
                            {
                               LabelMensagem.Text = "CNPJ já existente.";
                               TextBoxCNPJ.Text = "";
                
                         
                            }
                        }
                }

            
        }

        protected void ButtonVolar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}