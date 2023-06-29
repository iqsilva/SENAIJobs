using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SENAI_Jobs
{
    public class Usuario : BD
    {
        public String Login { get; set; }
        public String Senha { get; set; }
        public Boolean Administrador { get; set; }
        public Aluno Aluno { get; set; }
        public Empresa Empresa { get; set; }

        public Usuario() {}

        public Usuario(String Login, String Senha)
        {
            Conexao.Open();

            this.Login = Login;
            this.Senha = Senha;

            String SQL = "SELECT Usuario.*, Aluno.Matricula, Empresa.CNPJ " +
                         "FROM Usuario " +
                         "LEFT JOIN Aluno ON Usuario.Login = Aluno.LoginUsuario " +
                         "LEFT JOIN Empresa ON Usuario.Login = Empresa.LoginUsuario " +
                         "WHERE Usuario.Login = @Login AND Usuario.Senha = @Senha;";

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Login", this.Login);
            Comando.Parameters.AddWithValue("@Senha", this.Senha);

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Administrador = Convert.ToBoolean(Leitor["Administrador"]);

            if (Leitor["Matricula"].ToString().Equals("") && this.Administrador == false)
            {
                String CNPJ = Leitor["CNPJ"].ToString();
                this.Empresa = new Empresa(CNPJ, this);
            }
            else if (Leitor["CNPJ"].ToString().Equals("") && this.Administrador == false)
            {
                int Matricula = Convert.ToInt32(Leitor["Matricula"].ToString());
                this.Aluno = new Aluno(Matricula, this);
            }

            Conexao.Close();
        }

        public static Boolean Autenticar(String Login, String Senha)
        {
            BD BancoDeDados = new BD();

            BancoDeDados.Conexao.Open();

            BancoDeDados.Comando = new SqlCommand("SELECT * FROM Usuario WHERE Login = @Login and Senha = @Senha;", BancoDeDados.Conexao);
            BancoDeDados.Comando.Parameters.AddWithValue("@Login", Login);
            BancoDeDados.Comando.Parameters.AddWithValue("@Senha", Senha);
            // Passar todos os parâmetros

            BancoDeDados.Leitor = BancoDeDados.Comando.ExecuteReader();

            Boolean Retorno;
            if (BancoDeDados.Leitor.HasRows)
                Retorno = true;
            else
                Retorno = false;

            BancoDeDados.Conexao.Close();

            return Retorno;
        }

        public Boolean CadastrarAdministrador(String Login , String Senha)
        {
            // Cadastro de usuário administrador somente.
            Boolean Retorno = false;

            try
            {
                Conexao.Open();

                Comando = new SqlCommand();
                Comando.Connection = Conexao;
                Comando.Transaction = Conexao.BeginTransaction();

                Comando.CommandText = "INSERT INTO Usuario (Login, Senha, Administrador) VALUES (@Login, @Senha, 1);";
                Comando.Parameters.AddWithValue("@Login", Login);
                Comando.Parameters.AddWithValue("@Senha", Senha);
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