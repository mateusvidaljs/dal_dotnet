using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_MySql
    {
        /// <summary>
        /// YOU SHALL NOT... PASS!!!
        /// </summary>

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;

        //Construtor instanciando a conexão
        public DAL_MySql(string Servidor, string Usuario, string Senha, string Banco) 
        {
            con = new MySqlConnection("server=" + Servidor + ";uid=" + Usuario + ";pwd=" + Senha + ";database=" + Banco);
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO " + tabela + " VALUES (" + valores + ");" ,con);
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO " + tabela + " (" + campos + ") VALUES " + valores + ";" ,con);
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
                MySqlCommand cmd = new MySqlCommand("UPDATE " + tabela + " SET " + valores + " WHERE " + condicao + ";" ,con);
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM " + tabela + " WHERE " + condicao + ";" ,con);
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
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tabela + ";" ,con);
                da = new MySqlDataAdapter(cmd);
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
            MySqlCommand cmd = new MySqlCommand("SELECT " + campos + " FROM " + tabela + ";" ,con);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            Abrir_conexao();
            da.Fill(dt);
            con.Close();

            return dt;
        }

        //Select com campos e condições
        public DataTable Select_registro(string tabela, string campos, string condicao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT " + campos + " FROM " + tabela + " WHERE " + condicao + ";" ,con);
                da = new MySqlDataAdapter(cmd);
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
