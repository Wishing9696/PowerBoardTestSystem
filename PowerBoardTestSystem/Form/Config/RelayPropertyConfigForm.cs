﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using PowerBoardTestSystem.Service;
using PowerBoardTestSystem.Dao;

namespace PowerBoardTestSystem.Form.Config
{
    public partial class RelayPropertyConfigForm : System.Windows.Forms.Form
    {

        List<MyLableAndTextBox> myLT = new List<MyLableAndTextBox>();
        int DBExist;
        private int flowId;
        string floderpath;

        public RelayPropertyConfigForm(string dbpath)
        {
            InitializeComponent();
            this.floderpath = Path.GetDirectoryName(dbpath);
        }

        public RelayPropertyConfigForm(int flowId,string dbpath)
        {
            this.flowId = flowId;
            this.floderpath = System.IO.Path.GetDirectoryName(dbpath);
        }

        public void RelayPropertyConfigForm_Load(object sender, EventArgs e)
        {

            AddAllLTs();

            // TODO read the sqlite db if there are relay config
            // if exist AND IS THE ONLY ONE
            // load and show AND FLAG DBEXIST = 1
            // else
            // FLAG DBEXIST = THE COUNT OF DB
            FileInfo[] fileInfos = new DirectoryInfo(floderpath).GetFiles("*.db");
            if (fileInfos.Length == 1)
            {
                try
                {
                    DBExist = 1;
                    string dbFilePath = fileInfos[0].FullName;
                    showSQLData(dbFilePath);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else if (fileInfos.Length == 0)
            {
                DBExist = 0;
                MessageBox.Show("不存在数据库文件");
            }
            else
            {
                DBExist = 2;
                MessageBox.Show("目录下存在多个配置文件，请只保留一个后重启程序再试。");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myLT.Count; i++)
            {
                for (int j = 0; j < myLT.Count; j++)
                {
                    if ((i != j) && (myLT[i].tb.Text == myLT[j].tb.Text))
                    {
                        MessageBox.Show("存在相同名字的设备");
                        return;
                    }
                }
            }
            string dbpath = floderpath + "./newFlow.db";
            SqLiteService sqs = new SqLiteService(dbpath);
            switch (DBExist)
            {
                case 0:
                    sqs.CreateDB();
                    sqs.CreateTable("device", "\"id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,\"type\" varchar(20) NOT NULL,\"deviceId\" INTEGER NOT NULL,\"alias\" varchar(20)");
                    sqs.CreateTable("flow", "\"id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,\"flowId\" INTEGER NOT NULL,\"type\" TEXT NOT NULL,\"operates\" TEXT NOT NULL");
                    DBExist = 1;
                    goto case 1;
                case 1:
                    try
                    {
                        sqs.CreateTable("device", "\"id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,\"type\" varchar(20) NOT NULL,\"deviceId\" INTEGER NOT NULL,\"alias\" varchar(20)");
                        sqs.CreateTable("flow", "\"id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,\"flowId\" INTEGER NOT NULL,\"type\" TEXT NOT NULL,\"operates\" TEXT NOT NULL");                       
                    }
                    catch
                    {

                    }
                    sqs.InsertOrUpdateData("device", new RelayClass(myLT.Count, "allRELAY"));
                    for (int i = 0; i < myLT.Count; i++)
                    {
                        sqs.InsertOrUpdateData("device", new RelayClass(i, myLT[i].tb.Text));
                        try
                        {
                            List<int> ids = sqs.GetflowsId("flow", Types.RELAY);
                            for (int j = 0; j < ids.Count; j++)
                            {
                                FlowClass selectrelayflow = sqs.selectflow("flow", new FlowClass() { flowId = ids[j], type = Types.RELAY });

                                JsonService jsonService = new JsonService(selectrelayflow.operates);
                                OperateClass[] operateshandle = jsonService.GetOperate();
                                OperateClass[] operates = new OperateClass[operateshandle.Length];
                                for (int k = 0; k < operateshandle.Length; k++)
                                {
                                    operates[k] = new OperateClass(operateshandle[k].deviceId, operateshandle[k].operate, Types.RELAY, dbpath);
                                }
                                sqs.InsertOrUpdateData("flow", new FlowClass(ids[j], Types.RELAY, jsonService.SetOperate(operates)));
                            }
                        }
                        catch (Exception a)
                        {
                            MessageBox.Show(a.Message);
                        }
                    }
                    break;
                case 2:
                    MessageBox.Show("目录下存在多个配置文件，请只保留一个后再试。");
                    break;

            }
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string[] GetTextData()
        {
            string[] data = new string[11];
            for (int i = 0; i <= 11; i++)
            {
                data[i] =myLT[i].lb.Text+","+ myLT[i].tb.Text;
            }
            return data;
        }
        //获取数据库中配置的继电器别名并显示
        public void showSQLData(string path)
        {

            SqLiteService sqs = new SqLiteService(path);
            for (int i = 0; i <= 11; i++)
            {
                myLT[i].tb.Text = sqs.SelectData("device", new RelayClass(i,myLT[i].tb.Text),"alias");
            }
        }

        public void AddAllLTs()
        {
            myLT.Add(new MyLableAndTextBox(label1, textBox1));
            myLT.Add(new MyLableAndTextBox(label2, textBox2));
            myLT.Add(new MyLableAndTextBox(label3, textBox3));
            myLT.Add(new MyLableAndTextBox(label4, textBox4));
            myLT.Add(new MyLableAndTextBox(label5, textBox5));
            myLT.Add(new MyLableAndTextBox(label6, textBox6));
            myLT.Add(new MyLableAndTextBox(label7, textBox7));
            myLT.Add(new MyLableAndTextBox(label8, textBox8));
            myLT.Add(new MyLableAndTextBox(label9, textBox9));
            myLT.Add(new MyLableAndTextBox(label10, textBox10));
            myLT.Add(new MyLableAndTextBox(label11, textBox11));
            myLT.Add(new MyLableAndTextBox(label12, textBox12));
        }

    }


}
