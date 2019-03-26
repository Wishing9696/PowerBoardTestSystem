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
using System.Text.RegularExpressions;

namespace PowerBoardTestSystem.Form.Flow
{
    public partial class RelayFlowForm : System.Windows.Forms.Form
    {
        int flowId;
        public string dbpath;
        static SqLiteService sqs;
        List<InstrumentBaseClass> relays;

        public RelayFlowForm(string dbpath)
        {           
            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            flowId = sqs.GetNewflowId("flow");
            relays = sqs.selectdevice("device", Types.RELAY);
            InitializeComponent();
        }
        

        public RelayFlowForm(int flowId, string dbpath)
        {

            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            relays = sqs.selectdevice("device", Types.RELAY);
            this.flowId = flowId;
            InitializeComponent();
        }


        private void RelayFlowForm_Load(object sender, EventArgs e)
        {
            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_del.Enabled = false;

            foreach (var item in relays)
            {
                cb_relay.Items.Add(item.alias);
            }

            cb_action.Items.Add("打开");
            cb_action.Items.Add("关闭");
             
            cb_relay.SelectedIndex = 0;
            cb_action.SelectedIndex = -1;

            FlowClass selectrelayflow = sqs.selectflow("flow", new FlowClass() { flowId = flowId, type = Types.RELAY });

            JsonService jsonService = new JsonService(selectrelayflow.operates);

            OperateClass[] operates = jsonService.GetOperate();

            if(operates[0].operate == "reset")
            {
                cb_reset.Checked = true;
            }
            else
            {
                cb_reset.Checked = false;
            }

            for (int i = 0; i < operates.Length; i++)
            {
                listView1.Items.Add(operates[i].ToString());
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cb_relay.SelectedItem.ToString() != null) && (cb_action.SelectedItem.ToString() != null))
                {
                    string str = "OFF";
                    if (cb_action.SelectedItem.ToString() == "打开")
                    {
                        str = "ON";
                    }

                    listView1.Items.Add(cb_relay.SelectedItem.ToString() + "," + str);
                }
                else
                {
                    MessageBox.Show("请选择相关操作再点击添加按钮");
                }
            }
            catch
            {
                MessageBox.Show("请选择相关操作再点击添加按钮");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            bt_up.Enabled = true;
            bt_down.Enabled = true;
            bt_del.Enabled = true;
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
            bt_del.Enabled = false;
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
            bt_del.Enabled = false;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count<=0)
            {
                MessageBox.Show("请添加流程！");
                return;
            }
            JsonService jsonService = new JsonService();
            OperateClass[] operates = new OperateClass[listView1.Items.Count];           
            OperateClass[] addresetoperates = new OperateClass[listView1.Items.Count + 1];
            OperateClass[] delresetoperates = new OperateClass[listView1.Items.Count - 1];
            string operate = string.Empty;
            int i = 0;
            foreach (var item in listView1.Items)
            {
                string str = Regex.Match(item.ToString(),@"{\S*,\S*}").Value.Replace("{","").Replace("}","");

                OperateClass opt = new OperateClass(str.Split(',')[0], dbpath,str.Split(',')[1],Types.RELAY);

                operates[i] = opt;
                i++;
            }
            if (cb_reset.Checked && operates[0].operate != "reset")
            {
                addresetoperates[0] = new OperateClass("allRELAY", "reset");
                for (int j = 0; j < operates.Length; j++)
                {
                    addresetoperates[j + 1] = operates[j];
                }
                operate = jsonService.SetOperate(addresetoperates);
            }
            else if (!cb_reset.Checked && operates[0].operate == "reset")
            {
                for (int j = 1; j < operates.Length; j++)
                {
                    delresetoperates[j - 1] = operates[j];
                }
                
                operate = jsonService.SetOperate(delresetoperates);
            }
            else
            {
                operate = jsonService.SetOperate(operates);
            }

            FlowClass flow = new FlowClass(flowId, Types.RELAY, operate);

            sqs.InsertOrUpdateData("flow", flow);

            this.Close();
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
            bt_del.Enabled = false;
        }
    }
}
