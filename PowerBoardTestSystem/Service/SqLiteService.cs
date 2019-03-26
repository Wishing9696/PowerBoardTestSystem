using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using PowerBoardTestSystem.Dao;
using System.Threading;

namespace PowerBoardTestSystem.Service
{
    class SqLiteService
    {
        string path;

        public SqLiteService(string PATH)
        {
            this.path = PATH;
        }
        //create a new database
        public void CreateDB()
        {
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {
                cn.Open();
            }
        }

        //delete a database
        public void DeleteDB()
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        //create a new table
        //colunname为列名，以逗号分隔，每列列名和类型以空格分隔，例如： id varchar(4) primary key,score int
        public void CreateTable(string tablename, string columnname)
        {
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {
                string cmd = "CREATE TABLE " + tablename + "(" + columnname + ")";
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                    new SQLiteCommand(cmd, cn).ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        //delete a table
        public void DeleteTable(string tablename)
        {
            string cmd = "DROP TABLE IF EXISTS " + tablename;
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                    new SQLiteCommand(cmd, cn).ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
        //delete all data
        public void DeleteAlldata(string tablename)
        {
            string cmd = "DELETE FROM " + tablename;
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                    new SQLiteCommand(cmd, cn).ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        //insert data to a table 
        //data为更新或插入的一行数据（按顺序），以逗号分隔,有则更新，无则插入
        public void InsertOrUpdateData(string devicetablename, InstrumentBaseClass devicedata)
        {
            object obj = new object();
            var selectCommand = string.Format("SELECT * FROM {0} WHERE type = '{1}' AND deviceId = {2}", devicetablename, devicedata.type.ToString(), devicedata.deviceId);
            var insertCommand = string.Format("INSERT INTO {0} (type, alias, deviceId) VALUES ('{1}', '{2}', {3})", devicetablename, devicedata.type.ToString(), devicedata.alias, devicedata.deviceId);
            var updateCommand = string.Format("UPDATE {0} SET alias = '{1}' WHERE type = '{2}' AND deviceId = {3}", devicetablename, devicedata.alias, devicedata.type.ToString(), devicedata.deviceId);
            bool isExist = false;
            using (SQLiteConnection conn = new SQLiteConnection("data source = " + path))
            {
                conn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectCommand, conn).ExecuteReader();
                if (reader.HasRows)
                {
                    isExist = true;
                }
                reader.Close();
                conn.Close();
            }
            using (SQLiteConnection conn = new SQLiteConnection("data source = " + path))
            {
                if (isExist)
                {
                    Monitor.Enter(obj);
                    conn.Open();
                    new SQLiteCommand(updateCommand, conn).ExecuteNonQuery();
                    Monitor.Exit(obj);
                }
                else
                {
                    Monitor.Enter(obj);
                    conn.Open();
                    new SQLiteCommand(insertCommand, conn).ExecuteNonQuery();
                    Monitor.Exit(obj);
                }
                conn.Close();
            }

        }

        public void InsertOrUpdateData(string flowtablename,FlowClass flowdata)
        {
            object obj = new object();
            var selectCommand = string.Format("SELECT * FROM {0} WHERE type = '{1}' AND flowId = {2}", flowtablename, flowdata.type.ToString(),flowdata.flowId );
            var insertCommand = string.Format("INSERT INTO {0} (type,flowId,operates) VALUES ('{1}', '{2}', '{3}')", flowtablename, flowdata.type.ToString(), flowdata.flowId,flowdata.operates.ToString());
            var updateCommand = string.Format("UPDATE {0} SET operates = '{1}' WHERE type = '{2}' AND flowId = '{3}'", flowtablename, flowdata.operates.ToString(), flowdata.type.ToString(), flowdata.flowId);
            bool isExist = false;
            using (SQLiteConnection conn = new SQLiteConnection("data source = " + path))
            {
                conn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectCommand, conn).ExecuteReader();
                if (reader.HasRows)
                {
                    isExist = true;
                }
                reader.Close();
                conn.Close();
            }
            using (SQLiteConnection conn = new SQLiteConnection("data source = " + path))
            {
                if (isExist)
                {
                    Monitor.Enter(obj);
                    conn.Open();
                    new SQLiteCommand(updateCommand, conn).ExecuteNonQuery();
                    Monitor.Exit(obj);
                }
                else
                {
                    Monitor.Enter(obj);
                    conn.Open();
                    new SQLiteCommand(insertCommand, conn).ExecuteNonQuery();
                    Monitor.Exit(obj);
                }
                conn.Close();
            }

        }

        //Select Data
        public string SelectData(string tablename, InstrumentBaseClass data, string obj)
        {
            var selectCommand = string.Format("SELECT {0} FROM {1} WHERE type = '{2}' AND deviceId = {3}", obj, tablename, data.type.ToString(), data.deviceId);
            string result = string.Empty;
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {

                cn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectCommand, cn).ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader[obj].ToString();
                }
                reader.Close();
                 cn.Close();
            }

            return result;
        }

        //Select deviceId
        public int SelectdeviceId(string tablename, string alias,Types type, string obj)
        {
            var selectCommand = string.Format("SELECT {0} FROM {1} WHERE alias = '{2}' and type = '{3}'", obj, tablename, alias,type);
            string result = string.Empty;
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {

                cn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectCommand, cn).ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader[obj].ToString();
                }
                reader.Close();
                cn.Close();
            }

            return Convert.ToInt32(result);
        }

        //Select alias
        public string Selectalias(string tablename, int deviceId, Types type,string obj)
        {
            var selectCommand = string.Format("SELECT {0} FROM {1} WHERE deviceId = {2} AND type = '{3}'", obj, tablename, deviceId,type);
            string result = string.Empty;
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {

                cn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectCommand, cn).ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader[obj].ToString();
                }
                reader.Close();
                cn.Close();
            }

            return result;
        }
        //Select FlowId
        public int GetNewflowId(string flowtablename)
        {
            try
            {
                var selectcmd = string.Format("SELECT * FROM {0} ORDER BY flowId DESC LIMIT 1", flowtablename);
                string maxid = string.Empty;

                using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
                {
                    cn.Open();
                    SQLiteDataReader reader = new SQLiteCommand(selectcmd, cn).ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        maxid = reader["flowId"].ToString();
                    }
                    reader.Close();
                    cn.Close();
                }

                return Convert.ToInt32(maxid) + 1;
            }
            catch
            {
                return 1;
            }          
        }
        //Select all flows' flowId where typr = ???
        public List<int> GetflowsId(string flowtablename, Types type)
        {
            List<int> flowIds = new List<int>();
            try
            {
                var selectcmd = string.Format("SELECT * FROM {0} WHERE TYPE = '{1}'", flowtablename, type);

                using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
                {
                    cn.Open();
                    SQLiteDataReader reader = new SQLiteCommand(selectcmd, cn).ExecuteReader();
                    while (reader.HasRows)
                    {
                        reader.Read();
                        flowIds.Add(Convert.ToInt32(reader["flowId"]));
                    }
                    reader.Close();
                    cn.Close();
                }

                return flowIds;
            }
            catch
            {
                return flowIds;
            }
        }


        //Select a Flow
        public FlowClass selectflow(string flowtablename, FlowClass flow)
        {
            var selectcmd = string.Format("SELECT * FROM {0} WHERE flowId = '{1}' AND type ='{2}'", flowtablename, flow.flowId,flow.type);

            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {
                cn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectcmd, cn).ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        flow.operates = reader["operates"].ToString();
                    }
                }
                reader.Close();
                cn.Close();

                return flow;
            }
        }

        //Select all flows
        public List<FlowClass> selectallflows(string flowtablename)
        {
            var selectcmd = string.Format("SELECT * FROM {0}", flowtablename);

            List<FlowClass> flows = new List<FlowClass>();

            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {
                cn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectcmd, cn).ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        flows.Add(new FlowClass(Convert.ToInt32(reader["flowId"]),
                            (Types)Enum.Parse(typeof(Types), reader["type"].ToString()), reader["operates"].ToString()));
                    }
                }
                reader.Close();
                cn.Close();

                return flows;
            }
        }

        //Select Device
        public List<InstrumentBaseClass> selectdevice(string devicetablename, Types type)
        {
            var selectcmd = string.Format("SELECT * FROM {0} WHERE type ='{1}'", devicetablename, type);

            List<InstrumentBaseClass> instruments = new List<InstrumentBaseClass>();           

            using (SQLiteConnection cn = new SQLiteConnection("data source=" + path))
            {
                cn.Open();
                SQLiteDataReader reader = new SQLiteCommand(selectcmd, cn).ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        InstrumentBaseClass device;

                        if (type == Types.RELAY)
                        {
                            device = new RelayClass();
                        }
                        else
                        {
                            device = new ChannelClass();
                        }
                        device.deviceId = Int32.Parse(reader["deviceId"].ToString());
                        device.type = (Types)Enum.Parse(typeof(Types), reader["type"].ToString());
                        device.alias = reader["alias"].ToString();
                        instruments.Add(device);
                    }
                }
                reader.Close();
                cn.Close();

                return instruments;
            }
        }
    }
}
