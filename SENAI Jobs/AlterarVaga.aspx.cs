using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class AlterarVaga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Usuario U = (Usuario)Session["Usuario"];
                Empresa E = new Empresa(U);
                Vaga V = new Vaga();
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

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            TextBoxDescricao.Enabled = true;
            TextBoxSalario.Enabled = true;
            DropDownListNivel.Enabled = true;
            ButtonSalvar.Visible = true;
            
        }

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int Codigo = (Convert.ToInt32(DropDownListSelecionar.SelectedValue));
                Vaga V = new Vaga(Codigo);
                V.Codigo = Codigo;
                V.Salario = Request.Form["SENAIJobs$Body$TextBoxSalario"].ToString();
                V.Descricao = Request.Form["SENAIJobs$Body$TextBoxDescricao"].ToString();
                V.CodigoEscolaridade.Codigo = (Convert.ToInt32(Request.Form["SENAIJobs$Body$DropDownListNivel"].ToString()));
                V.Alterar();
                LabelFinalizarAlteracao.Visible = true;
                LabelFinalizarAlteracao.Text = "Dados Alterados com Sucesso !";
                ButtonSalvar.Visible = false;
            }
            catch (Exception)
            {
                LabelFinalizarAlteracao.Visible = true;
                LabelFinalizarAlteracao.Text = "Erro";
            }

        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/VagasEmpresas.aspx");
        }
    }
}