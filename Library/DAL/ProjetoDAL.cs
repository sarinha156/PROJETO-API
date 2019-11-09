using Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ProjetoDAL
    {
        public static int Insert(Projeto p)
        {
            
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TB_PROJETOS ");
                sql.AppendLine("(TX_NOME, TX_ORIENTADORES, TX_SALA, TX_TURMA) ");
                sql.AppendLine("VALUES (@TX_NOME, @TX_ORIENTADORES, @TX_SALA, @TX_TURMA) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TX_NOME", p.Nome);
                    cmd.Parameters.AddWithValue("@TX_ORIENTADORES", p.Orientadores);
                    cmd.Parameters.AddWithValue("@TX_SALA", p.Sala);
                    cmd.Parameters.AddWithValue("@TX_TURMA", p.Turma);                    

                    con.Open();
                    
                    p.Id = Convert.ToInt32(cmd.ExecuteScalar());                    
                    con.Close();
                }
            }
            return p.Id;
        }

        public static int Update(Projeto p)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TB_PROJETOS SET ");
                sql.AppendLine("TX_NOME = @TX_NOME, ");
                sql.AppendLine("TX_ORIENTADORES = @TX_ORIENTADORES, ");
                sql.AppendLine("TX_SALA = @TX_SALA, ");
                sql.AppendLine("TX_TURMA = @TX_TURMA ");
                sql.AppendLine("WHERE ID = @ID ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TX_NOME", p.Nome);
                    cmd.Parameters.AddWithValue("@TX_ORIENTADORES", p.Orientadores);
                    cmd.Parameters.AddWithValue("@TX_SALA", p.Sala);
                    cmd.Parameters.AddWithValue("@TX_TURMA", p.Turma);
                    cmd.Parameters.AddWithValue("@ID", p.Id);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return linhasAfetadas;
        }

        public static int Delete(int id)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                string sql = "DELETE FROM TB_PROJETOS WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public static List<Projeto> GetAll()
        {
            List<Projeto> listaProjetos = new List<Projeto>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ID, a.TX_NOME, a.TX_ORIENTADORES, a.TX_SALA, a.TX_TURMA, a.FL_ATIVO");
                sql.AppendLine("FROM TB_PROJETOS a ");
                sql.AppendLine("WHERE a.FL_ATIVO = 1 ");
                sql.AppendLine("ORDER BY a.TX_NOME ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Projeto p = new Projeto();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                p.Id = Convert.ToInt32(dr["ID"]);
                                p.Nome = dr["TX_NOME"].ToString();
                                p.Orientadores = dr["TX_ORIENTADORES"].ToString();
                                p.Sala = dr["TX_SALA"].ToString();
                                p.Turma = dr["TX_TURMA"].ToString();

                                listaProjetos.Add(p);//Adicionando o objeto para a lista
                            }
                        }
                    }
                }
            }
            return listaProjetos;
        }
                
        public static Projeto GetById(int id)
        {
            Projeto p = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ID, a.TX_NOME, a.TX_ORIENTADORES, a.TX_SALA, a.TX_TURMA, a.FL_ATIVO");
                sql.AppendLine("FROM TB_PROJETOS a ");
                sql.AppendLine("WHERE a.ID = @ID and a.FL_ATIVO = 1 ");
                sql.AppendLine("ORDER BY a.TX_NOME ");


                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@ID", id); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                p = new Projeto();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                p.Id = Convert.ToInt32(dr["ID"]);
                                p.Nome = dr["TX_NOME"].ToString();
                                p.Orientadores = dr["TX_ORIENTADORES"].ToString();
                                p.Sala = dr["TX_SALA"].ToString();
                                p.Turma = dr["TX_TURMA"].ToString();

                            }
                        }

                    }
                }
            }
            return p;
        }
    }
}
