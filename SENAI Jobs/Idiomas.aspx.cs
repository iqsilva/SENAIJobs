using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class Idiomas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);


            CheckBoxListLingua.DataSource = Idioma.Listar();
            CheckBoxListLingua.DataTextField = "Lingua";
            CheckBoxListLingua.DataValueField = "Codigo";
            CheckBoxListLingua.DataBind();

            if (!IsPostBack)
            {
                int[] Idiomas = Idioma.Listar(A.Matricula).ToArray();

                for (int i = 0; i < CheckBoxListLingua.Items.Count; i++)
                {
                    int CodigoIdioma = Convert.ToInt32(CheckBoxListLingua.Items[i].Value);

                    if (Array.IndexOf(Idiomas, CodigoIdioma) >= 0)
                        CheckBoxListLingua.Items[i].Selected = true;
                }
            }
        }

        protected void ButtonAvancar_Click(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);

            Idioma.LimparAssociacao(A.Matricula);

            for (int i = 0; i < CheckBoxListLingua.Items.Count; i++)
            {
                if (!CheckBoxListLingua.Items[i].Selected)
                    continue;

                int CodigoIdioma = Convert.ToInt32(CheckBoxListLingua.Items[i].Value);
                Idioma.Associar(A.Matricula, CodigoIdioma);
            }


            Response.Redirect("/Escolaridades.aspx");
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/HabilidadeComAbas.aspx");
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }

    }
}