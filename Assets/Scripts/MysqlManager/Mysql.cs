using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mysql : MonoBehaviour
{
    private void Start()
    {
        //连接数据库
        MysqlManager manager = new MysqlManager("localhost", "3306", "root", "password", "player");
        manager.OpenMysql();

        //创建数据表
        string[] col = new string[2];
        col[0] = "name";
        col[1] = "age";

        string[] colType = new string[2];
        colType[0] = "varchar(100)";
        colType[1] = "varchar(100)";
        //manager.UseDatabase("player");
        //manager.CreateTableAutoIncremID("info2", col, colType);

        //插入一组数据
        string[] values = new string[3];
        values[0] = "0";
        values[1] = Random.Range(0,1000).ToString();
        values[2] = Random.Range(0, 1000).ToString();
        //manager.InsertDataToTable("info2", values);

        //更新数据
        //manager.UpdateDataAtTable("info2", "name", "2222", "id", "1");

        manager.SelectDataAtTable("info2");
        //manager.DeleteDataAtTable("info2", "id", "1");
        //删除数据表
        //manager.DropTable("info");
        manager.CloseMysql();
    }
}
