using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;

namespace AcessoBanco
{
    public class CDataService
    {
        /// <summary>
        /// Guarda String de Conexão
        /// </summary>
        private string m_ConnectionString;

        /// <summary>
        /// Objeto para conexão com o Banco
        /// </summary>
        private SqlConnection m_Connection;

        /// <summary>
        ///    Propriedade para pegar e setar conexão
        /// </summary>
        /// 
        private SqlTransaction m_transaction;

        /// <summary>
        ///    Propriedade para pegar e setar conexão
        /// </summary>
        public string ConnectionString
        {
            get { return m_ConnectionString; }
            set { m_ConnectionString = value; }
        }

        public void committransacao()
        {
            if (m_transaction != null)
            {
                m_transaction.Commit();
                CloseDataSource();
            }
        }
        public void rollbacktransacao()
        {
            if (m_transaction != null)
            {
                m_transaction.Rollback();
                CloseDataSource();
            }
        }
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public CDataService(String Banco)
        {
            String server, strconn;
            server = "Eufrasio\\SQLEXPRESS";
            string Bancoteste = "ControleAtas";
            strconn = "SERVER=" + server + ";DATABASE=" + Bancoteste + ";";
            strconn = strconn + "UID=teste;PWD=12345";   
            this.m_ConnectionString = strconn;
            OpenDataSource();
        }

        /// <summary>
        /// Abre a conexão
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public SqlConnection OpenDataSource()
        {
            //Testa se a conexão existe
            if (m_Connection == null)
            {

                try
                {
                    m_Connection = new SqlConnection(m_ConnectionString);
                    m_Connection.Open();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
            else if (m_Connection.State != ConnectionState.Open)
            {
                m_Connection.ConnectionString = m_ConnectionString;
                try
                {
                    m_Connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return m_Connection;
        }

        public SqlConnection OpenDataSourceTransaction()
        {
            //Testa se a conexão existe
            if (m_Connection == null)
            {

                try
                {
                    m_Connection = new SqlConnection(m_ConnectionString);
                    m_Connection.Open();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
            else if (m_Connection.State != ConnectionState.Open)
            {
                m_Connection.ConnectionString = m_ConnectionString;
                try
                {
                    m_Connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            m_transaction = m_Connection.BeginTransaction();

            return m_Connection;
        }

        /// <summary>
        /// Fecha a conexão
        /// </summary>
        public void CloseDataSource()
        {
            if (m_Connection != null)
            {
                if (m_Connection.State == ConnectionState.Open)
                    m_Connection.Close();
                m_Connection = null;
            }
        }
        /// <summary>
        /// Retorna um DataSet, sem a opção de fechar a conexão
        /// </summary>
        /// <param name="QueryString">Select</param>
        /// <returns>DataSet</returns>
        public DataSet SelectSqlData(string QueryString, string TableName)
        {
            {
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter();
                try
                {
                    ad.SelectCommand = new SqlCommand(QueryString, this.OpenDataSource());
                    if (TableName.Trim().Length > 0) ad.Fill(ds, TableName);
                    else ad.Fill(ds);
                }
                catch (System.Exception e)
                {
                    throw e;
                }
                finally
                {
                    this.CloseDataSource();
                }
                return ds;
            }
        }

        /// <summary>
        /// Retorna um DataSet, sem a opção de table
        /// </summary>
        /// <param name="QueryString">Select</param>
        /// <returns>DataSet</returns>
        public DataSet SelectSqlData(string QueryString)
        {
            return SelectSqlData(QueryString, "");
        }
        /// <summary>
        /// Retorna um DataReader
        /// </summary>
        /// <param name="QueryString">Select</param>
        /// <returns>DataReader</returns>

        public SqlDataReader SelectSqlReader(string QueryString)
        {
            SqlCommand cmd = new SqlCommand(QueryString, this.OpenDataSource());
            return (cmd.ExecuteReader());
        }

        /// <summary>
        /// Insert a partir de um comando ou procedure
        /// </summary>
        /// <param name="InsertString"></param>
        /// <param name="MustClose"></param>
        public int InsertSqlData(string InsertString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                da.InsertCommand = new SqlCommand(InsertString + "select @@identity", this.OpenDataSource());
                return (Int32.Parse(da.InsertCommand.ExecuteScalar().ToString()));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.CloseDataSource();
            }
        }

        public int InsertSqlDatatransacao(string InsertString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                da.InsertCommand = new SqlCommand(InsertString + "select @@identity", m_Connection, m_transaction);

                return (Int32.Parse(da.InsertCommand.ExecuteScalar().ToString()));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // this.CloseDataSource();
            }
        }


        public void InsertSqlDataVoid(string InsertString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                da.InsertCommand = new SqlCommand(InsertString, this.OpenDataSource());
                int linhas = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.CloseDataSource();
            }
        }

        /// <summary>
        /// Deleta dado
        /// </summary>
        /// <param name="DeleteString">comando sql</param>
        public void DeleteSQLData(string DeleteString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                da.DeleteCommand = new SqlCommand(DeleteString, this.OpenDataSource());
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.CloseDataSource();
            }

        }


        /// <summary>
        /// Deleta dado
        /// </summary>
        /// <param name="DeleteString">comando sql</param>
        public void DeleteSQLDataTransaction(string DeleteString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                da.DeleteCommand = new SqlCommand(DeleteString, m_Connection, m_transaction);
                da.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //  this.CloseDataSource();
            }

        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="UpdateString">Comando Sql</param>
        /// <param name="MustClose">Fecha a conexão se True</param>
        public void UpdateSQLData(string UpdateString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                da.UpdateCommand = new SqlCommand(UpdateString, this.OpenDataSource());
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.CloseDataSource();
            }
        }
        public void UpdateSQLDatatransacao(string UpdateString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {

                da.UpdateCommand = new SqlCommand(UpdateString, m_Connection, m_transaction);
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // this.CloseDataSource();
            }
        }

    }

    //Class
    public static class Util
    {
        private const int IP_SMTP_CLIENT = 1;

        public static string SQLString(string s)
        {
            return ("'" + s.Replace("'", "''") + "'");
        }
        public static void EnviaEmail(string de, string para, string titulo, string texto)
        {
            MailMessage mail = new MailMessage(de, para);
            mail.Subject = titulo;
            mail.Body = texto;
            SmtpClient smtp = new SmtpClient(PegaParametro(IP_SMTP_CLIENT));
            smtp.Send(mail);
        }
        public static string PegaParametro(int codpar)
        {
            CDataService dados = new CDataService("controleAtas");
            SqlDataReader dr = dados.SelectSqlReader("select valor from parametros where id = " + codpar.ToString());
            if (dr.Read())
            {
                return dr[0].ToString();
            }
            else
            {
                return "";
            }
        }
    }
} //Namespace