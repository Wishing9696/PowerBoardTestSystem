using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerBoardTestSystem.Dao;
using PowerBoardTestSystem.Service;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace PowerBoardTestSystem
{
    public partial class i : System.Windows.Forms.Form
    {
        public i()
        {
            InitializeComponent();
        }

        public static string dbpath;
        static SqLiteService sqs;

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!Directory.Exists("./config"))
            {
                Directory.CreateDirectory("./config");
            }
            createfile("./config/relayins.txt");
            createfile("./config/cardins.txt");
            createfile("./config/electricmeterins.txt");
        }

        private void createfile(string path)
        {
            if (!File.Exists(path))
            {
                var a = File.Create(path);
                a.Close();
                string[] tex = { "COM:", "波特率:" };
                File.WriteAllLines(path, tex);
            }
        }

        private void tmsi_create_Click(object sender, EventArgs e)
        {
            if (new Form.Config.PasswordForm().ShowDialog() == DialogResult.OK)
            {
                new PowerBoardTestSystem.Form.Config.ConfigForm().ShowDialog();
            }
        }


        private void bt_load_Click(object sender, EventArgs e)
        {
            show();
        }

        private void btn_startTest_Click(object sender, EventArgs e)
        {
            try
            {
                show();
                handle();
            }
            catch
            {
                MessageBox.Show("ERROR！！\r\n*****检查配置文件*****\r\n*****检查数据库文件*****");
            }
        }

        private void show()
        {
            if(dbpath.Length<=1)
            {
                MessageBox.Show("请选择数据库文件");
                return;
            }
            ListView1.Clear();
            try
            {
                List<FlowClass> flows = sqs.selectallflows("flow");
                foreach (var flow in flows)
                {
                    OperateClass[] operates = new JsonService().GetOperate(flow.operates);
                    string itemope = string.Empty;
                    foreach (var ope in operates)
                    {
                        itemope += ope.alias + "," + ope.operate + "|";
                    }
                    string flowstr = string.Format("{0}/{1}/{2}", flow.flowId, flow.type, itemope);
                    ListView1.Items.Add(flowstr);
                }
            }
            catch
            {
                MessageBox.Show("不存在数据库文件，请创建！");
            }

        }

        private string getfromfile(string type, string model)
        {
            string result = string.Empty;
            string[] config = { "", "" };
            switch (type)
            {
                case "RELAY":
                    config = File.ReadAllLines("./config/relayins.txt");
                    switch (model)
                    {
                        case "portName":
                            result = config[0].Split(':')[1];
                            break;
                        case "baudRate":
                            result = config[1].Split(':')[1];
                            break;
                    }
                    break;
                case "CARD":
                    config = File.ReadAllLines("./config/cardins.txt");
                    switch (model)
                    {
                        case "portName":
                            result = config[0].Split(':')[1];
                            break;
                        case "baudRate":
                            result = config[1].Split(':')[1];
                            break;
                    }
                    break;
                case "ELECTRICMETER":
                    config = File.ReadAllLines("./config/electricmeterins.txt");
                    switch (model)
                    {
                        case "portName":
                            result = config[0].Split(':')[1];
                            break;
                        case "baudRate":
                            result = config[1].Split(':')[1];
                            break;
                    }
                    break;
            }
            return result;
        }

        public void handle()
        {
            SerialPort relayport = new SerialPort {
                PortName = getfromfile("RELAY", "portName"),
                BaudRate = Convert.ToInt32(getfromfile("RELAY", "baudRate"))
            }; 
            List<FlowClass> flows = sqs.selectallflows("flow");
            foreach(var flow in flows)
            {
                OperateClass[] operates = new JsonService().GetOperate(flow.operates);
                switch(flow.type)
                {
                    case Types.RELAY:
                        foreach (var operate in operates)
                        {
                            if (operate.operate == "ON")
                            {
                                new RelayClass(operate.deviceId,relayport).Open(operate.deviceId);
                            }
                            else if(operate.operate == "OFF")
                            {
                                new RelayClass(operate.deviceId,relayport).Close(operate.deviceId);
                            }
                            else if(operate.operate == "reset")
                            {
                                RelayClass.Reset();
                            }
                        }
                        break;

                    case Types.MEASURE:
                        foreach (var operate in operates)
                        {
                            if (operate.operate == "reset")
                            {
                                ChannelClass.Reset();
                            }
                            else
                            {
                                switch((Types)Enum.Parse(typeof(Types), operate.alias))
                                {
                                    case Types.CARD:
                                        CardClass card = new CardClass();                                       
                                        SerialPort cardport = new SerialPort
                                        {
                                            PortName = getfromfile("CARD", "portName"),
                                            BaudRate = Convert.ToInt32(getfromfile("CARD", "baudRate"))
                                        };



                                        card.Open();
                                        ChannelClass channel = new ChannelClass(operate.deviceId,cardport);
                                        channel.Open(operate.deviceId);
                                        channel.Close(operate.deviceId);
                                        card.Close();

                                        break;
                                    case Types.ELECTRICMETER:
                                        SerialPort elecport = new SerialPort
                                        {
                                            PortName = getfromfile("ELECTRICMETER", "portName"),
                                            BaudRate = Convert.ToInt32(getfromfile("ELECTRICMETER", "baudRate"))
                                        };




                                        ElectricmeterClass electricmeter = new ElectricmeterClass(operate.deviceId,elecport);
                                        electricmeter.Open();
                                        break;
                                }
                            }
                        }
                        break;

                    case Types.TIMEDELAY:
                        Thread.Sleep(Convert.ToInt32(operates[0].operate));
                        break;

                    case Types.TIP:
                        MessageBox.Show(operates[0].operate);
                        break;

                    default:
                        break;
                }
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDBFile.ShowDialog();
            string dbfilename = openDBFile.FileName;
            dbpath = dbfilename;
            sqs = new SqLiteService(dbpath);
            show();
        }
    }
}
