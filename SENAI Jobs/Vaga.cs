using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace SENAI_Jobs
{
    public class Vaga : BD
    {
        public int Codigo { get; set; }
        public String Descricao { get; set; }
        public String Salario { get; set; }
        public Empresa CNPJEmpresa { get; set; }
        public Escolaridade CodigoEscolaridade { get; set; }
        public Aluno Matricula { get; set; }
        public Idioma Idioma { get; set; }


        public Vaga(){}

        public Vaga(int Codigo)
        {
             Conexao.Open();

            this.Codigo = Codigo;

            String SQL = "SELECT * from Vaga where Codigo=@Codigo";
            Comando = new SqlCommand(SQL, Conexao);
            Comando.Parameters.AddWithValue("@Codigo", Codigo);
            Leitor = Comando.ExecuteReader();

            Leitor.Read();
            this.Descricao = Leitor["Descricao"].ToString();
            this.Salario = Leitor["Salario"].ToString();
            this.CNPJEmpresa = new Empresa(Leitor["CNPJEmpresa"].ToString());
            this.CodigoEscolaridade = new Escolaridade(Convert.ToInt32(Leitor["CodigoEscolaridade"].ToString()));

            Conexao.Close();
        }

        public Vaga(int Codigo, String Descricao, String Salario, Empresa CNPJEmpresa, Escolaridade CodigoEscolaridade, Idioma Idioma, Aluno Matricula)
        {
            this.Codigo = Codigo;
            this.Descricao = Descricao;
            this.Salario = Salario;
            this.CNPJEmpresa = CNPJEmpresa;
            this.CodigoEscolaridade = CodigoEscolaridade;
            this.Matricula = Matricula;
            //this.Idioma = Idioma;
        }
        public static Boolean Cadastrar( String CNPJEmpresa , int CodigoEscolaridade , String Descricao , String Salario)
        {
            BD Banco = new BD();
            Boolean Retorno = false;

            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new SqlCommand("INSERT INTO Vaga (CNPJEmpresa, CodigoEscolaridade, Descricao, Salario, DataCadastro) VALUES (@CNPJEmpresa,  @CodigoEscolaridade, @Descricao, @Salario, GETDATE());", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@CNPJEmpresa", CNPJEmpresa);
                Banco.Comando.Parameters.AddWithValue("@CodigoEscolaridade", CodigoEscolaridade);
                Banco.Comando.Parameters.AddWithValue("@Descricao", Descricao);
                Banco.Comando.Parameters.AddWithValue("@Salario", Salario);



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
        public Boolean Alterar()
        {
            Boolean Retorno = false;
            try
            {
                Conexao.Open();
                Comando = new SqlCommand();
                Comando.Connection = Conexao;
                
                
                Comando.CommandText = "UPDATE Vaga SET CodigoEscolaridade = @CodigoEscolaridade,  Descricao = @Descricao , Salario = @Salario WHERE Codigo = @Codigo;";
                
                Comando.Parameters.AddWithValue("@CodigoEscolaridade", this.CodigoEscolaridade.Codigo);
                Comando.Parameters.AddWithValue("@Descricao", this.Descricao);
                Comando.Parameters.AddWithValue("@Salario", this.Salario);
                Comando.Parameters.AddWithValue("@Codigo", this.Codigo);

                


                if (Comando.ExecuteNonQuery() > 0)
                {
                    
                    Retorno = true;
                }
                else
                {
                   
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

            Comando.CommandText = "DELETE FROM AlunoVaga WHERE CodigoVaga = @Codigo";
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);
            Comando.ExecuteNonQuery();

            Comando.CommandText = "DELETE FROM IdiomaVaga WHERE CodigoVaga = @Codigo";
            Comando.ExecuteNonQuery();

            Comando.CommandText = "DELETE FROM Vaga WHERE Codigo = @Codigo;";
            Boolean Retorno;
            if(Comando.ExecuteNonQuery() > 0)
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

                Banco.Comando = new SqlCommand("Select Vaga.Codigo AS 'Codigo da Vaga', Empresa.RazaoSocial AS Empresa, Escolaridade.Nivel AS 'Nivel de escolaridade requerido', " +
			                        "Vaga.Descricao AS 'Descrição da Vaga', Vaga.Salario AS 'Salario(R$)', Vaga.DataCadastro AS 'Data de Postagem da Vaga' " +
		                            "From Vaga " +
		                            "LEFT JOIN Escolaridade ON Escolaridade.Codigo = CodigoEscolaridade " +
		                            "LEFT JOIN Empresa ON CNPJEmpresa = Empresa.CNPJ " +
                                    "AND DATEDIFF(day, DataCadastro, getDate()) <= 7 ", Banco.Conexao); 

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

        public static DataTable Listar(String CNPJEmpresa)
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();
            
            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("Select Vaga.Codigo AS 'Codigo da Vaga', Empresa.RazaoSocial AS Empresa, Escolaridade.Nivel AS 'Nivel de escolaridade requerido', " +
			                        "Vaga.Descricao AS 'Descrição da Vaga', Vaga.Salario AS 'Salario(R$)', Vaga.DataCadastro AS 'Data de Postagem da Vaga' " +
		                            "From Vaga " +
		                            "INNER JOIN Escolaridade ON Escolaridade.Codigo = CodigoEscolaridade " +
		                            "INNER JOIN Empresa ON CNPJEmpresa = Empresa.CNPJ " +
                                    "AND Empresa.CNPJ = @CNPJ ", Banco.Conexao);
                                    
                //SELECT * FROM Vaga WHERE CNPJEmpresa = @CNPJEmpresa AND DATEDIFF(day, DataCadastro, getDate()) <= 7 ", Banco.Conexao);
                //Banco.Comando.Parameters.AddWithValue("@CNPJEmpresa", CNPJEmpresa);
                Banco.Comando.Parameters.AddWithValue("@CNPJ", CNPJEmpresa);

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
       

        public Boolean Envio(int Matricula)
        {
            BD Banco = new BD();
            Boolean Retorno = false;

            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new SqlCommand("INSERT INTO AlunoVaga (CodigoVaga, MatriculaAluno, DataEnvio) VALUES (@CodigoVaga,  @Matricula, GETDATE());", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@CodigoVaga", Codigo);
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
    }
}
