using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class Escolaridades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);
            Escolaridade E = Escolaridade.BuscarPorAluno(A.Matricula);
            
            DropDownListNivel.DataSource = Escolaridade.Listar();
            DropDownListNivel.DataTextField = "Nivel";
            DropDownListNivel.DataValueField = "Codigo";
            DropDownListNivel.DataBind();


            string CodigoEscolaridade = E.Codigo.ToString();
            string CursoDoCurriculo = A.CursoDoCurriculo;
            string Instituicao = A.Instituicao;


            if (CodigoEscolaridade != "0")
            {
                DropDownListNivel.Text = CodigoEscolaridade;
                TextBoxCursoDoCurriculo.Text = CursoDoCurriculo;
                TextBoxInstituicao.Text = Instituicao;
            }

        }

        protected void ButtonAvancar_Click(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);
            int CodigoEscolaridade = Convert.ToInt32(DropDownListNivel.Text);
            A.CursoDoCurriculo = TextBoxCursoDoCurriculo.Text;
            A.Instituicao = TextBoxInstituicao.Text;
            Escolaridade.Associar(A.Matricula, CodigoEscolaridade , A.CursoDoCurriculo , A.Instituicao);

            Response.Redirect("/ExperienciasProfissionais.aspx");
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Idiomas.aspx");
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }
    }
}