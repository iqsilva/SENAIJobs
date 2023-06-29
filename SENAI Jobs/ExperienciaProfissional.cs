using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
namespace SENAI_Jobs
{
    public class ExperienciaProfissional : BD
    {
        public int Codigo { get; set; }
        public Curriculo Curriculo { get; set; }
        public int MatriculaAluno { get; set; }
        public String NomeEmpresa { get; set; }
        public String AnosExperiencia { get; set; }
        public String Cargo { get; set; }
        public String Descricao { get; set; }
        public Aluno Aluno { get; set; }

        public ExperienciaProfissional(){}

        public ExperienciaProfissional(int Codigo, int MatriculaAluno, String NomeEmpresa, String AnosExperiencia, String Cargo, String Descricao, Curriculo Curriculo, Aluno Aluno) {
                this.Codigo = Codigo;
                this.Curriculo = Curriculo;
                this.MatriculaAluno = MatriculaAluno;
                this.NomeEmpresa = NomeEmpresa;
                this.AnosExperiencia = AnosExperiencia;
                this.Cargo = Cargo;
                this.Descricao = Descricao;
                this.Aluno = Aluno;
        }

        public ExperienciaProfissional(int Codigo)
        {
            Conexao.Open();

            String SQL = "SELECT *FROM ExperienciaProfissional where Codigo = @Codigo;";

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Codigo", Codigo);


            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Codigo = Codigo;
            this.MatriculaAluno = int.Parse(Leitor["MatriculaAluno"].ToString());
            this.NomeEmpresa = Leitor["NomeEmpresa"].ToString();
            this.AnosExperiencia = Leitor["AnosExperiencia"].ToString();
            this.Cargo = Leitor["Cargo"].ToString();
            this.Descricao = Leitor["Descricao"].ToString();

            Conexao.Close();

        }
        public Boolean Adicionar()
        {
            Conexao.Open();

            Comando = new SqlCommand("INSERT INTO ExperienciaProfissional (Codigo, NomeEmpresa, AnosExperiencia, Cargo, Descricao) VALUES (@Codigo, @NomeEmpresa, @AnosExperiencia, @Cargo, @Descricao);");
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);
            Comando.Parameters.AddWithValue("@NomeEmpresa", this.NomeEmpresa);
            Comando.Parameters.AddWithValue("@AnosExperiencia", this.AnosExperiencia);
            Comando.Parameters.AddWithValue("@Cargo", this.Cargo);
            Comando.Parameters.AddWithValue("@Descricao", this.Descricao);

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

            Comando = new SqlCommand("UPDATE ExperienciaProfissional SET NomeEmpresa = @NomeEmpresa , AnosExperiencia = @AnosExperiencia , Cargo = @Cargo , Descricao = @Descricao WHERE Codigo = @Codigo;");
            Comando.Parameters.AddWithValue("@NomeEmpresa", this.NomeEmpresa);
            Comando.Parameters.AddWithValue("@AnosExperiencia", this.AnosExperiencia);
            Comando.Parameters.AddWithValue("@Cargo", this.Cargo);
            Comando.Parameters.AddWithValue("@Descricao", this.Descricao);
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

            Comando = new SqlCommand("DELETE FROM ExperienciaProfissional WHERE Codigo = @Codigo;", Conexao);
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

                Banco.Comando = new SqlCommand("SELECT * FROM ExperienciaProfissional;", Banco.Conexao);

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

        public static Boolean Associar(int MatriculaAluno, String NomeEmpresa, String AnosExperiencia, String Cargo, String Descricao)
        {
            BD Banco = new BD();
            Boolean Retorno = false;

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("INSERT INTO ExperienciaProfissional (MatriculaAluno, NomeEmpresa, AnosExperiencia, Cargo, Descricao) VALUES (@MatriculaAluno, @NomeEmpresa, @AnosExperiencia, @Cargo, @Descricao);", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@MatriculaAluno", MatriculaAluno);
                Banco.Comando.Parameters.AddWithValue("@NomeEmpresa", NomeEmpresa);
                Banco.Comando.Parameters.AddWithValue("@AnosExperiencia", AnosExperiencia);
                Banco.Comando.Parameters.AddWithValue("@Cargo", Cargo);
                Banco.Comando.Parameters.AddWithValue("@Descricao", Descricao);


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

                Banco.Comando = new SqlCommand("DELETE FROM ExperienciaProfissional WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
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

        public static int Buscar(int Matricula)
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();
            int Retorno = 0;
            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT MatriculaAluno FROM ExperienciaProfissional WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);
                
                Banco.Leitor = Banco.Comando.ExecuteReader();
                Banco.Leitor.Read();
                Retorno = Convert.ToInt32(Banco.Leitor["MatriculaAluno"].ToString());

            }
            catch (Exception) { }
            finally
            {
                Banco.Conexao.Close();

            }
            return Retorno;
        }
        public static DataTable Listar(int MatriculaAluno)
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT * FROM ExperienciaProfissional, Aluno WHERE MatriculaAluno = @MatriculaAluno AND Matricula = MatriculaAluno", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@MatriculaAluno", MatriculaAluno);

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