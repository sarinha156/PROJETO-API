using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ConnectionFactory
    {
        /*         
        MS SQL Server address:	VotacaoProjetos.mssql.somee.com
        Login name:	VotaProjetos

        Login password:	has102019
        
        Connection string:	workstation id=VotacaoProjetos.mssql.somee.com;packet size=4096;user id=VotaProjetos;pwd=has102019;data source=VotacaoProjetos.mssql.somee.com;persist security info=False;initial catalog=VotacaoProjetos     
             
        */


        //Variável declarada para memorizar o nome da chave no Web.Config
        //public static string nomeConexao = "ConexaoSomee";
        public static string nomeConexao = "ConexaoHoracio";


        //Método retornará o caminho da conexão utilizando a variável declarada anteriormente.        
        public static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings[nomeConexao].ConnectionString;
        }

        public bool TestarConexao()
        {
            bool conectado = false;

            try
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    conectado = (con.State == System.Data.ConnectionState.Open);
                    con.Close();
                    return conectado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao estabelecer conexão: " + ex.Message);
            }
        }
    }
}
