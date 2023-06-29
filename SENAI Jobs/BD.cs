using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SENAI_Jobs
{
    public class BD
    {
        private static String _ConnectionString = "Data Source=IGOR-PC;Initial Catalog=SenaiJobs;Integrated Security=True";
        public SqlConnection Conexao = new SqlConnection(_ConnectionString);
        public SqlCommand Comando ;
        public SqlDataReader Leitor ;
    }
}