using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class ExluirVagas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Vaga V = new Vaga();
            Empresa E = new Empresa(U);

            DataTable Vagas = Vaga.Listar(E.CNPJ);
            DataRow R = Vagas.NewRow();
            R["Codigo da Vaga"] = 0;
            R["Empresa"] = 0;
            R["Nivel de escolaridade requerido"] = 0;
            R["Descrição da Vaga"] = "";
            R["Salario(R$)"] = "";

            Vagas.Rows.InsertAt(R, 0);

            DropDownListSelecionar.DataSource = Vagas;
            DropDownListSelecionar.DataTextField = "Descrição da Vaga";
            DropDownListSelecionar.DataValueField = "Codigo da Vaga";
            DropDownListSelecionar.DataBind();

            DropDownListSelecionar.Items[0].Text = "";
            TextBoxDescricao.Enabled = false;
            TextBoxSalario.Enabled = false;
            DropDownListNivel.Enabled = false;

        }
         protected void DropDownListSelecionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Codigo = (Convert.ToInt32(DropDownListSelecionar.SelectedValue));
            Vaga V = new Vaga(Codigo);
            Codigo = Convert.ToInt32(V.Codigo.ToString());
            string CodigoEscolaridade = V.CodigoEscolaridade.Codigo.ToString();
            string CNPJ = V.CNPJEmpresa.CNPJ;
            string Descricao = V.Descricao;
            string Salario = V.Salario;

            DropDownListNivel.DataSource = Escolaridade.Listar();
            DropDownListNivel.DataTextField = "Nivel";
            DropDownListNivel.DataValueField = "Codigo";
            DropDownListNivel.DataBind();

            if (Codigo != 0)
                DropDownListNivel.SelectedValue = CodigoEscolaridade;

            TextBoxCNPJ.Text = CNPJ;
            TextBoxDescricao.Text = Descricao;
            TextBoxSalario.Text = Salario;
        }


         protected void ButtonExcluir_Click(object sender, EventArgs e)
         {
             try
             {
                 int Codigo = (Convert.ToInt32(DropDownListSelecionar.SelectedValue));
                 Vaga V = new Vaga(Codigo);
                 if (V.Excluir())
                 {
                     LabelMensagemExcluir.Visible = true;
                     TextBoxCNPJ.Text = "";
                     DropDownListNivel.Items.Clear();
                     DropDownListSelecionar.Items.Clear();
                     TextBoxDescricao.Text = "";
                     TextBoxSalario.Text = "";
                     LabelMensagemExcluir.Text = "Vaga Excluída com sucesso!";

                 }
             }
             catch
             {
                 LabelMensagemExcluir.Visible = true;
                 LabelMensagemExcluir.Text = "Erro de exclusão";
             }

         }
        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/VagasEmpresas.aspx");
        }

       
        }     
    }
