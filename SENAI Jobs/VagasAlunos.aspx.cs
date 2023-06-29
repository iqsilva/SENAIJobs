using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class VagasAlunos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Vaga V = new Vaga();
            if (!IsPostBack)
            {
                ListaVagas.DataSource = Vaga.Listar();
                ListaVagas.DataBind();
            }


        }
  
        protected void ListaVagas_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EnviarCurriculo":
                  try 
	              {	 
                     Usuario U = (Usuario)Session["Usuario"];
                    int Codigo = Convert.ToInt32(e.Item.Cells[1].Text);
                    Vaga V = new Vaga(Codigo);
                    V.Envio(U.Aluno.Matricula);
                    LabelMensagem.Visible = true;
                    LabelMensagem.Text = "Curriculo Enviado !";
                  }
                  catch (Exception)
                  {
                      LabelMensagem.Visible = true;
                      LabelMensagem.Text = "Erro!";
                  }
              break;
            }
             
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Alunos.aspx");
        }
    }
}