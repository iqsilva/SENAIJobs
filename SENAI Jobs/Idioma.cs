using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace SENAI_Jobs
{
    public class Idioma : BD
    {
        public String Lingua { get; set; }
        public int Codigo { get; set; }

        public Idioma() {}

        public Idioma(String Lingua, int Codigo) {
            this.Codigo = Codigo;
            this.Lingua = Lingua;

        }
        public Boolean Adicionar()
        {
            Conexao.Open();

            Comando = new SqlCommand("INSERT INTO Idioma (Codigo, Lingua) VALUES (@Codigo, @Lingua);");
            Comando.Parameters.AddWithValue("@Codigo", this.Codigo);
            Comando.Parameters.AddWithValue("@Lingua", this.Lingua);
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

            Comando = new SqlCommand("UPDATE Idioma SET Lingua = @Lingua WHERE Codigo = @Codigo;");
            Comando.Parameters.AddWithValue("@Lingua", this.Lingua);
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

            Comando = new SqlCommand("DELETE FROM Idioma WHERE Codigo = @Codigo;");
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

                Banco.Comando = new SqlCommand("SELECT * FROM Idioma;", Banco.Conexao);

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
            List<int> Idiomas = new List<int>();

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("SELECT CodigoIdioma FROM IdiomaCurriculo WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);

                Banco.Leitor = Banco.Comando.ExecuteReader();

                while (Banco.Leitor.Read())
                {
                    Idiomas.Add(Convert.ToInt32(Banco.Leitor[0]));
                }
            }
            catch (Exception) { }
            finally
            {
                Banco.Conexao.Close();
            }

            return Idiomas;
        }

        public static Boolean Associar(int Matricula, int CodigoIdioma)
        {
            BD Banco = new BD();
            Boolean Retorno = false;

            try
            {
                Banco.Conexao.Open();

                Banco.Comando = new SqlCommand("INSERT INTO IdiomaCurriculo (MatriculaAluno, CodigoIdioma) VALUES (@Matricula, @Idioma);", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Matricula", Matricula);
                Banco.Comando.Parameters.AddWithValue("@Idioma", CodigoIdioma);

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

                Banco.Comando = new SqlCommand("DELETE FROM IdiomaCurriculo WHERE MatriculaAluno = @Matricula;", Banco.Conexao);
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