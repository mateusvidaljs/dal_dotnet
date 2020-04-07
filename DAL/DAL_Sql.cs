using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL_Sql
    {
        /// <summary>
        /// YOU SHALL NOT... PASS!!!
        /// </summary>

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        //Construtor instanciando a conexão
        public DAL_Sql(string Servidor, string Banco, string Usuario, string Senha) 
        {
            con = new SqlConnection("DATA SOURCE=" + Servidor + ";INITIAL CATALOG=" + Banco + " ;USER ID=" + Usuario + ";Password=" + Senha + ";");
        }

        private void Abrir_conexao()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        //Insert sem passar os campos
        public void Inserir_novo_registro(string tabela, string valores)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " + tabela + " VALUES (" + valores + ");", con);
                Abrir_conexao();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //Insert passando campos
       /*public void Inserir_novo_registro(string tabela, string campos,string valores)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " + tabela + " (" + campos + ") VALUES (" + valores + ");", con);
                Abrir_conexao();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }*/

        //Alteração de registros
        public void Alterar_registros(string tabela, string valores, string condicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE " + tabela + " SET" + valores + " WHERE " + condicao + ";", con);
                Abrir_conexao();
                cmd.ExecuteNonQuery();
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //Exclusão de registros
        public void Deletar_registro(string tabela, string condicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM " + tabela + " WHERE " + condicao + ";", con);
                Abrir_conexao();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //Select de todos os registros
        public DataTable Select_registro(string tabela)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + tabela + ";", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                Abrir_conexao();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //Select com campos
        public DataTable Select_registro(string tabela, string campos)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT " + campos + " FROM " + tabela + ";", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                Abrir_conexao();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //Select com campos e condições
        public DataTable Select_registro(string tabela, string campos, string condicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT " + campos + " FROM " + tabela + " WHERE " + condicao + ";", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                Abrir_conexao();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Select_registro(string tabela, string campos, string condicao, string like)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT " + campos + " FROM " + tabela + " WHERE " + condicao + " LIKE '%" + like + "%';", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                Abrir_conexao();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //QuerySql com retorno
        public object Query_com_retorno(string tabela, string campos)
        {
            try
            {
                cmd.CommandText = string.Format("SELECT {0} FROM {1}", campos, tabela);
                Abrir_conexao();

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
