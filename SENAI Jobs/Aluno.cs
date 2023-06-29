using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SENAI_Jobs
{
    
    public class Aluno : BD
    {
        //private SENAI_Jobs.Usuario U;

        public String CPF { get; set; } // Propriedade Autodeclarada
        public String LoginUsuario { get; set; }
        public String Senha { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Genero { get; set; }
        public String Curso { get; set; }
        public String CursoDoCurriculo { get; set; }
        public String Instituicao { get; set; }
        public int Matricula { get; set; }
        public String Endereco { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public DateTime DataNascimento { get; set; }
        public Boolean Ativo { get; set; }
        public Vaga[] Vagas { get; set; }
        public Curriculo Curriculo { get; set; }
        public Usuario Usuario { get; set; }

        public Aluno() {}

         public Aluno(Usuario U)
        {
            Conexao.Open();

            this.Matricula = Matricula;

            String SQL = "SELECT Aluno.* " +
                         "FROM Aluno " +
                         "JOIN Usuario ON Aluno.LoginUsuario = Usuario.Login " +
                         "WHERE Usuario.Login=@Login AND Usuario.Senha=@Senha;";

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Login", U.Login);
            Comando.Parameters.AddWithValue("@Senha", U.Senha);

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Matricula = int.Parse(Leitor["Matricula"].ToString());
            this.LoginUsuario = Leitor["LoginUsuario"].ToString();
            this.CPF = Leitor["CPF"].ToString();
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

            if (Leitor["Ativo"].ToString() == "1")
                this.Ativo = true;
            else
                this.Ativo = false;

            this.Usuario = U;

            Conexao.Close();
        }

        public Aluno(int Matricula)
        {
            Conexao.Open();

            this.Matricula = Matricula;

            String SQL = "SELECT Aluno.*, Usuario.Login, Usuario.Senha " +
                         "FROM Aluno " +
                         "JOIN Usuario ON Aluno.LoginUsuario = Usuario.Login " +
                         "WHERE Aluno.Matricula = @Matricula;";


            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Matricula", this.Matricula);
                   

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.LoginUsuario = Leitor["LoginUsuario"].ToString();
            this.CPF = Leitor["CPF"].ToString();
            this.Nome = Leitor["Nome"].ToString();
            this.Email = Leitor["Email"].ToString();
            this.Telefone = Leitor["Telefone"].ToString();
            this.Genero = Leitor["Genero"].ToString();
            this.Curso = Leitor["Curso"].ToString();
            //this.Instituicao = Leitor["Instituicao"].ToString();
            this.Endereco = Leitor["Endereco"].ToString();
            this.Bairro = Leitor["Bairro"].ToString();
            this.Cidade = Leitor["Cidade"].ToString();
            this.Estado = Leitor["Estado"].ToString();
            this.DataNascimento = DateTime.Parse(Leitor["DataNascimento"].ToString());

            if (Leitor["Ativo"].ToString() == "1")
                this.Ativo = true;
            else
                this.Ativo = false;

            this.Usuario = new Usuario(Leitor["Login"].ToString(), Leitor["Senha"].ToString());

            Conexao.Close();
            //TODO: Falta criar preencher os atributos curriculo e vaga
        }

        public Aluno(int Matricula, Usuario U)
        {
            Conexao.Open();

            this.Matricula = Matricula;

            String SQL = "SELECT * FROM Aluno WHERE Matricula = @Matricula;";


            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Matricula", this.Matricula);

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.LoginUsuario = Leitor["LoginUsuario"].ToString();
            this.CPF = Leitor["CPF"].ToString();
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

            if (Leitor["Ativo"].ToString() == "1")
                this.Ativo = true;
            else
                this.Ativo = false;

            this.Usuario = U;

            Conexao.Close();
            //TODO: Falta criar preencher os atributos curriculo e vaga
        }

        public Aluno(int Matricula , String LoginUsuario, String CPF, String Nome, String Email, String Telefone, String Genero, String Curso, String Instituicao, String Endereco, String Bairro, String Cidade, String Estado, DateTime DataNascimento, Boolean Ativo, Vaga[] Vagas, Curriculo Curriculo, Usuario Usuario)
        {
            this.Matricula = Matricula;
            this.LoginUsuario = LoginUsuario;
            this.Senha = Senha;
            this.CPF = CPF;
            this.Nome = Nome;
            this.Email = Email;
            this.Telefone = Telefone;
            this.Genero = Genero;
            this.Curso = Curso;
            this.Instituicao = Instituicao;
            this.Endereco = Endereco;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.DataNascimento = DataNascimento;
            this.Ativo = Ativo;
            this.Vagas = Vagas;
            this.Curriculo = Curriculo;
            this.Usuario = Usuario;
        }

      

        public Boolean Cadastrar(String Login, String Senha)
        {
            Boolean Retorno = false;

            try
            {
                Conexao.Open();

                Comando = new SqlCommand();
                Comando.Connection = Conexao;
                Comando.Transaction = Conexao.BeginTransaction();

                Comando.CommandText = "INSERT INTO Usuario (Login, Senha, Administrador) VALUES (@Login, @Senha, 0);";
                Comando.Parameters.AddWithValue("@Login", Login);
                Comando.Parameters.AddWithValue("@Senha", Senha);
                int CadastroUsuario = Comando.ExecuteNonQuery();

                Comando.Parameters.Clear();

                Comando.CommandText = "INSERT INTO Aluno (Matricula, LoginUsuario, CPF, Nome, Email, Telefone, Genero, Curso, Endereco, Bairro, Cidade, Estado, DataNascimento , Ativo) VALUES (@Matricula, @LoginUsuario, @CPF, @Nome, @Email, @Telefone, @Genero, @Curso, @Endereco, @Bairro, @Cidade, @Estado, @DataNascimento,0);";
                Comando.Parameters.AddWithValue("@Matricula", this.Matricula);
                Comando.Parameters.AddWithValue("@LoginUsuario", this.LoginUsuario);
                Comando.Parameters.AddWithValue("@CPF", this.CPF);
                Comando.Parameters.AddWithValue("@Nome", this.Nome);
                Comando.Parameters.AddWithValue("@Email", this.Email);
                Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
                Comando.Parameters.AddWithValue("@Genero", this.Genero);
                Comando.Parameters.AddWithValue("@Curso", this.Curso);
                Comando.Parameters.AddWithValue("@Endereco", this.Endereco);
                Comando.Parameters.AddWithValue("@Bairro", this.Bairro);
                Comando.Parameters.AddWithValue("@Cidade", this.Cidade);
                Comando.Parameters.AddWithValue("@Estado", this.Estado);
                Comando.Parameters.AddWithValue("@DataNascimento", this.DataNascimento);
                Comando.Parameters.AddWithValue("@Ativo", 0);
                int CadastroAluno = Comando.ExecuteNonQuery();

                if (CadastroUsuario > 0 && CadastroAluno > 0)
                {
                    Comando.Transaction.Commit();
                    Retorno = true;
                }
                else
                {
                    Comando.Transaction.Rollback();
                    Retorno = false;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                Conexao.Close();
            }

            return Retorno;
        }

        public Boolean Alterar()
        {
            Boolean Retorno = false;
            try
            {
            Conexao.Open();
            Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.Transaction = Conexao.BeginTransaction();

            Comando.CommandText = "UPDATE Aluno SET Nome = @Nome , Email = @Email , Telefone = @Telefone , Genero = @Genero , Curso = @Curso , Endereco = @Endereco , Bairro = @Bairro , Cidade = @Cidade , Estado = @Estado , DataNascimento = @DataNascimento WHERE Matricula = @Matricula;";
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
            Comando.Parameters.AddWithValue("@Genero", this.Genero);
            Comando.Parameters.AddWithValue("@Curso", this.Curso);
            Comando.Parameters.AddWithValue("@Endereco", this.Endereco);
            Comando.Parameters.AddWithValue("@Bairro", this.Bairro);
            Comando.Parameters.AddWithValue("@Cidade", this.Cidade);
            Comando.Parameters.AddWithValue("@Estado", this.Estado);
           Comando.Parameters.AddWithValue("@DataNascimento", this.DataNascimento);
            Comando.Parameters.AddWithValue("@Matricula", this.Matricula);


            if (Comando.ExecuteNonQuery() > 0)
            {
                Comando.Transaction.Commit();
                Retorno = true;
            }
            else
            {
                Comando.Transaction.Rollback();
                Retorno = false;
            }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                Conexao.Close();
            }

            return Retorno;   
            
        }

        public Boolean Excluir()
        {
                Conexao.Open();

                Comando = new SqlCommand();
                Comando.Connection = Conexao;
                Comando.CommandText = "DELETE FROM AlunoVaga WHERE MatriculaAluno = @Matricula;";
                Comando.Parameters.AddWithValue("@Matricula", this.Matricula);
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM EscolaridadeAluno WHERE MatriculaAluno = @Matricula;";
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM ExperienciaProfissional WHERE MatriculaAluno = @Matricula;";
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM HabilidadeCurriculo WHERE MatriculaAluno = @Matricula;";
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM IdiomaCurriculo WHERE MatriculaAluno = @Matricula;";
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM Aluno WHERE LoginUsuario = @Login";
                Comando.Parameters.AddWithValue("@Login", this.LoginUsuario);
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM Usuario WHERE Login = @Login;";
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM Aluno WHERE Matricula = @Matricula;";
                Comando.ExecuteNonQuery();

                Boolean Retorno;

                if (Comando.ExecuteNonQuery() > 0)
                    Retorno = false;
                else
                    Retorno = true;

            Conexao.Close();

            return Retorno;
        }

        public Boolean Procurar()
        {
            Conexao.Open();
            Comando = new SqlCommand("SELECT * FROM Aluno WHERE Matricula = @Matricula;");
            Comando.Parameters.AddWithValue("@Matricula", this.Matricula);


            Boolean Retorno;
            if (Comando.ExecuteNonQuery() > 0)
                Retorno = true;
            else
                Retorno = false;

            Conexao.Close();

            return Retorno;
        }

        public static DataTable ListarAluno(Boolean Ativo)
        {
            DataTable DT = new DataTable();
            BD Banco = new BD();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT Matricula, Nome FROM Aluno WHERE Ativo=@Ativo", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Ativo", Ativo);

                Banco.Leitor = Banco.Comando.ExecuteReader();
                DT.Load(Banco.Leitor);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                Banco.Conexao.Close();
            }

            return DT;
        }

        public static DataTable ListarAluno()
        {
            DataTable DT = new DataTable();
            BD Banco = new BD();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT Matricula, Nome FROM Aluno;", Banco.Conexao);

                Banco.Leitor = Banco.Comando.ExecuteReader();
                DT.Load(Banco.Leitor);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                Banco.Conexao.Close();
            }

            return DT;
        }
        public Boolean Ativar()
        {
            Conexao.Open();

            Comando = new SqlCommand("UPDATE Aluno SET Ativo = @Ativo WHERE Matricula=@Matricula", Conexao);
            Comando.Parameters.AddWithValue("@Ativo", 1);
            Comando.Parameters.AddWithValue("@Matricula", this.Matricula);
           
            Boolean Retorno;
            if (Comando.ExecuteNonQuery() > 0)
                Retorno = true;
            else
                Retorno = false;

            Conexao.Close();

            return Retorno;
        }
        public Boolean EsqueceuSenha()
        {
            Boolean Retorno = false;

            try
            {
                Conexao.Open();

                Comando = new SqlCommand();
                Comando.Connection = Conexao;
                Comando.Transaction = Conexao.BeginTransaction();

                Comando.CommandText = "UPDATE Usuario SET Senha = @NovaSenha WHERE Login = @Login;";
                Comando.Parameters.AddWithValue("@Login", LoginUsuario);
                Comando.Parameters.AddWithValue("@NovaSenha", Senha);
                int CadastroUsuario = Comando.ExecuteNonQuery();


                Comando.Parameters.Clear();

                if (CadastroUsuario == 1)
                {
                    Comando.Transaction.Commit();
                    Retorno = true;
                }
                else
                {
                    Comando.Transaction.Rollback();
                    Retorno = false;
                }
            }

            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
            return Retorno;
        }
       
    }
}