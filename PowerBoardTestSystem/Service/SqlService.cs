using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBoardTestSystem.Dao;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PowerBoardTestSystem.Service
{
    public class SqlService
    {
        public string SqlName;

        public static void ReadRelaysFromSql()
        {
            FileInfo[] fileInfos = new DirectoryInfo(@".\").GetFiles("*.db");
            if (fileInfos.Length == 1)
            {
                try
                {
                    string dbFilePath = fileInfos[0].FullName;
                    var connection = new SQLiteConnection("Data Source = " + dbFilePath);
                    connection.Open();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else if (fileInfos.Length == 0)
            {
                MessageBox.Show("不存在数据库文件");
            }
            else
            {
                MessageBox.Show("目录下存在多个配置文件，请只保留一个后再试。");
            }
        }
    }
}
