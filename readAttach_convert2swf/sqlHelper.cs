using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Data.OracleClient;

namespace readAttach_convert2swf
{
    class sqlHelper
    {
        #region 通用方法
        // 数据连接池
        //private SqlConnection con;
        private OracleConnection con;
        
        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static String GetSqlConnection()
        {
            //String conn = ConfigurationManager.AppSettings["connectionString"].ToString();
            string conn = ConfigurationManager.ConnectionStrings["conn"].ToString();
            return conn;
        }
        #endregion
        #region 执行sql字符串
        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="Sqlstr"></param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }
        /// <summary>
        /// 执行带参数的SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象数组</param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr, SqlParameter[] param)
        {
            String ConnStr = GetSqlConnection();
            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                cmd.Parameters.AddRange(param);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }
        /// <summary>
        /// 返回DataReader
        /// </summary>
        /// <param name="Sqlstr"></param>
        /// <returns></returns>
        public static OracleDataReader ExecuteReader(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            OracleConnection conn = new OracleConnection(ConnStr);//返回DataReader时,是不可以用using()的
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);//关闭关联的Connection
            }
            catch //(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 执行SQL语句并返回数据表
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                OracleDataAdapter da = new OracleDataAdapter(Sqlstr, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        /// <summary>
        /// 执行SQL语句并返回DataSet
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static DataSet ExecuteDs(String Sqlstr)
        {
            String ConnStr = GetSqlConnection();
            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                OracleDataAdapter da = new OracleDataAdapter(Sqlstr, conn);
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }
        #endregion
        #region 操作存储过程
        /// <summary>
        /// 运行存储过程(已重载)
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <returns>存储过程的返回值</returns>
        public int RunProc(string procName)
        {
            OracleCommand cmd = CreateCommand(procName, null);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>
        /// 运行存储过程(已重载)
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="prams">存储过程的输入参数列表</param>
        /// <returns>存储过程的返回值</returns>
        public int RunProc(string procName, OracleParameter[] prams)
        {
            OracleCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters[0].Value;
        }
        /// <summary>
        /// 运行存储过程(已重载)
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="dataReader">结果集</param>
        public void RunProc(string procName, out OracleDataReader dataReader)
        {
            OracleCommand cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 运行存储过程(已重载)
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="prams">存储过程的输入参数列表</param>
        /// <param name="dataReader">结果集</param>
        public void RunProc(string procName, OracleParameter[] prams, out OracleDataReader dataReader)
        {
            OracleCommand cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 创建Command对象用于访问存储过程
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="prams">存储过程的输入参数列表</param>
        /// <returns>Command对象</returns>
        private OracleCommand CreateCommand(string procName, OracleParameter[] prams)
        {
            // 确定连接是打开的
            Open();
            //command = new OracleCommand( sprocName, new OracleConnection( ConfigManager.DALConnectionString ) );
            OracleCommand cmd = new OracleCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            // 添加存储过程的输入参数列表
            if (prams != null)
            {
                foreach (OracleParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            // 返回Command对象
            return cmd;
        }
        /// <summary>
        /// 创建输入参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新参数对象</returns>
        public OracleParameter MakeInParam(string ParamName, OracleType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        /// <summary>
        /// 创建输出参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新参数对象</returns>
        public OracleParameter MakeOutParam(string ParamName, OracleType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }
        /// <summary>
        /// 创建存储过程参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数的方向(输入/输出)</param>
        /// <param name="Value">参数值</param>
        /// <returns>新参数对象</returns>
        public OracleParameter MakeParam(string ParamName, OracleType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OracleParameter param;
            if (Size > 0)
            {
                param = new OracleParameter(ParamName, DbType, Size);
            }
            else
            {
                param = new OracleParameter(ParamName, DbType);
            }
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }
            return param;
        }
        #endregion
        #region 数据库连接和关闭
        /// <summary>
        /// 打开连接池
        /// </summary>
        private void Open()
        {
            // 打开连接池
            if (con == null)
            {
                //这里不仅需要using System.Configuration;还要在引用目录里添加
                con = new OracleConnection(GetSqlConnection());
                con.Open();
            }
        }
        /// <summary>
        /// 关闭连接池
        /// </summary>
        public void Close()
        {
            if (con != null)
                con.Close();
        }
        /// <summary>
        /// 释放连接池
        /// </summary>
        public void Dispose()
        {
            // 确定连接已关闭
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
        #endregion
    }
}
