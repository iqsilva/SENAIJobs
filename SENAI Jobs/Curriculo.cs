using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SENAI_Jobs
{
    public class Curriculo : BD
    {
        public int Matricula { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Genero { get; set; }
        public String Curso { get; set; }
        public String Endereco { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Nivel { get; set; }
        public String CursoEscolaridade { get; set; }
        public String Instituicao { get; set; }
        public List<String> NomeEmpresa { get; set; }
        public List<String> AnosExperiencia { get; set; }
        public List<String> Cargo { get; set; }
        public List<String> DescExp { get; set; }
        public List<String> Descricao { get; set; }
        public List<String> Area { get; set; }
        public List<String> Lingua { get; set; }

        public Curriculo() {}
            
        public Curriculo(int Matricula)
        {
            this.NomeEmpresa = new List<String>();
            this.AnosExperiencia = new List<String>();
            this.Cargo = new List<String>();
            this.DescExp = new List<String>();
            this.Descricao = new List<String>();
            this.Area = new List<String>();
            this.Lingua = new List<String>();
            Conexao.Open();

            String SQL = "SELECT " +
	                    "Aluno.Nome,Aluno.Email,Aluno.Telefone,Aluno.Genero,Aluno.Curso,Aluno.Endereco, " +
	                    "Aluno.Bairro,Aluno.Cidade,Aluno.Estado,Aluno.DataNascimento, Escolaridade.Nivel, " +
                        "EscolaridadeAluno.Curso As CursoEscolaridade, EscolaridadeAluno.Instituicao, ExperienciaProfissional.NomeEmpresa, ExperienciaProfissional.AnosExperiencia, "+
                        "ExperienciaProfissional.Cargo, ExperienciaProfissional.Descricao AS DescExp, Habilidade.Descricao, Idioma.Lingua " +
                        "FROM " +
	                    "Aluno " +
                        "LEFT JOIN EscolaridadeAluno ON Aluno.Matricula = EscolaridadeAluno.MatriculaAluno " +
                        "LEFT JOIN Escolaridade ON EscolaridadeAluno.CodigoEscolaridade = Escolaridade.Codigo " +
                        "LEFT JOIN ExperienciaProfissional ON Aluno.Matricula = ExperienciaProfissional.MatriculaAluno "+
                        "LEFT JOIN HabilidadeCurriculo ON Aluno.Matricula = HabilidadeCurriculo.MatriculaAluno " +
                        "LEFT JOIN Habilidade ON Habilidade.Codigo = HabilidadeCurriculo.CodigoHabilidade " +
                        "LEFT JOIN IdiomaCurriculo ON Aluno.Matricula = IdiomaCurriculo.MatriculaAluno " +
                        "Left Join Idioma On Idioma.Codigo = IdiomaCurriculo.CodigoIdioma " +
                        "where Aluno.Matricula = @Matricula"; 

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Matricula", Matricula);
            
            Leitor = Comando.ExecuteReader();

            Leitor.Read();
            
            this.Nome = Leitor["Nome"].ToString();
            this.Email = Leitor["Email"].ToString();
            this.Telefone = Leitor["Telefone"].ToString();
            this.Genero = Leitor["Genero"].ToString();
            this.Curso = Leitor["Curso"].ToString();
            this.Endereco = Leitor["Endereco"].ToString();
            this.Bairro = Leitor["Bairro"].ToString();
            this.Cidade = Leitor["Cidade"].ToString();
            this.Estado = Leitor["Estado"].ToString();
            this.DataNascimento = DateTime.Parse(Leitor["DataNascimento"].ToString());
            this.Nivel = Leitor["Nivel"].ToString();
            this.CursoEscolaridade = Leitor["CursoEscolaridade"].ToString();
            this.Instituicao = Leitor["Instituicao"].ToString();

            do
            {
                this.NomeEmpresa.Add(Leitor["NomeEmpresa"].ToString());
                this.AnosExperiencia.Add(Leitor["AnosExperiencia"].ToString());
                this.Cargo.Add(Leitor["Cargo"].ToString());
                this.DescExp.Add(Leitor["DescExp"].ToString());
                this.Descricao.Add(Leitor["Descricao"].ToString());
                this.Lingua.Add(Leitor["Lingua"].ToString());
            } while (Leitor.Read());

            this.NomeEmpresa = this.NomeEmpresa.Distinct().ToList();
            this.AnosExperiencia = this.AnosExperiencia.Distinct().ToList();
            this.Cargo = this.Cargo.Distinct().ToList();
            this.DescExp = this.DescExp.Distinct().ToList();
            this.Descricao = this.Descricao.Distinct().ToList();
            this.Lingua = this.Lingua.Distinct().ToList();                    

            Conexao.Close();
        }

        public Boolean Exibir()
        {
            return true;
        }

        public static DataTable Listar(Vaga vaga)
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT * FROM AlunoVaga, Aluno WHERE CodigoVaga = @Codigo AND Matricula = MatriculaAluno;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Codigo", vaga.Codigo);
                Banco.Leitor = Banco.Comando.ExecuteReader();

                DT.Load(Banco.Leitor);
            }
            catch (Exception) { }
            finally
            {
                Banco.Conexao.Close();
            }

            return DT;
        }
    }
}