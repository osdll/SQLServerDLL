using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace SQL_Server_DLL
{
    public interface SqlServerInterface
    {
        #region 接口里的方法
        /// <summary>
        /// 判定数据库版本
        /// </summary>
        /// <param name="版本">数据库版本</param>
        /// <param name="路径">数据库所在的路径</param>
        /// <param name="密码">数据库密码</param>
        void Creating(string Version, string Database, string Account, string Password, string Address);

        /// <summary>
        /// 运用在显示单条数据上
        /// </summary>
        /// <param name="sql">传SQL语句</param>
        /// <returns>OleDbDataReader</returns>
        SqlDataReader ReturnSqlDataReader(string sql);

        /// <summary>
        /// 运用在增删改上
        /// </summary>
        /// <param name="sql">传SQL语句</param>
        /// <returns>int</returns>
        int Affected(string sql);

        /// <summary>
        /// 返回一个数据集
        /// </summary>
        /// <param name="sql">传SQL语句</param>
        /// <returns>DataSet</returns>
        DataSet ReturnDataSet(string sql);

        /// <summary>
        /// 登陆验证用返回0或1，0是登陆失败1是登陆成功
        /// </summary>
        /// <param name="sql">传SQL语句</param>
        /// <returns>int</returns>
        bool Existence(string sql);

        /// <summary>
        /// 返回一个表
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <returns>DataTable</returns>
        DataTable ReturnDataTable(string sql);

        /// <summary>
        /// 返回DataView
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <returns>DataView</returns>
        DataView ReturnDataView(string sql);
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        void Closetheconnection();
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <returns>int</returns>
        bool SqlBatch(ArrayList SQLStringList);
        /// <summary>
        ///  返回SQL查询数据表的数值
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <returns>int</returns>
        int ReturnQueries(string sql);
        /// <summary>
        /// 返回SqlCommand
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        SqlCommand ReturnSqlCommand(string sql);
        /// <summary>
        /// 提交数据集
        /// </summary>
        /// <param name="datatable">datatable</param>
        /// <param name="table">目标表</param>
        /// <param name="i">超时时间秒</param>
        /// <param name="hs">总行数</param>
        /// <param name="sbcm">设置SqlBulkCopyColumnMapping导入到ArrayList</param>
        /// <returns>大于0执行成功</returns>
        int SubmitDataTable(DataTable datatable, string table, int i, int hs, System.Collections.ArrayList sbcm);
        #endregion
    }
}