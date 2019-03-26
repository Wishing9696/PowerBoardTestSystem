using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerBoardTestSystem.Dao;
using PowerBoardTestSystem.Service;

namespace PowerBoardTestSystem.Form.Config
{
    public partial class ConfigForm : System.Windows.Forms.Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        public static string dbpath;
        static SqLiteService sqs;

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            
            string floder = "";
            int i = 0;
            while(floder == "")
            {
                floderchoose.ShowDialog();
                floder = floderchoose.SelectedPath;
                i++;
                if(i==3)
                {
                    this.Close();
                }
            }

            dbpath = floder + "./newFlow.db";
            sqs = new SqLiteService(dbpath);


            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_update.Enabled = false;
            bt_del.Enabled = false;
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
            show();
        }


        private void listView1_Click(object sender, EventArgs e)
        {
            bt_del.Enabled = true;
            bt_update.Enabled = true;
            bt_up.Enabled = true;
            bt_down.Enabled = true;
        }

        private void bt_up_Click(object sender, EventArgs e)
        {
            var temp = listView1.SelectedItems;
            var cIndex = listView1.SelectedIndices[0];
            if (cIndex >= 1)
            {
                var items = listView1.Items;
                var cItem = items[cIndex];
                items.RemoveAt(cIndex);
                items.Insert(cIndex - 1, cItem);
                var itemArray = new ListViewItem[items.Count];
                items.CopyTo(itemArray, 0);

                listView1.Clear();

                listView1.Items.AddRange(itemArray);
            }
            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_update.Enabled = false;
            bt_del.Enabled = false;
            bt_save.PerformClick();
            show();
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            var temp = listView1.SelectedItems;
            var cIndex = listView1.SelectedIndices[0];
            if (cIndex <= listView1.Items.Count)
            {
                var items = listView1.Items;
                var cItem = items[cIndex];
                items.RemoveAt(cIndex);
                items.Insert(cIndex + 1, cItem);
                var itemArray = new ListViewItem[items.Count];
                items.CopyTo(itemArray, 0);

                listView1.Clear();

                listView1.Items.AddRange(itemArray);
            }
            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_update.Enabled = false;
            bt_del.Enabled = false;
            bt_save.PerformClick();
            show();
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            var temp = listView1.SelectedItems;
            var cIndex = listView1.SelectedIndices[0];
            if (cIndex >= 0)
            {
                var items = listView1.Items;
                var cItem = items[cIndex];
                items.RemoveAt(cIndex);

                var itemArray = new ListViewItem[items.Count];
                items.CopyTo(itemArray, 0);

                listView1.Clear();

                listView1.Items.AddRange(itemArray);
            }
            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_update.Enabled = false;
            bt_del.Enabled = false;
            bt_save.PerformClick();
            show();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            List<FlowClass> flows = new List<FlowClass>();
            int newflowId = 1;
            foreach (var item in listView1.Items)
            {
                string str = Regex.Match(item.ToString(), @"{[\S|\s]+}").Value.Replace("{", "").Replace("}", "");
                string[] operates = str.Split('/')[2].Split('|');
                OperateClass[] opes = new OperateClass[operates.Length - 1];
                string type = string.Empty;
                if(str.Split('/')[1] == "MEASURE")
                {
                    type = "CHANNEL";
                }
                else
                {
                    type = str.Split('/')[1];
                }
                for (int i = 0; i < operates.Length - 1; i++)
                {
                    switch((Types)Enum.Parse(typeof(Types), type))
                    {
                        case Types.RELAY:
                            if (operates[i].Split(',')[1] == "reset")
                            {
                                opes[i] = new OperateClass(operates[i].Split(',')[0], operates[i].Split(',')[1]);
                            }
                            else
                            {
                                opes[i] = new OperateClass(operates[i].Split(',')[0], dbpath, operates[i].Split(',')[1], (Types)Enum.Parse(typeof(Types), type));
                            }
                            break;
                        case Types.CHANNEL:
                            if (operates[i].Split(',')[1] == "reset")
                            {
                                opes[i] = new OperateClass(operates[i].Split(',')[0], operates[i].Split(',')[1]);
                            }
                            else
                            {
                                opes[i] = new OperateClass(operates[i].Split(',')[0], dbpath, operates[i].Split(',')[1], (Types)Enum.Parse(typeof(Types), type));
                            }
                            break;
                        case Types.TIMEDELAY:
                            opes[i] = new OperateClass(operates[i].Split(',')[0], operates[i].Split(',')[1]);
                            break;
                        case Types.TIP:
                            opes[i] = new OperateClass(operates[i].Split(',')[0], operates[i].Split(',')[1]);
                            break;
                        default:
                            break;
                    }                    
                }

                flows.Add(new FlowClass(newflowId,
                    (Types)Enum.Parse(typeof(Types), str.Split('/')[1]),
                   new JsonService().SetOperate(opes)));
                newflowId++;
            }

            sqs.DeleteAlldata("flow");

            foreach (var item in flows)
            {
                sqs.InsertOrUpdateData("flow", item);
            }
            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_update.Enabled = false;
            bt_del.Enabled = false;
            MessageBox.Show("OK!");
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            string str = listView1.FocusedItem.Text;
            int flowId = Convert.ToInt32(str.Split('/')[0]);
            Types type = (Types)Enum.Parse(typeof(Types), str.Split('/')[1]);

            switch (type)
            {
                case Types.RELAY:
                    new Flow.RelayFlowForm(flowId, dbpath).ShowDialog();
                    show();
                    break;
                case Types.MEASURE:
                    new Flow.MeasureFlowForm(flowId, dbpath).ShowDialog();
                    show();
                    break;
                case Types.TIMEDELAY:
                    new Flow.TimeDelayForm(flowId, dbpath).ShowDialog();
                    show();
                    break;
                case Types.TIP:
                    new Flow.TipForm(flowId, dbpath).ShowDialog();
                    show();
                    break;
                default:
                    break;
            }
            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_update.Enabled = false;
            bt_del.Enabled = false;
        }

        private void tsmi_relayProperty_Click(object sender, EventArgs e)
        {
            new RelayPropertyConfigForm(dbpath).ShowDialog();
            show();
        }

        private void tsmi_measureChannelProperty_Click(object sender, EventArgs e)
        {
            new MeasureChannelPropertyConfigForm(dbpath).ShowDialog();
            show();
        }

        private void btn_addRelayFlow_Click(object sender, EventArgs e)
        {
            try
            {
                new Flow.RelayFlowForm(dbpath).ShowDialog();
                show();
            }
            catch
            {
                MessageBox.Show("请先完善继电器和通道配置！");
            }
        }

        private void btn_addMeasureFlow_Click(object sender, EventArgs e)
        {
            try
            {
                new Flow.MeasureFlowForm(dbpath).ShowDialog();
                show();
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message+"请先完善继电器和通道配置！");
            }
        }

        private void btn_addDelayFlow_Click(object sender, EventArgs e)
        {
            try
            {
                new Flow.TimeDelayForm(dbpath).ShowDialog();
                show();
            }
            catch
            {
                MessageBox.Show("请先完善继电器和通道配置！");
            }
        }

        private void btn_addAlertFlow_Click(object sender, EventArgs e)
        {
            try
            {
                new Flow.TipForm(dbpath).ShowDialog();
                show();
            }
            catch
            {
                MessageBox.Show("请先完善继电器和通道配置！");
            }
        }

        private void show()
        {
            listView1.Clear();
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
                    listView1.Items.Add(flowstr);
                }
            }
            catch
            {
                MessageBox.Show("不存在数据库文件，请创建！");
            }
        }

    }
}
