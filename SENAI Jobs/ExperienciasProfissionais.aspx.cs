using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SENAI_Jobs
{
    public partial class ExperienciasProfissionais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);
            
            List<HtmlTableRow> RowList = new List<HtmlTableRow>();
            RowList.Clear();
            if (Session["Experiencias"] == null)
                RowList = new List<HtmlTableRow>();
            else
                RowList = (List<HtmlTableRow>)Session["Experiencias"];
          
            for (int i = 0; i < RowList.Count; i++)
            {
                TableExperiencias.Rows.Add(RowList[i]);
            }
            TextBoxMatriculaAluno.Enabled = false;
            TextBoxMatriculaAluno.Text = A.Matricula.ToString();

            ButtonFinalizar.Visible = false;

            if(RowList.Count >0)
                ButtonFinalizar.Visible = true;
        }

        protected void ButtonFinalizar_Click(object sender, EventArgs e)
        {
            List<HtmlTableRow> RowList;
            if (Session["Experiencias"] == null)
                RowList = new List<HtmlTableRow>();
            else
                RowList = (List<HtmlTableRow>)Session["Experiencias"];
            int MatriculaAluno = Convert.ToInt32(RowList[0].Cells[0].InnerText);

            for (int i = 0; i < RowList.Count; i++)
            {
                String NomeEmpresa = RowList[i].Cells[1].InnerText;
                String AnosExperiencia = RowList[i].Cells[2].InnerText;
                String Cargo = RowList[i].Cells[3].InnerText;
                String Descricao = RowList[i].Cells[4].InnerText;
                ExperienciaProfissional.Associar(MatriculaAluno, NomeEmpresa, AnosExperiencia, Cargo, Descricao);

                Response.Redirect("/Alunos.aspx");
           
            }
        }
        

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Escolaridades.aspx");
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");

        }

        protected void ButtonAdicionar_Click(object sender, EventArgs e)
        {
            List<HtmlTableRow> RowList;
            if (Session["Experiencias"] == null)
                RowList = new List<HtmlTableRow>();
            else
                RowList = (List<HtmlTableRow>)Session["Experiencias"];

            HtmlTableCell[] Cells = new HtmlTableCell[5];
            Cells[0] = new HtmlTableCell();
            Cells[0].InnerText = TextBoxMatriculaAluno.Text.ToString();
            Cells[1] = new HtmlTableCell();
            Cells[1].InnerText = TextBoxNomeEmpresa.Text.ToString();
            Cells[2] = new HtmlTableCell();
            Cells[2].InnerText = TextBoxAnosExperiencia.Text.ToString();
            Cells[3] = new HtmlTableCell();
            Cells[3].InnerText = TextBoxCargo.Text.ToString();
            Cells[4] = new HtmlTableCell();
            Cells[4].InnerText = TextBoxDescricao.Text.ToString();

            HtmlTableRow Row = new HtmlTableRow();
            Row.Cells.Add(Cells[0]);
            Row.Cells.Add(Cells[1]);
            Row.Cells.Add(Cells[2]);
            Row.Cells.Add(Cells[3]);
            Row.Cells.Add(Cells[4]);
           
            RowList.Add(Row);
            
            Session["Experiencias"] = RowList;

            ButtonFinalizar.Visible = true;

            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ExcluirExperiencia.aspx");
        }

        protected void ButtonNaoTenho_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }
    }
}