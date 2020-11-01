
using System.Data;

interface IMysqlManager
{
    /// <summary>
    /// 链接数据库
    /// </summary>
    /// <returns>返回链接结果</returns>
    bool OpenMysql();

    /// <summary>
    /// 关闭数据库
    /// </summary>
    void CloseMysql();

    /// <summary>
    /// 创建数据库
    /// </summary>
    /// <param name="name">数据库名称</param>
    int CreateDatabase(string databaseName);

    /// <summary>
    /// 删除数据库
    /// </summary>
    /// <param name="name">数据库名称</param>
    int DropDatabase(string databaseName);

    /// <summary>
    /// 使用数据库
    /// </summary>
    /// <param name="name">数据库名称</param>
    /// <returns></returns>
    int UseDatabase(string databaseName);

    /// <summary>
    /// 创建数据表
    /// </summary>
    /// <param name="name">表名</param>
    /// <param name="cols">列名</param>
    /// <param name="colType">列类型</param>
    /// <returns></returns>
    int CreateTable(string tableName, string[] cols, string[] colType);

    /// <summary>
    /// 创建自增长ID的数据表
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="cols">列名</param>
    /// <param name="colType">列类型</param>
    /// <param name="idName">自增ID名</param>
    /// <param name="idType">自增ID类型</param>
    /// <returns>返回结果</returns>
    int CreateTableAutoIncremID(string tableName, string[] cols, string[] colType, string idName = "id", string idType = "int");

    /// <summary>
    /// 删除数据表
    /// </summary>
    /// <param name="name">数据表名</param>
    /// <returns></returns>
    int DropTable(string tableName);

    /// <summary>
    /// 插入内容到数据表
    /// </summary>
    /// <returns></returns>
    int InsertDataToTable(string tableName,string[] values);

    /// <summary>
    /// 单一条件更新表中的单一数据
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="col">列名</param>
    /// <param name="newValue">新数值</param>
    /// <param name="conditionCol">条件列名</param>
    /// <param name="conditionValue">条件值</param>
    /// <returns>返回结果</returns>
    int UpdateDataAtTable(string tableName, string col, string newValue, string conditionCol, string conditionValue);

    /// <summary>
    /// 单一条件删除表中的一组数据
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="conditionCol">条件列名</param>
    /// <param name="conditionValue">条件值</param>
    /// <returns></returns>
    int DeleteDataAtTable(string tableName,string conditionCol,string conditionValue);

    DataSet SelectDataAtTable(string tableName);
}