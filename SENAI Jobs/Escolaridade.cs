using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace SENAI_Jobs
{
    public class Escolaridade : BD
    {
        public int Codigo { get; set; }
        public string Nivel { get; set; }


        public Escolaridade(){}

        public Escolaridade(Aluno Matricula , int Codigo) {
            this.Codigo = Codigo;
            this.Nivel = Nivel;


        }

         public Escolaridade(int Codigo)
        {
            Conexao.Open();

            this.Codigo = Codigo;

            String SQL = "SELECT Nivel FROM Escolaridade WHERE Codigo = @Codigo";
                         

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Nivel = Leitor["Nivel"].ToString();

            Conexao.Close();
        }

        public Boolean Adicionar()
        {
            Conexao.Open();

            Comando = new SqlCommand("INSERT INTO Escolaridade (Codigo, Nivel) VALUES (@Codigo, @Nivel);");
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);

            // Passar todos os parâmetros

            Boolean Retorno;
            if (Comando.ExecuteNonQuery() > 0)
                Retorno = true;
            else
                Retorno = false;

            Conexao.Close();

            return Retorno;
        }
        public Boolean Alterar()
        {
            Conexao.Open();

            Comando = new SqlCommand("UPDATE Escolaridade SET Nivel = @Nivel WHERE Codigo = @Codigo;");
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);
            // Passar todos os parâmetros

            Boolean Retorno;
            if (Comando.ExecuteNonQuery() > 0)
                Retorno = true;
            else
                Retorno = false;

            Conexao.Close();

            return Retorno;
        }
        public Boolean Excluir()
        {
            Conexao.Open();

            Comando = new SqlCommand("DELETE FROM Escolaridade WHERE Codigo = @Codigo;");
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);

            // Passar todos os parâmetros

            Boolean Retorno;
            if (Comando.ExecuteNonQuery() > 0)
                Retorno = true;
            else
                Retorno = false;

            Conexao.Close();

            return Retorno;
        }

        public static DataTable Listar()
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT * FROM Escolaridade;", Banco.Conexao);

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

        
        public static Boolean Associar(int Matricula, int CodigoEscolaridade  , String CursoDoCurriculo , String Instituicao)
        {
            BD Banco = new BD();
            Boolean Retorno = false;

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("DELETE FROM EscolaridadeAluno WHERE MatriculaAluno = @Matricula", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);
                if (Banco.Comando.ExecuteNonQuery() == 0)
                    Retorno = false;

                Banco.Comando = new SqlCommand("INSERT INTO EscolaridadeAluno (MatriculaAluno, CodigoEscolaridade,  Curso, Instituicao) VALUES (@Matricula, @CodigoEscolaridade, @Curso, @Instituicao );", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);
                Banco.Comando.Parameters.AddWithValue("@CodigoEscolaridade",CodigoEscolaridade);
                Banco.Comando.Parameters.AddWithValue("@Curso", CursoDoCurriculo);
                Banco.Comando.Parameters.AddWithValue("@Instituicao", Instituicao);

                if (Banco.Comando.ExecuteNonQuery() > 0)
                    Retorno = true;
                else
                    Retorno = false;
            }
            catch (Exception) { }
            finally
            {
                Banco.Conexao.Close();
            }

            return Retorno;
        }

        public static Boolean LimparAssociacao(int Matricula)
        {
            BD Banco = new BD();
            Boolean Retorno = false;

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("DELETE FROM EscolaridadeAluno WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);

                if (Banco.Comando.ExecuteNonQuery() > 0)
                    Retorno = true;
                else
                    Retorno = false;
            }
            catch (Exception) { }
            finally
            {
                Banco.Conexao.Close();
            }

            return Retorno;
        }


        public static Escolaridade BuscarPorAluno(int Matricula) {
            BD Banco = new BD();
            Escolaridade Retorno = new Escolaridade ();

            try
            {
                Banco.Conexao.Open();

                 Banco.Comando = new SqlCommand("SELECT CodigoEscolaridade, CursoDoCurriculo, Instituicao FROM EscolaridadeAluno WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
                 Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);
                 Banco.Leitor = Banco.Comando.ExecuteReader();
                 Banco.Leitor.Read();
                 Retorno.Codigo = Convert.ToInt32(Banco.Leitor["CodigoEscolaridade"].ToString());


            }
            catch (Exception) { }
            finally
            {
                Banco.Conexao.Close();

            }
            return Retorno;
        }
    }
}