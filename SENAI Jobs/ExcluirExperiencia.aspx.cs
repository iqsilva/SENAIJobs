using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SENAI_Jobs
{
    public partial class ExcluirExperiencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Usuario U = (Usuario)Session["Usuario"];
                Aluno A = new Aluno(U);
                ExperienciaProfissional E = new ExperienciaProfissional();

                DataTable Experiencias = ExperienciaProfissional.Listar(A.Matricula);
               
                DropDownListExperiencia.AppendDataBoundItems = true; 
	            DropDownListExperiencia.Items.Insert(0, ""); 
                DropDownListExperiencia.DataSource = Experiencias;
                DropDownListExperiencia.DataTextField = "NomeEmpresa";
                DropDownListExperiencia.DataValueField = "Codigo";
                DropDownListExperiencia.DataBind();                                             
                DropDownListExperiencia.Items[0].Text = "";
                TextBoxMatriculaAluno.Enabled = false;
                TextBoxNomeEmpresa.Enabled = false;
                TextBoxAnosExperiencia.Enabled = false;
                TextBoxCargo.Enabled = false;
                TextBoxDescricao.Enabled = false;
                
            }
        
        }

        protected void DropDownListExperiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Codigo = DropDownListExperiencia.SelectedValue.ToString();
            ExperienciaProfissional E = new ExperienciaProfissional(Convert.ToInt32(Codigo));
            //Codigo = E.Codigo.ToString();
            int MatriculaAluno = E.MatriculaAluno;
            string NomeEmpresa = E.NomeEmpresa;
            string AnosExperiencia = E.AnosExperiencia;
            string Cargo = E.Cargo;
            string Descricao = E.Descricao;

            TextBoxMatriculaAluno.Text = E.MatriculaAluno.ToString();
            TextBoxNomeEmpresa.Text = E.NomeEmpresa;
            TextBoxAnosExperiencia.Text = E.AnosExperiencia;
            TextBoxCargo.Text = E.Cargo;
            TextBoxDescricao.Text = E.Descricao;
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            try
             {
                 int Codigo = (Convert.ToInt32(DropDownListExperiencia.SelectedValue));
                 ExperienciaProfissional E = new ExperienciaProfissional(Codigo);
                 if (E.Excluir())
                 {
                     LabelMensagemExcluir.Visible = true;
                     LabelMensagemExcluir.Text = "Experiência Excluída com sucesso.";
                 }
             }
             catch
             {
                 LabelMensagemExcluir.Visible = true;
                 LabelMensagemExcluir.Text = "Erro de exclusão";
             }
             Response.Redirect("/ExcluirExperiencia.aspx");
         
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ExperienciasProfissionais.aspx");
        }
    }
}