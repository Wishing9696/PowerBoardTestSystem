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
    public partial class MeasureFlowForm : System.Windows.Forms.Form
    {
        private int flowId;
        public string dbpath;
        static SqLiteService sqs;
        List<InstrumentBaseClass> channels;
       
        public MeasureFlowForm(string dbpath)
        {
            InitializeComponent();
            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            flowId = sqs.GetNewflowId("flow");
            channels = sqs.selectdevice("device", Types.CHANNEL);
        }

        public MeasureFlowForm(int flowId,string dbpath)
        {
            InitializeComponent();
            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            channels = sqs.selectdevice("device", Types.CHANNEL);
            this.flowId = flowId;
        }



        private void MeasureFlowForm_Load(object sender, EventArgs e)
        {
            bt_up.Enabled = false;
            bt_down.Enabled = false;
            bt_del.Enabled = false;

            foreach (var item in channels)
            {
                cb_channel.Items.Add(item.alias);
            }
            cb_type.Items.Add(Types.ELECTRICMETER);
            cb_type.Items.Add(Types.CARD);
            cb_type.SelectedIndex = -1;
            cb_channel.SelectedIndex = -1;

            FlowClass selectrelayflow = sqs.selectflow("flow", new FlowClass() { flowId = flowId, type = Types.MEASURE });

            JsonService jsonService = new JsonService(selectrelayflow.operates);

            OperateClass[] operates = jsonService.GetOperate();

            if (operates[0].operate == "reset")
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
                if ((cb_type.SelectedItem.ToString() != null) && (cb_channel.SelectedItem.ToString() != null))
                {
                    listView1.Items.Add(cb_channel.SelectedItem.ToString() + "," + cb_type.SelectedItem.ToString());
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
            if (listView1.Items.Count <= 0)
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
                string str = Regex.Match(item.ToString(), @"{\S*,\S*}").Value.Replace("{", "").Replace("}", "");

                OperateClass opt = new OperateClass(str.Split(',')[0],dbpath,str.Split(',')[1],Types.CHANNEL);
                operates[i] = opt;
                i++;
            }
            if (cb_reset.Checked && operates[0].operate != "reset")
            {
                addresetoperates[0] = new OperateClass("allCHANNEL","reset");
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

            FlowClass flow = new FlowClass(flowId, Types.MEASURE, operate);

            sqs.InsertOrUpdateData("flow", flow);

            this.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            bt_up.Enabled = true;
            bt_down.Enabled = true;
            bt_del.Enabled = true;
        }
    }
}
