using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace SENAI_Jobs
{
    public class Habilidade : BD
    {
        public int Codigo { get; set; }
        public String Descricao { get; set; }

        public Habilidade(){}

        public  Habilidade ( int Codigo, String Descricao)
        {
            this.Codigo = Codigo;
            this.Descricao = Descricao;

        }
          public Boolean Adicionar()
        {
            Conexao.Open();

            Comando = new SqlCommand("INSERT INTO Habilidade (Codigo, Descricao) VALUES (@Codigo, @Descricao);");
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);
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

            Comando = new SqlCommand("UPDATE Habilidade SET Descricao = @Descricao WHERE Codigo = @Codigo;");
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

            Comando = new SqlCommand("DELETE FROM Habilidade WHERE Codigo = @Codigo;");
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

        public static DataTable ListarInformatica()
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT * FROM Habilidade WHERE Area = 'Informática'", Banco.Conexao);

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

        public static DataTable ListarInstrumentacao()
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT * FROM Habilidade WHERE Area = 'Instrumentação'", Banco.Conexao);

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

        public static DataTable ListarAlimentos()
        {
            BD Banco = new BD();
            DataTable DT = new DataTable();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT * FROM Habilidade WHERE Area = 'Alimentos'", Banco.Conexao);

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

        public static List<int> Listar(int Matricula)
        {
            BD Banco = new BD();
            List<int> Habilidades = new List<int>();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT CodigoHabilidade FROM HabilidadeCurriculo WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);

                Banco.Leitor = Banco.Comando.ExecuteReader();

                while (Banco.Leitor.Read())
                {
                    Habilidades.Add(Convert.ToInt32(Banco.Leitor[0]));
                }
            }
            catch (Exception) { }
            finally
            {
                Banco.Conexao.Close();
            }

            return Habilidades;
        }

        public static Boolean Associar(int Matricula, int CodigoHabilidade)
        {
            BD Banco = new BD();
            Boolean Retorno = false;

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("INSERT INTO HabilidadeCurriculo (MatriculaAluno, CodigoHabilidade) VALUES (@Matricula, @Habilidade);", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);
                Banco.Comando.Parameters.AddWithValue("@Habilidade", CodigoHabilidade);

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

                Banco.Comando = new SqlCommand("DELETE FROM HabilidadeCurriculo WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
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