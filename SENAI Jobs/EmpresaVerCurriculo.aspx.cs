using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class EmpresaVerCurriculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Empresa E = new Empresa(U);
            Curriculo C = new Curriculo();
            Vaga V = new Vaga();

            int Codigo = Convert.ToInt32(Request.QueryString["Codigo"].ToString());
            V.Codigo = Codigo;
           
            DropDownListEmpresaVerCurriculo.DataSource = Curriculo.Listar(V);
            DropDownListEmpresaVerCurriculo.DataTextField = "Nome";
            DropDownListEmpresaVerCurriculo.DataValueField = "Matricula";
            DropDownListEmpresaVerCurriculo.DataBind();
            DropDownListEmpresaVerCurriculo.Items.Insert(0, "");


        }

        protected void DropDownListEmpresaVerCurriculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MatriculaVaga = Convert.ToInt32(Request.Form["SENAIJobs$Body$DropDownListEmpresaVerCurriculo"].ToString());
         
            int Matricula = MatriculaVaga;
            Curriculo C = new Curriculo(Matricula);
            LabelNome.Visible = true;
            LabelEmail.Visible = true;
            LabelTelefone.Visible = true;
            LabelCurso.Visible = true;
            LabelEndereco.Visible = true;
            LabelBairro.Visible = true;
            LabelCidade.Visible = true;
            LabelEstado.Visible = true;
            LabelDataNascimento.Visible = true;
            LabelNivel.Visible = true;
            LabelCursoEscolaridade.Visible = true;
            LabelInstituicao.Visible = true;
            LabelNomeEmpresa.Visible = true;
            LabelAnosExperiencia.Visible = true;
            LabelCargo.Visible = true;
            LabelDescExp.Visible = true;
            LabelDescricao.Visible = true;
            LabelLingua.Visible = true;
            LabelT1.Visible = true;
            LabelT2.Visible = true;
            LabelT5.Visible = true;
            LabelT6.Visible = true;
            LabelT7.Visible = true;
            LabelT8.Visible = true;
            LabelCursoC.Visible = true;
            LabelExperienciasC.Visible = true;
            LabelDados.Visible = true;
            LabelNomeC.Visible = true;
            LabelEnderecoC.Visible = true;
            LabelContatoC.Visible = true;
            LabelDataC.Visible = true;
            LabelHabilidadesC.Visible = true;
            LabelNivelC.Visible = true;
            LabelCursoEscolaridadeC.Visible = true;
            LabelInstituicaoC.Visible = true;




            LabelNome.Text = C.Nome;
            LabelEmail.Text = C.Email;
            LabelTelefone.Text = C.Telefone;
            LabelCurso.Text = C.Curso;
            LabelEndereco.Text = C.Endereco;
            LabelBairro.Text = C.Bairro;
            LabelCidade.Text = C.Cidade;
            LabelEstado.Text = C.Estado;
            LabelDataNascimento.Text = C.DataNascimento.ToString("dd/MM/yyyy");
            LabelNivel.Text = C.Nivel;
            LabelCursoEscolaridade.Text = C.CursoEscolaridade;
            LabelInstituicao.Text = C.Instituicao;
            
            LabelNomeEmpresa.Text = String.Join(", ", C.NomeEmpresa);

            LabelAnosExperiencia.Text = String.Join(", ", C.AnosExperiencia);
            LabelCargo.Text = String.Join(", ", C.Cargo);
            LabelDescExp.Text = String.Join(", ", C.DescExp);
            LabelDescricao.Text = String.Join(", ", C.Descricao);
            LabelLingua.Text = String.Join(", ", C.Lingua);
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/VagasEmpresas.aspx");
        }
        
    }
}