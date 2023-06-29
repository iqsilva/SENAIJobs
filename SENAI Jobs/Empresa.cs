using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace SENAI_Jobs
{
    public class Empresa :BD
    {
        public String CNPJ { get; set; }
        public String LoginUsuario { get; set; }
        public String Senha { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String CEP { get; set; }
        public String Endereco { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public Boolean Ativo { get; set; }
        public Usuario Usuario { get; set; }

        public Empresa(){}

        public Empresa(Usuario U)
        {
            Conexao.Open();

            this.CNPJ = CNPJ;

            String SQL = "SELECT Empresa.* " +
                         "FROM Empresa " +
                         "JOIN Usuario ON Empresa.LoginUsuario = Usuario.Login " +
                         "WHERE Usuario.Login=@Login AND Usuario.Senha=@Senha;";

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Login", U.Login);
            Comando.Parameters.AddWithValue("@Senha", U.Senha);

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.CNPJ = Leitor["CNPJ"].ToString();
            this.LoginUsuario = Leitor["LoginUsuario"].ToString();
            this.RazaoSocial = Leitor["RazaoSocial"].ToString();
            this.NomeFantasia = Leitor["NomeFantasia"].ToString();
            this.Email = Leitor["Email"].ToString();
            this.Telefone = Leitor["Telefone"].ToString();
            this.CEP = Leitor["CEP"].ToString();
            this.Endereco = Leitor["Endereco"].ToString();
            this.Bairro = Leitor["Bairro"].ToString();
            this.Cidade = Leitor["Cidade"].ToString();
            this.Estado = Leitor["Estado"].ToString();

            if (Leitor["Ativo"].ToString() == "1")
                this.Ativo = true;
            else
                this.Ativo = false;

            this.Usuario = U;

            Conexao.Close();
        }

        public Empresa(String CNPJ)
        {
            Conexao.Open();

            this.CNPJ = CNPJ;

            String SQL = "SELECT Empresa.*, Usuario.Login, Usuario.Senha " +
                         "FROM Empresa " +
                         "JOIN Usuario ON Empresa.LoginUsuario = Usuario.Login " +
                         "WHERE Empresa.CNPJ = @CNPJ;";

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@CNPJ", this.CNPJ);

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.LoginUsuario = Leitor["LoginUsuario"].ToString();
            this.RazaoSocial = Leitor["RazaoSocial"].ToString();
            this.NomeFantasia = Leitor["NomeFantasia"].ToString();
            this.Email = Leitor["Email"].ToString();
            this.Telefone = Leitor["Telefone"].ToString();
            this.CEP = Leitor["CEP"].ToString();
            this.Endereco = Leitor["Endereco"].ToString();
            this.Bairro = Leitor["Bairro"].ToString();
            this.Cidade = Leitor["Cidade"].ToString();
            this.Estado = Leitor["Estado"].ToString();

            if (Leitor["Ativo"].ToString() == "1")
                this.Ativo = true;
            else
                this.Ativo = false;

            this.Usuario = new Usuario(Leitor["Login"].ToString(), Leitor["Senha"].ToString());

            Conexao.Close();
        }

        public Empresa(String CNPJ, Usuario U)
        {
            Conexao.Open();

            this.CNPJ = CNPJ;

            String SQL = "SELECT * FROM Empresa WHERE CNPJ = @CNPJ;";

            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@CNPJ", this.CNPJ);

            Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.LoginUsuario = Leitor["LoginUsuario"].ToString();
            this.RazaoSocial = Leitor["RazaoSocial"].ToString();
            this.NomeFantasia = Leitor["NomeFantasia"].ToString();
            this.Email = Leitor["Email"].ToString();
            this.Telefone = Leitor["Telefone"].ToString();
            this.CEP = Leitor["CEP"].ToString();
            this.Endereco = Leitor["Endereco"].ToString();
            this.Bairro = Leitor["Bairro"].ToString();
            this.Cidade = Leitor["Cidade"].ToString();
            this.Estado = Leitor["Estado"].ToString();

            if (Leitor["Ativo"].ToString() == "1")
                this.Ativo = true;
            else
                this.Ativo = false;

            this.Usuario = U;

            Conexao.Close();
        }

        public Empresa(String CNPJ, String LoginUsuario, String RazaoSocial, String NomeFantasia, String Email, String Telefone, String CEP, String Endereco, String Bairro,
            String Cidade, String Estado, Usuario Usuario)
        {
            this.CNPJ = CNPJ;
            this.LoginUsuario = LoginUsuario;
            this.Senha = Senha;
            this.RazaoSocial = RazaoSocial;
            this.NomeFantasia = NomeFantasia;
            this.Email = Email;
            this.Telefone = Telefone;
            this.CEP = CEP;
            this.Endereco = Endereco;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.Usuario = Usuario;
            this.Ativo = Ativo;
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

                Comando.CommandText = "INSERT INTO Empresa (CNPJ, LoginUsuario, RazaoSocial, NomeFantasia, Email, Telefone, CEP, Endereco, Bairro, Cidade, Estado, Ativo) VALUES (@CNPJ, @LoginUsuario, @RazaoSocial, @NomeFantasia, @Email, @Telefone, @CEP, @Endereco, @Bairro, @Cidade, @Estado,0);";
                Comando.Parameters.AddWithValue("@CNPJ", this.CNPJ);
                Comando.Parameters.AddWithValue("@LoginUsuario", this.LoginUsuario);
                Comando.Parameters.AddWithValue("@RazaoSocial", this.RazaoSocial);
                Comando.Parameters.AddWithValue("@NomeFantasia", this.NomeFantasia);
                Comando.Parameters.AddWithValue("@Email", this.Email);
                Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
                Comando.Parameters.AddWithValue("@CEP", this.CEP);
                Comando.Parameters.AddWithValue("@Endereco", this.Endereco);
                Comando.Parameters.AddWithValue("@Bairro", this.Bairro);
                Comando.Parameters.AddWithValue("@Cidade", this.Cidade);
                Comando.Parameters.AddWithValue("@Estado", this.Estado);
                Comando.Parameters.AddWithValue("@Ativo", 0);
                int CadastroEmpresa = Comando.ExecuteNonQuery();
                // Passar todos os parâmetros

                if (CadastroUsuario > 0 && CadastroEmpresa > 0)
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

                Comando.CommandText = "UPDATE Empresa SET RazaoSocial = @RazaoSocial , NomeFantasia = @NomeFantasia , Email = @Email , Telefone = @Telefone , CEP = @CEP , Endereco = @Endereco , Bairro = @Bairro , Cidade = @Cidade , Estado = @Estado WHERE CNPJ = @CNPJ;";
                Comando.Parameters.AddWithValue("@RazaoSocial", this.RazaoSocial);
                Comando.Parameters.AddWithValue("@NomeFantasia", this.NomeFantasia);
                Comando.Parameters.AddWithValue("@Email", this.Email);
                Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
                Comando.Parameters.AddWithValue("@CEP", this.CEP);
                Comando.Parameters.AddWithValue("@Endereco", this.Endereco);
                Comando.Parameters.AddWithValue("@Bairro", this.Bairro);
                Comando.Parameters.AddWithValue("@Cidade", this.Cidade);
                Comando.Parameters.AddWithValue("@Estado", this.Estado);
                Comando.Parameters.AddWithValue("@CNPJ", this.CNPJ);
                // Passar todos os parâmetros
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

                Comando.CommandText = "DELETE FROM Vaga WHERE CNPJEmpresa = @CNPJ";
                Comando.Parameters.AddWithValue("@CNPJ", this.CNPJ);
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM Empresa WHERE LoginUsuario = @Login";
                Comando.Parameters.AddWithValue("@Login", this.LoginUsuario);
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM Usuario WHERE Login = @Login;";
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE FROM Empresa WHERE CNPJ = @CNPJ;";
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
            Comando = new SqlCommand("SELECT * FROM Empresa WHERE Empresa = @Empresa;");
            Comando.Parameters.AddWithValue("@CNPJ", this.CNPJ);
            // Passar todos os parâmetros

            Boolean Retorno;
            if (Comando.ExecuteNonQuery() > 0)
                Retorno = true;
            else
                Retorno = false;

            Conexao.Close();

            return Retorno;
          
            
        }

        public static DataTable ListarEmpresa(Boolean Ativo)
        {
            DataTable DT = new DataTable();
            BD Banco = new BD();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT CNPJ, RazaoSocial FROM Empresa WHERE Ativo=@Ativo", Banco.Conexao);
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

        public static DataTable ListarEmpresa2(Boolean Ativo)
        {
            DataTable DT = new DataTable();
            BD Banco = new BD();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT CNPJ, RazaoSocial FROM Empresa ", Banco.Conexao);

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

            Comando = new SqlCommand("UPDATE Empresa SET Ativo = @Ativo WHERE CNPJ=@CNPJ", Conexao);
            Comando.Parameters.AddWithValue("@Ativo", 1);
            Comando.Parameters.AddWithValue("@CNPJ", this.CNPJ);

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

                Comando.CommandText = "UPDATE Usuario SET Senha = @NovaSenha WHERE Login=@Login;";
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

        public int ContadordeVaga()
        {
            int Retorno = 0;

            try
            {
                Conexao.Open();

                Comando = new SqlCommand();
                Comando.Connection = Conexao;
                Comando.CommandText = "Select count (distinct Codigo) as qtd from Vaga where CNPJEmpresa = @CNPJEmpresa ;";
                Comando.Parameters.AddWithValue("@CNPJEmpresa", this.CNPJ);
                Leitor = Comando.ExecuteReader();
                Leitor.Read();

                Retorno = Convert.ToInt32(Leitor["qtd"].ToString());                                                            
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