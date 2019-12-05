using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SQL_Server_DLL
{
    /// <summary>
    /// SqlServer
    /// </summary>
    public class SqlServer
    {
        private static SqlConnection con;
        private static SqlDataAdapter Ada;
        private static SqlDataReader re;
        private static SqlCommand com;
        private static DataSet set;
        private static SqlTransaction tr = null;
        private static Methodstoachieve Achieve = new Methodstoachieve();
        private static DataView dv = null;
        private static SqlBulkCopy sbc;
        private static int pcl;
        class Methodstoachieve : SqlServerInterface
        {

            #region SqlServerInterface 成员

            /// <summary>
            /// Sql连接
            /// </summary>
            /// <param name="Version">数据库版本</param>
            /// <param name="Database">数据库名字</param>
            /// <param name="Account">帐号</param>
            /// <param name="Password">密码</param>
            /// <param name="Address">数据库地址</param>
            public void Creating(string Version, string Database, string Account, string Password, string Address)
            {
                switch (Version)
                {
                    case "Microsoft SQL Server 2008":
                        SqlServer.con = new SqlConnection();
                        con.ConnectionString = "server=" + Address + ";uid=" + Account + ";pwd=" + Password + ";database=" + Database + "";
                        break;
                    case "Microsoft SQL Server 2005":
                        SqlServer.con = new SqlConnection();
                        con.ConnectionString = "server=" + Address + ";uid=" + Account + ";pwd=" + Password + ";database=" + Database + "";
                        break;
                    case "Microsoft SQL Server 2000":
                        SqlServer.con = new SqlConnection();
                        con.ConnectionString = "server=" + Address + ";uid=" + Account + ";pwd=" + Password + ";database=" + Database + "";
                        break;
                    default:
                        throw new Exception("此版本类库不支持" + Version + "数据库");
                }
            }

            /// <summary>
            /// 关闭数据库连接
            /// </summary>
            public void Closetheconnection()
            {
                try
                {
                    SqlServer.con.Close();
                }
                catch (Exception d)
                {
                    throw new Exception("关闭连接失败" + d.Message);
                }
            }

            /// <summary>
            /// 运用在显示单条数据上
            /// </summary>
            /// <param name="sql">传SQL语句</param>
            /// <returns>SqlDataReader</returns>
            public SqlDataReader ReturnSqlDataReader(string sql)
            {
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    using (SqlServer.com = new SqlCommand())
                    {
                        com.CommandText = sql;
                        com.Connection = SqlServer.con;
                        SqlServer.re = SqlServer.com.ExecuteReader();
                    }
                }
                catch (Exception d)
                {
                    throw new Exception("数据行错误" + d.Message);
                }
                return SqlServer.re;
            }

            /// <summary>
            /// 运用在增删改上
            /// </summary>
            /// <param name="sql">传SQL语句</param>
            /// <returns>int</returns>
            public int Affected(string sql)
            {
                int i = 0;
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    using (SqlServer.com = new SqlCommand())
                    {
                        com.CommandText = sql;
                        com.Connection = SqlServer.con;
                        i = SqlServer.com.ExecuteNonQuery();
                    }
                }
                catch
                {
                    i = 0;
                }
                finally
                {
                    Closetheconnection();
                }
                return i;
            }

            /// <summary>
            /// 返回一个数据集
            /// </summary>
            /// <param name="sql">传SQL语句</param>
            /// <returns>DataSet</returns>
            public DataSet ReturnDataSet(string sql)
            {
                SqlServer.set = new DataSet();
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    using (SqlServer.Ada = new SqlDataAdapter(sql, SqlServer.con))
                    {
                        SqlServer.Ada.Fill(SqlServer.set);
                    }
                }
                catch (Exception d)
                {
                    throw new Exception("数据集错误" + d.Message);
                }
                finally
                {
                    Closetheconnection();
                }
                return SqlServer.set;
            }

            /// <summary>
            /// 登陆验证用返回0或1，0是登陆失败1是登陆成功
            /// </summary>
            /// <param name="sql">传SQL语句</param>
            /// <returns>int</returns>
            public bool Existence(string sql)
            {
                bool i = false;
                try
                {
                    string m = sql.Replace(" ", "").Trim();
                    for (int y = 0; y < m.Length; y++)
                    {
                        if (m.Substring(y, 4) == "'1=1" || m.Substring(y, 4) == "a'or" || m.Substring(y, 8) == "a'or'1=1")
                        {
                            return false;
                        }
                    }
                }
                catch { }
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    using (SqlServer.com = new SqlCommand())
                    {
                        com.CommandText = sql;
                        com.Connection = SqlServer.con;
                        int k = Convert.ToInt32(SqlServer.com.ExecuteScalar());
                        if (k > 0)
                        {
                            i = true;
                        }
                        else
                        {
                            i = false;
                        }
                    }
                }
                catch (Exception d)
                {
                    throw new Exception("登陆验证错误" + d.Message);
                }
                finally
                {
                    Closetheconnection();
                }
                return i;
            }

            /// <summary>
            /// 返回一个表
            /// </summary>
            /// <param name="sql">传入SQL语句</param>
            /// <returns>DataTable</returns>
            public DataTable ReturnDataTable(string sql)
            {
                SqlServer.set = new DataSet();
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    using (SqlServer.Ada = new SqlDataAdapter(sql, SqlServer.con))
                    {
                        SqlServer.Ada.Fill(SqlServer.set);
                    }
                }
                catch (Exception d)
                {
                    throw new Exception("数据表错误" + d.Message);
                }
                finally
                {
                    Closetheconnection();
                }
                return SqlServer.set.Tables[0];
            }

            /// <summary>
            /// 返回DataView
            /// </summary>
            /// <param name="sql">传入SQL语句</param>
            /// <returns>DataView</returns>
            public DataView ReturnDataView(string sql)
            {
                SqlServer.set = new DataSet();
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    using (SqlServer.Ada = new SqlDataAdapter(sql, SqlServer.con))
                    {
                        SqlServer.Ada.Fill(SqlServer.set);
                        SqlServer.dv = SqlServer.set.Tables[0].DefaultView;
                    }
                }
                catch (Exception d)
                {
                    throw new Exception("DataView错误" + d.Message);
                }
                finally
                {
                    Closetheconnection();
                }
                return dv;
            }

            /// <summary>
            /// 执行多条SQL语句，实现数据库事务。
            /// </summary>
            /// <param name="SQLStringList">多条SQL语句</param>
            /// <returns></returns>
            public bool SqlBatch(ArrayList SQLStringList)
            {
                bool i = false;
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    tr = SqlServer.con.BeginTransaction();
                    SqlServer.com = new SqlCommand();
                    SqlServer.com.Connection = tr.Connection;
                    SqlServer.com.Transaction = tr;
                    foreach (string sql in SQLStringList)
                    {
                        SqlServer.com.CommandText = sql;
                        SqlServer.com.ExecuteNonQuery();
                    }
                    tr.Commit();
                    i = true;
                }
                catch (SqlException d)
                {
                    i = false;
                    tr.Rollback();
                    throw new Exception("Sql语句批处理错误" + d.Message);
                }
                finally
                {
                    Closetheconnection();
                }
                return i;
            }
            /// <summary>
            ///  返回SQL查询数据表的数值
            /// </summary>
            /// <param name="sql">传入SQL语句</param>
            /// <returns>int</returns>
            public int ReturnQueries(string sql)
            {
                int k = 0;
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    SqlServer.com = new SqlCommand(sql, SqlServer.con);
                    k = Convert.ToInt32(SqlServer.com.ExecuteScalar());

                }
                catch (Exception d)
                {
                    throw new Exception("登陆验证错误" + d.Message);
                }
                finally
                {
                    Closetheconnection();
                }
                return k;
            }

           /// <summary>
            /// 返回SqlCommand
           /// </summary>
           /// <param name="sql">SQL语句</param>
           /// <returns></returns>
            public SqlCommand ReturnSqlCommand(string sql)
            {
                try
                {
                    SqlServer.con.Close();
                    SqlServer.con.Open();
                    using (SqlServer.com = new SqlCommand())
                    {
                        com.CommandText = sql;
                        com.Connection = SqlServer.con;
                        return com;
                    }
                }
                catch
                {
                    return null;
                }
            }

            /// <summary>
            /// 提交数据集
            /// </summary>
            /// <param name="datatable">datatable</param>
            /// <param name="table">目标表</param>
            /// <param name="i">超时时间秒</param>
            /// <param name="hs">总行数</param>
            /// <param name="sbcm">设置SqlBulkCopyColumnMapping导入到ArrayList</param>
            /// <returns>大于0执行成功</returns>
            public int SubmitDataTable(DataTable datatable, string table,int i,int hs,System.Collections.ArrayList sbcm)
            {
                SqlServer.con.Close();
                SqlServer.con.Open();
                sbc = new SqlBulkCopy(con);
                sbc.SqlRowsCopied += new SqlRowsCopiedEventHandler(sbc_SqlRowsCopied);
                foreach (SqlBulkCopyColumnMapping sm in sbcm)
                {
                    sbc.ColumnMappings.Add(sm);
                }
                sbc.BulkCopyTimeout = i;
                sbc.NotifyAfter = hs;
                try
                {
                    sbc.DestinationTableName = table;
                    sbc.WriteToServer(datatable);
                }
                catch { }
               
                return pcl;
            }
            public void sbc_SqlRowsCopied(object o,SqlRowsCopiedEventArgs e)
            {
                pcl = int.Parse(e.RowsCopied.ToString());
            }
            #endregion
        }

        /// <summary>
        /// Sql连接
        /// </summary>
        /// <returns>SqlServerInterface</returns>
        public static SqlServerInterface Creating()
        {
            return Achieve;
        }

        /// <summary>
        /// Sql连接
        /// </summary>
        /// <param name="Version">数据库版本</param>
        /// <param name="Database">数据库名字</param>
        /// <param name="Account">帐号</param>
        /// <param name="Password">密码</param>
        /// <param name="Address">数据库地址</param>
        /// <returns>SqlServerInterface</returns>
        public static SqlServerInterface Creating(string Version, string Database, string Account, string Password, string Address)
        {
            switch (Version)
            {
                case "Microsoft SQL Server 2008":
                    SqlServer.con = new SqlConnection();
                    con.ConnectionString = "server=" + Address + ";uid=" + Account + ";pwd=" + Password + ";database=" + Database + "";
                    break;
                case "Microsoft SQL Server 2005":
                    SqlServer.con = new SqlConnection();
                    con.ConnectionString = "server=" + Address + ";uid=" + Account + ";pwd=" + Password + ";database=" + Database + "";
                    break;
                case "Microsoft SQL Server 2000":
                    SqlServer.con = new SqlConnection();
                    con.ConnectionString = "server=" + Address + ";uid=" + Account + ";pwd=" + Password + ";database=" + Database + "";
                    break;
                default:
                    throw new Exception("此版本类库不支持" + Version + "数据库");
            }
            return Achieve;
        }
    }
}