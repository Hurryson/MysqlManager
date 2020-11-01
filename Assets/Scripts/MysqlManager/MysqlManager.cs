using UnityEngine;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;
using System.Net.Http.Headers;

public class MysqlManager : IMysqlManager
{
    private string mysqlIP = "localhost";

    private string mysqlPort = "3306";

    private string userID = "root";

    private string password = "root";

    private string tableName = "player";

    private string connectInfo = "";

    private MySqlConnection connection;

    private MySqlCommand command;
    /// <summary>
    /// 构造函数
    /// </summary>
    public MysqlManager(string ip,string port,string userid, string password, string tableName)
    {
        this.mysqlIP = ip;
        this.mysqlPort = port;
        this.userID = userid;
        this.password = password;
        this.tableName = tableName;
    }

    /// <summary>
    /// 链接数据库
    /// </summary>
    /// <returns>连接结果</returns>
    public bool OpenMysql()
    {
        bool isOpen = false;
        try
        {
            connectInfo = string.Format("Server = {0}; port = {1}; Database = {2}; User ID = {3}; Password = {4}; Pooling=true; Charset = utf8;",
            mysqlIP, mysqlPort, tableName, userID, password);

            connection = new MySqlConnection(connectInfo);
            connection.Open();
            isOpen = true;

            command = new MySqlCommand();
            command.Connection = connection;
            Debug.Log("数据库已连接...");
        }
        catch (Exception e)
        {
            Debug.Log("数据库连接失败... " + e);
        }
        return isOpen;
    }

    /// <summary>
    /// 关闭数据库
    /// </summary>
    public void CloseMysql()
    {
        if (connection != null)
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
    }

    #region 数据库操作
    public int CreateDatabase(string databaseName)
    {
        string query = "create database " + databaseName;
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int DropDatabase(string databaseName)
    {
        string query = "drop database " + databaseName;
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int UseDatabase(string databaseName)
    {
        string query = "use " + databaseName;
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }
    #endregion

    #region 数据表操作
    public int CreateTable(string tableName, string[] cols, string[] colType)
    {
        if (cols.Length != colType.Length)
        {
            throw new Exception("columns.Length != colType.Length");
        }

        string query = "create table " + tableName + " (" + cols[0] + " " + colType[0];

        for (int i = 1; i < cols.Length; ++i)
        {
            query += ", " + cols[i] + " " + colType[i];
        }

        query += ")";
        Debug.Log(query);
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int CreateTableAutoIncremID(string tableName, string[] cols, string[] colType, string idName = "id", string idType = "int")
    {
        if (cols.Length != colType.Length)
        {
            throw new Exception("columns.Length != colType.Length");
        }

        string query = "create table " + tableName + " (" + idName + " " + idType + " not null auto_increment";

        for (int i = 0; i < cols.Length; ++i)
        {
            query += ", " + cols[i] + " " + colType[i];
        }

        query += ",primary key (" +idName +"))";
        Debug.Log(query);
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int DropTable(string tableName)
    {
        string query = "drop table " + tableName;
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int InsertDataToTable(string tableName, string[] values)
    {
        string query = "insert into " + tableName + " values (" + "'" + values[0] + "'";

        for (int i = 1; i < values.Length; ++i)
        {
            query += ", " + "'" + values[i] + "'";
        }

        query += ")";

        Debug.Log(query);
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int UpdateDataAtTable(string tableName,string col,string newValue,string conditionCol,string conditionValue)
    {
        string query = "update " + tableName + " set " + col + " = " + newValue + " where " + conditionCol + " = " + conditionValue;
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int DeleteDataAtTable(string tableName, string conditionCol, string conditionValue)
    {
        string query = "delete from " + tableName + " where " + conditionCol + " = " + conditionValue;
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public DataSet SelectDataAtTable(string tableName)
    {
        string query = "select * from " + tableName;
        Debug.Log(query);
        command.CommandText = query;
        command.ExecuteNonQuery();
        MySqlDataReader reader = null;
        //reader = command.ExecuteReader();
        return null;
    }
    #endregion
}
