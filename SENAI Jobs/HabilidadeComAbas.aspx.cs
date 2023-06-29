using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class HabilidadeComAbas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);
            
            CheckBoxListHabilidadeInformatica.DataSource = Habilidade.ListarInformatica();
            CheckBoxListHabilidadeInformatica.DataTextField = "Descricao";
            CheckBoxListHabilidadeInformatica.DataValueField = "Codigo";
            CheckBoxListHabilidadeInformatica.DataBind();

            if (!IsPostBack)
            {
                int[] Habilidades = Habilidade.Listar(A.Matricula).ToArray();

                for (int i = 0; i < CheckBoxListHabilidadeInformatica.Items.Count; i++)
                {
                    int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidadeInformatica.Items[i].Value);

                    if (Array.IndexOf(Habilidades, CodigoHabilidade) >= 0)
                        CheckBoxListHabilidadeInformatica.Items[i].Selected = true;
                }
            }

            CheckBoxListHabilidadeInstrumentacao.DataSource = Habilidade.ListarInstrumentacao();
            CheckBoxListHabilidadeInstrumentacao.DataTextField = "Descricao";
            CheckBoxListHabilidadeInstrumentacao.DataValueField = "Codigo";
            CheckBoxListHabilidadeInstrumentacao.DataBind();

            if (!IsPostBack)
            {
                int[] Habilidades = Habilidade.Listar(A.Matricula).ToArray();

                for (int i = 0; i < CheckBoxListHabilidadeInstrumentacao.Items.Count; i++)
                {
                    int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidadeInstrumentacao.Items[i].Value);

                    if (Array.IndexOf(Habilidades, CodigoHabilidade) >= 0)
                        CheckBoxListHabilidadeInstrumentacao.Items[i].Selected = true;
                }
            }

            CheckBoxListHabilidadeAlimentos.DataSource = Habilidade.ListarAlimentos();
            CheckBoxListHabilidadeAlimentos.DataTextField = "Descricao";
            CheckBoxListHabilidadeAlimentos.DataValueField = "Codigo";
            CheckBoxListHabilidadeAlimentos.DataBind();

            if (!IsPostBack)
            {
                int[] Habilidades = Habilidade.Listar(A.Matricula).ToArray();

                for (int i = 0; i < CheckBoxListHabilidadeAlimentos.Items.Count; i++)
                {
                    int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidadeAlimentos.Items[i].Value);

                    if (Array.IndexOf(Habilidades, CodigoHabilidade) >= 0)
                        CheckBoxListHabilidadeAlimentos.Items[i].Selected = true;
                }
            }
        }

        protected void ButtonAvancarInformatica_Click(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);

            Habilidade.LimparAssociacao(A.Matricula);

            for (int i = 0; i < CheckBoxListHabilidadeInformatica.Items.Count; i++)
            {
                if (!CheckBoxListHabilidadeInformatica.Items[i].Selected)
                    continue;

                int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidadeInformatica.Items[i].Value);
                Habilidade.Associar(A.Matricula, CodigoHabilidade);
            }
            Response.Redirect("/Idiomas.aspx");
        }


        protected void ButtonCancelarInformatica_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }
        protected void ButtonAvancarInstrumentacao_Click(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);

            Habilidade.LimparAssociacao(A.Matricula);

            for (int i = 0; i < CheckBoxListHabilidadeInstrumentacao.Items.Count; i++)
            {
                if (!CheckBoxListHabilidadeInstrumentacao.Items[i].Selected)
                    continue;

                int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidadeInstrumentacao.Items[i].Value);
                Habilidade.Associar(A.Matricula, CodigoHabilidade);
            }
            Response.Redirect("/Idiomas.aspx");
        }


        protected void ButtonCancelarInstrumentacao_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }
        protected void ButtonAvancarAlimentos_Click(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            Aluno A = new Aluno(U);

            Habilidade.LimparAssociacao(A.Matricula);

            for (int i = 0; i < CheckBoxListHabilidadeAlimentos.Items.Count; i++)
            {
                if (!CheckBoxListHabilidadeAlimentos.Items[i].Selected)
                    continue;

                int CodigoHabilidade = Convert.ToInt32(CheckBoxListHabilidadeAlimentos.Items[i].Value);
                Habilidade.Associar(A.Matricula, CodigoHabilidade);
            }
            Response.Redirect("/Idiomas.aspx");
        }


        protected void ButtonCancelarAlimentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }

        
    }
}