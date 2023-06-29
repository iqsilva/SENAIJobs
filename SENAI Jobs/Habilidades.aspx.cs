using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SENAI_Jobs
{
    public partial class Habilidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);

            CheckBoxListHabilidade.DataSource = Habilidade.Listar();
            CheckBoxListHabilidade.DataTextField = "Descricao";
            CheckBoxListHabilidade.DataValueField = "Codigo";
            CheckBoxListHabilidade.DataBind();

            if (!IsPostBack)
            {
                int[] Habilidades = Habilidade.Listar(A.Matricula).ToArray();

                for (int i = 0; i < CheckBoxListHabilidade.Items.Count; i++)
                {
                    int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidade.Items[i].Value);

                    if (Array.IndexOf(Habilidades, CodigoHabilidade) >= 0)
                        CheckBoxListHabilidade.Items[i].Selected = true;
                }
            }
        }

        protected void ButtonAvancar_Click(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);

            Habilidade.LimparAssociacao(A.Matricula);

            for (int i = 0; i < CheckBoxListHabilidade.Items.Count; i++)
            {
                if (!CheckBoxListHabilidade.Items[i].Selected)
                    continue;

                int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidade.Items[i].Value);
                Habilidade.Associar(A.Matricula, CodigoHabilidade);
            }

            Response.Redirect("/Idiomas.aspx");
        }


        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }

        protected void ButtonAdicionar_Click(object sender, EventArgs e)
        {

        }
    }
}